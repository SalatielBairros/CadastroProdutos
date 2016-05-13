using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadastroProdutos.Models
{
    public class FiltroProduto
    {
        public FiltroProduto()
        {
            Nome = Tipo = string.Empty;
        }

        public FiltroProduto(string nome, string tipo)
        {
            Nome = nome;
            Tipo = tipo;
        }

        private static FiltroProduto _instancia;
        public static FiltroProduto Instancia
        {
            get
            {
                
                return _instancia ?? (_instancia = new FiltroProduto());
            }
        }

        public string Nome { get; set; }
        public string Tipo { get; set; }
    }
}