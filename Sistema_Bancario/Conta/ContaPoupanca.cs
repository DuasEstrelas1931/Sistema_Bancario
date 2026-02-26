using System;
public class ContaPoupanca : ContaBancaria
{
    public decimal TaxaDeRendimento { get; set; }

    public ContaPoupanca(string numeroDaConta, string titular, decimal depositoInicial = 0, decimal taxaDeRendimento = 0.05m)
        : base(numeroDaConta, titular, depositoInicial)
    {
        TaxaDeRendimento = taxaDeRendimento;
        Console.WriteLine($"Conta poupança criada com taxa de rendimento de {taxaDeRendimento:P} ao mês");
    }

    public void AplicarRendimento()
    {
        if (Saldo > 0)
        {
            decimal rendimento = Saldo * TaxaDeRendimento;
            Depositar(rendimento);
            Console.WriteLine($"Rendimento de {rendimento:C} aplicado à conta poupança de {Titular}");

        }
        else
        {
            Console.WriteLine("Saldo insuficiente para aplicar rendimento.");
        }
    }

    public override string ToString()
    {
        return $"Conta Poupança - Número: {NumeroConta} | Titular: {Titular} | Saldo: {Saldo:C} | Taxa de Rendimento: {TaxaDeRendimento:P}";
    }
    
}
