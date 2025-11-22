using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using ReoNet.Api.Models.Auth;
using ReoNet.Api.Models;

namespace ReoNet.Api.Models;

public partial class ReonetfiDbContext : DbContext
{
    public ReonetfiDbContext()
    {
    }

    public ReonetfiDbContext(DbContextOptions<ReonetfiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccAshkha> AccAshkhas { get; set; }

    public virtual DbSet<ReonetCity> ReonetCities { get; set; }

    public virtual DbSet<ReonetCustomer> ReonetCustomers { get; set; }

    public virtual DbSet<ReonetGender> ReonetGenders { get; set; }

    public virtual DbSet<ReonetOrderDetail> ReonetOrderdetails { get; set; }

    public virtual DbSet<ReonetOrderMaster> ReonetOrdermasters { get; set; }

    public virtual DbSet<ReonetOrderStatus> ReonetOrderstatuses { get; set; }

    public virtual DbSet<ReonetPostcode> ReonetPostcodes { get; set; }

    public virtual DbSet<ReonetServices> ReonetServices { get; set; }

    public virtual DbSet<ReonetServicecategory> ReonetServicecategories { get; set; }

    public virtual DbSet<ReonetServicetype> ReonetServicetypes { get; set; }

    public virtual DbSet<ReonetSubservice> ReonetSubservices { get; set; }

    public virtual DbSet<SecFormName> SecFormNames { get; set; }

    public virtual DbSet<SecGroup> SecGroups { get; set; }

    public virtual DbSet<SecRole> SecRoles { get; set; }

    public virtual DbSet<SecRoleGroup> SecRoleGroups { get; set; }

    public virtual DbSet<SecSetting> SecSettings { get; set; }

    public virtual DbSet<Auth.SecUser> SecUsers { get; set; }

    public virtual DbSet<SecUserGroup> SecUserGroups { get; set; }

    public virtual DbSet<SecUserRoleException> SecUserRoleExceptions { get; set; }

    public virtual DbSet<SecVersion> SecVersions { get; set; }

    public virtual DbSet<SecWindowsControl> SecWindowsControls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=win5.morvahost.com,1433;Initial Catalog=reonetfi_db;User ID=reonetfi_user;Password=@RKXMSDrkxmsd12345;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("reonetfi_user");

        modelBuilder.Entity<AccAshkha>(entity =>
        {
            entity.HasKey(e => e.Srl);

            entity.ToTable("Acc_Ashkhas", "dbo");

            entity.Property(e => e.Adres1).HasMaxLength(300);
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CodeMelli).HasMaxLength(50);
            entity.Property(e => e.EconomicCode).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Ezdevaj).HasMaxLength(10);
            entity.Property(e => e.Fax).HasMaxLength(11);
            entity.Property(e => e.JavazKasbNomber).HasMaxLength(50);
            entity.Property(e => e.Mobile).HasMaxLength(11);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Ostan).HasMaxLength(50);
            entity.Property(e => e.RegisterNomber).HasMaxLength(50);
            entity.Property(e => e.SaghfEtebar).HasColumnName("Saghf_etebar");
            entity.Property(e => e.Shahr).HasMaxLength(50);
            entity.Property(e => e.Shahrestan).HasMaxLength(50);
            entity.Property(e => e.ShakhsType).HasColumnName("Shakhs_Type");
            entity.Property(e => e.Site).HasMaxLength(100);
            entity.Property(e => e.SrlAccAshkhasOnvan).HasColumnName("Srl_Acc_Ashkhas_Onvan");
            entity.Property(e => e.SrlCompany).HasColumnName("Srl_Company");
            entity.Property(e => e.SrlSubmitUser).HasColumnName("Srl_SubmitUser");
            entity.Property(e => e.SubmitDate).HasColumnType("datetime");
            entity.Property(e => e.Tavalod)
                .HasMaxLength(10)
                .HasColumnName("tavalod");
            entity.Property(e => e.Telephone1).HasMaxLength(11);
            entity.Property(e => e.Telephone2).HasMaxLength(11);
        });

        modelBuilder.Entity<ReonetCity>(entity =>
        {
            entity.HasKey(e => e.Srl);

            entity.ToTable("reonet_city", "dbo");

            entity.Property(e => e.Srl).HasColumnName("srl");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ReonetCustomer>(entity =>
        {
            entity.HasKey(e => e.Srl).HasName("PK_reonet_user");

            entity.ToTable("reonet_customer", "dbo");

            entity.Property(e => e.Srl).HasColumnName("srl");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.Commission).HasColumnName("commission");
            entity.Property(e => e.Companyname)
                .HasMaxLength(50)
                .HasColumnName("companyname");
            entity.Property(e => e.Createdate)
                .HasColumnType("datetime")
                .HasColumnName("createdate");
            entity.Property(e => e.Createuser).HasColumnName("createuser");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Family)
                .HasMaxLength(50)
                .HasColumnName("family");
            entity.Property(e => e.IsCompany).HasColumnName("is_company");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Postcode)
                .HasMaxLength(50)
                .HasColumnName("postcode");
            entity.Property(e => e.SrlCity).HasColumnName("srl_city");
            entity.Property(e => e.SrlGender)
                .HasDefaultValue(0)
                .HasComment("0,1,2")
                .HasColumnName("srl_gender");
            entity.Property(e => e.Tell1)
                .HasMaxLength(12)
                .IsFixedLength()
                .HasColumnName("tell1");
            entity.Property(e => e.Tell2)
                .HasMaxLength(12)
                .IsFixedLength()
                .HasColumnName("tell2");
        });

        modelBuilder.Entity<ReonetGender>(entity =>
        {
            entity.HasKey(e => e.Srl);

            entity.ToTable("reonet_gender", "dbo");

            entity.Property(e => e.Srl).HasColumnName("srl");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ReonetOrderDetail>(entity =>
        {
            entity.HasKey(e => e.Srl);

            entity.ToTable("reonet_orderdetail", "dbo");

            entity.Property(e => e.Srl).HasColumnName("srl");
            entity.Property(e => e.Area).HasColumnName("area");
            entity.Property(e => e.Barcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("barcode");
            entity.Property(e => e.Deliverydate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("deliverydate");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.Imageaddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("imageaddress");
            entity.Property(e => e.Iscash).HasColumnName("iscash");
            entity.Property(e => e.Itemcount).HasColumnName("itemcount");
            entity.Property(e => e.Length).HasColumnName("length");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.SrlOrdermaster).HasColumnName("srl_ordermaster");
            entity.Property(e => e.SrlOrderstatus).HasColumnName("srl_orderstatus");
            entity.Property(e => e.SrlSubservice).HasColumnName("srl_subservice");
            entity.Property(e => e.Totalprice).HasColumnName("totalprice");
            entity.Property(e => e.Width).HasColumnName("width");
        });

        modelBuilder.Entity<ReonetOrderMaster>(entity =>
        {
            entity.HasKey(e => e.Srl);

            entity.ToTable("reonet_ordermaster", "dbo");

            entity.Property(e => e.Srl).HasColumnName("srl");
            entity.Property(e => e.CreateDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("createdate");
            entity.Property(e => e.DeliveryDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("deliverydate");
            entity.Property(e => e.DeliveryPrice).HasColumnName("deliveryprice");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.OrderDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("orderdate");
            entity.Property(e => e.OrderNumber).HasColumnName("ordernumber");
            entity.Property(e => e.SrlCustomer).HasColumnName("srl_customer");
            entity.Property(e => e.TotalPrice).HasColumnName("totalprice");
        });

        modelBuilder.Entity<ReonetOrderStatus>(entity =>
        {
            entity.HasKey(e => e.Srl);

            entity.ToTable("reonet_orderstatus", "dbo");

            entity.Property(e => e.Srl).HasColumnName("srl");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.SrlServicecategory).HasColumnName("srl_servicecategory");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
        });

        modelBuilder.Entity<ReonetPostcode>(entity =>
        {
            entity.HasKey(e => e.Srl);

            entity.ToTable("reonet_postcode", "dbo");

            entity.Property(e => e.Srl).HasColumnName("srl");
            entity.Property(e => e.Code)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("code");
            entity.Property(e => e.SrlCity).HasColumnName("srl_city");
        });

        modelBuilder.Entity<ReonetServices>(entity =>
        {
            entity.HasKey(e => e.Srl);

            entity.ToTable("reonet_services", "dbo");

            entity.Property(e => e.Srl).HasColumnName("srl");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.IsService).HasColumnName("is_service");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.SrlParent).HasColumnName("srl_parent");
            entity.Property(e => e.SrlServicecategory).HasColumnName("srl_servicecategory");
            entity.Property(e => e.SrlUnit).HasColumnName("srl_unit");
        });

        modelBuilder.Entity<ReonetServicecategory>(entity =>
        {
            entity.HasKey(e => e.Srl).HasName("PK_reonet_service");

            entity.ToTable("reonet_servicecategory", "dbo");

            entity.Property(e => e.Srl).HasColumnName("srl");
            entity.Property(e => e.Createdate)
                .HasColumnType("datetime")
                .HasColumnName("createdate");
            entity.Property(e => e.Createuser).HasColumnName("createuser");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
        });

        modelBuilder.Entity<ReonetServicetype>(entity =>
        {
            entity.HasKey(e => e.Srl);

            entity.ToTable("reonet_servicetype", "dbo");

            entity.Property(e => e.Srl).HasColumnName("srl");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ReonetSubservice>(entity =>
        {
            entity.HasKey(e => e.Srl);

            entity.ToTable("reonet_subservice", "dbo");

            entity.Property(e => e.Srl).HasColumnName("srl");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Createdate)
                .HasColumnType("datetime")
                .HasColumnName("createdate");
            entity.Property(e => e.Createuser).HasColumnName("createuser");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.SrlService).HasColumnName("srl_service");
            entity.Property(e => e.SrlServicetype).HasColumnName("srl_servicetype");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
        });

        modelBuilder.Entity<SecFormName>(entity =>
        {
            entity.HasKey(e => e.Srl);

            entity.ToTable("sec_FormName", "dbo");

            entity.Property(e => e.Srl).HasColumnName("srl");
            entity.Property(e => e.Formname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("formname");
        });

        modelBuilder.Entity<SecGroup>(entity =>
        {
            entity.HasKey(e => e.Srl).HasName("PK_Group");

            entity.ToTable("sec_Group", "dbo");

            entity.Property(e => e.GroupName).HasMaxLength(50);
        });

        modelBuilder.Entity<SecRole>(entity =>
        {
            entity.HasKey(e => e.Srl).HasName("PK_Role");

            entity.ToTable("sec_Role", "dbo");

            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<SecRoleGroup>(entity =>
        {
            entity.HasKey(e => e.Srl);

            entity.ToTable("sec_RoleGroup", "dbo");

            entity.Property(e => e.SrlGroup).HasColumnName("Srl_Group");
            entity.Property(e => e.SrlRole).HasColumnName("Srl_Role");
        });

        modelBuilder.Entity<SecSetting>(entity =>
        {
            entity.HasKey(e => e.Srl);

            entity.ToTable("Sec_Setting", "dbo");

            entity.Property(e => e.Srl).HasColumnName("srl");
            entity.Property(e => e.Dis).HasMaxLength(50);
            entity.Property(e => e.ObjectName).HasMaxLength(50);
            entity.Property(e => e.ObjectType).HasMaxLength(50);
            entity.Property(e => e.PropName).HasMaxLength(50);
            entity.Property(e => e.PropValue).HasMaxLength(50);
            entity.Property(e => e.SrlSecFrom).HasColumnName("Srl_Sec_From");
            entity.Property(e => e.SrlSecGroups).HasColumnName("Srl_Sec_Groups");
            entity.Property(e => e.SrlSecUsers).HasColumnName("Srl_Sec_Users");
            entity.Property(e => e.SrlSherkatName).HasColumnName("Srl_SherkatName");
            entity.Property(e => e.SrlSubmitUser).HasColumnName("Srl_SubmitUser");
            entity.Property(e => e.SubmitDate).HasMaxLength(10);
        });

        modelBuilder.Entity<SecUser>(entity =>
        {
            entity.HasKey(e => e.Srl).HasName("PK_User");

            entity.ToTable("sec_User", "dbo");

            entity.Property(e => e.Email)
                .HasMaxLength(1)
                .HasColumnName("email");
            entity.Property(e => e.ExpirementDate)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(200);
            entity.Property(e => e.RegisterDate)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Salt).HasColumnName("salt");
            entity.Property(e => e.SrlAccAshkhas).HasColumnName("Srl_Acc_Ashkhas");
            entity.Property(e => e.SrlCustomer).HasColumnName("Srl_Customer");
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<SecUserGroup>(entity =>
        {
            entity.HasKey(e => e.Srl);

            entity.ToTable("sec_UserGroup", "dbo");

            entity.Property(e => e.SrlGroup).HasColumnName("Srl_Group");
            entity.Property(e => e.SrlUser).HasColumnName("Srl_User");
        });

        modelBuilder.Entity<SecUserRoleException>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("sec_UserRole_Exception", "dbo");

            entity.Property(e => e.SrlRole).HasColumnName("Srl_Role");
            entity.Property(e => e.SrlUser).HasColumnName("Srl_User");
        });

        modelBuilder.Entity<SecVersion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Sec_Version", "dbo");

            entity.Property(e => e.Version).HasMaxLength(50);
        });

        modelBuilder.Entity<SecWindowsControl>(entity =>
        {
            entity.HasKey(e => e.Srl);

            entity.ToTable("sec_WindowsControl", "dbo");

            entity.Property(e => e.ControlName).HasMaxLength(50);
            entity.Property(e => e.FormName).HasMaxLength(50);
            entity.Property(e => e.SrlRole).HasColumnName("Srl_Role");
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
