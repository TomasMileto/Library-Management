using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria
{
    class CControladora
    {
        public static void Main()
        {
            CLibros listadoLibros = new CLibros();
            char opcion;
            ulong auxCodigo;
            do
            {
                char.TryParse(CInterfaz.DarOpcion().ToUpper(), out opcion);    //.ToUpper() Convierte la cadena a MAYÚSCULAS.

                switch (opcion)
                {
                    case 'E':   //Establecer el precio del Dolar
                        listadoLibros.SetDolar(Convert.ToSingle(CInterfaz.PedirDato("Precio del dolar (en $ARG)")));
                        break;
                    case 'C':   //Consultar precio Dolar
                        CInterfaz.MostrarInfo($"U$S {Convert.ToString(listadoLibros.GetDolar())}");
                        break;
                    case 'A':   //Añandir libro
                        
                        auxCodigo = Convert.ToUInt64(CInterfaz.PedirDato("Codigo"));
                        
                        if( listadoLibros.BuscarLibro(auxCodigo) != null)       //Verificar si el codigo es repetido
                        {
                            CInterfaz.MostrarInfo("ERROR: El codigo ingresado pertenece a otro libro");
                        }
                        else
                        {
                            string auxTitulo = CInterfaz.PedirDato("Titulo");
                            string auxAutor = CInterfaz.PedirDato("Autor");

                            CLibro auxLibro = listadoLibros.BuscarLibro(auxTitulo, auxAutor);

                            if (auxLibro != null)         //Verificar si el libro ya se encuentra la biblioteca
                            {
                                CInterfaz.MostrarInfo("Libro Preexistente: se autocontemplaran los datos restantes");
                                listadoLibros.CrearLibro(auxCodigo, auxLibro);
                            }
                            else
                            {
                                string auxGenero = CInterfaz.PedirDato("Genero");
                                string auxDescripcion = CInterfaz.PedirDato("Descripcion");
                                float auxPrecio = Convert.ToSingle(CInterfaz.PedirDato("Precio(U$S)"));

                                listadoLibros.CrearLibro(auxCodigo, auxTitulo, auxAutor, auxGenero, auxDescripcion, auxPrecio);
                            }

                        }

                        
                        break;

                    case 'M': //Mostrar
                        auxCodigo = Convert.ToUInt64(CInterfaz.PedirDato("Codigo"));
                        CInterfaz.MostrarInfo(listadoLibros.DarDatos(auxCodigo));
                        break;

                    case 'B': //Buscar libro por Titulo y Autor
                        string auxTitulo_search = CInterfaz.PedirDato("Titulo");
                        string auxAutor_search = CInterfaz.PedirDato("Autor");
                        CInterfaz.MostrarInfo("-Primera ocurrencia del libro especificado: \n"+
                           listadoLibros.DarDatos(auxTitulo_search, auxAutor_search));
                        break;

                    case 'L': //Listar todos los datos
                        listadoLibros.Ordenar();
                        CInterfaz.MostrarInfo(listadoLibros.DarDatos());
                        break;

                    case 'R': //Remover libro
                        auxCodigo = Convert.ToUInt64(CInterfaz.PedirDato("Codigo"));
                        if (!listadoLibros.EliminarLibro(auxCodigo))
                        {
                            CInterfaz.MostrarInfo("Libro Inexistente");
                        }
                        break;
                    

                    case 'S':   //Salir
                        break;

                    default:
                        CInterfaz.MostrarInfo("Opción inválida");
                        break;
                }
            } while (opcion != 'S');

            Console.WriteLine("Fin del programa");
            Console.Read();

        }   //fin del main
    }   //fin de clase
}
