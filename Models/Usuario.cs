using System.Data.SqlClient; 
using Dapper; 

static class Usuario {
    public int IdUsuario { get; set; }
    public string NombreUsuario { get; set; }
    public string Password { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
}