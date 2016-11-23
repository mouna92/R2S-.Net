using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using R2S.GUI.Models;
using R2S.Service;
using R2S.Service.Interfaces;
using R2S.Data.Models;

namespace R2S.GUI.Controllers
{
    public class InterviewController : BaseController
    {
        IInterviewService _interviewService = new InterviewService();
        IUserService _userService = new UserService();
        IJobService _jobService = new JobService();


        // GET: Interview
        public ActionResult Index()
        {
            return View(new InterviewViewModel() {User = CurrentUser, Interviews = _interviewService.GetMany().ToList()});
        }


        public ActionResult Create()
        {
            List<user> users = _userService.GetMany().ToList();
            user disabledUser = new user() { cin = 0, firstname = "Select a User" };
            List<user> disabledUsers = new List<user>() { disabledUser };
            users.Insert(0, disabledUser);
            ViewBag.candidate_cin = new SelectList(users, "cin", "firstname", disabledUsers);

            List<job> jobs = _jobService.GetMany().ToList();
            job disabledJob = new job() { id = 0, name = "Select a Job" };
            List<job> disabledJobs = new List<job>() { disabledJob };
            jobs.Insert(0, disabledJob);
            ViewBag.job_id = new SelectList(jobs, "id", "name", disabledJobs);

            return View(new InterviewViewDetailsModel() { User = CurrentUser });
        }

     
        [HttpPost]
        public ActionResult Create([Bind(Include = "date, candidate_cin, job_id")] interview interview)
        {
            if (ModelState.IsValid)
            {
                interview.recruitmentManager_cin = CurrentUser.Id;
                
                _interviewService.Add(interview);
                _interviewService.commit();

                interview.user = _userService.GetById(interview.candidate_cin.GetValueOrDefault());

                return RedirectToAction("Index");
            }

            return View(new InterviewViewDetailsModel() { User = CurrentUser, Interview = interview });
        }
    }
}