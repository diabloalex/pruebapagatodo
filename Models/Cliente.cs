using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string DNI { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public int IdEstado { get; set; }
    }
}
