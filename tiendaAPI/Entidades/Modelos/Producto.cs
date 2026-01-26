using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace tiendaAPI.Entidades.Modelos
{
    public class Producto
    {
        /*Esto es un modelo, simula un objeto, y cada objeto creado sigue la plantilla acá expuesta,
         * con, sus respectivas restricciones y libertades*/

        //Primeras 3 propiedades, un Id único, un código de proveedor que nos sirve para enlazar conceptualmente
        //el proveedor con el prodcto, y un código de producto para identificar el producto dentro de cada proveedor.

        public int Id { get; set; }
        public required string CodigoProveedor { get; set; }
        public required string CodigoProducto { get; set; }


        public required string Nombre { get; set; }
        public required decimal Precio { get; set; }
        public int Stock { get; set; }
        public bool Activado { get; set; } = true;


        /*La categoriaId es propiedad de enlace, es tipo conceptual, me sirve para enlazar cateogorías con productos
         Y, public Categoria es de tipo navegación, la utiliza EF Core para mapear las tablas, y, con el signo de interrogación
        deja permitido que su valor sea nulo. El =null! significa que no será null, es una promesa que puede o no puede ser cierta*/
        public int? CategoriaId { get; set; }
        //POSIBLEMENTE, necesite JSONIGNORE
        public Categoria? Categoria { get; set; } = null!;


        [Display(Name = "Image")]
        public string UrlFoto { get; set; } = null!;

        //Esta propiedad también es de tipo NAVEGACIÓN, para EF Core, pero tiene el JsonIgnore para evitar búsquedas cíclicas
        [JsonIgnore]
        public Proveedor Proveedor { get; set; } = null!;

    }
}
