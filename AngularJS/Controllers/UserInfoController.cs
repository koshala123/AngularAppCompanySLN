using Buisness_Layer;
using Data_Layer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularJS.Controllers
{
    public class UserInfoController : Controller
    {
        private IUserRepo _userRepo;
        public UserInfoController(IUserRepo  userRepo)
        {
            _userRepo = userRepo;
        }
        // GET: UserInfo
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CreateRecord(User_Information userInformation)
        {
            _userRepo.CreateUser(userInformation);
            string res = "Inserted";
            return Json(res,JsonRequestBehavior.AllowGet);
        }

        public ActionResult ShowData()
        {
            return View();
        }

        public JsonResult GetData()
        {
            var users = _userRepo.GetUserInformations();
            
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update_record(int Id)
        {
            return View();
        }

        public JsonResult Update_recordReal(User_Information userInformation)
        {
            _userRepo.UpdateUser(userInformation);
            string res = "Updated";
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDataById(int Id)
        {
            var user = _userRepo.GetUserInformation(Id);
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        public  JsonResult Delete_record(int Id)
        {
            _userRepo.DeleteUser(Id);
            string res = "Successfully Deleted";
            return Json(res,JsonRequestBehavior.AllowGet);
        }

        
    }
}