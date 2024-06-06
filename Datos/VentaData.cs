using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public static class VentaData
{
    private static string connectionString = "Server=localhost;Database=SistemaGestion;User Id=myUser;Password=myPassword;";

    public static Venta ObtenerVenta(int id)
    {
        Venta venta = null;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Ventas WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    venta = new Venta
                    {
                        Id = reader.GetInt32(0),
                        Comentarios = reader.GetString(1),
                        IdUsuario = reader.GetInt32(2)
                    };
                }
            }
        }

        return venta;
    }

    public static List<Venta> ListarVentas()
    {
        List<Venta> ventas = new List<Venta>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Ventas", connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Venta venta = new Venta
                    {
                        Id = reader.GetInt32(0),
                        Comentarios = reader.GetString(1),
                        IdUsuario = reader.GetInt32(2)
                    };

                    ventas.Add(venta);
                }
            }
        }

        return ventas;
    }

    public static void CrearVenta(Venta venta)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(
                "INSERT INTO Ventas (Comentarios, IdUsuario) VALUES (@Comentarios, @IdUsuario)",
                connection
            );

            command.Parameters.AddWithValue("@Comentarios", venta.Comentarios);
            command.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);

            command.ExecuteNonQuery();
        }
    }

    public static void ModificarVenta(Venta venta)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(
                "UPDATE Ventas SET Comentarios = @Comentarios, IdUsuario = @IdUsuario WHERE Id = @Id",
                connection
            );

            command.Parameters.AddWithValue("@Id", venta.Id);
            command.Parameters.AddWithValue("@Comentarios", venta.Comentarios);
            command.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);

            command.ExecuteNonQuery();
        }
    }

    public static void EliminarVenta(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Ventas WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            command.ExecuteNonQuery();
        }
    }
}
