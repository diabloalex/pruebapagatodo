using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Modelos
{
    public class Cuenta
    {
        public int IdCuenta { get; set; }

        public int IdCliente { get; set; }

        public string NumeroCuenta { get; set; }

        public decimal Saldo { get; set; }

        public string TipoCuenta { get; set; }

        public string EstadoCuenta { get; set; } 
    }
}
