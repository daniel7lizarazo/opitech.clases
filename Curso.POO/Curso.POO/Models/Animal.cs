using System;
using System.Collections.Generic;

namespace Curso.POO.Models
{
    public abstract class Animal
    {
        public string NombreCientifico { get; set; }
        
        public string NombreComun { get; set; }
                
        public abstract FamiliaAnimales FamiliaAnimales { get; }
       
        public abstract IEnumerable<ExtremidadesDesplazamiento> ExtremidadesDesplazamiento { get; }
        
        public abstract TipoDeAlimentacion TipoDeAlimentacion { get; }  
        
        public abstract TipoAlimentacionPosNatal TipoAlimentacionPosNatal { get; }


        public int Talla { get; protected set; }

        public float Peso { get; protected set; }

        public abstract float CalcularTalla();

        public void Comer()
        {
            Console.Write("Comer");
        }

        public abstract void Desplazar();

        public void Dormir()
        {
            Console.Write("Dormir");
        }
    }
}
