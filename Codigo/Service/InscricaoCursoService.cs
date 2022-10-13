using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal class InscricaoCursoService : IInscricaoCursoService
    {
        private readonly MaisMarinhaContext _context;

        public InscricaoCursoService(MaisMarinhaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Criar uma inscricao para um curso
        /// </summary>
        /// <param name="inscricaoCurso"></param>
        /// <returns></returns>
        public int Create(InscricaoCurso inscricaoCurso)
        {
            _context.Add(inscricaoCurso);
            _context.SaveChanges();
            return inscricaoCurso.Id;
        }

        /// <summary>
        /// Deletar uma inscricao Curso pelo id
        /// </summary>
        /// <param name="idInscricaoCurso"></param>
        public void Delete(int idInscricaoCurso)
        {
            var _inscricaoCurso = _context.Pessoas.Find(idInscricaoCurso);
            _context.Pessoas.Remove(_inscricaoCurso);
            _context.SaveChanges();
        }

        /// <summary>
        /// Editar as informações da inscricao Curso pelo id
        /// </summary>
        /// <param name="inscricaoCurso"></param>
        public void Edit(InscricaoCurso inscricaoCurso)
        {
            _context.Update(inscricaoCurso);
            _context.SaveChanges();
        }

        /// <summary>
        /// Ver informações da inscricao de Curso
        /// </summary>
        /// <param name="idInscricaoCurso"></param>
        /// <returns></returns>
        public InscricaoCurso Get(int idInscricaoCurso)
        {
            return _context.Inscricaocursos.Find(idInscricaoCurso);
        }

        /// <summary>
        /// Retorna todas inscricao de Curso
        /// </summary>
        /// <returns></returns>
        public IEnumerable<InscricaoCurso> GetAll()
        {
            return _context.Inscricaocursos.AsNoTracking();
        }
    }
}
