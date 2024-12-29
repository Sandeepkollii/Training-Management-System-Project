using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TMSClientApp.Models;
using TMSClientApp.ViewModel;

namespace TMSClientApp.Controllers
{
    public class BatchController : Controller
    {
        HttpClient client = new HttpClient();
        IConfiguration configuration;
        public BatchController(IConfiguration _config)
        {
            client.BaseAddress = new Uri("https://localhost:7263/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        // GET: BatchController
        public async Task<ActionResult> Index()
        {
            List<CourseViewModel> batches = null;
            HttpResponseMessage response = await client.GetAsync("api/batch");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                batches = JsonConvert.DeserializeObject<List<CourseViewModel>>(jsonString.Result);
                if(batches.Count==0)
                {
                    ViewBag.msg = "There are no batches";
                }

                return View(batches);
            }
            else
            {
                ViewBag.msg = response.ReasonPhrase;
                return View();
            }
        }

        // GET: BatchController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BatchController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BatchController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Batch batch)
        {
            try
            {
                StringContent content = new StringContent
                    (JsonConvert.SerializeObject(batch), Encoding.UTF8, "application/json");
                var contentType = new MediaTypeWithQualityHeaderValue
("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Authorization =
           new AuthenticationHeaderValue("Bearer",
           HttpContext.Session.GetString("token"));
                HttpResponseMessage response = await client.PostAsync("api/batch", content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    var temp = JsonConvert.DeserializeObject<Batch>(jsonString.Result);
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
        // GBatcET: BatchController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BatchController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BatchController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BatchController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
