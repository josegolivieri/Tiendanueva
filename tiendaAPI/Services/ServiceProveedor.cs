using Microsoft.EntityFrameworkCore;
using tiendaAPI.Data;
using tiendaAPI.Entidades.Modelos;
using tiendaAPI.Interfaces;

namespace tiendaAPI.Services
{
    public class ServiceProveedor(ContextoDB contexto) : IProveedorInterfaz
    {
        private readonly ContextoDB _contexto = contexto;


        public async Task<Proveedor> CrearProveedor(Proveedor proveedor)
        {
            await _contexto.Proveedores.AddAsync(proveedor);
            await _contexto.SaveChangesAsync();
            return proveedor;
        }
        public async Task<IEnumerable<Proveedor>> VerTodosLosProveedores()
        {
            return await _contexto.Proveedores
                //.Include(p => p.Productos)
                .Where(p => p.Activado == true)
                .ToListAsync();
        }
        public async Task<Proveedor?> ObtenerProveedorPorId(int id)
        {
            return await _contexto.Proveedores
                .Include(p => p.Productos)
                .FirstOrDefaultAsync(p => p.Id == id);       
        }

        public async Task<Proveedor> ActualizarProveedor(int id, string nuevoNombre, string nuevoCodigo)
        {
            var existeProveedor = await _contexto.Proveedores.FindAsync(id) ?? throw new InvalidOperationException($"Proveedor no encontrado.");

            existeProveedor.Nombre = nuevoNombre;
            existeProveedor.Codigo = nuevoCodigo;

            var CodigoEnUso = await _contexto.Proveedores.AnyAsync(p => p.Codigo == existeProveedor.Codigo && p.Id != existeProveedor.Id);
            if (CodigoEnUso)
            {
                throw new InvalidOperationException($"El código '{existeProveedor.Codigo}' está en uso.");
            }

            //_contexto.Entry(existeProveedor).CurrentValues.SetValues(existeProveedor);
            await _contexto.SaveChangesAsync();

            return existeProveedor;

        }

        public async Task<bool> CambiarEstado(int id)
        {
            var existeProveedor = await _contexto.Proveedores.FindAsync(id) ?? throw new InvalidOperationException($"Proveedor no encontrado.");

            existeProveedor.Activado = !existeProveedor.Activado;
            await _contexto.SaveChangesAsync();
            return true;
        }

        public async Task BorrarProveedor(int id)
        {
            var existeProveedor = await _contexto.Proveedores.FindAsync(id) ?? throw new InvalidOperationException($"Proveedor no encontrado.");

                _contexto.Proveedores.Remove(existeProveedor);
                await _contexto.SaveChangesAsync();
            

        }

    }
}
