public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string NombreUsuario { get; set; }
    public string Contraseña { get; set; }
    public string Mail { get; set; }
}

public class Producto
{
    public int Id { get; set; }
    public string Descripcion { get; set; }
    public decimal Costo { get; set; }
    public decimal PrecioVenta { get; set; }
    public int Stock { get; set; }
    public int IdUsuario { get; set; }
}

public class ProductoVendido
{
    public int Id { get; set; }
    public int IdProducto { get; set; }
    public int Stock { get; set; }
    public int IdVenta { get; set; }
}

public class Venta
{
    public int Id { get; set; }
    public string Comentarios { get; set; }
    public int IdUsuario { get; set; }
}
