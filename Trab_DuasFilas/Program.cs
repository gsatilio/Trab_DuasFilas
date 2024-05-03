using Trab_DuasFilas;

internal class Program
{
    private static void Main(string[] args)
    {
        FilaNumero fila1 = new FilaNumero();
        FilaNumero fila2 = new FilaNumero();
        FilaNumero filaAux = new FilaNumero();
        FilaNumero fila_opc = new FilaNumero(); ;
        int aleatorio, opc, opcfila;

        aleatorio = new Random().Next(1, 20);
        for (int i = 0; i < aleatorio; i++)
        {
            fila1.push(geraNumero());
        }

        aleatorio = new Random().Next(1, 20);
        for (int i = 0; i < aleatorio; i++)
        {
            fila2.push(geraNumero());
        }

        do
        {
            Console.Clear();
            Console.WriteLine("1 - Verificar o tamanho das filas");
            Console.WriteLine("2 - Verificar maior, menor, média aritmética de uma fila");
            Console.WriteLine("3 - Transferir uma fila para outra auxiliar");
            Console.WriteLine("4 - Imprimir números pares/impares de uma fila");
            Console.WriteLine("0 - Sair do programa");
            opc = int.Parse(Console.ReadLine());

            switch (opc)
            {
                case 0:
                    Console.WriteLine("Até mais");
                    break;
                case 1:
                    compararFilas(fila1, fila2);
                    Console.WriteLine("Aperte qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 2:
                    do
                    {
                        Console.WriteLine("Digite 1 para a fila 1, 2 para a fila 2 ou 3 para a fila Auxiliar.");
                        opcfila = int.Parse(Console.ReadLine());
                    } while ((opcfila < 1) && (opcfila > 3));
                    switch (opcfila)
                    {
                        case 1:
                            fila_opc = fila1;
                            break;
                        case 2:
                            fila_opc = fila2;
                            break;
                        default:
                            fila_opc = filaAux;
                            break;
                    }
                    retornarNumeros(fila_opc, 2);
                    valoresFilas(fila_opc);
                    Console.WriteLine("Aperte qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 3:
                    do
                    {
                        Console.WriteLine("Digite:\n1 - para transferir da fila 1");
                        Console.WriteLine("2 - para transferir da fila 2");
                        opcfila = int.Parse(Console.ReadLine());
                    } while ((opcfila < 1) && (opcfila > 2));
                    switch (opcfila)
                    {
                        case 1:
                            filaAux = transferirfila(fila1);
                            break;
                        default:
                            filaAux = transferirfila(fila2);
                            break;
                    }
                    Console.WriteLine($"Todos os Números da fila {opcfila} Transferida:");
                    retornarNumeros(filaAux, 2);
                    Console.WriteLine("Aperte qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 4:
                    do
                    {
                        Console.WriteLine("Digite 1 para a fila 1, 2 para a fila 2 ou 3 para a fila Auxiliar");
                        opcfila = int.Parse(Console.ReadLine());
                    } while ((opcfila < 1) && (opcfila > 2));
                    switch (opcfila)
                    {
                        case 1:
                            fila_opc = fila1;
                            break;
                        case 2:
                            fila_opc = fila2;
                            break;
                        default:
                            fila_opc = filaAux;
                            break;
                    }
                    retornarNumeros(fila_opc, 0);
                    retornarNumeros(fila_opc, 1);
                    Console.WriteLine("Aperte qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    Console.WriteLine("Aperte qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        } while (opc != 0);
    }
    static void compararFilas(FilaNumero f1, FilaNumero f2)
    {
        int f1s, f2s;
        f1s = f1.getContador();
        f2s = f2.getContador();

        if (f1s == f2s)
        {
            Console.WriteLine($"As filas são de tamanhos iguais: {f1s}.");
        }
        else if (f1s > f2s)
        {
            Console.WriteLine($"A Fila 1 ({f1s}) é maior que a Fila 2 ({f2s})");
        }
        else
        {
            Console.WriteLine($"A Fila 2 ({f2s}) é maior que a Fila 1 ({f1s})");
        }
    }
    static void valoresFilas(FilaNumero fila)
    {
        float resultado = 0;
        resultado = fila.getValores(0);
        Console.WriteLine($"O menor valor da fila é: {resultado}");
        resultado = fila.getValores(1);
        Console.WriteLine($"O maior valor da fila é: {resultado}");
        resultado = fila.getValores(2);
        Console.WriteLine($"A média aritmética fila é: {resultado}");
    }
    static Numero geraNumero()
    {
        Numero numerotemp = new Numero(new Random().Next(1, 100));
        return numerotemp;
    }
    static void retornarNumeros(FilaNumero fila, int tipo)
    {
        switch (tipo)
        {
            case 0:
                Console.WriteLine("Números pares: " + fila.print(0));
                break;
            case 1:
                Console.WriteLine("Números ímpares: " + fila.print(1));
                break;
            case 2:
                Console.WriteLine(fila.print(2));
                break;
        }
    }
    static FilaNumero transferirfila(FilaNumero fila)
    {
        int tamanhofila = 0;

        Numero aux;
        FilaNumero tempFinal = new FilaNumero();

        Console.WriteLine("Todos os Números da fila original:");
        retornarNumeros(fila, 2);
        tamanhofila = fila.getContador(); // verifico o tamanho da fila que vou transferir 
        for (int i = 0; i < tamanhofila; i++)
        {
            aux = new Numero(fila.pop()); // faço um pop na fila e insiro numa fila auxiliar
            tempFinal.push(aux);
        }
        return tempFinal; // retorno a auxiliar final
    }
}