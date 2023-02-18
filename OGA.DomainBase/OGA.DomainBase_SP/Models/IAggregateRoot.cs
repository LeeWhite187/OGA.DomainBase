using System;

namespace OGA.DomainBase.Models
{
    /// <summary>
    /// Marker Interface for Aggregate Roots
    /// </summary>
    public interface IAggregateRoot<TId> where TId : IEquatable<TId>
    {
        // Make the ID flexible at compile time.
        // It can be an Int32, Int64, Guid, or String.
        TId Id { get; }
    }
}
