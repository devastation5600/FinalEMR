using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FinalEMR.DataAccess.Repository.IRepository;
using FinalEMR.Models;
using FinalEMR.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using FinalEMR.Utility;

namespace FinalEMR.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Doctor + "," + SD.Role_Privi_Nurse + "," + SD.Role_Nurse)]
    public class PatientController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PatientController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Doctor + "," + SD.Role_Privi_Nurse)]
        public IActionResult Upsert(int? id)
        {
            PatientVM patientVM = new PatientVM()
            {
                Patient = new Patient(),
                PrescriptionList = _unitOfWork.Prescription.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                AllergyList = _unitOfWork.Allergy.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                DoctorList = _unitOfWork.Doctor.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                NurseList = _unitOfWork.Nurse.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
        };
            if (id == null)
            {
                //this is for create
                return View(patientVM);
            }
            //this is for edit
            patientVM.Patient = _unitOfWork.Patient.Get(id.GetValueOrDefault());
            if (patientVM.Patient == null)
            {
                return NotFound();
            }

            return View(patientVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(PatientVM patientVM)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\patients\");
                    var extension = Path.GetExtension(files[0].FileName);

                    if (patientVM.Patient.ImageUrl != null)
                    {
                        //this is for edit (To remove an old image)
                        var imagePath = Path.Combine(webRootPath, patientVM.Patient.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }
                    using (var filesStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(filesStreams);
                    }
                    patientVM.Patient.ImageUrl = @"\images\patients\" + fileName + extension;
                }
                else
                {
                    //Update when Image is not changed
                    if (patientVM.Patient.Id != 0)
                    {
                        Patient objFromDb = _unitOfWork.Patient.Get(patientVM.Patient.Id);
                        patientVM.Patient.ImageUrl = objFromDb.ImageUrl;
                    }

                }

                if (patientVM.Patient.Id == 0)
                {
                    //Adds new patient
                    _unitOfWork.Patient.Add(patientVM.Patient);
                }
                else
                {
                    _unitOfWork.Patient.Update(patientVM.Patient);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                patientVM.PrescriptionList = _unitOfWork.Prescription.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                patientVM.DoctorList = _unitOfWork.Doctor.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                patientVM.AllergyList = _unitOfWork.Allergy.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });                
                patientVM.DoctorList = _unitOfWork.Doctor.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });                
                patientVM.NurseList = _unitOfWork.Nurse.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                patientVM.DoctorList = _unitOfWork.Doctor.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                patientVM.NurseList = _unitOfWork.Nurse.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                patientVM.NurseList = _unitOfWork.Nurse.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                if (patientVM.Patient.Id != 0)
                {
                    patientVM.Patient = _unitOfWork.Patient.Get(patientVM.Patient.Id);
                }
            }
            return View(patientVM);
        }

        #region API CAllS
        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Patient.GetAll(includeProperties: "Prescription,Allergy,Doctor,Nurse");
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Patient.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            string webRootPath = _hostEnvironment.WebRootPath;
            var imagePath = Path.Combine(webRootPath, objFromDb.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            _unitOfWork.Patient.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion
    }
}
