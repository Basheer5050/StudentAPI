﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using studbApi.Models;

namespace studbApi.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index()
        {
            IEnumerable<StudentsModel> studata = null;
        }

        // GET: Students/Details/5
        public ActionResult Details(int id)
        {
            StudentsModel studata;
                //  var list = emp 
                studata = JsonConvert.DeserializeObject<StudentsModel>(json);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        public ActionResult Create(StudentsModel model)
        {
            try
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {
            StudentsModel studata;
                //  var list = emp 
                studata = JsonConvert.DeserializeObject<StudentsModel>(json);
        }

        // POST: Students/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StudentsModel model)
        {
            try
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {
            StudentsModel studata;
                //  var list = emp 
                studata = JsonConvert.DeserializeObject<StudentsModel>(json);
        }

        // POST: Students/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, StudentsModel model)
        {
            try
        }
    }
}