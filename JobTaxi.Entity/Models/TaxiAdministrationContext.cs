using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JobTaxi.Entity.Models;

public partial class TaxiAdministrationContext : DbContext
{
    public TaxiAdministrationContext()
    {
    }

    public TaxiAdministrationContext(DbContextOptions<TaxiAdministrationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CatalogAutoClass> CatalogAutoClasses { get; set; }

    public virtual DbSet<ControlsRestrictionType> ControlsRestrictionTypes { get; set; }

    public virtual DbSet<DriversConstraint> DriversConstraints { get; set; }

    public virtual DbSet<FirstDay> FirstDays { get; set; }

    public virtual DbSet<FlagsValue> FlagsValues { get; set; }

    public virtual DbSet<LocalRole> LocalRoles { get; set; }

    public virtual DbSet<LocalUser> LocalUsers { get; set; }

    public virtual DbSet<LoginFailedAttempt> LoginFailedAttempts { get; set; }

    public virtual DbSet<MenuWeb> MenuWebs { get; set; }

    public virtual DbSet<ModulesWeb> ModulesWebs { get; set; }

    public virtual DbSet<Park> Parks { get; set; }

    public virtual DbSet<ProductVersion> ProductVersions { get; set; }

    public virtual DbSet<RegistrationCall> RegistrationCalls { get; set; }

    public virtual DbSet<RestrictedEntitiesWeb> RestrictedEntitiesWebs { get; set; }

    public virtual DbSet<RightsWeb> RightsWebs { get; set; }

    public virtual DbSet<RolesWeb> RolesWebs { get; set; }

    public virtual DbSet<RulesWeb> RulesWebs { get; set; }

    public virtual DbSet<Schem> Schems { get; set; }

    public virtual DbSet<TaxiCompany> TaxiCompanies { get; set; }

    public virtual DbSet<Update> Updates { get; set; }

    public virtual DbSet<UsersErrorsLog> UsersErrorsLogs { get; set; }

    public virtual DbSet<UsersLog> UsersLogs { get; set; }

    public virtual DbSet<UsersParam> UsersParams { get; set; }

    public virtual DbSet<UsersRolesListWeb> UsersRolesListWebs { get; set; }

    public virtual DbSet<UsersWeb> UsersWebs { get; set; }

    public virtual DbSet<WithdrayMoneyWay> WithdrayMoneyWays { get; set; }

    public virtual DbSet<WorkCondition> WorkConditions { get; set; }

    public virtual DbSet<WorkSalaryCondition> WorkSalaryConditions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=OMSIT\\SQLEXPRESS;Database=taxi_administration;Trusted_Connection=True;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CatalogAutoClass>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_catalog_auto_class_ID");

            entity.ToTable("catalog_auto_class");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("active");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValueSql("('system')")
                .HasColumnName("created_by");
            entity.Property(e => e.NameView)
                .HasMaxLength(287)
                .HasComputedColumnSql("((CONVERT([nvarchar],[id])+': ')+[r_name])", false)
                .HasColumnName("name_view");
            entity.Property(e => e.RName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("r_name");
            entity.Property(e => e.RTypeChar)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("r_type_char");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValueSql("('system')")
                .HasColumnName("updated_by");
        });

