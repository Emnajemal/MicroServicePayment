using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MicroServicePayment.Models;

public partial class PayDbContext : DbContext
{
    public PayDbContext()
    {
    }

    public PayDbContext(DbContextOptions<PayDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Accountbalance> Accountbalances { get; set; }

    public virtual DbSet<Accountcontract> Accountcontracts { get; set; }

    public virtual DbSet<Entity> Entities { get; set; }

    public virtual DbSet<Nternalaccount> Nternalaccounts { get; set; }

    public virtual DbSet<Paymentcard> Paymentcards { get; set; }

    public virtual DbSet<Productservice> Productservices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("Data Source=10.250.0.130:1521/DBSTB;User Id=cartdef_digi;Password=sa;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("CARTDEF_DIGI");

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Pk).HasName("P_ACCOUNT");

            entity.ToTable("ACCOUNT");

            entity.HasIndex(e => new { e.Productcode, e.Pk }, "IDX_PRODUCTCODE");

            entity.HasIndex(e => e.Accountnumber, "IX_ACCOUNTNUMBER");

            entity.HasIndex(e => e.Unitcode, "IX_ACCOUNTUNIT9835");

            entity.HasIndex(e => e.Unitpk, "IX_ACCOUNTUNITPK2");

            entity.HasIndex(e => e.Code, "U_ACCOUNTCODE_").IsUnique();

            entity.HasIndex(e => e.Rib, "U_ACCOUNTRIB_").IsUnique();

            entity.Property(e => e.Pk)
                .HasPrecision(19)
                .ValueGeneratedNever()
                .HasColumnName("PK_");
            entity.Property(e => e.Accountnumber)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ACCOUNTNUMBER_");
            entity.Property(e => e.Activationdate)
                .HasColumnType("DATE")
                .HasColumnName("ACTIVATIONDATE_");
            entity.Property(e => e.Active)
                .HasPrecision(1)
                .HasColumnName("ACTIVE_");
            entity.Property(e => e.Bankcode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("BANKCODE_");
            entity.Property(e => e.Bankpk)
                .HasPrecision(19)
                .HasColumnName("BANKPK_");
            entity.Property(e => e.Cdate)
                .HasPrecision(6)
                .HasColumnName("CDATE_");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CODE_");
            entity.Property(e => e.Currencycode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CURRENCYCODE_");
            entity.Property(e => e.Currencypk)
                .HasPrecision(19)
                .HasColumnName("CURRENCYPK_");
            entity.Property(e => e.Cuser)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CUSER_");
            entity.Property(e => e.Fullname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FULLNAME_");
            entity.Property(e => e.Iban)
                .HasMaxLength(34)
                .IsUnicode(false)
                .HasColumnName("IBAN_");
            entity.Property(e => e.Isinternalrib)
                .HasPrecision(1)
                .HasColumnName("ISINTERNALRIB_");
            entity.Property(e => e.Ownership)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OWNERSHIP_");
            entity.Property(e => e.Productcategorycode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PRODUCTCATEGORYCODE_");
            entity.Property(e => e.Productcode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PRODUCTCODE_");
            entity.Property(e => e.Rib)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("RIB_");
            entity.Property(e => e.Signaturetype)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("SIGNATURETYPE_");
            entity.Property(e => e.Udate)
                .HasPrecision(6)
                .HasColumnName("UDATE_");
            entity.Property(e => e.Unitcode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("UNITCODE_");
            entity.Property(e => e.Unitpk)
                .HasPrecision(19)
                .HasColumnName("UNITPK_");
            entity.Property(e => e.Uuser)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("UUSER_");
            entity.Property(e => e.Versionnum)
                .HasPrecision(10)
                .HasColumnName("VERSIONNUM_");
        });

        modelBuilder.Entity<Accountbalance>(entity =>
        {
            entity.HasKey(e => e.Pk).HasName("P_ACCOUNTBALANCE");

            entity.ToTable("ACCOUNTBALANCE");

            entity.HasIndex(e => new { e.Accountcode, e.Balancetype, e.Enddate }, "ACCBAL_IDX_9C7F0001");

            entity.HasIndex(e => e.Positiondate, "ACCBAL_PDATE");

            entity.HasIndex(e => new { e.Accountcode, e.Positiondate }, "ACCOUNTBALANCE_IDX_99340001");

            entity.HasIndex(e => new { e.Currencycode, e.Balancetype, e.Enddate }, "IDX$$_CB840001");

            entity.HasIndex(e => e.Accountpk, "IDX_ACCBALANCE_ACCOUNTPK");

            entity.HasIndex(e => e.Currencypk, "IDX_ACCBALANCE_CURRENCYPK");

            entity.HasIndex(e => new { e.Accountpk, e.Positiondate }, "INDEX_BALANCE_STBNET");

            entity.HasIndex(e => new { e.Accountcode, e.Enddate, e.Positiondate, e.Balancetype }, "INDX_BALANCE_001");

            entity.Property(e => e.Pk)
                .HasPrecision(19)
                .ValueGeneratedNever()
                .HasColumnName("PK_");
            entity.Property(e => e.Accountcode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ACCOUNTCODE_");
            entity.Property(e => e.Accountpk)
                .HasPrecision(19)
                .HasColumnName("ACCOUNTPK_");
            entity.Property(e => e.Balance)
                .HasColumnType("NUMBER(19,4)")
                .HasColumnName("BALANCE_");
            entity.Property(e => e.Balancetype)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("BALANCETYPE_");
            entity.Property(e => e.Cdate)
                .HasPrecision(6)
                .HasColumnName("CDATE_");
            entity.Property(e => e.Creditmvt)
                .HasColumnType("NUMBER(19,4)")
                .HasColumnName("CREDITMVT_");
            entity.Property(e => e.Currencycode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CURRENCYCODE_");
            entity.Property(e => e.Currencypk)
                .HasPrecision(19)
                .HasColumnName("CURRENCYPK_");
            entity.Property(e => e.Cuser)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CUSER_");
            entity.Property(e => e.Debitmvt)
                .HasColumnType("NUMBER(19,4)")
                .HasColumnName("DEBITMVT_");
            entity.Property(e => e.Enddate)
                .HasColumnType("DATE")
                .HasColumnName("ENDDATE_");
            entity.Property(e => e.Lockamount)
                .HasColumnType("NUMBER(19,4)")
                .HasColumnName("LOCKAMOUNT_");
            entity.Property(e => e.Overdraftamount)
                .HasColumnType("NUMBER(19,4)")
                .HasColumnName("OVERDRAFTAMOUNT_");
            entity.Property(e => e.Positiondate)
                .HasColumnType("DATE")
                .HasColumnName("POSITIONDATE_");
            entity.Property(e => e.Udate)
                .HasPrecision(6)
                .HasColumnName("UDATE_");
            entity.Property(e => e.Uuser)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("UUSER_");
            entity.Property(e => e.Versionnum)
                .HasPrecision(10)
                .HasColumnName("VERSIONNUM_");

            entity.HasOne(d => d.AccountpkNavigation).WithMany(p => p.Accountbalances)
                .HasForeignKey(d => d.Accountpk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("F_ANCEACCOSZH6G6");
        });

        modelBuilder.Entity<Accountcontract>(entity =>
        {
            entity.HasKey(e => e.Pk).HasName("P_ACCOUNTCONTRACT");

            entity.ToTable("ACCOUNTCONTRACT");

            entity.HasIndex(e => new { e.Status, e.Pk }, "ACCOUNTCONTRACT_STATUS");

            entity.HasIndex(e => new { e.Status, e.Accountcode }, "IDX_ACC_20200329");

            entity.HasIndex(e => e.Accountcode, "I_ACCOUNTCODE");

            entity.HasIndex(e => e.Categorie, "I_CATEGORIE");

            entity.HasIndex(e => e.Generatereleve, "I_GENRELEVE");

            entity.HasIndex(e => e.Generatesettlreport, "I_GENSETTREPORT");

            entity.HasIndex(e => e.Numcpt7, "I_NUMCPT7");

            entity.HasIndex(e => e.Accountnumber, "U_ACCOUNTCON26HOBS").IsUnique();

            entity.HasIndex(e => e.Inactivityperiodpk, "U_ACCOUNTCO_23L58W").IsUnique();

            entity.HasIndex(e => e.Accountpk, "U_ACCOUNTCO_3XFOQY").IsUnique();

            entity.HasIndex(e => e.Validationprocesspk, "U_ACCOUNTCO_XGAGB7").IsUnique();

            entity.Property(e => e.Pk)
                .HasPrecision(19)
                .ValueGeneratedNever()
                .HasColumnName("PK_");
            entity.Property(e => e.Accountcode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ACCOUNTCODE_");
            entity.Property(e => e.Accountmig)
                .HasPrecision(1)
                .HasColumnName("ACCOUNTMIG_");
            entity.Property(e => e.Accountnumber)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("ACCOUNTNUMBER_");
            entity.Property(e => e.Accountpk)
                .HasPrecision(19)
                .HasColumnName("ACCOUNTPK_");
            entity.Property(e => e.Addinfo1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ADDINFO1_");
            entity.Property(e => e.Addinfo2)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ADDINFO2_");
            entity.Property(e => e.Addinfo3)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ADDINFO3_");
            entity.Property(e => e.Addinfo4)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ADDINFO4_");
            entity.Property(e => e.Addinfo5)
                .HasColumnType("DATE")
                .HasColumnName("ADDINFO5_");
            entity.Property(e => e.Addinfo6)
                .HasColumnType("DATE")
                .HasColumnName("ADDINFO6_");
            entity.Property(e => e.Addinfo7)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ADDINFO7_");
            entity.Property(e => e.Categorie)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CATEGORIE_");
            entity.Property(e => e.Clientpouvoirpk)
                .HasPrecision(19)
                .HasColumnName("CLIENTPOUVOIRPK_");
            entity.Property(e => e.Closingdate)
                .HasColumnType("DATE")
                .HasColumnName("CLOSINGDATE_");
            entity.Property(e => e.Codebp)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("CODEBP_");
            entity.Property(e => e.Comissionaccountcode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("COMISSIONACCOUNTCODE_");
            entity.Property(e => e.Comissionaccountpk)
                .HasPrecision(19)
                .HasColumnName("COMISSIONACCOUNTPK_");
            entity.Property(e => e.Confiscated)
                .HasPrecision(1)
                .HasColumnName("CONFISCATED_");
            entity.Property(e => e.Countrybpcode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("COUNTRYBPCODE_");
            entity.Property(e => e.Countrybppk)
                .HasPrecision(19)
                .HasColumnName("COUNTRYBPPK_");
            entity.Property(e => e.Creationaccountcode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CREATIONACCOUNTCODE_");
            entity.Property(e => e.Creationaccountpk)
                .HasPrecision(19)
                .HasColumnName("CREATIONACCOUNTPK_");
            entity.Property(e => e.Dateentrypackage)
                .HasColumnType("DATE")
                .HasColumnName("DATEENTRYPACKAGE_");
            entity.Property(e => e.Davepackagecode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DAVEPACKAGECODE_");
            entity.Property(e => e.Davepackagepk)
                .HasPrecision(19)
                .HasColumnName("DAVEPACKAGEPK_");
            entity.Property(e => e.Electionpresidentielle)
                .HasPrecision(1)
                .HasColumnName("ELECTIONPRESIDENTIELLE_");
            entity.Property(e => e.Firstname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FIRSTNAME_");
            entity.Property(e => e.Freezecredit)
                .HasPrecision(1)
                .HasColumnName("FREEZECREDIT_");
            entity.Property(e => e.Freezedebit)
                .HasPrecision(1)
                .HasColumnName("FREEZEDEBIT_");
            entity.Property(e => e.Freezeregulatory)
                .HasPrecision(1)
                .HasColumnName("FREEZEREGULATORY_");
            entity.Property(e => e.Frozen)
                .HasPrecision(1)
                .HasColumnName("FROZEN_");
            entity.Property(e => e.Frozendate)
                .HasColumnType("DATE")
                .HasColumnName("FROZENDATE_");
            entity.Property(e => e.Generateafbreleve)
                .HasPrecision(1)
                .HasColumnName("GENERATEAFBRELEVE_");
            entity.Property(e => e.Generatereleve)
                .HasPrecision(1)
                .HasColumnName("GENERATERELEVE_");
            entity.Property(e => e.Generatesettlreport)
                .HasPrecision(1)
                .HasColumnName("GENERATESETTLREPORT_");
            entity.Property(e => e.Generateswiftreleve)
                .HasPrecision(1)
                .HasColumnName("GENERATESWIFTRELEVE_");
            entity.Property(e => e.Inactivecredit)
                .HasPrecision(1)
                .HasColumnName("INACTIVECREDIT_");
            entity.Property(e => e.Inactivedebit)
                .HasPrecision(1)
                .HasColumnName("INACTIVEDEBIT_");
            entity.Property(e => e.Inactivityperiodpk)
                .HasPrecision(19)
                .HasColumnName("INACTIVITYPERIODPK_");
            entity.Property(e => e.Lastname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("LASTNAME_");
            entity.Property(e => e.Linckedaccountcode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("LINCKEDACCOUNTCODE_");
            entity.Property(e => e.Linckedaccountpk)
                .HasPrecision(19)
                .HasColumnName("LINCKEDACCOUNTPK_");
            entity.Property(e => e.Linkedaccountpackage)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("LINKEDACCOUNTPACKAGE_");
            entity.Property(e => e.Locked)
                .HasPrecision(1)
                .HasColumnName("LOCKED_");
            entity.Property(e => e.Maxima)
                .HasPrecision(1)
                .HasColumnName("MAXIMA_");
            entity.Property(e => e.Numcpt7)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NUMCPT7_");
            entity.Property(e => e.Objectrelationcode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("OBJECTRELATIONCODE_");
            entity.Property(e => e.Objectrelationpk)
                .HasPrecision(19)
                .HasColumnName("OBJECTRELATIONPK_");
            entity.Property(e => e.Origincreation)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ORIGINCREATION_");
            entity.Property(e => e.Otherobjectrelation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("OTHEROBJECTRELATION_");
            entity.Property(e => e.Pendingaccountcode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PENDINGACCOUNTCODE_");
            entity.Property(e => e.Pendingaccountpk)
                .HasPrecision(19)
                .HasColumnName("PENDINGACCOUNTPK_");
            entity.Property(e => e.Settlementaccountcode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("SETTLEMENTACCOUNTCODE_");
            entity.Property(e => e.Settlementaccountpk)
                .HasPrecision(19)
                .HasColumnName("SETTLEMENTACCOUNTPK_");
            entity.Property(e => e.Status)
                .HasMaxLength(17)
                .IsUnicode(false)
                .HasColumnName("STATUS_");
            entity.Property(e => e.Swiftreleveaddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("SWIFTRELEVEADDRESS_");
            entity.Property(e => e.Swiftrelevesequence)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("SWIFTRELEVESEQUENCE_");
            entity.Property(e => e.Swiftrelevetype)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("SWIFTRELEVETYPE_");
            entity.Property(e => e.Technicalaccountcode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TECHNICALACCOUNTCODE_");
            entity.Property(e => e.Technicalaccountpk)
                .HasPrecision(19)
                .HasColumnName("TECHNICALACCOUNTPK_");
            entity.Property(e => e.Transitiondate)
                .HasPrecision(6)
                .HasColumnName("TRANSITIONDATE_");
            entity.Property(e => e.Validationprocesspk)
                .HasPrecision(19)
                .HasColumnName("VALIDATIONPROCESSPK_");

            entity.HasOne(d => d.AccountpkNavigation).WithOne(p => p.Accountcontract)
                .HasForeignKey<Accountcontract>(d => d.Accountpk)
                .HasConstraintName("F_RACTACCO_3XFOQY");

            entity.HasOne(d => d.ComissionaccountpkNavigation).WithMany(p => p.InverseComissionaccountpkNavigation)
                .HasForeignKey(d => d.Comissionaccountpk)
                .HasConstraintName("F_RACTCOMII12D20");

            entity.HasOne(d => d.LinckedaccountpkNavigation).WithMany(p => p.InverseLinckedaccountpkNavigation)
                .HasForeignKey(d => d.Linckedaccountpk)
                .HasConstraintName("F_RACTLINCXV9LCG");

            entity.HasOne(d => d.PendingaccountpkNavigation).WithMany(p => p.InversePendingaccountpkNavigation)
                .HasForeignKey(d => d.Pendingaccountpk)
                .HasConstraintName("F_RACTPENDHJD0Y7");

            entity.HasOne(d => d.TechnicalaccountpkNavigation).WithMany(p => p.InverseTechnicalaccountpkNavigation)
                .HasForeignKey(d => d.Technicalaccountpk)
                .HasConstraintName("F_RACTTECHVVE4UT");
        });

        modelBuilder.Entity<Entity>(entity =>
        {
            entity.HasKey(e => e.Pk).HasName("P_ENTITY");

            entity.ToTable("ENTITY");

            entity.HasIndex(e => new { e.Nationalitycode, e.Pk }, "IDX$$_87830003");

            entity.HasIndex(e => new { e.Nationalitypk, e.Pk }, "IDX$$_87830004");

            entity.HasIndex(e => new { e.Type, e.Identifier }, "IDX_ENTITY_TYPID");

            entity.HasIndex(e => e.Soundex, "INDX_ENTITY_001");

            entity.HasIndex(e => e.Type, "INDX_TYPE");

            entity.HasIndex(e => e.Officialmailpk, "IX_OFFICIALMAILPK_");

            entity.HasIndex(e => e.Centralbankcode, "I_MEGARA_CENTRALBANKCODE_");

            entity.HasIndex(e => e.Fullname, "I_MEGARA_FULLNAME_");

            entity.HasIndex(e => e.Code, "U_ENTITYCODE_").IsUnique();

            entity.HasIndex(e => e.Identifier, "U_ENTITYIDEN8CMT5F").IsUnique();

            entity.HasIndex(e => e.Professionalactivitypk, "U_ENTITYPRO_P0W29H").IsUnique();

            entity.Property(e => e.Pk)
                .HasPrecision(19)
                .ValueGeneratedNever()
                .HasColumnName("PK_");
            entity.Property(e => e.Assaini)
                .HasPrecision(1)
                .HasColumnName("ASSAINI_");
            entity.Property(e => e.Bl)
                .HasPrecision(1)
                .HasColumnName("BL_");
            entity.Property(e => e.Branch)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("BRANCH_");
            entity.Property(e => e.Ccppk)
                .HasPrecision(19)
                .HasColumnName("CCPPK_");
            entity.Property(e => e.Cdate)
                .HasPrecision(6)
                .HasColumnName("CDATE_");
            entity.Property(e => e.Centralbankcode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CENTRALBANKCODE_");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CODE_");
            entity.Property(e => e.Crepk)
                .HasPrecision(19)
                .HasColumnName("CREPK_");
            entity.Property(e => e.Cuser)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CUSER_");
            entity.Property(e => e.Datefield1)
                .HasColumnType("DATE")
                .HasColumnName("DATEFIELD1_");
            entity.Property(e => e.Datefield2)
                .HasColumnType("DATE")
                .HasColumnName("DATEFIELD2_");
            entity.Property(e => e.Datefield3)
                .HasColumnType("DATE")
                .HasColumnName("DATEFIELD3_");
            entity.Property(e => e.Decbctrisk)
                .HasPrecision(1)
                .HasColumnName("DECBCTRISK_");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION_");
            entity.Property(e => e.Draft)
                .HasPrecision(1)
                .HasColumnName("DRAFT_");
            entity.Property(e => e.Entitycategorycode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ENTITYCATEGORYCODE_");
            entity.Property(e => e.Entitycategorypk)
                .HasPrecision(19)
                .HasColumnName("ENTITYCATEGORYPK_");
            entity.Property(e => e.Fiscalresidencecode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FISCALRESIDENCECODE_");
            entity.Property(e => e.Fiscalresidencepk)
                .HasPrecision(19)
                .HasColumnName("FISCALRESIDENCEPK_");
            entity.Property(e => e.Forbiddenaccount)
                .HasPrecision(1)
                .HasColumnName("FORBIDDENACCOUNT_");
            entity.Property(e => e.Fullname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FULLNAME_");
            entity.Property(e => e.Gc)
                .HasPrecision(1)
                .HasColumnName("GC_");
            entity.Property(e => e.Identifier)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("IDENTIFIER_");
            entity.Property(e => e.Identifier2)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("IDENTIFIER2_");
            entity.Property(e => e.Inscode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("INSCODE_");
            entity.Property(e => e.Isarchived)
                .HasPrecision(1)
                .HasColumnName("ISARCHIVED_");
            entity.Property(e => e.Isvalidated)
                .HasPrecision(1)
                .HasColumnName("ISVALIDATED_");
            entity.Property(e => e.Labft)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("LABFT_");
            entity.Property(e => e.Migstate)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("MIGSTATE_");
            entity.Property(e => e.Nationalitycode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NATIONALITYCODE_");
            entity.Property(e => e.Nationalitypk)
                .HasPrecision(19)
                .HasColumnName("NATIONALITYPK_");
            entity.Property(e => e.Notresident)
                .HasPrecision(1)
                .HasColumnName("NOTRESIDENT_");
            entity.Property(e => e.Officialmailpk)
                .HasPrecision(19)
                .HasColumnName("OFFICIALMAILPK_");
            entity.Property(e => e.Otherfunctionsppe)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OTHERFUNCTIONSPPE_");
            entity.Property(e => e.Ppe)
                .HasPrecision(1)
                .HasColumnName("PPE_");
            entity.Property(e => e.Ppefunctionpk)
                .HasPrecision(19)
                .HasColumnName("PPEFUNCTIONPK_");
            entity.Property(e => e.Professionalactivitypk)
                .HasPrecision(19)
                .HasColumnName("PROFESSIONALACTIVITYPK_");
            entity.Property(e => e.Prospect)
                .HasPrecision(1)
                .HasColumnName("PROSPECT_");
            entity.Property(e => e.Residencecode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("RESIDENCECODE_");
            entity.Property(e => e.Residencepk)
                .HasPrecision(19)
                .HasColumnName("RESIDENCEPK_");
            entity.Property(e => e.Resident)
                .HasPrecision(1)
                .HasColumnName("RESIDENT_");
            entity.Property(e => e.Riskcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RISKCODE_");
            entity.Property(e => e.Riskcodebc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RISKCODEBC_");
            entity.Property(e => e.Socialaffiliationdate)
                .HasColumnType("DATE")
                .HasColumnName("SOCIALAFFILIATIONDATE_");
            entity.Property(e => e.Socialaffiliationnum)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("SOCIALAFFILIATIONNUM_");
            entity.Property(e => e.Soundex)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("SOUNDEX_");
            entity.Property(e => e.Stringfield1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STRINGFIELD1_");
            entity.Property(e => e.Stringfield2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STRINGFIELD2_");
            entity.Property(e => e.Stringfield3)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STRINGFIELD3_");
            entity.Property(e => e.Stringfield4)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STRINGFIELD4_");
            entity.Property(e => e.Stringfield5)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STRINGFIELD5_");
            entity.Property(e => e.Stringfield6)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("STRINGFIELD6_");
            entity.Property(e => e.Stringfield7)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("STRINGFIELD7_");
            entity.Property(e => e.Translatedname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TRANSLATEDNAME_");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TYPE_");
            entity.Property(e => e.Udate)
                .HasPrecision(6)
                .HasColumnName("UDATE_");
            entity.Property(e => e.Uuser)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("UUSER_");
            entity.Property(e => e.Validatedbyjurdical)
                .HasPrecision(1)
                .HasColumnName("VALIDATEDBYJURDICAL_");
            entity.Property(e => e.Versionnum)
                .HasPrecision(10)
                .HasColumnName("VERSIONNUM_");
            entity.Property(e => e.Withanomaly)
                .HasPrecision(1)
                .HasColumnName("WITHANOMALY_");
        });

        modelBuilder.Entity<Nternalaccount>(entity =>
        {
            entity.HasKey(e => new { e.Internalaccountspk, e.Ownerpk }).HasName("P_NTERNALACCOUNTS");

            entity.ToTable("NTERNALACCOUNTS");

            entity.HasIndex(e => e.Internalaccountspk, "BAFIINDEX12347");

            entity.HasIndex(e => e.Ownerpk, "BAFIV2_INDEX9ZZ78SSHHSSZZ99");

            entity.Property(e => e.Internalaccountspk)
                .HasPrecision(19)
                .HasColumnName("INTERNALACCOUNTSPK");
            entity.Property(e => e.Ownerpk)
                .HasPrecision(19)
                .HasColumnName("OWNERPK");

            entity.HasOne(d => d.OwnerpkNavigation).WithMany(p => p.Nternalaccounts)
                .HasForeignKey(d => d.Ownerpk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("F_UNTSOWNEVULHFM");
        });

        modelBuilder.Entity<Paymentcard>(entity =>
        {
            entity.HasKey(e => e.Pk).HasName("P_PAYMENTCARD");

            entity.ToTable("PAYMENTCARD");

            entity.HasIndex(e => e.Accountpk, "IDX$$_D0200001");

            entity.HasIndex(e => e.Cardnumber, "INDX_PAYMENTCARDELIV");

            entity.HasIndex(e => new { e.Reference, e.Expirydate }, "U_PAYMENTCARAXGDLG").IsUnique();

            entity.HasIndex(e => e.Code, "U_PAYMENTCARDCODE_").IsUnique();

            entity.Property(e => e.Pk)
                .HasPrecision(19)
                .ValueGeneratedNever()
                .HasColumnName("PK_");
            entity.Property(e => e.Accountcode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ACCOUNTCODE_");
            entity.Property(e => e.Accountpk)
                .HasPrecision(19)
                .HasColumnName("ACCOUNTPK_");
            entity.Property(e => e.Cancelreason)
                .HasMaxLength(19)
                .IsUnicode(false)
                .HasColumnName("CANCELREASON_");
            entity.Property(e => e.Cardnumber)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CARDNUMBER_");
            entity.Property(e => e.Cardsproductcode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CARDSPRODUCTCODE_");
            entity.Property(e => e.Cardsproductpk)
                .HasPrecision(19)
                .HasColumnName("CARDSPRODUCTPK_");
            entity.Property(e => e.Category)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CATEGORY_");
            entity.Property(e => e.Cdate)
                .HasPrecision(6)
                .HasColumnName("CDATE_");
            entity.Property(e => e.Celling)
                .HasColumnType("NUMBER(19,4)")
                .HasColumnName("CELLING_");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CODE_");
            entity.Property(e => e.Confidentialcode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CONFIDENTIALCODE_");
            entity.Property(e => e.Currencycode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CURRENCYCODE_");
            entity.Property(e => e.Currencypk)
                .HasPrecision(19)
                .HasColumnName("CURRENCYPK_");
            entity.Property(e => e.Cuser)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CUSER_");
            entity.Property(e => e.Delivereraddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DELIVERERADDRESS_");
            entity.Property(e => e.Delivererfirstname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DELIVERERFIRSTNAME_");
            entity.Property(e => e.Delivereriddocument)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DELIVERERIDDOCUMENT_");
            entity.Property(e => e.Delivereridtypecode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DELIVERERIDTYPECODE_");
            entity.Property(e => e.Delivereridtypepk)
                .HasPrecision(19)
                .HasColumnName("DELIVERERIDTYPEPK_");
            entity.Property(e => e.Delivererlastname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DELIVERERLASTNAME_");
            entity.Property(e => e.Deliverermail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DELIVERERMAIL_");
            entity.Property(e => e.Deliverertel)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DELIVERERTEL_");
            entity.Property(e => e.Deliverertype)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DELIVERERTYPE_");
            entity.Property(e => e.Deliverydate)
                .HasColumnType("DATE")
                .HasColumnName("DELIVERYDATE_");
            entity.Property(e => e.Enroled)
                .HasPrecision(1)
                .HasColumnName("ENROLED_");
            entity.Property(e => e.Expirydate)
                .HasColumnType("DATE")
                .HasColumnName("EXPIRYDATE_");
            entity.Property(e => e.Injected)
                .HasPrecision(1)
                .HasColumnName("INJECTED_");
            entity.Property(e => e.Isprepaid)
                .HasPrecision(1)
                .HasColumnName("ISPREPAID_");
            entity.Property(e => e.Maxgab)
                .HasColumnType("NUMBER(19,4)")
                .HasColumnName("MAXGAB_");
            entity.Property(e => e.Maxtpe)
                .HasColumnType("NUMBER(19,4)")
                .HasColumnName("MAXTPE_");
            entity.Property(e => e.Numotp)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NUMOTP_");
            entity.Property(e => e.Overdraftamount)
                .HasColumnType("NUMBER(19,4)")
                .HasColumnName("OVERDRAFTAMOUNT_");
            entity.Property(e => e.Periodicity)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("PERIODICITY_");
            entity.Property(e => e.Reference)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("REFERENCE_");
            entity.Property(e => e.Renewable)
                .HasPrecision(1)
                .HasColumnName("RENEWABLE_");
            entity.Property(e => e.Status)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("STATUS_");
            entity.Property(e => e.Torenew)
                .HasPrecision(1)
                .HasColumnName("TORENEW_");
            entity.Property(e => e.Transitiondate)
                .HasPrecision(6)
                .HasColumnName("TRANSITIONDATE_");
            entity.Property(e => e.Udate)
                .HasPrecision(6)
                .HasColumnName("UDATE_");
            entity.Property(e => e.Uuser)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("UUSER_");
            entity.Property(e => e.Versionnum)
                .HasPrecision(10)
                .HasColumnName("VERSIONNUM_");
            entity.Property(e => e.Withcommission)
                .HasPrecision(1)
                .HasColumnName("WITHCOMMISSION_");

            entity.HasOne(d => d.AccountpkNavigation).WithMany(p => p.Paymentcards)
                .HasForeignKey(d => d.Accountpk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("F_CARDACCO_43KZQR");
        });

        modelBuilder.Entity<Productservice>(entity =>
        {
            entity.HasKey(e => e.Pk).HasName("P_PRODUCTSERVICE");

            entity.ToTable("PRODUCTSERVICE");

            entity.HasIndex(e => e.Type, "IDX$$_99640001");

            entity.HasIndex(e => new { e.Name, e.Type }, "IDX$$_99640003");

            entity.HasIndex(e => new { e.Code, e.Name }, "IDX$$_CB840002");

            entity.HasIndex(e => e.Productcategorypk, "IX_PRODUCTSER33221");

            entity.HasIndex(e => e.Ficheproductpk, "U_PRODUCTSE_7S4GHG").IsUnique();

            entity.HasIndex(e => e.Code, "U_PRODUCTSE_8NF190").IsUnique();

            entity.HasIndex(e => e.Vendorincentivespk, "U_PRODUCTSE_BESJO2").IsUnique();

            entity.HasIndex(e => e.Identifier, "U_PRODUCTSE_TM01JK").IsUnique();

            entity.Property(e => e.Pk)
                .HasPrecision(19)
                .ValueGeneratedNever()
                .HasColumnName("PK_");
            entity.Property(e => e.Abreviation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ABREVIATION_");
            entity.Property(e => e.Activationdate)
                .HasColumnType("DATE")
                .HasColumnName("ACTIVATIONDATE_");
            entity.Property(e => e.Applyfiscalretention)
                .HasPrecision(1)
                .HasColumnName("APPLYFISCALRETENTION_");
            entity.Property(e => e.Available)
                .HasPrecision(1)
                .HasColumnName("AVAILABLE_");
            entity.Property(e => e.Cbcategorycode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CBCATEGORYCODE_");
            entity.Property(e => e.Cbcategorypk)
                .HasPrecision(19)
                .HasColumnName("CBCATEGORYPK_");
            entity.Property(e => e.Cdate)
                .HasPrecision(6)
                .HasColumnName("CDATE_");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CODE_");
            entity.Property(e => e.Cuser)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CUSER_");
            entity.Property(e => e.Description)
                .HasMaxLength(1280)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION_");
            entity.Property(e => e.Draft)
                .HasPrecision(1)
                .HasColumnName("DRAFT_");
            entity.Property(e => e.Enddate)
                .HasColumnType("DATE")
                .HasColumnName("ENDDATE_");
            entity.Property(e => e.Expired)
                .HasPrecision(1)
                .HasColumnName("EXPIRED_");
            entity.Property(e => e.Ficheproductpk)
                .HasPrecision(19)
                .HasColumnName("FICHEPRODUCTPK_");
            entity.Property(e => e.Freetext)
                .HasMaxLength(1280)
                .IsUnicode(false)
                .HasColumnName("FREETEXT_");
            entity.Property(e => e.Identifier)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("IDENTIFIER_");
            entity.Property(e => e.Internal)
                .HasPrecision(1)
                .HasColumnName("INTERNAL_");
            entity.Property(e => e.Internalcode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("INTERNALCODE_");
            entity.Property(e => e.Isathorizedoperationempty)
                .HasPrecision(1)
                .HasColumnName("ISATHORIZEDOPERATIONEMPTY_");
            entity.Property(e => e.Islimiteempty)
                .HasPrecision(1)
                .HasColumnName("ISLIMITEEMPTY_");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NAME_");
            entity.Property(e => e.Offeredonce)
                .HasPrecision(1)
                .HasColumnName("OFFEREDONCE_");
            entity.Property(e => e.Prefixan)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PREFIXAN_");
            entity.Property(e => e.Productcategorycode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PRODUCTCATEGORYCODE_");
            entity.Property(e => e.Productcategorypk)
                .HasPrecision(19)
                .HasColumnName("PRODUCTCATEGORYPK_");
            entity.Property(e => e.Renewablerequestdelay)
                .HasPrecision(19)
                .HasColumnName("RENEWABLEREQUESTDELAY_");
            entity.Property(e => e.Revisionperiodicity)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("REVISIONPERIODICITY_");
            entity.Property(e => e.Risklevel)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("RISKLEVEL_");
            entity.Property(e => e.Serial)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("SERIAL_");
            entity.Property(e => e.Shortname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("SHORTNAME_");
            entity.Property(e => e.Translatedname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TRANSLATEDNAME_");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TYPE_");
            entity.Property(e => e.Udate)
                .HasPrecision(6)
                .HasColumnName("UDATE_");
            entity.Property(e => e.Uuser)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("UUSER_");
            entity.Property(e => e.Validationprocessname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("VALIDATIONPROCESSNAME_");
            entity.Property(e => e.Validationstepname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("VALIDATIONSTEPNAME_");
            entity.Property(e => e.Vendorincentivespk)
                .HasPrecision(19)
                .HasColumnName("VENDORINCENTIVESPK_");
            entity.Property(e => e.Versionnum)
                .HasPrecision(10)
                .HasColumnName("VERSIONNUM_");
            entity.Property(e => e.Weightingrate)
                .HasColumnType("FLOAT")
                .HasColumnName("WEIGHTINGRATE_");
        });
        modelBuilder.HasSequence("ABANDON_");
        modelBuilder.HasSequence("ABANDONCC_");
        modelBuilder.HasSequence("ABANDONCCVH_");
        modelBuilder.HasSequence("ABANDONECEPSVH_");
        modelBuilder.HasSequence("ABANDONECHEPSVH_");
        modelBuilder.HasSequence("ABANDONECHVH_");
        modelBuilder.HasSequence("ABANDONECVH_");
        modelBuilder.HasSequence("ABANDONEDBFD_");
        modelBuilder.HasSequence("ABANDONEDBFDEPS_");
        modelBuilder.HasSequence("ABANDONEPS_");
        modelBuilder.HasSequence("ABANDONNEDEFD_");
        modelBuilder.HasSequence("ABONDONEDBCC_");
        modelBuilder.HasSequence("ACC_TR_REQ_");
        modelBuilder.HasSequence("ACCCM_");
        modelBuilder.HasSequence("ACCCMD_");
        modelBuilder.HasSequence("ACCCMDDOCUMENTFI_");
        modelBuilder.HasSequence("ACCCONVALHIS_");
        modelBuilder.HasSequence("ACCCU_");
        modelBuilder.HasSequence("ACCMD_");
        modelBuilder.HasSequence("ACCMOVEMENT_");
        modelBuilder.HasSequence("ACCNBMODVH_");
        modelBuilder.HasSequence("ACCOUNT_");
        modelBuilder.HasSequence("ACCOUNTBALANCE_");
        modelBuilder.HasSequence("ACCOUNTBEHAVIOR_");
        modelBuilder.HasSequence("ACCOUNTFIELD_");
        modelBuilder.HasSequence("ACCOUNTFT_");
        modelBuilder.HasSequence("ACCOUNTLOCK_");
        modelBuilder.HasSequence("ACCOUNTR_");
        modelBuilder.HasSequence("ACCOUNTRVH_");
        modelBuilder.HasSequence("ACCOUNTS_");
        modelBuilder.HasSequence("ACCOUNTTF_");
        modelBuilder.HasSequence("ACCSETTVAL_");
        modelBuilder.HasSequence("ACCSETTVALHIS_");
        modelBuilder.HasSequence("ACCSMOOTHR_");
        modelBuilder.HasSequence("ACCSMOOTHRVH_");
        modelBuilder.HasSequence("ACCSMTHAPP_");
        modelBuilder.HasSequence("ACCVALHIS_");
        modelBuilder.HasSequence("ACCVALPRO_");
        modelBuilder.HasSequence("ACTIFBILAN_");
        modelBuilder.HasSequence("ACTIONS_");
        modelBuilder.HasSequence("ACTIONVCDO_");
        modelBuilder.HasSequence("ACTIONVFO_");
        modelBuilder.HasSequence("ACTIVITY_");
        modelBuilder.HasSequence("ACTIVITYAREA_");
        modelBuilder.HasSequence("ACTIVITYSECTOR_");
        modelBuilder.HasSequence("ACTUALISATIEVH_");
        modelBuilder.HasSequence("ADDITIONALI_");
        modelBuilder.HasSequence("ADDITIONALR_");
        modelBuilder.HasSequence("ADDITIONALSC_");
        modelBuilder.HasSequence("ADDITIONALST_");
        modelBuilder.HasSequence("ADDITIONNALPD_");
        modelBuilder.HasSequence("ADDITIONNAPDVH_");
        modelBuilder.HasSequence("ADDRESS_");
        modelBuilder.HasSequence("ADDRESSPURPOSE_");
        modelBuilder.HasSequence("ADDWARAFFREQ_");
        modelBuilder.HasSequence("ADDWARAFFRVH_");
        modelBuilder.HasSequence("ADJUSTMENTA_");
        modelBuilder.HasSequence("AFFECTATION_");
        modelBuilder.HasSequence("AFFECTEDOU_");
        modelBuilder.HasSequence("AFFECTEDW_");
        modelBuilder.HasSequence("AFFECTRCD_");
        modelBuilder.HasSequence("AFFECTS_");
        modelBuilder.HasSequence("AGESCALE_");
        modelBuilder.HasSequence("AGIOSR_");
        modelBuilder.HasSequence("AGIOSRC_");
        modelBuilder.HasSequence("AGIOSRD_");
        modelBuilder.HasSequence("AGIOSRS_");
        modelBuilder.HasSequence("AGIOSRVH_");
        modelBuilder.HasSequence("AGREEMENTO_");
        modelBuilder.HasSequence("AGREEMENTOPRVH_");
        modelBuilder.HasSequence("AGREMENTMF_");
        modelBuilder.HasSequence("AGROFPRINVH_");
        modelBuilder.HasSequence("ALERTEBC_");
        modelBuilder.HasSequence("ALERTECENTIF_");
        modelBuilder.HasSequence("ALERTECENTIFHIS_");
        modelBuilder.HasSequence("ALERTLIMIT_");
        modelBuilder.HasSequence("ALLOTMENT_");
        modelBuilder.HasSequence("ALLOTMENTREASON_");
        modelBuilder.HasSequence("ALLOTMENTTB_");
        modelBuilder.HasSequence("ALLOTMENTVH_");
        modelBuilder.HasSequence("ALLOWEDDCDO_");
        modelBuilder.HasSequence("ALLOWEDDFO_");
        modelBuilder.HasSequence("ALLOWEDER_");
        modelBuilder.HasSequence("ALLOWEDFCDO_");
        modelBuilder.HasSequence("ALLOWEDFFO_");
        modelBuilder.HasSequence("ALLOWEDO_");
        modelBuilder.HasSequence("ALLOWEDPRODUCT_");
        modelBuilder.HasSequence("AMCONTEXTVALUE_");
        modelBuilder.HasSequence("AMOUNTSTP_");
        modelBuilder.HasSequence("AMTNAM_");
        modelBuilder.HasSequence("ANALYSEPFT_");
        modelBuilder.HasSequence("ANNAPPDMCVH_");
        modelBuilder.HasSequence("ANNPAIECHC_");
        modelBuilder.HasSequence("ANNPAIECHCE_");
        modelBuilder.HasSequence("ANNULATIONPEE_");
        modelBuilder.HasSequence("ANNULATIONRG_");
        modelBuilder.HasSequence("ANNULATIONRGH_");
        modelBuilder.HasSequence("ANNULATIOPEEVH_");
        modelBuilder.HasSequence("ANNUPAIEECHVH_");
        modelBuilder.HasSequence("ANNUPECVH_");
        modelBuilder.HasSequence("ANTICIPARBAOVH_");
        modelBuilder.HasSequence("ANTICIPATEDRL_");
        modelBuilder.HasSequence("ANTICIPATEDRVH_");
        modelBuilder.HasSequence("ANTICIPATERTVH_");
        modelBuilder.HasSequence("APPELDEFONDSVH_");
        modelBuilder.HasSequence("APPORTDMCHIS_");
        modelBuilder.HasSequence("APUREMENTD_");
        modelBuilder.HasSequence("ARCHIVEPURGELOG_");
        modelBuilder.HasSequence("ARRETE_CEDC_");
        modelBuilder.HasSequence("ASSAINISSEECVH_");
        modelBuilder.HasSequence("ASSAINISSEMEEC_");
        modelBuilder.HasSequence("ASSOCIATIONTYPE_");
        modelBuilder.HasSequence("ASSURANCEREGULE_");
        modelBuilder.HasSequence("ATTACHEDD_");
        modelBuilder.HasSequence("ATTACHEDDCARDDOCUME_");
        modelBuilder.HasSequence("AUGMENTATIONVH_");
        modelBuilder.HasSequence("AUTHORITYD_");
        modelBuilder.HasSequence("AUTHORIZATILVH_");
        modelBuilder.HasSequence("AUTHORIZATIOCV_");
        modelBuilder.HasSequence("AUTHORIZATIONC_");
        modelBuilder.HasSequence("AUTHORIZATIONL_");
        modelBuilder.HasSequence("AUTHORIZATIONR_");
        modelBuilder.HasSequence("AUTHORIZATIRRS_");
        modelBuilder.HasSequence("AUTHORIZEDDMCO_");
        modelBuilder.HasSequence("AUTHORIZEDO_");
        modelBuilder.HasSequence("AUTHORIZEDS_");
        modelBuilder.HasSequence("AUTOMATEDREPORT_");
        modelBuilder.HasSequence("AUTOMATICA_");
        modelBuilder.HasSequence("AVABENEFICIARY_");
        modelBuilder.HasSequence("AVAILABLEB_");
        modelBuilder.HasSequence("AVAILABLEBJ_");
        modelBuilder.HasSequence("AVALISER_");
        modelBuilder.HasSequence("AVALISEUR_");
        modelBuilder.HasSequence("AVANCEDEMARRAGE_");
        modelBuilder.HasSequence("AVANCERD_");
        modelBuilder.HasSequence("AVANCEREGIE_");
        modelBuilder.HasSequence("AVAVISION_");
        modelBuilder.HasSequence("AVENANT_");
        modelBuilder.HasSequence("AVERAGECAPITAL_");
        modelBuilder.HasSequence("AVERAGECAPITALE_");
        modelBuilder.HasSequence("AVERAGECD_");
        modelBuilder.HasSequence("AVOIRCLIENT_");
        modelBuilder.HasSequence("BAIL_");
        modelBuilder.HasSequence("BANKGARNISHMENT_");
        modelBuilder.HasSequence("BANKGE_");
        modelBuilder.HasSequence("BANKSTAFF_");
        modelBuilder.HasSequence("BAOREFSEQUENCE_");
        modelBuilder.HasSequence("BDEOPERATION_");
        modelBuilder.HasSequence("BDEOPERATIONVH_");
        modelBuilder.HasSequence("BENEFICIAIDDMC_");
        modelBuilder.HasSequence("BENEFICIAIREDR_");
        modelBuilder.HasSequence("BENEFICIAREE_");
        modelBuilder.HasSequence("BENEFRN_");
        modelBuilder.HasSequence("BFDREPARTITION_");
        modelBuilder.HasSequence("BIGREMMSGRESULT_");
        modelBuilder.HasSequence("BILANFINANCIER_");
        modelBuilder.HasSequence("BILANS_");
        modelBuilder.HasSequence("BILLAVAL_");
        modelBuilder.HasSequence("BILLBAP_");
        modelBuilder.HasSequence("BILLBAP_REF");
        modelBuilder.HasSequence("BILLBAPVH_");
        modelBuilder.HasSequence("BILLBENEFICIARY_");
        modelBuilder.HasSequence("BILLCALENDAR_");
        modelBuilder.HasSequence("BILLCR_");
        modelBuilder.HasSequence("BILLEXCEED_");
        modelBuilder.HasSequence("BILLGP_");
        modelBuilder.HasSequence("BILLIMAGE_");
        modelBuilder.HasSequence("BILLIMAGEBILLIMAGE_");
        modelBuilder.HasSequence("BILLIMAGERECTO_");
        modelBuilder.HasSequence("BILLIMAGEVERSO_");
        modelBuilder.HasSequence("BILLL_");
        modelBuilder.HasSequence("BILLM_");
        modelBuilder.HasSequence("BILLRRVH_");
        modelBuilder.HasSequence("BILLSCCV_");
        modelBuilder.HasSequence("BILLSCV_");
        modelBuilder.HasSequence("BIRTHDOR_");
        modelBuilder.HasSequence("BLOCTPVH_");
        modelBuilder.HasSequence("BOARDORDER_");
        modelBuilder.HasSequence("BOITEPOSTAL_");
        modelBuilder.HasSequence("BOITEPVH_");
        modelBuilder.HasSequence("BONCAISSE_NUMBON_SEQ");
        modelBuilder.HasSequence("BOOKJD_");
        modelBuilder.HasSequence("BOOKJOBBER_");
        modelBuilder.HasSequence("BOOKJVH_");
        modelBuilder.HasSequence("BUSINESSALERT_");
        modelBuilder.HasSequence("CAER_");
        modelBuilder.HasSequence("CAERMARKET_");
        modelBuilder.HasSequence("CALENDARDOM_");
        modelBuilder.HasSequence("CALENDRIERDDMC_");
        modelBuilder.HasSequence("CALENDRIERR_");
        modelBuilder.HasSequence("CANALHORIZON_");
        modelBuilder.HasSequence("CANCELARVH_");
        modelBuilder.HasSequence("CANCELAVH_");
        modelBuilder.HasSequence("CANCELCBSMLVH_");
        modelBuilder.HasSequence("CANCELCUVH_");
        modelBuilder.HasSequence("CANCELCVH_");
        modelBuilder.HasSequence("CANCELDTVH_");
        modelBuilder.HasSequence("CANCELLATIONBP_");
        modelBuilder.HasSequence("CANCELLATIONLC_");
        modelBuilder.HasSequence("CANCELLBP_");
        modelBuilder.HasSequence("CANCELTPVH_");
        modelBuilder.HasSequence("CANTNRVH_");
        modelBuilder.HasSequence("CAPITALCD_");
        modelBuilder.HasSequence("CARACTERISTILS_");
        modelBuilder.HasSequence("CARACTLS_");
        modelBuilder.HasSequence("CARDCEILING_");
        modelBuilder.HasSequence("CARDS_");
        modelBuilder.HasSequence("CARDSSERVICES_");
        modelBuilder.HasSequence("CARDSUTIL_");
        modelBuilder.HasSequence("CARDTECHNOLOGY_");
        modelBuilder.HasSequence("CASDSK_");
        modelBuilder.HasSequence("CASDSKALERT_");
        modelBuilder.HasSequence("CASDSKBAL_");
        modelBuilder.HasSequence("CASDSKCLO_");
        modelBuilder.HasSequence("CASDSKDET_");
        modelBuilder.HasSequence("CASDSKOPE_");
        modelBuilder.HasSequence("CASDSKSET_");
        modelBuilder.HasSequence("CASDSKSETVH_");
        modelBuilder.HasSequence("CASDSKSTA_");
        modelBuilder.HasSequence("CASHDC_");
        modelBuilder.HasSequence("CASHDESKLOCK_");
        modelBuilder.HasSequence("CASHDESKTYPE_");
        modelBuilder.HasSequence("CASHDID_");
        modelBuilder.HasSequence("CASHDIO_");
        modelBuilder.HasSequence("CASHDMO_");
        modelBuilder.HasSequence("CASHDOC_");
        modelBuilder.HasSequence("CASHDOD_");
        modelBuilder.HasSequence("CASHRCV_");
        modelBuilder.HasSequence("CASHREMITTANCE_");
        modelBuilder.HasSequence("CASHRR_");
        modelBuilder.HasSequence("CASHRVH_");
        modelBuilder.HasSequence("CASMVT_");
        modelBuilder.HasSequence("CASSTADET_");
        modelBuilder.HasSequence("CASTYPOPE_");
        modelBuilder.HasSequence("CBS_COM_");
        modelBuilder.HasSequence("CBSCCAVH_");
        modelBuilder.HasSequence("CBSCCVH_");
        modelBuilder.HasSequence("CBSCE_");
        modelBuilder.HasSequence("CBSCEC_");
        modelBuilder.HasSequence("CBSCEVENTCSLT_");
        modelBuilder.HasSequence("CBSCONTEXTVALUE_");
        modelBuilder.HasSequence("CBSCRVH_");
        modelBuilder.HasSequence("CBSCTRCOM_");
        modelBuilder.HasSequence("CBSCVH_");
        modelBuilder.HasSequence("CBSLEVEESUSHIS_");
        modelBuilder.HasSequence("CBSLMGVH_");
        modelBuilder.HasSequence("CBSMAINLEVEEVH_");
        modelBuilder.HasSequence("CBSMEJG_");
        modelBuilder.HasSequence("CBSMISEENJEUVH_");
        modelBuilder.HasSequence("CBSMODCOM_");
        modelBuilder.HasSequence("CBSMODIFIEDDATA_");
        modelBuilder.HasSequence("CBSMSGCONFIG_");
        modelBuilder.HasSequence("CBSNPAIDEFD_");
        modelBuilder.HasSequence("CBSRVH_");
        modelBuilder.HasSequence("CBSSUSPENSIONVH_");
        modelBuilder.HasSequence("CBSTEVH_");
        modelBuilder.HasSequence("CBSUVH_");
        modelBuilder.HasSequence("CENADIMATRICULE_");
        modelBuilder.HasSequence("CENADISALARY_");
        modelBuilder.HasSequence("CENTRALBC_");
        modelBuilder.HasSequence("CENTRALFILE_");
        modelBuilder.HasSequence("CERTIFIEDCHECK_");
        modelBuilder.HasSequence("CERTIFIEDCHECK_REF");
        modelBuilder.HasSequence("CERTIFIEDCVH_");
        modelBuilder.HasSequence("CGPAB_");
        modelBuilder.HasSequence("CGPADDRESSMEDIA_");
        modelBuilder.HasSequence("CGPAMVH_");
        modelBuilder.HasSequence("CGPBILLCOM_");
        modelBuilder.HasSequence("CGPBILLCOMVH_");
        modelBuilder.HasSequence("CGPBILLS_");
        modelBuilder.HasSequence("CGPBILLSVALHIS_");
        modelBuilder.HasSequence("CGPBIR_");
        modelBuilder.HasSequence("CGPBLANCHVALHIS_");
        modelBuilder.HasSequence("CGPC_");
        modelBuilder.HasSequence("CGPCASREM_");
        modelBuilder.HasSequence("CGPCASREMVH_");
        modelBuilder.HasSequence("CGPCBS_");
        modelBuilder.HasSequence("CGPCBSVH_");
        modelBuilder.HasSequence("CGPCD_");
        modelBuilder.HasSequence("CGPCDC_");
        modelBuilder.HasSequence("CGPCLOSINGHIST_");
        modelBuilder.HasSequence("CGPCNTVAL_");
        modelBuilder.HasSequence("CGPCNTVALCTX_");
        modelBuilder.HasSequence("CGPCOMCBS_");
        modelBuilder.HasSequence("CGPCOMCBSVH_");
        modelBuilder.HasSequence("CGPDECISION_");
        modelBuilder.HasSequence("CGPDICV_");
        modelBuilder.HasSequence("CGPDISCOM_");
        modelBuilder.HasSequence("CGPDIVH_");
        modelBuilder.HasSequence("CGPDRAWEEINCUR_");
        modelBuilder.HasSequence("CGPED_");
        modelBuilder.HasSequence("CGPED_SEQ");
        modelBuilder.HasSequence("CGPEXDISVALHIS_");
        modelBuilder.HasSequence("CGPFFVH_");
        modelBuilder.HasSequence("CGPFILEFEES_");
        modelBuilder.HasSequence("CGPFINNATS_");
        modelBuilder.HasSequence("CGPFINNATVH_");
        modelBuilder.HasSequence("CGPFINTYP_");
        modelBuilder.HasSequence("CGPFINTYPEVH_");
        modelBuilder.HasSequence("CGPFORP_");
        modelBuilder.HasSequence("CGPFORP_SEQ");
        modelBuilder.HasSequence("CGPFORPVH_");
        modelBuilder.HasSequence("CGPFR_");
        modelBuilder.HasSequence("CGPFRVH_");
        modelBuilder.HasSequence("CGPFTA_");
        modelBuilder.HasSequence("CGPFTA_SEQ");
        modelBuilder.HasSequence("CGPFTAVH_");
        modelBuilder.HasSequence("CGPIF_");
        modelBuilder.HasSequence("CGPIFVH_");
        modelBuilder.HasSequence("CGPINVESTMENT_");
        modelBuilder.HasSequence("CGPINVVALHIS_");
        modelBuilder.HasSequence("CGPLOANCOM_");
        modelBuilder.HasSequence("CGPLOANINT_");
        modelBuilder.HasSequence("CGPMC_SEQ");
        modelBuilder.HasSequence("CGPMCVH_");
        modelBuilder.HasSequence("CGPMOVEMENTCOMM_");
        modelBuilder.HasSequence("CGPOC_SEQ");
        modelBuilder.HasSequence("CGPOPECOM_");
        modelBuilder.HasSequence("CGPOPECOMVH_");
        modelBuilder.HasSequence("CGPRC_");
        modelBuilder.HasSequence("CGPRC_SEQ");
        modelBuilder.HasSequence("CGPRCVH_");
        modelBuilder.HasSequence("CGPRECEUILSCALE_");
        modelBuilder.HasSequence("CGPRECUEILCARTH_");
        modelBuilder.HasSequence("CGPRECUEILLIMIT_");
        modelBuilder.HasSequence("CGPREPCALVALHIS_");
        modelBuilder.HasSequence("CGPRISKCOVCTX_");
        modelBuilder.HasSequence("CGPRISKCOVERAGE_");
        modelBuilder.HasSequence("CGPRM_");
        modelBuilder.HasSequence("CGPRMVH_");
        modelBuilder.HasSequence("CGPRSKCOVVH_");
        modelBuilder.HasSequence("CGPSC_");
        modelBuilder.HasSequence("CGPSC_SEQ");
        modelBuilder.HasSequence("CGPSCVH_");
        modelBuilder.HasSequence("CGPSETTVALHIS_");
        modelBuilder.HasSequence("CGPSP_");
        modelBuilder.HasSequence("CGPSP_SEQ");
        modelBuilder.HasSequence("CGPSPVH_");
        modelBuilder.HasSequence("CGPSV_");
        modelBuilder.HasSequence("CGPSV_SEQ");
        modelBuilder.HasSequence("CGPTAX_");
        modelBuilder.HasSequence("CGPTAXVALHIS_");
        modelBuilder.HasSequence("CGPTD_SEQ");
        modelBuilder.HasSequence("CGPTDVH_");
        modelBuilder.HasSequence("CGPTREASURYDATE_");
        modelBuilder.HasSequence("CGPURVH_");
        modelBuilder.HasSequence("CGPUSURYRATE_");
        modelBuilder.HasSequence("CGPVALUEDATE_");
        modelBuilder.HasSequence("CGPVAT_");
        modelBuilder.HasSequence("CGPVATHIS_");
        modelBuilder.HasSequence("CGPVATVALHIS_");
        modelBuilder.HasSequence("CGPVD_SEQ");
        modelBuilder.HasSequence("CGPVDVH_");
        modelBuilder.HasSequence("CGPWARCOM_");
        modelBuilder.HasSequence("CGPWCCV_");
        modelBuilder.HasSequence("CGPWCOMVH_");
        modelBuilder.HasSequence("CHANGECAVH_");
        modelBuilder.HasSequence("CHANGEMENTAVH_");
        modelBuilder.HasSequence("CHARGETYPE_");
        modelBuilder.HasSequence("CHECKPARAMETRES_");
        modelBuilder.HasSequence("CHECKRECOPE_");
        modelBuilder.HasSequence("CHECKREMITTANCE_");
        modelBuilder.HasSequence("CHECKRR_");
        modelBuilder.HasSequence("CHECKRVH_");
        modelBuilder.HasSequence("CHEQUE_");
        modelBuilder.HasSequence("CHEQUEBOOK_");
        modelBuilder.HasSequence("CHEQUENUMBERS_");
        modelBuilder.HasSequence("CHEQUERA_");
        modelBuilder.HasSequence("CHEQUERAVH_");
        modelBuilder.HasSequence("CHIFFREAD_");
        modelBuilder.HasSequence("CHIFFREAFFAIRE_");
        modelBuilder.HasSequence("CITY_");
        modelBuilder.HasSequence("CLASS_SECTOR");
        modelBuilder.HasSequence("CLASS_SECTOR_CLIENTC");
        modelBuilder.HasSequence("CLASS_SECTOR_CONTRACT");
        modelBuilder.HasSequence("CLASSIFICATIOP_");
        modelBuilder.HasSequence("CLASSIFICATIOS_");
        modelBuilder.HasSequence("CLEARINGDATA_");
        modelBuilder.HasSequence("CLEARINGDELAY_");
        modelBuilder.HasSequence("CLIDEFINVVH_");
        modelBuilder.HasSequence("CLIENTA_");
        modelBuilder.HasSequence("CLIENTACCEPLCH_");
        modelBuilder.HasSequence("CLIENTC_");
        modelBuilder.HasSequence("CLIENTCC_");
        modelBuilder.HasSequence("CLIENTCD_");
        modelBuilder.HasSequence("CLIENTCDH_");
        modelBuilder.HasSequence("CLIENTCH_");
        modelBuilder.HasSequence("CLIENTCLASSHIST_");
        modelBuilder.HasSequence("CLIENTCRITERIA_");
        modelBuilder.HasSequence("CLIENTDEBTS_");
        modelBuilder.HasSequence("CLIENTDOCUMENT_");
        modelBuilder.HasSequence("CLIENTDOCUMENTFILEDATA_");
        modelBuilder.HasSequence("CLIENTFC_");
        modelBuilder.HasSequence("CLIENTFCM_");
        modelBuilder.HasSequence("CLIENTFCMATTACHEDDO_");
        modelBuilder.HasSequence("CLIENTFCMVH_");
        modelBuilder.HasSequence("CLIENTINQUIRY_");
        modelBuilder.HasSequence("CLIENTINQUIRY_REFERENCE_");
        modelBuilder.HasSequence("CLIENTLINKTYPE_");
        modelBuilder.HasSequence("CLIENTNPE_");
        modelBuilder.HasSequence("CLIENTNPED_");
        modelBuilder.HasSequence("CLIENTP_");
        modelBuilder.HasSequence("CLIENTREQUEST_");
        modelBuilder.HasSequence("CLOSINGCCVH_");
        modelBuilder.HasSequence("CLOSINGCU_");
        modelBuilder.HasSequence("CLOSINGCUVH_");
        modelBuilder.HasSequence("CLOSINGODS_");
        modelBuilder.HasSequence("CLOSINGREASON_");
        modelBuilder.HasSequence("CLOSINGREQUEST_");
        modelBuilder.HasSequence("CLOSINGREQUESTATTACHEDDO_");
        modelBuilder.HasSequence("CLOSINGRVH_");
        modelBuilder.HasSequence("CLOSINGUVH_");
        modelBuilder.HasSequence("CLOTUREDMCHIS_");
        modelBuilder.HasSequence("CLTCLASSCFG_");
        modelBuilder.HasSequence("CMNTENVENTENG_");
        modelBuilder.HasSequence("CMTCOMTYPE_");
        modelBuilder.HasSequence("CMTCONVISS_");
        modelBuilder.HasSequence("CMTFEERATESCALE_");
        modelBuilder.HasSequence("CMTFEERULE_");
        modelBuilder.HasSequence("CMTFEERULEEDGE_");
        modelBuilder.HasSequence("CMTFEESCALE_");
        modelBuilder.HasSequence("CMTFEETYP_");
        modelBuilder.HasSequence("CMTFRVH_");
        modelBuilder.HasSequence("CMTINTRUL_");
        modelBuilder.HasSequence("CMTINTRULVH_");
        modelBuilder.HasSequence("CMTINTSCA_");
        modelBuilder.HasSequence("CMTIRE_");
        modelBuilder.HasSequence("CNTBNFMOD_");
        modelBuilder.HasSequence("CNTCOM_");
        modelBuilder.HasSequence("CNTFEE_");
        modelBuilder.HasSequence("CNTINS_");
        modelBuilder.HasSequence("CNTINT_");
        modelBuilder.HasSequence("CNTTLVH_");
        modelBuilder.HasSequence("CNTTMPLIM_");
        modelBuilder.HasSequence("CNTVALCND_");
        modelBuilder.HasSequence("CNTWAFFVH_");
        modelBuilder.HasSequence("CNTWARAFF_");
        modelBuilder.HasSequence("COEFFICIENTL_");
        modelBuilder.HasSequence("COFFRE_");
        modelBuilder.HasSequence("COFFREVALHIS_");
        modelBuilder.HasSequence("COLLECTIVEP_");
        modelBuilder.HasSequence("COMBYFEETYP_");
        modelBuilder.HasSequence("COMMERCIALISAT_");
        modelBuilder.HasSequence("COMMISSIOCBSCV_");
        modelBuilder.HasSequence("COMMITEDBANK_");
        modelBuilder.HasSequence("COMMITMENTED_");
        modelBuilder.HasSequence("COMMITMENTEVENT_").IncrementsBy(39580);
        modelBuilder.HasSequence("COMMITMENTEVENT_REF");
        modelBuilder.HasSequence("COMMITMENTFD_");
        modelBuilder.HasSequence("COMMITMENTRP_");
        modelBuilder.HasSequence("COMPENSATION_ALLER_");
        modelBuilder.HasSequence("COMPENSATION_ARRIVEE_");
        modelBuilder.HasSequence("COMPENSE_ALLER_");
        modelBuilder.HasSequence("COMPENSE_ARRIVEE_");
        modelBuilder.HasSequence("COMPENSE_SERVICES_");
        modelBuilder.HasSequence("COMPENSEAD_");
        modelBuilder.HasSequence("COMPENSEADFILE_");
        modelBuilder.HasSequence("COMPENSEADR_");
        modelBuilder.HasSequence("COMPTERESULTAT_");
        modelBuilder.HasSequence("COMPTESRESULTAT_");
        modelBuilder.HasSequence("CONDITIONE_");
        modelBuilder.HasSequence("CONDITIONPEL_");
        modelBuilder.HasSequence("CONDITIONR_");
        modelBuilder.HasSequence("CONDITIONRC_");
        modelBuilder.HasSequence("CONDITIONRD_");
        modelBuilder.HasSequence("CONDITIONRDDOCUMENTFI_");
        modelBuilder.HasSequence("CONDITIONRH_");
        modelBuilder.HasSequence("CONDITIONRS_");
        modelBuilder.HasSequence("CONDITIONRVH_");
        modelBuilder.HasSequence("CONFIGBILAN_");
        modelBuilder.HasSequence("CONFIGCALCULPI_");
        modelBuilder.HasSequence("CONFIGCPEL_");
        modelBuilder.HasSequence("CONFIGFT_");
        modelBuilder.HasSequence("CONFIGRISKRULE_");
        modelBuilder.HasSequence("CONFIGRRCV_");
        modelBuilder.HasSequence("CONFIGRRVH_");
        modelBuilder.HasSequence("CONFIGTCR_");
        modelBuilder.HasSequence("CONSCOND_");
        modelBuilder.HasSequence("CONSOLIDATEDA_");
        modelBuilder.HasSequence("CONSOLIDATEDCC_");
        modelBuilder.HasSequence("CONSOLIDATEDIE_");
        modelBuilder.HasSequence("CONSOLIDATEDPE_");
        modelBuilder.HasSequence("CONSOLIDATION_");
        modelBuilder.HasSequence("CONSOLIDATIOND_");
        modelBuilder.HasSequence("CONSOLIDATIONDFILEDATA_");
        modelBuilder.HasSequence("CONSOLOANCNT_");
        modelBuilder.HasSequence("CONSOOVD_");
        modelBuilder.HasSequence("CONSTANTTS_");
        modelBuilder.HasSequence("CONSTITUTEP_");
        modelBuilder.HasSequence("CONSTITUTIONE_");
        modelBuilder.HasSequence("CONTACT_");
        modelBuilder.HasSequence("CONTACTATTACHEDDO_");
        modelBuilder.HasSequence("CONTCLOABDVH_");
        modelBuilder.HasSequence("CONTENTCH_");
        modelBuilder.HasSequence("CONTENTIOUS_");
        modelBuilder.HasSequence("CONTENTIOUSC_");
        modelBuilder.HasSequence("CONTENTIOUSD_");
        modelBuilder.HasSequence("CONTENTIOUSDH_");
        modelBuilder.HasSequence("CONTENTIOUSEVH_");
        modelBuilder.HasSequence("CONTENTIOUSVH_");
        modelBuilder.HasSequence("CONTESTATIONB_");
        modelBuilder.HasSequence("CONTESTATIONVH_");
        modelBuilder.HasSequence("CONTESTEDBILL_");
        modelBuilder.HasSequence("CONTEXT_");
        modelBuilder.HasSequence("CONTEXTCONFIG_");
        modelBuilder.HasSequence("CONTEXTPC_");
        modelBuilder.HasSequence("CONTRACT_");
        modelBuilder.HasSequence("CONTRACTB_");
        modelBuilder.HasSequence("CONTRACTC_");
        modelBuilder.HasSequence("CONTRACTCH_");
        modelBuilder.HasSequence("CONTRACTCHIST_");
        modelBuilder.HasSequence("CONTRACTDETAIL_");
        modelBuilder.HasSequence("CONTRACTEDE_");
        modelBuilder.HasSequence("CONTRACTLU_");
        modelBuilder.HasSequence("CONTRACTMEJ_");
        modelBuilder.HasSequence("CONTRACTMEJVH_");
        modelBuilder.HasSequence("CONTRACTMS_");
        modelBuilder.HasSequence("CONTRACTO_");
        modelBuilder.HasSequence("CONTRACTUALA_");
        modelBuilder.HasSequence("CONTRACTUALS_");
        modelBuilder.HasSequence("CONTRATENVIE_");
        modelBuilder.HasSequence("CONVENTION_");
        modelBuilder.HasSequence("CONVENTIONMODEL_");
        modelBuilder.HasSequence("CONVENTIONPDMC_");
        modelBuilder.HasSequence("CONVERSIONI_");
        modelBuilder.HasSequence("CONVERSIONISSUE_");
        modelBuilder.HasSequence("CORRECTIONDD_");
        modelBuilder.HasSequence("CORRECTIONDDVH_");
        modelBuilder.HasSequence("CORRECTIONVD_");
        modelBuilder.HasSequence("CORRECTIONVDVH_");
        modelBuilder.HasSequence("CORRESPBC_");
        modelBuilder.HasSequence("CORRESPBP_");
        modelBuilder.HasSequence("COUNTRY_");
        modelBuilder.HasSequence("COURSCC_");
        modelBuilder.HasSequence("COURT_");
        modelBuilder.HasSequence("COURTCASETYPE_");
        modelBuilder.HasSequence("CREATIONLAW_");
        modelBuilder.HasSequence("CREDITACQUEREUR_");
        modelBuilder.HasSequence("CREDITDMCB_");
        modelBuilder.HasSequence("CREDITDMCEC_");
        modelBuilder.HasSequence("CREDITDMCEVENT_");
        modelBuilder.HasSequence("CRITERIAEXP_");
        modelBuilder.HasSequence("CRITERIARR_");
        modelBuilder.HasSequence("CROCARTH_");
        modelBuilder.HasSequence("CROSSPARITY_");
        modelBuilder.HasSequence("CRVALHIS_");
        modelBuilder.HasSequence("CURDENOM_");
        modelBuilder.HasSequence("CURRENCY_");
        modelBuilder.HasSequence("CURRENCYDC_");
        modelBuilder.HasSequence("CURRENCYER_");
        modelBuilder.HasSequence("CURRENCYERI_");
        modelBuilder.HasSequence("CURRENCYERVH_");
        modelBuilder.HasSequence("CURRENCYPI_");
        modelBuilder.HasSequence("CURRENCYPS_");
        modelBuilder.HasSequence("CURRENCYPSVH_");
        modelBuilder.HasSequence("CURRENCYPT_");
        modelBuilder.HasSequence("D_AMTOPE_");
        modelBuilder.HasSequence("D_CONDITIONT_");
        modelBuilder.HasSequence("D_DATOPE_");
        modelBuilder.HasSequence("D_MSBPM_ABSTRAAN_");
        modelBuilder.HasSequence("D_MSBPM_AFFECTEG_");
        modelBuilder.HasSequence("D_MSBPM_AFFECTEU_");
        modelBuilder.HasSequence("D_MSBPM_ATTRIBUC_");
        modelBuilder.HasSequence("D_MSBPM_CUSTOME_");
        modelBuilder.HasSequence("D_MSBPM_CUSTOTAC_");
        modelBuilder.HasSequence("D_MSBPM_DELEGACV_");
        modelBuilder.HasSequence("D_MSBPM_DELEGATC_");
        modelBuilder.HasSequence("D_MSBPM_DELEGATCR_");
        modelBuilder.HasSequence("D_MSBPM_DELEGATI_");
        modelBuilder.HasSequence("D_MSBPM_EVENTC_");
        modelBuilder.HasSequence("D_MSBPM_EXCEPTIH_");
        modelBuilder.HasSequence("D_MSBPM_EXPRESSE_");
        modelBuilder.HasSequence("D_MSBPM_FINALNODE_");
        modelBuilder.HasSequence("D_MSBPM_GROUPA_");
        modelBuilder.HasSequence("D_MSBPM_INCOMINT_");
        modelBuilder.HasSequence("D_MSBPM_INITIALN_");
        modelBuilder.HasSequence("D_MSBPM_MESSAGET_");
        modelBuilder.HasSequence("D_MSBPM_NODEEVENT_");
        modelBuilder.HasSequence("D_MSBPM_NODEI_");
        modelBuilder.HasSequence("D_MSBPM_PARAMETC_");
        modelBuilder.HasSequence("D_MSBPM_PROCESDA_");
        modelBuilder.HasSequence("D_MSBPM_PROCESIT_");
        modelBuilder.HasSequence("D_MSBPM_PROCESSD_");
        modelBuilder.HasSequence("D_MSBPM_PROCESSI_");
        modelBuilder.HasSequence("D_MSBPM_TASKAC_");
        modelBuilder.HasSequence("D_MSBPM_TASKCC_");
        modelBuilder.HasSequence("D_MSBPM_TRANSITI_");
        modelBuilder.HasSequence("D_MSBPM_USECA_");
        modelBuilder.HasSequence("D_MSBPM_USECC_");
        modelBuilder.HasSequence("D_MSBPM_USECV_");
        modelBuilder.HasSequence("D_MSBPM_USERACTOR_");
        modelBuilder.HasSequence("D_MSDBD_AFFECTAT_");
        modelBuilder.HasSequence("D_MSDBD_ALERT_");
        modelBuilder.HasSequence("D_MSDBD_ATTRIBUC_");
        modelBuilder.HasSequence("D_MSDBD_DASHBOAA_");
        modelBuilder.HasSequence("D_MSDBD_DASHBOARD_");
        modelBuilder.HasSequence("D_MSDBD_DASHBOAT_");
        modelBuilder.HasSequence("D_MSDBD_METHODP_");
        modelBuilder.HasSequence("D_MSDBD_USECV_");
        modelBuilder.HasSequence("D_MSESB_ABSTRACT_");
        modelBuilder.HasSequence("D_MSESB_ABSTRADG_");
        modelBuilder.HasSequence("D_MSESB_AMOUNTD_");
        modelBuilder.HasSequence("D_MSESB_AMOUNTF_");
        modelBuilder.HasSequence("D_MSESB_ATTACHME_");
        modelBuilder.HasSequence("D_MSESB_ATTRIBUTE_");
        modelBuilder.HasSequence("D_MSESB_BIGDO_");
        modelBuilder.HasSequence("D_MSESB_BLOCK3C_");
        modelBuilder.HasSequence("D_MSESB_BLOCK3TAG_");
        modelBuilder.HasSequence("D_MSESB_BLOCK4C_");
        modelBuilder.HasSequence("D_MSESB_BLOCK4TAG_");
        modelBuilder.HasSequence("D_MSESB_BLOCK5C_");
        modelBuilder.HasSequence("D_MSESB_BLOCK5TAG_");
        modelBuilder.HasSequence("D_MSESB_BLOCKO_");
        modelBuilder.HasSequence("D_MSESB_CHAINC_");
        modelBuilder.HasSequence("D_MSESB_CHUNKV_");
        modelBuilder.HasSequence("D_MSESB_CLIENTE_");
        modelBuilder.HasSequence("D_MSESB_COMPUTEF_");
        modelBuilder.HasSequence("D_MSESB_CONDEC_");
        modelBuilder.HasSequence("D_MSESB_CONDITION_");
        modelBuilder.HasSequence("D_MSESB_CONTENTP_");
        modelBuilder.HasSequence("D_MSESB_CRITERIP_");
        modelBuilder.HasSequence("D_MSESB_CRITEROP_");
        modelBuilder.HasSequence("D_MSESB_DATABASC_");
        modelBuilder.HasSequence("D_MSESB_DATEO_");
        modelBuilder.HasSequence("D_MSESB_DEFERREM_");
        modelBuilder.HasSequence("D_MSESB_DESCRIPT_");
        modelBuilder.HasSequence("D_MSESB_DOUBLEO_");
        modelBuilder.HasSequence("D_MSESB_EDPTT_");
        modelBuilder.HasSequence("D_MSESB_EJBCONFIG_");
        modelBuilder.HasSequence("D_MSESB_ENDPOTPC_");
        modelBuilder.HasSequence("D_MSESB_ENTITYTE_");
        modelBuilder.HasSequence("D_MSESB_ENTITYTP_");
        modelBuilder.HasSequence("D_MSESB_ESBEVENT_");
        modelBuilder.HasSequence("D_MSESB_ESBMSG_");
        modelBuilder.HasSequence("D_MSESB_EXTERMSC_");
        modelBuilder.HasSequence("D_MSESB_FIELDTE_");
        modelBuilder.HasSequence("D_MSESB_FILENC_");
        modelBuilder.HasSequence("D_MSESB_FILENP_");
        modelBuilder.HasSequence("D_MSESB_FILETH_");
        modelBuilder.HasSequence("D_MSESB_FILETRACK_");
        modelBuilder.HasSequence("D_MSESB_FILTER_");
        modelBuilder.HasSequence("D_MSESB_GROUPIND_");
        modelBuilder.HasSequence("D_MSESB_GROUPINF_");
        modelBuilder.HasSequence("D_MSESB_HEADERP_");
        modelBuilder.HasSequence("D_MSESB_HOSTC_");
        modelBuilder.HasSequence("D_MSESB_INBOUNDE_");
        modelBuilder.HasSequence("D_MSESB_INBOUNDM_");
        modelBuilder.HasSequence("D_MSESB_INBOUNDR_");
        modelBuilder.HasSequence("D_MSESB_INBOUNRM_");
        modelBuilder.HasSequence("D_MSESB_INPUTN_");
        modelBuilder.HasSequence("D_MSESB_INRC_");
        modelBuilder.HasSequence("D_MSESB_INRE_");
        modelBuilder.HasSequence("D_MSESB_INTERMSC_");
        modelBuilder.HasSequence("D_MSESB_JDBCPC_");
        modelBuilder.HasSequence("D_MSESB_JMSD_");
        modelBuilder.HasSequence("D_MSESB_KIDOBJECT_");
        modelBuilder.HasSequence("D_MSESB_LDAPA_");
        modelBuilder.HasSequence("D_MSESB_LDAPC_");
        modelBuilder.HasSequence("D_MSESB_LDAPPC_");
        modelBuilder.HasSequence("D_MSESB_LISTBO_");
        modelBuilder.HasSequence("D_MSESB_LONGO_");
        modelBuilder.HasSequence("D_MSESB_MAILR_");
        modelBuilder.HasSequence("D_MSESB_MAILSP_");
        modelBuilder.HasSequence("D_MSESB_METHODP_");
        modelBuilder.HasSequence("D_MSESB_MSGTRACE_");
        modelBuilder.HasSequence("D_MSESB_NOTIFICE_");
        modelBuilder.HasSequence("D_MSESB_OUTBOUNE_");
        modelBuilder.HasSequence("D_MSESB_OUTBOUNR_");
        modelBuilder.HasSequence("D_MSESB_OUTPUTN_");
        modelBuilder.HasSequence("D_MSESB_OUTRC_");
        modelBuilder.HasSequence("D_MSESB_PARAMECT_");
        modelBuilder.HasSequence("D_MSESB_PARAMETER_");
        modelBuilder.HasSequence("D_MSESB_PARENTO_");
        modelBuilder.HasSequence("D_MSESB_PROCESSB_");
        modelBuilder.HasSequence("D_MSESB_PROCESSE_");
        modelBuilder.HasSequence("D_MSESB_PROFILE_");
        modelBuilder.HasSequence("D_MSESB_QUERYP_");
        modelBuilder.HasSequence("D_MSESB_QUEUETPC_");
        modelBuilder.HasSequence("D_MSESB_RECEIVEM_");
        modelBuilder.HasSequence("D_MSESB_RECYCLIM_");
        modelBuilder.HasSequence("D_MSESB_REPORTA_");
        modelBuilder.HasSequence("D_MSESB_RESPONSR_");
        modelBuilder.HasSequence("D_MSESB_RESPONST_");
        modelBuilder.HasSequence("D_MSESB_RESULTSC_");
        modelBuilder.HasSequence("D_MSESB_ROUTERE_");
        modelBuilder.HasSequence("D_MSESB_RSPRC_");
        modelBuilder.HasSequence("D_MSESB_SENTMSG_");
        modelBuilder.HasSequence("D_MSESB_SHEETCS_");
        modelBuilder.HasSequence("D_MSESB_SIMPLERA_");
        modelBuilder.HasSequence("D_MSESB_STRINGO_");
        modelBuilder.HasSequence("D_MSESB_SUBCB_");
        modelBuilder.HasSequence("D_MSESB_SUBFFB_");
        modelBuilder.HasSequence("D_MSESB_SYNCD_");
        modelBuilder.HasSequence("D_MSESB_TRANSFOK_");
        modelBuilder.HasSequence("D_MSESB_USERBC_");
        modelBuilder.HasSequence("D_MSESB_USERBT_");
        modelBuilder.HasSequence("D_MSESB_VALUE_");
        modelBuilder.HasSequence("D_MSESB_WSDLC_");
        modelBuilder.HasSequence("D_MSESB_XMLNP_");
        modelBuilder.HasSequence("D_MSETP_ASYNCHRM_");
        modelBuilder.HasSequence("D_MSETP_REMOTEC_");
        modelBuilder.HasSequence("D_MSIFR_ATTRIBUTE_");
        modelBuilder.HasSequence("D_MSIFR_DSLC_");
        modelBuilder.HasSequence("D_MSIFR_DSLE_");
        modelBuilder.HasSequence("D_MSIFR_FUNCTION_");
        modelBuilder.HasSequence("D_MSIFR_IMPORTA_");
        modelBuilder.HasSequence("D_MSIFR_INPUTV_");
        modelBuilder.HasSequence("D_MSIFR_OUTPUTV_");
        modelBuilder.HasSequence("D_MSIFR_RULE_");
        modelBuilder.HasSequence("D_MSIFR_RULEC_");
        modelBuilder.HasSequence("D_MSIFR_RULECOND_");
        modelBuilder.HasSequence("D_MSIFR_RULESET_");
        modelBuilder.HasSequence("D_MSJOB_PARAMETC_");
        modelBuilder.HasSequence("D_MSJOB_REPEATAB_");
        modelBuilder.HasSequence("D_MSJOB_SCHEDULER_");
        modelBuilder.HasSequence("D_MSJOB_TASKC_");
        modelBuilder.HasSequence("D_MSJOB_WORKFLOE_");
        modelBuilder.HasSequence("D_MSJOB_WORKFLOT_");
        modelBuilder.HasSequence("D_MSJOB_WORKFLOW_");
        modelBuilder.HasSequence("D_MSJOB_WORKFLTE_");
        modelBuilder.HasSequence("D_MSLOG_MASSAL_");
        modelBuilder.HasSequence("D_MSLOG_MASSINLC_");
        modelBuilder.HasSequence("D_MSLOG_MASSRL_");
        modelBuilder.HasSequence("D_MSRPT_AGGREGAL_");
        modelBuilder.HasSequence("D_MSRPT_AGREGATC_");
        modelBuilder.HasSequence("D_MSRPT_ALLOWEDG_");
        modelBuilder.HasSequence("D_MSRPT_COLUMNC_");
        modelBuilder.HasSequence("D_MSRPT_COLUMNCND_");
        modelBuilder.HasSequence("D_MSRPT_COLUMNF_");
        modelBuilder.HasSequence("D_MSRPT_CONDITIC_");
        modelBuilder.HasSequence("D_MSRPT_FIXEDC_");
        modelBuilder.HasSequence("D_MSRPT_FIXEDCF_");
        modelBuilder.HasSequence("D_MSRPT_FIXEDROW_");
        modelBuilder.HasSequence("D_MSRPT_GROUPF_");
        modelBuilder.HasSequence("D_MSRPT_GROUPH_");
        modelBuilder.HasSequence("D_MSRPT_GROUPINF_");
        modelBuilder.HasSequence("D_MSRPT_KEYFIELD_");
        modelBuilder.HasSequence("D_MSRPT_LINEC_");
        modelBuilder.HasSequence("D_MSRPT_LINEFONT_");
        modelBuilder.HasSequence("D_MSRPT_MASSJR_");
        modelBuilder.HasSequence("D_MSRPT_ORDERF_");
        modelBuilder.HasSequence("D_MSRPT_ORDERINF_");
        modelBuilder.HasSequence("D_MSRPT_PARENTC_");
        modelBuilder.HasSequence("D_MSRPT_REPETICO_");
        modelBuilder.HasSequence("D_MSRPT_REPORT_");
        modelBuilder.HasSequence("D_MSRPT_REPORTC_");
        modelBuilder.HasSequence("D_MSRPT_REPORTCRT_");
        modelBuilder.HasSequence("D_MSRPT_REPORTE_");
        modelBuilder.HasSequence("D_MSRPT_REPORTF_");
        modelBuilder.HasSequence("D_MSRPT_REPORTH_");
        modelBuilder.HasSequence("D_MSRPT_REPORTR_");
        modelBuilder.HasSequence("D_MSRPT_REPORTSC_");
        modelBuilder.HasSequence("D_MSRPT_REPORTV_");
        modelBuilder.HasSequence("D_MSRPT_RPTC_");
        modelBuilder.HasSequence("D_MSRPT_RPTQP_");
        modelBuilder.HasSequence("D_MSRPT_SERIE_");
        modelBuilder.HasSequence("D_MSRPT_SUBJR_");
        modelBuilder.HasSequence("D_MSRPT_TABLEC_");
        modelBuilder.HasSequence("D_MSRPT_TABLECF_");
        modelBuilder.HasSequence("D_MSRPT_TABLEG_");
        modelBuilder.HasSequence("D_MSRPT_TABLEGC_");
        modelBuilder.HasSequence("D_MSRPT_TXTAL_");
        modelBuilder.HasSequence("D_MSRPT_TXTE_");
        modelBuilder.HasSequence("D_MSRPT_TXTRC_");
        modelBuilder.HasSequence("D_MSRPT_TXTRPT_");
        modelBuilder.HasSequence("D_MSRPT_TXTTC_");
        modelBuilder.HasSequence("D_MSRPT_TXTTCP_");
        modelBuilder.HasSequence("D_MSRPT_UIC_");
        modelBuilder.HasSequence("D_MSRPT_UIELEMENT_");
        modelBuilder.HasSequence("D_MSRPT_UITC_");
        modelBuilder.HasSequence("D_MSRPT_VARIABLC_");
        modelBuilder.HasSequence("D_MSSEC_CONDITIP_");
        modelBuilder.HasSequence("D_MSSEC_DATAP_");
        modelBuilder.HasSequence("D_MSSEC_GROUPP_");
        modelBuilder.HasSequence("D_MSSEC_GROUPPRFL_");
        modelBuilder.HasSequence("D_MSSEC_MENU_");
        modelBuilder.HasSequence("D_MSSEC_PRIVILEGE_");
        modelBuilder.HasSequence("D_MSSEC_SECURITD_");
        modelBuilder.HasSequence("D_MSSEC_SERVICEM_");
        modelBuilder.HasSequence("D_MSSEC_SERVICEP_");
        modelBuilder.HasSequence("D_MSSEC_USERP_");
        modelBuilder.HasSequence("D_MSSEC_USERPRFL_");
        modelBuilder.HasSequence("D_MSSEC_USERPRVL_");
        modelBuilder.HasSequence("D_MSSEC_USERTE_");
        modelBuilder.HasSequence("D_MSTRP_COLUMNC_");
        modelBuilder.HasSequence("D_MSTRP_CONDITIC_");
        modelBuilder.HasSequence("D_MSTRP_CRITERIM_");
        modelBuilder.HasSequence("D_MSTRP_DOCUMENC_");
        modelBuilder.HasSequence("D_MSTRP_FONT_");
        modelBuilder.HasSequence("D_MSTRP_FOOTERC_");
        modelBuilder.HasSequence("D_MSTRP_GROUPBY_");
        modelBuilder.HasSequence("D_MSTRP_HEADERC_");
        modelBuilder.HasSequence("D_MSTRP_ORDERBY_");
        modelBuilder.HasSequence("D_MSTRP_PAGEC_");
        modelBuilder.HasSequence("D_MSTRP_REPORTC_");
        modelBuilder.HasSequence("D_MSTRP_REPORTV_");
        modelBuilder.HasSequence("D_MSTRP_TABLECFG_");
        modelBuilder.HasSequence("D_MSTRP_TABLECRT_");
        modelBuilder.HasSequence("D_MSTRP_TEXTFC_");
        modelBuilder.HasSequence("D_MSTRP_TEXTR_");
        modelBuilder.HasSequence("D_MSVLD_ACTION_");
        modelBuilder.HasSequence("D_MSVLD_MODIFICR_");
        modelBuilder.HasSequence("D_MSVLD_STEP_");
        modelBuilder.HasSequence("D_MSVLD_VALIDATI_");
        modelBuilder.HasSequence("D_MSVLD_VALIDATP_");
        modelBuilder.HasSequence("D_MSVLD_VALIDATR_");
        modelBuilder.HasSequence("D_PARAMDEF_");
        modelBuilder.HasSequence("D_STROPE_");
        modelBuilder.HasSequence("D_SWFTBLOK1_");
        modelBuilder.HasSequence("D_SWFTBLOK2_");
        modelBuilder.HasSequence("D_SWFTBLOK3_");
        modelBuilder.HasSequence("D_SWFTBLOK4_");
        modelBuilder.HasSequence("D_SWFTBLOK5_");
        modelBuilder.HasSequence("D_SWFTBUSER_");
        modelBuilder.HasSequence("D_TRANSITINS_");
        modelBuilder.HasSequence("D_TTY_OPERATION_");
        modelBuilder.HasSequence("DADINCUR_");
        modelBuilder.HasSequence("DATNAM_");
        modelBuilder.HasSequence("DAVEFEERULE_");
        modelBuilder.HasSequence("DAVEFRL_");
        modelBuilder.HasSequence("DAVEFRS_");
        modelBuilder.HasSequence("DAVEFRVH_");
        modelBuilder.HasSequence("DAVEGP_");
        modelBuilder.HasSequence("DAVEMSGCONFIG_");
        modelBuilder.HasSequence("DAVEPACKAGE_");
        modelBuilder.HasSequence("DAVINTRUL_");
        modelBuilder.HasSequence("DAVINTRULVH_");
        modelBuilder.HasSequence("DAVINTSCA_");
        modelBuilder.HasSequence("DDMRVALHIS_");
        modelBuilder.HasSequence("DEBITMVTHIS_");
        modelBuilder.HasSequence("DEBITORMOVEMENT_");
        modelBuilder.HasSequence("DEBLOCAGEDMCHIS_");
        modelBuilder.HasSequence("DEBREVOLVHIS_");
        modelBuilder.HasSequence("DEBTSD_");
        modelBuilder.HasSequence("DEBTSPL_");
        modelBuilder.HasSequence("DEBTSURRENDERVH_");
        modelBuilder.HasSequence("DECHEANCETVH_");
        modelBuilder.HasSequence("DECISIONHISTORY_");
        modelBuilder.HasSequence("DECISIONODR_");
        modelBuilder.HasSequence("DECOMPTE_");
        modelBuilder.HasSequence("DECOMPTEPROJET_");
        modelBuilder.HasSequence("DECOMPTETB_");
        modelBuilder.HasSequence("DELEGATEUR_");
        modelBuilder.HasSequence("DEMANDECOVID_");
        modelBuilder.HasSequence("DENOMINATIOND_");
        modelBuilder.HasSequence("DENOMINATIONT_");
        modelBuilder.HasSequence("DEPOSITREASON_");
        modelBuilder.HasSequence("DEPOSITWITHHELD_");
        modelBuilder.HasSequence("DEPOSITWVH_");
        modelBuilder.HasSequence("DEPOSTWT_");
        modelBuilder.HasSequence("DERIVATIVETYPE_");
        modelBuilder.HasSequence("DESIGNATIONCOUT_");
        modelBuilder.HasSequence("DESKOTCI_");
        modelBuilder.HasSequence("DETAILADF_");
        modelBuilder.HasSequence("DETAILDC_");
        modelBuilder.HasSequence("DETAILIMPAYES_");
        modelBuilder.HasSequence("DETAILPA_");
        modelBuilder.HasSequence("DETAILVISAPLAN_");
        modelBuilder.HasSequence("DETAILWA_");
        modelBuilder.HasSequence("DIFFEREDO_");
        modelBuilder.HasSequence("DIS_EVENT_COM_");
        modelBuilder.HasSequence("DISCCAVH_");
        modelBuilder.HasSequence("DISCLOREQMSG_");
        modelBuilder.HasSequence("DISCNTCOM_");
        modelBuilder.HasSequence("DISCOUNTEC_");
        modelBuilder.HasSequence("DISCOUNTED_");
        modelBuilder.HasSequence("DISCOUNTEDFILEDATA_");
        modelBuilder.HasSequence("DISCOUNTEDRI_");
        modelBuilder.HasSequence("DISCOUNTEVENT_");
        modelBuilder.HasSequence("DISCOUNTEVH_");
        modelBuilder.HasSequence("DISCOUNTMC_");
        modelBuilder.HasSequence("DISCOUNTMD_");
        modelBuilder.HasSequence("DISCOUNTMI_");
        modelBuilder.HasSequence("DISCOUNTRE_");
        modelBuilder.HasSequence("DISINT_");
        modelBuilder.HasSequence("DISMEJG_");
        modelBuilder.HasSequence("DISMODIFIEDCOM_");
        modelBuilder.HasSequence("DISNPEFDP_");
        modelBuilder.HasSequence("DIVERSE_OPERATION_REF");
        modelBuilder.HasSequence("DIVERSEO_");
        modelBuilder.HasSequence("DIVERSEOVH_");
        modelBuilder.HasSequence("DOCUMENT_");
        modelBuilder.HasSequence("DOCUMENTBP_");
        modelBuilder.HasSequence("DOCUMENTCARDDOCUME_");
        modelBuilder.HasSequence("DOCUMENTH_");
        modelBuilder.HasSequence("DOCUMENTSFAMILY_");
        modelBuilder.HasSequence("DOCUMENTSRA_");
        modelBuilder.HasSequence("DOCUMENTSRR_");
        modelBuilder.HasSequence("DOCUMENTSTBR_");
        modelBuilder.HasSequence("DOCUMENTSTYPE_");
        modelBuilder.HasSequence("DOCUMENTSTYPETEMPLATE_");
        modelBuilder.HasSequence("DOSSIERAA_");
        modelBuilder.HasSequence("DOSSIERID_");
        modelBuilder.HasSequence("DOSSIERPE_");
        modelBuilder.HasSequence("DOUANECUSTOM_");
        modelBuilder.HasSequence("DOWNLOADCONFIG_");
        modelBuilder.HasSequence("DOWNLOADP_");
        modelBuilder.HasSequence("DRAC_");
        modelBuilder.HasSequence("DRAWEE_");
        modelBuilder.HasSequence("DRAWEEACCOUNT_");
        modelBuilder.HasSequence("DRAWEEINCUR_");
        modelBuilder.HasSequence("DRAWEERATING_");
        modelBuilder.HasSequence("DURATIONTYPE_");
        modelBuilder.HasSequence("ECHEANCEIMPAYEE_");
        modelBuilder.HasSequence("ECHEANCIERD_");
        modelBuilder.HasSequence("ECHRET_");
        modelBuilder.HasSequence("ECONOMICA_");
        modelBuilder.HasSequence("ECONOMICFACTOR_");
        modelBuilder.HasSequence("ECONOMICFBC_");
        modelBuilder.HasSequence("EFALLINGDUE_");
        modelBuilder.HasSequence("EFDAPUREE_");
        modelBuilder.HasSequence("EFDPS_");
        modelBuilder.HasSequence("EFDSUBSTITUEE_");
        modelBuilder.HasSequence("ELEMCASDSK_");
        modelBuilder.HasSequence("ELEMENTC_");
        modelBuilder.HasSequence("ELEMENTCD_");
        modelBuilder.HasSequence("ELEMENTCOUT_");
        modelBuilder.HasSequence("ELEMENTER_");
        modelBuilder.HasSequence("ELEMENTPV_");
        modelBuilder.HasSequence("ELEMENTRECAPLOT_");
        modelBuilder.HasSequence("ELEMENTVDP_");
        modelBuilder.HasSequence("ELEMENTVENTE_");
        modelBuilder.HasSequence("ELIGIBILITEI_");
        modelBuilder.HasSequence("EMPLOISR_");
        modelBuilder.HasSequence("EMPLOYE_");
        modelBuilder.HasSequence("EMPLOYES_");
        modelBuilder.HasSequence("ENCOURSCLIENT_");
        modelBuilder.HasSequence("ENCOURSCU_");
        modelBuilder.HasSequence("ENCOURSE_");
        modelBuilder.HasSequence("ENCOURSGARANTIE_");
        modelBuilder.HasSequence("ENCOURSP_");
        modelBuilder.HasSequence("ENDORSER_");
        modelBuilder.HasSequence("ENRICHMENTER_");
        modelBuilder.HasSequence("ENROLLEMENTPC_");
        modelBuilder.HasSequence("ENTITY_");
        modelBuilder.HasSequence("ENTITYANOMALY_");
        modelBuilder.HasSequence("ENTITYCA_");
        modelBuilder.HasSequence("ENTITYCATEGORY_");
        modelBuilder.HasSequence("ENTITYDOCUMENT_");
        modelBuilder.HasSequence("ENTITYDOCUMENTDOCUMENTFI_");
        modelBuilder.HasSequence("ENTITYES_");
        modelBuilder.HasSequence("ENTITYFIELD_");
        modelBuilder.HasSequence("ENTITYFIELDTYPE_");
        modelBuilder.HasSequence("ENTITYIDENTIFIER");
        modelBuilder.HasSequence("ENTITYLABEL_");
        modelBuilder.HasSequence("ENTITYMODIFVH_");
        modelBuilder.HasSequence("ENTITYMS_");
        modelBuilder.HasSequence("ENTITYQUALITY_");
        modelBuilder.HasSequence("ENTITYROLE_");
        modelBuilder.HasSequence("ENTITYTYPEFIELD_");
        modelBuilder.HasSequence("ENTITYTYPEMODIF_");
        modelBuilder.HasSequence("ENTITYTYPEMODIFDATA_");
        modelBuilder.HasSequence("ENTITYV_");
        modelBuilder.HasSequence("ENTITYVH_");
        modelBuilder.HasSequence("ENUMERATIONFL_");
        modelBuilder.HasSequence("ENUMERATIONL_");
        modelBuilder.HasSequence("EPSBENEFICIARY_");
        modelBuilder.HasSequence("EPSGP_");
        modelBuilder.HasSequence("EPSNPEP_");
        modelBuilder.HasSequence("EQUILIBREF_");
        modelBuilder.HasSequence("EQUILIBREFP_");
        modelBuilder.HasSequence("ESBCLIENTEVENT_");
        modelBuilder.HasSequence("ESBEVENTS_");
        modelBuilder.HasSequence("ESTABLISHMENT_");
        modelBuilder.HasSequence("ETATAI_");
        modelBuilder.HasSequence("ETATSFA_");
        modelBuilder.HasSequence("EVENTC_");
        modelBuilder.HasSequence("EVENTCOM_");
        modelBuilder.HasSequence("EVOLUTIONCR_");
        modelBuilder.HasSequence("EXCEPTIONCLASSE_");
        modelBuilder.HasSequence("EXCESS_");
        modelBuilder.HasSequence("EXCHANGEDC_");
        modelBuilder.HasSequence("EXPERTISEGAGE_");
        modelBuilder.HasSequence("EXPERTISEGP_");
        modelBuilder.HasSequence("EXPLOITHUISSIER_");
        modelBuilder.HasSequence("EXPLOITHVH_");
        modelBuilder.HasSequence("EXPRESSIONRR_");
        modelBuilder.HasSequence("EXTERNALC_");
        modelBuilder.HasSequence("EXTERNALCVH_");
        modelBuilder.HasSequence("EXTERNALOE_");
        modelBuilder.HasSequence("FAISABILITET_");
        modelBuilder.HasSequence("FAISABILITETP_");
        modelBuilder.HasSequence("FALLINGDUE_");
        modelBuilder.HasSequence("FATCA_");
        modelBuilder.HasSequence("FEESAMOUNTS_");
        modelBuilder.HasSequence("FEESDETAIL_");
        modelBuilder.HasSequence("FEESORPC_");
        modelBuilder.HasSequence("FEESREGULE_");
        modelBuilder.HasSequence("FEETAC_");
        modelBuilder.HasSequence("FEETYPE_");
        modelBuilder.HasSequence("FICHEPRODUCT_");
        modelBuilder.HasSequence("FICHESOP_");
        modelBuilder.HasSequence("FICHESUIVIBAIL_");
        modelBuilder.HasSequence("FICSUIHYP_");
        modelBuilder.HasSequence("FIELDLABEL_");
        modelBuilder.HasSequence("FILESFCV_");
        modelBuilder.HasSequence("FINANCEDPOST_");
        modelBuilder.HasSequence("FINANCEMENTL_");
        modelBuilder.HasSequence("FINANCIALI_");
        modelBuilder.HasSequence("FINANCIALO_");
        modelBuilder.HasSequence("FINANCINGCP_");
        modelBuilder.HasSequence("FINANCINGNATURE_");
        modelBuilder.HasSequence("FINANCINGNSV_");
        modelBuilder.HasSequence("FINANCINGPOST_");
        modelBuilder.HasSequence("FINANCINGRRS_");
        modelBuilder.HasSequence("FINANCINGRSA_");
        modelBuilder.HasSequence("FINANCINGTBS_");
        modelBuilder.HasSequence("FINANCINGTV_");
        modelBuilder.HasSequence("FINANCINGTYPE_");
        modelBuilder.HasSequence("FINOPEREFERENCE");
        modelBuilder.HasSequence("FINOT_");
        modelBuilder.HasSequence("FINOTCI_");
        modelBuilder.HasSequence("FINOTD_");
        modelBuilder.HasSequence("FISCALNATURE_");
        modelBuilder.HasSequence("FISCALRS_");
        modelBuilder.HasSequence("FLUXANNUEL_");
        modelBuilder.HasSequence("FLUXMENSUEL_");
        modelBuilder.HasSequence("FLUXRECALCULE_");
        modelBuilder.HasSequence("FLUXTPI_");
        modelBuilder.HasSequence("FLUXTRESORERIE_");
        modelBuilder.HasSequence("FLUXTRIMESTRIEL_");
        modelBuilder.HasSequence("FONDGC_");
        modelBuilder.HasSequence("FONDORIGIN_");
        modelBuilder.HasSequence("FORCEBILLSTATUS_");
        modelBuilder.HasSequence("FORCINGAMOUNT_");
        modelBuilder.HasSequence("FORCINGIE_");
        modelBuilder.HasSequence("FORCINGMCNE_");
        modelBuilder.HasSequence("FORCINGMCNEVH_");
        modelBuilder.HasSequence("FORCINGPE_");
        modelBuilder.HasSequence("FORCINGPECLIENT_");
        modelBuilder.HasSequence("FORCINGPECLIENTVH_");
        modelBuilder.HasSequence("FORCINGPECONTRACT_");
        modelBuilder.HasSequence("FORCINGPEVH_");
        modelBuilder.HasSequence("FOREXOPERATION_");
        modelBuilder.HasSequence("FOURCHETTER_");
        modelBuilder.HasSequence("FRANCHISEPERIOD_");
        modelBuilder.HasSequence("FRCONTEXTVALUE_");
        modelBuilder.HasSequence("FREEREDEMPTION_");
        modelBuilder.HasSequence("FREEZEDECISION_");
        modelBuilder.HasSequence("FTAPPCONDITION_");
        modelBuilder.HasSequence("GARANTIEMIG_");
        modelBuilder.HasSequence("GARNISHEDA_");
        modelBuilder.HasSequence("GARNISHMENTVH_");
        modelBuilder.HasSequence("GENERALP_");
        modelBuilder.HasSequence("GENERICCALENDAR_");
        modelBuilder.HasSequence("GENERICCE_");
        modelBuilder.HasSequence("GENERICPDVH_");
        modelBuilder.HasSequence("GENERICPU_");
        modelBuilder.HasSequence("GEOGRAPHICAREA_");
        modelBuilder.HasSequence("GLOANNREV_");
        modelBuilder.HasSequence("GLOANNREVH_");
        modelBuilder.HasSequence("GLOBALCURREVH_");
        modelBuilder.HasSequence("GLOBALEE_");
        modelBuilder.HasSequence("GLOBALOC_");
        modelBuilder.HasSequence("GLOBALTEG_");
        modelBuilder.HasSequence("GLOCURREV_");
        modelBuilder.HasSequence("GROUPA_");
        modelBuilder.HasSequence("GROUPE_");
        modelBuilder.HasSequence("GROUPEDFCP_");
        modelBuilder.HasSequence("GROUPEDI_");
        modelBuilder.HasSequence("GROUPEDPW_");
        modelBuilder.HasSequence("GROUPETYPE_");
        modelBuilder.HasSequence("GRPISI_");
        modelBuilder.HasSequence("GVGENERALPARAMS_");
        modelBuilder.HasSequence("GVRP_");
        modelBuilder.HasSequence("HISTCAER_");
        modelBuilder.HasSequence("HISTORICD_");
        modelBuilder.HasSequence("HISTORICRATE_");
        modelBuilder.HasSequence("HISTORIQUEDLF_");
        modelBuilder.HasSequence("IDDOCUMENT_");
        modelBuilder.HasSequence("IDDOCUMENTTYPE_");
        modelBuilder.HasSequence("IFOBJECT_");
        modelBuilder.HasSequence("IMPACTEDLIMIT_");
        modelBuilder.HasSequence("IMPACTLINE_");
        modelBuilder.HasSequence("IMPORTDO_");
        modelBuilder.HasSequence("IMPORTDOLARGEFILE_");
        modelBuilder.HasSequence("IMPORTPC_");
        modelBuilder.HasSequence("IMPORTPCFILE_");
        modelBuilder.HasSequence("INACTIVITYD_");
        modelBuilder.HasSequence("INACTIVITYP_");
        modelBuilder.HasSequence("INCCLOMEJDETAIL_");
        modelBuilder.HasSequence("INCIDENPL_");
        modelBuilder.HasSequence("INCIDENTDMCHIS_");
        modelBuilder.HasSequence("INCIDENTGP_");
        modelBuilder.HasSequence("INCIDENTPAYMENT_");
        modelBuilder.HasSequence("INCOMETC_");
        modelBuilder.HasSequence("INCURVISION_");
        modelBuilder.HasSequence("INFODC_");
        modelBuilder.HasSequence("INFORMATIONE_");
        modelBuilder.HasSequence("INJECTEDPC_");
        modelBuilder.HasSequence("INJECTEDPCLARGEFILE_");
        modelBuilder.HasSequence("INQUIRYCOMMENT_");
        modelBuilder.HasSequence("INQUIRYSOURCE_");
        modelBuilder.HasSequence("INQUIRYSOUSTYPE_");
        modelBuilder.HasSequence("INQUIRYTYPE_");
        modelBuilder.HasSequence("INSCRIPTIONFICP_");
        modelBuilder.HasSequence("INSEXVH_");
        modelBuilder.HasSequence("INSFINREP_");
        modelBuilder.HasSequence("INSJURREP_");
        modelBuilder.HasSequence("INSPECTEVENTVH_");
        modelBuilder.HasSequence("INSPECTIONDMCVH_");
        modelBuilder.HasSequence("INSTCHREP_");
        modelBuilder.HasSequence("INSTRUCTIONA_");
        modelBuilder.HasSequence("INSTRUCTIONDT_");
        modelBuilder.HasSequence("INSTRUCTIONDTTEMPLATE_");
        modelBuilder.HasSequence("INSTRUCTIONFCV_");
        modelBuilder.HasSequence("INSTRUCTIONFEES_");
        modelBuilder.HasSequence("INSTRUCTIONP_");
        modelBuilder.HasSequence("INSTRUCTIONRU_");
        modelBuilder.HasSequence("INSURANCEADDVH_");
        modelBuilder.HasSequence("INSURANCEC_");
        modelBuilder.HasSequence("INSURANCED_");
        modelBuilder.HasSequence("INSURANCERD_");
        modelBuilder.HasSequence("INSURANCERETINC_");
        modelBuilder.HasSequence("INTERESTRL_");
        modelBuilder.HasSequence("INTERVENANT_");
        modelBuilder.HasSequence("INTERVENANTR_");
        modelBuilder.HasSequence("INV_CAPITAL_");
        modelBuilder.HasSequence("INV_CGPCCVI_");
        modelBuilder.HasSequence("INV_CGPCI_");
        modelBuilder.HasSequence("INV_CGPCIVH_");
        modelBuilder.HasSequence("INV_CGPII_");
        modelBuilder.HasSequence("INV_CGPIIVH_");
        modelBuilder.HasSequence("INV_COMMISRDIV_");
        modelBuilder.HasSequence("INV_COMMISRDSI_");
        modelBuilder.HasSequence("INV_COMMISSIOD_");
        modelBuilder.HasSequence("INV_COMMISSIOR_");
        modelBuilder.HasSequence("INV_COMMISSITI_");
        modelBuilder.HasSequence("INV_COMMISSRDI_");
        modelBuilder.HasSequence("INV_DELIVERYTR_");
        modelBuilder.HasSequence("INV_DETAILOP_");
        modelBuilder.HasSequence("INV_INTERERSDI_");
        modelBuilder.HasSequence("INV_INTERESCVI_");
        modelBuilder.HasSequence("INV_INTERESDIS_");
        modelBuilder.HasSequence("INV_INTERESRDI_");
        modelBuilder.HasSequence("INV_INTERESTD_");
        modelBuilder.HasSequence("INV_INTERESTRI_");
        modelBuilder.HasSequence("INV_INTERRDIVH_");
        modelBuilder.HasSequence("INV_INVESTMCVH_");
        modelBuilder.HasSequence("INV_INVESTMENE_");
        modelBuilder.HasSequence("INV_INVESTMENO_");
        modelBuilder.HasSequence("INV_INVESTMEVH_");
        modelBuilder.HasSequence("INV_INVESTMOVH_");
        modelBuilder.HasSequence("INV_MODIFICATEINVCONTRAC_");
        modelBuilder.HasSequence("INV_OPERATIONI_");
        modelBuilder.HasSequence("INV_OPERATIONP_");
        modelBuilder.HasSequence("INV_PAYEMENTTR_");
        modelBuilder.HasSequence("INV_PAYMENTRVH_");
        modelBuilder.HasSequence("INV_PERIODICITY_");
        modelBuilder.HasSequence("INVANTICIPCOND_");
        modelBuilder.HasSequence("INVCPI_");
        modelBuilder.HasSequence("INVESTMENTCV_");
        modelBuilder.HasSequence("INVESTMENTPOST_");
        modelBuilder.HasSequence("INVESTMENTPT_");
        modelBuilder.HasSequence("INVESTMENTRP_");
        modelBuilder.HasSequence("INVPPS_");
        modelBuilder.HasSequence("ISREMITTANCELARGEFILE_");
        modelBuilder.HasSequence("JUDGMENTES_");
        modelBuilder.HasSequence("JURIDICALD_");
        modelBuilder.HasSequence("JURIDICALFORM_");
        modelBuilder.HasSequence("JURIDICALS_");
        modelBuilder.HasSequence("JUSTIFICATIFDC_");
        modelBuilder.HasSequence("JUSTIFICATIFDCFICHIER_");
        modelBuilder.HasSequence("L_AMTOPE_");
        modelBuilder.HasSequence("L_CONDITIONT_");
        modelBuilder.HasSequence("L_DATOPE_");
        modelBuilder.HasSequence("L_MESSAGESTG_");
        modelBuilder.HasSequence("L_MSBPM_ABSTRAAN_");
        modelBuilder.HasSequence("L_MSBPM_AFFECTEG_");
        modelBuilder.HasSequence("L_MSBPM_AFFECTEU_");
        modelBuilder.HasSequence("L_MSBPM_ATTRIBUC_");
        modelBuilder.HasSequence("L_MSBPM_CUSTOTAC_");
        modelBuilder.HasSequence("L_MSBPM_DELEGACV_");
        modelBuilder.HasSequence("L_MSBPM_DELEGATC_");
        modelBuilder.HasSequence("L_MSBPM_DELEGATCR_");
        modelBuilder.HasSequence("L_MSBPM_DELEGATI_");
        modelBuilder.HasSequence("L_MSBPM_EVENTC_");
        modelBuilder.HasSequence("L_MSBPM_EXCEPTIH_");
        modelBuilder.HasSequence("L_MSBPM_FINALNODE_");
        modelBuilder.HasSequence("L_MSBPM_GROUPA_");
        modelBuilder.HasSequence("L_MSBPM_INCOMINT_");
        modelBuilder.HasSequence("L_MSBPM_INITIALN_");
        modelBuilder.HasSequence("L_MSBPM_MESSAGET_");
        modelBuilder.HasSequence("L_MSBPM_NODEI_");
        modelBuilder.HasSequence("L_MSBPM_PARAMETC_");
        modelBuilder.HasSequence("L_MSBPM_PROCESDA_");
        modelBuilder.HasSequence("L_MSBPM_PROCESIT_");
        modelBuilder.HasSequence("L_MSBPM_PROCESSD_");
        modelBuilder.HasSequence("L_MSBPM_PROCESSI_");
        modelBuilder.HasSequence("L_MSBPM_TASKAC_");
        modelBuilder.HasSequence("L_MSBPM_TASKCC_");
        modelBuilder.HasSequence("L_MSBPM_TRANSITI_");
        modelBuilder.HasSequence("L_MSBPM_USECA_");
        modelBuilder.HasSequence("L_MSBPM_USECC_");
        modelBuilder.HasSequence("L_MSBPM_USECV_");
        modelBuilder.HasSequence("L_MSBPM_USERACTOR_");
        modelBuilder.HasSequence("L_MSDBD_AFFECTAT_");
        modelBuilder.HasSequence("L_MSDBD_ALERT_");
        modelBuilder.HasSequence("L_MSDBD_ATTRIBUC_");
        modelBuilder.HasSequence("L_MSDBD_DASHBOAA_");
        modelBuilder.HasSequence("L_MSDBD_DASHBOARD_");
        modelBuilder.HasSequence("L_MSDBD_DASHBOAT_");
        modelBuilder.HasSequence("L_MSDBD_METHODP_");
        modelBuilder.HasSequence("L_MSDBD_USECV_");
        modelBuilder.HasSequence("L_MSESB_ABSTRACT_");
        modelBuilder.HasSequence("L_MSESB_ABSTRADG_");
        modelBuilder.HasSequence("L_MSESB_AMOUNTD_");
        modelBuilder.HasSequence("L_MSESB_AMOUNTF_");
        modelBuilder.HasSequence("L_MSESB_ATTACHME_");
        modelBuilder.HasSequence("L_MSESB_ATTRIBUTE_");
        modelBuilder.HasSequence("L_MSESB_BIGDO_");
        modelBuilder.HasSequence("L_MSESB_BLOCK3C_");
        modelBuilder.HasSequence("L_MSESB_BLOCK3TAG_");
        modelBuilder.HasSequence("L_MSESB_BLOCK4C_");
        modelBuilder.HasSequence("L_MSESB_BLOCK4TAG_");
        modelBuilder.HasSequence("L_MSESB_BLOCK5C_");
        modelBuilder.HasSequence("L_MSESB_BLOCK5TAG_");
        modelBuilder.HasSequence("L_MSESB_BLOCKO_");
        modelBuilder.HasSequence("L_MSESB_CHAINC_");
        modelBuilder.HasSequence("L_MSESB_CHUNKV_");
        modelBuilder.HasSequence("L_MSESB_CLIENTE_");
        modelBuilder.HasSequence("L_MSESB_COMPUTEF_");
        modelBuilder.HasSequence("L_MSESB_CONDEC_");
        modelBuilder.HasSequence("L_MSESB_CONDITION_");
        modelBuilder.HasSequence("L_MSESB_CONTENTP_");
        modelBuilder.HasSequence("L_MSESB_CRITERIP_");
        modelBuilder.HasSequence("L_MSESB_CRITEROP_");
        modelBuilder.HasSequence("L_MSESB_DATABASC_");
        modelBuilder.HasSequence("L_MSESB_DATEO_");
        modelBuilder.HasSequence("L_MSESB_DEFERREM_");
        modelBuilder.HasSequence("L_MSESB_DESCRIPT_");
        modelBuilder.HasSequence("L_MSESB_DOUBLEO_");
        modelBuilder.HasSequence("L_MSESB_EDPTT_");
        modelBuilder.HasSequence("L_MSESB_EJBCONFIG_");
        modelBuilder.HasSequence("L_MSESB_ENDPOTPC_");
        modelBuilder.HasSequence("L_MSESB_ENTITYTE_");
        modelBuilder.HasSequence("L_MSESB_ENTITYTP_");
        modelBuilder.HasSequence("L_MSESB_ESBEVENT_");
        modelBuilder.HasSequence("L_MSESB_ESBMSG_");
        modelBuilder.HasSequence("L_MSESB_EXTERMSC_");
        modelBuilder.HasSequence("L_MSESB_FIELDTE_");
        modelBuilder.HasSequence("L_MSESB_FILENC_");
        modelBuilder.HasSequence("L_MSESB_FILENP_");
        modelBuilder.HasSequence("L_MSESB_FILETH_");
        modelBuilder.HasSequence("L_MSESB_FILETRACK_");
        modelBuilder.HasSequence("L_MSESB_FILTER_");
        modelBuilder.HasSequence("L_MSESB_GROUPIND_");
        modelBuilder.HasSequence("L_MSESB_GROUPINF_");
        modelBuilder.HasSequence("L_MSESB_HEADERP_");
        modelBuilder.HasSequence("L_MSESB_HOSTC_");
        modelBuilder.HasSequence("L_MSESB_INBOUNDE_");
        modelBuilder.HasSequence("L_MSESB_INBOUNDM_");
        modelBuilder.HasSequence("L_MSESB_INBOUNDR_");
        modelBuilder.HasSequence("L_MSESB_INBOUNRM_");
        modelBuilder.HasSequence("L_MSESB_INPUTN_");
        modelBuilder.HasSequence("L_MSESB_INRC_");
        modelBuilder.HasSequence("L_MSESB_INRE_");
        modelBuilder.HasSequence("L_MSESB_INTERMSC_");
        modelBuilder.HasSequence("L_MSESB_JDBCPC_");
        modelBuilder.HasSequence("L_MSESB_JMSD_");
        modelBuilder.HasSequence("L_MSESB_KIDOBJECT_");
        modelBuilder.HasSequence("L_MSESB_LDAPA_");
        modelBuilder.HasSequence("L_MSESB_LDAPC_");
        modelBuilder.HasSequence("L_MSESB_LDAPPC_");
        modelBuilder.HasSequence("L_MSESB_LISTBO_");
        modelBuilder.HasSequence("L_MSESB_LONGO_");
        modelBuilder.HasSequence("L_MSESB_MAILR_");
        modelBuilder.HasSequence("L_MSESB_MAILSP_");
        modelBuilder.HasSequence("L_MSESB_METHODP_");
        modelBuilder.HasSequence("L_MSESB_MSGTRACE_");
        modelBuilder.HasSequence("L_MSESB_NOTIFICE_");
        modelBuilder.HasSequence("L_MSESB_OUTBOUNE_");
        modelBuilder.HasSequence("L_MSESB_OUTBOUNR_");
        modelBuilder.HasSequence("L_MSESB_OUTPUTN_");
        modelBuilder.HasSequence("L_MSESB_OUTRC_");
        modelBuilder.HasSequence("L_MSESB_PARAMECT_");
        modelBuilder.HasSequence("L_MSESB_PARAMETER_");
        modelBuilder.HasSequence("L_MSESB_PARENTO_");
        modelBuilder.HasSequence("L_MSESB_PROCESSB_");
        modelBuilder.HasSequence("L_MSESB_PROCESSE_");
        modelBuilder.HasSequence("L_MSESB_PROFILE_");
        modelBuilder.HasSequence("L_MSESB_QUERYP_");
        modelBuilder.HasSequence("L_MSESB_QUEUETPC_");
        modelBuilder.HasSequence("L_MSESB_RECEIVEM_");
        modelBuilder.HasSequence("L_MSESB_RECYCLIM_");
        modelBuilder.HasSequence("L_MSESB_REPORTA_");
        modelBuilder.HasSequence("L_MSESB_RESPONSR_");
        modelBuilder.HasSequence("L_MSESB_RESPONST_");
        modelBuilder.HasSequence("L_MSESB_RESULTSC_");
        modelBuilder.HasSequence("L_MSESB_ROUTERE_");
        modelBuilder.HasSequence("L_MSESB_RSPRC_");
        modelBuilder.HasSequence("L_MSESB_SENTMSG_");
        modelBuilder.HasSequence("L_MSESB_SHEETCS_");
        modelBuilder.HasSequence("L_MSESB_SIMPLERA_");
        modelBuilder.HasSequence("L_MSESB_STRINGO_");
        modelBuilder.HasSequence("L_MSESB_SUBCB_");
        modelBuilder.HasSequence("L_MSESB_SUBFFB_");
        modelBuilder.HasSequence("L_MSESB_SYNCD_");
        modelBuilder.HasSequence("L_MSESB_TRANSFOK_");
        modelBuilder.HasSequence("L_MSESB_USERBC_");
        modelBuilder.HasSequence("L_MSESB_USERBT_");
        modelBuilder.HasSequence("L_MSESB_VALUE_");
        modelBuilder.HasSequence("L_MSESB_WSDLC_");
        modelBuilder.HasSequence("L_MSESB_XMLNP_");
        modelBuilder.HasSequence("L_MSETP_ASYNCHRM_");
        modelBuilder.HasSequence("L_MSETP_REMOTEC_");
        modelBuilder.HasSequence("L_MSJOB_PARAMETC_");
        modelBuilder.HasSequence("L_MSJOB_REPEATAB_");
        modelBuilder.HasSequence("L_MSJOB_SCHEDULER_");
        modelBuilder.HasSequence("L_MSJOB_TASKC_");
        modelBuilder.HasSequence("L_MSJOB_WORKFLOE_");
        modelBuilder.HasSequence("L_MSJOB_WORKFLOT_");
        modelBuilder.HasSequence("L_MSJOB_WORKFLOW_");
        modelBuilder.HasSequence("L_MSJOB_WORKFLTE_");
        modelBuilder.HasSequence("L_MSLOG_MASSAL_");
        modelBuilder.HasSequence("L_MSLOG_MASSINLC_");
        modelBuilder.HasSequence("L_MSLOG_MASSRL_");
        modelBuilder.HasSequence("L_MSRPT_AGGREGAL_");
        modelBuilder.HasSequence("L_MSRPT_AGREGATC_");
        modelBuilder.HasSequence("L_MSRPT_ALLOWEDG_");
        modelBuilder.HasSequence("L_MSRPT_COLUMNC_");
        modelBuilder.HasSequence("L_MSRPT_COLUMNCND_");
        modelBuilder.HasSequence("L_MSRPT_COLUMNF_");
        modelBuilder.HasSequence("L_MSRPT_CONDITIC_");
        modelBuilder.HasSequence("L_MSRPT_FIXEDC_");
        modelBuilder.HasSequence("L_MSRPT_FIXEDCF_");
        modelBuilder.HasSequence("L_MSRPT_FIXEDROW_");
        modelBuilder.HasSequence("L_MSRPT_GROUPF_");
        modelBuilder.HasSequence("L_MSRPT_GROUPH_");
        modelBuilder.HasSequence("L_MSRPT_GROUPINF_");
        modelBuilder.HasSequence("L_MSRPT_KEYFIELD_");
        modelBuilder.HasSequence("L_MSRPT_LINEC_");
        modelBuilder.HasSequence("L_MSRPT_LINEFONT_");
        modelBuilder.HasSequence("L_MSRPT_MASSJR_");
        modelBuilder.HasSequence("L_MSRPT_ORDERF_");
        modelBuilder.HasSequence("L_MSRPT_ORDERINF_");
        modelBuilder.HasSequence("L_MSRPT_PARENTC_");
        modelBuilder.HasSequence("L_MSRPT_REPETICO_");
        modelBuilder.HasSequence("L_MSRPT_REPORT_");
        modelBuilder.HasSequence("L_MSRPT_REPORTC_");
        modelBuilder.HasSequence("L_MSRPT_REPORTCRT_");
        modelBuilder.HasSequence("L_MSRPT_REPORTE_");
        modelBuilder.HasSequence("L_MSRPT_REPORTF_");
        modelBuilder.HasSequence("L_MSRPT_REPORTH_");
        modelBuilder.HasSequence("L_MSRPT_REPORTR_");
        modelBuilder.HasSequence("L_MSRPT_REPORTSC_");
        modelBuilder.HasSequence("L_MSRPT_REPORTV_");
        modelBuilder.HasSequence("L_MSRPT_RPTC_");
        modelBuilder.HasSequence("L_MSRPT_RPTQP_");
        modelBuilder.HasSequence("L_MSRPT_SERIE_");
        modelBuilder.HasSequence("L_MSRPT_SUBJR_");
        modelBuilder.HasSequence("L_MSRPT_TABLEC_");
        modelBuilder.HasSequence("L_MSRPT_TABLECF_");
        modelBuilder.HasSequence("L_MSRPT_TABLEG_");
        modelBuilder.HasSequence("L_MSRPT_TABLEGC_");
        modelBuilder.HasSequence("L_MSRPT_TXTAL_");
        modelBuilder.HasSequence("L_MSRPT_TXTE_");
        modelBuilder.HasSequence("L_MSRPT_TXTRC_");
        modelBuilder.HasSequence("L_MSRPT_TXTRPT_");
        modelBuilder.HasSequence("L_MSRPT_TXTTC_");
        modelBuilder.HasSequence("L_MSRPT_TXTTCP_");
        modelBuilder.HasSequence("L_MSRPT_UIC_");
        modelBuilder.HasSequence("L_MSRPT_UIELEMENT_");
        modelBuilder.HasSequence("L_MSRPT_UITC_");
        modelBuilder.HasSequence("L_MSRPT_VARIABLC_");
        modelBuilder.HasSequence("L_MSSEC_CONDITIP_");
        modelBuilder.HasSequence("L_MSSEC_DATAP_");
        modelBuilder.HasSequence("L_MSSEC_GROUPP_");
        modelBuilder.HasSequence("L_MSSEC_GROUPPRFL_");
        modelBuilder.HasSequence("L_MSSEC_MENU_");
        modelBuilder.HasSequence("L_MSSEC_PRIVILEGE_");
        modelBuilder.HasSequence("L_MSSEC_SECURITD_");
        modelBuilder.HasSequence("L_MSSEC_SERVICEM_");
        modelBuilder.HasSequence("L_MSSEC_SERVICEP_");
        modelBuilder.HasSequence("L_MSSEC_USERPRFL_");
        modelBuilder.HasSequence("L_MSSEC_USERPRVL_");
        modelBuilder.HasSequence("L_MSSEC_USERTE_");
        modelBuilder.HasSequence("L_MSTRP_COLUMNC_");
        modelBuilder.HasSequence("L_MSTRP_CONDITIC_");
        modelBuilder.HasSequence("L_MSTRP_CRITERIM_");
        modelBuilder.HasSequence("L_MSTRP_DOCUMENC_");
        modelBuilder.HasSequence("L_MSTRP_FONT_");
        modelBuilder.HasSequence("L_MSTRP_FOOTERC_");
        modelBuilder.HasSequence("L_MSTRP_GROUPBY_");
        modelBuilder.HasSequence("L_MSTRP_HEADERC_");
        modelBuilder.HasSequence("L_MSTRP_ORDERBY_");
        modelBuilder.HasSequence("L_MSTRP_PAGEC_");
        modelBuilder.HasSequence("L_MSTRP_REPORTC_");
        modelBuilder.HasSequence("L_MSTRP_REPORTV_");
        modelBuilder.HasSequence("L_MSTRP_TABLECFG_");
        modelBuilder.HasSequence("L_MSTRP_TABLECRT_");
        modelBuilder.HasSequence("L_MSTRP_TEXTFC_");
        modelBuilder.HasSequence("L_MSTRP_TEXTR_");
        modelBuilder.HasSequence("L_MSVLD_ACTION_");
        modelBuilder.HasSequence("L_MSVLD_MODIFICR_");
        modelBuilder.HasSequence("L_MSVLD_STEP_");
        modelBuilder.HasSequence("L_MSVLD_VALIDATI_");
        modelBuilder.HasSequence("L_MSVLD_VALIDATP_");
        modelBuilder.HasSequence("L_MSVLD_VALIDATR_");
        modelBuilder.HasSequence("L_PARAMDEF_");
        modelBuilder.HasSequence("L_STROPE_");
        modelBuilder.HasSequence("L_SWFTBLOK1_");
        modelBuilder.HasSequence("L_SWFTBLOK2_");
        modelBuilder.HasSequence("L_SWFTBLOK3_");
        modelBuilder.HasSequence("L_SWFTBLOK4_");
        modelBuilder.HasSequence("L_SWFTBLOK5_");
        modelBuilder.HasSequence("L_SWFTBUSER_");
        modelBuilder.HasSequence("L_TRANSITINS_");
        modelBuilder.HasSequence("L_TTY_OPERATION_");
        modelBuilder.HasSequence("LEVEEIDMCH_");
        modelBuilder.HasSequence("LEVEEMEDVH_");
        modelBuilder.HasSequence("LEVELINTRUCTION_");
        modelBuilder.HasSequence("LIBERATIONABRH_");
        modelBuilder.HasSequence("LIBERATIONABVH_");
        modelBuilder.HasSequence("LIBERATIONDVH_");
        modelBuilder.HasSequence("LIBERATIONRG_");
        modelBuilder.HasSequence("LIBERATIONRGH_");
        modelBuilder.HasSequence("LIMITE_");
        modelBuilder.HasSequence("LINECED_");
        modelBuilder.HasSequence("LINECEFC_");
        modelBuilder.HasSequence("LINECRDACPH_");
        modelBuilder.HasSequence("LINECRDREVH_");
        modelBuilder.HasSequence("LINECRDRNGH_");
        modelBuilder.HasSequence("LINECRDRNWH_");
        modelBuilder.HasSequence("LINECRDTMPXH_");
        modelBuilder.HasSequence("LINECREDITEVENT_");
        modelBuilder.HasSequence("LINEOCAH_");
        modelBuilder.HasSequence("LINEOCP_");
        modelBuilder.HasSequence("LINEOCSH_");
        modelBuilder.HasSequence("LINEOFCREDITCOM_");
        modelBuilder.HasSequence("LIQUIDATION_");
        modelBuilder.HasSequence("LIQUIDATIONF_");
        modelBuilder.HasSequence("LISTCC_");
        modelBuilder.HasSequence("LOAN_");
        modelBuilder.HasSequence("LOANDATA_");
        modelBuilder.HasSequence("LOANEVENT_");
        modelBuilder.HasSequence("LOANEVENTDOC_");
        modelBuilder.HasSequence("LOANEVENTDOCFILEDATA_");
        modelBuilder.HasSequence("LOANEVNCNS_");
        modelBuilder.HasSequence("LOANFR_");
        modelBuilder.HasSequence("LOANINSTITUTION_");
        modelBuilder.HasSequence("LOANMSGCONFIG_");
        modelBuilder.HasSequence("LOANRATESCALE_");
        modelBuilder.HasSequence("LOCAL_DEPOSIT_REF").IncrementsBy(49441);
        modelBuilder.HasSequence("LOCAL_WITHDRAW_REF").IncrementsBy(184900);
        modelBuilder.HasSequence("LOCALDEPOSITOPE_");
        modelBuilder.HasSequence("LOCALWITHDRAWO_");
        modelBuilder.HasSequence("LOCALWITHDRAWR_");
        modelBuilder.HasSequence("LOCALWITHDRAWVH_");
        modelBuilder.HasSequence("LOCATIONBP_");
        modelBuilder.HasSequence("LOCATIONBPVH_");
        modelBuilder.HasSequence("LOCATIONCOFFRE_");
        modelBuilder.HasSequence("LOCATIONCVH_");
        modelBuilder.HasSequence("LOCK_ACC_REF");
        modelBuilder.HasSequence("LOCKAR_");
        modelBuilder.HasSequence("LOCKARVH_");
        modelBuilder.HasSequence("LON_CGPI_");
        modelBuilder.HasSequence("LON_CGPINSVH_");
        modelBuilder.HasSequence("LON_CGPLCVH_");
        modelBuilder.HasSequence("LON_CGPLIVH_");
        modelBuilder.HasSequence("LON_CGPLOAN_");
        modelBuilder.HasSequence("LON_CGPLVH_");
        modelBuilder.HasSequence("LON_COMMISSITP_");
        modelBuilder.HasSequence("LON_INSURANCCV_");
        modelBuilder.HasSequence("LON_INSURANCET_");
        modelBuilder.HasSequence("LON_INSURANCTP_");
        modelBuilder.HasSequence("LON_LOANCCV_");
        modelBuilder.HasSequence("LON_LOANCV_");
        modelBuilder.HasSequence("LON_LOANICV_");
        modelBuilder.HasSequence("LON_MOYENPA_");
        modelBuilder.HasSequence("LON_ONACP_");
        modelBuilder.HasSequence("LONAUTHOBJ_");
        modelBuilder.HasSequence("LOTPROJETIMMO_");
        modelBuilder.HasSequence("LOTRUBRIQUECOUT_");
        modelBuilder.HasSequence("LOYERPP_");
        modelBuilder.HasSequence("LOYERPREV_");
        modelBuilder.HasSequence("MAINENTITY_");
        modelBuilder.HasSequence("MAINENTITYBC_");
        modelBuilder.HasSequence("MAINLCDMCVH_");
        modelBuilder.HasSequence("MAINLD_");
        modelBuilder.HasSequence("MAINLDDOCUMENTFI_");
        modelBuilder.HasSequence("MAINLEVEE_");
        modelBuilder.HasSequence("MAINLEVEECOM_");
        modelBuilder.HasSequence("MAINLEVEEVH_");
        modelBuilder.HasSequence("MAKEURDECISION_");
        modelBuilder.HasSequence("MANDATAIRES_");
        modelBuilder.HasSequence("MANDATORIESQ_");
        modelBuilder.HasSequence("MANDATORYFIELD_");
        modelBuilder.HasSequence("MANUALCR_");
        modelBuilder.HasSequence("MANUALED_");
        modelBuilder.HasSequence("MANUALEXCHANGE_").IncrementsBy(8700);
        modelBuilder.HasSequence("MANUALEXCHANGE_REF");
        modelBuilder.HasSequence("MANUALTERM_");
        modelBuilder.HasSequence("MANUELCD_");
        modelBuilder.HasSequence("MAPPINGCRITERIA_");
        modelBuilder.HasSequence("MARKET_");
        modelBuilder.HasSequence("MARKETBYCOUNTRY_");
        modelBuilder.HasSequence("MARKETI_");
        modelBuilder.HasSequence("MARKETTYPE_");
        modelBuilder.HasSequence("MEJDETAIL_");
        modelBuilder.HasSequence("MISEENDOUTEUXVH_");
        modelBuilder.HasSequence("MODIFCONDVALUE_");
        modelBuilder.HasSequence("MODIFCONDVALUEMODIFIEDIN_");
        modelBuilder.HasSequence("MODIFCONDVALVH_");
        modelBuilder.HasSequence("MODIFFD_");
        modelBuilder.HasSequence("MODIFICATIONPS_");
        modelBuilder.HasSequence("MODIFICATIONPSMODIFICATI_");
        modelBuilder.HasSequence("MODIFICATIOODA_");
        modelBuilder.HasSequence("MODIFICATIPSVH_");
        modelBuilder.HasSequence("MODIFICATODAVH_");
        modelBuilder.HasSequence("MODIFIEDAR_");
        modelBuilder.HasSequence("MODIFIEDC_");
        modelBuilder.HasSequence("MODIFIEDDATA_");
        modelBuilder.HasSequence("MODIFIEDFP_");
        modelBuilder.HasSequence("MODIFIEDPC_");
        modelBuilder.HasSequence("MODIFIEDREDEMPSC_");
        modelBuilder.HasSequence("MODIFIEDRS_");
        modelBuilder.HasSequence("MODIFNPOOLREQ_");
        modelBuilder.HasSequence("MODIFNPOOLREQVH_");
        modelBuilder.HasSequence("MODULE_");
        modelBuilder.HasSequence("MONETICC_");
        modelBuilder.HasSequence("MONETICO_");
        modelBuilder.HasSequence("MONETICOC_");
        modelBuilder.HasSequence("MONETICOPERATION_");
        modelBuilder.HasSequence("MOTIFCA_");
        modelBuilder.HasSequence("MOTIFCREATION_");
        modelBuilder.HasSequence("MOTIFODO_");
        modelBuilder.HasSequence("MOUVEMENTBAIL_");
        modelBuilder.HasSequence("MOUVEMENTE_");
        modelBuilder.HasSequence("MOUVEMENTEU_");
        modelBuilder.HasSequence("MOUVEMENTOP_");
        modelBuilder.HasSequence("MOUVEMENTP_");
        modelBuilder.HasSequence("MOUVEMENTTF_");
        modelBuilder.HasSequence("MOVEMENTDETAIL_");
        modelBuilder.HasSequence("MSBPM_ABSTRAAN_");
        modelBuilder.HasSequence("MSBPM_AFFECTEG_");
        modelBuilder.HasSequence("MSBPM_AFFECTEU_");
        modelBuilder.HasSequence("MSBPM_ATTRIBUC_");
        modelBuilder.HasSequence("MSBPM_CUSTOTAC_");
        modelBuilder.HasSequence("MSBPM_DELEGACV_");
        modelBuilder.HasSequence("MSBPM_DELEGATC_");
        modelBuilder.HasSequence("MSBPM_DELEGATCR_");
        modelBuilder.HasSequence("MSBPM_DELEGATI_");
        modelBuilder.HasSequence("MSBPM_EVENTC_");
        modelBuilder.HasSequence("MSBPM_EXCEPTIH_");
        modelBuilder.HasSequence("MSBPM_FINALNODE_");
        modelBuilder.HasSequence("MSBPM_GROUPA_");
        modelBuilder.HasSequence("MSBPM_INCOMINT_");
        modelBuilder.HasSequence("MSBPM_INITIALN_");
        modelBuilder.HasSequence("MSBPM_MESSAGET_");
        modelBuilder.HasSequence("MSBPM_NODEI_");
        modelBuilder.HasSequence("MSBPM_PARAMETC_");
        modelBuilder.HasSequence("MSBPM_PROCESDA_");
        modelBuilder.HasSequence("MSBPM_PROCESIT_");
        modelBuilder.HasSequence("MSBPM_PROCESSD_");
        modelBuilder.HasSequence("MSBPM_PROCESSI_");
        modelBuilder.HasSequence("MSBPM_TASKAC_");
        modelBuilder.HasSequence("MSBPM_TASKCC_");
        modelBuilder.HasSequence("MSBPM_TRANSITI_");
        modelBuilder.HasSequence("MSBPM_USECA_");
        modelBuilder.HasSequence("MSBPM_USECC_");
        modelBuilder.HasSequence("MSBPM_USECV_");
        modelBuilder.HasSequence("MSBPM_USERACTOR_");
        modelBuilder.HasSequence("MSCAL_ANNUALH_");
        modelBuilder.HasSequence("MSCAL_EXCEPTIH_");
        modelBuilder.HasSequence("MSCAL_WEEKH_");
        modelBuilder.HasSequence("MSDBD_AFFECTAT_");
        modelBuilder.HasSequence("MSDBD_ALERT_");
        modelBuilder.HasSequence("MSDBD_ATTRIBUC_");
        modelBuilder.HasSequence("MSDBD_DASHBOAA_");
        modelBuilder.HasSequence("MSDBD_DASHBOARD_");
        modelBuilder.HasSequence("MSDBD_DASHBOAT_");
        modelBuilder.HasSequence("MSDBD_METHODP_");
        modelBuilder.HasSequence("MSDBD_USECV_");
        modelBuilder.HasSequence("MSESB_ABSTRACT_");
        modelBuilder.HasSequence("MSESB_ABSTRADG_");
        modelBuilder.HasSequence("MSESB_AMOUNTD_");
        modelBuilder.HasSequence("MSESB_AMOUNTF_");
        modelBuilder.HasSequence("MSESB_ATTACHME_");
        modelBuilder.HasSequence("MSESB_ATTRIBUTE_");
        modelBuilder.HasSequence("MSESB_BIGDO_");
        modelBuilder.HasSequence("MSESB_BLOCK3C_");
        modelBuilder.HasSequence("MSESB_BLOCK3TAG_");
        modelBuilder.HasSequence("MSESB_BLOCK4C_");
        modelBuilder.HasSequence("MSESB_BLOCK4TAG_");
        modelBuilder.HasSequence("MSESB_BLOCK5C_");
        modelBuilder.HasSequence("MSESB_BLOCK5TAG_");
        modelBuilder.HasSequence("MSESB_BLOCKO_");
        modelBuilder.HasSequence("MSESB_CHAINC_");
        modelBuilder.HasSequence("MSESB_CHUNKV_");
        modelBuilder.HasSequence("MSESB_CLIENTE_");
        modelBuilder.HasSequence("MSESB_COMPUTEF_");
        modelBuilder.HasSequence("MSESB_CONDITION_");
        modelBuilder.HasSequence("MSESB_CONTENTP_");
        modelBuilder.HasSequence("MSESB_CRITERIP_");
        modelBuilder.HasSequence("MSESB_CRITEROP_");
        modelBuilder.HasSequence("MSESB_DATABASC_");
        modelBuilder.HasSequence("MSESB_DATEO_");
        modelBuilder.HasSequence("MSESB_DBSN_");
        modelBuilder.HasSequence("MSESB_DEFERREM_");
        modelBuilder.HasSequence("MSESB_DEFERREMMESSAGE_");
        modelBuilder.HasSequence("MSESB_DESCRIPT_");
        modelBuilder.HasSequence("MSESB_DOUBLEO_");
        modelBuilder.HasSequence("MSESB_EDPTT_");
        modelBuilder.HasSequence("MSESB_EJBCONFIG_");
        modelBuilder.HasSequence("MSESB_ENDPOTPC_");
        modelBuilder.HasSequence("MSESB_ENTITYTE_");
        modelBuilder.HasSequence("MSESB_ENTITYTP_");
        modelBuilder.HasSequence("MSESB_ESBEVENT_");
        modelBuilder.HasSequence("MSESB_ESBMSG_");
        modelBuilder.HasSequence("MSESB_ESBMSGCORRELATIO_");
        modelBuilder.HasSequence("MSESB_ESBMSGHEADERS_");
        modelBuilder.HasSequence("MSESB_ESBMSGMSGTOPROCE_");
        modelBuilder.HasSequence("MSESB_ESBMSGPROCESSEDM_");
        modelBuilder.HasSequence("MSESB_ESBMSGPROCESSMES_");
        modelBuilder.HasSequence("MSESB_EXTERMSC_");
        modelBuilder.HasSequence("MSESB_FIELDTE_");
        modelBuilder.HasSequence("MSESB_FILENC_");
        modelBuilder.HasSequence("MSESB_FILENP_");
        modelBuilder.HasSequence("MSESB_FILETH_");
        modelBuilder.HasSequence("MSESB_FILETRACK_");
        modelBuilder.HasSequence("MSESB_FILTER_");
        modelBuilder.HasSequence("MSESB_FIXHEADER_");
        modelBuilder.HasSequence("MSESB_FIXHOST_");
        modelBuilder.HasSequence("MSESB_FIXMSG_");
        modelBuilder.HasSequence("MSESB_FIXT_");
        modelBuilder.HasSequence("MSESB_FIXTAG_");
        modelBuilder.HasSequence("MSESB_GROOVYS_");
        modelBuilder.HasSequence("MSESB_GROOVYSP_");
        modelBuilder.HasSequence("MSESB_GROUPIND_");
        modelBuilder.HasSequence("MSESB_GROUPINF_");
        modelBuilder.HasSequence("MSESB_HEADERP_");
        modelBuilder.HasSequence("MSESB_HOSTC_");
        modelBuilder.HasSequence("MSESB_INBOUNDE_");
        modelBuilder.HasSequence("MSESB_INBOUNDM_");
        modelBuilder.HasSequence("MSESB_INBOUNDR_");
        modelBuilder.HasSequence("MSESB_INBOUNRM_");
        modelBuilder.HasSequence("MSESB_INPUTN_");
        modelBuilder.HasSequence("MSESB_INPUTNRECEIVEDNO_");
        modelBuilder.HasSequence("MSESB_INRC_");
        modelBuilder.HasSequence("MSESB_INRE_");
        modelBuilder.HasSequence("MSESB_INTERMSC_");
        modelBuilder.HasSequence("MSESB_IOMSGORIGINALMS_");
        modelBuilder.HasSequence("MSESB_IOMSGTRANSFORME_");
        modelBuilder.HasSequence("MSESB_JDBCPC_");
        modelBuilder.HasSequence("MSESB_JMSD_");
        modelBuilder.HasSequence("MSESB_KIDOBJECT_");
        modelBuilder.HasSequence("MSESB_LDAPA_");
        modelBuilder.HasSequence("MSESB_LDAPC_");
        modelBuilder.HasSequence("MSESB_LDAPPC_");
        modelBuilder.HasSequence("MSESB_LISTBO_");
        modelBuilder.HasSequence("MSESB_LONGO_");
        modelBuilder.HasSequence("MSESB_MAILR_");
        modelBuilder.HasSequence("MSESB_MAILSP_");
        modelBuilder.HasSequence("MSESB_METHODP_");
        modelBuilder.HasSequence("MSESB_MSGTRACE_");
        modelBuilder.HasSequence("MSESB_MSGTRACEDATA_");
        modelBuilder.HasSequence("MSESB_NOTIFICE_");
        modelBuilder.HasSequence("MSESB_OUTBOUNE_");
        modelBuilder.HasSequence("MSESB_OUTBOUNR_");
        modelBuilder.HasSequence("MSESB_OUTPUTN_");
        modelBuilder.HasSequence("MSESB_OUTRC_");
        modelBuilder.HasSequence("MSESB_PARAMECT_");
        modelBuilder.HasSequence("MSESB_PARAMETER_");
        modelBuilder.HasSequence("MSESB_PARENTO_");
        modelBuilder.HasSequence("MSESB_PROCESSB_");
        modelBuilder.HasSequence("MSESB_PROCESSBFAILEDBLOC_");
        modelBuilder.HasSequence("MSESB_PROCESSE_");
        modelBuilder.HasSequence("MSESB_PROFILE_");
        modelBuilder.HasSequence("MSESB_PROFILEHEADERS_");
        modelBuilder.HasSequence("MSESB_PROFILEPARENTBLOC_");
        modelBuilder.HasSequence("MSESB_PROFILEPROCESSMES_");
        modelBuilder.HasSequence("MSESB_QUERYP_");
        modelBuilder.HasSequence("MSESB_QUEUETPC_");
        modelBuilder.HasSequence("MSESB_RECEIVEM_");
        modelBuilder.HasSequence("MSESB_RECEIVEMHEADERS_");
        modelBuilder.HasSequence("MSESB_RECEIVEMPROCESSMES_");
        modelBuilder.HasSequence("MSESB_RECYCLIM_");
        modelBuilder.HasSequence("MSESB_REPORTA_");
        modelBuilder.HasSequence("MSESB_RESPONSR_");
        modelBuilder.HasSequence("MSESB_RESPONST_");
        modelBuilder.HasSequence("MSESB_RESULTSC_");
        modelBuilder.HasSequence("MSESB_ROUTERE_");
        modelBuilder.HasSequence("MSESB_RSPRC_");
        modelBuilder.HasSequence("MSESB_SENTMSG_");
        modelBuilder.HasSequence("MSESB_SHEETCS_");
        modelBuilder.HasSequence("MSESB_SIMPLERA_");
        modelBuilder.HasSequence("MSESB_STRINGO_");
        modelBuilder.HasSequence("MSESB_SUBCB_");
        modelBuilder.HasSequence("MSESB_SUBFFB_");
        modelBuilder.HasSequence("MSESB_SYNCD_");
        modelBuilder.HasSequence("MSESB_TRANSFOK_");
        modelBuilder.HasSequence("MSESB_USERBC_");
        modelBuilder.HasSequence("MSESB_USERBT_");
        modelBuilder.HasSequence("MSESB_VALUE_");
        modelBuilder.HasSequence("MSESB_WSDLC_");
        modelBuilder.HasSequence("MSESB_XMLNP_");
        modelBuilder.HasSequence("MSETP_ASYNCHRMMESSAGE_");
        modelBuilder.HasSequence("MSETP_REMOTEC_");
        modelBuilder.HasSequence("MSJOB_PARAMETC_");
        modelBuilder.HasSequence("MSJOB_REPEATAB_");
        modelBuilder.HasSequence("MSJOB_SCHEDULER_");
        modelBuilder.HasSequence("MSJOB_TASKC_");
        modelBuilder.HasSequence("MSJOB_WORKFLOE_");
        modelBuilder.HasSequence("MSJOB_WORKFLOT_");
        modelBuilder.HasSequence("MSJOB_WORKFLOW_");
        modelBuilder.HasSequence("MSJOB_WORKFLTE_");
        modelBuilder.HasSequence("MSLOG_MASSAL_");
        modelBuilder.HasSequence("MSLOG_MASSINLC_");
        modelBuilder.HasSequence("MSLOG_MASSRL_");
        modelBuilder.HasSequence("MSRPT_AGGREGAL_");
        modelBuilder.HasSequence("MSRPT_AGREGATC_");
        modelBuilder.HasSequence("MSRPT_ALLOWEDG_");
        modelBuilder.HasSequence("MSRPT_COLUMNC_");
        modelBuilder.HasSequence("MSRPT_COLUMNCND_");
        modelBuilder.HasSequence("MSRPT_COLUMNF_");
        modelBuilder.HasSequence("MSRPT_CONDITIC_");
        modelBuilder.HasSequence("MSRPT_FIXEDC_");
        modelBuilder.HasSequence("MSRPT_FIXEDCF_");
        modelBuilder.HasSequence("MSRPT_FIXEDROW_");
        modelBuilder.HasSequence("MSRPT_GROUPF_");
        modelBuilder.HasSequence("MSRPT_GROUPH_");
        modelBuilder.HasSequence("MSRPT_GROUPINF_");
        modelBuilder.HasSequence("MSRPT_KEYFIELD_");
        modelBuilder.HasSequence("MSRPT_LINEC_");
        modelBuilder.HasSequence("MSRPT_LINEFONT_");
        modelBuilder.HasSequence("MSRPT_MASSJR_");
        modelBuilder.HasSequence("MSRPT_MASSJRREPORTDATA_");
        modelBuilder.HasSequence("MSRPT_ORDERF_");
        modelBuilder.HasSequence("MSRPT_ORDERINF_");
        modelBuilder.HasSequence("MSRPT_PARENTC_");
        modelBuilder.HasSequence("MSRPT_REPETICO_");
        modelBuilder.HasSequence("MSRPT_REPORT_");
        modelBuilder.HasSequence("MSRPT_REPORTC_");
        modelBuilder.HasSequence("MSRPT_REPORTCRT_");
        modelBuilder.HasSequence("MSRPT_REPORTE_");
        modelBuilder.HasSequence("MSRPT_REPORTF_");
        modelBuilder.HasSequence("MSRPT_REPORTH_");
        modelBuilder.HasSequence("MSRPT_REPORTHD_");
        modelBuilder.HasSequence("MSRPT_REPORTHDREPORTPARA_");
        modelBuilder.HasSequence("MSRPT_REPORTR_");
        modelBuilder.HasSequence("MSRPT_REPORTSC_");
        modelBuilder.HasSequence("MSRPT_REPORTV_");
        modelBuilder.HasSequence("MSRPT_RPTC_");
        modelBuilder.HasSequence("MSRPT_RPTQP_");
        modelBuilder.HasSequence("MSRPT_SERIE_");
        modelBuilder.HasSequence("MSRPT_SUBJR_");
        modelBuilder.HasSequence("MSRPT_SUBJRREPORTDATA_");
        modelBuilder.HasSequence("MSRPT_TABLEC_");
        modelBuilder.HasSequence("MSRPT_TABLECF_");
        modelBuilder.HasSequence("MSRPT_TABLEG_");
        modelBuilder.HasSequence("MSRPT_TABLEGC_");
        modelBuilder.HasSequence("MSRPT_TXTAL_");
        modelBuilder.HasSequence("MSRPT_TXTE_");
        modelBuilder.HasSequence("MSRPT_TXTRC_");
        modelBuilder.HasSequence("MSRPT_TXTRPT_");
        modelBuilder.HasSequence("MSRPT_TXTTC_");
        modelBuilder.HasSequence("MSRPT_TXTTCP_");
        modelBuilder.HasSequence("MSRPT_UIC_");
        modelBuilder.HasSequence("MSRPT_UIELEMENT_");
        modelBuilder.HasSequence("MSRPT_UIIMAGEDATA_");
        modelBuilder.HasSequence("MSRPT_UITC_");
        modelBuilder.HasSequence("MSRPT_VARIABLC_");
        modelBuilder.HasSequence("MSSEC_AFFECTEG_");
        modelBuilder.HasSequence("MSSEC_ENTITYM_");
        modelBuilder.HasSequence("MSSEC_ENTITYMINITIALVAL_");
        modelBuilder.HasSequence("MSSEC_ENTITYMNEWVALUE_");
        modelBuilder.HasSequence("MSSEC_ORGANIZP_");
        modelBuilder.HasSequence("MSSEC_PROFILEP_");
        modelBuilder.HasSequence("MSSEC_REGIONAO_");
        modelBuilder.HasSequence("MSSEC_REPLACEM_");
        modelBuilder.HasSequence("MSSEC_USER_");
        modelBuilder.HasSequence("MSSEC_USERGROUP_");
        modelBuilder.HasSequence("MSSEC_USERP_");
        modelBuilder.HasSequence("MSSEC_USERRA_");
        modelBuilder.HasSequence("MSSEC_USERTEMODIFICATI_");
        modelBuilder.HasSequence("MSTRP_COLUMNC_");
        modelBuilder.HasSequence("MSTRP_CONDITIC_");
        modelBuilder.HasSequence("MSTRP_CRITERIM_");
        modelBuilder.HasSequence("MSTRP_DOCUMENC_");
        modelBuilder.HasSequence("MSTRP_FONT_");
        modelBuilder.HasSequence("MSTRP_FOOTERC_");
        modelBuilder.HasSequence("MSTRP_GROUPBY_");
        modelBuilder.HasSequence("MSTRP_HEADERC_");
        modelBuilder.HasSequence("MSTRP_ORDERBY_");
        modelBuilder.HasSequence("MSTRP_PAGEC_");
        modelBuilder.HasSequence("MSTRP_REPORTC_");
        modelBuilder.HasSequence("MSTRP_REPORTV_");
        modelBuilder.HasSequence("MSTRP_TABLECFG_");
        modelBuilder.HasSequence("MSTRP_TABLECRT_");
        modelBuilder.HasSequence("MSTRP_TEXTFC_");
        modelBuilder.HasSequence("MSTRP_TEXTR_");
        modelBuilder.HasSequence("MSVLD_ACTION_");
        modelBuilder.HasSequence("MSVLD_MODIFICR_");
        modelBuilder.HasSequence("MSVLD_STEP_");
        modelBuilder.HasSequence("MSVLD_VALIDATI_");
        modelBuilder.HasSequence("MSVLD_VALIDATP_");
        modelBuilder.HasSequence("MSVLD_VALIDATR_");
        modelBuilder.HasSequence("MTTEMPLATELINE_");
        modelBuilder.HasSequence("MULTDWVH_");
        modelBuilder.HasSequence("MULTIPLEBO_");
        modelBuilder.HasSequence("MULTIPLEBOVH_");
        modelBuilder.HasSequence("MULTIPLEDO_");
        modelBuilder.HasSequence("MULTIPLEDOVH_");
        modelBuilder.HasSequence("MULTIPLEDW_");
        modelBuilder.HasSequence("MULTIPLEPBA_");
        modelBuilder.HasSequence("MULTIPLEPBAVH_");
        modelBuilder.HasSequence("MULTIPLESC_");
        modelBuilder.HasSequence("MULTIPLET_").IncrementsBy(8720);
        modelBuilder.HasSequence("MULTIPLET_REF");
        modelBuilder.HasSequence("MULTIPLETLARGEFILE_");
        modelBuilder.HasSequence("MULTIPLETT_");
        modelBuilder.HasSequence("MULTIPLETTVH_");
        modelBuilder.HasSequence("MULTIPLETVH_");
        modelBuilder.HasSequence("MVTCOMMCONTEXT_");
        modelBuilder.HasSequence("MVTEG_");
        modelBuilder.HasSequence("NATAMTSCA_");
        modelBuilder.HasSequence("NATUREE_");
        modelBuilder.HasSequence("NATUREIMMO_");
        modelBuilder.HasSequence("NATURERC_");
        modelBuilder.HasSequence("NATURETITRE_");
        modelBuilder.HasSequence("NETWORKSCARDS_");
        modelBuilder.HasSequence("NEWAL_");
        modelBuilder.HasSequence("NEWAVH_");
        modelBuilder.HasSequence("NOSTROCA_");
        modelBuilder.HasSequence("NOTIONALPR_");
        modelBuilder.HasSequence("NOTIONALPRVH_");
        modelBuilder.HasSequence("NOTPAIDEFD_");
        modelBuilder.HasSequence("NOTPEP_");
        modelBuilder.HasSequence("NPAIDEFDDIS_");
        modelBuilder.HasSequence("NSTRANS_");
        modelBuilder.HasSequence("NSTRANS_000");
        modelBuilder.HasSequence("NSTRANS_001");
        modelBuilder.HasSequence("NSTRANS_002");
        modelBuilder.HasSequence("NSTRANS_003");
        modelBuilder.HasSequence("NSTRANS_004");
        modelBuilder.HasSequence("NSTRANS_005");
        modelBuilder.HasSequence("NSTRANS_006");
        modelBuilder.HasSequence("NSTRANS_007");
        modelBuilder.HasSequence("NSTRANS_008");
        modelBuilder.HasSequence("NSTRANS_009");
        modelBuilder.HasSequence("NSTRANS_010");
        modelBuilder.HasSequence("NSTRANS_011");
        modelBuilder.HasSequence("NSTRANS_012");
        modelBuilder.HasSequence("NSTRANS_013");
        modelBuilder.HasSequence("NSTRANS_014");
        modelBuilder.HasSequence("NSTRANS_015");
        modelBuilder.HasSequence("NSTRANS_016");
        modelBuilder.HasSequence("NSTRANS_017");
        modelBuilder.HasSequence("NSTRANS_018");
        modelBuilder.HasSequence("NSTRANS_019");
        modelBuilder.HasSequence("NSTRANS_020");
        modelBuilder.HasSequence("NSTRANS_021");
        modelBuilder.HasSequence("NSTRANS_022");
        modelBuilder.HasSequence("NSTRANS_023");
        modelBuilder.HasSequence("NSTRANS_024");
        modelBuilder.HasSequence("NSTRANS_025");
        modelBuilder.HasSequence("NSTRANS_026");
        modelBuilder.HasSequence("NSTRANS_027");
        modelBuilder.HasSequence("NSTRANS_028");
        modelBuilder.HasSequence("NSTRANS_029");
        modelBuilder.HasSequence("NSTRANS_030");
        modelBuilder.HasSequence("NSTRANS_031");
        modelBuilder.HasSequence("NSTRANS_032");
        modelBuilder.HasSequence("NSTRANS_033");
        modelBuilder.HasSequence("NSTRANS_034");
        modelBuilder.HasSequence("NSTRANS_035");
        modelBuilder.HasSequence("NSTRANS_036");
        modelBuilder.HasSequence("NSTRANS_037");
        modelBuilder.HasSequence("NSTRANS_038");
        modelBuilder.HasSequence("NSTRANS_039");
        modelBuilder.HasSequence("NSTRANS_040");
        modelBuilder.HasSequence("NSTRANS_041");
        modelBuilder.HasSequence("NSTRANS_042");
        modelBuilder.HasSequence("NSTRANS_043");
        modelBuilder.HasSequence("NSTRANS_044");
        modelBuilder.HasSequence("NSTRANS_045");
        modelBuilder.HasSequence("NSTRANS_046");
        modelBuilder.HasSequence("NSTRANS_047");
        modelBuilder.HasSequence("NSTRANS_048");
        modelBuilder.HasSequence("NSTRANS_049");
        modelBuilder.HasSequence("NSTRANS_050");
        modelBuilder.HasSequence("NSTRANS_051");
        modelBuilder.HasSequence("NSTRANS_052");
        modelBuilder.HasSequence("NSTRANS_053");
        modelBuilder.HasSequence("NSTRANS_054");
        modelBuilder.HasSequence("NSTRANS_055");
        modelBuilder.HasSequence("NSTRANS_056");
        modelBuilder.HasSequence("NSTRANS_057");
        modelBuilder.HasSequence("NSTRANS_058");
        modelBuilder.HasSequence("NSTRANS_059");
        modelBuilder.HasSequence("NSTRANS_060");
        modelBuilder.HasSequence("NSTRANS_061");
        modelBuilder.HasSequence("NSTRANS_062");
        modelBuilder.HasSequence("NSTRANS_063");
        modelBuilder.HasSequence("NSTRANS_064");
        modelBuilder.HasSequence("NSTRANS_065");
        modelBuilder.HasSequence("NSTRANS_066");
        modelBuilder.HasSequence("NSTRANS_067");
        modelBuilder.HasSequence("NSTRANS_068");
        modelBuilder.HasSequence("NSTRANS_069");
        modelBuilder.HasSequence("NSTRANS_070");
        modelBuilder.HasSequence("NSTRANS_071");
        modelBuilder.HasSequence("NSTRANS_072");
        modelBuilder.HasSequence("NSTRANS_073");
        modelBuilder.HasSequence("NSTRANS_074");
        modelBuilder.HasSequence("NSTRANS_075");
        modelBuilder.HasSequence("NSTRANS_076");
        modelBuilder.HasSequence("NSTRANS_077");
        modelBuilder.HasSequence("NSTRANS_078");
        modelBuilder.HasSequence("NSTRANS_079");
        modelBuilder.HasSequence("NSTRANS_080");
        modelBuilder.HasSequence("NSTRANS_081");
        modelBuilder.HasSequence("NSTRANS_082");
        modelBuilder.HasSequence("NSTRANS_083");
        modelBuilder.HasSequence("NSTRANS_084");
        modelBuilder.HasSequence("NSTRANS_085");
        modelBuilder.HasSequence("NSTRANS_086");
        modelBuilder.HasSequence("NSTRANS_087");
        modelBuilder.HasSequence("NSTRANS_088");
        modelBuilder.HasSequence("NSTRANS_089");
        modelBuilder.HasSequence("NSTRANS_100");
        modelBuilder.HasSequence("NSTRANS_101");
        modelBuilder.HasSequence("NSTRANS_102");
        modelBuilder.HasSequence("NSTRANS_103");
        modelBuilder.HasSequence("NSTRANS_104");
        modelBuilder.HasSequence("NSTRANS_105");
        modelBuilder.HasSequence("NSTRANS_106");
        modelBuilder.HasSequence("NSTRANS_107");
        modelBuilder.HasSequence("NSTRANS_108");
        modelBuilder.HasSequence("NSTRANS_109");
        modelBuilder.HasSequence("NSTRANS_110");
        modelBuilder.HasSequence("NSTRANS_112");
        modelBuilder.HasSequence("NSTRANS_113");
        modelBuilder.HasSequence("NSTRANS_114");
        modelBuilder.HasSequence("NSTRANS_115");
        modelBuilder.HasSequence("NSTRANS_116");
        modelBuilder.HasSequence("NSTRANS_118");
        modelBuilder.HasSequence("NSTRANS_119");
        modelBuilder.HasSequence("NSTRANS_120");
        modelBuilder.HasSequence("NSTRANS_121");
        modelBuilder.HasSequence("NSTRANS_122");
        modelBuilder.HasSequence("NSTRANS_123");
        modelBuilder.HasSequence("NSTRANS_124");
        modelBuilder.HasSequence("NSTRANS_125");
        modelBuilder.HasSequence("NSTRANS_126");
        modelBuilder.HasSequence("NSTRANS_127");
        modelBuilder.HasSequence("NSTRANS_128");
        modelBuilder.HasSequence("NSTRANS_129");
        modelBuilder.HasSequence("NSTRANS_130");
        modelBuilder.HasSequence("NSTRANS_131");
        modelBuilder.HasSequence("NSTRANS_132");
        modelBuilder.HasSequence("NSTRANS_133");
        modelBuilder.HasSequence("NSTRANS_134");
        modelBuilder.HasSequence("NSTRANS_135");
        modelBuilder.HasSequence("NSTRANS_136");
        modelBuilder.HasSequence("NSTRANS_137");
        modelBuilder.HasSequence("NSTRANS_138");
        modelBuilder.HasSequence("NSTRANS_139");
        modelBuilder.HasSequence("NSTRANS_140");
        modelBuilder.HasSequence("NSTRANS_141");
        modelBuilder.HasSequence("NSTRANS_142");
        modelBuilder.HasSequence("NSTRANS_143");
        modelBuilder.HasSequence("NSTRANS_144");
        modelBuilder.HasSequence("NSTRANS_145");
        modelBuilder.HasSequence("NSTRANS_146");
        modelBuilder.HasSequence("NSTRANS_147");
        modelBuilder.HasSequence("NSTRANS_148");
        modelBuilder.HasSequence("NSTRANS_149");
        modelBuilder.HasSequence("NSTRANS_150");
        modelBuilder.HasSequence("NSTRANS_151");
        modelBuilder.HasSequence("NSTRANS_152");
        modelBuilder.HasSequence("NSTRANS_153");
        modelBuilder.HasSequence("NSTRANS_154");
        modelBuilder.HasSequence("NSTRANS_155");
        modelBuilder.HasSequence("NSTRANS_156");
        modelBuilder.HasSequence("NSTRANS_157");
        modelBuilder.HasSequence("NSTRANS_158");
        modelBuilder.HasSequence("NSTRANS_159");
        modelBuilder.HasSequence("NSTRANS_160");
        modelBuilder.HasSequence("NSTRANS_161");
        modelBuilder.HasSequence("NUM_PIECE45").IsCyclic();
        modelBuilder.HasSequence("OBJECTRS_");
        modelBuilder.HasSequence("OBJETDDMC_");
        modelBuilder.HasSequence("OCCUPANCYPERMIT_");
        modelBuilder.HasSequence("OFFERARVH_");
        modelBuilder.HasSequence("ONAC_");
        modelBuilder.HasSequence("OPECOMCONTEXT_");
        modelBuilder.HasSequence("OPEFLD_");
        modelBuilder.HasSequence("OPERATION_");
        modelBuilder.HasSequence("OPERATIONA_");
        modelBuilder.HasSequence("OPERATIONC_");
        modelBuilder.HasSequence("OPERATIONCR_");
        modelBuilder.HasSequence("OPERATIONDETAIL_");
        modelBuilder.HasSequence("OPERATIONVISION_");
        modelBuilder.HasSequence("OPERATOROR_");
        modelBuilder.HasSequence("OPPBILLVALHIS_");
        modelBuilder.HasSequence("OPPOSEDBILL_");
        modelBuilder.HasSequence("OPPOSEDBILLS_");
        modelBuilder.HasSequence("OPPOSEDCHEQUE_");
        modelBuilder.HasSequence("OPPOSITION_");
        modelBuilder.HasSequence("OPPOSITIONAUTH_");
        modelBuilder.HasSequence("OPPOSITIONAVH_");
        modelBuilder.HasSequence("OPPOSITIONVH_");
        modelBuilder.HasSequence("ORG_BRANCHC_");
        modelBuilder.HasSequence("ORG_UNITA_");
        modelBuilder.HasSequence("ORG_UNITAT_");
        modelBuilder.HasSequence("ORG_UNITTYPE_");
        modelBuilder.HasSequence("ORGUNIT_");
        modelBuilder.HasSequence("ORGUSER_");
        modelBuilder.HasSequence("ORIGINEINCOME_");
        modelBuilder.HasSequence("OTHERATB_");
        modelBuilder.HasSequence("OTHERBC_");
        modelBuilder.HasSequence("OTHERCHARGE_");
        modelBuilder.HasSequence("OTHERFEES_");
        modelBuilder.HasSequence("OTHERIEVH_");
        modelBuilder.HasSequence("OTHERLOAN_");
        modelBuilder.HasSequence("OTHEROAU_");
        modelBuilder.HasSequence("OTHERRA_");
        modelBuilder.HasSequence("OVDAVH_");
        modelBuilder.HasSequence("OVERDA_");
        modelBuilder.HasSequence("OWNERSHIP_");
        modelBuilder.HasSequence("PAIEMENTDVH_");
        modelBuilder.HasSequence("PARCELLE_");
        modelBuilder.HasSequence("PASSIFBILAN_");
        modelBuilder.HasSequence("PATRIMONIALD_");
        modelBuilder.HasSequence("PATRIMONIALS_");
        modelBuilder.HasSequence("PATRIMONIALTYPE_");
        modelBuilder.HasSequence("PAYCASHOPERATION_");
        modelBuilder.HasSequence("PAYINGTHIRDPART_");
        modelBuilder.HasSequence("PAYMCCV_");
        modelBuilder.HasSequence("PAYMENTC_");
        modelBuilder.HasSequence("PAYMENTCARD_");
        modelBuilder.HasSequence("PAYMENTCARD_REF");
        modelBuilder.HasSequence("PAYMENTCC_");
        modelBuilder.HasSequence("PAYMENTCE_");
        modelBuilder.HasSequence("PAYMENTCM_");
        modelBuilder.HasSequence("PAYMENTCMVH_");
        modelBuilder.HasSequence("PAYMENTCOC_");
        modelBuilder.HasSequence("PAYMENTCVH_");
        modelBuilder.HasSequence("PAYMENTINCIDENT_");
        modelBuilder.HasSequence("PAYMENTREASON_");
        modelBuilder.HasSequence("PAYMENTWALLET_");
        modelBuilder.HasSequence("PBACCESS_");
        modelBuilder.HasSequence("PBAUTHORIZATION_");
        modelBuilder.HasSequence("PENALTYDAEPSVH_");
        modelBuilder.HasSequence("PENALTYDC_");
        modelBuilder.HasSequence("PENDELVH_");
        modelBuilder.HasSequence("PENSIONSCHEME_");
        modelBuilder.HasSequence("PERCEPTIONA_");
        modelBuilder.HasSequence("PERIODICITYRATE_");
        modelBuilder.HasSequence("PERIODICPA_");
        modelBuilder.HasSequence("PERIODICPS_");
        modelBuilder.HasSequence("PERIODICREPORT_");
        modelBuilder.HasSequence("PERIODICT_").IncrementsBy(160);
        modelBuilder.HasSequence("PERIODICT_REF");
        modelBuilder.HasSequence("PERIODICTM_");
        modelBuilder.HasSequence("PERIODICTMVH_");
        modelBuilder.HasSequence("PERIODICTVH_");
        modelBuilder.HasSequence("PERIODIFICATIC_");
        modelBuilder.HasSequence("PERIODIFIEDAS_");
        modelBuilder.HasSequence("PERIODPLV_");
        modelBuilder.HasSequence("PERIODPLV_REF");
        modelBuilder.HasSequence("PERIODPLVVH_");
        modelBuilder.HasSequence("PERTRAPP_");
        modelBuilder.HasSequence("PHASEC_");
        modelBuilder.HasSequence("PHASEDL_");
        modelBuilder.HasSequence("PHASELANCEMENT_");
        modelBuilder.HasSequence("PLANARRANGEMENTI_");
        modelBuilder.HasSequence("POOLLINK_");
        modelBuilder.HasSequence("POSTPONEDAMOUNT_");
        modelBuilder.HasSequence("POSTPONEDE_");
        modelBuilder.HasSequence("POUVOIR_");
        modelBuilder.HasSequence("POUVOIR_NAME_");
        modelBuilder.HasSequence("POUVOIRVH_");
        modelBuilder.HasSequence("PPDBC_");
        modelBuilder.HasSequence("PPDETAILSBYBFD_");
        modelBuilder.HasSequence("PPEFUNCTIONS_");
        modelBuilder.HasSequence("PPEINFORMATIONS_");
        modelBuilder.HasSequence("PRECONTENTICVH_");
        modelBuilder.HasSequence("PRECONTENTIEVH_");
        modelBuilder.HasSequence("PRECONTENTIOUC_");
        modelBuilder.HasSequence("PRECONTENTIOUE_");
        modelBuilder.HasSequence("PRECONTENTIOUSCLIENT_");
        modelBuilder.HasSequence("PRELEVEMENT_ALLER_");
        modelBuilder.HasSequence("PREPAIDCARD_");
        modelBuilder.HasSequence("PREPAIDCARDLOT_");
        modelBuilder.HasSequence("PRICELIST_");
        modelBuilder.HasSequence("PRIMEID_");
        modelBuilder.HasSequence("PRJFLDTYP_");
        modelBuilder.HasSequence("PRLVBENEF_");
        modelBuilder.HasSequence("PROAUTCUR_");
        modelBuilder.HasSequence("PRODUCTAR_");
        modelBuilder.HasSequence("PRODUCTBYNATURE_");
        modelBuilder.HasSequence("PRODUCTCATEGORY_");
        modelBuilder.HasSequence("PRODUCTDT_");
        modelBuilder.HasSequence("PRODUCTFIELD_");
        modelBuilder.HasSequence("PRODUCTSC_");
        modelBuilder.HasSequence("PRODUCTSERVICE_");
        modelBuilder.HasSequence("PRODUCTSVH_");
        modelBuilder.HasSequence("PRODUCTSVISION_");
        modelBuilder.HasSequence("PRODUCTTYPE_");
        modelBuilder.HasSequence("PRODUCTWARRANTY_");
        modelBuilder.HasSequence("PROFESSION_");
        modelBuilder.HasSequence("PROFESSIONALA_");
        modelBuilder.HasSequence("PROFESSIONALACCOUNT_");
        modelBuilder.HasSequence("PROFESSIONALSC_");
        modelBuilder.HasSequence("PROHIBITION_");
        modelBuilder.HasSequence("PROJECTDOCUMENT_");
        modelBuilder.HasSequence("PROJECTDOCUMENTFILEDATA_");
        modelBuilder.HasSequence("PROJECTDT_");
        modelBuilder.HasSequence("PROJETI_");
        modelBuilder.HasSequence("PROPOSEDW_");
        modelBuilder.HasSequence("PROPOSEDWA_");
        modelBuilder.HasSequence("PROROGATIONEVH_");
        modelBuilder.HasSequence("PROROGATIONUVH_");
        modelBuilder.HasSequence("PROSUBAUTH_");
        modelBuilder.HasSequence("PROSUBAUTHVH_");
        modelBuilder.HasSequence("PROVIDER_");
        modelBuilder.HasSequence("PROVISIONOCI_");
        modelBuilder.HasSequence("PROVISIONR_");
        modelBuilder.HasSequence("PROVISIONREG_");
        modelBuilder.HasSequence("PROVREGHIS_");
        modelBuilder.HasSequence("PROVRESSESS_");
        modelBuilder.HasSequence("PROVRESSTAT_");
        modelBuilder.HasSequence("PROVRESVH_");
        modelBuilder.HasSequence("PSA_AUT_REF").IncrementsBy(1961);
        modelBuilder.HasSequence("QTYNAM_");
        modelBuilder.HasSequence("QUALITY_");
        modelBuilder.HasSequence("R_AMTOPE_");
        modelBuilder.HasSequence("R_CONDITIONT_");
        modelBuilder.HasSequence("R_DATOPE_");
        modelBuilder.HasSequence("R_MESSAGESTG_");
        modelBuilder.HasSequence("R_MSBPM_ABSTRAAN_");
        modelBuilder.HasSequence("R_MSBPM_AFFECTEG_");
        modelBuilder.HasSequence("R_MSBPM_AFFECTEU_");
        modelBuilder.HasSequence("R_MSBPM_ATTRIBUC_");
        modelBuilder.HasSequence("R_MSBPM_CUSTOME_");
        modelBuilder.HasSequence("R_MSBPM_CUSTOTAC_");
        modelBuilder.HasSequence("R_MSBPM_DELEGACV_");
        modelBuilder.HasSequence("R_MSBPM_DELEGATC_");
        modelBuilder.HasSequence("R_MSBPM_DELEGATCR_");
        modelBuilder.HasSequence("R_MSBPM_DELEGATI_");
        modelBuilder.HasSequence("R_MSBPM_EVENTC_");
        modelBuilder.HasSequence("R_MSBPM_EXCEPTIH_");
        modelBuilder.HasSequence("R_MSBPM_EXPRESSE_");
        modelBuilder.HasSequence("R_MSBPM_FINALNODE_");
        modelBuilder.HasSequence("R_MSBPM_GROUPA_");
        modelBuilder.HasSequence("R_MSBPM_INCOMINT_");
        modelBuilder.HasSequence("R_MSBPM_INITIALN_");
        modelBuilder.HasSequence("R_MSBPM_MESSAGET_");
        modelBuilder.HasSequence("R_MSBPM_NODEEVENT_");
        modelBuilder.HasSequence("R_MSBPM_NODEI_");
        modelBuilder.HasSequence("R_MSBPM_PARAMETC_");
        modelBuilder.HasSequence("R_MSBPM_PROCESDA_");
        modelBuilder.HasSequence("R_MSBPM_PROCESIT_");
        modelBuilder.HasSequence("R_MSBPM_PROCESSD_");
        modelBuilder.HasSequence("R_MSBPM_PROCESSI_");
        modelBuilder.HasSequence("R_MSBPM_TASKAC_");
        modelBuilder.HasSequence("R_MSBPM_TASKCC_");
        modelBuilder.HasSequence("R_MSBPM_TRANSITI_");
        modelBuilder.HasSequence("R_MSBPM_USECA_");
        modelBuilder.HasSequence("R_MSBPM_USECC_");
        modelBuilder.HasSequence("R_MSBPM_USECV_");
        modelBuilder.HasSequence("R_MSBPM_USERACTOR_");
        modelBuilder.HasSequence("R_MSDBD_AFFECTAT_");
        modelBuilder.HasSequence("R_MSDBD_ALERT_");
        modelBuilder.HasSequence("R_MSDBD_ATTRIBUC_");
        modelBuilder.HasSequence("R_MSDBD_DASHBOAA_");
        modelBuilder.HasSequence("R_MSDBD_DASHBOARD_");
        modelBuilder.HasSequence("R_MSDBD_DASHBOAT_");
        modelBuilder.HasSequence("R_MSDBD_METHODP_");
        modelBuilder.HasSequence("R_MSDBD_USECV_");
        modelBuilder.HasSequence("R_MSESB_ABSTRACT_");
        modelBuilder.HasSequence("R_MSESB_ABSTRADG_");
        modelBuilder.HasSequence("R_MSESB_AMOUNTD_");
        modelBuilder.HasSequence("R_MSESB_AMOUNTF_");
        modelBuilder.HasSequence("R_MSESB_ATTACHME_");
        modelBuilder.HasSequence("R_MSESB_ATTRIBUTE_");
        modelBuilder.HasSequence("R_MSESB_BIGDO_");
        modelBuilder.HasSequence("R_MSESB_BLOCK3C_");
        modelBuilder.HasSequence("R_MSESB_BLOCK3TAG_");
        modelBuilder.HasSequence("R_MSESB_BLOCK4C_");
        modelBuilder.HasSequence("R_MSESB_BLOCK4TAG_");
        modelBuilder.HasSequence("R_MSESB_BLOCK5C_");
        modelBuilder.HasSequence("R_MSESB_BLOCK5TAG_");
        modelBuilder.HasSequence("R_MSESB_BLOCKO_");
        modelBuilder.HasSequence("R_MSESB_CHAINC_");
        modelBuilder.HasSequence("R_MSESB_CHUNKV_");
        modelBuilder.HasSequence("R_MSESB_CLIENTE_");
        modelBuilder.HasSequence("R_MSESB_COMPUTEF_");
        modelBuilder.HasSequence("R_MSESB_CONDEC_");
        modelBuilder.HasSequence("R_MSESB_CONDITION_");
        modelBuilder.HasSequence("R_MSESB_CONTENTP_");
        modelBuilder.HasSequence("R_MSESB_CRITERIP_");
        modelBuilder.HasSequence("R_MSESB_CRITEROP_");
        modelBuilder.HasSequence("R_MSESB_DATABASC_");
        modelBuilder.HasSequence("R_MSESB_DATEO_");
        modelBuilder.HasSequence("R_MSESB_DEFERREM_");
        modelBuilder.HasSequence("R_MSESB_DESCRIPT_");
        modelBuilder.HasSequence("R_MSESB_DOUBLEO_");
        modelBuilder.HasSequence("R_MSESB_EDPTT_");
        modelBuilder.HasSequence("R_MSESB_EJBCONFIG_");
        modelBuilder.HasSequence("R_MSESB_ENDPOTPC_");
        modelBuilder.HasSequence("R_MSESB_ENTITYTE_");
        modelBuilder.HasSequence("R_MSESB_ENTITYTP_");
        modelBuilder.HasSequence("R_MSESB_ESBEVENT_");
        modelBuilder.HasSequence("R_MSESB_ESBMSG_");
        modelBuilder.HasSequence("R_MSESB_EXTERMSC_");
        modelBuilder.HasSequence("R_MSESB_FIELDTE_");
        modelBuilder.HasSequence("R_MSESB_FILENC_");
        modelBuilder.HasSequence("R_MSESB_FILENP_");
        modelBuilder.HasSequence("R_MSESB_FILETH_");
        modelBuilder.HasSequence("R_MSESB_FILETRACK_");
        modelBuilder.HasSequence("R_MSESB_FILTER_");
        modelBuilder.HasSequence("R_MSESB_GROUPIND_");
        modelBuilder.HasSequence("R_MSESB_GROUPINF_");
        modelBuilder.HasSequence("R_MSESB_HEADERP_");
        modelBuilder.HasSequence("R_MSESB_HOSTC_");
        modelBuilder.HasSequence("R_MSESB_INBOUNDE_");
        modelBuilder.HasSequence("R_MSESB_INBOUNDM_");
        modelBuilder.HasSequence("R_MSESB_INBOUNDR_");
        modelBuilder.HasSequence("R_MSESB_INBOUNRM_");
        modelBuilder.HasSequence("R_MSESB_INPUTN_");
        modelBuilder.HasSequence("R_MSESB_INRC_");
        modelBuilder.HasSequence("R_MSESB_INRE_");
        modelBuilder.HasSequence("R_MSESB_INTERMSC_");
        modelBuilder.HasSequence("R_MSESB_JDBCPC_");
        modelBuilder.HasSequence("R_MSESB_JMSD_");
        modelBuilder.HasSequence("R_MSESB_KIDOBJECT_");
        modelBuilder.HasSequence("R_MSESB_LDAPA_");
        modelBuilder.HasSequence("R_MSESB_LDAPC_");
        modelBuilder.HasSequence("R_MSESB_LDAPPC_");
        modelBuilder.HasSequence("R_MSESB_LISTBO_");
        modelBuilder.HasSequence("R_MSESB_LONGO_");
        modelBuilder.HasSequence("R_MSESB_MAILR_");
        modelBuilder.HasSequence("R_MSESB_MAILSP_");
        modelBuilder.HasSequence("R_MSESB_METHODP_");
        modelBuilder.HasSequence("R_MSESB_MSGTRACE_");
        modelBuilder.HasSequence("R_MSESB_NOTIFICE_");
        modelBuilder.HasSequence("R_MSESB_OUTBOUNE_");
        modelBuilder.HasSequence("R_MSESB_OUTBOUNR_");
        modelBuilder.HasSequence("R_MSESB_OUTPUTN_");
        modelBuilder.HasSequence("R_MSESB_OUTRC_");
        modelBuilder.HasSequence("R_MSESB_PARAMECT_");
        modelBuilder.HasSequence("R_MSESB_PARAMETER_");
        modelBuilder.HasSequence("R_MSESB_PARENTO_");
        modelBuilder.HasSequence("R_MSESB_PROCESSB_");
        modelBuilder.HasSequence("R_MSESB_PROCESSE_");
        modelBuilder.HasSequence("R_MSESB_PROFILE_");
        modelBuilder.HasSequence("R_MSESB_QUERYP_");
        modelBuilder.HasSequence("R_MSESB_QUEUETPC_");
        modelBuilder.HasSequence("R_MSESB_RECEIVEM_");
        modelBuilder.HasSequence("R_MSESB_RECYCLIM_");
        modelBuilder.HasSequence("R_MSESB_REPORTA_");
        modelBuilder.HasSequence("R_MSESB_RESPONSR_");
        modelBuilder.HasSequence("R_MSESB_RESPONST_");
        modelBuilder.HasSequence("R_MSESB_RESULTSC_");
        modelBuilder.HasSequence("R_MSESB_ROUTERE_");
        modelBuilder.HasSequence("R_MSESB_RSPRC_");
        modelBuilder.HasSequence("R_MSESB_SENTMSG_");
        modelBuilder.HasSequence("R_MSESB_SHEETCS_");
        modelBuilder.HasSequence("R_MSESB_SIMPLERA_");
        modelBuilder.HasSequence("R_MSESB_STRINGO_");
        modelBuilder.HasSequence("R_MSESB_SUBCB_");
        modelBuilder.HasSequence("R_MSESB_SUBFFB_");
        modelBuilder.HasSequence("R_MSESB_SYNCD_");
        modelBuilder.HasSequence("R_MSESB_TRANSFOK_");
        modelBuilder.HasSequence("R_MSESB_USERBC_");
        modelBuilder.HasSequence("R_MSESB_USERBT_");
        modelBuilder.HasSequence("R_MSESB_VALUE_");
        modelBuilder.HasSequence("R_MSESB_WSDLC_");
        modelBuilder.HasSequence("R_MSESB_XMLNP_");
        modelBuilder.HasSequence("R_MSETP_ASYNCHRM_");
        modelBuilder.HasSequence("R_MSETP_REMOTEC_");
        modelBuilder.HasSequence("R_MSIFR_ATTRIBUTE_");
        modelBuilder.HasSequence("R_MSIFR_DSLC_");
        modelBuilder.HasSequence("R_MSIFR_DSLE_");
        modelBuilder.HasSequence("R_MSIFR_FUNCTION_");
        modelBuilder.HasSequence("R_MSIFR_IMPORTA_");
        modelBuilder.HasSequence("R_MSIFR_INPUTV_");
        modelBuilder.HasSequence("R_MSIFR_OUTPUTV_");
        modelBuilder.HasSequence("R_MSIFR_RULE_");
        modelBuilder.HasSequence("R_MSIFR_RULEC_");
        modelBuilder.HasSequence("R_MSIFR_RULECOND_");
        modelBuilder.HasSequence("R_MSIFR_RULESET_");
        modelBuilder.HasSequence("R_MSJOB_PARAMETC_");
        modelBuilder.HasSequence("R_MSJOB_REPEATAB_");
        modelBuilder.HasSequence("R_MSJOB_SCHEDULER_");
        modelBuilder.HasSequence("R_MSJOB_TASKC_");
        modelBuilder.HasSequence("R_MSJOB_WORKFLOE_");
        modelBuilder.HasSequence("R_MSJOB_WORKFLOT_");
        modelBuilder.HasSequence("R_MSJOB_WORKFLOW_");
        modelBuilder.HasSequence("R_MSJOB_WORKFLTE_");
        modelBuilder.HasSequence("R_MSLOG_MASSAL_");
        modelBuilder.HasSequence("R_MSLOG_MASSINLC_");
        modelBuilder.HasSequence("R_MSLOG_MASSRL_");
        modelBuilder.HasSequence("R_MSRPT_AGGREGAL_");
        modelBuilder.HasSequence("R_MSRPT_AGREGATC_");
        modelBuilder.HasSequence("R_MSRPT_ALLOWEDG_");
        modelBuilder.HasSequence("R_MSRPT_COLUMNC_");
        modelBuilder.HasSequence("R_MSRPT_COLUMNCND_");
        modelBuilder.HasSequence("R_MSRPT_COLUMNF_");
        modelBuilder.HasSequence("R_MSRPT_CONDITIC_");
        modelBuilder.HasSequence("R_MSRPT_FIXEDC_");
        modelBuilder.HasSequence("R_MSRPT_FIXEDCF_");
        modelBuilder.HasSequence("R_MSRPT_FIXEDROW_");
        modelBuilder.HasSequence("R_MSRPT_GROUPF_");
        modelBuilder.HasSequence("R_MSRPT_GROUPH_");
        modelBuilder.HasSequence("R_MSRPT_GROUPINF_");
        modelBuilder.HasSequence("R_MSRPT_KEYFIELD_");
        modelBuilder.HasSequence("R_MSRPT_LINEC_");
        modelBuilder.HasSequence("R_MSRPT_LINEFONT_");
        modelBuilder.HasSequence("R_MSRPT_MASSJR_");
        modelBuilder.HasSequence("R_MSRPT_ORDERF_");
        modelBuilder.HasSequence("R_MSRPT_ORDERINF_");
        modelBuilder.HasSequence("R_MSRPT_PARENTC_");
        modelBuilder.HasSequence("R_MSRPT_REPETICO_");
        modelBuilder.HasSequence("R_MSRPT_REPORT_");
        modelBuilder.HasSequence("R_MSRPT_REPORTC_");
        modelBuilder.HasSequence("R_MSRPT_REPORTCRT_");
        modelBuilder.HasSequence("R_MSRPT_REPORTE_");
        modelBuilder.HasSequence("R_MSRPT_REPORTF_");
        modelBuilder.HasSequence("R_MSRPT_REPORTH_");
        modelBuilder.HasSequence("R_MSRPT_REPORTR_");
        modelBuilder.HasSequence("R_MSRPT_REPORTSC_");
        modelBuilder.HasSequence("R_MSRPT_REPORTV_");
        modelBuilder.HasSequence("R_MSRPT_RPTC_");
        modelBuilder.HasSequence("R_MSRPT_RPTQP_");
        modelBuilder.HasSequence("R_MSRPT_SERIE_");
        modelBuilder.HasSequence("R_MSRPT_SUBJR_");
        modelBuilder.HasSequence("R_MSRPT_TABLEC_");
        modelBuilder.HasSequence("R_MSRPT_TABLECF_");
        modelBuilder.HasSequence("R_MSRPT_TABLEG_");
        modelBuilder.HasSequence("R_MSRPT_TABLEGC_");
        modelBuilder.HasSequence("R_MSRPT_TXTAL_");
        modelBuilder.HasSequence("R_MSRPT_TXTE_");
        modelBuilder.HasSequence("R_MSRPT_TXTRC_");
        modelBuilder.HasSequence("R_MSRPT_TXTRPT_");
        modelBuilder.HasSequence("R_MSRPT_TXTTC_");
        modelBuilder.HasSequence("R_MSRPT_TXTTCP_");
        modelBuilder.HasSequence("R_MSRPT_UIC_");
        modelBuilder.HasSequence("R_MSRPT_UIELEMENT_");
        modelBuilder.HasSequence("R_MSRPT_UITC_");
        modelBuilder.HasSequence("R_MSRPT_VARIABLC_");
        modelBuilder.HasSequence("R_MSSEC_CONDITIP_");
        modelBuilder.HasSequence("R_MSSEC_DATAP_");
        modelBuilder.HasSequence("R_MSSEC_GROUPP_");
        modelBuilder.HasSequence("R_MSSEC_GROUPPRFL_");
        modelBuilder.HasSequence("R_MSSEC_MENU_");
        modelBuilder.HasSequence("R_MSSEC_PRIVILEGE_");
        modelBuilder.HasSequence("R_MSSEC_SECURITD_");
        modelBuilder.HasSequence("R_MSSEC_SERVICEM_");
        modelBuilder.HasSequence("R_MSSEC_SERVICEP_");
        modelBuilder.HasSequence("R_MSSEC_USERP_");
        modelBuilder.HasSequence("R_MSSEC_USERPRFL_");
        modelBuilder.HasSequence("R_MSSEC_USERPRVL_");
        modelBuilder.HasSequence("R_MSSEC_USERTE_");
        modelBuilder.HasSequence("R_MSTRP_COLUMNC_");
        modelBuilder.HasSequence("R_MSTRP_CONDITIC_");
        modelBuilder.HasSequence("R_MSTRP_CRITERIM_");
        modelBuilder.HasSequence("R_MSTRP_DOCUMENC_");
        modelBuilder.HasSequence("R_MSTRP_FONT_");
        modelBuilder.HasSequence("R_MSTRP_FOOTERC_");
        modelBuilder.HasSequence("R_MSTRP_GROUPBY_");
        modelBuilder.HasSequence("R_MSTRP_HEADERC_");
        modelBuilder.HasSequence("R_MSTRP_ORDERBY_");
        modelBuilder.HasSequence("R_MSTRP_PAGEC_");
        modelBuilder.HasSequence("R_MSTRP_REPORTC_");
        modelBuilder.HasSequence("R_MSTRP_REPORTV_");
        modelBuilder.HasSequence("R_MSTRP_TABLECFG_");
        modelBuilder.HasSequence("R_MSTRP_TABLECRT_");
        modelBuilder.HasSequence("R_MSTRP_TEXTFC_");
        modelBuilder.HasSequence("R_MSTRP_TEXTR_");
        modelBuilder.HasSequence("R_MSVLD_ACTION_");
        modelBuilder.HasSequence("R_MSVLD_MODIFICR_");
        modelBuilder.HasSequence("R_MSVLD_STEP_");
        modelBuilder.HasSequence("R_MSVLD_VALIDATI_");
        modelBuilder.HasSequence("R_MSVLD_VALIDATP_");
        modelBuilder.HasSequence("R_MSVLD_VALIDATR_");
        modelBuilder.HasSequence("R_PARAMDEF_");
        modelBuilder.HasSequence("R_STROPE_");
        modelBuilder.HasSequence("R_SWFTBLOK1_");
        modelBuilder.HasSequence("R_SWFTBLOK2_");
        modelBuilder.HasSequence("R_SWFTBLOK3_");
        modelBuilder.HasSequence("R_SWFTBLOK4_");
        modelBuilder.HasSequence("R_SWFTBLOK5_");
        modelBuilder.HasSequence("R_SWFTBUSER_");
        modelBuilder.HasSequence("R_TRANSITINS_");
        modelBuilder.HasSequence("R_TTY_OPERATION_");
        modelBuilder.HasSequence("RAISEFREEZE_");
        modelBuilder.HasSequence("RATING_");
        modelBuilder.HasSequence("RATIOCS_");
        modelBuilder.HasSequence("RCBALANCE_");
        modelBuilder.HasSequence("RCCONTEXTVALUE_");
        modelBuilder.HasSequence("RCP_COMPLEMENTARY_BILL_");
        modelBuilder.HasSequence("RCP_GLOBAL_SENTPRELEVEMENT_");
        modelBuilder.HasSequence("RCP_PRESENTATION_BILL_");
        modelBuilder.HasSequence("RCP_PRESENTATION_CHQ_");
        modelBuilder.HasSequence("RCP_PRESENTATION_VIR_");
        modelBuilder.HasSequence("RCP_PRL_20_");
        modelBuilder.HasSequence("RCP_PRL_EMETTEUR_");
        modelBuilder.HasSequence("RCV_VIR_REF").IncrementsBy(26961);
        modelBuilder.HasSequence("READBA_");
        modelBuilder.HasSequence("RECAPLOT_");
        modelBuilder.HasSequence("RECEIVEDACCOUNT_");
        modelBuilder.HasSequence("RECEIVEDBALANCE_");
        modelBuilder.HasSequence("RECEIVEDBILL_");
        modelBuilder.HasSequence("RECEIVEDBILL_REF");
        modelBuilder.HasSequence("RECEIVEDBILLBILLIMAGE_");
        modelBuilder.HasSequence("RECEIVEDBILLBILLIMAGEV_");
        modelBuilder.HasSequence("RECEIVEDBILLSIGNATUREI_");
        modelBuilder.HasSequence("RECEIVEDBILLVH_");
        modelBuilder.HasSequence("RECEIVEDCE_");
        modelBuilder.HasSequence("RECEIVEDCHECK_").IncrementsBy(62080);
        modelBuilder.HasSequence("RECEIVEDCHECK_REF");
        modelBuilder.HasSequence("RECEIVEDCHECKCHECKIMAGE_");
        modelBuilder.HasSequence("RECEIVEDCHECKSIGNATUREI_");
        modelBuilder.HasSequence("RECEIVEDCHECKVH_");
        modelBuilder.HasSequence("RECEIVEDT_").IncrementsBy(139720);
        modelBuilder.HasSequence("RECEIVEDT_REF");
        modelBuilder.HasSequence("RECEIVEDTVH_");
        modelBuilder.HasSequence("RECEIVEDVSS_");
        modelBuilder.HasSequence("RECENDOBILL_");
        modelBuilder.HasSequence("RECETTEFINANCE_");
        modelBuilder.HasSequence("RECEUILCARTHCONTEXT_");
        modelBuilder.HasSequence("RECONCILEDBILL_");
        modelBuilder.HasSequence("RECONCILEDBILLIMGRECTO_");
        modelBuilder.HasSequence("RECONCILEDBILLIMGVERSO_");
        modelBuilder.HasSequence("RECONCILEDSC_");
        modelBuilder.HasSequence("RECONCILEDSCIMGRECTO_");
        modelBuilder.HasSequence("RECONCILEDSCIMGVERSO_");
        modelBuilder.HasSequence("RECOVERMENFCVH_");
        modelBuilder.HasSequence("RECOVERMENTC_");
        modelBuilder.HasSequence("RECOVERMENTFC_");
        modelBuilder.HasSequence("RECOVERMENTFEE_");
        modelBuilder.HasSequence("RECOVERMENTP_");
        modelBuilder.HasSequence("RECPLVVH_");
        modelBuilder.HasSequence("RECUEILCARTHHIS_");
        modelBuilder.HasSequence("RECVPLV_").IncrementsBy(13020);
        modelBuilder.HasSequence("RECVPLV_REF");
        modelBuilder.HasSequence("RECVPLVVH_");
        modelBuilder.HasSequence("RECWAR_");
        modelBuilder.HasSequence("RECWARADR_");
        modelBuilder.HasSequence("RECWARC_");
        modelBuilder.HasSequence("RECWAREXP_");
        modelBuilder.HasSequence("RECWAREXPVH_");
        modelBuilder.HasSequence("RECWC_");
        modelBuilder.HasSequence("REDEMPTIONC_");
        modelBuilder.HasSequence("REDEMPTIONCBPC_");
        modelBuilder.HasSequence("REDEMPTIONCR_");
        modelBuilder.HasSequence("REDEMPTIONS_");
        modelBuilder.HasSequence("REECHELONNERVH_");
        modelBuilder.HasSequence("REFERENCE").IncrementsBy(3036419);
        modelBuilder.HasSequence("REFERENCERATE_");
        modelBuilder.HasSequence("REFERENCERPS_");
        modelBuilder.HasSequence("REFINANCINGRULE_");
        modelBuilder.HasSequence("REFRBC_");
        modelBuilder.HasSequence("REGLEMENT_");
        modelBuilder.HasSequence("REGLEMENTH_");
        modelBuilder.HasSequence("REGLEMENTHVH_");
        modelBuilder.HasSequence("REGULARISATIOG_");
        modelBuilder.HasSequence("REGULCHECK_");
        modelBuilder.HasSequence("REGULCHECKVH_");
        modelBuilder.HasSequence("REGULEAMENDE_");
        modelBuilder.HasSequence("REGULEAMENDEVH_");
        modelBuilder.HasSequence("REGULEAVH_");
        modelBuilder.HasSequence("REGULECH_");
        modelBuilder.HasSequence("REGULEFNVH_");
        modelBuilder.HasSequence("REGULGARVH_");
        modelBuilder.HasSequence("REJECTIPC_");
        modelBuilder.HasSequence("RELATEDPF_");
        modelBuilder.HasSequence("RELATEDPFD_");
        modelBuilder.HasSequence("RELATEDPRODUCT_");
        modelBuilder.HasSequence("RELATEDSFE_");
        modelBuilder.HasSequence("RELEVECD_");
        modelBuilder.HasSequence("REMITTANCEC_");
        modelBuilder.HasSequence("RENEGOCIATIONVH_");
        modelBuilder.HasSequence("RENEGOCIATIRVH_");
        modelBuilder.HasSequence("RENEWALC_");
        modelBuilder.HasSequence("REPORTCC_");
        modelBuilder.HasSequence("REPORTCOMMISION_");
        modelBuilder.HasSequence("REPORTINGID_");
        modelBuilder.HasSequence("REPORTINGO_");
        modelBuilder.HasSequence("REPORTNPE_");
        modelBuilder.HasSequence("REPRISEEA_");
        modelBuilder.HasSequence("REPRISEMVT_");
        modelBuilder.HasSequence("REQUEST_");
        modelBuilder.HasSequence("REQUEST_REF");
        modelBuilder.HasSequence("REQUESTVALHIS_");
        modelBuilder.HasSequence("REQUIREDA_");
        modelBuilder.HasSequence("REQUIREDDBR_");
        modelBuilder.HasSequence("REQUIREDDBT_");
        modelBuilder.HasSequence("REQUIREDTD_");
        modelBuilder.HasSequence("RESCE_");
        modelBuilder.HasSequence("RESCHEDULINGVH_");
        modelBuilder.HasSequence("RESERVEDOC_");
        modelBuilder.HasSequence("RESERVEDOPE_");
        modelBuilder.HasSequence("RESERVELIST_");
        modelBuilder.HasSequence("RESERVETYPE_");
        modelBuilder.HasSequence("RETOURBCT_");
        modelBuilder.HasSequence("RETOURCALLCENTER_");
        modelBuilder.HasSequence("RETOURFEVH_");
        modelBuilder.HasSequence("RETOURGPE_");
        modelBuilder.HasSequence("RETOURHUISSIER_");
        modelBuilder.HasSequence("RETOURHVH_");
        modelBuilder.HasSequence("RETROCESSIONG_");
        modelBuilder.HasSequence("REVERSEEFDCVH_");
        modelBuilder.HasSequence("REVERSEO_");
        modelBuilder.HasSequence("REVERSEOVH_");
        modelBuilder.HasSequence("REVOLVINGB_");
        modelBuilder.HasSequence("REVOLVINGC_");
        modelBuilder.HasSequence("REVOLVINGEC_");
        modelBuilder.HasSequence("REVOLVINGEVENT_");
        modelBuilder.HasSequence("REVOLVINGI_");
        modelBuilder.HasSequence("REVOLVINGIEVH_");
        modelBuilder.HasSequence("REVOLVINGMC_");
        modelBuilder.HasSequence("REVOLVINGMD_");
        modelBuilder.HasSequence("RIBMRVALHIS_");
        modelBuilder.HasSequence("RIBSYNTAXE_");
        modelBuilder.HasSequence("RISKCONFIG_");
        modelBuilder.HasSequence("RISKI_");
        modelBuilder.HasSequence("RISKRULE_");
        modelBuilder.HasSequence("RJT_COMPENSATION_ALLER_");
        modelBuilder.HasSequence("RJT_COMPENSATION_ARRIVEE_");
        modelBuilder.HasSequence("RJT_PRELEVEMENT_ALLER_");
        modelBuilder.HasSequence("RJTREASON_OT_");
        modelBuilder.HasSequence("RMCONTEXTVALUE_");
        modelBuilder.HasSequence("ROLEFIELD_");
        modelBuilder.HasSequence("ROLEFIELDTYPE_");
        modelBuilder.HasSequence("ROLETYPEFIELD_");
        modelBuilder.HasSequence("RSCNOTPAIDEFD_");
        modelBuilder.HasSequence("RTPM_ALLER_");
        modelBuilder.HasSequence("RTPM_ARRIVEE_");
        modelBuilder.HasSequence("RUBRIQUEACTIF_");
        modelBuilder.HasSequence("RUBRIQUEAGIOS_");
        modelBuilder.HasSequence("RUBRIQUECALCUL_");
        modelBuilder.HasSequence("RUBRIQUECOUT_");
        modelBuilder.HasSequence("RUBRIQUEPASSIF_");
        modelBuilder.HasSequence("RVL_EVENT_COM__");
        modelBuilder.HasSequence("SAISIEARRET_");
        modelBuilder.HasSequence("SALARYSTRUCTURE_");
        modelBuilder.HasSequence("SALEHUISSIER_");
        modelBuilder.HasSequence("SAVINGBCC_");
        modelBuilder.HasSequence("SAVINGBOOK_");
        modelBuilder.HasSequence("SAVINGPREMIUM_");
        modelBuilder.HasSequence("SCANNEDITEM_");
        modelBuilder.HasSequence("SCANNERP_");
        modelBuilder.HasSequence("SCANNERPBU_");
        modelBuilder.HasSequence("SCHEDULEPERIOD_");
        modelBuilder.HasSequence("SCHEMARC_");
        modelBuilder.HasSequence("SCREENFE_");
        modelBuilder.HasSequence("SCREENINSTANCE_");
        modelBuilder.HasSequence("SECURITY_");
        modelBuilder.HasSequence("SECURITYBM_");
        modelBuilder.HasSequence("SECURITYC_");
        modelBuilder.HasSequence("SECURITYDETAIL_");
        modelBuilder.HasSequence("SECURITYFORMAT_");
        modelBuilder.HasSequence("SECURITYRATING_");
        modelBuilder.HasSequence("SECURITYSECTOR_");
        modelBuilder.HasSequence("SED_CAER_");
        modelBuilder.HasSequence("SENT_VIR_REF").IncrementsBy(189261);
        modelBuilder.HasSequence("SENTCEVH_");
        modelBuilder.HasSequence("SENTCHECK_").IncrementsBy(52840);
        modelBuilder.HasSequence("SENTCHECK_REF");
        modelBuilder.HasSequence("SENTCHECKARP_");
        modelBuilder.HasSequence("SENTCHECKARPVH_");
        modelBuilder.HasSequence("SENTCHECKCNP_");
        modelBuilder.HasSequence("SENTCHECKEVENT_");
        modelBuilder.HasSequence("SENTCHECKIMAGERECTO_");
        modelBuilder.HasSequence("SENTCHECKIMAGEVERSO_");
        modelBuilder.HasSequence("SENTCHECKVH_");
        modelBuilder.HasSequence("SENTPLV_").IncrementsBy(2460);
        modelBuilder.HasSequence("SENTPLV_REF");
        modelBuilder.HasSequence("SENTPR_");
        modelBuilder.HasSequence("SENTPR_REF");
        modelBuilder.HasSequence("SENTPRLARGEFILE_");
        modelBuilder.HasSequence("SENTPRVH_");
        modelBuilder.HasSequence("SENTTRANSFER_");
        modelBuilder.HasSequence("SENTTRANSFERVH_");
        modelBuilder.HasSequence("SEQBL_");
        modelBuilder.HasSequence("SEQUENCEEC_");
        modelBuilder.HasSequence("SEQUENCEI_");
        modelBuilder.HasSequence("SEQUENCER_");
        modelBuilder.HasSequence("SEQUENCEREMISE_");
        modelBuilder.HasSequence("SESSIONGE_");
        modelBuilder.HasSequence("SESSIONGR_");
        modelBuilder.HasSequence("SESSIONGVH_");
        modelBuilder.HasSequence("SETTAD_");
        modelBuilder.HasSequence("SETTCOMFRACTION_");
        modelBuilder.HasSequence("SETTLCC_");
        modelBuilder.HasSequence("SETTLCOMDETAIL_");
        modelBuilder.HasSequence("SETTLEMENTC_");
        modelBuilder.HasSequence("SETTLEMENTI_");
        modelBuilder.HasSequence("SETTLEMENTP_");
        modelBuilder.HasSequence("SETTLEMENTR_");
        modelBuilder.HasSequence("SETTLEMENTRM_");
        modelBuilder.HasSequence("SETTLID_");
        modelBuilder.HasSequence("SETTLIDC_");
        modelBuilder.HasSequence("SETTLPC_");
        modelBuilder.HasSequence("SETTLVC_");
        modelBuilder.HasSequence("SETTLVCONDITION_");
        modelBuilder.HasSequence("SICAV_");
        modelBuilder.HasSequence("SINGLELRVH_");
        modelBuilder.HasSequence("SINGLIMREV_");
        modelBuilder.HasSequence("SIZECO_");
        modelBuilder.HasSequence("SMSBANKING_");
        modelBuilder.HasSequence("SOLVENCYCODE_");
        modelBuilder.HasSequence("SOURCEDF_");
        modelBuilder.HasSequence("SOURCEF_");
        modelBuilder.HasSequence("SOUSDB_");
        modelBuilder.HasSequence("SOUSDC_");
        modelBuilder.HasSequence("SPECIFICPCD_");
        modelBuilder.HasSequence("SPLITEDAMOUNT_");
        modelBuilder.HasSequence("SPRELEVAUT_");
        modelBuilder.HasSequence("SPRELEVAUTVH_");
        modelBuilder.HasSequence("STANDARDM_");
        modelBuilder.HasSequence("STANDARDPOU_");
        modelBuilder.HasSequence("STATE_");
        modelBuilder.HasSequence("STATEMENTSC_");
        modelBuilder.HasSequence("STATEMENTSS_");
        modelBuilder.HasSequence("STATEMENTSSC_");
        modelBuilder.HasSequence("STBTASK_");
        modelBuilder.HasSequence("STEPEH_");
        modelBuilder.HasSequence("STRNAM_");
        modelBuilder.HasSequence("SUBCC_");
        modelBuilder.HasSequence("SUPERIORI_");
        modelBuilder.HasSequence("SUSPECTEDO_");
        modelBuilder.HasSequence("SUSPECTEDOC_");
        modelBuilder.HasSequence("SWFTBLOK1_");
        modelBuilder.HasSequence("SWFTBLOK2_");
        modelBuilder.HasSequence("SWFTBLOK3_");
        modelBuilder.HasSequence("SWFTBLOK4_");
        modelBuilder.HasSequence("SWFTBLOK5_");
        modelBuilder.HasSequence("SWFTBUSER_");
        modelBuilder.HasSequence("SYNTHESEBN_");
        modelBuilder.HasSequence("SYNTHESEVD_");
        modelBuilder.HasSequence("TABYFUND_");
        modelBuilder.HasSequence("TASKALERT_");
        modelBuilder.HasSequence("TASKREADUSER_");
        modelBuilder.HasSequence("TAXCONTEXTVALUE_");
        modelBuilder.HasSequence("TAXRATE_");
        modelBuilder.HasSequence("TAXRULE_");
        modelBuilder.HasSequence("TAXSCALE_");
        modelBuilder.HasSequence("TECHNICALRR_");
        modelBuilder.HasSequence("TECHNOLOGYTPE_");
        modelBuilder.HasSequence("TECPRSPRG_");
        modelBuilder.HasSequence("TECPRSPRJ_");
        modelBuilder.HasSequence("TEGACCESSORY_");
        modelBuilder.HasSequence("TEGDR_");
        modelBuilder.HasSequence("TEMPLATESW_");
        modelBuilder.HasSequence("TEMPLIMEXR_");
        modelBuilder.HasSequence("TERMON_");
        modelBuilder.HasSequence("TERMPOSTPONEVH_");
        modelBuilder.HasSequence("THIRDPARTACCMOD_");
        modelBuilder.HasSequence("THIRDPARTPAYERS_");
        modelBuilder.HasSequence("TITRE_");
        modelBuilder.HasSequence("TITREFONCIER_");
        modelBuilder.HasSequence("TITULAR_");
        modelBuilder.HasSequence("TOTAL01_");
        modelBuilder.HasSequence("TOTAL02_");
        modelBuilder.HasSequence("TOTAL09_");
        modelBuilder.HasSequence("TRACEACTION_");
        modelBuilder.HasSequence("TRAITEMENTHCVH_");
        modelBuilder.HasSequence("TRANCHELC_");
        modelBuilder.HasSequence("TRANCHELCVH_");
        modelBuilder.HasSequence("TRANCHEPRS_");
        modelBuilder.HasSequence("TRANFERTEEVH_");
        modelBuilder.HasSequence("TRANSFERCR_");
        modelBuilder.HasSequence("TRANSFERREASON_");
        modelBuilder.HasSequence("TRANSFERTEU_");
        modelBuilder.HasSequence("TRANSITINS_");
        modelBuilder.HasSequence("TREASURYDC_");
        modelBuilder.HasSequence("TTY_CHECKRD_");
        modelBuilder.HasSequence("TTY_EVENTFAMILY_");
        modelBuilder.HasSequence("TTY_EVENTTYPE_");
        modelBuilder.HasSequence("TTY_OPERATIONC_");
        modelBuilder.HasSequence("TTY_OPERATIONT_");
        modelBuilder.HasSequence("TTY_REJECTIONN_");
        modelBuilder.HasSequence("TTY_REJECTIONR_");
        modelBuilder.HasSequence("TTY_REJECTR_");
        modelBuilder.HasSequence("TYPEEV_");
        modelBuilder.HasSequence("TYPEFLUXTRESO_");
        modelBuilder.HasSequence("TYPELIMIT_");
        modelBuilder.HasSequence("TYPERC_");
        modelBuilder.HasSequence("UNAVAILABLEAR_");
        modelBuilder.HasSequence("UNAVAILABLETAR_");
        modelBuilder.HasSequence("UNAVARH_");
        modelBuilder.HasSequence("UNAVTOAVVALHIS_");
        modelBuilder.HasSequence("UNITBYSERVER_");
        modelBuilder.HasSequence("UNITDSET_");
        modelBuilder.HasSequence("URCONTEXTVALUE_");
        modelBuilder.HasSequence("USAGEC_");
        modelBuilder.HasSequence("USAGECH_");
        modelBuilder.HasSequence("USAGEMDRVH_");
        modelBuilder.HasSequence("USAGEMRVH_");
        modelBuilder.HasSequence("UTILISATIONRRS_");
        modelBuilder.HasSequence("UTLCBSCOMPER_");
        modelBuilder.HasSequence("V_AMTOPE_");
        modelBuilder.HasSequence("V_CONDITIONT_");
        modelBuilder.HasSequence("V_DATOPE_");
        modelBuilder.HasSequence("V_MESSAGESTG_");
        modelBuilder.HasSequence("V_MSBPM_ABSTRAAN_");
        modelBuilder.HasSequence("V_MSBPM_AFFECTEG_");
        modelBuilder.HasSequence("V_MSBPM_AFFECTEU_");
        modelBuilder.HasSequence("V_MSBPM_CUSTOME_");
        modelBuilder.HasSequence("V_MSBPM_CUSTOTAC_");
        modelBuilder.HasSequence("V_MSBPM_DELEGACV_");
        modelBuilder.HasSequence("V_MSBPM_DELEGATC_");
        modelBuilder.HasSequence("V_MSBPM_DELEGATCR_");
        modelBuilder.HasSequence("V_MSBPM_DELEGATI_");
        modelBuilder.HasSequence("V_MSBPM_EVENTC_");
        modelBuilder.HasSequence("V_MSBPM_EXCEPTIH_");
        modelBuilder.HasSequence("V_MSBPM_EXPRESSE_");
        modelBuilder.HasSequence("V_MSBPM_FINALNODE_");
        modelBuilder.HasSequence("V_MSBPM_GROUPA_");
        modelBuilder.HasSequence("V_MSBPM_INCOMINT_");
        modelBuilder.HasSequence("V_MSBPM_INITIALN_");
        modelBuilder.HasSequence("V_MSBPM_MESSAGET_");
        modelBuilder.HasSequence("V_MSBPM_NODEEVENT_");
        modelBuilder.HasSequence("V_MSBPM_NODEI_");
        modelBuilder.HasSequence("V_MSBPM_PARAMETC_");
        modelBuilder.HasSequence("V_MSBPM_PROCESDA_");
        modelBuilder.HasSequence("V_MSBPM_PROCESIT_");
        modelBuilder.HasSequence("V_MSBPM_PROCESSD_");
        modelBuilder.HasSequence("V_MSBPM_PROCESSI_");
        modelBuilder.HasSequence("V_MSBPM_TASKAC_");
        modelBuilder.HasSequence("V_MSBPM_TASKCC_");
        modelBuilder.HasSequence("V_MSBPM_TRANSITI_");
        modelBuilder.HasSequence("V_MSBPM_USECA_");
        modelBuilder.HasSequence("V_MSBPM_USECC_");
        modelBuilder.HasSequence("V_MSBPM_USECV_");
        modelBuilder.HasSequence("V_MSBPM_USERACTOR_");
        modelBuilder.HasSequence("V_MSDBD_ALERT_");
        modelBuilder.HasSequence("V_MSDBD_ATTRIBUC_");
        modelBuilder.HasSequence("V_MSDBD_DASHBOAA_");
        modelBuilder.HasSequence("V_MSDBD_DASHBOARD_");
        modelBuilder.HasSequence("V_MSDBD_DASHBOAT_");
        modelBuilder.HasSequence("V_MSDBD_METHODP_");
        modelBuilder.HasSequence("V_MSDBD_USECV_");
        modelBuilder.HasSequence("V_MSESB_ABSTRACT_");
        modelBuilder.HasSequence("V_MSESB_ABSTRADG_");
        modelBuilder.HasSequence("V_MSESB_AMOUNTD_");
        modelBuilder.HasSequence("V_MSESB_AMOUNTF_");
        modelBuilder.HasSequence("V_MSESB_ATTACHME_");
        modelBuilder.HasSequence("V_MSESB_ATTRIBUTE_");
        modelBuilder.HasSequence("V_MSESB_BLOCK3C_");
        modelBuilder.HasSequence("V_MSESB_BLOCK3TAG_");
        modelBuilder.HasSequence("V_MSESB_BLOCK4C_");
        modelBuilder.HasSequence("V_MSESB_BLOCK4TAG_");
        modelBuilder.HasSequence("V_MSESB_BLOCK5C_");
        modelBuilder.HasSequence("V_MSESB_BLOCK5TAG_");
        modelBuilder.HasSequence("V_MSESB_BLOCKO_");
        modelBuilder.HasSequence("V_MSESB_CHAINC_");
        modelBuilder.HasSequence("V_MSESB_CHUNKV_");
        modelBuilder.HasSequence("V_MSESB_CLIENTE_");
        modelBuilder.HasSequence("V_MSESB_COMPUTEF_");
        modelBuilder.HasSequence("V_MSESB_CONDITION_");
        modelBuilder.HasSequence("V_MSESB_CONTENTP_");
        modelBuilder.HasSequence("V_MSESB_CRITERIP_");
        modelBuilder.HasSequence("V_MSESB_CRITEROP_");
        modelBuilder.HasSequence("V_MSESB_DATABASC_");
        modelBuilder.HasSequence("V_MSESB_DATEO_");
        modelBuilder.HasSequence("V_MSESB_DEFERREM_");
        modelBuilder.HasSequence("V_MSESB_DESCRIPT_");
        modelBuilder.HasSequence("V_MSESB_DOUBLEO_");
        modelBuilder.HasSequence("V_MSESB_EDPTT_");
        modelBuilder.HasSequence("V_MSESB_EJBCONFIG_");
        modelBuilder.HasSequence("V_MSESB_ENDPOTPC_");
        modelBuilder.HasSequence("V_MSESB_ENTITYTE_");
        modelBuilder.HasSequence("V_MSESB_ENTITYTP_");
        modelBuilder.HasSequence("V_MSESB_ESBEVENT_");
        modelBuilder.HasSequence("V_MSESB_ESBMSG_");
        modelBuilder.HasSequence("V_MSESB_EXTERMSC_");
        modelBuilder.HasSequence("V_MSESB_FIELDTE_");
        modelBuilder.HasSequence("V_MSESB_FILENC_");
        modelBuilder.HasSequence("V_MSESB_FILENP_");
        modelBuilder.HasSequence("V_MSESB_FILETH_");
        modelBuilder.HasSequence("V_MSESB_FILETRACK_");
        modelBuilder.HasSequence("V_MSESB_FILTER_");
        modelBuilder.HasSequence("V_MSESB_GROUPIND_");
        modelBuilder.HasSequence("V_MSESB_GROUPINF_");
        modelBuilder.HasSequence("V_MSESB_HEADERP_");
        modelBuilder.HasSequence("V_MSESB_HOSTC_");
        modelBuilder.HasSequence("V_MSESB_INBOUNDE_");
        modelBuilder.HasSequence("V_MSESB_INBOUNDM_");
        modelBuilder.HasSequence("V_MSESB_INBOUNDR_");
        modelBuilder.HasSequence("V_MSESB_INBOUNRM_");
        modelBuilder.HasSequence("V_MSESB_INPUTN_");
        modelBuilder.HasSequence("V_MSESB_INRC_");
        modelBuilder.HasSequence("V_MSESB_INRE_");
        modelBuilder.HasSequence("V_MSESB_INTERMSC_");
        modelBuilder.HasSequence("V_MSESB_JDBCPC_");
        modelBuilder.HasSequence("V_MSESB_JMSD_");
        modelBuilder.HasSequence("V_MSESB_KIDOBJECT_");
        modelBuilder.HasSequence("V_MSESB_LDAPA_");
        modelBuilder.HasSequence("V_MSESB_LDAPC_");
        modelBuilder.HasSequence("V_MSESB_LDAPPC_");
        modelBuilder.HasSequence("V_MSESB_LISTBO_");
        modelBuilder.HasSequence("V_MSESB_LONGO_");
        modelBuilder.HasSequence("V_MSESB_MAILR_");
        modelBuilder.HasSequence("V_MSESB_MAILSP_");
        modelBuilder.HasSequence("V_MSESB_METHODP_");
        modelBuilder.HasSequence("V_MSESB_MSGTRACE_");
        modelBuilder.HasSequence("V_MSESB_NOTIFICE_");
        modelBuilder.HasSequence("V_MSESB_OUTBOUNE_");
        modelBuilder.HasSequence("V_MSESB_OUTBOUNR_");
        modelBuilder.HasSequence("V_MSESB_OUTPUTN_");
        modelBuilder.HasSequence("V_MSESB_OUTRC_");
        modelBuilder.HasSequence("V_MSESB_PARAMECT_");
        modelBuilder.HasSequence("V_MSESB_PARAMETER_");
        modelBuilder.HasSequence("V_MSESB_PARENTO_");
        modelBuilder.HasSequence("V_MSESB_PROCESSB_");
        modelBuilder.HasSequence("V_MSESB_PROCESSE_");
        modelBuilder.HasSequence("V_MSESB_PROFILE_");
        modelBuilder.HasSequence("V_MSESB_QUERYP_");
        modelBuilder.HasSequence("V_MSESB_QUEUETPC_");
        modelBuilder.HasSequence("V_MSESB_RECEIVEM_");
        modelBuilder.HasSequence("V_MSESB_RECYCLIM_");
        modelBuilder.HasSequence("V_MSESB_REPORTA_");
        modelBuilder.HasSequence("V_MSESB_RESPONSR_");
        modelBuilder.HasSequence("V_MSESB_RESPONST_");
        modelBuilder.HasSequence("V_MSESB_RESULTSC_");
        modelBuilder.HasSequence("V_MSESB_ROUTERE_");
        modelBuilder.HasSequence("V_MSESB_RSPRC_");
        modelBuilder.HasSequence("V_MSESB_SENTMSG_");
        modelBuilder.HasSequence("V_MSESB_SHEETCS_");
        modelBuilder.HasSequence("V_MSESB_STRINGO_");
        modelBuilder.HasSequence("V_MSESB_SUBCB_");
        modelBuilder.HasSequence("V_MSESB_SUBFFB_");
        modelBuilder.HasSequence("V_MSESB_SYNCD_");
        modelBuilder.HasSequence("V_MSESB_TRANSFOK_");
        modelBuilder.HasSequence("V_MSESB_USERBC_");
        modelBuilder.HasSequence("V_MSESB_USERBT_");
        modelBuilder.HasSequence("V_MSESB_VALUE_");
        modelBuilder.HasSequence("V_MSESB_WSDLC_");
        modelBuilder.HasSequence("V_MSESB_XMLNP_");
        modelBuilder.HasSequence("V_MSETP_ASYNCHRM_");
        modelBuilder.HasSequence("V_MSIFR_ATTRIBUTE_");
        modelBuilder.HasSequence("V_MSIFR_DSLC_");
        modelBuilder.HasSequence("V_MSIFR_DSLE_");
        modelBuilder.HasSequence("V_MSIFR_FUNCTION_");
        modelBuilder.HasSequence("V_MSIFR_IMPORTA_");
        modelBuilder.HasSequence("V_MSIFR_INPUTV_");
        modelBuilder.HasSequence("V_MSIFR_OUTPUTV_");
        modelBuilder.HasSequence("V_MSIFR_RULE_");
        modelBuilder.HasSequence("V_MSIFR_RULEC_");
        modelBuilder.HasSequence("V_MSIFR_RULECOND_");
        modelBuilder.HasSequence("V_MSIFR_RULESET_");
        modelBuilder.HasSequence("V_MSJOB_PARAMETC_");
        modelBuilder.HasSequence("V_MSJOB_REPEATAB_");
        modelBuilder.HasSequence("V_MSJOB_SCHEDULER_");
        modelBuilder.HasSequence("V_MSJOB_TASKC_");
        modelBuilder.HasSequence("V_MSJOB_WORKFLOE_");
        modelBuilder.HasSequence("V_MSJOB_WORKFLOT_");
        modelBuilder.HasSequence("V_MSJOB_WORKFLOW_");
        modelBuilder.HasSequence("V_MSJOB_WORKFLTE_");
        modelBuilder.HasSequence("V_MSLOG_MASSAL_");
        modelBuilder.HasSequence("V_MSLOG_MASSINLC_");
        modelBuilder.HasSequence("V_MSLOG_MASSRL_");
        modelBuilder.HasSequence("V_MSRPT_AGGREGAL_");
        modelBuilder.HasSequence("V_MSRPT_AGREGATC_");
        modelBuilder.HasSequence("V_MSRPT_ALLOWEDG_");
        modelBuilder.HasSequence("V_MSRPT_COLUMNC_");
        modelBuilder.HasSequence("V_MSRPT_COLUMNCND_");
        modelBuilder.HasSequence("V_MSRPT_COLUMNF_");
        modelBuilder.HasSequence("V_MSRPT_CONDITIC_");
        modelBuilder.HasSequence("V_MSRPT_FIXEDC_");
        modelBuilder.HasSequence("V_MSRPT_FIXEDCF_");
        modelBuilder.HasSequence("V_MSRPT_FIXEDROW_");
        modelBuilder.HasSequence("V_MSRPT_GROUPF_");
        modelBuilder.HasSequence("V_MSRPT_GROUPH_");
        modelBuilder.HasSequence("V_MSRPT_GROUPINF_");
        modelBuilder.HasSequence("V_MSRPT_KEYFIELD_");
        modelBuilder.HasSequence("V_MSRPT_LINEC_");
        modelBuilder.HasSequence("V_MSRPT_LINEFONT_");
        modelBuilder.HasSequence("V_MSRPT_ORDERF_");
        modelBuilder.HasSequence("V_MSRPT_ORDERINF_");
        modelBuilder.HasSequence("V_MSRPT_PARENTC_");
        modelBuilder.HasSequence("V_MSRPT_REPETICO_");
        modelBuilder.HasSequence("V_MSRPT_REPORT_");
        modelBuilder.HasSequence("V_MSRPT_REPORTC_");
        modelBuilder.HasSequence("V_MSRPT_REPORTCRT_");
        modelBuilder.HasSequence("V_MSRPT_REPORTE_");
        modelBuilder.HasSequence("V_MSRPT_REPORTF_");
        modelBuilder.HasSequence("V_MSRPT_REPORTH_");
        modelBuilder.HasSequence("V_MSRPT_REPORTR_");
        modelBuilder.HasSequence("V_MSRPT_REPORTSC_");
        modelBuilder.HasSequence("V_MSRPT_REPORTV_");
        modelBuilder.HasSequence("V_MSRPT_RPTC_");
        modelBuilder.HasSequence("V_MSRPT_RPTQP_");
        modelBuilder.HasSequence("V_MSRPT_SERIE_");
        modelBuilder.HasSequence("V_MSRPT_TABLEC_");
        modelBuilder.HasSequence("V_MSRPT_TABLEG_");
        modelBuilder.HasSequence("V_MSRPT_TABLEGC_");
        modelBuilder.HasSequence("V_MSRPT_TXTAL_");
        modelBuilder.HasSequence("V_MSRPT_TXTE_");
        modelBuilder.HasSequence("V_MSRPT_TXTRC_");
        modelBuilder.HasSequence("V_MSRPT_TXTRPT_");
        modelBuilder.HasSequence("V_MSRPT_TXTTC_");
        modelBuilder.HasSequence("V_MSRPT_UIC_");
        modelBuilder.HasSequence("V_MSRPT_UIELEMENT_");
        modelBuilder.HasSequence("V_MSRPT_UITC_");
        modelBuilder.HasSequence("V_MSRPT_VARIABLC_");
        modelBuilder.HasSequence("V_MSSEC_CONDITIP_");
        modelBuilder.HasSequence("V_MSSEC_DATAP_");
        modelBuilder.HasSequence("V_MSSEC_GROUPP_");
        modelBuilder.HasSequence("V_MSSEC_GROUPPRFL_");
        modelBuilder.HasSequence("V_MSSEC_MENU_");
        modelBuilder.HasSequence("V_MSSEC_PRIVILEGE_");
        modelBuilder.HasSequence("V_MSSEC_SERVICEM_");
        modelBuilder.HasSequence("V_MSSEC_SERVICEP_");
        modelBuilder.HasSequence("V_MSSEC_USERP_");
        modelBuilder.HasSequence("V_MSSEC_USERPRFL_");
        modelBuilder.HasSequence("V_MSTRP_COLUMNC_");
        modelBuilder.HasSequence("V_MSTRP_CONDITIC_");
        modelBuilder.HasSequence("V_MSTRP_CRITERIM_");
        modelBuilder.HasSequence("V_MSTRP_DOCUMENC_");
        modelBuilder.HasSequence("V_MSTRP_FONT_");
        modelBuilder.HasSequence("V_MSTRP_FOOTERC_");
        modelBuilder.HasSequence("V_MSTRP_GROUPBY_");
        modelBuilder.HasSequence("V_MSTRP_HEADERC_");
        modelBuilder.HasSequence("V_MSTRP_ORDERBY_");
        modelBuilder.HasSequence("V_MSTRP_PAGEC_");
        modelBuilder.HasSequence("V_MSTRP_REPORTC_");
        modelBuilder.HasSequence("V_MSTRP_REPORTV_");
        modelBuilder.HasSequence("V_MSTRP_TABLECFG_");
        modelBuilder.HasSequence("V_MSTRP_TABLECRT_");
        modelBuilder.HasSequence("V_MSTRP_TEXTFC_");
        modelBuilder.HasSequence("V_MSTRP_TEXTR_");
        modelBuilder.HasSequence("V_MSVLD_ACTION_");
        modelBuilder.HasSequence("V_MSVLD_MODIFICR_");
        modelBuilder.HasSequence("V_MSVLD_STEP_");
        modelBuilder.HasSequence("V_MSVLD_VALIDATI_");
        modelBuilder.HasSequence("V_MSVLD_VALIDATP_");
        modelBuilder.HasSequence("V_MSVLD_VALIDATR_");
        modelBuilder.HasSequence("V_PARAMDEF_");
        modelBuilder.HasSequence("V_STROPE_");
        modelBuilder.HasSequence("V_SWFTBLOK1_");
        modelBuilder.HasSequence("V_SWFTBLOK2_");
        modelBuilder.HasSequence("V_SWFTBLOK3_");
        modelBuilder.HasSequence("V_SWFTBLOK4_");
        modelBuilder.HasSequence("V_SWFTBLOK5_");
        modelBuilder.HasSequence("V_SWFTBUSER_");
        modelBuilder.HasSequence("V_TRANSITINS_");
        modelBuilder.HasSequence("V_TTY_OPERATION_");
        modelBuilder.HasSequence("VALIDATIOCDMCH_");
        modelBuilder.HasSequence("VALUEDC_");
        modelBuilder.HasSequence("VALUEEF_");
        modelBuilder.HasSequence("VALUEEFC_");
        modelBuilder.HasSequence("VATCONTEXTVALUE_");
        modelBuilder.HasSequence("VATRATE_");
        modelBuilder.HasSequence("VENDORI_");
        modelBuilder.HasSequence("VENDORINCENTIVE_");
        modelBuilder.HasSequence("VG_PAYINC_");
        modelBuilder.HasSequence("VIPCLIENT_");
        modelBuilder.HasSequence("VISADEPLAN_");
        modelBuilder.HasSequence("VISIONAE_");
        modelBuilder.HasSequence("VISIONAMOUNT_");
        modelBuilder.HasSequence("VISIONC_");
        modelBuilder.HasSequence("VISIONCRITERIA_");
        modelBuilder.HasSequence("VISIONDATE_");
        modelBuilder.HasSequence("VISIONEE_");
        modelBuilder.HasSequence("VISIONEEV_");
        modelBuilder.HasSequence("VISIONESBEVENT_");
        modelBuilder.HasSequence("VISIONIMPACT_");
        modelBuilder.HasSequence("VISIONMESSAGE_");
        modelBuilder.HasSequence("VISIONPE_");
        modelBuilder.HasSequence("VISIONPROPERTY_");
        modelBuilder.HasSequence("VISIONRULE_");
        modelBuilder.HasSequence("VISITECLIENT_");
        modelBuilder.HasSequence("VOLUMEBP_");
        modelBuilder.HasSequence("VOLUMECOFFRE_");
        modelBuilder.HasSequence("WARCONSCOND_");
        modelBuilder.HasSequence("WARDOC_");
        modelBuilder.HasSequence("WARDOCDOCUMENTFI_");
        modelBuilder.HasSequence("WARDOCTYP_");
        modelBuilder.HasSequence("WARDOCTYPTEMPLATE_");
        modelBuilder.HasSequence("WARMEJEVVH_");
        modelBuilder.HasSequence("WARMEJVH_");
        modelBuilder.HasSequence("WARRANTYA_");
        modelBuilder.HasSequence("WARRANTYB_");
        modelBuilder.HasSequence("WARRANTYC_");
        modelBuilder.HasSequence("WARRANTYCC_");
        modelBuilder.HasSequence("WARRANTYCD_");
        modelBuilder.HasSequence("WARRANTYD_");
        modelBuilder.HasSequence("WARRANTYDDOCUMENTFI_");
        modelBuilder.HasSequence("WARRANTYG_");
        modelBuilder.HasSequence("WARRANTYM_");
        modelBuilder.HasSequence("WARRANTYMC_");
        modelBuilder.HasSequence("WARRANTYMEJ_");
        modelBuilder.HasSequence("WARRANTYNATURE_");
        modelBuilder.HasSequence("WARRANTYRENEWAL_");
        modelBuilder.HasSequence("WARRANTYRVH_");
        modelBuilder.HasSequence("WARRANTYTI_");
        modelBuilder.HasSequence("WARRANTYTYPE_");
        modelBuilder.HasSequence("WARRANTYVISION_");
        modelBuilder.HasSequence("WARRATYMC_");
        modelBuilder.HasSequence("WARTYPDOC_");
        modelBuilder.HasSequence("WARTYPINFO_");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
