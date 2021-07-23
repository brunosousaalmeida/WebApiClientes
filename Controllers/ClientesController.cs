using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiClientes.Models;

namespace WebApiClientes.Controllers
{
    public class ClientesController : ApiController
    {
        private static List<Cliente> clientes = new List<Cliente>();

        [HttpPost]
        public void InserirCliente(string nome)
        {
            if (!string.IsNullOrEmpty(nome))
            {
                clientes.Add(new Cliente(nome));
            }
        }

        [HttpGet]
        public List<Cliente> ObterClientes()
        {
            return clientes;
        }

        [HttpPut]
        public void AtualizarCliente(string nome, string novoNome)
        {
            if (clientes.Any(x => x.Nome == nome))
            {
                var item = clientes.FirstOrDefault(c => c.Nome == nome);
                item.Nome = novoNome;
            }
        }

        public void Delete(string nome)
        {
            clientes.RemoveAt(clientes.IndexOf(clientes.First(x => x.Nome.Equals(nome))));
        }

       
    }
}
