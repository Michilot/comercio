using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using AutoMapper;
using EC.ElComercio.App_Start;
using EC.ElComercio.Models;
using EC.MVC.Application;
using EC.MVC.Domain.Entities;

namespace EC.ElComercio.Controllers
{
    public class SucursalController : Controller
    {

        private readonly SucursalAppService _sucursalAppService;
        private readonly BancoAppService _bancoAppService;

        public SucursalController(SucursalAppService sucursalAppService, BancoAppService bancoAppService)
        {
            _sucursalAppService = sucursalAppService;
            _bancoAppService = bancoAppService;
        }

        // GET: Sucursal
        public ActionResult Index()
        {
            var sucursalModel = Mapper.Map<IEnumerable<Sucursal>, IEnumerable<SucursalModel>>(_sucursalAppService.ListarTodos());
            return View(sucursalModel);
        }


        [HttpGet]
        public IEnumerable<SucursalModel> ListarSucursalxBanco(int id)
        {
            //List<Sucursal> loSucursal = new List<Sucursal>();
            Banco oBanco = new Banco() { Id = id };
            var sucursalModel = Mapper.Map<IEnumerable<Sucursal>, IEnumerable<SucursalModel>>(_sucursalAppService.ListarxBanco(oBanco));
            return sucursalModel;

            //return new HttpResponseMessage
            //{
            //    Content = new StringContent(xml, Encoding.UTF8, "application/xml")
            //};

            //return new HttpResponseMessage()
            //{
            //    RequestMessage = Request,
            //    Content = new XmlContent(loSucursal.ToXmlDocument())
            //};


        }

        // GET: Sucursal/Details/5
        public ActionResult Details(int id)
        {
            var oSucursal = new Sucursal() { Id = id };
            oSucursal = _sucursalAppService.ListarPorId(oSucursal);
            SucursalModel oSucursalModel = Mapper.Map<Sucursal, SucursalModel>(oSucursal);
            return View(oSucursalModel);
        }

        // GET: Sucursal/Create
        public ActionResult Create()
        {
            ViewBag.Bancos = new SelectList(_bancoAppService.ListarTodos(), "Id", "Nombre");
            return View();
        }

        // POST: Sucursal/Create
        [HttpPost]
        public ActionResult Create(Sucursal oSucursal)
        {
            try
            {
                _sucursalAppService.Agregar(oSucursal);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        // GET: Sucursal/Edit/5
        public ActionResult Edit(int id)
        {

            ViewBag.Bancos = new SelectList(_bancoAppService.ListarTodos(), "Id", "Nombre");
            var oSucursal = new Sucursal { Id = id };
            oSucursal = _sucursalAppService.ListarPorId(oSucursal);
            SucursalModel oSucursalModel = Mapper.Map<Sucursal, SucursalModel>(oSucursal);
            return View(oSucursalModel);
        }

        // POST: Sucursal/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Sucursal sucursal)
        {
            try
            {
                _sucursalAppService.Actualizar(sucursal);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sucursal/Delete/5
        public ActionResult Delete(int id)
        {
            var oSucursal = new Sucursal { Id = id };
            _sucursalAppService.Eliminar(oSucursal);
            return RedirectToAction("Index");
        }

        // POST: Sucursal/Delete/5
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
    }
}
