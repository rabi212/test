using ITCGKP.Data.ViewModels.Financial;
using ITCGKP.Data.ViewModels.Master;
using ITCGKP.Data.ViewModels.Transaction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITCGKP.Data.Services.NewUpdateDeleteData
{
    public interface IFinancialRepository
    {
        // A/c Group Table
        Task<string> HeadGroupSrNoCreation();
        Task<int> AddNewAccountGroupMaster(AccountGroupViewModel model);
        Task<bool> UpdateAccountGroupMaster(AccountGroupViewModel model);
        Task<List<AccountGroupViewModel>> GetAllAccountGroupMaster(int id);
        Task<AccountGroupViewModel> GetAccountGroupMasterById(int id);
        Task<List<AccountGroupViewModel>> SearchAccountGroupUnderName(string searchName);
        Task<bool> DeleteAccountGroupMaster(int id);

        // Address Book Duplication Ledger Master 
        Task<string> AddressSrNoCreation(int? cmpdid);
        Task<int> AddNewAddressMasterRecord(LedgerMasterViewModel models);
        Task<bool> UpdateAddressMaster(LedgerMasterViewModel models);
        Task<LedgerMasterViewModel> GetAddressMasterById(int id);
        Task<bool> DeleteAddressMaster(int id);
        Task<List<LedgerMasterViewModel>> SearchAddressMasterUnderName(string searchName);
        Task<List<LedgerMasterViewModel>> GetAllAddressMaster(int cmdid);
        Task<List<LedgerMasterViewModel>> GetAllAddressMasterName(int cmdid, string partyname = "", string mobileno = "", string cityname = "");
        Task<int> GetIdLedgerMasterByCode(string id);
        Task<List<LedgerMasterViewModel>> GetLedgerHelpFile(int compId);
        Task<List<LedgerMasterViewModel>> SearchLedgerMasterByALLGroup(int compId);
        // Account Configuration file
        Task<int> AddNewAccountConfigMasterRecord(AccountConfigViewModel model);
        Task<bool> UpdateAccountConfig(AccountConfigViewModel model);
        Task<AccountConfigViewModel> GetAccountConfigById(int id);
        Task<List<AccountConfigViewModel>> GetALLAccountConfig(int compId);

        // Product Measurement Details
        Task<string> ProductMeasurementSrNoCreation();
        Task<int> AddNewProductMeasurementRecord(UnitMeasurementViewModel model);
        Task<bool> UpdateProductMeasurement(UnitMeasurementViewModel model);
        Task<UnitMeasurementViewModel> GetProductMeasurementById(int id);
        Task<bool> DeleteProductMeasurement(int id);
        Task<List<UnitMeasurementViewModel>> GetAllProductMeasurement();
        Task<List<UnitMeasurementViewModel>> GetAllProductMeasurementName();
        Task<List<UnitMeasurementViewModel>> GetAllProductMeasurementName(string name);

        // UQC Master Table
        Task<int> AddNewUQCRecord(UQCMasterViewModel model);
        Task<bool> UpdateUQC(UQCMasterViewModel model);
        Task<UQCMasterViewModel> GetUQCById(int id);
        Task<bool> DeleteUQC(int id);
        Task<List<UQCMasterViewModel>> GetAllUQC();

        // Product Company Details
        Task<string> ProductCompanySrNoCreation();
        Task<int> AddNewProductCompanyRecord(ProductCompanyViewModel model);
        Task<bool> UpdateProductCompany(ProductCompanyViewModel model);
        Task<ProductCompanyViewModel> GetProductCompanyById(int id);
        Task<bool> DeleteProductCompany(int id);
        Task<List<ProductCompanyViewModel>> GetAllProductCompany();
        Task<List<ProductCompanyViewModel>> GetAllProductCompanyName();
        Task<List<ProductCompanyViewModel>> GetAllProductCompanyName(string name);

        // Item Group Table
        Task<string> ItemGroupSrNoCreation();
        Task<int> AddNewItemGroupRecord(ItemGroupViewModel model);
        Task<bool> UpdateItemGroup(ItemGroupViewModel model);
        Task<ItemGroupViewModel> GetItemGroupById(int id);
        Task<bool> DeleteItemGroup(int id);
        Task<List<ItemGroupViewModel>> GetAllItemGroup();
        Task<List<ItemGroupViewModel>> GetAllItemGroupOrderName();
        Task<List<ItemGroupViewModel>> GetAllItemGroupByName(string name);
        Task<int> GetAllIdItemGroupByName(string name);
        // Packing Master File
        Task<string> PackingSrNoCreation();
        Task<int> AddNewPackingRecord(PackingMasterViewModel model);
        Task<bool> UpdatePackingMaster(PackingMasterViewModel model);
        Task<PackingMasterViewModel> GetPackingMasterById(int id);
        Task<bool> DeletePackingMaster(int id);
        Task<List<PackingMasterViewModel>> SearchPackingMasterName(string searchName);
        Task<List<PackingMasterViewModel>> GetALLPackingMaster();
        Task<List<PackingMasterViewModel>> GetALLPackingMasterName(string name);

        //  Item Master File
        Task<string> ItemSrNoCreation();
        Task<int> AddNewItemMasterRecord(ItemMasterViewModel model);
        Task<bool> UpdateItemMaster(ItemMasterViewModel model);
        Task<ItemMasterViewModel> GetItemMasterById(int id);
        Task<bool> DeleteItemMaster(int id);
        Task<List<ItemMasterViewModel>> SearchItemMasterName(string searchName);
        Task<List<ItemMasterViewModel>> GetALLItemMaster();
        Task<List<ItemMasterViewModel>> GetALLItemMasterName(int itemGroupId, int prodid, string itemname = "", string prodcompanme = "", string hsncode = "");
        // Openning Item Stock
        Task<string> OpnSrNoCreation(int cmpid);
        Task<int> AddNewOpenItemMaster(OpenItemMasterViewModel models);
        Task<bool> UpdateOpenItemMaster(OpenItemMasterViewModel models);
        Task<OpenItemMasterViewModel> GetOpenItemMasterById(int id);
        Task<bool> DeleteOpenItemMaster(OpenItemMasterViewModel models);
        Task<bool> DeleteOpenItemMasterOne(int id, int tno);
        Task<List<OpenItemMasterViewModel>> GetALLOpenItemMasterDateWise(string uid, string StartDate, string EndDate);
        Task<List<OpenItemMasterViewModel>> SearchOpenItemMasterDateWise(int CmpId, string UCode, DateTime dt1, DateTime dt2);
        Task<List<ItemStockViewModel>> SearchItemStockDateWise(int CmpId, int ProdCompId, int itemGroupId, int itemPackId, string itemname, string hsncode,DateTime dt1);
        Task<List<ItemBalanceViewModel>> SearchItemBalanceByItemId(int itemid, int cmpid);
        Task<ItemBalanceViewModel> ItemBalanceAutomationAdd(int itemid, int cmpid);

        // Vouher Transfer
        Task<int> TransferPatientToVoucher(PatientViewModel models);
        Task<bool> TransferPatientToUpdateVoucher(PatientViewModel models);
        Task<bool> DeletePatientVoucher(string VchNo, string Userid, int? cmpid);
        Task<List<VoucherViewModel>> GetVoucherIPDateWise(int cmpid, int DoctorId, DateTime FromDt, DateTime UptoDt);
    }
}
