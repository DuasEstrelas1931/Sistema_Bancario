using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Sintema Bancario RADS ===\n");
        // Criando o Banco
        Banco banco = new Banco("Digital RADS");

        //Criando Contas
        ContaBancaria conta1 = new ContaBancaria("001", "Ricardo Amor", 1000);
        ContaPoupanca conta2 = new ContaPoupanca("002", "Renata Souza", 500, 0.005m);
        ContaBancaria conta3 = new ContaBancaria("003", "Carlo Santos");

        // Adicionando contas o banco
        banco.AdicionarConta(conta1);
        banco.AdicionarConta(conta2);
        banco.AdicionarConta(conta3);

        Console.WriteLine("\n=== OPERAÇÕES ===");

        //Operação na conta 1
        Console.WriteLine($"\n===Operação na conta de {conta1.Titular} ===");
        conta1.Depositar(500);
        conta1.Sacar(200);
        conta1.ExibirDadosDaConta();

        //Operação na conta 2 (poupança)
        Console.WriteLine($"\n===Operação na conta de {conta2.Titular} ===");
        conta2.AplicarRendimento();
        conta2.ExibirDadosDaConta();
      




    }

}
