using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    internal interface IConcursoService
    {

        int Create(Concurso concurso);
        void Edit(Concurso concurso);
        void Delete(Concurso concurso);
        Concurso Get(Concurso concurso);
        IEnumerable<Concurso> GetAll();
        
    }
}
