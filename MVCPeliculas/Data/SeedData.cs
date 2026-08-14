using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVCPeliculas.Models;

namespace MVCPeliculas.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PeliculasDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<PeliculasDbContext>>()))
            {
                // Si ya existen películas, no volvemos a insertar los datos iniciales
                if (context.Peliculas.Any())
                {
                    return;
                }

                // Crear géneros
                var fantasia = new Genero
                {
                    Nombre = "Fantasia"
                };

                var drama = new Genero
                {
                    Nombre = "Drama"
                };

                var aventura = new Genero
                {
                    Nombre = "Aventura"
                };

                var comedia = new Genero
                {
                    Nombre = "Comedia"
                };

                var terror = new Genero
                {
                    Nombre = "Terror"
                };

                context.Generos.AddRange(
                    fantasia,
                    drama,
                    aventura,
                    comedia,
                    terror
                );

                // Guardamos primero los géneros para que SQL Server genere sus Id
                context.SaveChanges();

                // Crear películas usando directamente el género
                context.Peliculas.AddRange(
                    new Pelicula
                    {
                        Titulo = "Harry Potter y la piedra filosofal",
                        FechaLanzamiento = new DateTime(2001, 11, 16),
                        Genero = fantasia,
                        Precio = 7.55m,
                        Director = "Chris Columbus"
                    },

                    new Pelicula
                    {
                        Titulo = "El Señor de los Anillos: La Comunidad del Anillo",
                        FechaLanzamiento = new DateTime(2001, 12, 10),
                        Genero = aventura,
                        Precio = 8.30m,
                        Director = "Peter Jackson"
                    },

                    new Pelicula
                    {
                        Titulo = "El silencio de los corderos",
                        FechaLanzamiento = new DateTime(1991, 2, 14),
                        Genero = drama,
                        Precio = 6.25m,
                        Director = "Jonathan Demme"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}