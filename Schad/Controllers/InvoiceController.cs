using DAL.Interface;
using Microsoft.AspNetCore.Mvc;
using Model;
using Schad.Models;

namespace Schad.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoice _invoice;
        private readonly ICustomer _customer;

        public InvoiceController(IInvoice invoice, ICustomer customer)
        {
            _invoice = invoice;
            _customer = customer;
        }
        // GET: Invoice
        public async Task<ActionResult> Index()
        {
            var model = await _invoice.GetAllAsync();
            return View(model);
        }

        // GET: Invoice/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await _invoice.GetByIdAsync(id);
            return View(model);
        }

        // GET: Invoice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Invoice/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(InvoiceViewMolde collection)
        {
            try
            {
                var model = new Invoice()
                {
                    Id = collection.Id,
                    TotalItbis = collection.TotalItbis,
                    SubTotal = collection.SubTotal,
                    Total = collection.Total,
                    Customer = await _customer.GetByIdAsync(collection.Customer.Id),
                    InvoiceDeteils = new List<InvoiceDeteil>() { }
                };
                var a = await _invoice.AddAsync(model);
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

        // GET: Invoice/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _invoice.GetByIdAsync(id);
            return View(model);
        }

        // POST: Invoice/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(InvoiceViewMolde collection)
        {
            try
            {
                var model = await _invoice.GetByIdAsync(collection.Id);
                if (model == null)
                {
                    return View("Error");
                }
                else
                {
                    var a = await _invoice.EditAsync(model);
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
                return View();
            }
        }

        // GET: Invoice/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _invoice.GetByIdAsync(id);
            return View(model);
        }

        // POST: Invoice/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(InvoiceViewMolde collection)
        {
            try
            {
                var model = await _invoice.GetByIdAsync(collection.Id);
                if (model == null)
                {
                    return View("Error");
                }
                else
                {
                    var a = await _invoice.DeleteAsync(model);
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
