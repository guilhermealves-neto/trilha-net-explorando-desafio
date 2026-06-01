namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; } = new List<Pessoa>();
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }
        public decimal ValorDesconto { get; set; }
        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            // *IMPLEMENTE AQUI*
            int quantidadeHospedes = hospedes.Count;
            int capacidadeSuite = Suite.Capacidade;

            if (quantidadeHospedes <=  capacidadeSuite)
            {
                Hospedes.AddRange(hospedes);
            }
            else
            {
                throw new Exception("Quantidade de hospedes é maior do que a capacidade da suite.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
           
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
           
            decimal valorDaDiaria = (DiasReservados * Suite.ValorDiaria);
            decimal valorDaDiariaComDesconto = 0;
            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
         
            if (DiasReservados>=10 )
            {
                valorDaDiariaComDesconto = valorDaDiaria * 0.90M;
                ValorDesconto = valorDaDiaria - valorDaDiariaComDesconto;
                valorDaDiaria = valorDaDiariaComDesconto;
                
            }

            return valorDaDiaria;
        }
    }
}