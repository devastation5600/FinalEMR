using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FinalEMR.Models;
using FinalEMR.Models.ViewModels;
using FinalEMR.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace FinalEMR.Areas.Staff.Controllers
{
    [Area("Staff")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            IEnumerable<Patient> patientList = _unitOfWork.Patient.GetAll(includeProperties: "Prescription,Allergy");
            return View(patientList);
        }

        public IActionResult Details(int id)    
        {
            var patientFromDb = _unitOfWork.Patient
                                .GetFirstOrDefault(u => u.Id == id, includeProperties:"Prescription,Allergy");
            Record recordObj = new Record()
            {
                Patient = patientFromDb,
                PatientId = patientFromDb.Id
            };
            return View(recordObj);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Details(Record RecordObject)
        {
            RecordObject.Id = 0;
            if (ModelState.IsValid)
            {
                //Will add to record
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                RecordObject.ApplicationUserId = claim.Value;

                Record recordFromDb = _unitOfWork.Record.GetFirstOrDefault(
                    u => u.ApplicationUserId == RecordObject.ApplicationUserId && u.PatientId == RecordObject.PatientId,
                    includeProperties: "Patient"
                    );

                if (recordFromDb == null)
                {
                    //Record Object is Empty for the Patient
                    _unitOfWork.Record.Add(RecordObject);
                }
                else {
                    _unitOfWork.Record.Update(recordFromDb);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else 
            {
                var patientFromDb = _unitOfWork.Patient
                                .GetFirstOrDefault(u => u.Id == RecordObject.PatientId, includeProperties:"Prescription,Allergy");
                Record recordObj = new Record()
                {
                    Patient = patientFromDb,
                    PatientId = patientFromDb.Id
                };
                return View(recordObj);
            }

            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
