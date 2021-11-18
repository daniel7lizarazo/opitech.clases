using System;
using System.Collections.Generic;

namespace Curso.POO.Models
{
    public class Murcielago: Mamifero, IVolador
    {
        public override FamiliaAnimales FamiliaAnimales => FamiliaAnimales.Mammalia;

        public override IEnumerable<ExtremidadesDesplazamiento> ExtremidadesDesplazamiento => new List<ExtremidadesDesplazamiento> {
            { Models.ExtremidadesDesplazamiento.Bipedos },
            { Models.ExtremidadesDesplazamiento.Cuadropedos }
        };

        public override TipoDeAlimentacion TipoDeAlimentacion => TipoDeAlimentacion.Omnivoro;

        public override float CalcularTalla()
        {
            Console.WriteLine("Parcticular a su tall");
            return Talla;
        }

        public override void Desplazar()
        {
            Volar();
        }

        public void Volar()
        {
            Console.WriteLine("Volando");
        }
    }
}
