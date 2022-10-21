using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class InscricaoconcursoService
    {
        private readonly MaisMarinhaContext _context;

        public InscricaoconcursoService(MaisMarinhaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Criar uma inscricao para um Concurso
        /// </summary>
        /// <param name="Inscricaoconcurso"></param>
        /// <returns></returns>
        public int Create(Inscricaoconcurso Inscricaoconcurso)
        {
            _context.Add(Inscricaoconcurso);
            _context.SaveChanges();
            return Inscricaoconcurso.Id;
        }

        /// <summary>
        /// Deletar uma inscricao Concurso pelo id
        /// </summary>
        /// <param name="idInscricaoconcurso"></param>
        public void Delete(int idInscricaoconcurso)
        {
            var _Inscricaoconcurso = _context.Inscricaoconcursos.Find(idInscricaoconcurso);
            _context.Inscricaoconcursos.Remove(_Inscricaoconcurso);
            _context.SaveChanges();
        }

        /// <summary>
        /// Editar as informações da inscricao Concurso pelo id
        /// </summary>
        /// <param name="Inscricaoconcurso"></param>
        public void Edit(Inscricaoconcurso Inscricaoconcurso)
        {
            _context.Update(Inscricaoconcurso);
            _context.SaveChanges();
        }

        /// <summary>
        /// Ver informações da inscricao de Concurso
        /// </summary>
        /// <param name="idInscricaoconcurso"></param>
        /// <returns></returns>
        public Inscricaoconcurso Get(int idInscricaoconcurso)
        {
            return _context.Inscricaoconcursos.Find(idInscricaoconcurso);
        }

        /// <summary>
        /// Retorna todas inscricao de Concurso
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Inscricaoconcurso> GetAll()
        {
            return _context.Inscricaoconcursos.AsNoTracking();
        }
    }
}
