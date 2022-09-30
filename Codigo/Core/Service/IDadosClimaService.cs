using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    internal interface IDadosClimaService
    {
        int Create(Clima clima);
        void Edit(Clima clima);
        void Delete(int idClima);
        Clima Get(int idClima);
        IEnumerable<Clima> GetAll();
    }
}
