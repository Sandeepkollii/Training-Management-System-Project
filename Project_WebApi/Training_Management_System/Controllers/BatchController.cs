using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Training_Management_System.Models;
using Training_Management_System.ViewModels;

namespace Training_Management_System.Controllers
{
    public class BatchController : Controller
    {
        HttpClient client = new HttpClient();
        static List<Batch> courses = null;
        static List<CourseViewModel> CourseView = null;

        public BatchController()
        {
            client.BaseAddress = new Uri("https://localhost:7191");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }



        // GET: BatchController
        public async Task<ActionResult> Index()
        {
            List<BatchViewModel> batchView = null;
            HttpResponseMessage response = await client.GetAsync("api/Batch");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                batchView = JsonConvert.DeserializeObject<List<BatchViewModel>>(jsonString.Result);
                if (batchView != null) {
                    return View(batchView);
                }
                else
                {
                    ViewBag.msg = "No Batches Found";
                    return View();
                }

                
            }
            else
            {
                ViewBag.msg = response.ReasonPhrase;
                return View();
            }

        }

        // GET: BatchController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            HttpResponseMessage response = await client.GetAsync("api/Batch/" + id);
            if (response.IsSuccessStatusCode)
            {

                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                var batch = JsonConvert.DeserializeObject<BatchViewModel>(jsonString.Result);
                if (batch != null) {

                    return View(batch);

                }
                else
                {
                    ViewBag.msg = "No Batch Found";
                    return View();
                }
                

            }
            else
            {
                ViewBag.msg = response.ReasonPhrase;
                return View();
            }

        }

        // GET: BatchController/Create
        public async Task<ActionResult> Create()
        {
            HttpResponseMessage response = await client.GetAsync("api/Batch/GetCourses/");
            if (response.IsSuccessStatusCode)
            {

                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                var btc = JsonConvert.DeserializeObject<List<BatchViewModel>>(jsonString.Result);
                if (btc == null) 
                {
                    ViewBag.msg = "No Course is Available";
                    
                }
                ViewBag.courses = new SelectList(btc, "CourseId", "CourseName");
                return View();

            }
            else
            {
                ViewBag.msg = response.ReasonPhrase;
                return View();
            }

        }

        // POST: BatchController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Batch batch)
        {
            //course.CourseId = 0;
            //course.CreatedBy = 3;
            //course.CreatedOn = DateTime.Now;
            //course.IsActive = true;
            batch.BatchId = 0;
            batch.CreatedBy = 3;
            batch.CreatedOn = DateTime.Now;

            try
            {
                StringContent content = new StringContent
                   (JsonConvert.SerializeObject(batch), Encoding.UTF8, "application/json");
                var contentType = new MediaTypeWithQualityHeaderValue
("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);

                HttpResponseMessage response = await client.PostAsync("api/Batch", content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    var temp = JsonConvert.DeserializeObject<Batch>(jsonString.Result);
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    ViewBag.msg = response.ReasonPhrase;
                    return View();
                }


            }
            catch
            {
                return View();
            }
        }



        // GET: BatchController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage response = await client.GetAsync("api/Batch/GetCourses/");
            if (response.IsSuccessStatusCode)
            {

                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                var btc = JsonConvert.DeserializeObject<List<BatchViewModel>>(jsonString.Result);
                if (btc == null)
                {
                    ViewBag.msg = "No Course is Available";

                }
                ViewBag.courses = new SelectList(btc, "CourseId", "CourseName");
                

            }
            HttpResponseMessage response1 = await client.GetAsync("api/Batch/" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = response1.Content.ReadAsStringAsync();
                jsonString.Wait();
                var temp = JsonConvert.DeserializeObject<Batch>(jsonString.Result);
                return View(temp);

            }
            else
            {
                ViewBag.msg = response1.ReasonPhrase;
                return View();
            }

            
            
            

        }

        // POST: BatchController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id,Batch batch)
        {
            batch.BatchId = 0;
            try
            {
                batch.Updated = DateTime.Now;
                batch.UpdatedBy = 3;
                
                StringContent content = new StringContent
                   (JsonConvert.SerializeObject(batch), Encoding.UTF8, "application/json");
                var contentType = new MediaTypeWithQualityHeaderValue
("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);

                HttpResponseMessage response = await client.PutAsync("api/Batch/" + id, content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    var temp = JsonConvert.DeserializeObject<Batch>(jsonString.Result);
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    ViewBag.msg = response.ReasonPhrase;
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: BatchController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage response = await client.GetAsync("api/Batch/" + id);
            if (response.IsSuccessStatusCode)
            {

                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                var batch = JsonConvert.DeserializeObject<Batch>(jsonString.Result);
                if (batch != null)
                {

                    return View(batch);

                }
                else
                {
                    ViewBag.msg = "No Batch Found";
                    return View();
                }


            }
            else
            {
                ViewBag.msg = response.ReasonPhrase;
                return View();
            }
        }

        // POST: BatchController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Deleted(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("api/Batch/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    var batch = JsonConvert.DeserializeObject<Batch>(jsonString.Result);
                    if (batch != null)
                    {

                        return View(batch);

                    }
                    else
                    {
                        ViewBag.msg = "No Batch Found";
                        return View();
                    }


                }
                else
                {
                    ViewBag.msg = response.ReasonPhrase;
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
