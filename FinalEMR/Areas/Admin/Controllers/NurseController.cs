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
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Doctor + "," + SD.Role_Privi_Nurse + "," + SD.Role_Nurse)]
    public class NurseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public NurseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Doctor +  "," + SD.Role_Privi_Nurse)]
        public IActionResult Upsert(int? id)
        {
            Nurse nurse = new Nurse();
            if (id == null)
            {
                //this is for create
                return View(nurse);
            }
            //this is for edit
            nurse = _unitOfWork.Nurse.Get(id.GetValueOrDefault());
            if (nurse == null)
            {
                return NotFound();
            }

            return View(nurse);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Nurse nurse)
        {
            if (ModelState.IsValid)
            {
                if (nurse.Id == 0)
                {
                    //Adds new nurse
                    _unitOfWork.Nurse.Add(nurse);
                }
                else
                {
                    _unitOfWork.Nurse.Update(nurse);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(nurse);
        }

        #region API CAllS
        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Nurse.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Nurse.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.Nurse.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion
    }
}
