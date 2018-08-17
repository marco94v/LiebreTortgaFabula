using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiebreTortuga.Services
{
    public class auxiliar
    {
        private int[] tortuga, liebre;
        private int ganador;
        private int[,] modelo;


        public auxiliar(int[] tortuga, int[] liebre, int ganador)
        {
            this.tortuga = tortuga;
            this.liebre = liebre;
            this.ganador = ganador;
        }

        public int [,]obtenetModelo()
        {
            modelo = new int[3,50];
            for(int i=0; i < 50; i++)
            {
                modelo[0, i] = tortuga[i];
                modelo[1, i] = liebre[i];
            }
            modelo[2, 0] = ganador;
            return modelo;
        }
    }
}