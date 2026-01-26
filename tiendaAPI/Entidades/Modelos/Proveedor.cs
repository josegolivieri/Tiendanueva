namespace tiendaAPI.Entidades.Modelos
{
    public class Proveedor
    {
        public int Id { get; set; }
        public required string Codigo { get; set; }
        public required string Nombre { get; set; }
        //Esta propiedad le da la posibilidad al proveedor de tener productos, por eso es un tipo de propiedad
        //ICollection<TIPO> y al final se inicia como un array vacío, o, en este caso, como un new List<TIPO>();
        public ICollection<Producto> Productos { get; set; } = new List<Producto>();

        //Esta propiedad sirve para decir si está activado o no, de momento no tiene relevancia técnica pero se usará para apagar
        //o encender el proveedor
        public bool Activado { get; set; } = true;
    }
}
