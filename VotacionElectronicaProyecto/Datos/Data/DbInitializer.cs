using Shared.Entities;

namespace Api.Data
{
    public static class DBInitializer
    {
        public static void Initialize(DataContext context)
        {
           

        //    // Verificar si ya hay datos en las tablas
        //    if (context.Candidatos.Any() || context.Eleccion.Any() || context.Lista.Any() ||
        //        context.Persona.Any() || context.Resultado.Any() || context.Votante.Any() ||
        //        context.Voto.Any() || context.EleccionListas.Any())
        //    {
        //        return; // La base de datos ya ha sido inicializada
        //    }

        //    // Sembrar datos iniciales
        //    var candidatos = new List<Candidatos>
        //{
        //    new Candidatos { /* Inicializa propiedades aquí */ },
        //    new Candidatos { /* Inicializa propiedades aquí */ }
        //};

        //    var elecciones = new List<Eleccion>
        //{
        //    new Eleccion { /* Inicializa propiedades aquí */ },
        //    new Eleccion { /* Inicializa propiedades aquí */ }
        //};

        //    var listas = new List<Lista>
        //{
        //    new Lista { /* Inicializa propiedades aquí */ },
        //    new Lista { /* Inicializa propiedades aquí */ }
        //};

        //    var personas = new List<Persona>
        //{
        //    new Persona { NroIdentificacionPersona = "12345678", /* Inicializa otras propiedades */ },
        //    new Persona { NroIdentificacionPersona = "87654321", /* Inicializa otras propiedades */ }
        //};

        //    var votantes = new List<Votante>
        //{
        //    new Votante { /* Inicializa propiedades aquí */ },
        //    new Votante { /* Inicializa propiedades aquí */ }
        //};

        //    var resultados = new List<Resultado>
        //{
        //    new Resultado { /* Inicializa propiedades aquí */ },
        //    new Resultado { /* Inicializa propiedades aquí */ }
        //};

        //    var votos = new List<Voto>
        //{
        //    new Voto { /* Inicializa propiedades aquí */ },
        //    new Voto { /* Inicializa propiedades aquí */ }
        //};

        //    var eleccionListas = new List<EleccionLista>
        //{
        //    new EleccionLista { /* Inicializa propiedades aquí */ },
        //    new EleccionLista { /* Inicializa propiedades aquí */ }
        //};

        //    // Agregar los datos al contexto
        //    context.Candidatos.AddRange(candidatos);
        //    context.Eleccion.AddRange(elecciones);
        //    context.Lista.AddRange(listas);
        //    context.Persona.AddRange(personas);
        //    context.Votante.AddRange(votantes);
        //    context.Resultado.AddRange(resultados);
        //    context.Voto.AddRange(votos);
        //    context.EleccionListas.AddRange(eleccionListas);

        //    // Guardar los cambios en la base de datos
        //    context.SaveChanges();
        }
    }

}
