using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using QRCoder;

namespace GenerateQRCode.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Generate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Generate(string qrcode)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator _qrgenerator = new QRCodeGenerator();
                QRCodeGenerator.QRCode _qrcode = _qrgenerator.CreateQrCode(qrcode, QRCodeGenerator.ECCLevel.Q);

              
                using (Bitmap _bitmap = _qrcode.GetGraphic(20))
                {
                    _bitmap.Save(ms, ImageFormat.Png);

                    ViewBag.QRCodeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}