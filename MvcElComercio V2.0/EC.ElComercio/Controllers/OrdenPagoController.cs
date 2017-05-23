using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using EC.ElComercio.Models;
using EC.MVC.Application;
using EC.MVC.Domain.Entities;
using Newtonsoft.Json.Linq;

namespace EC.ElComercio.Controllers
{
    public class OrdenPagoController : Controller
    {
        private readonly OrdenPagoAppService _ordenPagoAppService;
        private readonly MonedaAppService _monedaAppService;
        private readonly EstadoAppService _estadoAppService;
        private readonly SucursalAppService _sucursalAppService;

        public OrdenPagoController(OrdenPagoAppService ordenPagoAppService, MonedaAppService monedaAppService, EstadoAppService estadoAppService, SucursalAppService sucursalAppService)
        {
            _ordenPagoAppService = ordenPagoAppService;
            _monedaAppService = monedaAppService;
            _estadoAppService = estadoAppService;
            _sucursalAppService = sucursalAppService;

        }


        public JsonResult ListarOrdenesPago(int idSucursal, int idMoneda)
        {
            Moneda oMoneda = new Moneda() { Id = idMoneda };
            Sucursal oSucursal = new Sucursal() { Id = idSucursal };
            List<OrdenPago> loOrdenPago = _ordenPagoAppService.ListarPorMoneda(oMoneda, oSucursal); ;

            if (loOrdenPago.Count == 0)
            {
                return new JsonResult { Data = new { estado = "0", mensaje = "No se encontró información.", resultado = "" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else
            {
                return new JsonResult { Data = new { estado = "1", mensaje = "Información encontrada.", resultado = loOrdenPago }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }

        // GET: OrdenPago
        public ActionResult Index()
        {
            var ordenPagoModel = Mapper.Map<IEnumerable<OrdenPago>, IEnumerable<OrdenPagoModel>>(_ordenPagoAppService.ListarTodos());
            return View(ordenPagoModel);
        }

        // GET: OrdenPago/Details/5
        public ActionResult Details(int id)
        {
            var oOrdenPago = new OrdenPago { Id = id };
            oOrdenPago = _ordenPagoAppService.ListarPorId(oOrdenPago);
            OrdenPagoModel oOrdenPagoModel = Mapper.Map<OrdenPago, OrdenPagoModel>(oOrdenPago);
            return View(oOrdenPagoModel);
        }

        // GET: OrdenPago/Create
        public ActionResult Create()
        {
            ViewBag.Sucursales = new SelectList(_sucursalAppService.ListarTodos(), "Id", "Nombre");
            ViewBag.Monedas = new SelectList(_monedaAppService.ListarTodos(), "Id", "Nombre");
            ViewBag.Estados = new SelectList(_estadoAppService.ListarTodos(), "Id", "Nombre");
            return View();
        }

        // POST: OrdenPago/Create
        [HttpPost]
        public ActionResult Create(OrdenPago oOrdenPago)
        {
            try
            {
                _ordenPagoAppService.Agregar(oOrdenPago);
                return RedirectToAction("Index");
                // }
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdenPago/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Sucursales = new SelectList(_sucursalAppService.ListarTodos(), "Id", "Nombre");
            ViewBag.Monedas = new SelectList(_monedaAppService.ListarTodos(), "Id", "Nombre");
            ViewBag.Estados = new SelectList(_estadoAppService.ListarTodos(), "Id", "Nombre");

            var oOrdenPago = new OrdenPago { Id = id };
            oOrdenPago = _ordenPagoAppService.ListarPorId(oOrdenPago);
            OrdenPagoModel oOrdenPagoModel = Mapper.Map<OrdenPago, OrdenPagoModel>(oOrdenPago);
            return View(oOrdenPagoModel);
        }

        // POST: OrdenPago/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, OrdenPago oOrdenPago)
        {
            try
            {
                // TODO: Add update logic here
                _ordenPagoAppService.Actualizar(oOrdenPago);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdenPago/Delete/5
        public ActionResult Delete(int id)
        {
            var oOrdenPago = new OrdenPago { Id = id };
            _ordenPagoAppService.Eliminar(oOrdenPago);
            return RedirectToAction("Index");
        }

        //// POST: OrdenPago/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
