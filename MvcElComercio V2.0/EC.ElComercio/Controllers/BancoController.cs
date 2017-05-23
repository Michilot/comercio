using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using EC.ElComercio.Models;
using EC.MVC.Application;
using EC.MVC.Domain.Entities;

namespace EC.ElComercio.Controllers
{
    public class BancoController : Controller
    {

        private readonly BancoAppService _bancoAppService;

        public BancoController(BancoAppService bancoAppService)
        {
            _bancoAppService = bancoAppService;
        }

        //
        // GET: /Banco/
        public ActionResult Index()
        {
            var bancoModel = Mapper.Map<IEnumerable<Banco>, IEnumerable<BancoModel>>(_bancoAppService.ListarTodos());
            return View(bancoModel);
        }

        //
        // GET: /Banco/Details/5 // DETALLE
        public ActionResult Details(int id)
        {
            var oBanco = new Banco { Id = id };
            oBanco = _bancoAppService.ListarPorId(oBanco);
            BancoModel oBancoModel = Mapper.Map<Banco, BancoModel>(oBanco);
            return View(oBancoModel);
        }

        //
        // GET: /Banco/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Banco/Create

        [HttpPost]
        public ActionResult Create(Banco oBanco)
        {
            try
            {
                string sMensaje = _bancoAppService.Validar(oBanco);

                if (sMensaje != string.Empty)
                {
                    ModelState.AddModelError("Nombre", sMensaje);
                    BancoModel oBancoModel = Mapper.Map<Banco, BancoModel>(oBanco);
                    return View(oBancoModel);
                }
                else
                {
                    _bancoAppService.Agregar(oBanco);
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Banco/Edit/5

        public ActionResult Edit(int id)
        {
            var oBanco = new Banco { Id = id };
            oBanco = _bancoAppService.ListarPorId(oBanco);
            BancoModel oBancoModel = Mapper.Map<Banco, BancoModel>(oBanco);
            return View(oBancoModel);
        }

        //
        // POST: /Banco/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Banco oBanco)
        {
            try
            {
                // TODO: Actualizar
                _bancoAppService.Actualizar(oBanco);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Banco/Delete/5 //ELIMINAR

        public ActionResult Delete(int id)
        {
            var oBanco = new Banco { Id = id };
            _bancoAppService.Eliminar(oBanco);
            return RedirectToAction("Index");
        }

        //
        // POST: /Banco/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Banco Banco)
        {
            try
            {
                Banco oBanco = new Banco();
                oBanco.Id = id;
                _bancoAppService.Eliminar(oBanco);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
