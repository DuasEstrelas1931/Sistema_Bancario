public class ContaBancaria
{
    //Propriedades
    public string NumeroConta { get; private set; }
    public string Titular { get; set; }
    public decimal Saldo { get; private set; }
    public DateTime DataAbertura { get; private set; }
    public bool Ativa { get; private set; }

    // Construtor
    public ContaBancaria(string numeroConta, string titular, decimal depositoInicial = 0)
    {
        NumeroConta = numeroConta;
        Titular = titular;
        Saldo = depositoInicial;
        DataAbertura = DateTime.Now;
        Ativa = true;

        Console.WriteLine($"Conta criada com sucesso pra {Titular}!\n");
    }

    public void Depositar(decimal valor)
    {
        if (!Ativa)
        {
            Console.WriteLine("Conta inativa. Operação não permitida.");
            return;
        }

        if (valor > 0)
        {
            Saldo += valor;
            Console.WriteLine($"Depósito de {valor:C} realizado com sucesso!");
            ExibirSaldo();
        }
        else
        {
            Console.WriteLine("Valor de depósito deve ser positivo.");
        }

    }

    public bool Sacar(decimal valor)
    {
        if (!Ativa)
        {
            Console.WriteLine("Conta inativa. Operçõ não permitida.");
            return false;
        }

        if (valor <= 0)
        {
            Console.WriteLine("Valor de saque inválido!");
            return false;
        }

        if (valor > Saldo)
        {
            Console.WriteLine("Saldo insuficiente para saque.");
            return false;
        }

        Saldo -= valor;
        Console.WriteLine($"Saque de {valor:C} realizado com sucesso!");
        ExibirSaldo();
        return true;
    }

    public void ExibirSaldo()
    {
        Console.WriteLine($"Saldo atual: {Saldo:C}");
    }
}
