using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using IHMCSDelhi.Models;
using System.Net.Mail;

namespace IHMCSDelhi.Controllers
{
    public class HomeController : Controller
    {
        private IhmcsDelhiDBEntities db = new IhmcsDelhiDBEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult careerin()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult director()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult testimonial()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult ug()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult pg()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult diploma()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult placementcell()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult tie()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult place()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult internships()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult admissions()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult franchise()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult vacancy()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult job()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult apply()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult accreditations()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult gallery()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult contact()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult form()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        [HttpPost]
        public ActionResult form(FormCollection frm)
        {
            string Current_Url = Request.UrlReferrer.PathAndQuery;
            string[] Path = Current_Url.Split('/');

            string CandidateName = frm["name"].ToString();
            string Mobilenumber = frm["txtnumber"].ToString();
            string EmailID = frm["email"].ToString();
            string dob = frm["dob"].ToString();

            //string coursename = frm["coursename"].ToString();
            //string CandidateName = frm["name"].ToString();
            //string Mobilenumber = frm["txtnumber"].ToString();
            //string EmailID = frm["email"].ToString();
            //string dob = frm["dob"].ToString();
            //string contact = frm["contact"].ToString();
            //string fathername = frm["fathername"].ToString();
            //string mothername = frm["mothername"].ToString();
            //string address = frm["address"].ToString();
            //string city = frm["city"].ToString();
            //string state = frm["state"].ToString();
            //string pin = frm["pin"].ToString();
            //string parentemail = frm["parentemail"].ToString();
            //string eduqualibdy = frm["eduqualibdy"].ToString();
            //string englishfluency = frm["englishfluency"].ToString();
            //string otherlanguage = frm["otherlanguage"].ToString();
            //string extraactivity = frm["extraactivity"].ToString();
            //string additionalinfo = frm["additionalinfo"].ToString();

            //if (string.IsNullOrEmpty(coursename))
            //{
            //    TempData["qUERYmESSAGE"] = "Please fill the Course Name";
            //    return RedirectToAction(Path[2], Path[1]);
            //}
            //if (string.IsNullOrEmpty(email))
            //{
            //    TempData["qUERYmESSAGE"] = "please fill the email";
            //    return RedirectToAction(Path[2], Path[1]);
            //}
            //if (string.IsNullOrEmpty(Mobilenumber))
            //{
            //    TempData["qUERYmESSAGE"] = "please fill the Mobile number";
            //    return RedirectToAction(Path[2], Path[1]);
            //}

            return View();
        }

        [HttpPost]
        public ActionResult contact(FormCollection frm)
        {
            string Current_Url = Request.UrlReferrer.PathAndQuery;
            string[] Path = Current_Url.Split('/');

            string CandidateName = frm["name"].ToString();
            string Mobilenumber = frm["phone"].ToString();
            string EmailID = frm["email"].ToString();
            string EnquiryMessage = frm["message"].ToString();

            if (string.IsNullOrEmpty(CandidateName))
            {
                TempData["qUERYmESSAGE"] = "Please fill the Name.";
                return RedirectToAction(Path[2], Path[1]);
            }
            if (string.IsNullOrEmpty(EmailID))
            {
                TempData["qUERYmESSAGE"] = "please fill the email";
                return RedirectToAction(Path[2], Path[1]);
            }
            if (string.IsNullOrEmpty(Mobilenumber))
            {
                TempData["qUERYmESSAGE"] = "please fill the Mobile number";
                return RedirectToAction(Path[2], Path[1]);
            }
            if (string.IsNullOrEmpty(EnquiryMessage))
            {
                TempData["qUERYmESSAGE"] = "please fill the Enquiry Message";
                return RedirectToAction(Path[2], Path[1]);
            }

            T_EnquiryMaster ObjNew = new T_EnquiryMaster();
            ObjNew.Emailid = EmailID;
            ObjNew.MobileNo = Mobilenumber;
            ObjNew.Name = CandidateName;
            ObjNew.UserMessage = EnquiryMessage;
            ObjNew.RequestedURL = Current_Url;
            ObjNew.ModifiedBy = EmailID;
            ObjNew.CreateDate = DateTime.Now;
            ObjNew.ModifiedDate = DateTime.Now;
            ObjNew.Active = true;
            db.T_EnquiryMaster.Add(ObjNew);
            db.SaveChanges();
            if (SendUserInfo(ObjNew))
            {
                TempData["qUERYmESSAGE"] = " Dear " + ObjNew.Name + ", Your Enquiry Application has been Submitted. Thank you for INSTITUTE OF HOTEL MANAGEMENT & CATERING SCIENCE (IHMCS) Enquiry. We will get back to you soon!!!";
            }
            return RedirectToAction("thankyou");
        }

