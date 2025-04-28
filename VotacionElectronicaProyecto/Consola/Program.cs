using Newtonsoft.Json;
using System.Runtime.CompilerServices;

Console.WriteLine("Bienvenido prueba de consulta de la app.");
Console.WriteLine("----------------------------------------");
Console.WriteLine(" ");

Console.WriteLine("Obteniendo todos los Candidatos.....");
Console.WriteLine("--------------------------------");
Console.WriteLine(" ");
Console.WriteLine("Presione una tecla para continuar");

Console.ReadKey();
var lista = Negocio.CasosDeUso.Candidatos.ObtenerTodo().GetAwaiter().GetResult();

foreach (var item in lista)
{
    Console.WriteLine(JsonConvert.SerializeObject(item));
    Console.WriteLine(" ");
}
Console.WriteLine(" ");
Console.WriteLine("Fin obtención de todos los Paises.....");
Console.WriteLine(" ");

Console.WriteLine("Total de Candidatos: " + lista.Count);
Console.WriteLine(" ");

Console.WriteLine("Presione una tecla para salir");

Console.ReadKey();

var objCreatePais = new Shared.Dtos.Candidatos.CrearDTO { NombreCandidato = "Candidato creado desde linea de comando" };

// Negocio.CasosDeUso.Pais.Crear(objCreatePais).GetAwaiter().GetResult();

Console.WriteLine(" ");
Console.WriteLine("Presione una tecla para continuar");

Console.ReadKey();

lista = Negocio.CasosDeUso.Candidatos.ObtenerTodo().GetAwaiter().GetResult();

foreach (var item in lista)
{
    Console.WriteLine(JsonConvert.SerializeObject(item));
    Console.WriteLine(" ");
}

Console.ReadKey();

Negocio.CasosDeUso.Candidatos.Borrar(26).GetAwaiter().GetResult();

Console.WriteLine(" ");
Console.WriteLine("Presione una tecla para continuar");

Console.ReadKey();

lista = Negocio.CasosDeUso.Candidatos.ObtenerTodo().GetAwaiter().GetResult();

foreach (var item in lista)
{
    Console.WriteLine(JsonConvert.SerializeObject(item));
    Console.WriteLine(" ");
}
Console.ReadKey();
