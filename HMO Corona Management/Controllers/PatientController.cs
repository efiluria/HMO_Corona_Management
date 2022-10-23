using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using HMO_Corona_Management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Http;

namespace HMO_Corona_Management.Controllers
{
    public class PatientController : Controller
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "sFCsM0BpjSSi2kzKBwvNMuF40Xg4oJ1nSCsUOLHN",
            BasePath = "https://hmo-corona-management-default-rtdb.firebaseio.com/",
        };

        IFirebaseClient client;

        // GET: PatientController
        public ActionResult Index()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Patients");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<Patient>();
            //IEnumerable<String> list;
            if (data != null)
            {
                foreach (var item in data)
                {
                    list.Add(JsonConvert.DeserializeObject<Patient>(((JProperty)item).Value.ToString()));
                }
            }
            return View(list);
        }

        // GET: PatientController/Details/5
        public ActionResult Details(string id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Patients/" + id);
            Patient data = new Patient();
            data = JsonConvert.DeserializeObject<Patient>(response.Body);
            return View(JsonConvert.DeserializeObject<Patient>(response.Body));
        }

        // GET: PatientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentInfo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Patient patient)
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
                var data = patient;
                PushResponse response = client.Push("Patients/", data);
                data.id = response.Result.name;
                // set the id of the patient to be the name of the response
                SetResponse setResponse = client.Set("Patients/" + data.id, data);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    ModelState.AddModelError(string.Empty, "Added Succesfully");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Something went wrong!");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }

        // GET: PatientController/Edit/5
        public ActionResult Edit(string id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Patients/" + id);
            Patient data = JsonConvert.DeserializeObject<Patient>(response.Body);
            return View(data);
        }

        // POST: PatientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Patient patient)
        {
            client = new FireSharp.FirebaseClient(config);
            SetResponse response = client.Set("Patients/" + patient.id, patient);
            return RedirectToAction("Index");
        }

        // GET: PatientController/Delete/5
        public ActionResult Delete(Patient patient)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Patients/" + patient.id);
            Patient data = JsonConvert.DeserializeObject<Patient>(response.Body);
            return View(data);
        }

        // POST: PatientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Delete("Patients/" + id);
            return RedirectToAction("Index");
        }
    }
}
