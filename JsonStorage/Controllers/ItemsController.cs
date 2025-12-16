using JsonStorage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace JsonStorage.Controllers
{
    public class ItemsController : Controller
    {

        public readonly string filePath = "./Data/storage.json";

        public List<Item> returnList(string filePath)
        {

            string jsonData = System.IO.File.ReadAllText(filePath);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<List<Item>>(jsonData, options) ?? new List<Item>();

        }
        
        // GET: ItemsController
        public ActionResult Index()
        {

            var items = returnList(filePath);

            return View(items);
        }

        // GET: ItemsController/Details/5
        public ActionResult Details(int id)
        {
            
            var items = returnList(filePath);

            var item = items[id - 1]; // to get the correct index

            return View(item);
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
                // Retrieves list and adds latest item
                var items = returnList(filePath);
                items.Add(item);

                // Serializes new list and wites it into the json file
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true
                };
                var jsonData = JsonSerializer.Serialize(items, options);
                System.IO.File.WriteAllText(filePath, jsonData);

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
