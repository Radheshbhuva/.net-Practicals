
using System.Collections.Generic;
using System.Web.Mvc;
using FeedbackManagement.Models;

namespace FeedbackManagement.Controllers
{
    public class FeedbackController : Controller
    {
        public static List<Feedback> feedbackList =
            new List<Feedback>();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GiveFeedback()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GiveFeedback(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedbackList.Add(feedback);
                return RedirectToAction("ViewFeedback");
            }

            return View(feedback);
        }

        public ActionResult ViewFeedback()
        {
            return View(feedbackList);
        }
    }
}
