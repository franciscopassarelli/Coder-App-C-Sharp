using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public static class ProductoData
{
    private static string connectionString = "Server=nombre_servidor;Database=SistemaGestion;User Id=usuario;Password=contraseña;";

    public static Producto ObtenerProducto(int id)
    {
        Producto producto = null;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Productos WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    producto = new Producto
                    {
                        Id = reader.GetInt32(0),
                        Descripcion = reader.GetString(1),
                        Costo = reader.GetDecimal(2),
                        PrecioVenta = reader.GetDecimal(3),
                        Stock = reader.GetInt32(4),
                        IdUsuario = reader.GetInt32(5)
                    };
                }
            }
        }

        return producto;
    }

    public static List<Producto> ListarProductos()
    {
        List<Producto> productos = new List<Producto>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Productos", connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Producto producto = new Producto
                    {
                        Id = reader.GetInt32(0),
                        Descripcion = reader.GetString(1),
                        Costo = reader.GetDecimal(2),
                        PrecioVenta = reader.GetDecimal(3),
                        Stock = reader.GetInt32(4),
                        IdUsuario = reader.GetInt32(5)
                    };

                    productos.Add(producto);
                }
            }
        }

        return productos;
    }

    public static void CrearProducto(Producto producto)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(
                "INSERT INTO Productos (Descripcion, Costo, PrecioVenta, Stock, IdUsuario) VALUES (@Descripcion, @Costo, @PrecioVenta, @Stock, @IdUsuario)",
                connection
            );

            command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
            command.Parameters.AddWithValue("@Costo", producto.Costo);
            command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
            command.Parameters.AddWithValue("@Stock", producto.Stock);
            command.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);

            command.ExecuteNonQuery();
        }
    }

    public static void ModificarProducto(Producto producto)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(
                "UPDATE Productos SET Descripcion = @Descripcion, Costo = @Costo, PrecioVenta = @PrecioVenta, Stock = @Stock, IdUsuario = @IdUsuario WHERE Id = @Id",
                connection
            );

            command.Parameters.AddWithValue("@Id", producto.Id);
            command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
            command.Parameters.AddWithValue("@Costo", producto.Costo);
            command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
            command.Parameters.AddWithValue("@Stock", producto.Stock);
            command.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);

            command.ExecuteNonQuery();
        }
    }

    public static void EliminarProducto(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Productos WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            command.ExecuteNonQuery();
        }
    }
}
