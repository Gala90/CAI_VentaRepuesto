using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion.VentaRepuesto.Entidades
{
    public class Repuesto
    {
        private int _codigo;
        private string _nombre;
        private double _precio;
        private int _stock;
        private Categoria _categoria;

        public int Codigo { get => _codigo; set => _codigo = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public double Precio { get => _precio; set => _precio = value; }
        public int Stock { get => _stock; set => _stock = value; }
        public Categoria Categoria { get => _categoria; set => _categoria = value; }


        public Repuesto(int cod, string nom, double precio, int stock, Categoria cat)
        {
            this._codigo = cod;
            this._nombre = nom;
            this._precio = precio;
            this._stock = stock;
            this._categoria = cat;

        }

        public override string ToString()
        {
            return Nombre;
        }


    }
}
