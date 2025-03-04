namespace PruebaTecnica.ValueObjects
{
    public class ClientesResponse
    {
        public int IdCuenta { get; set; }
        public int IdCliente { get; set; }
        public decimal NumeroCuenta { get; set; }
        public decimal Saldo { get; set; }
        public string TipoCuenta { get; set; }
        public string EstadoCuenta { get; set; }
    }
}
