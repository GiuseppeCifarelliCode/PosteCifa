using Microsoft.Ajax.Utilities;
using PosteCifa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PosteCifa.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string tipoSelezione, string CF, int IdSpedizione)
        {
            if (ModelState.IsValid)
            {
                if (tipoSelezione == "Cliente")
                {
                    Spedizione s = DB.getSpedizioneFromClientiById(IdSpedizione);
                    Cliente c = DB.getClienteById(s.IdCliente);
                    if (c.CF == CF)
                    {
                        TempData["tipoSelezione"] = tipoSelezione;
                        TempData["spedizione"] = s;
                        return RedirectToAction("Detail");
                    }
                    else
                    {
                        ViewBag.Error = "Nessuna Spedizione trovata";
                        return View();
                    }
                }
                else if (tipoSelezione == "Azienda")
                {
                    Spedizione s = DB.getSpedizioneFromAziendaById(IdSpedizione);
                    Azienda a = DB.getAziendaById(s.IdCliente);
                    if (a.PartitaIVA == CF)
                    {
                        TempData["tipoSelezione"] = tipoSelezione;
                        TempData["spedizione"] = s;
                        return RedirectToAction("Detail");
                    }
                    else
                    {
                        ViewBag.Error = "Nessuna Spedizione trovata";
                        return View();
                    }
                }
                else return View();

            }
            else{
                ViewBag.Error = "Dati inseriti non  validi";
                return View();
            }
        }

        public ActionResult Detail()
        {
            string tipoSelezione = TempData["tipoSelezione"] as string;
            Spedizione spedizione = TempData["spedizione"] as Spedizione;
            if(tipoSelezione == "Cliente")
            {
                List<AggiornamentoSpedizione> update = DB.getAllUpdateSFromClienteById(spedizione.Id);
                ViewBag.spedizione = spedizione;
                return View(update);
            } else if(tipoSelezione == "Azienda")
            {
                List<AggiornamentoSpedizione> update = DB.getAllUpdateSFromAziendaById(spedizione.Id);
                ViewBag.spedizione = spedizione;
                return View(update);
            }
            return View();
        }
    }
}