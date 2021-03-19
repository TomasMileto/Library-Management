using System;
namespace Libreria
{
    public class CInterfaz
    {
        static CInterfaz()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static string DarOpcion()
        {
            Console.Clear();
            Console.WriteLine("***********************************************");
            Console.WriteLine("*        Sistema de Gestión de Libros        *");
            Console.WriteLine("***********************************************");
            Console.WriteLine("\n[E] Establecer el precio Dolar actual.");
            Console.WriteLine("\n[C] Conocer el precio Dolar actual.");
            Console.WriteLine("\n[A] Agregar un Libro.");
            Console.WriteLine("\n[M] Mostrar datos de un Libro.");
            Console.WriteLine("\n[B] Buscar un Libro por Titulo y Autor.");
            Console.WriteLine("\n[L] Listar los datos de todos los Libros.");
            Console.WriteLine("\n[R] Remover un Libro.");
            Console.WriteLine("\n[S] Salir de la aplicación.");
            Console.WriteLine("\n**********************************************");
            return CInterfaz.PedirDato("opción elegida");
        }
        public static string PedirDato(string nombDato)
        {
            Console.Write("[?] Ingrese " + nombDato + ": ");
            string ingreso = Console.ReadLine();
            while (ingreso == "")
            {
                Console.Write("[!] " + nombDato + "es de ingreso OBLIGATORIO:");
                ingreso = Console.ReadLine();
            }
            Console.Clear();
            return ingreso.Trim();
            //.Trim() Remueve espacios en blanco previos y posteriores.

        }
        public static void MostrarInfo(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.Write("<Pulse Enter>");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
