using AgendaMG.Model;
using AgendaMG.Service;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaMG.Business
{
    public class PessoaBusiness
    {
        private readonly IPessoaService _service;
        public PessoaBusiness(IPessoaService service)
        {
            _service = service;
        }

        public List<Pessoa> GetListPessoas()
        {

            var listaPessoas = _service.GetPessoas();


            return listaPessoas;
        }

        public List<Pessoa> AddPessoa(JObject jsonPessoa)
        {
            string sNome = jsonPessoa["nome"].ToString();
            string sTelefone = jsonPessoa["telefone"].ToString();
            string sEmail = jsonPessoa["email"].ToString();

            var listaPessoas = _service.GetPessoas();

            var ultimoId = listaPessoas.OrderByDescending(o => o.IdPessoa).FirstOrDefault();
            var objPessoa = new Pessoa
            {
                IdPessoa = ultimoId.IdPessoa + 1,
                Nome = sNome,
                Telefone = sTelefone,
                Email = sEmail

            };

            _service.AddPessoa(objPessoa);

            return _service.GetPessoas();

        }

        public List<Pessoa> UpdatePessoa(JObject jsonPessoa)
        {
            int iIdPessoa = Convert.ToInt32(jsonPessoa["idPessoa"].ToString());
            string sNome = jsonPessoa["nome"].ToString();
            string sTelefone = jsonPessoa["telefone"].ToString();
            string sEmail = jsonPessoa["email"].ToString();

            var objPessoa = new Pessoa
            {
                IdPessoa = iIdPessoa,
                Nome = sNome,
                Telefone = sTelefone,
                Email = sEmail

            };

            _service.UpdatePessoa(objPessoa);

            return _service.GetPessoas();

        }
        public List<Pessoa> DeletePessoa(int id)
        {

            _service.DeletePessoa(id);

            return _service.GetPessoas();
        }
    }
}
