using Nancy;
using ApiCaller;
using System;
using System.Collections.Generic;

namespace HelloNancy
{
    public class HelloModule : NancyModule
    {
        public HelloModule()
        {
// _________________GET__________________
    
            Get("/", async args =>
            {
                string Name = "";
                long Height = 0;
                long Weight = 0;

                // Our anonymous function is a parameter of type Action that returns a Dictionary
                await WebRequest.SendRequest("http://pokeapi.co/api/v2/pokemon/1", new Action<Dictionary<string, object>>( JsonResponse =>
                    {
                        Name = (string)JsonResponse["name"];
                        ViewBag.name = Name;
                        Height = (long)JsonResponse["height"];
                        ViewBag.height = Height;
                        Weight = (long)JsonResponse["weight"];
                        ViewBag.weight = Weight;
                    }
                ));
                Console.WriteLine(Name); // bulbasaur
                Console.WriteLine(Height);
                Console.WriteLine(Weight);


                return View["Hello"];
            });
// _________________POST__________________

           
        }
    }
}