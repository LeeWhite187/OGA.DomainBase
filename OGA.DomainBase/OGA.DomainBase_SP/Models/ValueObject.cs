using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGA.DomainBase.Models
{
    /* Value Object Base.
     * This class was adapted from here: https://enterprisecraftsmanship.com/posts/value-object-better-implementation/
     * Use this for all value objects
     * Each value object type must have only GET for each property.
     * Each value object type must have a constructor that accepts all property values.
     * Each value object type must inherit the below base class AND override the GetEqualityComponents method, like this:
            public class cVONetAddress : SharedKernel.Models.ValueObject
            {
                public string Address { get; private set; }

                public string Subnet { get; private set; }
                public int Mask { get; private set; }

                public bool Is_V4 { get; private set; }

                public cVONetAddress(string address, string subnet, int mask, bool is_v4)
                {
                    Address = address;
                    Subnet = subnet;
                    Mask = mask;
                    Is_V4 = is_v4;
                }

                public override string ToString()
                {
                    return $"{Address}, {Subnet}, {Mask} {Is_V4}";
                }

                protected override IEnumerable<object> GetEqualityComponents()
                {
                    yield return Address;
                    yield return Subnet;
                    yield return Mask;
                    yield return Is_V4;
                }
            }

        Additionally, for any owned value object, a mapping configuration must be created, so EF can store and retrieve the value object
        as part of its owner, like this:
            // Part of the OrderEntityTypeConfiguration.cs class
            //
            public void Configure(EntityTypeBuilder<Order> orderConfiguration)
            {
                orderConfiguration.ToTable("orders", OrderingContext.DEFAULT_SCHEMA);
                orderConfiguration.HasKey(o => o.Id);
                orderConfiguration.Ignore(b => b.DomainEvents);
                orderConfiguration.Property(o => o.Id)
                    .ForSqlServerUseSequenceHiLo("orderseq", OrderingContext.DEFAULT_SCHEMA);

                //Address value object persisted as owned entity in EF Core 2.0
                orderConfiguration.OwnsOne(o => o.Address);

                orderConfiguration.Property<DateTime>("OrderDate").IsRequired();

                //...Additional validations, constraints and code...
                //...
            }
     */


    /// <summary>
    /// Value Object Base
    /// Inherit this class for all value type objects in the domain.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ValueObject
    {
        #region Methods Required for Value Object

        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            var valueObject = (ValueObject)obj;

            return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
            
            //return GetEqualityComponents()
            //    .Aggregate(1, (current, obj) =>
            //    {
            //        unchecked
            //        {
            //            return current * 23 + (obj?.GetHashCode() ?? 0);
            //        }
            //    });
        }

        protected static bool EqualOperator(ValueObject a, ValueObject b)
        {
            if (ReferenceEquals(a, null) ^ ReferenceEquals(b, null))
            {
                return false;
            }
            return ReferenceEquals(a, null) || a.Equals(b);
        }

        protected static bool NotEqualOperator(ValueObject a, ValueObject b)
        {
            return !(EqualOperator(a, b));
        }

        public static bool operator ==(ValueObject a, ValueObject b)
        {
            return EqualOperator(a, b);
            //if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            //    return true;

            //if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            //    return false;

            //return a.Equals(b);
        }

        public static bool operator !=(ValueObject a, ValueObject b)
        {
            return !(EqualOperator(a, b));
        }

        #endregion
    }
}
