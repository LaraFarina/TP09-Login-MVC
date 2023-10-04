using System.Data.SqlClient; 
using Dapper; 

public class BD{
    private static string _connectionString = @"Server=.;Trusted_Connection=True;";
    private static Usuario _UserLog = null;

    public static void RegistrarUsuario(Usuario user){
        string sql = "INSERT INTO Usuario(id, UserName, Contraseña, Nombre, Email, Telefono, ) VALUES (@pid, @pUserName, @pContraseña, @pNombre, @pEmail, @pTelefono, )";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            db.Execute(sql, new {pid = user.id, pUserName = user.UserName, pContraseña = user.Contraseña, pEmail = user.Email, pTelefono = user.Telefono, pNombre = user.Nombre});
        }
    }

    public static List<Usuario> LoginUsuario(){
        List<Usuario> listaUsuarios;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Usuarios";
            listaUsuarios = db.Query<Usuario>(sql).ToList();
        }
        return listaUsuarios;
    }

    public static Usuario ObtenerUsuario(){
        return _UserLog;
    }

    public static void CrearUsuario(Usuario User)
    {
        int RegistrosAñadidos = 0;
        string sql = "INSERT INTO Usuario(UserName, Contraseña, Email, Nombre, Genero) VALUES (@pUsername, @pContra, @pMail, @pTel, @pNombre)";
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            RegistrosAñadidos = db.Execute(sql, new {pUserName = User.UserName, pContra = User.Contraseña, pMail = User.Email, pTel = User.Telefono, pNombre = User.Nombre});
        }
        bool esValido = ValidacionUsuario(User.UserName, User.Contraseña);
    }

    public static bool ValidacionUsuario(string nameUser, string contra)
    {
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Usuario WHERE UserName = @pName and Contraseña = @pContra";
            _UserLog = db.QueryFirstOrDefault<Usuario>(sql, new {pName = nameUser, pContra = contra});
        }
        return(_UserLog != null);
    }
}