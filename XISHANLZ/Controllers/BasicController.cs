using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using common.Tools.Helper;
using LZ.IService;
using LZ.Model.Models;
using LZ.Model.Request;
using LZ.Model.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LZ.Web.Controllers
{
    public class BasicController : Controller
    {
        #region 构造函数
        private IBaseService _baseService;
        public BasicController(IBaseService baseService)
        {
            _baseService = baseService;
        }
        #endregion
        // GET: Base
        public ActionResult UserIndex(BasePageRequest request)
        {
            var userList = _baseService.GetUserList(request);
            return View(userList);
        }

        // GET: Base/Details/5
        public ActionResult UserDetails(int Id)
        {
            var user = _baseService.GetUserByID(Id).Result;
            return View(user);
        }



        // POST: Base/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserCreate(IFormCollection collection)
        {//mvc原生 不推荐 ，需要手动转码，推荐UserEdit方式
            try
            {
                // TODO: Add insert logic here
                User user = new User();
                user.Name = collection["Name"].ToString();
                user.Account = collection["Account"].ToString();
                user.PassWord = RSACryptionHelper.RSAEncrypt(collection["PassWord"].ToString());
                user.CreateTime = DateTime.Now;
                user.UpdateTime = DateTime.Now;
                user.CreateUserId = 1;
                user.CreateUserName = "管理员";
                _baseService.CreateUser(user);
                return RedirectToAction("UserIndex");
            }
            catch
            {
                return View();
            }
        }

        // POST: Base/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserEdit([FromBody]EditUserRequest request)
        {//推荐采用这种方式进行表单提交 json 转化了类型 
            var user = _baseService.EditUser(request);
            return RedirectToAction("UserIndex");
        }





        // POST: Base/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserDelete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                _baseService.DeleteUser(id);
                return RedirectToAction("UserIndex");
            }
            catch
            {
                return View();
            }
        }
    }
}