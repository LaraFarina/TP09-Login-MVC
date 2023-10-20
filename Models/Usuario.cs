using System.Data.SqlClient; 
using Dapper; 

public class Usuario{
    public int id{get;set;}
    public string UserName{get;set;}
    public string Contraseña{get;set;}
    public string Email{get;set;}
    public char Genero{get;set;}
    public int Telefono{get;set;}
}