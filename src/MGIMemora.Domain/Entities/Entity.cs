namespace MGIMemora.Domain;

public class Entity
{
    public int Id { get; private set; }
    public DateTime DateCreate { get; protected set; }
    public DateTime? DateUpdate { get; protected set; }
}