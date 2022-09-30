using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IAtendimentoService
    {

        int Create(Agendamento agendamento);
        void Edit(Agendamento agendamento);
        void Delete(int idAgendamento);
        Agendamento Get(int idAgendamento);
        IEnumerable<Agendamento> GetAll();

    }
}
