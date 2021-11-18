using System;
using System.Collections.Generic;

namespace Curso.POO.Models
{
    public class Gorila : Mamifero
    {
        public override IEnumerable<ExtremidadesDesplazamiento> ExtremidadesDesplazamiento => new List<ExtremidadesDesplazamiento>()
        {
            {Models.ExtremidadesDesplazamiento.Bipedos },
            {Models.ExtremidadesDesplazamiento.Cuadropedos }
        };

        public override FamiliaAnimales FamiliaAnimales => FamiliaAnimales.Hominidos;

        public override TipoDeAlimentacion TipoDeAlimentacion => TipoDeAlimentacion.Herviboro;

        public override void Desplazar()
        {
            Console.WriteLine("knuckle-walk");
        }

        public override float CalcularTalla()
        {
            Console.WriteLine("ocurre la forma particular para calcular una talla del gorila");

            return Talla;
        }
    }
}
