using JsonStorage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace JsonStorage.Controllers
{
    public class ItemsController : Controller
    {
        // GET: ItemsController
        public ActionResult Index()
        {

            string jsonData = System.IO.File.ReadAllText("./Data/storage.json");
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var items = JsonSerializer.Deserialize<List<Item>>(jsonData, options);

            return View(items);
        }

        // GET: ItemsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ItemsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name")] Item item)
        {
            try
            {
                string jsonData = System.IO.File.ReadAllText("./Data/storage.json");
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNameCaseInsensitive = true
                };
                var items = JsonSerializer.Deserialize<List<Item>>(jsonData, options) ?? new List<Item>();

                items.Add(item);

                jsonData = JsonSerializer.Serialize(items, options);
                System.IO.File.WriteAllText("./Data/storage.json", jsonData);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ItemsController/Edit/5
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

        // GET: ItemsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ItemsController/Delete/5
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
