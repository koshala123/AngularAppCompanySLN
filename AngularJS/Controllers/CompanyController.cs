using Buisness_Layer;
using Data_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularJS.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        private CompanyRepo _companyRepo;
        public CompanyController(CompanyRepo companyRepo)
        {
            _companyRepo = companyRepo;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CreateRecord(Company company)
        {
            _companyRepo.CreateCompany(company);
            string res = "Inserted";
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ShowData()
        {
            return View();
        }

        public JsonResult GetData()
        {
            var users = _companyRepo.GetCompanyDetails();

            return Json(users, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteData(int Id)
        {
            _companyRepo.DeleteCompany(Id);
            string res = "Successfully deleted";
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateView()
        {
            return View();
        }

        public JsonResult GetDataById(int Id)
        {

            var company = _companyRepo.GetCompanyDetail(Id);
          
            return Json(company, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateData(Company company)
        {
            _companyRepo.UpdateCompany(company);
            string res = "Updated";

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStatus()
        {
            var results = _companyRepo.GetStatus();
            return Json(results, JsonRequestBehavior.AllowGet);
        }

    }
}