        modelBuilder.Entity<ControlsRestrictionType>(entity =>
        {
            entity.HasKey(e => e.RestrictionId)
                .HasName("PK_controls_restriction_types_RESTRICTION_ID")
                .IsClustered(false);

            entity.ToTable("controls_restriction_types");

            entity.Property(e => e.RestrictionId).HasColumnName("RESTRICTION_ID");
            entity.Property(e => e.RestrictionName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("RESTRICTION_NAME");
            entity.Property(e => e.RestrictionTitle)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("RESTRICTION_TITLE");
        });

        modelBuilder.Entity<DriversConstraint>(entity =>
        {
            entity.ToTable("drivers_constraints");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValueSql("('system')")
                .HasColumnName("created_by");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValueSql("('system')")
                .HasColumnName("updated_by");
        });

        modelBuilder.Entity<FirstDay>(entity =>
        {
            entity.ToTable("first_day");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValueSql("('system')")
                .HasColumnName("created_by");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValueSql("('system')")
                .HasColumnName("updated_by");
        });

        modelBuilder.Entity<FlagsValue>(entity =>
        {
            entity.HasKey(e => e.Code)
                .HasName("PK__flags_va__AA1D4379ADF52908")
                .IsClustered(false);

            entity.ToTable("flags_values");

            entity.Property(e => e.Code)
                .ValueGeneratedNever()
                .HasColumnName("CODE");
            entity.Property(e => e.Val)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("VAL");
        });

        modelBuilder.Entity<LocalRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("local_role");

            entity.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("active");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(64)
                .HasDefaultValueSql("('system')")
                .HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("description");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ip4)
                .HasDefaultValueSql("((2130706433))")
                .HasColumnName("ip4");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(64)
                .HasDefaultValueSql("('system')")
                .HasColumnName("updated_by");
        });

        modelBuilder.Entity<LocalUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("local_user");

            entity.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("active");
            entity.Property(e => e.ConfNumber)
                .HasMaxLength(200)
                .HasColumnName("conf_number");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(64)
                .HasDefaultValueSql("('system')")
                .HasColumnName("created_by");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(200)
                .HasColumnName("first_name");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Ip4)
                .HasDefaultValueSql("((2130706433))")
                .HasColumnName("ip4");
            entity.Property(e => e.LastName)
                .HasMaxLength(200)
                .HasColumnName("last_name");
            entity.Property(e => e.Login)
                .HasMaxLength(200)
                .HasColumnName("login");
            entity.Property(e => e.Pass)
                .HasMaxLength(200)
                .HasColumnName("pass");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(200)
                .HasColumnName("patronymic");
            entity.Property(e => e.Phone)
                .HasMaxLength(200)
                .HasColumnName("phone");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Salt)
                .HasMaxLength(200)
                .HasColumnName("salt");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(64)
                .HasDefaultValueSql("('system')")
                .HasColumnName("updated_by");
        });

        modelBuilder.Entity<LoginFailedAttempt>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK__login_fa__3214EC262454A229")
                .IsClustered(false);

            entity.ToTable("login_failed_attempts");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.HasLoginInRegUsers).HasColumnName("HAS_LOGIN_IN_REG_USERS");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IP_ADDRESS");
            entity.Property(e => e.Login)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("LOGIN");
            entity.Property(e => e.NoteDatetime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("NOTE_DATETIME");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
        });

        modelBuilder.Entity<MenuWeb>(entity =>
        {
            entity.HasKey(e => e.MenuId)
                .HasName("PK__menu_web__6C47297844DF8433")
                .IsClustered(false);

            entity.ToTable("menu_web");

            entity.Property(e => e.MenuId).HasColumnName("MENU_ID");
            entity.Property(e => e.ChiefId).HasColumnName("CHIEF_ID");
            entity.Property(e => e.IsAdmin).HasColumnName("IS_ADMIN");
            entity.Property(e => e.Link)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("LINK");
            entity.Property(e => e.MenuTitle)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("MENU_TITLE");
            entity.Property(e => e.ModuleId).HasColumnName("MODULE_ID");

            entity.HasOne(d => d.Chief).WithMany(p => p.InverseChief)
                .HasForeignKey(d => d.ChiefId)
                .HasConstraintName("FK_menu_web_CHIEF_ID");

            entity.HasOne(d => d.Module).WithMany(p => p.MenuWebs)
                .HasForeignKey(d => d.ModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_menu_web_MODULE_ID");
        });

        modelBuilder.Entity<ModulesWeb>(entity =>
        {
            entity.HasKey(e => e.ModuleId)
                .HasName("PK__modules___238A8247E6633DD1")
                .IsClustered(false);

            entity.ToTable("modules_web");

            entity.Property(e => e.ModuleId).HasColumnName("MODULE_ID");
            entity.Property(e => e.IsAdmin).HasColumnName("IS_ADMIN");
            entity.Property(e => e.ModuleDescription)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("MODULE_DESCRIPTION");
            entity.Property(e => e.ModuleName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("MODULE_NAME");
        });

        modelBuilder.Entity<Park>(entity =>
        {
            entity.ToTable("parks");

            entity.HasIndex(e => e.ParkGuid, "UQ_park_guid").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.AddressLatitude)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("address_latitude");
            entity.Property(e => e.AddressLongitude)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("address_longitude");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValueSql("('system')")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedUserId)
                .HasDefaultValueSql("((1))")
                .HasColumnName("CREATED_USER_ID");
            entity.Property(e => e.Deposit)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("deposit");
            entity.Property(e => e.DepositRet)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("deposit_ret");
            entity.Property(e => e.FirstDayId).HasColumnName("first_day_id");
            entity.Property(e => e.GasThrowTaxometr).HasColumnName("gas_throw_taxometr");
            entity.Property(e => e.Inspection)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("inspection");
            entity.Property(e => e.Insurance).HasColumnName("insurance");
            entity.Property(e => e.Ip4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("((2130706433))")
                .HasColumnName("ip4");
            entity.Property(e => e.MinRentalPeriod)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("min_rental_period");
            entity.Property(e => e.ParkAddress)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("park_address");
            entity.Property(e => e.ParkGuid)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("park_guid");
            entity.Property(e => e.ParkName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("park_name");
            entity.Property(e => e.ParkPercent).HasColumnName("park_percent");
            entity.Property(e => e.Penalties)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("penalties");
            entity.Property(e => e.Ransom).HasColumnName("ransom");
            entity.Property(e => e.RentalWriteOffTime)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("rental_write_off_time");
            entity.Property(e => e.SelfEmployed).HasColumnName("self_employed");
            entity.Property(e => e.SelfEmployedSum)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("self_employed_sum");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValueSql("('system')")
                .HasColumnName("updated_by");
            entity.Property(e => e.Waybills)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("waybills");
            entity.Property(e => e.WithdrawMoney).HasColumnName("withdraw_money");
            entity.Property(e => e.WithdrawMoneyId).HasColumnName("withdraw_money_id");
            entity.Property(e => e.WorkRadius)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("work_radius");
            entity.Property(e => e.YandexTaxoparkId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("yandex_taxopark_id");

            entity.HasOne(d => d.CreatedUser).WithMany(p => p.Parks)
                .HasForeignKey(d => d.CreatedUserId)
                .HasConstraintName("FK_parks_users_web");

            entity.HasOne(d => d.FirstDay).WithMany(p => p.Parks)
                .HasForeignKey(d => d.FirstDayId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_parks_first_day");

            entity.HasOne(d => d.WithdrawMoneyNavigation).WithMany(p => p.Parks)
                .HasForeignKey(d => d.WithdrawMoneyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_parks_withdraw_money_ways");
        });

        modelBuilder.Entity<ProductVersion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("product_version");

            entity.HasIndex(e => new { e.EntityCode, e.CurrentVersion }, "uq__product_version").IsUnique();

            entity.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("active");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValueSql("('system')")
                .HasColumnName("created_by");
            entity.Property(e => e.CurrentVersion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("current_version");
            entity.Property(e => e.EntityCode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("entity_code");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValueSql("('system')")
                .HasColumnName("updated_by");
        });

        modelBuilder.Entity<RegistrationCall>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_registration_calls_ID");

            entity.ToTable("registration_calls");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Fam)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("fam");
            entity.Property(e => e.Im)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("im");
            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ip");
            entity.Property(e => e.IsAgreed).HasColumnName("is_agreed");
            entity.Property(e => e.Ot)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("ot");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("updated_by");
        });

        modelBuilder.Entity<RestrictedEntitiesWeb>(entity =>
        {
            entity.HasKey(e => e.EntityId)
                .HasName("PK__restrict__2E73818A0C46DBD0")
                .IsClustered(false);

            entity.ToTable("restricted_entities_web");

            entity.Property(e => e.EntityId).HasColumnName("ENTITY_ID");
            entity.Property(e => e.EntityDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ENTITY_DESCRIPTION");
            entity.Property(e => e.EntityName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("ENTITY_NAME");
            entity.Property(e => e.ModuleId).HasColumnName("MODULE_ID");

            entity.HasOne(d => d.Module).WithMany(p => p.RestrictedEntitiesWebs)
                .HasForeignKey(d => d.ModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_restricted_entities_web_MODULE_ID");
        });

        modelBuilder.Entity<RightsWeb>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK__rights_w__3214EC260CF32F38")
                .IsClustered(false);

            entity.ToTable("rights_web");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IsAdmin).HasColumnName("IS_ADMIN");
            entity.Property(e => e.RoleId).HasColumnName("ROLE_ID");
            entity.Property(e => e.RuleId).HasColumnName("RULE_ID");

            entity.HasOne(d => d.Role).WithMany(p => p.RightsWebs)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_rights_web_ROLE_ID");

            entity.HasOne(d => d.Rule).WithMany(p => p.RightsWebs)
                .HasForeignKey(d => d.RuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_rights_web_RULE_ID");
        });

        modelBuilder.Entity<RolesWeb>(entity =>
        {
            entity.HasKey(e => e.RoleId)
                .HasName("PK__roles_we__5AC4D223CC85EC9A")
                .IsClustered(false);

            entity.ToTable("roles_web");

            entity.Property(e => e.RoleId).HasColumnName("ROLE_ID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("ROLE_NAME");
        });

        modelBuilder.Entity<RulesWeb>(entity =>
        {
            entity.HasKey(e => e.RuleId)
                .HasName("PK__rules_we__E103520D7799F781")
                .IsClustered(false);

            entity.ToTable("rules_web");

            entity.Property(e => e.RuleId).HasColumnName("RULE_ID");
            entity.Property(e => e.EntityId).HasColumnName("ENTITY_ID");
            entity.Property(e => e.IsAdmin).HasColumnName("IS_ADMIN");
            entity.Property(e => e.ModuleId).HasColumnName("MODULE_ID");
            entity.Property(e => e.RestrictDefaultValue)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("RESTRICT_DEFAULT_VALUE");
            entity.Property(e => e.RestrictTypeId).HasColumnName("RESTRICT_TYPE_ID");
            entity.Property(e => e.RuleName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("RULE_NAME");

            entity.HasOne(d => d.Entity).WithMany(p => p.RulesWebs)
                .HasForeignKey(d => d.EntityId)
                .HasConstraintName("FK_rules_web_ENTITY_ID");

            entity.HasOne(d => d.Module).WithMany(p => p.RulesWebs)
                .HasForeignKey(d => d.ModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_rules_web_MODULE_ID");

            entity.HasOne(d => d.RestrictType).WithMany(p => p.RulesWebs)
                .HasForeignKey(d => d.RestrictTypeId)
                .HasConstraintName("FK_rules_web_RESTRICT_TYPE_ID");
        });

        modelBuilder.Entity<Schem>(entity =>
        {
            entity.ToTable("schems");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValueSql("('system')")
                .HasColumnName("created_by");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValueSql("('system')")
                .HasColumnName("updated_by");
        });

        modelBuilder.Entity<TaxiCompany>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("taxi_company");

            entity.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("active");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(64)
                .HasDefaultValueSql("('system')")
                .HasColumnName("created_by");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Ip4)
                .HasDefaultValueSql("((2130706433))")
                .HasColumnName("ip4");
            entity.Property(e => e.TxAdress)
                .HasMaxLength(512)
                .HasDefaultValueSql("('')")
                .HasColumnName("tx_adress");
            entity.Property(e => e.TxDriver)
                .HasMaxLength(512)
                .HasDefaultValueSql("('')")
                .HasColumnName("tx_driver");
            entity.Property(e => e.TxName)
                .HasMaxLength(128)
                .HasDefaultValueSql("('')")
                .HasColumnName("tx_name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(64)
                .HasDefaultValueSql("('system')")
                .HasColumnName("updated_by");
        });

        modelBuilder.Entity<Update>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk__updates");

            entity.ToTable("updates");

            entity.HasIndex(e => new { e.Dst, e.ResultVersion, e.ResultStatus }, "uq__updates").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("active");
            entity.Property(e => e.Author)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("author");
            entity.Property(e => e.BaseVersion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("base_version");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValueSql("('system')")
                .HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasMaxLength(1024)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Dst)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("dst");
            entity.Property(e => e.ResultStatus)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("result_status");
            entity.Property(e => e.ResultVersion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("result_version");
            entity.Property(e => e.Src)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("src");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValueSql("('system')")
                .HasColumnName("updated_by");
        });

        modelBuilder.Entity<UsersErrorsLog>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK__users_er__3214EC26FEB9CF3B")
                .IsClustered(false);

            entity.ToTable("users_errors_log");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("DATE_ADDED");
            entity.Property(e => e.ErrorInfo)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("ERROR_INFO");
            entity.Property(e => e.FilterData)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("FILTER_DATA");
            entity.Property(e => e.PageUrl)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("PAGE_URL");
            entity.Property(e => e.RoleId).HasColumnName("ROLE_ID");
            entity.Property(e => e.UserId).HasColumnName("USER_ID");

            entity.HasOne(d => d.Role).WithMany(p => p.UsersErrorsLogs)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_users_errors_log_ROLE_ID");

            entity.HasOne(d => d.User).WithMany(p => p.UsersErrorsLogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_users_errors_log_USER_ID");
        });

        modelBuilder.Entity<UsersLog>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK__users_lo__3214EC26F882D782")
                .IsClustered(false);

            entity.ToTable("users_log");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreateFlag).HasColumnName("CREATE_FLAG");
            entity.Property(e => e.DelFlag).HasColumnName("DEL_FLAG");
            entity.Property(e => e.FieldName)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("FIELD_NAME");
            entity.Property(e => e.NewValue)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("NEW_VALUE");
            entity.Property(e => e.NoteDate)
                .HasColumnType("date")
                .HasColumnName("NOTE_DATE");
            entity.Property(e => e.ObjectId).HasColumnName("OBJECT_ID");
            entity.Property(e => e.OldValue)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("OLD_VALUE");
            entity.Property(e => e.PaketCondition)
                .HasMaxLength(350)
                .IsUnicode(false)
                .HasColumnName("PAKET_CONDITION");
            entity.Property(e => e.TableName)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("TABLE_NAME");
            entity.Property(e => e.UserId).HasColumnName("USER_ID");

            entity.HasOne(d => d.User).WithMany(p => p.UsersLogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_users_log_USER_ID");
        });

        modelBuilder.Entity<UsersParam>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK__users_pa__3214EC262E24686B")
                .IsClustered(false);

            entity.ToTable("users_params");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Park)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PARK");
            entity.Property(e => e.Phone)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PHONE");
            entity.Property(e => e.RoleId).HasColumnName("ROLE_ID");
            entity.Property(e => e.UserId).HasColumnName("USER_ID");
        });

        modelBuilder.Entity<UsersRolesListWeb>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK__users_ro__3214EC267E4481E8")
                .IsClustered(false);

            entity.ToTable("users_roles_list_web");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.RoleId).HasColumnName("ROLE_ID");
            entity.Property(e => e.UserId).HasColumnName("USER_ID");
        });

        modelBuilder.Entity<UsersWeb>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK__users_we__3214EC26CD5B191D")
                .IsClustered(false);

            entity.ToTable("users_web");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AuthId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("AUTH_ID");
            entity.Property(e => e.CreationDate)
                .HasColumnType("date")
                .HasColumnName("CREATION_DATE");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Fam)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("FAM");
            entity.Property(e => e.Im)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("IM");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("((1))")
                .HasColumnName("IS_ACTIVE");
            entity.Property(e => e.LastVisit)
                .HasColumnType("datetime")
                .HasColumnName("LAST_VISIT");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LOGIN");
            entity.Property(e => e.Ot)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("OT");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.RoleIdVisit).HasColumnName("ROLE_ID_VISIT");

            entity.HasOne(d => d.RoleIdVisitNavigation).WithMany(p => p.UsersWebs)
                .HasForeignKey(d => d.RoleIdVisit)
                .HasConstraintName("FK_users_web_ROLE_ID_VISIT");
        });

        modelBuilder.Entity<WithdrayMoneyWay>(entity =>
        {
            entity.ToTable("withdray_money_ways");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValueSql("('system')")
                .HasColumnName("created_by");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValueSql("('system')")
                .HasColumnName("updated_by");
        });

        modelBuilder.Entity<WorkCondition>(entity =>
        {
            entity.ToTable("work_conditions");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValueSql("('system')")
                .HasColumnName("created_by");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValueSql("('system')")
                .HasColumnName("updated_by");
        });

        modelBuilder.Entity<WorkSalaryCondition>(entity =>
        {
            entity.ToTable("work_salary_conditions");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValueSql("('system')")
                .HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.ParkId).HasColumnName("park_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasDefaultValueSql("('system')")
                .HasColumnName("updated_by");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
