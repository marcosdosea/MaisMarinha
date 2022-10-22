using AutoMapper;
using Core;
using Core.Service;
using MaisMarinhaWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace MaisMarinhaWeb.Controllers
{
    public class InscricaoConcursoController : Controller
    {
        private readonly IInscricaoConcursoService _inscricaoConcursoService;
        private readonly IMapper _mapper;

        public InscricaoConcursoController(IInscricaoConcursoService inscricaoConcursoService, IMapper mapper)
        {
            _inscricaoConcursoService = inscricaoConcursoService;
            _mapper = mapper;
        }
        // GET: InscricaoConcursoController
        public ActionResult Index()
        {
            var listaInscricaoConcursos = _inscricaoConcursoService.GetAll();
            var listaInscricaoConcursosModel = _mapper.Map<List<InscricaoConcursoModel>>(listaInscricaoConcursos);
            return View(listaInscricaoConcursosModel);
        }

        // GET: InscricaoConcursoController/Details/5
        public ActionResult Details(int id)
        {
            Inscricaoconcurso inscricaoConcurso = _inscricaoConcursoService.Get(id);
            InscricaoConcursoModel inscricaoConcursoModel = _mapper.Map<InscricaoConcursoModel>(inscricaoConcurso);
            return View(inscricaoConcursoModel);
        }

        // GET: InscricaoConcursoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InscricaoConcursoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inscricaoconcurso inscricaoConcursoModel)
        {
            if (ModelState.IsValid)
            {
                var inscricaoConcurso = _mapper.Map<Inscricaoconcurso>(inscricaoConcursoModel);
                _inscricaoConcursoService.Create(inscricaoConcurso);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: InscricaoConcursoController/Edit/5
        public ActionResult Edit(int id)
        {
            Inscricaoconcurso inscricaoConcurso = _inscricaoConcursoService.Get(id);
            InscricaoConcursoModel inscricaoConcursoModel = _mapper.Map<InscricaoConcursoModel>(inscricaoConcurso);
            return View(inscricaoConcursoModel);
        }

        // POST: InscricaoConcursoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, InscricaoConcursoModel inscricaoConcursoModel)
        {
            if (ModelState.IsValid)
            {
                var inscricaoConcurso = _mapper.Map<Inscricaoconcurso>(inscricaoConcursoModel);
                _inscricaoConcursoService.Edit(inscricaoConcurso);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: InscricaoConcursoController/Delete/5
        public ActionResult Delete(int id)
        {
            Inscricaoconcurso inscricaoConcurso = _inscricaoConcursoService.Get(id);
            InscricaoConcursoModel inscricaoConcursoModel = _mapper.Map<InscricaoConcursoModel>(inscricaoConcurso);
            return View(inscricaoConcursoModel);
        }

        // POST: InscricaoConcursoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, InscricaoConcursoModel inscricaoConcursoModel)
        {
            _inscricaoConcursoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
