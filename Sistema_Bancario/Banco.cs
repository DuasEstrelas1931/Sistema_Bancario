// Gerenciador
class Banco
    {
    private List<ContaBancaria> contas;

    public string Nome { get; set; }
    public Banco(string nome)
    {
        Nome = nome;
        contas = new List<ContaBancaria>();
        Console.WriteLine($"Banco {nome} criado com sucesso!");
    }

    public void AdicionarConta(ContaBancaria conta)
    {
        contas.Add(conta);
        Console.WriteLine($"Conta de {conta.Titular} adicionada ao banco {Nome}");
    }

    public ContaBancaria BuscarConta(string numeroDaConta)
    {
        foreach (var conta in contas)
        {
            if (conta.NumeroConta == numeroDaConta)
                return conta;                                
          
        }
        return null;
    }

    public void ListarContas()
    {
        Console.WriteLine($"\n=== Contas do Banco {Nome} ===");
        if (contas.Count == 0) {
            Console.WriteLine("Nenhuma conta cadastrada.");
            return;
        }
        foreach (var conta in contas)
        {
            Console.WriteLine($"Número: {conta.NumeroConta} | Titular: {conta.Titular} | Saldo: {conta.Saldo:C}");
        }
    }

    public decimal CalcularPatrimonial()
    {
        decimal total = 0;
        foreach (var conta in contas)
        {
            total += conta.Saldo;
        }
        return total;
    }

}

