using jpdemo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using umbraco;

namespace jpdemo1.Controllers
{
    /// <summary>
    /// Summary description for ContactSurfaceController
    /// </summary>
    public class ContactSurfaceController : Umbraco.Web.Mvc.SurfaceController
    {
        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("<p>Name: {0}</p>", model.Name);
                sb.AppendFormat("<p>Email: {0}</p>", model.Email);
                sb.AppendFormat("<p>Phone: {0}</p>", model.Phone);
                sb.AppendFormat("<p>{0}</p>", model.Message);

                library.SendMail("noreply@cms.jeremypridmore.com", "jeremy.pridmore@googlemail.com", "CMS Contact Form", sb.ToString(), true);

                return RedirectToUmbracoPage(model.ThankYouPage);
            }

            return CurrentUmbracoPage();
        }
    }
}
