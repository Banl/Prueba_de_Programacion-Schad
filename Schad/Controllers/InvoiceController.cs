using DAL.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public async Task<ActionResult> AddDetails(int id)
        {
            var IdInvo = await _invoice.GetByIdAsync(id);
            var model = new InvoiceDeteilViewModel()
            {
                Invoices = IdInvo.Id
            };
            return View(model);
        }

        // POST: Invoice/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddDetails(InvoiceDeteilViewModel collection)
        {
            try
            {
                var invoice = await _invoice.GetByIdAsync(collection.Invoices);
                var model = new InvoiceDetail()
                {
                    TotalItbis = collection.TotalItbis,
                    SubTotal = collection.SubTotal,
                    Total = collection.Total,
                    Price = collection.Price,
                    Qty = collection.Qty,
                    CustomerId = invoice.Customer.Id,
                    Invoice = invoice
                };
                var a = await _invoice.AddDetail(model);
                if (a)
                {
                    return RedirectToAction(nameof(Details), new { id = invoice.Id });
                }
                else
                {
                    return View(collection);
                }
            }
            catch (Exception e)
            {
                return View(collection);
            }
        }

        // POST: Invoice/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveDetail(int id)
        {
            var collection = await _invoice.GetByIdAsync(id);
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
                    return RedirectToAction(nameof(Details), new { id = collection.Id });

                }
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Details), new { id = collection.Id });
            }
        }

        // GET: Invoice/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Customer = new SelectList(await _customer.GetAllAsync(), "Id", "CustName");
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
                    TotalItbis = collection.TotalItbis,
                    SubTotal = collection.SubTotal,
                    Total = collection.Total,
                    Customer = await _customer.GetByIdAsync(collection.Customer),
                };
                var a = await _invoice.AddAsync(model);
                if (a)
                {
                    return RedirectToAction(nameof(AddDetails), new { id = model.Id });
                }
                else
                {
                    return View(collection);
                }
            }
            catch (Exception e)
            {
                return View(collection);
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
            catch (Exception e)
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
                        return RedirectToAction(nameof(AddDetails), new { id = model.Id });
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
