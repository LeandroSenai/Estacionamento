using Parking.Models;


var EstacionamentoLeandro = new Estacionamento("1", "Estacionamento do Leandro");


while (true)
{
    Thread.Sleep(2000);

    QuebrarLinha();

    Console.WriteLine("==================== ESTACIONAMENTO =================");
    QuebrarLinha();

    Console.WriteLine("1 - Cadastrar Veículo");
    Console.WriteLine("2 - Listar veículos");
    Console.WriteLine("3 - Entrada de veículo");
    Console.WriteLine("4 - Saída de veículo");
    Console.WriteLine("0 - Sair do sistema");
    Console.Write("Digite sua opção: ");
    int option = int.Parse(Console.ReadLine());
    QuebrarLinha();




    if (option == 0)
    {
        Console.WriteLine("Desligando programa...");
        Thread.Sleep(1000);
        Console.WriteLine("Desligando programa..");
        Thread.Sleep(1000);
        Console.WriteLine("Desligando programa.");
        Thread.Sleep(1000);
        Console.WriteLine("Bye");
        break;
    }



    switch(option)
    {
        case 1:
            Console.Clear();
            Console.WriteLine("------ Cadastrar Veículo -------");
            Console.Write("Informe a placa do veículo: ");
            string placa = Console.ReadLine().ToUpper();

            var veiculo1 = EstacionamentoLeandro.Veiculos.FirstOrDefault(x => x.Placa == placa);
            if (veiculo1 != null)
            {
                Console.WriteLine("Veículo já cadastrado.");
                continue;
            }

            Console.Write("Informe o nome do proprietario: ");
            string nome = Console.ReadLine();
            Console.Write("Informe o modelo do veículo(ex: Up): ");
            string modelo = Console.ReadLine();
            Console.Write("Informe a cor do veículo: ");
            string cor = Console.ReadLine();
            QuebrarLinha();

            if (cor == "" || placa == "" || nome == null || modelo == null)
            {
                break;
            }
            Console.WriteLine("Confirme os dados");
            Console.WriteLine("PLACA: " + placa);
            Console.WriteLine("NOME: " + nome);
            Console.WriteLine("MODELO: " + modelo);
            Console.WriteLine("COR: " + cor);
            QuebrarLinha();
            Console.Write("Confirmar(C) ou Recusar(R): ");
            char confirmar = Convert.ToChar(Console.ReadLine());
            QuebrarLinha();
            
            if (confirmar.ToString().ToUpper() != "C")

            {
                Console.WriteLine("Cadastrado cancelado.");

                continue;
            }
            var veiculoCadastrado = new Veiculo(placa, nome, modelo, cor);
            EstacionamentoLeandro.Veiculos.Add(veiculoCadastrado);
            Console.WriteLine("Veículo cadastrado com sucesso !");
            break;

        case 2:
            Console.Clear();

            Console.WriteLine("------ Listar Veículos -------");
            foreach(Veiculo car in EstacionamentoLeandro.Veiculos)
            {
                string status = car.isEstacionado ? "Estacionado" : "Não estacionado";
                Console.WriteLine($"Placa: [{car.Placa}] - Proprietário: {car.Nome} - {status}" );
            }

            break;

        case 3:
            Console.Clear();

            Console.WriteLine("------ Entrada de Veículo -------");
            Console.Write("Informe a placa do veículo: ");
            string placaS = Console.ReadLine().ToUpper();
            QuebrarLinha();

            var veiculo = EstacionamentoLeandro.Veiculos.FirstOrDefault(x => x.Placa == placaS);

            if (veiculo == null)
            {
                QuebrarLinha();
                Console.WriteLine("Veículo não encontrado.");
                continue;
            }
            var isParking = veiculo.isEstacionado;
       
            if (isParking)
            {
                QuebrarLinha();
                Console.WriteLine("Veículo já está estacionado.");
                continue;
            }

            veiculo.EstacionadoObj.Entrada = DateTime.Now;
            veiculo.isEstacionado = true;
            Console.WriteLine($"Veículo de placa : {veiculo.Placa}");
            Console.WriteLine($"Estacionado com sucesso em {veiculo.EstacionadoObj.Entrada}");
            break;

        case 4:
            Console.Clear();

            Console.WriteLine("------ Saída de Veículo -------");

            Console.Write("Informe a placa do veículo: ");
            string placaR = Console.ReadLine().ToUpper();

            var veiculoR = EstacionamentoLeandro.Veiculos.FirstOrDefault(x => x.Placa == placaR);
            if (veiculoR == null)
            {
                Console.WriteLine("Veículo não encontrado.");
                continue;
            }

            var isParkingR = veiculoR.isEstacionado;

         
            if (!isParkingR)
            {
                Console.WriteLine("Veículo não está estacionado.");
                continue;
            }

            veiculoR.EstacionadoObj.Saida = DateTime.Now;
            double total = veiculoR.EstacionadoObj.CalcularTotal();
            Console.WriteLine($"Placa: {veiculoR.Placa}");
            Console.WriteLine($"Entrada: {veiculoR.EstacionadoObj.Entrada}");
            Console.WriteLine($"Saída: {veiculoR.EstacionadoObj.Saida}");
            Console.WriteLine($"Tempo(m) total: {total / 2}"); 
            Console.WriteLine($"Valor total: R${total}");

            veiculoR.EstacionadoObj.Saida = null;
            veiculoR.EstacionadoObj.Saida = null;
            veiculoR.isEstacionado = false;

            Console.WriteLine("Clique qualquer letra para continuar !");
            Console.ReadKey(intercept: true);


            break;
    }


}



static void QuebrarLinha()
{
     Console.WriteLine();
}