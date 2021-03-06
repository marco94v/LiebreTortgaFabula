﻿using LiebreTortuga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace LiebreTortuga.Services
{
    public abstract class Animales
    {
        private int distanciaT = 1;
        private int mov = -1;
        Thread hilo;
        private Animal a;

        private int[] pos = Enumerable.Repeat(-1, 50).ToArray();
        

        public Animales(Animal a)
        {
            pos[0] = 1;
            this.A = a;
        }

        public Animal A { get => a; set => a = value; }
        public int DistanciaT { get => distanciaT; set => distanciaT = value; }
        public int[] Pos { get => pos; set => pos = value; }

        public void carrera()
        {
            hilo = new Thread(race);
            hilo.Start();

        }
        public bool isAlive()
        {
            return hilo.IsAlive;
        }
        private void race()
        {

            while (!a.llegoMeta)
            {
           
                mov = GetMovimieto();
                DistanciaT += mov;
                if (mov == 0)
                {
                    pos[distanciaT-1] = 0;
                    a.durmiendo = true;
                    System.Diagnostics.Debug.WriteLine("La " + a.nombre + " se encuentra en la posición " + DistanciaT + " se quedo dormida");
                    Thread.Sleep(500);
                }
                else
                {
                    if (distanciaT > 50)
                    {
                        pos[19] = 5;
                    }
                    else
                    {
                        if(accion()=="normal")
                        {
                            pos[distanciaT-1] = 3;
                        }
                        else
                        {
                            pos[distanciaT-1] = 4;
                        }   
                    }
                    System.Diagnostics.Debug.WriteLine("La " + a.nombre + " se encuentra en la posición " + DistanciaT + " caminando " + accion());
                }

                if (DistanciaT >= 50)
                {
                    a.llegoMeta = true;
                }
                Thread.Sleep(500);
                a.durmiendo = false;                
            }

        }


        private string accion()
        {
            if (mov <= 2)
            {
                return "normal";
            }
            else
            {
                return "rapido";
            }
        }

        public abstract int GetMovimieto();

        public bool getLlego()
        {
            return a.llegoMeta;
        }

        public void Detener()
        {
            hilo.Abort();
        }

        public bool getDuerme()
        {
            return a.durmiendo;
        }
    }
}