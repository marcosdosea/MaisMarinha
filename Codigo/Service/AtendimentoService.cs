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
        /// CRIA UM NOVO AGENDAMENTO
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
        /// REMOVER AGENDAMENTO
        /// </summary>
        /// <param name="idAgendamento"></param>
        public void Delete(int idAgendamento)
        {
            var _agendamento = _context.Agendamentos.Find(idAgendamento);
            _context.Remove(_agendamento);
            _context.SaveChanges();            
        }
        /// <summary>
        /// EDITANDO AGENDAMENTO
        /// </summary>
        /// <param name="agendamento"></param>
        public void Edit(Agendamento agendamento)
        {
            _context.Update(agendamento);
            _context.SaveChanges();
        }
        public Agendamento Get(int idAgendamento)
        {
            return _context.Agendamentos.Find(idAgendamento);
        }
        /// <summary>
        /// BUSCAR AGENDAMENTO
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
