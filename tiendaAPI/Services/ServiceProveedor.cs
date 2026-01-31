using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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
            await ValidarDatos(proveedor, banderaUpdate: false);
            await _contexto.Proveedores.AddAsync(proveedor);
            await _contexto.SaveChangesAsync();
            return proveedor;
        }
        public async Task<IEnumerable<Proveedor>> VerTodosLosProveedores()
        {
            return await _contexto.Proveedores
                .AsNoTracking()
                .Where(p => p.Activado == true)
                .ToListAsync();
        }
        public async Task<Proveedor?> ObtenerProveedorPorId(int id)
        {
            return await _contexto.Proveedores
                .AsNoTracking()
                .Include(p => p.Productos)
                .FirstOrDefaultAsync(p => p.Id == id);       
        }

        public async Task<Proveedor> ActualizarProveedor(int id, string nuevoNombre)
        {
            var existeProveedor = await _contexto.Proveedores.FindAsync(id) ?? throw new InvalidOperationException($"Proveedor no encontrado.");

            existeProveedor.Nombre = nuevoNombre;


            await ValidarDatos(existeProveedor, banderaUpdate: true);
            await _contexto.SaveChangesAsync();

            return existeProveedor;

        }

        public async Task<bool> CambiarEstado(int id)
        {
            var existeProveedor = await _contexto.Proveedores.FindAsync(id) ?? throw new InvalidOperationException($"Proveedor no encontrado.");

            existeProveedor.Activado = !existeProveedor.Activado;
            await _contexto.SaveChangesAsync();
            return existeProveedor.Activado;
        }

        public async Task BorrarProveedor(int id)
        {
            var existeProveedor = await _contexto.Proveedores.FindAsync(id) ?? throw new InvalidOperationException($"Proveedor no encontrado.");

                _contexto.Proveedores.Remove(existeProveedor);
                await _contexto.SaveChangesAsync();
            

        }


        private async Task ValidarDatos(Proveedor proveedor, bool banderaUpdate)
        {
            if (string.IsNullOrWhiteSpace(proveedor.Nombre)) throw new InvalidOperationException("El campo nombre no puede estar vacío");
            if (string.IsNullOrEmpty(proveedor.Codigo)) throw new InvalidOperationException("El codigo no puede estar vacío");

            var codigoEnUso = await _contexto.Categorias.AnyAsync(p => p.Nombre.ToLower() == proveedor.Nombre.ToLower() && (!banderaUpdate || p.Id != proveedor.Id));

            if (codigoEnUso) 
            {
                throw new InvalidOperationException($"El nombre '{proveedor.Nombre}' ya está en uso");
            }
        
        
        }

        
    }
}
