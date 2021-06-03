using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using StudMVC.Models;
using System.Collections.Specialized;
using System.Text;
using System.Net;
using System.Web.Http.Cors;

namespace StudMVC.Controllers
{
    public class StudentMvcController : Controller
    {
        // GET: StudentMvc
        [EnableCors(headers: "*", methods: "*", origins: "*")]
        public ActionResult Index()
        {


            IEnumerable<StudentView> empdata = null;
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = "https://localhost:44304/api/";

                var json = webClient.DownloadString("Students");
                var list = JsonConvert.DeserializeObject<List<StudentView>>(json);
                empdata = list.ToList();
                return View(empdata);
            }
        }

        // GET: StudentMvc/Details/5
        [EnableCors(headers: "*", methods: "*", origins: "*")]
        public ActionResult Details(int id)
        {

            StudentView empdata;
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = "https://localhost:44304/api/";

                var json = webClient.DownloadString("Students/" + id);
                //  var list = emp 
                empdata = JsonConvert.DeserializeObject<StudentView>(json);
            }
            return View(empdata);
        }

        // GET: StudentMvc/Create
        [EnableCors(headers: "*", methods: "*", origins: "*")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentMvc/Create

        [HttpPost]
        [EnableCors(headers: "*", methods: "*", origins: "*")]
        public ActionResult Create(StudentView model)
        {
            try
            {
                // TODO: Add insert logic here

                using (WebClient webClient = new WebClient())
                {
                    webClient.BaseAddress = "https://localhost:44304/api/";
                    var url = "Students/POST";
                    //webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    string data = JsonConvert.SerializeObject(model);
                    var response = webClient.UploadString(url, data);
                    JsonConvert.DeserializeObject<StudentView>(response);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        // GET: StudentMvc/Edit/5
        [EnableCors(headers: "*", methods: "*", origins: "*")]
        public ActionResult Edit(int id)
        {
            StudentView empdata;
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = "https://localhost:44304/api/";

                var json = webClient.DownloadString("Students/" + id);
                //  var list = emp 
                empdata = JsonConvert.DeserializeObject<StudentView>(json);
            }
            return View(empdata);
        }

        // POST: StudentMvc/Edit/5
        [EnableCors(headers: "*", methods: "*", origins: "*")]
        [HttpPost]
        public ActionResult Edit(int id, StudentView model)
        {
            try
            {
                // TODO: Add update logic here
                using (WebClient webClient = new WebClient())
                {
                    webClient.BaseAddress = "https://localhost:44304/api/Students/"+id;
                    //var url = "Values/Put/" + id;
                    //webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    string data = JsonConvert.SerializeObject(model);

                    var response = webClient.UploadString(webClient.BaseAddress, data);

                    StudentView modeldata = JsonConvert.DeserializeObject<StudentView>(response);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        // GET: StudentMvc/Delete/5
        [EnableCors(headers: "*", methods: "*", origins: "*")]
        public ActionResult Delete(int id)
        {
            StudentView empdata;
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = "https://localhost:44304/api/";

                var json = webClient.DownloadString("Students/" + id);
                //  var list = emp 
                empdata = JsonConvert.DeserializeObject<StudentView>(json);
            }
            return View(empdata);
        }

        // POST: StudentMvc/Delete/5
        [EnableCors(headers: "*", methods: "*", origins: "*")]
        [HttpPost]
        public ActionResult Delete(int id, StudentView model)
        {
            try
            {
                // TODO: Add delete logic here

                using (WebClient webClient = new WebClient())
                {
                    NameValueCollection nv = new NameValueCollection();
                    var url = "https://localhost:44304/api/Students/" + id;
                    var response = Encoding.ASCII.GetString(webClient.UploadValues(url, "DELETE", nv));

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }
    }
}
