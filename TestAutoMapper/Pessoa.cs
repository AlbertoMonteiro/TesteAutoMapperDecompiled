namespace TestAutoMapper
{
    class Pessoa
    {
        public string PrimeiroNome { get; set; }
        public string SegundoNome { get; set; }
        public string NomeCompleto { get { return PrimeiroNome + " " + SegundoNome; } }
    }
}