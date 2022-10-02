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
    public class PessoaService : IPessoaService
    {
        private readonly MaisMarinhaContext _context;

        public PessoaService (MaisMarinhaContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Insere uma nova pessoa na base de dados
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        public int Create(Pessoa pessoa)
        {
            _context.Add(pessoa);
            _context.SaveChanges();
            return pessoa.Id;
        }

        /// <summary>
        /// Remove uma pessoa na base de dados
        /// </summary>
        /// <param name="idPessoa"></param>
        public void Delete(int idPessoa)
        {
            var _pessoa = _context.Pessoas.Find(idPessoa);
            _context.Pessoas.Remove(_pessoa);
            _context.SaveChanges();
        }

        /// <summary>
        /// Edita os dados de uma pessoa na base de dados
        /// </summary>
        /// <param name="pessoa"></param>
        public void Edit(Pessoa pessoa)
        {
            _context.Update(pessoa);
            _context.SaveChanges();
        }

        /// <summary>
        /// Busca uma pessoa cadastrada na base de dados
        /// </summary>
        /// <param name="idPessoa"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Pessoa Get(int idPessoa)
        {
            return _context.Pessoas.Find(idPessoa);
        }

        /// <summary>
        /// Retorna todas pessoas cadastradas na base de dados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Pessoa> GetAll()
        {
            return _context.Pessoas.AsNoTracking();
        }
    }
}
