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



    
}

