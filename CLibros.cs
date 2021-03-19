using System;
using System.Collections;
using System.Collections.Generic;

namespace Libreria
{
    public class CLibros
    {
        //Variables Miembro
        private ArrayList listado;
        //Constructor
        public CLibros()
        {
            this.listado = new ArrayList();
        }
        
        //Funciones
        public CLibro BuscarLibro(ulong cod)
        {
            foreach (CLibro aux in this.listado)
            {
                if (aux.GetCodigo() == cod) return aux;
            }
            return null;
        }
        public CLibro BuscarLibro(string tit, string aut)       //primera ocurrencia de libro con dicho titulo y autor
        {
            foreach (CLibro aux in this.listado)
            {
                if ( aux.GetTitulo() == tit && aux.GetAutor() == aut) return aux;
            }
            return null;
        }
        public bool CrearLibro(ulong cod, string tit, string aut, string gen, string desc, float prec)
        {
            if (this.BuscarLibro(cod) == null)
            {
                this.listado.Add(new CLibro(cod, tit, aut, gen, desc,prec));
                return true;
            }
            return false;
        }
        public bool CrearLibro(ulong cod, CLibro _libro)        //Para libros repetidos
        {
            if ( this.BuscarLibro(cod) == null )
            {
                this.listado.Add(new CLibro(cod, _libro.GetTitulo(), _libro.GetAutor(),
                    _libro.GetGenero(), _libro.GetDescripcion(), _libro.GetPrecio()));
                return true;
            }

            
            return false;
        }
        public string DarDatos(ulong cod)
        {
            CLibro aux = this.BuscarLibro(cod);
            if (aux != null) return aux.DarDatos();
            return "Libro inexistente";
        }

        public string DarDatos(string tit, string aut)
        {
            CLibro aux = this.BuscarLibro(tit, aut);
            if (aux != null) return aux.DarDatos();
            return "Libro inexistente";
        }
        public string DarDatos()
        {
            if (this.listado.Count != 0)
            {
                String datos = "";
                foreach (CLibro aux in this.listado) datos += aux.DarDatos() + "\n";
                return datos;
            }
            return "No se registraron libros válidos";
        }
        public bool EliminarLibro(ulong cod)
        {
            CLibro aux = this.BuscarLibro(cod);
            if (aux != null)
            {
                this.listado.Remove(aux);
                return true;
            }
            return false;
        }
        public void SetDolar(float dol)
        {
            CLibro.SetDolar(dol);
        }
        public float GetDolar()
        {
            return CLibro.GetDolar();
        }
        public float DarPrecioPesos(ulong cod)
        {
            CLibro aux = this.BuscarLibro(cod);
            if (aux != null) return aux.DarPrecioPesos();
            return 0.0f;
        }
        public void Ordenar()
        {
            this.listado.Sort();
        }
    }
}

