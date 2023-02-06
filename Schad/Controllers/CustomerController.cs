using DAL.Interface;
using Microsoft.AspNetCore.Mvc;
using Model;
using Schad.Models;

namespace Schad.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomer _customer;

        private readonly ICustomerType _customerType;

        public CustomerController(ICustomer customer, ICustomerType customerType)
        {
            _customer = customer;
            _customerType = customerType;
        }
        // GET: CustomerController
        public async Task<ActionResult> Index()
        {
            var model = await _customer.GetAllAsync();
            return View(model);
        }

        // GET: CustomerController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await _customer.GetByIdAsync(id);
            return View(model);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CustomerViewModel collection)
        {
            try
            {
                var model = new Customer()
                {
                    Adress= collection.Adress,
                    CustName=collection.CustName,
                    CustomerType =  await _customerType.GetByIdAsync(collection.CustomerType.Id),
                    Status= true
                };
                var a = await _customer.AddAsync(model);
                if (a)
                {
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    return View(collection);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _customer.GetByIdAsync(id);
            return View(model);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CustomerViewModel collection)
        {
            try
            {
                var model = await _customer.GetByIdAsync(collection.Id);
                if (model == null)
                {
                    return View("Error");
                }
                else
                {
                    var a = await _customer.EditAsync(model);
                    if (a)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return View(collection);
                    }
                }
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: CustomerController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _customer.GetByIdAsync(id);
            return View(model);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(CustomerViewModel collection)
        {
            try
            {
                var model = await _customer.GetByIdAsync(collection.Id);
                if (model == null)
                {
                    return View("Error");
                }
                else
                {
                    var a = await _customer.DeleteAsync(model);
                    if (a)
                    {
                        return RedirectToAction(nameof(Index));

                    }
                    else
                    {
                        return View(collection);
                    }
                }
            }
            catch
            {
                return View(collection);
            }
        }
    }
}
