using System;

class Program
{
    static void Main()
    {
        string[] nomes = new string[100];
        string[] cpfs = new string[100];
        string[] senhas = new string[100];
        double[] saldos = new double[100];
        int totalUsuarios = 0;
        int usuarioLogado = -1;
        int opcao = 0;

        while (true)
        {
            if (usuarioLogado == -1)
            {
                Console.WriteLine("=== SISTEMA BANCÁRIO ===");
                Console.WriteLine("1 - Cadastrar usuário");
                Console.WriteLine("2 - Login");
                Console.WriteLine("3 - Sair");
                Console.Write("Escolha: ");
                opcao = int.Parse(Console.ReadLine());

                if (opcao == 1)
                {
                    Console.Write("Nome: ");
                    nomes[totalUsuarios] = Console.ReadLine();

                    Console.Write("CPF: ");
                    cpfs[totalUsuarios] = Console.ReadLine();

                    Console.Write("Senha: ");
                    senhas[totalUsuarios] = Console.ReadLine();

                    Console.Write("Saldo inicial: ");
                    saldos[totalUsuarios] = double.Parse(Console.ReadLine());

                    totalUsuarios++;
                    Console.WriteLine("Usuário cadastrado com sucesso!");
                    Console.WriteLine();
                }
                else if (opcao == 2)
                {
                    Console.Write("CPF: ");
                    string cpfLogin = Console.ReadLine();

                    Console.Write("Senha: ");
                    string senhaLogin = Console.ReadLine();

                    bool achou = false;

                    for (int i = 0; i < totalUsuarios; i++)
                    {
                        if (cpfs[i] == cpfLogin && senhas[i] == senhaLogin)
                        {
                            usuarioLogado = i;
                            achou = true;
                            break;
                        }
                    }

                    if (achou)
                    {
                        Console.WriteLine("Login feito perfeitamente!");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("CPF ou senha errados!");
                        Console.WriteLine();
                    }
                }
                else if (opcao == 3)
                {
                    Console.WriteLine("Saindo do sistema...");
                    break;
                }
                else
                {
                    Console.WriteLine("Opção inválida!");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("=== MENU DA CONTA ===");
                Console.WriteLine("1 - Ver saldo");
                Console.WriteLine("2 - Depositar");
                Console.WriteLine("3 - Sacar");
                Console.WriteLine("4 - Transferir");
                Console.WriteLine("5 - Logout");
                Console.Write("Escolha: ");
                opcao = int.Parse(Console.ReadLine());

                if (opcao == 1)
                {
                    Console.WriteLine("Seu saldo é:     " + saldos[usuarioLogado]);
                    Console.WriteLine();
                }
                else if (opcao == 2)
                {
                    Console.Write("Valor para depósito: ");
                    double valor = double.Parse(Console.ReadLine());
                    saldos[usuarioLogado] += valor;
                    Console.WriteLine("Depósito realizado!");
                    Console.WriteLine();
                }
                else if (opcao == 3)
                {
                    Console.Write("Valor para saque: ");
                    double valor = double.Parse(Console.ReadLine());

                    if (valor <= saldos[usuarioLogado])
                    {
                        saldos[usuarioLogado] -= valor;
                        Console.WriteLine("Saque realizado!");
                    }
                    else
                    {
                        Console.WriteLine("Saldo insuficiente!");
                    }
                    Console.WriteLine();
                }
                else if (opcao == 4)
                {
                    Console.Write("CPF do destinatário: ");
                    string cpfDestino = Console.ReadLine();
                    int indiceDestino = -1;

                    for (int i = 0; i < totalUsuarios; i++)
                    {
                        if (cpfs[i] == cpfDestino)
                        {
                            indiceDestino = i;
                            break;
                        }
                    }

                    if (indiceDestino == -1)
                    {
                        Console.WriteLine("Usuário não encontrado!");
                    }
                    else
                    {
                        Console.Write("Valor da transferência: ");
                        double valor = double.Parse(Console.ReadLine());

                        if (valor <= saldos[usuarioLogado])
                        {
                            saldos[usuarioLogado] -= valor;
                            saldos[indiceDestino] += valor;
                            Console.WriteLine("Transferência feita com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Saldo insuficiente!");
                        }
                    }
                    Console.WriteLine();
                }
                else if (opcao == 5)
                {
                    usuarioLogado = -1;
                    Console.WriteLine("Logout feito com sucesso!");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Opção inválida!");
                    Console.WriteLine();
                }
            }
        }
    }
}






