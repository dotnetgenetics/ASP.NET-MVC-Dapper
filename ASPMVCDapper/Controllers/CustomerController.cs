using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPMVCDapper.Models;

namespace ASPMVCDapper.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerService _service;

        public CustomerController()
        {
            _service = new CustomerService();
        }

        // GET: Customer
        public ActionResult Index()
        {
            var model = _service.GetAll();
            return View(model);
        }
        
        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                _service.AddCustomer(customer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _service.FindById(id);
            return View(model);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                _service.UpdateCustomer(customer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _service.FindById(id);
            return View(model);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            try
            {
                _service.DeleteCustomer(customer.CustomerID);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
