using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Data.Mapping.Customers
{
   public class CustomerMap:NopEntityTypeConfiguration<Customer>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer));
            builder.HasKey(customer => customer.Id);
            builder.Property(customer => customer.Name).IsRequired().HasMaxLength(100);
            builder.Property(customer => customer.Email).IsRequired().HasMaxLength(50);
            builder.Property(customer => customer.DepartMentId).IsRequired();
            builder.Property(customer => customer.Telephone).IsRequired().HasMaxLength(11);
            builder.Property(customer => customer.UserName).IsRequired().HasMaxLength(200);
            builder.Property(customer => customer.PassWord).IsRequired().HasMaxLength(50);
            base.Configure(builder);
        }

        #endregion
    }
}
