using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

using TalesInGold_EShop.Models;

using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace TalesInGold_EShop.Controllers
{
    public class HomeController : Controller
    {
        public IConfiguration _configuration { get; }
        private readonly modelContext _context = null;

        public HomeController(IOptions<Setting> settings, IConfiguration configuration)
        {
            _context = new modelContext(settings);
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var _jewel = _context.JewelriesLinq.AsQueryable().Where(x => x.isFirstPage == 1 ).OrderBy(x => x.orderInFirstPage).Take(4);
            //var _jewel = _context.JewelriesLinq.AsQueryable().Take(4);
            return View("Index", _jewel);
        }

        [HttpGet("home/jewelry/{id}")]
        public IActionResult GetItem(string id)
        {
            var _jewel = _context.JewelriesLinq.AsQueryable().FirstOrDefault(x => x.Id == new MongoDB.Bson.ObjectId(id));

            var moreInfoTrans = _jewel.moreInfo.Replace("\r","<br>");
            _jewel.moreInfo = moreInfoTrans;

            return View("jewelry", _jewel);
        }


        [HttpGet("home/gallery/all")]
        public IActionResult GetAllItem()
        {
            ViewBag.Collections = new string[1] { "All" };
            var _jewel = _context.JewelriesLinq.AsQueryable().Where(x => x.isFirstPage>=0).ToList();

            return View("Gallerys", _jewel);
        }

        [HttpGet("home/Jewelry")]
        public IActionResult Getegory()
        {
            return View("jewelryGategory");
        }

        [HttpGet("home/gallery/{id}")]
        [HttpGet("home/gallery/{id}/{subid}")]
        public IActionResult GetGategory(string id, string subid)
        {

            var _jewel = new List<Jewelry>();

            switch (id)
            {
                case "necklaces":
                    ViewBag.Collections = new string[1] { "Necklaces" };
                    _jewel = _context.JewelriesLinq.Find(x => x.isNecklace == 1).ToList();
                    break;
                case "bracelets":
                    ViewBag.Collections = new string[1] { "Bracelets" };
                    _jewel = _context.JewelriesLinq.Find(x => x.isBracelet == 1).ToList();
                    break;
                case "earrings":
                    ViewBag.Collections = new string[1] { "Earrings" };
                    _jewel = _context.JewelriesLinq.Find(x => x.isEarring == 1).ToList();
                    if (subid == "studs")
                    {
                        ViewBag.Collections = new string[2] { "Earrings", "Studs" };
                        _jewel = _jewel.Where(y => y.typeOfEarring == "studs").ToList();
                    }
                    else if (subid == "threader")
                    {
                        ViewBag.Collections = new string[2] { "Earrings", "Threader & Long" };
                        _jewel = _jewel.Where(y => y.typeOfEarring == "threader").ToList();
                    }
                    break;
                case "personalized":
                    ViewBag.Collections = new string[1] { "Personalized Jewelry" };
                    _jewel = _context.JewelriesLinq.Find(x => x.isPersonalized == 1).ToList();
                    if (subid == "necklaces")
                    {
                        ViewBag.Collections = new string[2] { "Personalized Jewelry", "Necklaces"};
                       _jewel = _jewel.Where(y => y.typeOfPersonalized == "necklaces").ToList();

                    }
                    else if (subid == "bracelets")
                    {
                        ViewBag.Collections = new string[2] { "Personalized Jewelry", "Bracelets"};
                        _jewel = _jewel.Where(y => y.typeOfPersonalized == "bracelets").ToList();
                    }
                    break;
                case "birthstone":
                    ViewBag.Collections = new string[1] { "Birthstone Jewelry" };
                    _jewel = _context.JewelriesLinq.Find(x => x.isBirthstone == 1).ToList();
                    if (subid == "necklaces")
                    {
                        ViewBag.Collections = new string[2] { "Birthstone Jewelry", "Necklaces" };
                        _jewel = _jewel.Where(y => y.typeOfBirthstone == "necklaces").ToList();

                    }
                    else if (subid == "earrings")
                    {
                        ViewBag.Collections = new string[2] { "Birthstone Jewelry", "Earrings" };
                        _jewel = _jewel.Where(y => y.typeOfBirthstone == "earrings").ToList();
                    }
                    break;
                case "diamond":
                    ViewBag.Collections = new string[1] { "Diamond Jewelry" };
                    _jewel = _context.JewelriesLinq.Find(x => x.isDiamond == 1).ToList();
                    if (subid == "necklaces")
                    {
                        ViewBag.Collections = new string[2] { "Diamond Jewelry","Necklaces"};
                        _jewel = _jewel.Where(y => y.typeOfDiamond == "necklaces").ToList();

                    }
                    else if (subid == "earrings")
                    {
                        ViewBag.Collections = new string[2] { "Diamond Jewelry","Earrings"};
                        _jewel = _jewel.Where(y => y.typeOfDiamond == "earrings").ToList();
                    }
                    else if (subid == "bracelets")
                    {
                        ViewBag.Collections = new string[2] { "Diamond Jewelry","Bracelets"};
                        _jewel = _jewel.Where(y => y.typeOfDiamond == "bracelets").ToList();
                    }
                    else if (subid == "rings")
                    {
                        ViewBag.Collections = new string[2] { "Diamond Jewelry","Rings"};
                        _jewel = _jewel.Where(y => y.typeOfDiamond == "rings").ToList();
                    }
                    break;
                case "rings":
                    ViewBag.Collections = new string[1] { "Rings" };
                    _jewel = _context.JewelriesLinq.Find(x => x.isRing == 1).ToList();
                    break;
                default:
                    return RedirectToAction("Index");
            }

            ViewBag.UrlCollections = new string[1] { id };

            if (!String.IsNullOrEmpty(subid))
            {
                ViewBag.UrlCollections = new string[2] { id, subid };
            }

            return View("Gallerys", _jewel);

        }

        [HttpGet("home/contact")]
        public IActionResult Contact()
        {
            ViewBag.mailSend = 0;
            return View("Contact");
        }

        [HttpGet("home/news")]
        public IActionResult news()
        {
            ViewBag.mailSend = 0;
            return View("News");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(ContactForm mailbody)
        {
            if (ModelState.IsValid)
            {

                ViewBag.mailSend = SendMail(mailbody);
                return View("Contact");
            }

            ViewBag.mailSend = -1;
            return View("Contact");
        }


        //POST a Jewelry
        public IActionResult About()
        {
            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        private int SendMail(ContactForm mailbody)
        {
            var username = _configuration.GetSection("Email:User").Value;
            var pass = _configuration.GetSection("Email:Pass").Value;

            using (var message = new MailMessage(mailbody.Email, username))
            {
                
                message.To.Add(new MailAddress(username));
                message.From = new MailAddress(mailbody.Email);
                message.Subject = "Tales In Gold Test Contact";
                message.Body = mailbody.Message + "\n\n From:" + mailbody.Email;


                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.Port = 587;
                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = new System.Net.NetworkCredential(username, pass);

                    var isSend = -1;
                    try
                    {
                        smtpClient.Send(message);
                        isSend = 1;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception caught in CreateTimeoutTestMessage(): {0}",
                                    ex.ToString());
                    }

                    smtpClient.Dispose();
                    return isSend;
                }
            }
        }
    }
}
