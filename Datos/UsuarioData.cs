using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public static class UsuarioData
{
    private static string connectionString = "Server=nombre_servidor;Database=SistemaGestion;User Id=usuario;Password=contraseña;";

    public static Usuario ObtenerUsuario(int id)
    {
        Usuario usuario = null;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Usuarios WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    usuario = new Usuario
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Apellido = reader.GetString(2),
                        NombreUsuario = reader.GetString(3),
                        Contraseña = reader.GetString(4),
                        Mail = reader.GetString(5)
                    };
                }
            }
        }

        return usuario;
    }

    public static List<Usuario> ListarUsuarios()
    {
        List<Usuario> usuarios = new List<Usuario>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Usuarios", connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Usuario usuario = new Usuario
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Apellido = reader.GetString(2),
                        NombreUsuario = reader.GetString(3),
                        Contraseña = reader.GetString(4),
                        Mail = reader.GetString(5)
                    };

                    usuarios.Add(usuario);
                }
            }
        }

        return usuarios;
    }

    public static void CrearUsuario(Usuario usuario)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(
                "INSERT INTO Usuarios (Nombre, Apellido, NombreUsuario, Contraseña, Mail) VALUES (@Nombre, @Apellido, @NombreUsuario, @Contraseña, @Mail)",
                connection
            );

            command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
            command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
            command.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
            command.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
            command.Parameters.AddWithValue("@Mail", usuario.Mail);

            command.ExecuteNonQuery();
        }
    }

    public static void ModificarUsuario(Usuario usuario)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(
                "UPDATE Usuarios SET Nombre = @Nombre, Apellido = @Apellido, NombreUsuario = @NombreUsuario, Contraseña = @Contraseña, Mail = @Mail WHERE Id = @Id",
                connection
            );

            command.Parameters.AddWithValue("@Id", usuario.Id);
            command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
            command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
            command.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
            command.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
            command.Parameters.AddWithValue("@Mail", usuario.Mail);

            command.ExecuteNonQuery();
        }
    }

    public static void EliminarUsuario(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Usuarios WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            command.ExecuteNonQuery();
        }
    }
}
