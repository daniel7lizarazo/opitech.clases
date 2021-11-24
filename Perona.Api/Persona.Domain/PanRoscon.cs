namespace Persona.Domain
{
    public class PanRoscon: Entity<string>
    {
        public string Name { get; set; }   
        public string Description { get; set; }
        public float Precio { get; set; }

       
        public PanRoscon()
        {
            
        }

        private PanRoscon(string id,string name, string descripcion, float precio)
        {
            this.Name = name;
            this.Description = descripcion;
            this.Precio = precio;  
            this.Id = id;
        }

        public static PanRoscon Crear(string id,string name, string descripcion, float precio)
        {
            return new PanRoscon(id,name, descripcion, precio);
        }
    }
}
