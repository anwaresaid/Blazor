using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OmnitroTool.Server.Models
{
    public partial class omniservicesintContext : DbContext
    {
        public omniservicesintContext()
        {
        }

        public omniservicesintContext(DbContextOptions<omniservicesintContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BaseTransfers> BaseTransfers { get; set; }
        public virtual DbSet<BillingSnapshots> BillingSnapshots { get; set; }
        public virtual DbSet<CustomerAddresses> CustomerAddresses { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<DbMetadata> DbMetadata { get; set; }
        public virtual DbSet<Integrations> Integrations { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<ProductBarcodes> ProductBarcodes { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ReceivingOrderLineItems> ReceivingOrderLineItems { get; set; }
        public virtual DbSet<ReceivingOrders> ReceivingOrders { get; set; }
        public virtual DbSet<ReturnLineItemImages> ReturnLineItemImages { get; set; }
        public virtual DbSet<ReturnLineItemShippingAddresses> ReturnLineItemShippingAddresses { get; set; }
        public virtual DbSet<ReturnLineItemShippings> ReturnLineItemShippings { get; set; }
        public virtual DbSet<ReturnLineItems> ReturnLineItems { get; set; }
        public virtual DbSet<Returns> Returns { get; set; }
        public virtual DbSet<SalesOrderAddresses> SalesOrderAddresses { get; set; }
        public virtual DbSet<SalesOrderLineItems> SalesOrderLineItems { get; set; }
        public virtual DbSet<SalesOrders> SalesOrders { get; set; }
        public virtual DbSet<Tenants> Tenants { get; set; }
        public virtual DbSet<UsageSnapshots> UsageSnapshots { get; set; }
        public virtual DbSet<WayBills> WayBills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=omniservices-int;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseTransfers>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CarriageTransferShipmentDate).HasColumnName("CarriageTransfer_ShipmentDate");

                entity.Property(e => e.Discriminator).IsRequired();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.BaseTransfers)
                    .HasForeignKey<BaseTransfers>(d => d.Id);
            });

            modelBuilder.Entity<BillingSnapshots>(entity =>
            {
                entity.HasIndex(e => new { e.TenantId, e.Category, e.Unit, e.PeriodStartDate, e.PeriodEndDate })
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Charges).HasColumnType("decimal(19, 4)");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.BillingSnapshots)
                    .HasForeignKey(d => d.TenantId);
            });

            modelBuilder.Entity<CustomerAddresses>(entity =>
            {
                entity.HasIndex(e => e.CustomerId);

                entity.HasIndex(e => e.ReferenceNumber)
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BaseAddressAddressOne).HasColumnName("BaseAddress_AddressOne");

                entity.Property(e => e.BaseAddressAddressTwo).HasColumnName("BaseAddress_AddressTwo");

                entity.Property(e => e.BaseAddressCity).HasColumnName("BaseAddress_City");

                entity.Property(e => e.BaseAddressCountry).HasColumnName("BaseAddress_Country");

                entity.Property(e => e.BaseAddressDistrict).HasColumnName("BaseAddress_District");

                entity.Property(e => e.BaseAddressPostalCode).HasColumnName("BaseAddress_PostalCode");

                entity.Property(e => e.FullAddress).HasComputedColumnSql("(((((((((([BaseAddress_AddressOne]+' ')+isnull([BaseAddress_AddressTwo],''))+' ')+isnull([BaseAddress_District],''))+' ')+[BaseAddress_City])+' ')+[BaseAddress_Country])+' ')+[BaseAddress_PostalCode])");

                entity.Property(e => e.FullName).HasComputedColumnSql("(([FirstName]+' ')+[LastName])");

                entity.Property(e => e.ReferenceNumber).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerAddresses)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasIndex(e => e.ReferenceNumber)
                    .IsUnique();

                entity.HasIndex(e => e.TenantId);

                entity.HasIndex(e => new { e.Email, e.TenantId })
                    .IsUnique()
                    .HasFilter("([Email] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FullName).HasComputedColumnSql("(([FirstName]+' ')+[LastName])");

                entity.Property(e => e.ReferenceNumber).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DbMetadata>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("__dbMetadata");

                entity.Property(e => e.Hash).IsRequired();
            });

            modelBuilder.Entity<Integrations>(entity =>
            {
                entity.HasIndex(e => e.CustomerCliendId)
                    .IsUnique()
                    .HasFilter("([CustomerCliendId] IS NOT NULL)");

                entity.HasIndex(e => e.TenantId);

                entity.HasIndex(e => new { e.Name, e.TenantId })
                    .IsUnique()
                    .HasFilter("([Name] IS NOT NULL)");

                entity.HasIndex(e => new { e.ShopLink, e.TenantId })
                    .IsUnique()
                    .HasFilter("([ShopLink] IS NOT NULL)");

                entity.HasIndex(e => new { e.TicimaxIntegrationShopLink, e.TenantId })
                    .IsUnique()
                    .HasFilter("([TicimaxIntegration_ShopLink] IS NOT NULL)");

                entity.HasIndex(e => new { e.WooCommerceIntegrationShopLink, e.TenantId })
                    .IsUnique()
                    .HasFilter("([WooCommerceIntegration_ShopLink] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Apipassword).HasColumnName("APIPassword");

                entity.Property(e => e.Discriminator).IsRequired();

                entity.Property(e => e.FtpIntegrationDetailsBarcodeKey).HasColumnName("FtpIntegrationDetails_BarcodeKey");

                entity.Property(e => e.FtpIntegrationDetailsCategoryKey).HasColumnName("FtpIntegrationDetails_CategoryKey");

                entity.Property(e => e.FtpIntegrationDetailsCreatedAtKey).HasColumnName("FtpIntegrationDetails_CreatedAtKey");

                entity.Property(e => e.FtpIntegrationDetailsImageUrlKey).HasColumnName("FtpIntegrationDetails_ImageUrlKey");

                entity.Property(e => e.FtpIntegrationDetailsPriceKey).HasColumnName("FtpIntegrationDetails_PriceKey");

                entity.Property(e => e.FtpIntegrationDetailsSalePriceKey).HasColumnName("FtpIntegrationDetails_SalePriceKey");

                entity.Property(e => e.FtpIntegrationDetailsSkukey).HasColumnName("FtpIntegrationDetails_SKUKey");

                entity.Property(e => e.FtpIntegrationDetailsSubBarcodesKey).HasColumnName("FtpIntegrationDetails_SubBarcodesKey");

                entity.Property(e => e.FtpIntegrationDetailsTaxRatioKey).HasColumnName("FtpIntegrationDetails_TaxRatioKey");

                entity.Property(e => e.FtpIntegrationDetailsTitleKey).HasColumnName("FtpIntegrationDetails_TitleKey");

                entity.Property(e => e.FtpIntegrationDetailsUpdatedAtKey).HasColumnName("FtpIntegrationDetails_UpdatedAtKey");

                entity.Property(e => e.IsCoDactive).HasColumnName("IsCoDActive");

                entity.Property(e => e.TicimaxIntegrationShopLink).HasColumnName("TicimaxIntegration_ShopLink");

                entity.Property(e => e.WooCommerceIntegrationShopLink).HasColumnName("WooCommerceIntegration_ShopLink");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.Integrations)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasIndex(e => e.TenantId);

                entity.HasIndex(e => new { e.Sku, e.TenantId })
                    .IsUnique()
                    .HasFilter("([SKU] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.PieceHeightType).HasColumnName("PieceHeight_Type");

                entity.Property(e => e.PieceHeightValue)
                    .HasColumnName("PieceHeight_Value")
                    .HasColumnType("decimal(19, 4)");

                entity.Property(e => e.PieceLengthType).HasColumnName("PieceLength_Type");

                entity.Property(e => e.PieceLengthValue)
                    .HasColumnName("PieceLength_Value")
                    .HasColumnType("decimal(19, 4)");

                entity.Property(e => e.PieceWeightType).HasColumnName("PieceWeight_Type");

                entity.Property(e => e.PieceWeightValue)
                    .HasColumnName("PieceWeight_Value")
                    .HasColumnType("decimal(19, 4)");

                entity.Property(e => e.PieceWidthType).HasColumnName("PieceWidth_Type");

                entity.Property(e => e.PieceWidthValue)
                    .HasColumnName("PieceWidth_Value")
                    .HasColumnType("decimal(19, 4)");

                entity.Property(e => e.Sku).HasColumnName("SKU");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Products)
                    .WithOne(p => p.Inventory)
                    .HasPrincipalKey<Products>(p => new { p.Sku, p.TenantId })
                    .HasForeignKey<Inventory>(d => new { d.Sku, d.TenantId });
            });

            modelBuilder.Entity<ProductBarcodes>(entity =>
            {
                entity.HasIndex(e => e.ProductId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Sku).HasColumnName("SKU");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductBarcodes)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasIndex(e => e.IntegrationId);

                entity.HasIndex(e => new { e.Sku, e.TenantId })
                    .HasName("AK_Products_SKU_TenantId")
                    .IsUnique();

                entity.HasIndex(e => new { e.TenantId, e.Sku })
                    .HasName("AK_Products_TenantId_SKU")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Price).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.SalePrice).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasColumnName("SKU");

                entity.Property(e => e.TaxRatio).HasColumnType("decimal(19, 4)");

                entity.HasOne(d => d.Integration)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IntegrationId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ReceivingOrderLineItems>(entity =>
            {
                entity.HasIndex(e => e.ReceivingOrderId);

                entity.HasIndex(e => new { e.TenantId, e.Sku });

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasColumnName("SKU");

                entity.HasOne(d => d.ReceivingOrder)
                    .WithMany(p => p.ReceivingOrderLineItems)
                    .HasForeignKey(d => d.ReceivingOrderId);

                entity.HasOne(d => d.Products)
                    .WithMany(p => p.ReceivingOrderLineItems)
                    .HasPrincipalKey(p => new { p.TenantId, p.Sku })
                    .HasForeignKey(d => new { d.TenantId, d.Sku })
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ReceivingOrders>(entity =>
            {
                entity.HasIndex(e => e.IntegrationId);

                entity.HasIndex(e => new { e.TenantId, e.ReferenceNumber })
                    .IsUnique()
                    .HasFilter("([ReferenceNumber] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Integration)
                    .WithMany(p => p.ReceivingOrders)
                    .HasForeignKey(d => d.IntegrationId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.ReceivingOrders)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ReturnLineItemImages>(entity =>
            {
                entity.HasIndex(e => e.ReturnLineItemId);

                entity.HasIndex(e => e.ReturnLineItemId1);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.ReturnLineItem)
                    .WithMany(p => p.ReturnLineItemImagesReturnLineItem)
                    .HasForeignKey(d => d.ReturnLineItemId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.ReturnLineItemId1Navigation)
                    .WithMany(p => p.ReturnLineItemImagesReturnLineItemId1Navigation)
                    .HasForeignKey(d => d.ReturnLineItemId1);
            });

            modelBuilder.Entity<ReturnLineItemShippingAddresses>(entity =>
            {
                entity.HasIndex(e => e.ReferenceNumber)
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BaseAddressAddressOne).HasColumnName("BaseAddress_AddressOne");

                entity.Property(e => e.BaseAddressAddressTwo).HasColumnName("BaseAddress_AddressTwo");

                entity.Property(e => e.BaseAddressCity).HasColumnName("BaseAddress_City");

                entity.Property(e => e.BaseAddressCountry).HasColumnName("BaseAddress_Country");

                entity.Property(e => e.BaseAddressDistrict).HasColumnName("BaseAddress_District");

                entity.Property(e => e.BaseAddressPostalCode).HasColumnName("BaseAddress_PostalCode");

                entity.Property(e => e.FullAddress).HasComputedColumnSql("(((((((((([BaseAddress_AddressOne]+' ')+isnull([BaseAddress_AddressTwo],''))+' ')+isnull([BaseAddress_District],''))+' ')+[BaseAddress_City])+' ')+[BaseAddress_Country])+' ')+[BaseAddress_PostalCode])");

                entity.Property(e => e.FullName).HasComputedColumnSql("(([FirstName]+' ')+[LastName])");

                entity.Property(e => e.ReferenceNumber).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.ReturnLineItemShippingAddresses)
                    .HasForeignKey<ReturnLineItemShippingAddresses>(d => d.Id);
            });

            modelBuilder.Entity<ReturnLineItemShippings>(entity =>
            {
                entity.HasIndex(e => e.CustomerId);

                entity.HasIndex(e => e.ReturnLineItemId)
                    .IsUnique()
                    .HasFilter("([ReturnLineItemId] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ReturnLineItemShippings)
                    .HasForeignKey(d => d.CustomerId);

                entity.HasOne(d => d.ReturnLineItem)
                    .WithOne(p => p.ReturnLineItemShippings)
                    .HasForeignKey<ReturnLineItemShippings>(d => d.ReturnLineItemId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ReturnLineItems>(entity =>
            {
                entity.HasIndex(e => e.CustomerId);

                entity.HasIndex(e => e.ReturnId);

                entity.HasIndex(e => e.SalesOrderLineItemId);

                entity.HasIndex(e => new { e.TenantId, e.Sku });

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasColumnName("SKU");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ReturnLineItems)
                    .HasForeignKey(d => d.CustomerId);

                entity.HasOne(d => d.Return)
                    .WithMany(p => p.ReturnLineItems)
                    .HasForeignKey(d => d.ReturnId);

                entity.HasOne(d => d.SalesOrderLineItem)
                    .WithMany(p => p.ReturnLineItems)
                    .HasForeignKey(d => d.SalesOrderLineItemId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Products)
                    .WithMany(p => p.ReturnLineItems)
                    .HasPrincipalKey(p => new { p.TenantId, p.Sku })
                    .HasForeignKey(d => new { d.TenantId, d.Sku })
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Returns>(entity =>
            {
                entity.HasIndex(e => e.IntegrationId);

                entity.HasIndex(e => e.ReferenceNumber)
                    .IsUnique();

                entity.HasIndex(e => e.SalesOrderId);

                entity.HasIndex(e => e.TenantId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ReferenceNumber).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Integration)
                    .WithMany(p => p.Returns)
                    .HasForeignKey(d => d.IntegrationId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.SalesOrder)
                    .WithMany(p => p.Returns)
                    .HasForeignKey(d => d.SalesOrderId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.Returns)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<SalesOrderAddresses>(entity =>
            {
                entity.HasIndex(e => e.ReferenceNumber)
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BaseAddressAddressOne).HasColumnName("BaseAddress_AddressOne");

                entity.Property(e => e.BaseAddressAddressTwo).HasColumnName("BaseAddress_AddressTwo");

                entity.Property(e => e.BaseAddressCity).HasColumnName("BaseAddress_City");

                entity.Property(e => e.BaseAddressCountry).HasColumnName("BaseAddress_Country");

                entity.Property(e => e.BaseAddressDistrict).HasColumnName("BaseAddress_District");

                entity.Property(e => e.BaseAddressPostalCode).HasColumnName("BaseAddress_PostalCode");

                entity.Property(e => e.FullAddress).HasComputedColumnSql("(((((((((([BaseAddress_AddressOne]+' ')+isnull([BaseAddress_AddressTwo],''))+' ')+isnull([BaseAddress_District],''))+' ')+[BaseAddress_City])+' ')+[BaseAddress_Country])+' ')+[BaseAddress_PostalCode])");

                entity.Property(e => e.FullName).HasComputedColumnSql("(([FirstName]+' ')+[LastName])");

                entity.Property(e => e.ReferenceNumber).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<SalesOrderLineItems>(entity =>
            {
                entity.HasIndex(e => e.SalesOrderId);

                entity.HasIndex(e => new { e.TenantId, e.Sku });

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ProductPrice).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.ProductSalePrice).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.ProductTaxRatio).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasColumnName("SKU");

                entity.HasOne(d => d.SalesOrder)
                    .WithMany(p => p.SalesOrderLineItems)
                    .HasForeignKey(d => d.SalesOrderId);

                entity.HasOne(d => d.Products)
                    .WithMany(p => p.SalesOrderLineItems)
                    .HasPrincipalKey(p => new { p.TenantId, p.Sku })
                    .HasForeignKey(d => new { d.TenantId, d.Sku })
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<SalesOrders>(entity =>
            {
                entity.HasIndex(e => e.BillingAddressId);

                entity.HasIndex(e => e.CustomerId);

                entity.HasIndex(e => e.IntegrationId);

                entity.HasIndex(e => e.ShippingAddressId);

                entity.HasIndex(e => new { e.TenantId, e.ReferenceNumber })
                    .IsUnique()
                    .HasFilter("([ReferenceNumber] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.PaymentCurrency).HasColumnName("Payment_Currency");

                entity.Property(e => e.PaymentPaymentOption).HasColumnName("Payment_PaymentOption");

                entity.Property(e => e.PaymentTotalPaymentAmount)
                    .HasColumnName("Payment_TotalPaymentAmount")
                    .HasColumnType("decimal(19, 4)");

                entity.Property(e => e.VasGiftVasGiftNotes).HasColumnName("VAS_GiftVAS_GiftNotes");

                entity.Property(e => e.VasGiftVasGiftWrap).HasColumnName("VAS_GiftVAS_GiftWrap");

                entity.HasOne(d => d.BillingAddress)
                    .WithMany(p => p.SalesOrdersBillingAddress)
                    .HasForeignKey(d => d.BillingAddressId);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.SalesOrders)
                    .HasForeignKey(d => d.CustomerId);

                entity.HasOne(d => d.Integration)
                    .WithMany(p => p.SalesOrders)
                    .HasForeignKey(d => d.IntegrationId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.ShippingAddress)
                    .WithMany(p => p.SalesOrdersShippingAddress)
                    .HasForeignKey(d => d.ShippingAddressId);

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.SalesOrders)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Tenants>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .IsUnique()
                    .HasFilter("([Name] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CompanyAddress).HasColumnName("Company_Address");

                entity.Property(e => e.CompanyPhone).HasColumnName("Company_Phone");

                entity.Property(e => e.CompanyTaxAdministration).HasColumnName("Company_TaxAdministration");

                entity.Property(e => e.CompanyTaxNo).HasColumnName("Company_TaxNo");

                entity.Property(e => e.CompanyTitle).HasColumnName("Company_Title");

                entity.Property(e => e.TenantLastSyncTimeInventoryLastSyncAt).HasColumnName("TenantLastSyncTime_InventoryLastSyncAt");

                entity.Property(e => e.TenantLastSyncTimeProductCatalogLastSyncAt).HasColumnName("TenantLastSyncTime_ProductCatalogLastSyncAt");

                entity.Property(e => e.TenantLastSyncTimeReceivingOrdersLastSyncAt).HasColumnName("TenantLastSyncTime_ReceivingOrdersLastSyncAt");

                entity.Property(e => e.TenantLastSyncTimeSalesOrdersLastSyncAt).HasColumnName("TenantLastSyncTime_SalesOrdersLastSyncAt");

                entity.Property(e => e.TenantLastSyncTimeSalesOrdersLastSyncAtFromWms).HasColumnName("TenantLastSyncTime_SalesOrdersLastSyncAtFromWMS");
            });

            modelBuilder.Entity<UsageSnapshots>(entity =>
            {
                entity.HasIndex(e => new { e.TenantId, e.Category, e.Unit, e.Period })
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Value).HasColumnType("decimal(19, 4)");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.UsageSnapshots)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<WayBills>(entity =>
            {
                entity.HasIndex(e => e.ReceivingOrderId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.ReceivingOrder)
                    .WithMany(p => p.WayBills)
                    .HasForeignKey(d => d.ReceivingOrderId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
