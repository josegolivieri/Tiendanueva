using tiendaAPI.Entidades.DTO;
using tiendaAPI.Entidades.Modelos;

namespace tiendaAPI.Interfaces
{
    public interface IProductoInterfaz
    {
        Task<Producto> CrearProductoAsync(Producto producto);
        Task<IEnumerable<Producto>> ObtenerProductosAsync();
        Task<Producto?> ObtenerProductoPorCodigo(string CodigoProveedor, string codigoProducto);
        Task<Producto?> ObtenerCodigoPorId(int id);
        Task<Producto> ActualizarProducto(int id, ActializarDTO dto);
        Task<bool> ActualizarActivoAsync(int id);
        Task EliminarProducto(int id);
    }
}
