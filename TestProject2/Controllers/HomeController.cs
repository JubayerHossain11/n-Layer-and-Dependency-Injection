
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using TestProject2.Models;

namespace TestProject2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var dir = new System.IO.DirectoryInfo(Server.MapPath("~/Content/Files/"));
            var filePath = Server.MapPath("~/Content/Files/Md. Jubayer Hossain.pdf");
            //System.IO.FileInfo[] fileNames = dir.GetFiles("*.*");
            //List<string> items = new List<string>();

            string from = "jubayerhossain11@outlook.com"; //example:- sourabh9303@gmail.com

            var html = RenderRazorViewToString("_emailTemplate", new EmailTemplateViewModel() { Name = "Jon Snow",Address = "48/5,west amarica",ContactNo="0154478452",Email="Jonsnow@jmail.com"});

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("jubayerhossain11@outlook.com");
                mail.To.Add("jubayerhossain11@gmail.com");
                mail.Subject = "Hello World Subject";
                //mail.Body = "<h1>mail Body___</h1> <br> <img src=\"~/Content/AdminTemplate/plugins/ckeditor/plugins/image/images/ noimage.png\"/>";

                mail.Body = html;
                mail.IsBodyHtml = true;
                mail.Attachments.Add(new Attachment(filePath));

                //using (FileStream fileStream = System.IO.File.OpenRead(filePath))
                //{
                //    MemoryStream memStream = new MemoryStream();
                //    memStream.SetLength(fileStream.Length);
                //    fileStream.Read(memStream.GetBuffer(), 0, (int)fileStream.Length);

                //    mail.Attachments.Add(new Attachment(fileStream, "jubayer_CV"));
                //}

                using (SmtpClient smtp = new SmtpClient("smtp-mail.outlook.com", 587))
                {
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("jubayerhossain11@outlook.com", "2468juba");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }

            }




            //using (MailMessage mail = new MailMessage(from, "jubayerhossain11@gmail.com"))

            //{
            //    mail.Subject = "Test Mail";

            //    mail.Body = "email body for test mail";


            //    //using (FileStream fileStream = System.IO.File.OpenRead(filePath))
            //    //{
            //    //    using (MemoryStream memStream = new MemoryStream()) {
            //    //        memStream.SetLength(fileStream.Length);
            //    //        fileStream.Read(memStream.GetBuffer(), 0, (int)fileStream.Length);
            //    //    };
            //    //    mail.Attachments.Add(new Attachment(fileStream, "jubayer_CV", System.Net.Mime.MediaTypeNames.Application.Pdf));
            //    //}


            //    mail.Attachments.Add(new Attachment(filePath));
            //    mail.IsBodyHtml = true;

            //    SmtpClient smtp = new SmtpClient();

            //    smtp.Host = "smtp-mail.outlook.com";

            //    smtp.EnableSsl = true;

            //    NetworkCredential networkCredential = new NetworkCredential(from, "2468juba");

            //    smtp.UseDefaultCredentials = false;

            //    smtp.Credentials = networkCredential;
            //    smtp.Port = 587;
            //    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            //    smtp.Send(mail);

            //    ViewBag.Message = "Sent";

            //}


            return View();
        }


        private string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                return sw.GetStringBuilder().ToString();
            }
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

        //public static void sendEmail(string subject, string tomailid, string title, string bodycontent, string imagepath)
        //{
        //    try
        //    {
        //        string body = string.Empty;
        //        using (StreamReader reader = new StreamReader(HostingEnvironment.MapPath("~/emailtemplates/email.html")))
        //        {
        //            body = reader.ReadToEnd();
        //        }
        //        body = body.Replace("{Title}", title);
        //        body = body.Replace("{Body}", bodycontent);
        //        string mainbody = body;
        //        using (MailMessage mm = new MailMessage())
        //        {

        //            mm.From = new MailAddress("Email-id");
        //            mm.To.Add(new MailAddress(tomailid));
        //            ////var imagepath1= @"~/Images\NoDataAvailable.png";
        //            // var imagepath1= HttpContext.Current.Server.MapPath("~/Images/NoDataAvailable.png");
        //            var stream = new WebClient().OpenRead(imagepath);
        //            //Attachment attachement = new Attachment(stream, "");
        //            var filename = Path.GetFileName(imagepath);
        //            mm.Attachments.Add(new Attachment(stream, "filename"));
        //            mm.Subject = subject;
        //            mm.Body = mainbody;
        //            mm.IsBodyHtml = true;
        //            SmtpClient smtp = new SmtpClient();
        //            smtp.Host = "smtp.gmail.com";
        //            smtp.EnableSsl = true;
        //            NetworkCredential NetworkCred = new NetworkCredential("Emailid", "PAssword");
        //            smtp.UseDefaultCredentials = false;
        //            smtp.Credentials = NetworkCred;
        //            smtp.Port = 587;
        //            smtp.Send(mm);

        //        }
        //    }
        //    catch { }

        //}



        //[HttpPost]
        //public ActionResult SendEmailWithFile(MailModel objModelMail, HttpPostedFileBase fileUploader)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var dir = new System.IO.DirectoryInfo(Server.MapPath("~/Content/Files/"));
        //        System.IO.FileInfo[] fileNames = dir.GetFiles("*.*");

        //        string from = "Your Gmail Id"; //example:- sourabh9303@gmail.com
        //        using (MailMessage mail = new MailMessage(from, objModelMail.To))
        //        {
        //            mail.Subject = objModelMail.Subject;
        //            mail.Body = objModelMail.Body;

        //            foreach (var file in fileNames)
        //            {
        //                //string fileName = Path.GetFileName(fileUploader.FileName);
        //                //mail.Attachments.Add(new Attachment(, file.Name));
        //            }

        //            if (fileUploader != null)
        //            {
        //                var FileVirtualPath = "~/Content/Files/" + "Md. Jubayer Hossain";
        //                var kkk = File(FileVirtualPath, Path.GetFileName(FileVirtualPath));

        //                //string fileName = Path.GetFileName(fileUploader.FileName);
        //                //mail.Attachments.Add(new Attachment(fileUploader.InputStream, fileName));

        //            }

        //            mail.IsBodyHtml = false;
        //            SmtpClient smtp = new SmtpClient();
        //            smtp.Host = "smtp.gmail.com";
        //            smtp.EnableSsl = true;
        //            NetworkCredential networkCredential = new NetworkCredential(from, "Your Gmail Password");
        //            smtp.UseDefaultCredentials = true;
        //            smtp.Credentials = networkCredential;
        //            smtp.Port = 587;
        //            smtp.Send(mail);
        //            ViewBag.Message = "Sent";
        //            return View("Index", objModelMail);
        //        }
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}



    }
}
