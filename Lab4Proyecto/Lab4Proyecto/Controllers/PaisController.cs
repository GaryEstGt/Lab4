using Lab4Proyecto.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab4Proyecto.Controllers
{
    public class PaisController : Controller
    {
        // GET: Pais
        public ActionResult Index()
        {
            return View(Data.instance.Diccionario1.Select(x => x.Value).ToList());
        }

        // GET: Pais/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pais/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pais/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pais/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pais/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pais/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult CrearPorArchivo()
        {
            return View();
        }

        // POST: Jugador/Create
        [HttpPost]
        public ActionResult CrearPorArchivo(HttpPostedFileBase postedFile)
        {
            try
            {
                string todoeltexto = "";
                string filePath = string.Empty;
                if (postedFile != null)
                {
                    string path = Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    filePath = path + Path.GetFileName(postedFile.FileName);
                    string extension = Path.GetExtension(postedFile.FileName);
                    postedFile.SaveAs(filePath);

                    int contLinea = 0;
                    string csvData = System.IO.File.ReadAllText(filePath);
                    Dictionary<string, Pais>[] lista;

                        lista = JsonConvert.DeserializeObject < Dictionary < string,Pais >[]> (csvData);
                    for (int i = 0; i < lista.Length; i++)
                    {
                        for (int y = 0; y < lista[i].Select(x=>x.Value).ToArray().Length; y++)
                        {
                            Data.instance.Diccionario1.Add(lista[i].Select(x => x.Key).ToArray()[0], lista[i].Select(x => x.Value).ToArray()[y]);
                        }
                        
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult CrearPorArchivo2()
        {
            return View();
        }

        // POST: Jugador/Create
        [HttpPost]
        public ActionResult CrearPorArchivo2(HttpPostedFileBase postedFile)
        {
            try
            {
                string todoeltexto = "";
                string filePath = string.Empty;
                if (postedFile != null)
                {
                    string path = Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    filePath = path + Path.GetFileName(postedFile.FileName);
                    string extension = Path.GetExtension(postedFile.FileName);
                    postedFile.SaveAs(filePath);

                    int contLinea = 0;
                    string csvData = System.IO.File.ReadAllText(filePath);

                    Data.instance.Diccionario2 = JsonConvert.DeserializeObject<Dictionary<string, bool>>(csvData);

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
