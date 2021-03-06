﻿using System;
using LiebreTortuga.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LiebreTortuga.Models;
using System.Threading;

namespace LiebreTortuga.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            var ServicePelicula = new ServicePelicula();
            var model = ServicePelicula.ObtenerPeliculas();

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Fabula()
        {
            var win = 0;
            ViewBag.Message = "Comienza la carrera de 100 metros entre la tortuga y la liebre";
            System.Diagnostics.Debug.WriteLine("Comienza la carrera de 100 metros entre la tortuga y la liebre");

            var liebre = new Liebre(new Animal() { nombre = "Liebre", durmiendo = false, llegoMeta = false });
            var tortuga = new Tortuga(new Animal() { nombre = "Tortuga", durmiendo = false, llegoMeta = false });

            tortuga.carrera();
            liebre.carrera();

            while (!tortuga.getLlego() || !liebre.getLlego())
            {

                if (tortuga.getLlego())
                {
                    System.Diagnostics.Debug.WriteLine("La tortuga gano...¡¡");
                    win = 1;
                    liebre.Detener();
                    break;
                }
                if (liebre.getLlego())
                {
                    System.Diagnostics.Debug.WriteLine("La liebre gano gano...¡¡");
                    win = 2;
                    tortuga.Detener();
                    break;
                }

                if (liebre.DistanciaT == tortuga.DistanciaT)
                {
                    if (!liebre.getDuerme() && liebre.DistanciaT != 1)
                    {
                        System.Diagnostics.Debug.WriteLine("La tortuga muerde a la liebre");
                        Thread.Sleep(500);
                    }

                }
            }

            if (tortuga.getLlego() && liebre.getLlego())
            {
                Random r = new Random();
                if (r.Next(1, 2) == 1)
                {
                    win = 3;
                    System.Diagnostics.Debug.WriteLine("La carrera ah sido un empate");
                }
                else
                {
                    win = 4;
                    System.Diagnostics.Debug.WriteLine("la tortuga gano..¡¡ fue chance");
                }
            }
            while (tortuga.isAlive() && liebre.isAlive())
            {

            }
            auxiliar a = new auxiliar(tortuga.Pos, liebre.Pos, win);
            var model = a.obtenetModelo();

            for (int i = 0; i < 50; i++)
            {
               // System.Diagnostics.Debug.WriteLine(model[1, i]);
            }
            //System.Diagnostics.Debug.WriteLine(model[2, 0]);
            return View(model);
        }
    }
}