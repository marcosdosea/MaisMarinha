using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    internal interface ICapitaniaService
    {

        int Create(Capitania capitania);
        void Edit(Capitania capitania);
        void Delete(int idCapitania);
        Capitania Get(int idCapitania);
        IEnumerable<Capitania> GetAll();

    }
}
