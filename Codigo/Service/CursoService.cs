using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CursoService : ICursoService
    {
        private readonly MaisMarinhaContext _context;

        public CursoService(MaisMarinhaContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Insere um novo curso na base de dados
        /// </summary>
        /// <param name="curso"></param>
        /// <returns></returns>
        public int Create(Curso curso)
        {
            _context.Add(curso);
            _context.SaveChanges();
            return curso.Id;
        }
        /// <summary>
        /// Remove um curso na base de dados
        /// </summary>
        /// <param name="idCurso"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Delete(int idCurso)
        {
            var _curso = _context.Cursos.Find(idCurso);
            _context.Cursos.Remove(_curso);
            _context.SaveChanges();
        }
        /// <summary>
        /// Edita os dados de um curso na base de dados
        /// </summary>
        /// <param name="curso"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Edit(Curso curso)
        {
            _context.Update(curso);
            _context.SaveChanges();
        }
        /// <summary>
        /// Busca um curso na base de dados
        /// </summary>
        /// <param name="idCurso"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Curso Get(int idCurso)
        {
            return _context.Cursos.Find(idCurso);
        }
        /// <summary>
        /// Retorna todos os cursos cadastrados na base de dados
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Curso> GetAll()
        {
            return _context.Cursos.AsNoTracking();
        }
    }
}
