using System;


class Manu
{
    static Banco banco = new Banco("RADS");
    static ContaBancaria contaAtual = null;

    static void Main(String[] args)
    {
        bool executando = true;

        while (executando)
        {
            Console.Clear();
            Console.WriteLine("===Menu Bancário===\n");
            Console.WriteLine("1. Criar nova conta");
            Console.WriteLine("2. Acessar conta existente");
            Console.WriteLine("3. Listar todas as contas");
            Console.WriteLine("4. Sair");
            Console.WriteLine("\n Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CriarConta();
                    break;
                case "2":
                    AcessarConta();
                    break;
                case "3":
                    banco.ListarContas();
                    break;
                case "4":
                    executando = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    static void CriarConta()
    {
        Console.Clear();
        Console.WriteLine("=== CRIAR NOVA CONTA ===");

        Console.Write("Tipo (1-Corrente / 2-Poupança):");
        string tipo = Console.ReadLine();

        Console.Write("Número da conta: ");
        string numeroDaConta = Console.ReadLine();

        Console.Write("Nome do titular: ");
        string titular = Console.ReadLine();

        Console.Write("Depósito inicial: ");
        decimal depositoInicial = decimal.Parse(Console.ReadLine());

        if (tipo == "1")
        {
            ContaBancaria novaConta = new ContaBancaria(numeroDaConta, titular, depositoInicial);
            banco.AdicionarConta(novaConta);
        }
        else if (tipo == "2")
        {
            Console.Write("Taxa de rendimento (% mensal): ");
            decimal taxa = decimal.Parse(Console.ReadLine());

            ContaPoupanca novaConta = new ContaPoupanca(numeroDaConta, titular, depositoInicial, taxa);
            banco.AdicionarConta(novaConta);
        }

        Pausar();
    }

    static void AcessarConta()
    {
        Console.Clear();
        Console.WriteLine("=== ACESSAR CONTA EXISTENTE ===");
        Console.Write("Digite o número da conta: ");
        string numeroDaConta = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(numeroDaConta))
        {
            Console.WriteLine("Número da conta inválido.");
            Pausar();
            return;
        }

        contaAtual = banco.BuscarConta(numeroDaConta);

        if (contaAtual != null)
        {
            MenuConta();
        }
        else
        {
            Console.WriteLine("Conta não encontrada");
            Pausar();
        }           
        
    }

    static void MenuConta()
    {
        bool voltar = false;

        while (voltar)
        {
            Console.Clear();
            Console.WriteLine($"=== CONTA DE {contaAtual.Titular.ToUpper()} ===");
            Console.WriteLine($"Saldo: {contaAtual.Saldo:C}");
            Console.WriteLine("\n1. Depositar");
            Console.WriteLine("2. Sacar");
            Console.WriteLine("3. Transferir");
            Console.WriteLine("4. Ver dados da conta");
            Console.WriteLine("5. Voltar ao menu principal");
            Console.Write("\nEscolha uma opção:");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Valor do depósito: ");
                    decimal valorDeposito = decimal.Parse(Console.ReadLine());
                    contaAtual.Depositar(valorDeposito);
                    Pausar();
                    break;
                case "2":
                    Console.Write("Valor do saque: ");
                    decimal valorSaque = decimal.Parse(Console.ReadLine());
                    contaAtual.Sacar(valorSaque);
                    Pausar();
                    break;
                case "3":
                    Console.Write("Número da conta destino: ");
                    string numeroDestino = Console.ReadLine();
                    ContaBancaria contaDestino = banco.BuscarConta(numeroDestino);
                    if (contaDestino != null)
                    {
                        Console.Write("Valor da transferência: ");
                        decimal valorTransferencia = decimal.Parse(Console.ReadLine());
                        contaAtual.Transferir(contaDestino, valorTransferencia);
                    }
                    else
                    {
                        Console.WriteLine("Conta destino não encontrada.");
                    }
                    Pausar();
                    break;
                case "4":
                    contaAtual.ExibirDadosDaConta();
                    Pausar();
                    break;
                case "5":
                    voltar = true;                    
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Pausar();
                    break;
            }
        }
    }

    static void Pausar()
    {
        Console.WriteLine("\nPressione Enter para continuar...");
        Console.ReadKey();
    }
}

