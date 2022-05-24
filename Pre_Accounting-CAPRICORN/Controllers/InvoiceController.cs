using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using Pre_Accounting_CAPRICORN.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pre_Accounting_CAPRICORN.Controllers
{
    [Authorize]
    public class InvoiceController : Controller
    {
        Context c = new Context();
        // GET: Invoice
        public ActionResult Index(string search)
        {
            var invoice = from i in c.Invoices
                          where i.Status == true
                          select i;
            if (!String.IsNullOrEmpty(search))
            {
                invoice = invoice.Where(i => i.InvoiceDate.Contains(search) || i.TaxOffice.Contains(search));
            }
            return View(invoice.ToList());
        }


        //public decimal GetTotal(int id)
        //{



        //    decimal? total = decimal.Zero;
        //    total = (decimal?)(from invoice in c.Invoices
        //                       join item in c.InvoiceItems on invoice.InvoiceID equals item.InvoiceID
        //                       where item.InvoiceID == id
        //                       select (int?)item.Quantity *
        //                       item.Price).Sum();
        //    ViewBag.total = total;
        //    //return View("Index",total);
        //    return total ?? decimal.Zero;
        //}

        public ActionResult NewInvoice()
        {
            List<SelectListItem> customer = (from y in c.Customers.Where(x => x.Status == true).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = y.CustomerName,
                                                 Value = y.CustomerID.ToString()
                                             }).ToList();
            ViewBag.cust = customer;

            List<SelectListItem> personnel = (from p in c.Personnels.Where(x => x.Status == true).ToList()
                                              select new SelectListItem
                                              {
                                                  Text = p.PersonnelName,
                                                  Value = p.PersonnelID.ToString()
                                              }).ToList();
            ViewBag.pers = personnel;
            return View();
        }

        [HttpPost]
        public ActionResult NewInvoice(Invoice i)
        {

            try
            {
                i.Status = true;
                c.Invoices.Add(i);
                c.SaveChanges();
                if (i.InvoiceID > 0)
                    c.ACTs.Add(new Models.ACT()
                    {
                        InvoiceID = i.InvoiceID,
                        CustomerName = c.Customers.FirstOrDefault(x => x.CustomerID == i.CustomerID).CustomerName,
                        Type = i.Type,
                        TotalAmount = i.TotalAmount

                    });

                c.SaveChanges();

            }
            catch (Exception e)
            {

                return View("Error", e);
            }
            return RedirectToAction("Index");

        }

        public JsonResult IsInvoiceExist(string InvoiceSerialRowNo, int? Id)
        {
            var validateName = c.Invoices.FirstOrDefault
                                (x => x.InvoiceSerialRowNo == InvoiceSerialRowNo && x.InvoiceID != Id);
            if (validateName != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult BringInvoice(int id)
        {
            List<SelectListItem> customer = (from y in c.Customers.Where(x => x.Status == true).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = y.CustomerName,
                                                 Value = y.CustomerID.ToString()
                                             }).ToList();
            ViewBag.cust = customer;

            List<SelectListItem> personnel = (from p in c.Personnels.Where(x => x.Status == true).ToList()
                                              select new SelectListItem
                                              {
                                                  Text = p.PersonnelName,
                                                  Value = p.PersonnelID.ToString()
                                              }).ToList();
            ViewBag.pers = personnel;

            var result = c.Invoices.Find(id);

            return View("BringInvoice", result);
        }

        [HttpPost]
        public ActionResult UpdateInvoice(Invoice i)
        {
            var invoice = c.Invoices.Find(i.InvoiceID);
            invoice.InvoiceID = i.InvoiceID;
            invoice.InvoiceSerialRowNo = i.InvoiceSerialRowNo;
            invoice.InvoiceDate = i.InvoiceDate;
            invoice.InvoiceTime = i.InvoiceTime;
            invoice.TaxOffice = i.TaxOffice;
            invoice.CustomerID = i.CustomerID;
            invoice.PersonnelID = i.PersonnelID;
            invoice.TotalAmount = i.TotalAmount;
            invoice.Type = i.Type;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var result = c.Invoices.Find(id);
            if (result != null)
            {
                result.Status = false;

                c.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult InvoiceDetails(int id)
        {
            List<InvoiceItem> items = new List<InvoiceItem>();
            items = c.InvoiceItems.Where(x => x.InvoiceID == id).ToList();
            Invoice invoice = new Invoice();

            invoice = c.Invoices.FirstOrDefault(x => x.InvoiceID == id);

            ViewBag.invoice = invoice;

            return View(items);
        }

        [HttpGet]
        public ActionResult NewItem()
        {
            List<SelectListItem> product = (from x in c.Products.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.ProductName,
                                                Value = x.ProductID.ToString()
                                            }).ToList();
            ViewBag.product = product;
            return View();
        }

        [HttpPost]
        public ActionResult NewItem(InvoiceItem t)
        {
            try
            {
                var id = c.Invoices.Find(t.InvoiceID);
                ViewBag.id = id;

                List<SelectListItem> product = (from x in c.Products.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.ProductName,
                                                    Value = x.ProductID.ToString()
                                                }).ToList();
                ViewBag.product = product;

                int adet = c.Products.FirstOrDefault(x => x.ProductID == t.ProductID)?.Stock ?? 0;

                var type = c.Invoices.FirstOrDefault(x => x.InvoiceID == t.InvoiceID).Type;

                if(type == "2")
                {
                    adet = adet - t.Quantity;
                    if (adet < 0)
                    {
                        ViewBag.msg = "There is no enough " + c.Products.FirstOrDefault(x => x.ProductID == t.ProductID).ProductName + " stock. Try again!";
                        return View();
                    }
                }
                t.Total = t.Price * t.Quantity;
                var totalAmount = c.Invoices.Find(t.InvoiceID).TotalAmount;
                totalAmount += t.Total;
                //var totalAmount = c.InvoiceItems.Where(x => x.InvoiceID == t.InvoiceID).Select(x => x.Total).Sum();
                //var totalAmount = c.InvoiceItems.Where(x => x.InvoiceID == t.InvoiceID).Select(x => x.Price * x.Quantity).Sum();
                //var totalAmount = GetTotal(t.InvoiceID);
                t.Status = true;
                c.InvoiceItems.Add(t);
                
                c.Invoices.FirstOrDefault(x => x.InvoiceID == t.InvoiceID).TotalAmount = totalAmount;
                c.ACTs.FirstOrDefault(x => x.InvoiceID == t.InvoiceID).TotalAmount = totalAmount;
                c.SaveChanges();



                if (t.InvoiceItemID > 0)
                    c.STs.Add(new Models.ST()
                    {
                        InvoiceItemID = t.InvoiceItemID,
                        ProductName = c.Products.FirstOrDefault(x => x.ProductID == t.ProductID).ProductName,
                        Quantity = t.Quantity,
                        Type = c.Invoices.FirstOrDefault(x => x.InvoiceID == t.InvoiceID).Type

                    });
                c.SaveChanges();
                if (t.Invoice.Type == "1")
                {
                    t.STs.FirstOrDefault().RemainingStock = t.Product.Stock + t.Quantity;
                    t.Product.Stock += t.Quantity;
                }
                else /*if(t.Product.Stock - t.Quantity >= 0)*/
                {
                    t.STs.FirstOrDefault().RemainingStock = t.Product.Stock - t.Quantity;
                    t.Product.Stock -= t.Quantity;

                    //if (t.Product.Stock < 0)
                    //{
                    //    ViewBag.msg = "There is no enough " + t.Product.ProductName + " stock. Try again!";
                    //    t.Product.Stock += t.Quantity;
                    //    c.InvoiceItems.Remove(t);
                    //    c.SaveChanges();
                    //    return View();
                    //}

                }
               
                c.SaveChanges();

            }
            catch (Exception e)
            {

                return View("Error", e);
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteItem(int id)
        {
            var result = c.InvoiceItems.Find(id);
            if (result != null)
            {
                result.Status = false;

                c.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult PrintInvoice(int id)
        {
            List<InvoiceItem> items = new List<InvoiceItem>().ToList();
            ViewBag.items = items;
            var result = c.Invoices.Find(id);
            return View(result);
        }

        [HttpPost]
        [ValidateInput(false)]
        public FileResult ExportHTML(string ExportData)
        {
            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                StringReader reader = new StringReader(ExportData);
                Document PdfFile = new Document(PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(PdfFile, stream);
                PdfFile.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, PdfFile, reader);
                PdfFile.Close();
                return File(stream.ToArray(), "application/pdf", "ExportData.pdf");
            }
        }

        [HttpGet]
        public ActionResult ACT(string search)
        {
            var result = from a in c.ACTs
                         select a;
            if (!String.IsNullOrEmpty(search))
            {
                result = result.Where(x => x.CustomerName.Contains(search));
            }
            return View(result.ToList());
        }

        [HttpGet]
        public ActionResult ST(string search)
        {
            var result = from s in c.STs
                         select s;
            if (!String.IsNullOrEmpty(search))
            {
                result = result.Where(x => x.ProductName.Contains(search));
            }
            return View(result.ToList());
        }

    }
}
