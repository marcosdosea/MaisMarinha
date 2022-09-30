using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    internal interface IInscricaoCursoService
    {
        int Create(Inscricaocurso inscricaocurso);
        void Edit(Inscricaocurso inscricaocurso);
        void Delete(int idInscricaocurso);
        Inscricaocurso Get(int idInscricaocurso);
        IEnumerable<Inscricaocurso> GetAll();
    }
}
