namespace Marombastore.Core.Seedwork;

public class EntityBase
{
    protected Guid Id { get; set; }

    public EntityBase() => Id = Guid.NewGuid();
}