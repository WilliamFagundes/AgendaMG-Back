using AgendaMG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaMG.Service
{
    public interface IPessoaService
    {
        List<Pessoa> GetPessoas();
        Pessoa GetPessoa(int id);
        void AddPessoa(Pessoa item);
        void UpdatePessoa(Pessoa item);
        void DeletePessoa(int id);
        bool PessoaExists(int id);
    }
}
