namespace Curso.POO.Models
{
    public abstract class Mamifero:  Animal
    {
        public override TipoAlimentacionPosNatal TipoAlimentacionPosNatal { get => TipoAlimentacionPosNatal.Amamantar; }
    }
}