        public ActionResult thankyou()
        {
            return View();
        }

        public bool SendUserInfo(T_EnquiryMaster ObjNew)
        {
            if (string.IsNullOrEmpty(ObjNew.Name))
            {
                ViewBag.Status = "Please Enter User Name.";
            }
            if (string.IsNullOrEmpty(ObjNew.Emailid))
            {
                ViewBag.Status = "Please Enter Contact No.";
            }
            if (string.IsNullOrEmpty(ObjNew.MobileNo))
            {
                ViewBag.Status = "Please Enter Email ID.";
            }
            if (string.IsNullOrEmpty(ObjNew.UserMessage))
            {
                ViewBag.Status = "Please Enter Enquiry Message.";
            }

            try
            {
                MailMessage message = new MailMessage();
                message.To.Add(ObjNew.Emailid);
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                message.From = new System.Net.Mail.MailAddress("enquiry@ihmcsdelhi.org", "INSTITUTE OF HOTEL MANAGEMENT & CATERING SCIENCE (IHMCS) Enquiry Details");
                message.Bcc.Add("info@ihmcsdelhi.org");
                message.Bcc.Add("ajitmca2015@gmail.com");
                message.Bcc.Add("codelovertechnology@gmail.com");
                message.Subject = "INSTITUTE OF HOTEL MANAGEMENT & CATERING SCIENCE (IHMCS) Enquiry Details : " + ObjNew.Name;
                message.Body = "Hi " + ObjNew.Name + ", " + System.Environment.NewLine + System.Environment.NewLine
                    + "======================================================================================== "
                    + System.Environment.NewLine + "  User Name : " + ObjNew.Name
                    + System.Environment.NewLine + "  Contact No : " + ObjNew.MobileNo
                    + System.Environment.NewLine + "  Email ID : " + ObjNew.Emailid
                     + System.Environment.NewLine + " Dear " + ObjNew.Name + ", Your Enquiry Application has been Submitted. Thank you for INSTITUTE OF HOTEL MANAGEMENT & CATERING SCIENCE (IHMCS) Enquiry. We will get back to you soon!!!"
                     + System.Environment.NewLine + "  Enquiry Message: " + ObjNew.UserMessage+"." 
                     + System.Environment.NewLine + "Feel free to Visit INSTITUTE OF HOTEL MANAGEMENT & CATERING SCIENCE (IHMCS) Web Portal."
                     + System.Environment.NewLine + " Enquiry Requested From : " + ObjNew.RequestedURL + System.Environment.NewLine
                    + " ======================================================================================== "
                    + System.Environment.NewLine + System.Environment.NewLine
                    + System.Environment.NewLine
                    + System.Environment.NewLine
                    + "Thanks & Regards," + System.Environment.NewLine
                   + "INSTITUTE OF HOTEL MANAGEMENT & CATERING SCIENCE (IHMCS)," + System.Environment.NewLine
                   + "CORPORATE OFFICE :-" + System.Environment.NewLine
                   + "D-1, 3rd Floor, Bareja Tower," + System.Environment.NewLine
                   + "Main Mathura Road, Badarpur, New Delhi- 110044," + System.Environment.NewLine
                   + "Phone :- 011-2989-2088" + System.Environment.NewLine
                   + "Email ID :- enquiry@ihmcsdelhi.org/info@ihmcsdelhi.org" + System.Environment.NewLine
                   + "Contact No : +91-8285148778" + System.Environment.NewLine
                + System.Environment.NewLine
                   + System.Environment.NewLine
                   + "IHMCS INFORMATION CENTER :-" + System.Environment.NewLine
                   + "K-95/1, Main Masoodpur Market, Vasant Kunj," + System.Environment.NewLine
                   + "Near Hotel Malik Continental, New Delhi-110070," + System.Environment.NewLine;

                //var contentType = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Application.Pdf);
                message.IsBodyHtml = false;
                SmtpClient client = new SmtpClient();
                client.Host = "mail.ihmcsdelhi.org";
                client.Port = 25;
                client.Credentials = new System.Net.NetworkCredential("enquiry@ihmcsdelhi.org", "b9Jzm?05");
                client.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                ViewBag.Status = "Problem while sending email, Please check details." + ex.ToString();
            }
            return false;
        }

        public ActionResult exam()
        {
            return View();
        }

        public ActionResult Result()
        {
            return View();
        }


        //DBNull information
        // user id : IhmcsDelhiUser
        // pwd : mC0ha6@7
        // db : IhmcsDelhiDB


        public ActionResult ihmcs()
        {
            return View();
        }
    }
}
