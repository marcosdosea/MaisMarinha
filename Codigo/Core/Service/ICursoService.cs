using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface ICursoService
    {

        int Create(Curso curso);
        void Edit(Curso curso);
        void Delete(int idCurso);
        Curso Get(int idCurso);
        IEnumerable<Curso> GetAll();

    }
}
