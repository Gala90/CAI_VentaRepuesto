using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion.VentaRepuesto.Entidades
{
    public class Comercio
    {
        private string _nombreComercio;
        private string _direccion;
        private List<Repuesto> _listaProducto;



        public string NombreComercio { get => _nombreComercio; set => _nombreComercio = value; }

        public string Direccion { get => _direccion; set => _direccion = value; }

        public  List<Repuesto> Repuestos { get => _listaProducto; set => _listaProducto = value; }


        public Comercio (string nom, string dir)
        {
            this._nombreComercio = nom;
            this._direccion = dir;
            _listaProducto = new List<Repuesto>();
        }


        public void AgregarRepuesto (Repuesto r)
        {
            this.Repuestos.Add(r);
        }

        public void QuitarRepuesto(int cod)
        {
            foreach (Repuesto r in Repuestos)
            {
                if (r.Codigo == cod)
                {
                    Repuestos.Remove(r);
                }
            }
        }

        public void ModificarPrecio(int cod, double precio)
        {
            foreach (Repuesto r in Repuestos)
            {
                if (r.Codigo == cod)
                {
                    r.Precio = precio;
                }
            }

        }

        public void AgregarStock(int cod, int cant)
        {
            foreach (Repuesto r in Repuestos)
            {
                if (r.Codigo == cod)
                {
                    r.Stock = r.Stock - cant;
                }
            }
        }

        public void QuitarStock(int cod, int cant)
        {
            foreach (Repuesto r in Repuestos)
            {
                if (r.Codigo == cod)
                {
                    r.Stock = r.Stock + cant;
                }
            }
        }

        public List<Repuesto> TraerPorCategoria(int cod)
        {
            List<Repuesto> reps = new List<Repuesto>();
            foreach (Repuesto r in Repuestos)
            {
                if (r.Categoria.Codigo == cod)
                {
                    reps.Add(r); 
                }
            }
            return reps;
        }

        

    }
}
