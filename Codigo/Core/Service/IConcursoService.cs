using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IConcursoService
    {
        
        int Create(Concurso concurso);
        void Edit(Concurso concurso);
        void Delete(int idConcurso);
        Concurso Get(int idConcurso);
        IEnumerable<Concurso> GetAll();
        
    }
}
