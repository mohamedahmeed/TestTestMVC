using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using TestTest;
using TestTest.VM;
using TestTestMVC.Vm;

namespace TestTestMVC.Controllers
{
    public class RegionController : Controller
    {
        // GET: RegionController
        public ActionResult Index()
        
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage res = client.GetAsync("http://localhost:27965/api/Region").Result;
            if (res.IsSuccessStatusCode)
            {
                List<RegionVm> regions = res.Content.ReadAsAsync<List<RegionVm>>().Result;
                return View(regions);
            }
            return View();
        }

        // GET: RegionController/Details/5
        public ActionResult Details(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage res=    client.GetAsync("http://localhost:27965/api/Region/"+id).Result;
            if (res.IsSuccessStatusCode)
            {
                Region region = res.Content.ReadAsAsync<Region>().Result;
                return View(region);
            }
            return NotFound();
        }

        // GET: RegionController/Create
        public ActionResult Create()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage res1 = client.GetAsync("http://localhost:27965/api/Country").Result;
            if (res1.IsSuccessStatusCode)
            {
                List<Country> country = res1.Content.ReadAsAsync<List<Country>>().Result;
                ViewBag.CName = country;
                
            }
            return View();
        }

        // POST: RegionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection,Region r)
        {
            
                HttpClient client =new HttpClient();
            HttpResponseMessage res=client.PostAsJsonAsync("http://localhost:27965/api/Region",r).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("index",r);
                }
                return RedirectToAction("Create", r);

            
            
        }

        // GET: RegionController/Edit/5
        public ActionResult Edit(int id)
        {
            HttpClient client = new HttpClient();
        HttpResponseMessage res=client.GetAsync("http://localhost:27965/api/Region/"+ id).Result;
            if (res.IsSuccessStatusCode)
            {
                EditeRegionVm region = res.Content.ReadAsAsync<EditeRegionVm>().Result;

                    return View(region);
                
            }
            
            return View();
        }

        // POST: RegionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Region rr , IFormCollection collection)
        {
            
                Region r = new Region()
                {
                    regionName=rr.regionName,
                    Country=rr.Country,
                    countryId=rr.countryId, 
                };
                HttpClient client =new HttpClient();
          HttpResponseMessage res= client.PutAsJsonAsync("http://localhost:27965/api/Region/"+id, r).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", r);
                }
                return RedirectToAction(nameof(Edit),rr);
           
        }

        // GET: RegionController/Delete/5
        public ActionResult Delete(int id)
        {
            HttpClient client= new HttpClient();
            HttpResponseMessage res=client.DeleteAsync("http://localhost:27965/api/Region/"+id).Result;
            if (res.IsSuccessStatusCode)
            {
               // Region r = res.Content.ReadAsAsync<Region>().Result;
                return RedirectToAction("Index");
            }
            return View();
        }

        // POST: RegionController/Delete/5
        
    }
}
