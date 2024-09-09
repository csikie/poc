namespace poc.Domain.Primitives;

public abstract class Entity : IEquatable<Entity>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Entity"/> class with the specified Id.
    /// </summary>
    /// <param name="id">The id of the entity.</param>
    protected Entity(int id)
    {
        Id = id;
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Entity"/> class.
    /// </summary>
    protected Entity()
    {
    }

    /// <summary>
    /// The id of the entity.
    /// </summary>
    public int Id { get; init; }
    
    /// <summary>
    /// This operator determines whether two Entities are equal.
    /// </summary>
    /// <param name="left">The first Entity to be compared.</param>
    /// <param name="right">The second Entity to be compared.</param>
    /// <returns>True if the two objects are equal; otherwise, false.</returns>
    /// <seealso cref="Equals(Entity)"/>
    /// <seealso cref="operator!="/>
    /// <remarks>Two entities are equal if their types match and their Ids are equal.</remarks>
    public static bool operator ==(Entity? left, Entity? right)
    {
        if (left is null && right is null)
        {
            return true;
        }

        var result = left is not null && right is not null && left.Equals(right);
        return result;
    }

    /// <summary>
    /// This operator determines whether two Entities are NOT equal.
    /// </summary>
    /// <param name="left">The first Entity to be compared.</param>
    /// <param name="right">The second Entity to be compared.</param>
    /// <returns>True if the two objects are NOT equal; otherwise, false.</returns>
    /// <seealso cref="Equals(Entity)"/>
    /// <seealso cref="operator=="/>
    /// <remarks>Two entities are equal if their types match and their Ids are equal.</remarks>
    public static bool operator !=(Entity? left, Entity? right)
    {
        var result = !(left == right);
        return result;
    }

    /// <inheritdoc/>
    public bool Equals(Entity? other)
    {
        return other != null && other.GetType() == GetType() && other.Id == Id;
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return obj is Entity entity && entity.Id == Id;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}