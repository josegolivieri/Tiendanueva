namespace tiendaAPI.Entidades.Modelos
{
    public class Categoria
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public bool Activado { get; set; } = true;
        public ICollection<Producto> Productos { get; set; } = [];

    }
}
