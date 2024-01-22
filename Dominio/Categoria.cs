using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Categoria
    {
        public Categoria() { }
        public Categoria(string descripcion, int id)
        {
            Descripcion = descripcion;
            Id = id;
        }
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public string Imagen { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
