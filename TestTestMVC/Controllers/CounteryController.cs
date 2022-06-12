using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using TestTest;

namespace TestTestMVC.Controllers
{
    public class CounteryController : Controller
    {
        // GET: CounteryController
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
        HttpResponseMessage res=client.GetAsync("http://localhost:27965/api/Country").Result;
            if (res.IsSuccessStatusCode)
            {
               List<Country> countries=res.Content.ReadAsAsync<List<Country>>().Result;
                return View(countries);
            }
            return View();
        }

        // GET: CounteryController/Details/5
        public ActionResult Details(int id)
        {
            HttpClient client = new HttpClient();
   HttpResponseMessage res= client.GetAsync("http://localhost:27965/api/Country/" + id).Result;
            if (res.IsSuccessStatusCode)
            {
                Country country = res.Content.ReadAsAsync<Country>().Result;
                return View(country);
            }
            return View();
        }

        // GET: CounteryController/Create
        public ActionResult Create()
        {
          
            return View();
        }

        // POST: CounteryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Country c)
        {

           
                    HttpClient client = new HttpClient();
                    HttpResponseMessage res = client.PostAsJsonAsync("http://localhost:27965/api/Country", c).Result;
                    if (res.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", c);
                    }
                     else
                      {
                    
                return RedirectToAction("Create", c);
                      }
          
        }

        // GET: CounteryController/Edit/5
        public ActionResult Edit(int id)
        {
            //ازى ابعت error massage لما يدخل دوله موجوده اصلا
            HttpClient client = new HttpClient();
            HttpResponseMessage res = client.GetAsync("http://localhost:27965/api/Country/" + id).Result;
            if (res.IsSuccessStatusCode)
            {
                Country country = res.Content.ReadAsAsync<Country>().Result;
                return View(country);
            }
            return View();

        }

        // POST: CounteryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Country c, IFormCollection collection)
        {
            try
            {
                Country cc = new Country()
                {
                    countryName = c.countryName,
                };
                HttpClient client = new HttpClient();
                HttpResponseMessage res = client.PutAsJsonAsync("http://localhost:27965/api/Country/"+id,cc).Result;
                if (res.IsSuccessStatusCode)
                {
                    Country country = res.Content.ReadAsAsync<Country>().Result;
                    return RedirectToAction("index", cc);
                }
                return RedirectToAction(nameof(Edit));
            }
            catch
            {
                return View();
            }
        }

        // GET: CounteryController/Delete/5
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage res = client.DeleteAsync("http://localhost:27965/api/Country/" + id).Result;
            if (res.IsSuccessStatusCode)
            {
                Country country = res.Content.ReadAsAsync<Country>().Result;
                return RedirectToAction("Index");
            }
            return View();
        }

        // POST: CounteryController/Delete/5
       
    }
}
