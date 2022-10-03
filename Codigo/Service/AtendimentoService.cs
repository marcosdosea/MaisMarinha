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
    public class AtendimentoService : IAtendimentoService
    {
        private readonly MaisMarinhaContext _context;

        public AtendimentoService(MaisMarinhaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Insere um agendamento na base de dados
        /// </summary>
        /// <param name="agendamento">Dados do Agendamento</param>
        /// <returns>Id do Agendamento</returns>
        /// <exception cref="NotImplementedException"></exception>
        public int Create(Agendamento agendamento)
        {
            _context.Add(agendamento);
            _context.SaveChanges();
            return agendamento.Id;
        }
        /// <summary>
        /// Remove um agendamento na base de dados
        /// </summary>
        /// <param name="idAgendamento"></param>
        public void Delete(int idAgendamento)
        {
            var _agendamento = _context.Agendamentos.Find(idAgendamento);
            _context.Remove(_agendamento);
            _context.SaveChanges();            
        }
        /// <summary>
        /// Edita um agendamento na base de dados
        /// </summary>
        /// <param name="agendamento"></param>
        public void Edit(Agendamento agendamento)
        {
            _context.Update(agendamento);
            _context.SaveChanges();
        }
        /// <summary>
        /// Busca um agendamento na base de dados
        /// </summary>
        /// <param name="idAgendamento"></param>
        /// <returns></returns>
        public Agendamento Get(int idAgendamento)
        {
            return _context.Agendamentos.Find(idAgendamento);
        }
        /// <summary>
        /// Retorna todos agendamentos cadastrados na base de dados
        /// </summary>
        /// <param name="idAgendamento"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Agendamento> GetAll()
        {
            return _context.Agendamentos.AsNoTracking();
        }
    }
}
