
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Collections.Generic;
using EC.ElComercio.Models;
using EC.MVC.Application;
using EC.MVC.Domain.Entities;
using System.Text;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json.Linq;


namespace EC.ElComercio.Controllers
{
    public class WSController : ApiController
    {

        private readonly OrdenPagoAppService _ordenPagoAppService;
        private readonly SucursalAppService _sucursalAppService;

        public WSController(OrdenPagoAppService ordenPagoAppService, SucursalAppService sucursalAppService)
        {
            _ordenPagoAppService = ordenPagoAppService;
            _sucursalAppService = sucursalAppService;
        }

        [System.Web.Http.HttpGet]
        public JsonResult ListarOrdenesPago(int idSucursal, int idMoneda)
        {
            Moneda oMoneda = new Moneda() { Id = idMoneda };
            Sucursal oSucursal = new Sucursal() { Id = idSucursal };
            List<OrdenPago> result = _ordenPagoAppService.ListarPorMoneda(oMoneda, oSucursal); ;

            if (result.Count == 0)
            {
                return new JsonResult
                {
                    Data = new { estado = "0", mensaje = "Información encontrada.", resultado = "" },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    ContentType = "application/json"
                };
            }
            else
            {
                return new JsonResult
                {
                    Data = new { estado = "1", mensaje = "Información encontrada.", resultado = result },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    ContentType = "application/json"
                };
            }
        }

    }









}