using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
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
    public class AllergyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AllergyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            Allergy allergy = new Allergy();
            if (id == null)
            {
                //this is for create
                return View(allergy);
            }
            //this is for edit
            var parameter = new DynamicParameters();
            parameter.Add(@"Id", id);
            allergy = _unitOfWork.SP_Call.OneRecord<Allergy>(SD.Proc_Allergy_Get, parameter);
            if (allergy == null)
            {
                return NotFound();
            }

            return View(allergy);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Allergy allergy)
        {
            if (ModelState.IsValid)
            {
                var parameter = new DynamicParameters();
                parameter.Add(@"Name", allergy.Name);

                if (allergy.Id == 0)
                {
                    //Adds new prescription
                    _unitOfWork.SP_Call.Execute(SD.Proc_Allergy_Create, parameter);
                }
                else
                {
                    parameter.Add(@"Id", allergy.Id);
                    _unitOfWork.SP_Call.Execute(SD.Proc_Allergy_Update, parameter);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(allergy);
        }

        #region API CAllS
        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.SP_Call.List<Allergy>(SD.Proc_Allergy_GetAll, null);
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Id", id);
            var objFromDb = _unitOfWork.SP_Call.OneRecord<Allergy>(SD.Proc_Allergy_Get, parameter);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.SP_Call.Execute(SD.Proc_Allergy_Delete, parameter);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion
    }
}
