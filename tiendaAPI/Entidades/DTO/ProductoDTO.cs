namespace tiendaAPI.Entidades.DTO
{
    public record ActializarDTO
        (string Nombre,
        string Precio,
        int stock,
        string? urlphoto
        );
}
