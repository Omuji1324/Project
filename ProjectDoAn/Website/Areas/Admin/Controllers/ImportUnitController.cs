﻿using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Website.Infrastructure;

namespace Website.Areas.Admin.Controllers
{
    [CustomAuthenticationFilter]

    [CustomAuthorize("Admin", "Manager")]
    public class ImportUnitController : Controller
    {
        // GET: ImportUnit
        public ActionResult Index(int page = 1, int size = 10)
        {
            ViewBag.page = page;
            ViewBag.size = size;
            return View();
        }
        public ActionResult ListImportUnit(int page = 1, int size = 10)
        {
            ViewBag.page = page;
            ViewBag.size = size;
            int skip = (page - 1) * size;
            LibData.Provider.ImportUnitProvider importUnitProvider = new LibData.Provider.ImportUnitProvider();
            var list = importUnitProvider.GetAll(skip, size);
            var count = importUnitProvider.CountAll();
            StaticPagedList<LibData.ImportUnit> pagedList = new StaticPagedList<LibData.ImportUnit>(list, page, size, count);
            return View(pagedList);
        }
        [HttpGet]
        public ActionResult AddImportUnit(int? id)
        {
            LibData.ImportUnit importUnit = new LibData.ImportUnit();
            if (id.HasValue)
            {
                importUnit = new LibData.Provider.ImportUnitProvider().GetById(id.Value);
            }
            return View(importUnit);
        }
        [HttpPost]
        public ActionResult AddImportUnit(LibData.ImportUnit model)
        {
            LibData.Provider.ImportUnitProvider importUnitProvider = new LibData.Provider.ImportUnitProvider();
            if (string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError("Name", "Tên nhà cung cấp không được để trống");
            }
            else if(importUnitProvider.CheckName(model))
            {
                ModelState.AddModelError("Name", "Tên nhà cung cấp đã tồn tại");
            }
            if (string.IsNullOrEmpty(model.Address))
            {
                ModelState.AddModelError("Address", "Địa chỉ nhà cung cấp không được để trống");
            }
            if (string.IsNullOrEmpty(model.Phone))
            {
                ModelState.AddModelError("Phone", "Số điện thoại không được để trống");
            }
            else if (model.Phone.Length != 10 || model.Phone[0] != '0')
            {
                ModelState.AddModelError("Phone", "Số điện thoại không phù hợp");
            }
            if (ModelState.IsValid)
            {

                if (model.Id > 0)
                {
                    if (importUnitProvider.Update(model))
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return View(model);

                    }
                    ModelState.AddModelError("Error", "Lỗi hệ thống");
                }
                else
                {
                    if (importUnitProvider.Insert(model))
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return View(model);
                    }
                    ModelState.AddModelError("Error", "Lỗi hệ thống");
                }
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult ImportUnitDetail(int id)
        {
               LibData.ImportUnit importUnit = new LibData.Provider.ImportUnitProvider().GetById(id);
            return View(importUnit);
        }
    }
}