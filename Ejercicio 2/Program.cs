using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejercicio_2
{
    internal class Program
    {
        static double promedio;
        static int i = 0, j=0;
        static double[] notas = new double[100];
        static int[] libreta = new int[100];
        static string[] nombre = new string[100];
        static double[] mayornotas = new double[100];
        static int[] mayorlibreta = new int[100];
        static string[] mayornombre = new string[100];
        static void Main(string[] args)
        {
            int opcion;
            string alumno;

            do
            {
                Console.Clear();
                Console.WriteLine($"Ingrese el nombre del alumno {i+1}  - - [0] Para terminar de cargar");
                alumno = Console.ReadLine();
                if (alumno != "0")
                {
                    Console.Clear();
                    Console.WriteLine($"Ahora ingrese el numero de libreta del alumno {i+1}");
                    int lib = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine($"Por ultimo ingrese la nota del alumno {i+1}");
                    int not = Convert.ToInt32(Console.ReadLine());
                    guardarnombre(alumno);
                    guardarlibreta(lib);
                    guardarnota(not);
                    i++;
                }
            } while (alumno != "0");

            if (alumno != "0")
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("1 - Calcular Promedio");
                    Console.WriteLine("2 - Alumnos Mayor Al Promedio");
                    Console.WriteLine("3 - Buscar Alumno");
                    Console.WriteLine("4 - Dentro De Lista Mayor Promedio (Alumno Mayor Promedio - Alumno Menor Promedio)");
                    Console.WriteLine("0 - Salir/Otros");
                    opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            {
                                Console.Clear();
                                CalcularPromedio();
                                Console.WriteLine($"El promedio de nota de los alumnos es de {promedio} ");
                            }
                            break;
                        case 2:
                            {
                                Console.Clear();
                                if (j == 0)
                                {
                                    CalcularPromedio();
                                    alumnosmayor();
                                    ordenamientoburbuja();
                                }

                                for (int l = j - 1; l > -1; l--)
                                {
                                    Console.WriteLine($"- Alumno: {mayornombre[l]}");
                                    Console.WriteLine($"- Numero Libreta: {mayorlibreta[l]}");
                                    Console.WriteLine($"- Nota: {mayornotas[l]}");
                                    Console.WriteLine("");
                                    Console.WriteLine("");
                                }

                            }
                            break;
                        case 3:
                            {
                                Console.Clear();
                                Console.WriteLine("Libreta del alumno que quiere buscar");
                                int lib = Convert.ToInt32(Console.ReadLine());
                                int posicion = buscaralumno(lib);
                                if (posicion != -1)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"- Alumno: {nombre[posicion]}");
                                    Console.WriteLine($"- Numero Libreta: {libreta[posicion]}");
                                    Console.WriteLine($"- Nota: {notas[posicion]}");
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("¡Alumno no encontrado!");
                                }

                            }
                            break;
                        case 4:
                            {
                                Console.Clear();
                                if (j == 0)
                                {
                                    CalcularPromedio();
                                    alumnosmayor();
                                    ordenamientoburbuja();
                                }
                                Console.WriteLine($"- Alumno: {mayornombre[j - 1]}");
                                Console.WriteLine($"- Numero Libreta: {mayorlibreta[j - 1]}");
                                Console.WriteLine($"- Nota: {mayornotas[j - 1]}");
                                Console.WriteLine("");
                                Console.WriteLine("------------------------------------------------------------");
                                Console.WriteLine($"- Alumno: {mayornombre[0]}");
                                Console.WriteLine($"- Numero Libreta: {mayorlibreta[0]}");
                                Console.WriteLine($"- Nota: {mayornotas[0]}");

                            }
                            break;
                    }
                    if (opcion != 0)
                    {
                        Console.ReadKey();
                    }
                } while (opcion != 0);
            }
        }

        static void guardarnombre(string alumno)
        {
            nombre[i] = alumno;
        }
        static void guardarlibreta(int nmrolibreta)
        {
            libreta[i] = nmrolibreta;
        }
        static void guardarnota(int nota)
        {
            notas[i] = nota;
        }

        static void CalcularPromedio()
        {
            double sum=0;
            for(int h=0; h<i; h++)
            {
                sum += notas[h];
            }

            promedio = sum / i - 1;

        }

        static void alumnosmayor()
        {
            for(int h=0; h<i; h++)
            {
                if (notas[h] > promedio)
                {
                    mayorlibreta[j] = libreta[h];
                    mayornombre[j] = nombre[h];
                    mayornotas[j] = notas[h];
                    j++;
                }
            }
        }

        static void ordenamientoburbuja()
        {
            for(int a=0; a<j-1; a++)
            { 
                for(int l=a+1; l<j; l++)
                {
                    if (mayornotas[a] > mayornotas[l])
                    {
                        double aux = mayornotas[l];
                        mayornotas[l] = mayornotas[a];
                        mayornotas[a] = aux;

                        string auxnom = mayornombre[l];
                        mayornombre[l] = mayornombre[a];
                        mayornombre[a] = auxnom;

                        int auxlib = mayorlibreta[l];
                        mayorlibreta[l] = mayorlibreta[a];
                        mayorlibreta[a] = auxlib;

                    }
                }
            }
        }

        
        static int buscaralumno(int nmrolibreta)
        {
            int posicion = -1;
            for(int l = 0; l<i; l++)
            {
                if (libreta[l] == nmrolibreta)
                {
                    posicion = l;
                }
            }

            return posicion;
        }

    }
}
