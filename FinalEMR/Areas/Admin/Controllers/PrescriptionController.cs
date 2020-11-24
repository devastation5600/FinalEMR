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
    [Authorize(Roles = SD.Role_Admin)]
    public class PrescriptionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PrescriptionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            Prescription prescription = new Prescription();
            if (id == null)
            {
                //this is for create
                return View(prescription);
            }
            //this is for edit
            prescription = _unitOfWork.Prescription.Get(id.GetValueOrDefault());
            if (prescription == null)
            {
                return NotFound();
            }

            return View(prescription);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                if (prescription.Id == 0)
                {
                    //Adds new prescription
                    _unitOfWork.Prescription.Add(prescription);
                }
                else
                {
                    _unitOfWork.Prescription.Update(prescription);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(prescription);
        }

        #region API CAllS
        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Prescription.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Prescription.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.Prescription.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion
    }
}
