using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TMSClientApp.ViewModel;

namespace TMSClientApp.Controllers
{

    public class JWT
    {
        public string Token { get; set; }
    }

    public class LoginController : Controller
    {
        ILogger<LoginController> _logger;
        HttpClient client = new HttpClient();
        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
            client.BaseAddress = new Uri("https://localhost:7263/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        public IActionResult Login()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            try
            {
                StringContent content = new StringContent
                    (JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                var contentType = new MediaTypeWithQualityHeaderValue
("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = await client.PostAsync("api/Authenticate", content);
                if (response.IsSuccessStatusCode)
                {
                    var stringJWT = response.Content.ReadAsStringAsync().Result;
                    JWT jwt = JsonConvert.DeserializeObject<JWT>(stringJWT);
                    // the token that we received, has to be stored somewhere
                    // Why??
                    // becuase this tokek has to be sent alongwith every request to service now
                    // we have to use some state management technique
                    // cookie > are used on clienty side ,also there is a size limit here
                    // session varibales > are stored on server side 
                    // we are using session variable
                    // to use session varibale,  add using AddSession in the services collection
                    // and add it to the middleware pipeline
                    HttpContext.Session.SetString("token", jwt.Token);
                    return RedirectToAction("Index", "Course");
                }
                else
                {
                    _logger.LogCritical("Someone not authenicated is trying to access application");
                    ViewBag.msg = "User do not exist";
                    //TempData["role"]= "Get role here"
                    return View();
                }
            }
            catch
            {
                return View();
            }
            
            


        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("token");
            return RedirectToAction("Login");
        }
    }
}
