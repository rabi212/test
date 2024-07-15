using ITCGKP.Data.Models;
using ITCGKP.Data.Models.Financial;
using ITCGKP.Data.Models.Master;
using ITCGKP.Data.Models.PayBill;
using ITCGKP.Data.Models.Setting;
using ITCGKP.Data.Models.Transaction;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITCGKP.Data.Services
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);           
        //}
        public DbSet<Titles> TitlesTable { get; set; }
        public DbSet<CompanyDetail> CompanyDetailTable { get; set; }
        public DbSet<State> StateTable { get; set; }
        public DbSet<District> DistrictTable { get; set; }
        public DbSet<SMSKey> SMSKeyTable { get; set; }
        public DbSet<MoneyMaster> MoneyMasterTable { get; set; }
        public DbSet<UploadPhotoFront> UploadPhotoFrontTable { get; set; }
        public DbSet<SMSFile> SMSFileTable { get; set; }
        public DbSet<CheckMessageSend> CheckMessageSendTable { get; set; }
        public DbSet<FontCustom> FontCustomTable { get; set; }

        // Master Record
        public DbSet<PageSetup> PageSetupTable { get; set; }
        public DbSet<AreaFile> AreaFileTable { get; set; }
        public DbSet<ClientFile> ClientFileTable { get; set; }

        public DbSet<AgentFile> AgentFileTable { get; set; }
        public DbSet<TestGroupMaster> TestGroupTable { get; set; }
        public DbSet<Doctor> DoctorTable { get; set; }
        public DbSet<DoctorDetailsMaster> DoctorDetailsMasterTable { get; set; }
        public DbSet<DoctorLab> DoctorLabTable { get; set; }
        public DbSet<ReportGroup> ReportGroupTable { get; set; }
        public DbSet<TestMaster> TestMasterTable { get; set; }
        public DbSet<TestDocMaster> TestDocMasterTable { get; set; }
        public DbSet<TestSubMaster> TestSubMasterTable { get; set; }
        public DbSet<Patient> PatientTable { get; set; }
        public DbSet<PatientII> PatientIITable { get; set; }
        public DbSet<PatientDetailsMaster> PatientDetailsMasterTable { get; set; }
        public DbSet<PatientDiscountMaster> PatientDiscountMasterTable { get; set; }
        public DbSet<PatientInvestigation> PatientInvestigationTable { get; set; }
        public DbSet<TestResult> TestResultTable { get; set; }
        public DbSet<TestResultDetail> TestResultDetailTable { get; set; }
        public DbSet<PatientAudit> PatientAuditTable { get; set; }
        public DbSet<PatientDueRecipt> PatientDueReciptTable { get; set; }

        public DbSet<MedMaster> MedMasterTable { get; set; }
        public DbSet<MedTest> MedTestTable { get; set; }
        public DbSet<MedTestDetail> MedTestDetailTable { get; set; }

        // Pay Bill File
        public DbSet<UpdatePayBill> PayBillTable { get; set; }
        // Financial Tables
        public DbSet<AccountConfig> AccountConfigTable { get; set; }
        public DbSet<AccountGroup> HeadGroupTable { get; set; }
        public DbSet<LedgerMaster> HeadTable { get; set; }
        public DbSet<ItemGroup> ItemGroupTable { get; set; }
        public DbSet<ProductCompany> ProductCompanyTable { get; set; }
        public DbSet<PackingMaster> PackingTable { get; set; }
        public DbSet<UnitMeasurement> UnitMeasurementTable { get; set; }
        public DbSet<UQCMaster> UQCMasterTable { get; set; }
        public DbSet<ItemMaster> ItemTable { get; set; }
        public DbSet<OpenItemMaster> OpenItemMasterTable { get; set; }
        public DbSet<OpenItemMasterDetail> OpenItemMasterDetailTable { get; set; }

        // Transaction
        public DbSet<ItemStock> ItemStockTable { get; set; }
        public DbSet<ItemBalance> ItemBalanceTable { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrderTable { get; set; }
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetailTable { get; set; }
        public DbSet<Sale> SaleTable { get; set; }
        public DbSet<SaleDetail> SaleDetailTable { get; set; }
        public DbSet<SaleR> SaleRTable { get; set; }
        public DbSet<SaleRDetail> SaleRDetailTable { get; set; }
        public DbSet<Purchase> PurchaseTable { get; set; }
        public DbSet<PurchaseDetail> PurchaseDetailTable { get; set; }
        public DbSet<PurchaseR> PurchaseRTable { get; set; }
        public DbSet<PurchaseRDetail> PurchaseRDetailTable { get; set; }
        public DbSet<Voucher> VoucherTable { get; set; }
        public DbSet<VoucherDetail> VoucherDetailTable { get; set; }

    }
}
