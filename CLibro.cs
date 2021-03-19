using System;

namespace Libreria
{
    public class CLibro: IComparable
    {
        //Variables miembro de instancia
        private ulong codigo;
        private string titulo;
        private string autor;
        private string genero;
        private string descripcion;
        private float precio;
        //Variables miembro de clase
        private static float dolar;
        //Metodos miembro de instancia
        //Constructores
        //Por defecto
        public CLibro()
        {
            this.codigo = 0;
            this.genero = "sin asignar";
            this.titulo = "sin asignar";
            this.descripcion = "sin asignar";
            this.precio = 0.0F;
        }
        //Parametrizados
        public CLibro(ulong cod)
        {
            this.codigo = cod;
        }
       
        public CLibro(ulong cod, string tit, string aut, string gen, string desc, float prec)
        {
            this.codigo = cod;
            this.titulo = tit;
            this.autor = aut;
            this.genero = gen;
            this.descripcion = desc;
            this.precio = prec;
        }
        //Setters de instancia
        public void SetCodigo(ulong cod)
        { this.codigo = cod; }
        
        public void SetTitulo(string tit)
        { this.titulo = tit; }
        public void SetAutor(string aut)
        { this.autor = aut; }
        public void SetGenero(string gen)
        { this.genero = gen; }
        public void SetDescripcion(string desc)
        { this.descripcion = desc; }
        public void SetPrecio(float prec)
        { this.precio = prec; }

        //Getters de instancia
        public ulong GetCodigo()
        { return this.codigo; }
        
        public string GetTitulo()
        { return this.titulo; }
        public string GetAutor()
        { return this.autor; }
        public string GetGenero()
        { return this.genero; }
        public string GetDescripcion()
        { return this.descripcion; }
        public float GetPrecio()
        { return this.precio; }

        public string DarDatos()
        {
            string ret = $"[{this.codigo.ToString()}]";
            ret += ": " + this.titulo +", "+ this.autor;
            ret+=  ". Genero: " + this.genero;
            ret += ". Precio del libro en dolares: U$S " + this.precio.ToString();
            ret += ". Precio del dolar hoy: $" + CLibro.dolar.ToString();
            ret += ". Precio del libro en pesos: $ " + this.DarPrecioPesos().ToString();
            ret += "\nDescripcion: " + this.descripcion;
            return ret;
        }
        public float DarPrecioPesos()
        {
            return CLibro.dolar * this.precio;
        }
        //Finalizadores
        //Por defecto
        ~CLibro()
        {
        }
        //Alternativa invocable
        public void Dispose()
        {
            //Tarea a realizar al momento de la invocacion
            System.GC.SuppressFinalize(this); //No ejecutar el finalizador por defecto
        }

        //Metodos miembro de clase
        //Setter de dolar
        public static void SetDolar(float dol)
        { CLibro.dolar = dol; }
        //Getter de dolar
        public static float GetDolar()
        { return CLibro.dolar; }
        
        //CompareTo de IComparable
        public int CompareTo(object obj)
        {
            if (obj is CLibro)
            {
                return (int)(this.codigo - ((CLibro)obj).GetCodigo());
            }
            return int.MaxValue;
        }
       
    } //Fin de la clase
} //Cierra del espacio de nombre Libreria
