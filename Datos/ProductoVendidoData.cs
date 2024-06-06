using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public static class ProductoVendidoData
{
    private static string connectionString = "Server=localhost;Database=SistemaGestion;User Id=myUser;Password=myPassword;";

    public static ProductoVendido ObtenerProductoVendido(int id)
    {
        ProductoVendido productoVendido = null;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM ProductosVendidos WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    productoVendido = new ProductoVendido
                    {
                        Id = reader.GetInt32(0),
                        IdProducto = reader.GetInt32(1),
                        Stock = reader.GetInt32(2),
                        IdVenta = reader.GetInt32(3)
                    };
                }
            }
        }

        return productoVendido;
    }

    public static List<ProductoVendido> ListarProductosVendidos()
    {
        List<ProductoVendido> productosVendidos = new List<ProductoVendido>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM ProductosVendidos", connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ProductoVendido productoVendido = new ProductoVendido
                    {
                        Id = reader.GetInt32(0),
                        IdProducto = reader.GetInt32(1),
                        Stock = reader.GetInt32(2),
                        IdVenta = reader.GetInt32(3)
                    };

                    productosVendidos.Add(productoVendido);
                }
            }
        }

        return productosVendidos;
    }

    public static void CrearProductoVendido(ProductoVendido productoVendido)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(
                "INSERT INTO ProductosVendidos (IdProducto, Stock, IdVenta) VALUES (@IdProducto, @Stock, @IdVenta)",
                connection
            );

            command.Parameters.AddWithValue("@IdProducto", productoVendido.IdProducto);
            command.Parameters.AddWithValue("@Stock", productoVendido.Stock);
            command.Parameters.AddWithValue("@IdVenta", productoVendido.IdVenta);

            command.ExecuteNonQuery();
        }
    }

    public static void ModificarProductoVendido(ProductoVendido productoVendido)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(
                "UPDATE ProductosVendidos SET IdProducto = @IdProducto, Stock = @Stock, IdVenta = @IdVenta WHERE Id = @Id",
                connection
            );

            command.Parameters.AddWithValue("@Id", productoVendido.Id);
            command.Parameters.AddWithValue("@IdProducto", productoVendido.IdProducto);
            command.Parameters.AddWithValue("@Stock", productoVendido.Stock);
            command.Parameters.AddWithValue("@IdVenta", productoVendido.IdVenta);

            command.ExecuteNonQuery();
        }
    }

    public static void EliminarProductoVendido(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM ProductosVendidos WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            command.ExecuteNonQuery();
        }
    }
}
