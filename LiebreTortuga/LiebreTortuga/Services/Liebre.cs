using LiebreTortuga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiebreTortuga.Services
{
    public class Liebre : Animales
    {
        private const int NORMAL = 2;
        private const int RAPIDO = 4;
        private const int DORMIR = 0;
        private int dis;
        private int rnd;
        Random r = new Random();


        public Liebre(Animal a)
            : base(a)
        {
            this.rnd = -1;
            this.dis = -1;
        }

        private int calcularDistancia()
        {
            rnd = calculaRandom();
            if (rnd >= 1 && rnd <= 2)
            {
                return DORMIR;
            }
            else if (rnd >= 3 && rnd <= 6)
            {
                return NORMAL;
            }
            else if (rnd >= 7 && rnd <= 10)
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