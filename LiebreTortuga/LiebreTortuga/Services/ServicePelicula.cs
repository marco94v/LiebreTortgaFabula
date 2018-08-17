using LiebreTortuga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiebreTortuga.Services
{
    public class ServicePelicula
    {
        public Pelicula ObtenerPelicula()
        {
            return new Pelicula()
            {
                Titulo = "Escape plan",
                Duracion = 115,
                Pais = "USA",
                Publicacion = new DateTime(2013, 12, 5)
            };
        }

        public List<Pelicula> ObtenerPeliculas()
        {
            var pelicula1 = new Pelicula()
            {
                Titulo = "Deadpool 2",
                Duracion = 215,
                Pais = "USA",
                Publicacion = new DateTime(2018, 04, 13)
            };

            var pelicula2 = new Pelicula()
            {
                Titulo = "Infinity war",
                Duracion = 230,
                Pais = "USA",
                Publicacion = new DateTime(2018, 05, 27)
            };

            return new List<Pelicula> { pelicula1, pelicula2 };
        }
    }
}