namespace ultima_prueba
{
    public class Transaccion
    {
        public int Id { get; set; }
        public string numeroCuenta { get; set; }
        public string Tipo { get; set; }
        public decimal Monto { get; set; }
        public decimal SaldoDespues { get; set; }
    }
}
