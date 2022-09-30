using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    internal interface IPessoaService
    {
        int Create(Pessoa pessoa);
        void Edit(Pessoa pessoa);
        void Delete(int idPessoa);
        Pessoa Get(int idPessoa);
        IEnumerable<Pessoa> GetAll();
    }
}
