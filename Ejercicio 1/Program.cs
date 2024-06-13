using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_1
{
    internal class Program
    {
        static bool esono = false;
        static int res;
        static int i = 0;
        static int[] vector1 = new int[100];
        static bool bandera;
        static void Main(string[] args)
        {
            int opcion, num;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Guardar numeros");
                Console.WriteLine("2 - Ordenar lista");
                Console.WriteLine("3 - Metodo Secuencial");
                Console.WriteLine("4 - Metodo Binario");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        {
                            {

                                do
                                {
                                    Console.Clear();
                                    Console.WriteLine("Ingrese el numero que quiere guardar o [0] para volver");
                                    num = Convert.ToInt32(Console.ReadLine());
                                    if (num != 0)
                                    {
                                        guardarnumeros(num);
                                    }
                                } while (num != 0);
                            }
                        }
                        break;
                    case 2:
                        {
                            Console.Clear();
                            MetodoBurbuja();
                            Console.WriteLine("¡Lista Ordenada con exito!");
                        }
                        break;
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("Ingrese el numero que quiere buscar");
                            num = Convert.ToInt32(Console.ReadLine());
                            busquedasecuencial(num);
                            Console.Clear();
                            if (esono)
                            {
                                Console.WriteLine($"El numero buscado se encuentra en la posicion {res+1} de la lista");
                            }
                            else
                            {
                                Console.WriteLine("No se encontro el numero buscado en la lista");
                            }
                        }
                        break;
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("Ingrese el numero que quiere buscar");
                            num = Convert.ToInt32(Console.ReadLine());
                            int buscado = metodobinario(num);
                            if (bandera)
                            {
                                Console.WriteLine($"El numero buscado se encuentra en la posicion {buscado + 1} de la lista");
                            }
                            else
                            {
                                Console.WriteLine("No se encontro el numero buscado en la lista");
                            }
                        }
                        break;
                }
                Console.ReadKey();
            } while (opcion != 0);


        }

        static void guardarnumeros(int num)
        {

            vector1[i] = num;

            i++;
        }

        static void MetodoBurbuja()
        {
            for (int a = 0; a < i - 1; a++)
            {
                for (int n = a + 1; n < i; n++)
                {
                    if (vector1[a] > vector1[n])
                    {
                        int aux = vector1[n];
                        vector1[n] = vector1[a];
                        vector1[a] = aux;
                    }
                }
            }

        }

        #region con metodo secuencia con for
        static void busquedasecuencial(int num)
        {
            esono = false;
            for (int h = 0; h < i; h++)
            {
                if (vector1[h] == num)
                {
                    esono = true;
                    res = h;
                }
            }

        }
        #endregion fin con metodo secuencial for

        static int metodobinario(int num)
        {
            int izq = 0, medio , der, pos = -1;
            bandera = false;
            der = i - 1;
            do
            {
                medio = (izq + der) / 2;
                if (vector1[medio] == num)
                {
                    bandera = true;
                }
                else if (vector1[medio] < num)
                {
                    izq = medio + 1;
                }
                else
                {
                    der = medio - 1;
                }
            }while(( izq <= der) && (!bandera));

            if (bandera)
            {
                pos = medio;
            }
            return pos;
        }


    }
}
