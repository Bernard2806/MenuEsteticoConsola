using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuEsteticoConsola
{
    internal class Program
    {
        // Opciones para testing
        private static string[] OptionMenu = new string[] {
            "Esto es una prueba",
            "De un menu de mierda",
            "En proceso de creacion",
            "Apartentemente no funciona"
        };

        // Posicion del Cursor en la Consola
        private static int x;
        private static int y;

        static void Main(string[] args)
        {
            MostrarMenu(OptionMenu);
        }

        static void MostrarMenu(string[] Opciones) {
            bool loop = true;
            int counter = 0;
            ConsoleKeyInfo Tecla;

            Console.CursorVisible = false; // Con esto hacemos que el cursor no se muestre en consola

            

            while (loop) {
                Console.Clear();
                x = Console.CursorLeft;
                y = Console.CursorTop;

                string Resultado = LogicaMenu(Opciones, counter);
                while ((Tecla = Console.ReadKey(true)).Key != ConsoleKey.Enter) { 
                    switch (Tecla.Key){
                        case ConsoleKey.DownArrow:
                            if (counter == Opciones.Length - 1) break;
                            counter++;
                            break;
                        case ConsoleKey.UpArrow:
                            if (counter == 0) break;
                            counter--;
                            break;
                        default:
                            break;
                    }
                    Resultado = LogicaMenu(Opciones, counter);
                }
            }
        }

        private static string LogicaMenu(string[] items, int opcion) {
            Console.Clear();
            Console.WriteLine("Seleccione una opción del menu:" + System.Environment.NewLine);
            string SeleccionActual = string.Empty;
            int Destacado = 0;

            Array.ForEach(items, element =>
            {
                if (Destacado == opcion)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(" > " + element + " < ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    SeleccionActual = element;
                }
                else {
                    Console.WriteLine(element);
                }
                Destacado++;
            });

            return SeleccionActual;
        }
    }
}
