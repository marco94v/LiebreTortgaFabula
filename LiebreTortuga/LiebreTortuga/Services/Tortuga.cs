using LiebreTortuga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiebreTortuga.Services
{
    public class Tortuga : Animales
    {
        private const int NORMAL = 1;
        private const int RAPIDO = 3;

        private int dis;
        private int rnd;
        Random r = new Random();


        public Tortuga(Animal a)
            : base(a)
        {
            this.rnd = -1;
            this.dis = -1;
        }

        private int calcularDistancia()
        {
            rnd = calculaRandom();
            if (rnd >= 1 && rnd <= 5)
            {
                return NORMAL;
            }
            else if (rnd >= 6 && rnd <= 10)
            {
                return RAPIDO;
            }

            throw new NotImplementedException();
        }

        private int calculaRandom()
        {
            int aleatorio = r.Next(1, 10);
            return aleatorio;
        }

        public override int GetMovimieto()
        {
            return calcularDistancia();
        }
    }
}