using DAL.Interface;
using Microsoft.AspNetCore.Mvc;
using Model;
using Schad.Models;

namespace Schad.Controllers
{
    public class CustomerTypeController : Controller
    {
        private readonly ICustomerType _customerType;

        public CustomerTypeController(ICustomerType customerType)
        {
            _customerType = customerType;
        }
        // GET: CustomerTypeController
        public async Task<ActionResult> Index()
        {
            var model = await _customerType.GetAllAsync();
            return View(model);
        }

        // GET: CustomerTypeController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await _customerType.GetByIdAsync(id);
            return View(model);
        }

        // GET: CustomerTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CustomerTypeViewMolde collection)
        {
            try
            {
                var model = new CustomerType()
                {
                    Description = collection.Description,
                };
                var a = await _customerType.AddAsync(model);
                if (a)
                {
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    return View(collection);
                }
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: CustomerTypeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _customerType.GetByIdAsync(id);
            return View(model);
        }

        // POST: CustomerTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CustomerTypeViewMolde collection)
        {
            try
            {
                var model = await _customerType.GetByIdAsync(collection.Id);
                if (model == null) 
                { 
                    return View("Error"); 
                }
                else
                {
                    var a = await _customerType.EditAsync(model);
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
            catch (Exception e)
            {
                return View(collection);
            }
        }

        // GET: CustomerTypeController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _customerType.GetByIdAsync(id);
            return View(model);
        }

        // POST: CustomerTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(CustomerTypeViewMolde collection)
        {
            try
            {
                var model = await _customerType.GetByIdAsync(collection.Id);
                if (model == null)
                {
                    return View("Error");
                }
                else
                {
                    var a = await _customerType.DeleteAsync(model);
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
            catch (Exception e)
            {
                return View(collection);
            }
        }
    }
}
