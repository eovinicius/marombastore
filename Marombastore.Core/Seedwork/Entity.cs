namespace Marombastore.Core.Seedwork;

public class EntityBase
{
    protected Guid Id { get; private set; }

    public EntityBase() => Id = Guid.NewGuid();
}