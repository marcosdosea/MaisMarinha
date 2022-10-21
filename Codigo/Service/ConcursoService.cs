using Core;
using Core.DTO;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ConcursoService : IConcursoService
    {
        private readonly MaisMarinhaContext _context;

        public ConcursoService(MaisMarinhaContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Insere um novo concurso na base de dados
        /// </summary>
        /// <param name="concurso"></param>
        /// <returns></returns>
        public int Create(Concurso concurso)
        {
            _context.Add(concurso);
            _context.SaveChanges();
            return concurso.Id;
        }
        /// <summary>
        /// Remove um concurso na base de dados
        /// </summary>
        /// <param name="idConcurso"></param>
        public void Delete(int idConcurso)
        {
            var _concurso = _context.Concursos.Find(idConcurso);
            _context.Concursos.Remove(_concurso);
            _context.SaveChanges();
        }
        /// <summary>
        /// Edita os dados de um concurso na base de dados
        /// </summary>
        /// <param name="concurso"></param>
        public void Edit(Concurso concurso)
        {
            _context.Update(concurso);
            _context.SaveChanges();
        }
        /// <summary>
        /// Busca um concurso na base de dados
        /// </summary>
        /// <param name="idConcurso"></param>
        /// <returns></returns>
        public Concurso Get(int idConcurso)
        {
            return _context.Concursos.Find(idConcurso);
        }
        /// <summary>
        /// Retorna todos os concursos cadastrados na base de dados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Concurso> GetAll()
        {
            return _context.Concursos.AsNoTracking();
        }

        public IEnumerable<ConcursoDTO> GetByNome(string nome)
        {
            var query = from concurso in _context.Concursos
                        where concurso.Nome.StartsWith(nome)
                        orderby concurso.Nome
                        select new ConcursoDTO
                        {
                            Id = concurso.Id,
                            Nome = concurso.Nome,
                            DataInicialInscricao = concurso.DataInicialInscricao,
                            DataFinalInscricao = concurso.DataFinalInscricao,
                            DataProva = concurso.DataProva,
                            Escolaridade = concurso.Escolaridade
                        };
            return query;
        }
    }
}
