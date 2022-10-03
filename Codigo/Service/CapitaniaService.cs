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
    public class CapitaniaService : ICapitaniaService
    {
        private readonly MaisMarinhaContext _context;
        /// <summary>
        /// Insere uma nova capitania na base de dados
        /// </summary>
        /// <param name="capitania"></param>
        /// <returns></returns>
        public int Create(Capitania capitania)
        {
            _context.Add(capitania);
            _context.SaveChanges();
            return capitania.Id;
        }
        /// <summary>
        /// Remove uma capitania na base de dados
        /// </summary>
        /// <param name="idCapitania"></param>
        public void Delete(int idCapitania)
        {
            var _capitania = _context.Capitania.Find(idCapitania);
            _context.Capitania.Remove(_capitania);
            _context.SaveChanges();
        }
        /// <summary>
        /// Edita os dados de uma capitania na base de dados
        /// </summary>
        /// <param name="capitania"></param>
        public void Edit(Capitania capitania)
        {
            _context.Update(capitania);
            _context.SaveChanges();
        }
        /// <summary>
        /// Busca uma capitania na base de dados
        /// </summary>
        /// <param name="idCapitania"></param>
        /// <returns></returns>
        public Capitania Get(int idCapitania)
        {
            return _context.Capitania.Find(idCapitania);
        }
        /// <summary>
        /// Retorna todos os climas cadastrados na base de dados
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Capitania> GetAll()
        {
            return _context.Capitania.AsNoTracking();
        }
    }
}
