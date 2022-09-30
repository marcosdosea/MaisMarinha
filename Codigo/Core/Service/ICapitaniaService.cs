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
        void Delete(Capitania capitania);
        Capitania Get(Capitania capitania);
        IEnumerable<Capitania> GetAll();

    }
}
