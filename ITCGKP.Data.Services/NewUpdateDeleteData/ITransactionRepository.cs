using ITCGKP.Data.ViewModels.Financial;
using ITCGKP.Data.ViewModels.Transaction;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITCGKP.Data.Services.NewUpdateDeleteData
{
    public interface ITransactionRepository
    {
        // Purchase File
        Task<string> PurchaseSrNoCreation(int cmpid);
        Task<int> AddNewPurchaseFile(PurchaseViewModel models);
        Task<bool> UpdatePurchaseFile(PurchaseViewModel models);
        Task<PurchaseViewModel> GetPurchaseFileById(int id);
        Task<bool> DeletePurchaseFile(PurchaseViewModel models);
        Task<bool> DeletePurchaseOne(int id, int tno);
        Task<List<PurchaseViewModel>> SearchPurchaseFileDateWise(int CmpId, string UCode, string invno, string name, string mobileno, string address, decimal totalamt, decimal discamt, decimal grandamt, DateTime dt1, DateTime dt2);
        Task<PurchaseDetailViewModel> PurchaseDetailFileLastRecord(int id);

        // Purchase Return File (Debit Notes)
        Task<string> PurchaseReturnSrNoCreation(int cmpid);
        Task<int> AddNewPurchaseReturnFile(PurchaseRViewModel models);
        Task<bool> UpdatePurchaseReturnFile(PurchaseRViewModel models);
        Task<PurchaseRViewModel> GetPurchaseReturnFileById(int id);
        Task<bool> DeletePurchaseReturnFile(PurchaseRViewModel models);
        Task<bool> DeletePurchaseReturnOne(int id, int tno);
        Task<List<PurchaseRViewModel>> SearchPurchaseReturnFileDateWise(int CmpId, string UCode, string invno, string name, string mobileno, string address, decimal totalamt, decimal discamt, decimal grandamt, DateTime dt1, DateTime dt2);

        // Sale File
        Task<string> SaleSrNoCreation(int cmpid);
        Task<int> AddNewSaleFile(SaleViewModel models);
        Task<bool> UpdateSaleFile(SaleViewModel models);
        Task<SaleViewModel> GetSaleFileById(int id);
        Task<bool> DeleteSaleFile(SaleViewModel models);
        Task<bool> DeleteSaleFileOne(int id, int tno);
        Task<List<SaleViewModel>> SearchSaleFileDateWise(int CmpId, string UCode, string invno, string name, string address, decimal totalamt, decimal discamt, decimal grandamt, decimal paidamt, DateTime dt1, DateTime dt2);

        // Sale Return File (Credit Notes)
        Task<string> SaleReturnSrNoCreation(int cmpid);
        Task<int> AddNewSaleReturnFile(SaleRViewModel models);
        Task<bool> UpdateSaleReturnFile(SaleRViewModel models);
        Task<SaleRViewModel> GetSaleReturnFileById(int id);
        Task<bool> DeleteSaleReturnFile(SaleRViewModel models);
        Task<bool> DeleteSaleReturnFileOne(int id, int tno);
        Task<List<SaleRViewModel>> SearchSaleReturnFileDateWise(int CmpId, string UCode, string invno, string name, string address, decimal totalamt, decimal discamt, decimal grandamt, DateTime dt1, DateTime dt2);

        // Purchase / Sale Order File
        Task<string> PurchaseOrderSrNoCreation(int cmpid);
        Task<int> AddNewPurchaseOrderFile(PurchaseOrderViewModel models);
        Task<bool> UpdatePurchaseOrderFile(PurchaseOrderViewModel models);
        Task<PurchaseOrderViewModel> GetPurchaseOrderFileById(int id);
        Task<bool> DeletePurchaseOrderFile(PurchaseOrderViewModel models);
        Task<bool> DeletePurchaseOrderFileOne(int id, int tno);
        Task<List<PurchaseOrderViewModel>> SearchPurchaseOrderFileDateWise(int CmpId, string UCode, string invno, string name, string mobileno, string address, DateTime dt1, DateTime dt2);

        // Voucher File
        Task<string> VoucherSrNoCreation(int cmpid, string vouchtype);
        Task<int> AddNewVoucherRecord(VoucherViewModel model);
        Task<bool> UpdateVoucherRecord(VoucherViewModel model);
        Task<VoucherViewModel> GetVoucherById(int id);
        Task<bool> DeleteVoucherRecord(int id);
        Task<bool> DeleteVoucherOneRecord(int id, int tno);
        Task<List<VoucherViewModel>> SearchVoucherDateWise(int CmpId, string userId, string vouchertype, decimal totalAmt, decimal creditAmt, DateTime dt1, DateTime dt2);
        Task<List<VoucherViewModel>> AccountGroupVoucherDateWise(int CmpId, DateTime dt2, int AcGroupId);
        Task<int> LedgerBeforeDateBal(DateTime dt1, int AcId);
        Task<List<VoucherViewModel>> LedgerVoucherDateWise(DateTime dt1, DateTime dt2, int AcId);
        Task<List<VoucherDetailViewModel>> LedgerIdRecord(int id);
        Task<List<LedgerMasterViewModel>> DailyWorkSummaryAccountGroup(DateTime dt1);
        Task<List<VoucherViewModel>> DailyWorkSummaryDateWise(DateTime dt1);
        Task<List<VoucherViewModel>> CashBankDateWise(DateTime dt1, DateTime dt2, int AcId);
    }
}