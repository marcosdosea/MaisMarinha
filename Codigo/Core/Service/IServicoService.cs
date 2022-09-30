using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    internal interface IServicoService
    {
        int Create(Servico servico);
        void Edit(Servico servico);
        void Delete(int idServico);
        Servico Get(int idServico);
        IEnumerable<Servico> GetAll();
    }
}
