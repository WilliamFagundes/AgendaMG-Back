using AgendaMG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaMG.Service
{
    public class PessoaService : IPessoaService
    {
        private readonly List<Pessoa> pessoas;

        public PessoaService()
        {
            this.pessoas = new List<Pessoa>
            {
                new Pessoa
                        {
                            IdPessoa = 1,
                            Nome = "William Thiago Fagundes Santos",
                            Telefone = "(11) 96160-2617",
                            Email = "wtfspunck@hotmail.com"
                        },

                new Pessoa
                {
                    IdPessoa = 2,
                    Nome = "Taciana Oliveira Firmo Fagundes",
                    Telefone = "(11) 96160-2617",
                    Email = "tacifirmo@hotmail.com"
                }

            };
            
        }

        public void AddPessoa(Pessoa item)
        {
            this.pessoas.Add(item);
        }

        public void DeletePessoa(int id)
        {
            var model = this.pessoas.Where(m => m.IdPessoa == id).FirstOrDefault();
            this.pessoas.Remove(model);
        }

        public bool PessoaExists(int id)
        {
            return this.pessoas.Any(m => m.IdPessoa == id);
        }

        public Pessoa GetPessoa(int id)
        {
            return this.pessoas.Where(m => m.IdPessoa == id).FirstOrDefault();
        }

        public List<Pessoa> GetPessoas()
        {
            return this.pessoas.ToList();
        }

        public void UpdatePessoa(Pessoa item)
        {
            var model = this.pessoas.Where(m => m.IdPessoa == item.IdPessoa).FirstOrDefault();

            model.Nome = item.Nome;
            model.Telefone = item.Telefone;
            model.Email = item.Email;
        }
    }

}
