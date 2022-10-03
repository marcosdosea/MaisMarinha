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
    public class DadosClimaService : IDadosClimaService
    {
        private readonly MaisMarinhaContext _context;

        public DadosClimaService(MaisMarinhaContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Insere um novo clima na base de dados
        /// </summary>
        /// <param name="clima"></param>
        /// <returns></returns>
        public int Create(Clima clima)
        {

            _context.Add(clima);
            _context.SaveChanges();
            return clima.Id;
        }
        /// <summary>
        /// Remove um clima na base de dados
        /// </summary>
        /// <param name="idClima"></param>
        public void Delete(int idClima)
        {
            var _clima = _context.Climas.Find(idClima);
            _context.Climas.Remove(_clima);
            _context.SaveChanges();
        }
        /// <summary>
        /// Edita os dados de um clima na base de dados
        /// </summary>
        /// <param name="clima"></param>
        public void Edit(Clima clima)
        {
            _context.Update(clima);
            _context.SaveChanges();
        }
        /// <summary>
        /// Busca um clima na base de dados
        /// </summary>
        /// <param name="idClima"></param>
        /// <returns></returns>
        public Clima Get(int idClima)
        {
            return _context.Climas.Find(idClima);
        }
        /// <summary>
        /// Retorna todos os climas cadastrados na base de dados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Clima> GetAll()
        {
            return _context.Climas.AsNoTracking();
        }
    }
}
