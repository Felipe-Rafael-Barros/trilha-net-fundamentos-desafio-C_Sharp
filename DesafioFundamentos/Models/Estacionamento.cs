namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // Sistema que adicionar o veiculo caso não exista nenhum veiculo com a mesma placa no estacionamento
            Console.WriteLine("Digite a placa do veículo para estacionar:");

            string Placa = Console.ReadLine(); // Coleta a entrada do usuário

            if (veiculos.Contains(Placa)) // Avalia se existe um veículo com a mesma placa no estacionamento
            {
                Console.WriteLine($"O veículo com placa {Placa} já está estacionado no sistema.");
            }
            else
            {
                veiculos.Add($"{Placa}");
                Console.WriteLine($"Carro com placa: {Placa}, foi adicionar ao sistema no horário {DateTime.Now}  "); // Coleta a entrada do usuário
            }

        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");


            string placa = Console.ReadLine(); // Pede ao usuário a placa do veículo

            
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper())) // Verifica se o veículo existe
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = int.Parse(Console.ReadLine());  // Verifica o tempo em horas que o veículo passou no estacionamento
                decimal valorTotal = precoInicial + precoPorHora*horas;  // Calcula o valor final
                

                veiculos.Remove(veiculos.FirstOrDefault(x => x.Equals(placa, StringComparison.OrdinalIgnoreCase))); //Remove o veículo da lista( sistema usado para não fazer distinção de letra maiúsculas o minúsculas)

                Console.WriteLine($"O veículo {placa} foi removido às {DateTime.Now} com custo de: R$ {valorTotal}");

            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Por Ordem de chegada temos os seguintes veículos estacionados: ");

                
                int ContadorAuxiliar = 0;
                foreach (string placa in veiculos)  //Loop que mostra todos os veículos caso exista por ordem de "chegada".
                {
                    Console.WriteLine($"{ContadorAuxiliar+1}º = {placa}");
                    ContadorAuxiliar++;
                }
            }
            else
            {
                Console.WriteLine("No momento não há veículos estacionados.");
            }
        }
    }
}
