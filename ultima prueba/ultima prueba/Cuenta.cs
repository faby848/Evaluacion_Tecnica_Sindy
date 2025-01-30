namespace ultima_prueba
{
    public class Cuenta
    {
        public string numeroCuenta { get; set; }
        public decimal saldo { get; set; }
        public List<Transaccion> transacciones { get; set; } = new List<Transaccion>(); 
    }
}
