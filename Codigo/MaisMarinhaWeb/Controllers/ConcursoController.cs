using AutoMapper;
using Core;
using Core.Service;
using MaisMarinhaWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace MaisMarinhaWeb.Controllers
{
    public class ConcursoController : Controller
    {

        private readonly IConcursoService _concursoService;
        private readonly IMapper _mapper;

        public ConcursoController(IConcursoService concursoService, IMapper mapper)
        {
            _concursoService = concursoService;
            _mapper = mapper;
        }
        // GET: ConcursoController
        public ActionResult Index()
        {
            var listaConcurso = _concursoService.GetAll();
            var listaConcursoModel = _mapper.Map<List<ConcursoModel>>(listaConcurso);
            return View(listaConcursoModel);
        }

        // GET: ConcursoController/Details/5
        public ActionResult Details(int id)
        {
            Concurso concurso = _concursoService.Get(id);
            ConcursoModel concursoModel = _mapper.Map<ConcursoModel>(concurso);
            return View(concursoModel);
        }

        // GET: ConcursoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConcursoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConcursoModel concursoModel)
        {
            if (ModelState.IsValid)
            {
                var concurso = _mapper.Map<Concurso>(concursoModel);
                _concursoService.Create(concurso);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ConcursoController/Edit/5
        public ActionResult Edit(int id)
        {
            Concurso concurso = _concursoService.Get(id);
            ConcursoModel concursoModel = _mapper.Map<ConcursoModel>(concurso);
            return View(concursoModel);
        }

        // POST: ConcursoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ConcursoModel concursoModel)
        {
            if (ModelState.IsValid)
            {
                var concurso = _mapper.Map<Concurso>(concursoModel);
                _concursoService.Edit(concurso);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ConcursoController/Delete/5
        public ActionResult Delete(int id)
        {
            Concurso concurso = _concursoService.Get(id);
            ConcursoModel concursoModel = _mapper.Map<ConcursoModel>(concurso);
            return View(concursoModel);
        }

        // POST: ConcursoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ConcursoModel concursoModel)
        {
            _concursoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
