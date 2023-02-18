using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OGA.SharedKernel.Exceptions;
using OGA.DomainBase.Models;

namespace OGA.DomainBase.SampleUsage
{
    /* Persistence of this domain class requires a configuration mapping for EF to properly handle the contained value objects of this class.
     * Refer to the this link for mapping of owned types: https://docs.microsoft.com/en-us/ef/core/modeling/owned-entities#collections-of-owned-types
     * Here is a sample mapping for this domain class:
            public class cSampleOwnerEntityMapConfig : IEntityTypeConfiguration<cSampleOwnerEntity>
            {
                public void Configure(EntityTypeBuilder<cSampleOwnerEntity> builder)
                {
                    builder.ToTable("cSampleOwnerEntity");

                    builder.HasKey(o => o.Id);
                    builder.Property(o => o.Id).ValueGeneratedOnAdd().HasColumnName("Id");

                    builder.Property(en => en.LAN_SegmentId).HasColumnName("LAN_SegmentId");

                    // Do this, to have EF generate a separate table for the owned class...
                    // Address value object persisted as owned entity in EF Core 2.0
                    builder.OwnsOne(o => o.vo_sample);

                    // Do this to place the properties of the owned class in the owner table schema...
                    builder.OwnsOne(en => en.Addresses, addr =>
                    {
                        addr.Property(x => x.Address).HasColumnName("Address");
                        addr.Property(x => x.Subnet).HasColumnName("Subnet");
                        addr.Property(x => x.Mask).HasColumnName("Mask");
                        addr.Property(x => x.Is_V4).HasColumnName("Is_V4");
                    });

                    // Do this to configure mapping for the addresses collection...
                    builder.OwnsMany(p => p.Addresses, a =>
                        {
                            a.WithOwner().HasForeignKey("OwnerId");
                            a.Property<int>("Id");
                            a.HasKey("Id");
                        });
                }
            }
     */



    /// <summary>
    /// Represents a sample owner object that can be copied and implemented.
    /// This class type owns a value object.
    /// </summary>
    public class cSampleOwnerEntity<TId> : OGA.DomainBase.Models.DomainObject<TId>, OGA.DomainBase.Models.IAggregateRoot<TId> where TId : IEquatable<TId>
    {
        #region Properties

        // Make the ID flexible at compile time.
        // It can be an Int32, Int64, Guid, or String.
        public TId LAN_SegmentId { get; private set; }

        public string MAC_ID { get; private set; }

        /// <summary>
        /// Sample owned value object implementation.
        /// </summary>
        public cItem_SampleValueObject vo_sample { get; private set; }


        /* Note, how the owned value object collection has a private instance and a readonly public getter.
         * There are methods for adding elements to the collection, which check business rules as required.
         */

        private List<cItem_SampleValueObject> _addresses;
        public ICollection<cItem_SampleValueObject> Addresses { get { return _addresses.AsReadOnly(); } }

        #endregion


        #region ctor / dtor

        /// <summary>
        /// This constructor is needed for EF functionality.
        /// </summary>
        protected cSampleOwnerEntity(): base()
        {
            // Only instanciate collections in it.

            _addresses = new List<cItem_SampleValueObject>();
        }
        /// <summary>
        /// Public constructor sample.
        /// Require elements the instance can't logically exist without.
        /// </summary>
        /// <param name="shippingAdress"></param>
        /// <param name="addresses"></param>
        public cSampleOwnerEntity(cItem_SampleValueObject vosample, IEnumerable<cItem_SampleValueObject> addresses): this()
        {
            CheckForBrokenRules(vosample, addresses);

            this.vo_sample = vosample;

            foreach (var addr in addresses)
                AddAddress(addr);
        }

        #endregion


        #region Property Accessors

        public void Set_MAC_ID(string newmac)
        {
            //...
            // Domain rules/logic for adding the OrderItem to the order
            // ...
            //
            // Throw a business rules exception if a violation occurs, like this:
            //      throw new BusinessRuleBrokenException("vo sample must be specified!");

            this.MAC_ID = newmac;
        }
        // Make the ID flexible at compile time.
        // It can be an Int32, Int64, Guid, or String.
        public void Set_LANSegment_ID(TId lanid)
        {
            //...
            // Domain rules/logic for adding the OrderItem to the order
            // ...
            //
            // Throw a business rules exception if a violation occurs, like this:
            //      throw new BusinessRuleBrokenException("vo sample must be specified!");

            this.LAN_SegmentId = lanid;
        }

        public void AddAddress(cItem_SampleValueObject address)
        {
            //...
            // Domain rules/logic for adding the OrderItem to the order
            // ...
            //
            // Throw a business rules exception if a violation occurs, like this:
            //      throw new BusinessRuleBrokenException("vo sample must be specified!");

            _addresses.Add(address);
        }
        public void AddAddress(string address, string subnet, int mask, bool is_v4)
        {
            //...
            // Domain rules/logic for adding the OrderItem to the order
            // ...
            //
            // Throw a business rules exception if a violation occurs, like this:
            //      throw new BusinessRuleBrokenException("vo sample must be specified!");

            var addr = new cItem_SampleValueObject(address, subnet, mask, is_v4);
            this.AddAddress(addr);
        }

        #endregion


        #region Private Methods

        private void CheckForBrokenRules(cItem_SampleValueObject vosample, IEnumerable<cItem_SampleValueObject> addresses)
        {
            //if (string.IsNullOrWhiteSpace(vosample))
            //    throw new BusinessRuleBrokenException("You must supply ShippingAdress!");

            if (vosample is null)
                throw new BusinessRuleBrokenException("vo sample must be specified!");

            if (addresses is null || (!addresses.Any()))
                throw new BusinessRuleBrokenException("You must supply an address!");
        }

        #endregion
    }
}
