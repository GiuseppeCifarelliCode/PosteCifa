using PosteCifa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace PosteCifa.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public List<Cliente> c = DB.getAllClienti();
        public List<Azienda> a = DB.getAllAziende();
        public List<SelectListItem> clienti
        {
            get
            {
                List<SelectListItem> listC = new List<SelectListItem>();
                foreach (Cliente cliente in c)
                {
                    SelectListItem item = new SelectListItem { Text = cliente.Surname + " " + cliente.Name, Value = cliente.Id.ToString() };
                    listC.Add(item);
                }
                return listC;
            }
        }

        public List<SelectListItem> aziende
        {
            get
            {
                List<SelectListItem> listA = new List<SelectListItem>();
                foreach (Azienda azienda in a)
                {
                    SelectListItem item = new SelectListItem { Text = azienda.Nominativo, Value = azienda.Id.ToString() };
                    listA.Add(item);
                }
                return listA;
            }
        }

        public List<SelectListItem> listaStati
        {
            get
            {
                List<SelectListItem> list = new List<SelectListItem>();
                SelectListItem item = new SelectListItem { Text = "In Transito", Value = "In Transito" };
                SelectListItem item2 = new SelectListItem { Text = "Bloccato alla Dogana", Value = "Bloccato alla Dogana" };
                SelectListItem item3 = new SelectListItem { Text = "In Consegna", Value = "In Consegna" };
                SelectListItem item4 = new SelectListItem { Text = "Rubato", Value = "Rubato" };
                SelectListItem item5 = new SelectListItem { Text = "Consegnato", Value = "Consegnato" };

                list.Add(item);
                list.Add(item2);
                list.Add(item3);
                list.Add (item4);
                list.Add(item5);
                return list;
            }
        }


        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCliente()
        {
            ViewBag.ListaClienti = DB.getAllClienti();
            return View();
        }

        [HttpPost]
        public ActionResult AddCliente(Cliente c)
        {
            if (ModelState.IsValid)
            {
                DB.AddCliente(c.Name, c.Surname, c.BirthDay, c.CF);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ListaClienti = DB.getAllClienti();
                return View();
            }
        }

        public ActionResult AddAzienda()
        {
            ViewBag.ListaAziende = DB.getAllAziende();
            return View();
        }

        [HttpPost]
        public ActionResult AddAzienda(Azienda a)
        {
            if (ModelState.IsValid)
            {
                DB.AddAzienda(a.Nominativo, a.RagioneSociale, a.PartitaIVA);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ListaAziende = DB.getAllAziende();
                return View();
            }
        }
        public ActionResult AddSpedizione()
        {
            ViewBag.ListaClienti = clienti;
            ViewBag.ListaAziende = aziende;
            return View(); 
        }

        [HttpPost]
        public ActionResult AddSpedizione(Spedizione s,string tipoSelezione,string selectedCliente,string selectedAzienda)
        {
            if (ModelState.IsValid)
            {
                if(tipoSelezione == "Cliente")
                {
                    s.IdCliente = int.Parse(selectedCliente);
                    DB.AddSpedizioneCLienti(s.DataSpedizione, s.Weight, s.Destination, s.Address, s.Destinatario, s.Price, s.DataConsegna,s.IdCliente);
                    List<Spedizione> spedizioni = DB.getAllSpedizioniFromClienti();
                    DB.AddUpdateSClienti("In deposito", "Matera", "Stiamo cercando il prodotto", DateTime.Now, spedizioni[spedizioni.Count-1].Id);
                    return RedirectToAction("Index");
                } else if(tipoSelezione == "Azienda")
                {
                    s.IdCliente = int.Parse(selectedAzienda);
                    DB.AddSpedizioneAzienda(s.DataSpedizione, s.Weight, s.Destination, s.Address, s.Destinatario, s.Price, s.DataConsegna, s.IdCliente);
                    List<Spedizione> spedizioni = DB.getAllSpedizioniFromAziende();
                    DB.AddUpdateSAzienda("In deposito", "Matera", "Stiamo cercando il prodotto", DateTime.Now, spedizioni[spedizioni.Count - 1].Id);
                    return RedirectToAction("Index");
                } else
                {
                    ViewBag.ListaClienti = clienti;
                    ViewBag.ListaAziende = aziende;
                    return View();
                }
            }
            else
            {
                ViewBag.ListaClienti = clienti;
                ViewBag.ListaAziende = aziende;
                return View();
            }
        }

        public ActionResult ShowSpedizioni()
        {
            ViewBag.sClienti = DB.getAllSpedizioniFromClienti();
            ViewBag.sAziende = DB.getAllSpedizioniFromAziende();
            return View();
        }

        public ActionResult UpdateSCliente(int id)
        {
            ViewBag.listaStati = listaStati;
            ViewBag.SCliente = DB.getSpedizioneFromClientiById(id);
            ViewBag.updateSCliente = DB.getAllUpdateSFromClienteById(id);
            AggiornamentoSpedizione u = new AggiornamentoSpedizione();
            u.IdSpedizione = id;
            return View(u);
        }

        [HttpPost]
        public  ActionResult UpdateSCliente(AggiornamentoSpedizione u)
        {
            if (ModelState.IsValid)
            {
                DB.AddUpdateSClienti(u.State, u.City, u.Description, u.Update, u.IdSpedizione);
                return RedirectToAction("Index");
            } else return View();
        }

        public ActionResult UpdateSAzienda(int id)
        {
            ViewBag.listaStati = listaStati;
            ViewBag.SAzienda = DB.getSpedizioneFromAziendaById(id);
            ViewBag.updateSAzienda = DB.getAllUpdateSFromAziendaById(id);
            AggiornamentoSpedizione u = new AggiornamentoSpedizione();
            u.IdSpedizione = id;
            return View(u);
        }

        [HttpPost]
        public ActionResult UpdateSAzienda(AggiornamentoSpedizione u)
        {
            if (ModelState.IsValid)
            {
                DB.AddUpdateSAzienda(u.State, u.City, u.Description, u.Update, u.IdSpedizione);
                return RedirectToAction("Index");
            }
            else return View();
        }

        public ActionResult Query()
        {
            return View();
        }

        public ActionResult getSpedizioniToday()
        {
            List<Spedizione> sCliente = DB.getAllSpedizioniFromClientiByDataConsegna(DateTime.Now);
            List<Spedizione> sAzienda = DB.getAllSpedizioniFromAziendaByDataConsegna(DateTime.Now);
            sCliente.AddRange(sAzienda);

            var formattedSpedizioni = sCliente.Select(s =>
                new
                   {
                       s.Id,
                       DataSpedizione = s.DataSpedizione.ToString("yyyy-MM-dd"),
                       s.Weight,
                       s.Destination,
                       s.Address,
                       s.Destinatario,
                       s.Price,
                       DataConsegna = s.DataConsegna.ToString("yyyy-MM-dd"),
                       s.IdCliente
                   }).ToList();

            return Json(formattedSpedizioni, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getTotSNonConsegnate()
        {
            TotSpedizioniNonConsegnate tot = DB.getTotSpedizioniNonConsegnate();
            return Json(tot, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getTotSpedizioniByCity()
        {
            List<TotXCitta> tot = DB.getAllSpedizioniGroupByCity();
            return Json(tot, JsonRequestBehavior.AllowGet);
        }

    }
}