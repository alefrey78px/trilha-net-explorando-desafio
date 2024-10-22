namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            bool suiteComportaQuantidadeDeHospedes = hospedes.Count <= Suite.Capacidade;

            if (suiteComportaQuantidadeDeHospedes)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("A suíte não comporta tantos hospedes!");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            int quantidadeDeHospedes = Hospedes.Count;
            return quantidadeDeHospedes;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = DiasReservados * Suite.ValorDiaria;

            bool reservaParaDezDiasOuMais = DiasReservados >= 10;
            if (reservaParaDezDiasOuMais)
            {
                valor *= 0.9M;
            }

            return valor;
        }
    }
}