using AutoMapper;
using Core;
using Core.Service;
using MaisMarinhaWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaisMarinhaWeb.Controllers
{
    public class CapitaniaController : Controller
    {

        private readonly ICapitaniaService _capitaniaService;
        private readonly IMapper _mapper;

        public CapitaniaController(ICapitaniaService capitaniaService, IMapper mapper)
        {
            _capitaniaService = capitaniaService;
            _mapper = mapper;
        }


        // GET: CapitaniaController
        public ActionResult Index()
        {
            var listaCapitania = _capitaniaService.GetAll();
            var listaCapitaniaModel = _mapper.Map<List<CapitaniaModel>>(listaCapitania);
            return View(listaCapitaniaModel);
        }

        // GET: CapitaniaController/Details/5
        public ActionResult Details(int id)
        {
            Capitania capitania = _capitaniaService.Get(id);
            CapitaniaModel capitaniaModel = _mapper.Map<CapitaniaModel>(capitania);
            return View(capitaniaModel);
        }

        // GET: CapitaniaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CapitaniaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CapitaniaModel capitaniaModel)
        {
            if (ModelState.IsValid)
            {
                var capitania = _mapper.Map<Capitania>(capitaniaModel);
                _capitaniaService.Create(capitania);
            }
            return RedirectToAction(nameof(Index));
        }


        // GET: CapitaniaController/Edit/5
        public ActionResult Edit(int id)
        {
            Capitania capitania = _capitaniaService.Get(id);
            CapitaniaModel capitaniaModel = _mapper.Map<CapitaniaModel>(capitania);
            return View(capitaniaModel);
        }

        // POST: CapitaniaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CapitaniaModel capitaniaModel)
        {
            if (ModelState.IsValid)
            {
                var capitania = _mapper.Map<Capitania>(capitaniaModel);
                _capitaniaService.Edit(capitania);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: CapitaniaController/Delete/5
        public ActionResult Delete(int id)
        {
            Capitania capitania = _capitaniaService.Get(id);
            CapitaniaModel capitaniaModel = _mapper.Map<CapitaniaModel>(capitania);
            return View(capitaniaModel);
        }

        // POST: CapitaniaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _capitaniaService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
