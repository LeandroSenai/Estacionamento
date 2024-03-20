using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Models
{
    public class Estacionamento
    {

          public string Id { get; set; }

        public string Name { get; set; }

        public List<Veiculo> Veiculos { get; set; }


        public Estacionamento(string id, string name)
        {
            Id = id;
            Name = name;
            Veiculos = new List<Veiculo>();
        }


    }
}
