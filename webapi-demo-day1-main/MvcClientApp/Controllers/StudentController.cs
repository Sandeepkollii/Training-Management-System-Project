using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcClientApp.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace MvcClientApp.Controllers
{
    public class StudentController : Controller
    {
        HttpClient client = new HttpClient();
        static List<Student> students = null;
        public StudentController()
        {
            client.BaseAddress = new Uri("https://localhost:7226/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Acctrept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        // GET: StudentController
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync("api/Student");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                students = JsonConvert.DeserializeObject<List<Student>>(jsonString.Result);


                return View(students);
            }
            else
            {
                ViewBag.msg = response.ReasonPhrase;
                return View();
            }
        }

        // GET: StudentController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            HttpResponseMessage response = await client.GetAsync("api/Student/"+id);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                var student = JsonConvert.DeserializeObject<Student>(jsonString.Result);


                return View(student);
            }
            else
            {
                ViewBag.msg = response.ReasonPhrase;
                return View();
            } 
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Student student)
        {
            try
            {
                StringContent content = new StringContent
                    (JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");
                var contentType = new MediaTypeWithQualityHeaderValue
("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = await client.PostAsync("api/Student", content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    var temp = JsonConvert.DeserializeObject<Student>(jsonString.Result);



                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage response = await client.GetAsync("api/Student/" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                var student = JsonConvert.DeserializeObject<Student>(jsonString.Result);


                return View(student);
            }
            else
            {
                ViewBag.msg = response.ReasonPhrase;
                return View();
            }
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Student student)
        {
             try
            {
                StringContent content = new StringContent
                    (JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");
                var contentType = new MediaTypeWithQualityHeaderValue
("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = await client.PutAsync("api/Student/"+id, content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    var temp = JsonConvert.DeserializeObject<Student>(jsonString.Result);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
            }

        // GET: StudentController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage response = await client.GetAsync("api/Student/" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                var student = JsonConvert.DeserializeObject<Student>(jsonString.Result);


                return View(student);
            }
            else
            {
                ViewBag.msg = response.ReasonPhrase;
                return View();
            }
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<ActionResult> Deleted(int id)
        {
            try
            {
                
                HttpResponseMessage response = await client.DeleteAsync("api/Student/"+id);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    var temp = JsonConvert.DeserializeObject<Student>(jsonString.Result);



                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
