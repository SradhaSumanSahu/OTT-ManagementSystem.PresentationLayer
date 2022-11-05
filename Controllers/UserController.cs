using OTTManagementsystem.DataAccessLayer;
using OTTMangementSystem.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OTT_ManagementSystem.PresentationLayer.Controllers
{
    public class UserController : Controller
    {
        [Required]
        UserDataAccessLayer UserDataAccess = new UserDataAccessLayer();
        // GET: User
        public ActionResult Index() //get the data from the database
        {
            var UserList = UserDataAccess.GetAllUser();
            if (UserList.Count == 0)
            {
                TempData["InfoMessage"] = "Currently User is not available in the database.";
            }
            return View(UserList);

        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var User = UserDataAccess.GetUserByID(id).FirstOrDefault();
                if (User == null)
                {
                    TempData["InfoMessage"] = "User not available with id" + id.ToString();
                    return RedirectToAction("Index");
                }
                return View(User);
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }
        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User User)
        {
            try
            {
                bool IsInserted = false;
                if (ModelState.IsValid)
                {
                    IsInserted = UserDataAccess.InsertUser(User);
                    if (IsInserted)
                    {
                        TempData["SuccessMessage"] = "User details saved successfully...!";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Unable to save the User details.";
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

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var User = UserDataAccess.GetUserByID(id).FirstOrDefault();
            if (User == null)
            {
                TempData["InfoMessage"] = "User not available with ID" + id.ToString();
                return RedirectToAction("Index");
            }

            return View(User);
        }


        // POST: User/Edit/5
        [HttpPost, ActionName("Edit")]
        public ActionResult UpdateUser(User User)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool IsUpdated = UserDataAccess.UpdateUser(User);

                    if (IsUpdated)
                    {
                        TempData["SuccessMessage"] = "User details updated successfully..";

                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Unable to save the User details.";
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var User = UserDataAccess.GetUserByID(id).FirstOrDefault();
                if (User == null)
                {
                    TempData["InfoMessage"] = "User not available with id" + id.ToString();
                    return RedirectToAction("Index");
                }
                return View(User);
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmation(int id)
        {
            try
            {
                string result = UserDataAccess.DeleteUser(id);
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
