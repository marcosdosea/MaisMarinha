using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    internal interface IInscricaoConcursoService
    {
        int Create(Inscricaoconcurso inscricaoconcurso);
        void Edit(Inscricaoconcurso inscricaoconcurso);
        void Delete(int idInscricaoconcurso);
        Inscricaoconcurso Get(int idInscricaoconcurso);
        IEnumerable<Inscricaoconcurso> GetAll();

    }
}
