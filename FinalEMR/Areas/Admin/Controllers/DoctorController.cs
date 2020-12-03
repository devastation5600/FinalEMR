using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalEMR.DataAccess.Repository.IRepository;
using FinalEMR.Models;
using FinalEMR.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace FinalEMR.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Doctor + "," + SD.Role_Privi_Nurse)]
    public class DoctorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoctorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Upsert(int? id)
        {
            Doctor doctor = new Doctor();
            if (id == null)
            {
                //this is for create
                return View(doctor);
            }
            //this is for edit
            doctor = _unitOfWork.Doctor.Get(id.GetValueOrDefault());
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                if (doctor.Id == 0)
                {
                    //Adds new doctor
                    _unitOfWork.Doctor.Add(doctor);
                }
                else
                {
                    _unitOfWork.Doctor.Update(doctor);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }

        #region API CAllS
        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Doctor.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Doctor.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.Doctor.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion
    }
}
