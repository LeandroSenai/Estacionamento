using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Models
{
    public class Estacionado
    {
        public string Placa { get; set; }

        public DateTime? Entrada { get; set; }
        public DateTime? Saida { get; set; }
    


    public Estacionado(string placa, DateTime? entrada, DateTime? saida)
    {
        Placa = placa;
        Entrada = entrada;
        Saida = saida;
    }



        public double CalcularTotal()
        {
            TimeSpan tempoTotal = (Saida ?? DateTime.Now) - (Entrada ?? DateTime.Now);
            double minutosTotais = tempoTotal.Minutes;
            double valorTotal = minutosTotais * 2;
            return valorTotal;
        }

    }


}
