using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Models
{
    public class Veiculo
    {

        public string Placa {  get; set; }

        public string Nome { get; set; }

        public string Modelo { get; set; }

        public string cor { get; set; }

        public Estacionado EstacionadoObj { get; set; }

        public bool isEstacionado { get; set; }

        public Veiculo(string placa, string nome, string modelo, string cor)
        {
            Placa = placa;
            Nome = nome;
            Modelo = modelo;
            this.cor = cor;
            EstacionadoObj = new Estacionado(placa, null, null);
            isEstacionado = false;
        }
    }
}
