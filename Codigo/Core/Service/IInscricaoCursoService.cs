using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IInscricaoCursoService
    {
        int Create(InscricaoCurso inscricaoCurso);
        void Edit(InscricaoCurso inscricaoCurso);
        void Delete(int idInscricaoCurso);
        InscricaoCurso Get(int idInscricaoCurso);
        IEnumerable<InscricaoCurso> GetAll();
    }
}
