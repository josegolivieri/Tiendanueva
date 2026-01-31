using tiendaAPI.Entidades.Modelos;

namespace tiendaAPI.Interfaces
{
    public interface ICategoriaInterfaz
    {
        Task<Categoria> CrearCategoriaAsync(Categoria categoria);
        Task<IEnumerable<Categoria>> ObtenerCategorias();
        Task<Categoria?> ObtenerCategoriaPorId(int id);
        Task<Categoria> ModificarCategoria(int id, string nuevoNombre);
        Task<bool> CambiarEstado(int id);
        Task BorrarCategoria(int id);
    }
}
