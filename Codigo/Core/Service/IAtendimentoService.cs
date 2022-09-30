using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    internal interface IAtendimentoService
    {

        int Create(Agendamento agendamento);
        void Edit(Agendamento agendamento);
        void Delete(Agendamento agendamento);
        Agendamento Get(int idAgendamento);
        IEnumerable<Agendamento> GetAll();

    }
}
