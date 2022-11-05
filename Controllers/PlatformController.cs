using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OTTManagementsystem.DataAccessLayer;
using OTTMangementSystem.Entities;

namespace OTT_ManagementSystem.PresentationLayer.Controllers
{
    public class PlatformController : Controller
    {
        [Required]
        PlatformDataAccessLayer PlatformDataAccess = new PlatformDataAccessLayer();
        // GET: Platform
        public ActionResult Index() //get the data from the database
        {
            var PlatformList = PlatformDataAccess.GetAllPlatform();
            if (PlatformList.Count == 0)
            {
                TempData["InfoMessage"] = "Currently Platform is not available in the database.";
            }
            return View(PlatformList);

        }

        // GET: Platform/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var Platform = PlatformDataAccess.GetPlatformByID(id).FirstOrDefault();
                if (Platform == null)
                {
                    TempData["InfoMessage"] = "Platform not available with id" + id.ToString();
                    return RedirectToAction("Index");
                }
                return View(Platform);
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: Platform/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Platform/Create
        [HttpPost]
        public ActionResult Create(Platform Platform)
        {
            try
            {
                bool IsInserted = false;
                if (ModelState.IsValid)
                {
                    IsInserted = PlatformDataAccess.InsertPlatform(Platform);
                    if (IsInserted)
                    {
                        TempData["SuccessMessage"] = "Platform details saved successfully...!";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Unable to save the Platform details.";
                    }

                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return View();
            }

        }

        // GET: Platform/Edit/5

        public ActionResult Edit(int id)
        {
            var Platform = PlatformDataAccess.GetPlatformByID(id).FirstOrDefault();
            if (Platform == null)
            {
                TempData["InfoMessage"] = "Platform not available with ID" + id.ToString();
                return RedirectToAction("Index");
            }

            return View(Platform);
        }


        // POST: Platform/Edit/5
        [HttpPost, ActionName("Edit")]
        public ActionResult UpdatePlatform(Platform Platform)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool IsUpdated = PlatformDataAccess.UpdatePlatform(Platform);

                    if (IsUpdated)
                    {
                        TempData["SuccessMessage"] = "Platform details updated successfully..";

                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Unable to save the Platform details.";
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: Platform/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var Platform = PlatformDataAccess.GetPlatformByID(id).FirstOrDefault();
                if (Platform == null)
                {
                    TempData["InfoMessage"] = "Platform not available with id" + id.ToString();
                    return RedirectToAction("Index");
                }
                return View(Platform);
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: Platform/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmation(int id)
        {
            try
            {
                string result = PlatformDataAccess.DeletePlatform(id);
                if (result.Contains("deleted"))
                {
                    TempData["SuccessMessage"] = result;
                }
                else
                {
                    TempData["ErrorMessage"] = result;
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }
    }
}
