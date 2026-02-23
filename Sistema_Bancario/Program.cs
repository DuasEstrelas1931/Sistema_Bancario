class Program
{ 
    static void Main(string[]args)
    {
        Console.WriteLine("=== Sintema Bancario RADS ===\n");
        // Criando o Banco
        Banco banco = new Banco("Digital RADS");

        //Criando Contas
        ContaBancaria conta1 = new ContaBancaria("001", "Ricardo Amor", 1000);
        ContaBancaria conta2 = new ContaBancaria("002", "Renata Souza", 500);
        ContaBancaria conta3 = new ContaBancaria("003", "Carlo Santos");

        // Adicionando contas o banco
        banco.AdicionarConta(conta1);
        banco.AdicionarConta(conta2);
        banco.AdicionarConta(conta3);

        Console.WriteLine("\n=== OPERAÇÕES ===");

    }
}
