using tiendaAPI.Entidades.Modelos;

namespace tiendaAPI.Interfaces
{
    public interface IProveedorInterfaz
    {
        //Task<DEVUELVE> nombre__(PARAMETRO);
        //En este caso, el Task, DEVUELVE un objeto del tipo Proveedor, se llama CrearProveedor, y, recibe, para crear ese proveedor
        //Un objeto, del tipo Proveedor
        Task<Proveedor> CrearProveedor(Proveedor proveedor);
        /*Este task, me deuvelve una lista iterable, que, además, es del tipo Proveedor Task<TIPO<SUBTIPO>>
         No le paso ningún parámetro porque no necesita ninguno, si solo me trae una lista*/
        Task<IEnumerable<Proveedor>> VerTodosLosProveedores();
        /*Este task de tipo proveedor PUEDE O NO PUEDE devolver un proveedor, porque tiene "?"
         Este recibe el ID para buscar a ese proveedor*/
        Task<Proveedor?> ObtenerProveedorPorId(int id);
        //Task para actualizar, devuelve proveedor, recibe int id para UBICAR AL PROVEEDOR, y las dos
        //parámetros de tipo string son para actualizar los datos
        Task<Proveedor> ActualizarProveedor(int id, string nuevoNombre);
        //Esta únicamente se mete en la propiedad del proveedor llamado ACTIVADO, y cambia su estado
        //Si está true, lo cambia a false, y viceversa
        Task<bool> CambiarEstado(int id);
        //Esto solo borra, pero usa el ID para encontrar a ese proveedorr
        Task BorrarProveedor(int id);
    }
}
