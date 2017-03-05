using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mercadorias.Models
{
    public class Mercadoria
    {
        private long idMercadoria;
        private string tipoMercadoria;
        private string nomeMercadoria;
        private string tipoNegocio;
        private int quantidade;
        private string preco;


        public long IdMercadoria
        {
            get
            {
                return idMercadoria;
            }

            set
            {
                idMercadoria = value;
            }
        }

        public string TipoMercadoria
        {
            get
            {
                return tipoMercadoria;
            }

            set
            {
                tipoMercadoria = value;
            }
        }

        public string NomeMercadoria
        {
            get
            {
                return nomeMercadoria;
            }

            set
            {
                nomeMercadoria = value;
            }
        }

        public string TipoNegocio
        {
            get
            {
                return tipoNegocio;
            }

            set
            {
                tipoNegocio = value;
            }
        }

        public int Quantidade
        {
            get
            {
                return quantidade;
            }

            set
            {
                quantidade = value;
            }
        }

        public string Preco
        {
            get
            {
                return preco;
            }

            set
            {
                preco = value;
            }
        }
    }
}