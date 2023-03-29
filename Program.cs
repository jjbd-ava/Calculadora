using System;

namespace Calculadora
{
    class Program
    {
        static void Main(string[] args)
        {
            string modo;
            do
            {
                Console.WriteLine("Seleccione el modo de la calculadora:\n1 - Modo manual\n2 - Modo automático\n0 - Salir");
                modo = Console.ReadLine();
            } while (modo != "0" && modo != "1" && modo != "2");

            switch (modo)
            {
                case "1":
                    Manual();
                    break;
                case "2":
                    Automatico();
                    break;
                case "0":
                    break;
            }

                
        } 

        public static void Suma(double num1, double num2)
        {
            Console.WriteLine($"La suma de {num1} y {num2} es {num1 + num2}.");
        }

        public static void Resta(double num1, double num2)
        {
            Console.WriteLine($"La resta de {num1} y {num2} es {num1 - num2}.");
        }

        public static void Division(double num1, double num2)
        {
            Console.WriteLine($"La división de {num1} y {num2} es {num1 / num2}.");
        }

        public static void Multiplicacion(double num1, double num2)
        {
            Console.WriteLine($"La multiplicación de {num1} y {num2} es {num1 * num2}.");
        }

        public static void Potencia(double num1, double num2)
        {
            num2 = Math.Truncate(num2);
            double resultado = 1;
            double potencia;
            if (num2 < 0)
            {
                potencia = num2 * -1;
            }
            else potencia = num2;
            for (int i = 0; i < potencia; i++)
            {
                resultado *= num1;
            }
            if (num2 < 0)
            {
                resultado = 1 / resultado;
            }
            Console.WriteLine($"{num1} elevado a {num2} es {resultado}.");
        }

        public static void Calculadora(double num1, double num2, char operacion)
        {
            switch (operacion)
            {
                case '+':
                    Suma(num1, num2);
                    break;
                case '-':
                    Resta(num1, num2);
                    break;
                case '/':
                    Division(num1, num2);
                    break;
                case '*':
                    Multiplicacion(num1, num2);
                    break;
                case '^':
                    Potencia(num1, num2);
                    break;
                default:
                    Console.WriteLine("Tipo de operación introducida no válido.");
                    break;
            }
        }

        public static void Manual()
        {
            Boolean seguir = true;
            do
            {
                Console.WriteLine("¿Qué operación quieres hacer? (+, -, /, *, ^)");
                char operacion = Console.ReadLine()[0];
                double num1;
                double num2;

                Console.WriteLine("Introduce el primer operando:");
                while (!double.TryParse(Console.ReadLine(), out num1))
                {
                    Console.WriteLine("Introduce un valor válido para el primer operando");
                }
                Console.WriteLine("Introduce el segundo operando:");
                while (!double.TryParse(Console.ReadLine(), out num2))
                {
                    Console.WriteLine("Introduce un valor válido para el segundo operando");
                }
                Calculadora(num1, num2, operacion);
                Console.WriteLine("Si desea realizar otra operación, introduzca Y\nCualquier otra tecla para salir del modo manual.");
                if (Console.ReadLine().ToUpper() != "Y") seguir = false;
            } while (seguir);
        }

        public static void Automatico()
        {
            Boolean seguir = true;
            do
            {
                Console.WriteLine("Introduzca la operación deseada:");
                string cadenaOperacion = Console.ReadLine();
                char[] operacionesValidas = {'+', '-', '/', '*', '^'};
                char operacion = '_';
                int posicion = 0;
                if (cadenaOperacion.IndexOfAny(operacionesValidas) != -1)
                {
                    posicion = cadenaOperacion.IndexOfAny(operacionesValidas);
                    operacion = cadenaOperacion[posicion];
                    string parte1 = cadenaOperacion.Substring(0, posicion);
                    string parte2 = cadenaOperacion.Substring(posicion + 1);
                    double num1;
                    double num2;
                    if(double.TryParse(parte1, out num1))
                    {
                        num1 = Double.Parse(parte1);
                    }
                    else Console.WriteLine("El primer operando no es válido.");
                    if (double.TryParse(parte2, out num2))
                    {
                        num2 = Double.Parse(parte2);
                    }
                    else Console.WriteLine("El segundo operando no es válido.");
                    if (double.TryParse(parte1, out num1) && double.TryParse(parte2, out num2))
                    {
                        Calculadora(num1, num2, operacion);
                    }
                    else Console.WriteLine("No se ha podido realizar la operación.");
                }
                else Console.WriteLine("La cadena introducida no contiene ningún operador válido");

                Console.WriteLine("Si desea realizar otra operación, introduzca Y\nCualquier otra tecla para salir del modo automático.");
                if (Console.ReadLine().ToUpper() != "Y") seguir = false;
            } while (seguir);
        }
    }
}