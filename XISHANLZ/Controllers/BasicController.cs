using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LZ.IService;
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
        public ActionResult UserIndex()
        {
            var userList=_baseService.GetUserList();
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
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // POST: Base/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserEdit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // POST: Base/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserDelete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}