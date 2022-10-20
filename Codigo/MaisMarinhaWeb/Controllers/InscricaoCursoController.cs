using AutoMapper;
using Core;
using Core.Service;
using MaisMarinhaWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace MaisMarinhaWeb.Controllers
{
    public class InscricaoCursoController : Controller
    {
        private readonly IInscricaoCursoService _inscricaoCursoService;
        private readonly IMapper _mapper;

        public InscricaoCursoController(IInscricaoCursoService inscricaoCursoService, IMapper mapper)
        {
            _inscricaoCursoService = inscricaoCursoService;
            _mapper = mapper;
        }
        // GET: InscricaoCursoController
        public ActionResult Index()
        {
            var listaInscricaoCursos = _inscricaoCursoService.GetAll();
            var listaInscricaoCursosModel = _mapper.Map<List<InscricaoCursoModel>>(listaInscricaoCursos);
            return View(listaInscricaoCursosModel);
        }

        // GET: InscricaoCursoController/Details/5
        public ActionResult Details(int id)
        {
            InscricaoCurso inscricaoCurso = _inscricaoCursoService.Get(id);
            InscricaoCursoModel inscricaoCursoModel = _mapper.Map<InscricaoCursoModel>(inscricaoCurso);
            return View(inscricaoCursoModel);
        }

        // GET: InscricaoCursoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InscricaoCursoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InscricaoCurso inscricaoCursoModel)
        {
            if (ModelState.IsValid)
            {
                var inscricaoCurso = _mapper.Map<InscricaoCurso>(inscricaoCursoModel);
                _inscricaoCursoService.Create(inscricaoCurso);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: InscricaoCursoController/Edit/5
        public ActionResult Edit(int id)
        {
            InscricaoCurso inscricaoCurso = _inscricaoCursoService.Get(id);
            InscricaoCursoModel inscricaoCursoModel = _mapper.Map<InscricaoCursoModel>(inscricaoCurso);
            return View(inscricaoCursoModel);
        }

        // POST: InscricaoCursoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, InscricaoCursoModel inscricaoCursoModel)
        {
            if (ModelState.IsValid)
            {
                var inscricaoCurso = _mapper.Map<InscricaoCurso>(inscricaoCursoModel);
                _inscricaoCursoService.Edit(inscricaoCurso);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: InscricaoCursoController/Delete/5
        public ActionResult Delete(int id)
        {
            InscricaoCurso inscricaoCurso = _inscricaoCursoService.Get(id);
            InscricaoCursoModel inscricaoCursoModel = _mapper.Map<InscricaoCursoModel>(inscricaoCurso);
            return View(inscricaoCursoModel);
        }

        // POST: InscricaoCursoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, InscricaoCursoModel inscricaoCursoModel)
        {
            _inscricaoCursoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
