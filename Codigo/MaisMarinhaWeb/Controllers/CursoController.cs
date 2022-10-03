using AutoMapper;
using Core;
using Core.Service;
using MaisMarinhaWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaisMarinhaWeb.Controllers
{
    public class CursoController : Controller
    {
        private readonly ICursoService _cursoService;
        private readonly IMapper _mapper;

        public CursoController (ICursoService cursoService, IMapper mapper)
        {
            _cursoService = cursoService;
            _mapper = mapper;
        }

        // GET: CursoController
        public ActionResult Index()
        {
            var listaCursos = _cursoService.GetAll();
            var listaCursosModel = _mapper.Map<List<CursoModel>>(listaCursos);
            return View(listaCursosModel);
        }

        // GET: CursoController/Details/5
        public ActionResult Details(int id)
        {
            Curso curso = _cursoService.Get(id);
            CursoModel cursoModel = _mapper.Map<CursoModel>(curso);
            return View(cursoModel);
        }

        // GET: CursoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CursoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CursoModel cursoModel)
        {
            if (ModelState.IsValid)
            {
                var curso = _mapper.Map<Curso>(cursoModel);
                _cursoService.Create(curso);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: CursoController/Edit/5
        public ActionResult Edit(int id)
        {
            Curso curso = _cursoService.Get(id);
            CursoModel cursoModel = _mapper.Map<CursoModel>(curso);
            return View(cursoModel);
        }

        // POST: CursoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CursoModel cursoModel)
        {
            if (ModelState.IsValid)
            {
                var curso = _mapper.Map<Curso>(cursoModel);
                _cursoService.Edit(curso);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: CursoController/Delete/5
        public ActionResult Delete(int id)
        {
            Curso curso = _cursoService.Get(id);
            CursoModel cursoModel = _mapper.Map<CursoModel>(curso);
            return View(cursoModel);
        }

        // POST: CursoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _cursoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
