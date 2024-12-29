using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Training_Management_System.Models;

namespace Training_Management_System.Controllers
{
    public class UserController : Controller
    {
        HttpClient client = new HttpClient();
        static List<User> users = null;

        public UserController() {

            client.BaseAddress = new Uri("https://localhost:7191");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        // GET: UserController
        public async Task<ActionResult> Index()
        {
            List<UserViewModel> userView = null;
            HttpResponseMessage response = await client.GetAsync("api/User");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                userView = JsonConvert.DeserializeObject<List<UserViewModel>>(jsonString.Result);
                if (userView != null)
                {
                    return View(userView);
                }
                else
                {
                    ViewBag.msg = "No Users Found";
                    return View();
                }


            }
            else
            {
                ViewBag.msg = response.ReasonPhrase;
                return View();
            }
        }

        // GET: UserController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            //HttpResponseMessage response = await client.GetAsync("api/User/GetManagers/" + id);
            HttpResponseMessage response = await client.GetAsync("api/User/" + id);
            if (response.IsSuccessStatusCode)
            {

                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                var usr = JsonConvert.DeserializeObject<UserViewModel>(jsonString.Result);
                if (usr != null)
                {

                    return View(usr);

                }
                else
                {
                    ViewBag.msg = "No User Found";
                    return View();
                }


            }
            else
            {
                ViewBag.msg = response.ReasonPhrase;
                return View();
            }
        }

        // GET: UserController/Create
        public async Task<ActionResult> Create()
        {
            List<Role> roles = null;
            List<UserViewModel> manager = null;
            HttpResponseMessage response = await client.GetAsync("api/User/GetRoles/");
            if (response.IsSuccessStatusCode)
            {

                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                var btc = JsonConvert.DeserializeObject<List<Role>>(jsonString.Result);
                if (btc == null)
                {
                    ViewBag.msg = "No such Role is Available";

                }
                ViewBag.roles = new SelectList(btc, "RoleId", "RoleName");

                
                

            }
           
            HttpResponseMessage response2 = await client.GetAsync("api/User/GetManagers");
            if (response2.IsSuccessStatusCode)
            {
                var jsonString = response2.Content.ReadAsStringAsync();
                jsonString.Wait();
                manager = JsonConvert.DeserializeObject<List<UserViewModel>>(jsonString.Result);
            }
            if (manager == null)
            {
                ViewBag.Msg = "No Manager is available";
            }
            ViewBag.manager = new SelectList(manager, "ManagerId", "ManagerName");


            return View();


        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Create(User user)
        {
            user.CreatedBy = 1;
            user.CreatedOn = DateTime.Now;
            user.IsActive = true;
            user.UserId = 0;
            try
            {
                StringContent content = new StringContent
                   (JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                var contentType = new MediaTypeWithQualityHeaderValue
("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);

                HttpResponseMessage response = await client.PostAsync("api/User", content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    var temp = JsonConvert.DeserializeObject<User>(jsonString.Result);
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

        // GET: UserController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            List<Role> temp = null;
            List<UserViewModel> manager = null;
            HttpResponseMessage response = await client.GetAsync("api/User/GetRoles");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                temp = JsonConvert.DeserializeObject<List<Role>>(jsonString.Result);

            }
            if (temp == null || temp.Any())
            {
                ViewBag.msg = "No Role is Present";
            }
            ViewBag.roles = new SelectList(temp, "RoleId", "RoleName");
            
            
            HttpResponseMessage response2 = await client.GetAsync("api/User/managers/" +id);
            if (response2.IsSuccessStatusCode)
            {
                var jsonString = response2.Content.ReadAsStringAsync();
                jsonString.Wait();
                manager = JsonConvert.DeserializeObject<List<UserViewModel>>(jsonString.Result);
            }
            if (manager == null || !manager.Any())
            {
                ViewBag.Msg = "No Manager is available";
            }
            ViewBag.manager = new SelectList(manager, "ManagerId", "ManagerName");

            HttpResponseMessage response1 = await client.GetAsync("api/User/" + id);
            if (response1.IsSuccessStatusCode)
            {
                var jsonString = response1.Content.ReadAsStringAsync();
                jsonString.Wait();
                var user = JsonConvert.DeserializeObject<User>(jsonString.Result);

                return View(user);
            }
            else
            {
                ViewBag.msg = response1.ReasonPhrase;
                return View();
            }



        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, User user)
        {
            user.UserId = 0;
            user.Updated = DateTime.Now;
            user.UpdatedBy = 3;
            try
            {
                

                StringContent content = new StringContent
                   (JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                var contentType = new MediaTypeWithQualityHeaderValue
("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);

                HttpResponseMessage response = await client.PutAsync("api/User/" + id, content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    var temp = JsonConvert.DeserializeObject<User>(jsonString.Result);
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

        // GET: UserController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage response = await client.GetAsync("api/User/" + id);
            if (response.IsSuccessStatusCode)
            {

                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                var usr = JsonConvert.DeserializeObject<User>(jsonString.Result);

                return View(usr);


            }
            else
            {
                ViewBag.msg = response.ReasonPhrase;
                return View();
            }
        }

        // POST: UserController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Deleted(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("api/User/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    var usr = JsonConvert.DeserializeObject<User>(jsonString.Result);
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
