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
            List<PaisString> paises = new List<PaisString>();
            foreach (var item in Data.instance.Diccionario1)
            {
                PaisString pais = new PaisString();
                pais.nombre = item.Key;
                pais.faltantes = item.Value.faltantesToString();
                pais.coleccionadas = item.Value.coleccionadasToString();
                pais.cambios = item.Value.cambiosToString();
                paises.Add(pais);
            }
            return View(paises);
        }
        public ActionResult Index2()
        {
            List<Calcomania> calcos = new List<Calcomania>();
            foreach (var item in Data.instance.Diccionario2)
            {
                Calcomania nueva = new Calcomania();
                nueva.nombre = item.Key;
                nueva.disponibilidad = Convert.ToString(item.Value);
                calcos.Add(nueva);
            }
            return View(calcos);

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
        public ActionResult Actualizar(string id)
        {
            return View(Data.instance.Diccionario1[id]);
        }

        // POST: Pais/Edit/5
        [HttpPost]
        public ActionResult Actualizar(string id, FormCollection collection)
        {
            try
            {
                bool faltante = false, coleccionada = false;
                int nueva = int.Parse(collection["nombre"]);
                if (Data.instance.Diccionario1[id].faltantes.Count != 0)
                {
                    for (int i = 0; i < Data.instance.Diccionario1[id].faltantes.Count; i++)
                    {
                        if (nueva == Data.instance.Diccionario1[id].faltantes[i])
                        {
                            Data.instance.Diccionario1[id].faltantes.RemoveAt(i);
                            Data.instance.Diccionario1[id].coleccionadas.Add(nueva);
                            faltante = true;
                            break;
                        }                        
                    }
                }

                if (!faltante)
                {
                    for (int j = 0; j < Data.instance.Diccionario1[id].coleccionadas.Count; j++)
                    {
                        if (nueva == Data.instance.Diccionario1[id].coleccionadas[j])
                        {
                            Data.instance.Diccionario1[id].cambios.Add(nueva);
                            coleccionada = true;
                            break;
                        }                        
                    }                    
                }

                if (!faltante && !coleccionada)
                {
                    TempData["alertMessage"] = "El número de calcomania que ingresó no existe";
                    return View();
                }                                                
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
                    Dictionary<string, Pais> lista;

                    Data.instance.Diccionario1 = JsonConvert.DeserializeObject< Dictionary < string,Pais >> (csvData);                                            
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
                return RedirectToAction("Index2");
            }
            catch
            {
                return View();
            }
        }
    }
}
