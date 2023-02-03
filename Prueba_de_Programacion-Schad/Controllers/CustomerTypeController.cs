using DAL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Prueba_de_Programacion_Schad.Controllers
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
            return View(_customerType.GetAllAsync());
        }

        // GET: CustomerTypeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
