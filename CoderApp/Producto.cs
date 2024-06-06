using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderApp
{
    public class Producto
    {
       
            public int Id { get; set; }
            public string Descripcion { get; set; }
            public decimal Costo { get; set; }
            public decimal PrecioVenta { get; set; }
            public int Stock { get; set; }
            public int IdUsuario { get; set; }
        
    }
}

