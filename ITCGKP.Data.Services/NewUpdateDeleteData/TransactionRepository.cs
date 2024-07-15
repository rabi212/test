using ITCGKP.Data.Models.Financial;
using ITCGKP.Data.Models.Transaction;
using ITCGKP.Data.ViewModels;
using ITCGKP.Data.ViewModels.Financial;
using ITCGKP.Data.ViewModels.Master;
using ITCGKP.Data.ViewModels.Setting;
using ITCGKP.Data.ViewModels.Transaction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCGKP.Data.Services.NewUpdateDeleteData
{
    public class TransactionRepository : VariableService, ITransactionRepository 
    {
        string[] myzero = { "0000", "000", "00", "0" };
        string[] myTwozero = { "00", "0" };
        string[] myThreezero = { "000", "00", "0" };
        private readonly ApplicationDBContext _applicationDbContext = null;
        public TransactionRepository(ApplicationDBContext applicationDBContext)
        {
            _applicationDbContext = applicationDBContext;
        }
        // Purchase    File
        public async Task<string> PurchaseSrNoCreation(int cmpid)
        {
            var NewNo = ""; var NewValue = 0; CurrentIndex = 0;
            var result = await _applicationDbContext.PurchaseTable
                          .OrderByDescending(x => x.STId)
                          .Select(x => new { x.STVNo, x.CompId })
                          .FirstOrDefaultAsync(x => x.CompId == cmpid);
            if (result != null)
            {
                string[] parts1 = result.STVNo.Split('P');
                NewValue = Convert.ToInt32(parts1[1]) + 1;
                CurrentIndex = Convert.ToInt32(NewValue.ToString().Length) - 1;
                NewNo = CurrentIndex < 4 ? "P" + myzero[CurrentIndex] + (NewValue) : "P" + NewValue.ToString();
            }
            else
            {
                NewNo = "P00001";
            }
            return NewNo;
        }
        public async Task<int> AddNewPurchaseFile(PurchaseViewModel models)
        {
            DateTime? Date1 = null;
            userdt = models.STDate.Split('/');
            userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            if (!string.IsNullOrEmpty(models.OrderDate))
            {
                userdt = models.OrderDate.Split('/');
                userdt2 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            }
            Purchase opnitemMaster = new Purchase()
            {
                UserCode = models.UserCode,
                CompId = models.CompId,
                STVNo = models.STVNo,
                STDate = string.IsNullOrEmpty(models.STDate) ? Date1 : Convert.ToDateTime(userdt1),
                OrderNo = models.OrderNo,
                OrderDate = string.IsNullOrEmpty(models.OrderDate) ? Date1 : Convert.ToDateTime(userdt2),
                PayMode = (int)models.PayMode,
                AcCode = models.AcCode,
                CustName = models.CustName,
                CustAddress1 = models.CustAddress1,
                CustLedStateId = models.CustLedStateId,
                NetAmt = models.NetAmt,
                DiscAmt = models.DiscAmt,
                CGSTTotalAmt = models.CGSTTotalAmt,
                SGSTTotalAmt = models.SGSTTotalAmt,
                IGSTTotalAmt = models.IGSTTotalAmt,
                CessTotalAmt = models.CessTotalAmt,
                OtherAmt1 = models.OtherAmt1,
                OtherAmt2 = models.OtherAmt2,
                TotalAmt = models.TotalAmt,
                CashAmt = models.CashAmt,
                DigitalAmt = models.DigitalAmt
            };
            _applicationDbContext.Entry(opnitemMaster).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            foreach (var item in models.PurchaseDetailViewModels)
            {
                Date1 = null; userdt = item.ExpDate.Split('/');
                userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
                PurchaseDetail order = new PurchaseDetail()
                {
                    STMDId = item.STMDId,
                    ItemCode = item.ItemCode,
                    STItemName = item.STItemName,
                    BatchNo = item.BatchNo,
                    ExpDate = string.IsNullOrEmpty(item.ExpDate) ? Date1 : Convert.ToDateTime(userdt1),
                    CasePcs = item.CasePcs,
                    OnFreeCase = item.OnFreeCase,
                    UnitCase = item.UnitCase,
                    FreePcs = item.FreePcs,
                    TotalPcs = item.TotalPcs,
                    PurRate = item.PurRate,
                    DiscPer1 = item.DiscPer1,
                    DiscAmt1 = item.DiscAmt1,
                    DiscPer2 = item.DiscPer2,
                    DiscAmt2 = item.DiscAmt2,
                    DiscPer3 = item.DiscPer3,
                    DiscAmt3 =  item.DiscAmt3,
                    TotalDiscAmt = item.TotalDiscAmt,
                    GSTPer = item.GSTPer,
                    CGSTAmt = item.CGSTAmt,
                    SGSTAmt = item.SGSTAmt,
                    IGSTAmt = item.IGSTAmt,
                    MRP = item.MRP,
                    SaleRate = item.SaleRate,
                    NetPurRate = item.NetPurRate,
                    PurAmt = item.PurAmt,
                    NetPurAmt = item.NetPurAmt,
                    MRPAmt = item.MRPAmt,
                    TempSrNo = (int)item.TempSrNo,
                    CompIdSTItemMD = models.CompId,
                    UserCodeSTItemMD = models.UserCode,
                    STVNoD = models.STVNo,
                    STIMId = opnitemMaster.STId
                };
                _applicationDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            await _applicationDbContext.SaveChangesAsync();
            return opnitemMaster.STId;
        }
        public async Task<bool> UpdatePurchaseFile(PurchaseViewModel models)
        {
            DateTime? Date1 = null;
            userdt = models.STDate.Split('/');
            userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            if (!string.IsNullOrEmpty(models.OrderDate))
            {
                userdt = models.OrderDate.Split('/');
                userdt2 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            }
            var result = await _applicationDbContext.PurchaseTable.FirstOrDefaultAsync(n => n.STId == models.STId);
            if (result != null)
            {
                result.UserCode = result.UserCode;
                result.CompId = result.CompId;
                result.STVNo = models.STVNo;
                result.STDate = string.IsNullOrEmpty(models.STDate) ? Date1 : Convert.ToDateTime(userdt1);
                result.OrderNo = models.OrderNo;
                result.OrderDate = string.IsNullOrEmpty(models.OrderDate) ? Date1 : Convert.ToDateTime(userdt2);
                result.PayMode = (int)models.PayMode;
                result.AcCode = models.AcCode;
                result.CustName = models.CustName;
                result.CustAddress1 = models.CustAddress1;
                result.CustLedStateId = models.CustLedStateId;
                result.NetAmt = models.NetAmt;
                result.DiscAmt = models.DiscAmt;
                result.CGSTTotalAmt = models.CGSTTotalAmt;
                result.SGSTTotalAmt = models.SGSTTotalAmt;
                result.IGSTTotalAmt = models.IGSTTotalAmt;
                result.CessTotalAmt = models.CessTotalAmt;
                result.OtherAmt1 = models.OtherAmt1;
                result.OtherAmt2 = models.OtherAmt2;
                result.TotalAmt = models.TotalAmt;
                result.CashAmt = models.CashAmt;
                result.DigitalAmt = models.DigitalAmt;
            };
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();

            foreach (var item in models.PurchaseDetailViewModels)
            {
                Date1 = null; userdt = item.ExpDate.Split('/');
                userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
                var result1 = await _applicationDbContext.PurchaseDetailTable.FirstOrDefaultAsync(x => x.TempSrNo == item.TempSrNo && x.STIMId == models.STId);
                if (result1 != null)
                {
                    result1.ItemCode = item.ItemCode;
                    result1.STItemName = item.STItemName;
                    result1.BatchNo = item.BatchNo;
                    result1.ExpDate = string.IsNullOrEmpty(item.ExpDate) ? Date1 : Convert.ToDateTime(userdt1);
                    result1.CasePcs = item.CasePcs;
                    result1.OnFreeCase = item.OnFreeCase;
                    result1.UnitCase = item.UnitCase;
                    result1.FreePcs = item.FreePcs;
                    result1.TotalPcs = item.TotalPcs;
                    result1.PurRate = item.PurRate;
                    result1.DiscPer1 = item.DiscPer1;
                    result1.DiscAmt1 = item.DiscAmt1;
                    result1.DiscPer2 = item.DiscPer2;
                    result1.DiscAmt2 = item.DiscAmt2;
                    result1.DiscPer3 = item.DiscPer3;
                    result1.DiscAmt3 = item.DiscAmt3;
                    result1.TotalDiscAmt = item.TotalDiscAmt;
                    result1.GSTPer = item.GSTPer;
                    result1.CGSTAmt = item.CGSTAmt;
                    result1.SGSTAmt = item.SGSTAmt;
                    result1.IGSTAmt = item.IGSTAmt;
                    result1.MRP = item.MRP;
                    result1.SaleRate = item.SaleRate;
                    result1.NetPurRate = item.NetPurRate;
                    result1.PurAmt = item.PurAmt;
                    result1.NetPurAmt = item.NetPurAmt;
                    result1.MRPAmt = item.MRPAmt;
                    result1.CompIdSTItemMD = result.CompId;
                    result1.UserCodeSTItemMD = result.UserCode;
                    result1.STVNoD = result.STVNo;
                    result1.STIMId = result.STId;
                    _applicationDbContext.Entry(result1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                else
                {
                    PurchaseDetail order = new PurchaseDetail()
                    {
                        ItemCode = item.ItemCode,
                        STItemName = item.STItemName,
                        BatchNo = item.BatchNo,
                        ExpDate = string.IsNullOrEmpty(item.ExpDate) ? Date1 : Convert.ToDateTime(userdt1),
                        CasePcs = item.CasePcs,
                        OnFreeCase = item.OnFreeCase,
                        UnitCase = item.UnitCase,
                        FreePcs = item.FreePcs,
                        TotalPcs = item.TotalPcs,
                        PurRate = item.PurRate,
                        DiscPer1 = item.DiscPer1,
                        DiscAmt1 = item.DiscAmt1,
                        DiscPer2 = item.DiscPer2,
                        DiscAmt2 = item.DiscAmt2,
                        DiscPer3 = item.DiscPer3,
                        DiscAmt3 = item.DiscAmt3,
                        TotalDiscAmt = item.TotalDiscAmt,
                        GSTPer = item.GSTPer,
                        CGSTAmt = item.CGSTAmt,
                        SGSTAmt = item.SGSTAmt,
                        IGSTAmt = item.IGSTAmt,
                        MRP = item.MRP,
                        SaleRate = item.SaleRate,
                        NetPurRate = item.NetPurRate,
                        PurAmt = item.PurAmt,
                        NetPurAmt = item.NetPurAmt,
                        MRPAmt = item.MRPAmt,
                        TempSrNo = (int)item.TempSrNo,
                        CompIdSTItemMD = result.CompId,
                        UserCodeSTItemMD = result.UserCode,
                        STVNoD = models.STVNo,
                        STIMId = result.STId
                    };
                    _applicationDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                }
            }
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<PurchaseViewModel> GetPurchaseFileById(int id)
        {
            var result = await _applicationDbContext.PurchaseTable
                    .Select(x => new PurchaseViewModel()
                    {
                        STId = x.STId,
                        CompId = x.CompId,
                        UserCode = x.UserCode,
                        STVNo = x.STVNo,
                        STDate = (x.STDate != null ? Convert.ToDateTime(x.STDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                        OrderNo = x.OrderNo,
                        OrderDate = (x.OrderDate != null ? Convert.ToDateTime(x.OrderDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                        PayMode = (PaymentMode) x.PayMode,
                        AcCode = x.AcCode,
                        CustName = x.CustName,
                        CustAddress1 = x.CustAddress1,    
                        CustLedStateId = x.CustLedStateId,
                        NetAmt = x.NetAmt,
                        DiscAmt = x.DiscAmt,
                        CGSTTotalAmt = x.CGSTTotalAmt,
                        SGSTTotalAmt = x.SGSTTotalAmt,
                        IGSTTotalAmt = x.IGSTTotalAmt,
                        CessTotalAmt = x.CessTotalAmt,
                        OtherAmt1 = x.OtherAmt1,
                        OtherAmt2 = x.OtherAmt2,
                        TotalAmt = x.TotalAmt,
                        CashAmt = x.CashAmt,
                        DigitalAmt = x.DigitalAmt,
                        PurchaseDetailViewModels = x.PurchaseDetails.Where(a => a.STIMId == x.STId)
                        .OrderBy(a => a.TempSrNo)
                        .Select(n => new PurchaseDetailViewModel()
                        {
                            TempSrNo = n.TempSrNo,
                            ItemCode = n.ItemCode,
                            STItemName = n.STItemName,
                            BatchNo = n.BatchNo,
                            ExpDate = (n.ExpDate != null ? Convert.ToDateTime(n.ExpDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                            CasePcs = n.CasePcs,
                            OnFreeCase = n.OnFreeCase,
                            UnitCase = n.UnitCase,
                            FreePcs = n.FreePcs,
                            TotalPcs = n.TotalPcs,
                            PurRate = n.PurRate,
                            DiscPer1 = n.DiscPer1,
                            DiscAmt1 = n.DiscAmt1,
                            DiscPer2 = n.DiscPer2,
                            DiscAmt2 = n.DiscAmt2,
                            DiscPer3 = n.DiscPer3,
                            DiscAmt3 = n.DiscAmt3,
                            TotalDiscAmt = n.TotalDiscAmt,
                            GSTPer = n.GSTPer,
                            CGSTAmt = n.CGSTAmt,
                            SGSTAmt = n.SGSTAmt,
                            IGSTAmt = n.IGSTAmt,
                            MRP = n.MRP,
                            SaleRate = n.SaleRate,
                            NetPurRate = n.NetPurRate,
                            PurAmt = n.PurAmt,
                            NetPurAmt = n.NetPurAmt,
                            MRPAmt = n.MRPAmt,
                            RecordType = "Old"
                        }).ToList()
                    }).FirstOrDefaultAsync(x => x.STId == id);
            return result;
        }
        public async Task<bool> DeletePurchaseFile(PurchaseViewModel models)
        {   
            var result2 = await _applicationDbContext.PurchaseTable.FirstOrDefaultAsync(x => x.STId == models.STId);
            if (result2 != null)
            {
                _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            return false;
        }
        public async Task<bool> DeletePurchaseOne(int id, int tno)
        {
            var result1 = await _applicationDbContext.PurchaseDetailTable.FirstOrDefaultAsync(x => x.TempSrNo == tno && x.STIMId == id);
            if (result1 != null)
            {
                result1.STIMId = id;
                result1.TempSrNo = tno;              
                _applicationDbContext.Entry(result1).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            var No1 = 1;
            var result2 = await _applicationDbContext.PurchaseDetailTable.OrderBy(x => x.TempSrNo).Where(x => x.STIMId == id).ToListAsync();
            foreach (var item in result2)
            {
                var result = await _applicationDbContext.PurchaseDetailTable.FirstOrDefaultAsync(x => x.STMDId == item.STMDId);
                if (result != null)
                {
                    item.TempSrNo = No1;
                    _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _applicationDbContext.SaveChanges();
                    No1++;
                }
            }
            return false;
        }        
        public async Task<List<PurchaseViewModel>> SearchPurchaseFileDateWise(int CmpId, string UCode, string invno, string name, string mobileno, string address, decimal totalamt, decimal discamt, decimal grandamt, DateTime dt1, DateTime dt2)
        {
            var result = await _applicationDbContext.PurchaseTable
                 .OrderBy(x => x.CompId).ThenBy(x => x.UserCode).ThenBy(x => x.STDate).ThenBy(x => x.STVNo)
                 .Where(x => (CmpId > 0 ? x.CompId == CmpId : true)
                  && (UCode != "0" ? x.UserCode == UCode : true)
                  && x.STDate >= dt1 && x.STDate <= dt2
                  && (invno != null ? x.STVNo.Contains(invno) : true)
                  && (name != null ? x.CustName.Contains(name) : true)
                  && (mobileno != null ? x.LedgerMaster.MobileNo1.Contains(mobileno) : true)
                  && (address != null ? x.LedgerMaster.Address1.Contains(address) : true)
                  && (totalamt > 0 ? x.TotalAmt == totalamt : true)
                  && (discamt > 0 ? x.DiscAmt == discamt : true)
                  && (grandamt > 0 ? x.TotalAmt == grandamt : true)
                  )
                 .Select(x => new PurchaseViewModel()
                 {
                     STId = x.STId,
                     CompId = x.CompId,
                     CompanyDetailViewModel = new CompanyDetailViewModel()
                     {
                         CompName = x.CompanyDetail.CompName,
                         Address1 = x.CompanyDetail.Address1,
                         TransCode = x.CompanyDetail.TransCode
                     },
                     UserCode = x.UserCode,
                     STVNo = x.STVNo,
                     STDate = (x.STDate != null ? Convert.ToDateTime(x.STDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                     OrderNo = x.OrderNo,
                     OrderDate = (x.OrderDate != null ? Convert.ToDateTime(x.OrderDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                     PayMode = (PaymentMode)x.PayMode,
                     AcCode = x.AcCode,
                     LedgerMasterViewModel = new LedgerMasterViewModel()
                     {
                         LedgerMasterId = x.LedgerMaster.LedgerMasterId,
                         PartyName = x.LedgerMaster.PartyName,
                         Address1 = x.LedgerMaster.Address1,
                         GSTNo = x.LedgerMaster.GSTNo
                     },
                     CustName = x.CustName,
                     CustAddress1 = x.CustAddress1,
                     NetAmt = x.NetAmt,
                     DiscAmt = x.DiscAmt,
                     CGSTTotalAmt = x.CGSTTotalAmt,
                     SGSTTotalAmt = x.SGSTTotalAmt,
                     IGSTTotalAmt = x.IGSTTotalAmt,
                     CessTotalAmt = x.CessTotalAmt,
                     OtherAmt1 = x.OtherAmt1,
                     OtherAmt2 = x.OtherAmt2,
                     TotalAmt = x.TotalAmt,
                     CashAmt = x.CashAmt,
                     DigitalAmt = x.DigitalAmt
                 }).ToListAsync();
            return result;
        }
        public async Task<PurchaseDetailViewModel> PurchaseDetailFileLastRecord(int id)
        {
            var result = await _applicationDbContext.PurchaseDetailTable                        
                        .OrderByDescending(a => a.STMDId)
                        .Select(n => new PurchaseDetailViewModel()
                        {
                            TempSrNo = n.TempSrNo,
                            ItemCode = n.ItemCode,
                            STItemName = n.STItemName,
                            BatchNo = n.BatchNo,
                            ExpDate = (n.ExpDate != null ? Convert.ToDateTime(n.ExpDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                            CasePcs = n.CasePcs,
                            OnFreeCase = n.OnFreeCase,
                            UnitCase = n.UnitCase,
                            FreePcs = n.FreePcs,
                            TotalPcs = n.TotalPcs,
                            PurRate = n.PurRate,
                            DiscPer1 = n.DiscPer1,
                            DiscAmt1 = n.DiscAmt1,
                            DiscPer2 = n.DiscPer2,
                            DiscAmt2 = n.DiscAmt2,
                            DiscPer3 = n.DiscPer3,
                            DiscAmt3 = n.DiscAmt3,
                            TotalDiscAmt = n.TotalDiscAmt,
                            GSTPer = n.GSTPer,
                            CGSTAmt = n.CGSTAmt,
                            SGSTAmt = n.SGSTAmt,
                            IGSTAmt = n.IGSTAmt,
                            MRP = n.MRP,
                            SaleRate = n.SaleRate,
                            NetPurRate = n.NetPurRate,
                            PurAmt = n.PurAmt,
                            NetPurAmt = n.NetPurAmt,
                            MRPAmt = n.MRPAmt
                    }).FirstOrDefaultAsync(x => x.ItemCode == id);
            return result;
        }

        // Purchase Return  Item File (Debit Note)
        public async Task<string> PurchaseReturnSrNoCreation(int cmpid)
        {
            var NewNo = ""; var NewValue = 0; CurrentIndex = 0;
            var result = await _applicationDbContext.PurchaseRTable
                          .OrderByDescending(x => x.STId)
                          .Select(x => new { x.STVNo, x.CompId })
                          .FirstOrDefaultAsync(x => x.CompId == cmpid);
            if (result != null)
            {
                string[] parts1 = result.STVNo.Split('D');
                NewValue = Convert.ToInt32(parts1[1]) + 1;
                CurrentIndex = Convert.ToInt32(NewValue.ToString().Length) - 1;
                NewNo = CurrentIndex < 4 ? "D" + myzero[CurrentIndex] + (NewValue) : "D" + NewValue.ToString();
            }
            else
            {
                NewNo = "D00001";
            }
            return NewNo;
        }
        public async Task<int> AddNewPurchaseReturnFile(PurchaseRViewModel models)
        {
            DateTime? Date1 = null;
            userdt = models.STDate.Split('/');
            userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];           
            PurchaseR opnitemMaster = new PurchaseR()
            {
                UserCode = models.UserCode,
                CompId = models.CompId,
                STVNo = models.STVNo,
                STDate = string.IsNullOrEmpty(models.STDate) ? Date1 : Convert.ToDateTime(userdt1),
                AcCode = models.AcCode,
                CustName = models.CustName,
                CustAddress1 = models.CustAddress1,
                CustLedStateId = models.CustLedStateId,
                NetAmt = models.NetAmt,
                DiscAmt = models.DiscAmt,
                CGSTTotalAmt = models.CGSTTotalAmt,
                SGSTTotalAmt = models.SGSTTotalAmt,
                IGSTTotalAmt = models.IGSTTotalAmt,
                CessTotalAmt = models.CessTotalAmt,
                OtherAmt1 = models.OtherAmt1,
                OtherAmt2 = models.OtherAmt2,
                TotalAmt = models.TotalAmt,
                CashAmt = models.CashAmt,
                DigitalAmt = models.DigitalAmt
            };
            _applicationDbContext.Entry(opnitemMaster).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            foreach (var item in models.PurchaseRDetailViewModels)
            {
                Date1 = null; userdt = item.ExpDate.Split('/');
                userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
                PurchaseRDetail order = new PurchaseRDetail()
                {
                    STMDId = item.STMDId,
                    ItemCode = item.ItemCode,
                    STItemName = item.STItemName,
                    BatchNo = item.BatchNo,
                    ExpDate = string.IsNullOrEmpty(item.ExpDate) ? Date1 : Convert.ToDateTime(userdt1),
                    CasePcs = item.CasePcs,
                    OnFreeCase = item.OnFreeCase,
                    UnitCase = item.UnitCase,
                    FreePcs = item.FreePcs,
                    TotalPcs = item.TotalPcs,
                    PurRate = item.PurRate,
                    DiscPer1 = item.DiscPer1,
                    DiscAmt1 = item.DiscAmt1,
                    DiscPer2 = item.DiscPer2,
                    DiscAmt2 = item.DiscAmt2,
                    DiscPer3 = item.DiscPer3,
                    DiscAmt3 = item.DiscAmt3,
                    TotalDiscAmt = item.TotalDiscAmt,
                    GSTPer = item.GSTPer,
                    CGSTAmt = item.CGSTAmt,
                    SGSTAmt = item.SGSTAmt,
                    IGSTAmt = item.IGSTAmt,
                    MRP = item.MRP,
                    SaleRate = item.SaleRate,
                    NetPurRate = item.NetPurRate,
                    PurAmt = item.PurAmt,
                    NetPurAmt = item.NetPurAmt,
                    MRPAmt = item.MRPAmt,
                    TempSrNo = (int)item.TempSrNo,
                    CompIdSTItemMD = models.CompId,
                    UserCodeSTItemMD = models.UserCode,
                    STVNoD = models.STVNo,
                    STIMId = opnitemMaster.STId
                };
                _applicationDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            await _applicationDbContext.SaveChangesAsync();
            return opnitemMaster.STId;
        }
        public async Task<bool> UpdatePurchaseReturnFile(PurchaseRViewModel models)
        {
            DateTime? Date1 = null;
            userdt = models.STDate.Split('/');
            userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            var result = await _applicationDbContext.PurchaseRTable.FirstOrDefaultAsync(n => n.STId == models.STId);
            if (result != null)
            {
                result.UserCode = result.UserCode;
                result.CompId = result.CompId;
                result.STVNo = models.STVNo;
                result.STDate = string.IsNullOrEmpty(models.STDate) ? Date1 : Convert.ToDateTime(userdt1);
                result.AcCode = models.AcCode;
                result.CustName = models.CustName;
                result.CustAddress1 = models.CustAddress1;
                result.CustLedStateId = models.CustLedStateId;
                result.NetAmt = models.NetAmt;
                result.DiscAmt = models.DiscAmt;
                result.CGSTTotalAmt = models.CGSTTotalAmt;
                result.SGSTTotalAmt = models.SGSTTotalAmt;
                result.IGSTTotalAmt = models.IGSTTotalAmt;
                result.CessTotalAmt = models.CessTotalAmt;
                result.OtherAmt1 = models.OtherAmt1;
                result.OtherAmt2 = models.OtherAmt2;
                result.TotalAmt = models.TotalAmt;
                result.CashAmt = models.CashAmt;
                result.DigitalAmt = models.DigitalAmt;
            };
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();

            foreach (var item in models.PurchaseRDetailViewModels)
            {
                Date1 = null; userdt = item.ExpDate.Split('/');
                userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
                var result1 = await _applicationDbContext.PurchaseRDetailTable.FirstOrDefaultAsync(x => x.TempSrNo == item.TempSrNo && x.STIMId == models.STId);
                if (result1 != null)
                {
                    result1.ItemCode = item.ItemCode;
                    result1.STItemName = item.STItemName;
                    result1.BatchNo = item.BatchNo;
                    result1.ExpDate = string.IsNullOrEmpty(item.ExpDate) ? Date1 : Convert.ToDateTime(userdt1);
                    result1.CasePcs = item.CasePcs;
                    result1.OnFreeCase = item.OnFreeCase;
                    result1.UnitCase = item.UnitCase;
                    result1.FreePcs = item.FreePcs;
                    result1.TotalPcs = item.TotalPcs;
                    result1.PurRate = item.PurRate;
                    result1.DiscPer1 = item.DiscPer1;
                    result1.DiscAmt1 = item.DiscAmt1;
                    result1.DiscPer2 = item.DiscPer2;
                    result1.DiscAmt2 = item.DiscAmt2;
                    result1.DiscPer3 = item.DiscPer3;
                    result1.DiscAmt3 = item.DiscAmt3;
                    result1.TotalDiscAmt = item.TotalDiscAmt;
                    result1.GSTPer = item.GSTPer;
                    result1.CGSTAmt = item.CGSTAmt;
                    result1.SGSTAmt = item.SGSTAmt;
                    result1.IGSTAmt = item.IGSTAmt;
                    result1.MRP = item.MRP;
                    result1.SaleRate = item.SaleRate;
                    result1.NetPurRate = item.NetPurRate;
                    result1.PurAmt = item.PurAmt;
                    result1.NetPurAmt = item.NetPurAmt;
                    result1.MRPAmt = item.MRPAmt;
                    result1.CompIdSTItemMD = result.CompId;
                    result1.UserCodeSTItemMD = result.UserCode;
                    result1.STVNoD = result.STVNo;
                    result1.STIMId = result.STId;
                    _applicationDbContext.Entry(result1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                else
                {
                    PurchaseRDetail order = new PurchaseRDetail()
                    {
                        ItemCode = item.ItemCode,
                        STItemName = item.STItemName,
                        BatchNo = item.BatchNo,
                        ExpDate = string.IsNullOrEmpty(item.ExpDate) ? Date1 : Convert.ToDateTime(userdt1),
                        CasePcs = item.CasePcs,
                        OnFreeCase = item.OnFreeCase,
                        UnitCase = item.UnitCase,
                        FreePcs = item.FreePcs,
                        TotalPcs = item.TotalPcs,
                        PurRate = item.PurRate,
                        DiscPer1 = item.DiscPer1,
                        DiscAmt1 = item.DiscAmt1,
                        DiscPer2 = item.DiscPer2,
                        DiscAmt2 = item.DiscAmt2,
                        DiscPer3 = item.DiscPer3,
                        DiscAmt3 = item.DiscAmt3,
                        TotalDiscAmt = item.TotalDiscAmt,
                        GSTPer = item.GSTPer,
                        CGSTAmt = item.CGSTAmt,
                        SGSTAmt = item.SGSTAmt,
                        IGSTAmt = item.IGSTAmt,
                        MRP = item.MRP,
                        SaleRate = item.SaleRate,
                        NetPurRate = item.NetPurRate,
                        PurAmt = item.PurAmt,
                        NetPurAmt = item.NetPurAmt,
                        MRPAmt = item.MRPAmt,
                        TempSrNo = (int)item.TempSrNo,
                        CompIdSTItemMD = result.CompId,
                        UserCodeSTItemMD = result.UserCode,
                        STVNoD = models.STVNo,
                        STIMId = result.STId
                    };
                    _applicationDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                }
            }
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<PurchaseRViewModel> GetPurchaseReturnFileById(int id)
        {
            var result = await _applicationDbContext.PurchaseRTable
                    .Select(x => new PurchaseRViewModel()
                    {
                        STId = x.STId,
                        CompId = x.CompId,
                        UserCode = x.UserCode,
                        STVNo = x.STVNo,
                        STDate = (x.STDate != null ? Convert.ToDateTime(x.STDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                        AcCode = x.AcCode,
                        LedgerMasterViewModel = new LedgerMasterViewModel()
                        {
                            LedgerMasterId = x.LedgerMaster.LedgerMasterId,
                            PartyName = x.LedgerMaster.PartyName,
                            Address1 = x.LedgerMaster.Address1,
                            MobileNo1 = x.LedgerMaster.MobileNo1,
                            GSTNo = x.LedgerMaster.GSTNo,
                            StateLedgerMasterView = new StateViewModel()
                            {
                                StateId = x.LedgerMaster.StateLedger.StateId,
                                StateName = x.LedgerMaster.StateLedger.StateName,                                
                            }
                        },
                        CustName = x.CustName,
                        CustAddress1 = x.CustAddress1,
                        CustLedStateId = x.CustLedStateId,
                        NetAmt = x.NetAmt,
                        DiscAmt = x.DiscAmt,
                        CGSTTotalAmt = x.CGSTTotalAmt,
                        SGSTTotalAmt = x.SGSTTotalAmt,
                        IGSTTotalAmt = x.IGSTTotalAmt,
                        CessTotalAmt = x.CessTotalAmt,
                        OtherAmt1 = x.OtherAmt1,
                        OtherAmt2 = x.OtherAmt2,
                        TotalAmt = x.TotalAmt,
                        CashAmt = x.CashAmt,
                        DigitalAmt = x.DigitalAmt,
                        PurchaseRDetailViewModels = x.PurchaseRDetails.Where(a => a.STIMId == x.STId)
                        .OrderBy(a => a.TempSrNo)
                        .Select(n => new PurchaseRDetailViewModel()
                        {
                            TempSrNo = n.TempSrNo,
                            ItemCode = n.ItemCode,
                            STItemName = n.STItemName,
                            BatchNo = n.BatchNo,
                            ExpDate = (n.ExpDate != null ? Convert.ToDateTime(n.ExpDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                            CasePcs = n.CasePcs,
                            OnFreeCase = n.OnFreeCase,
                            UnitCase = n.UnitCase,
                            FreePcs = n.FreePcs,
                            TotalPcs = n.TotalPcs,
                            PurRate = n.PurRate,
                            DiscPer1 = n.DiscPer1,
                            DiscAmt1 = n.DiscAmt1,
                            DiscPer2 = n.DiscPer2,
                            DiscAmt2 = n.DiscAmt2,
                            DiscPer3 = n.DiscPer3,
                            DiscAmt3 = n.DiscAmt3,
                            TotalDiscAmt = n.TotalDiscAmt,
                            GSTPer = n.GSTPer,
                            CGSTAmt = n.CGSTAmt,
                            SGSTAmt = n.SGSTAmt,
                            IGSTAmt = n.IGSTAmt,
                            MRP = n.MRP,
                            SaleRate = n.SaleRate,
                            NetPurRate = n.NetPurRate,
                            PurAmt = n.PurAmt,
                            NetPurAmt = n.NetPurAmt,
                            MRPAmt = n.MRPAmt,
                            RecordType = "Old"
                        }).ToList()
                    }).FirstOrDefaultAsync(x => x.STId == id);
            return result;
        }
        public async Task<bool> DeletePurchaseReturnFile(PurchaseRViewModel models)
        {
            var result2 = await _applicationDbContext.PurchaseRTable.FirstOrDefaultAsync(x => x.STId == models.STId);
            if (result2 != null)
            {
                _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            return false;
        }
        public async Task<bool> DeletePurchaseReturnOne(int id, int tno)
        {
            var result1 = await _applicationDbContext.PurchaseRDetailTable.FirstOrDefaultAsync(x => x.TempSrNo == tno && x.STIMId == id);
            if (result1 != null)
            {
                result1.STIMId = id;
                result1.TempSrNo = tno;
                _applicationDbContext.Entry(result1).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            var No1 = 1;
            var result2 = await _applicationDbContext.PurchaseRDetailTable.OrderBy(x => x.TempSrNo).Where(x => x.STIMId == id).ToListAsync();
            foreach (var item in result2)
            {
                var result = await _applicationDbContext.PurchaseRDetailTable.FirstOrDefaultAsync(x => x.STMDId == item.STMDId);
                if (result != null)
                {
                    item.TempSrNo = No1;
                    _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _applicationDbContext.SaveChanges();
                    No1++;
                }
            }
            return false;
        }
        public async Task<List<PurchaseRViewModel>> SearchPurchaseReturnFileDateWise(int CmpId, string UCode, string invno, string name, string mobileno, string address, decimal totalamt, decimal discamt, decimal grandamt, DateTime dt1, DateTime dt2)
        {
            var result = await _applicationDbContext.PurchaseRTable
                 .OrderBy(x => x.CompId).ThenBy(x => x.UserCode).ThenBy(x => x.STDate).ThenBy(x => x.STVNo)
                 .Where(x => (CmpId > 0 ? x.CompId == CmpId : true)
                  && (UCode != "0" ? x.UserCode == UCode : true)
                  && x.STDate >= dt1 && x.STDate <= dt2
                  && (invno != null ? x.STVNo.Contains(invno) : true)
                  && (name != null ? x.CustName.Contains(name) : true)
                  && (mobileno != null ? x.LedgerMaster.MobileNo1.Contains(mobileno) : true)
                  && (address != null ? x.LedgerMaster.Address1.Contains(address) : true)
                  && (totalamt > 0 ? x.TotalAmt == totalamt : true)
                  && (discamt > 0 ? x.DiscAmt == discamt : true)
                  && (grandamt > 0 ? x.TotalAmt == grandamt : true)
                  )
                 .Select(x => new PurchaseRViewModel()
                 {
                     STId = x.STId,
                     CompId = x.CompId,
                     CompanyDetailViewModel = new CompanyDetailViewModel()
                     {
                         CompName = x.CompanyDetail.CompName,
                         Address1 = x.CompanyDetail.Address1,
                         TransCode = x.CompanyDetail.TransCode
                     },
                     UserCode = x.UserCode,
                     STVNo = x.STVNo,
                     STDate = (x.STDate != null ? Convert.ToDateTime(x.STDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                     AcCode = x.AcCode,
                     LedgerMasterViewModel = new LedgerMasterViewModel()
                     {
                         LedgerMasterId = x.LedgerMaster.LedgerMasterId,
                         PartyName = x.LedgerMaster.PartyName,
                         Address1 = x.LedgerMaster.Address1,
                         MobileNo1 = x.LedgerMaster.MobileNo1,
                         GSTNo = x.LedgerMaster.GSTNo
                     },
                     CustName = x.CustName,
                     CustAddress1 = x.CustAddress1,
                     NetAmt = x.NetAmt,
                     DiscAmt = x.DiscAmt,
                     CGSTTotalAmt = x.CGSTTotalAmt,
                     SGSTTotalAmt = x.SGSTTotalAmt,
                     IGSTTotalAmt = x.IGSTTotalAmt,
                     CessTotalAmt = x.CessTotalAmt,
                     OtherAmt1 = x.OtherAmt1,
                     OtherAmt2 = x.OtherAmt2,
                     TotalAmt = x.TotalAmt,
                     CashAmt = x.CashAmt,
                     DigitalAmt = x.DigitalAmt
                 }).ToListAsync();
            return result;
        }

        // Sale File 
        public async Task<string> SaleSrNoCreation(int cmpid)
        {
            var NewNo = ""; var NewValue = 0; CurrentIndex = 0;
            var result = await _applicationDbContext.SaleTable
                          .OrderByDescending(x => x.SSId)
                          .Select(x => new { x.SSVNo, x.CompId })
                          .FirstOrDefaultAsync(x => x.CompId == cmpid);
            if (result != null)
            {
                string[] parts1 = result.SSVNo.Split('S');
                NewValue = Convert.ToInt32(parts1[1]) + 1;
                CurrentIndex = Convert.ToInt32(NewValue.ToString().Length) - 1;
                NewNo = CurrentIndex < 4 ? "S" + myzero[CurrentIndex] + (NewValue) : "S" + NewValue.ToString();
            }
            else
            {
                NewNo = "S00001";
            }
            return NewNo;
        }
        public async Task<int> AddNewSaleFile(SaleViewModel models)
        {
            DateTime? Date1 = null;
            userdt = models.SDate.Split('/');
            userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            Sale opnitemMaster = new Sale()
            {
                UserCode = models.UserCode,
                CompId = models.CompId,
                SSVNo = models.SSVNo,
                SDate = string.IsNullOrEmpty(models.SDate) ? Date1 : Convert.ToDateTime(userdt1),
                PayMode = (int)models.PayMode,
                CustName = models.CustName,
                CustAddress1 = models.CustAddress1,
                Remark = models.Remark,
                NetAmt = models.NetAmt,
                DiscAmt = models.DiscAmt,
                TaxAmt = models.TaxAmt,
                CreditAmt = models.CreditAmt,                
                TotalAmt = models.TotalAmt,
                PaidAmt = models.PaidAmt
            };
            _applicationDbContext.Entry(opnitemMaster).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            foreach (var item in models.SaleDetailViewModels)
            {
                Date1 = null; userdt = item.ExpDate.Split('/');
                userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
                SaleDetail order = new SaleDetail()
                {
                    SSMDId = item.SSMDId,
                    ItemCode = item.ItemCode,
                    SSItemName = item.SSItemName,
                    BatchNo = item.BatchNo,
                    ExpDate = string.IsNullOrEmpty(item.ExpDate) ? Date1 : Convert.ToDateTime(userdt1),
                    Qty = item.Qty,                                       
                    DiscPer1 = item.DiscPer1,                    
                    TotalDiscAmt = item.TotalDiscAmt,
                    CustSaleRate = item.CustSaleRate,
                    GSTPer = item.GSTPer,
                    TotalAmt = item.TotalAmt,
                    NetTotalAmt = item.NetTotalAmt,
                    PurRate = item.PurRate,
                    MRP = item.MRP,
                    SaleRate = item.SaleRate,
                    NetPurRate = item.NetPurRate,
                    TempSrNo = (int)item.TempSrNo,
                    CompIdSSItemMD =(int) models.CompId,
                    UserCodeSSItemMD = models.UserCode,
                    SSVNoD = models.SSVNo,
                    SSIMId = opnitemMaster.SSId
                };
                _applicationDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            await _applicationDbContext.SaveChangesAsync();
            return opnitemMaster.SSId;
        }
        public async Task<bool> UpdateSaleFile(SaleViewModel models)
        {
            DateTime? Date1 = null;
            userdt = models.SDate.Split('/');
            userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            var result = await _applicationDbContext.SaleTable.FirstOrDefaultAsync(n => n.SSId == models.SSId);
            if (result != null)
            {
                result.UserCode = result.UserCode;
                result.CompId = result.CompId;
                result.SSVNo = result.SSVNo;
                result.SDate = string.IsNullOrEmpty(models.SDate) ? Date1 : Convert.ToDateTime(userdt1);
                result.PayMode = (int)models.PayMode;
                result.CustName = models.CustName;
                result.CustAddress1 = models.CustAddress1;
                result.Remark = models.Remark;
                result.NetAmt = models.NetAmt;
                result.DiscAmt = models.DiscAmt;
                result.TaxAmt = models.TaxAmt;
                result.CreditAmt = models.CreditAmt;
                result.TotalAmt = models.TotalAmt;
                result.PaidAmt = models.PaidAmt;
            };
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();

            foreach (var item in models.SaleDetailViewModels)
            {
                Date1 = null; userdt = item.ExpDate.Split('/');
                userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
                var result1 = await _applicationDbContext.SaleDetailTable.FirstOrDefaultAsync(x => x.TempSrNo == item.TempSrNo && x.SSIMId == models.SSId);
                if (result1 != null)
                {
                    //result1.SSMDId = item.SSMDId;
                    result1.ItemCode = item.ItemCode;
                    result1.SSItemName = item.SSItemName;
                    result1.BatchNo = item.BatchNo;
                    result1.ExpDate = string.IsNullOrEmpty(item.ExpDate) ? Date1 : Convert.ToDateTime(userdt1);
                    result1.Qty = item.Qty;
                    result1.DiscPer1 = item.DiscPer1;
                    result1.TotalDiscAmt = item.TotalDiscAmt;
                    result1.CustSaleRate = item.CustSaleRate;
                    result1.GSTPer = item.GSTPer;
                    result1.TotalAmt = item.TotalAmt;
                    result1.NetTotalAmt = item.NetTotalAmt;
                    result1.PurRate = item.PurRate;
                    result1.MRP = item.MRP;
                    result1.SaleRate = item.SaleRate;
                    result1.NetPurRate = item.NetPurRate;
                    //result1.TempSrNo = (int)item.TempSrNo;
                    //result1.CompIdSSItemMD = (int)result.CompId;
                    //result1.UserCodeSSItemMD = result.UserCode;
                    //result1.SSVNoD = models.SSVNo;
                    //result1.SSIMId = result.SSId;
                    _applicationDbContext.Entry(result1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                else
                {
                    SaleDetail order = new SaleDetail()
                    {
                        SSMDId = item.SSMDId,
                        ItemCode = item.ItemCode,
                        SSItemName = item.SSItemName,
                        BatchNo = item.BatchNo,
                        ExpDate = string.IsNullOrEmpty(item.ExpDate) ? Date1 : Convert.ToDateTime(userdt1),
                        Qty = item.Qty,
                        DiscPer1 = item.DiscPer1,
                        TotalDiscAmt = item.TotalDiscAmt,
                        CustSaleRate = item.CustSaleRate,
                        GSTPer = item.GSTPer,
                        TotalAmt = item.TotalAmt,
                        NetTotalAmt = item.NetTotalAmt,
                        PurRate = item.PurRate,
                        MRP = item.MRP,
                        SaleRate = item.SaleRate,
                        NetPurRate = item.NetPurRate,
                        TempSrNo = (int)item.TempSrNo,
                        CompIdSSItemMD = (int)result.CompId,
                        UserCodeSSItemMD = result.UserCode,
                        SSVNoD = models.SSVNo,
                        SSIMId = result.SSId
                    };
                    _applicationDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                }
            }
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<SaleViewModel> GetSaleFileById(int id)
        {
            var result = await _applicationDbContext.SaleTable
                    .Select(x => new SaleViewModel()
                    {
                        SSId = x.SSId,
                        CompId = x.CompId,
                        UserCode = x.UserCode,
                        SSVNo = x.SSVNo,
                        SDate = (x.SDate != null ? Convert.ToDateTime(x.SDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                        PayMode = (PaymentMode)x.PayMode,
                        CustName = x.CustName,
                        CustAddress1 = x.CustAddress1,
                        Remark = x.Remark,
                        NetAmt = x.NetAmt,
                        DiscAmt = x.DiscAmt,
                        TaxAmt = x.TaxAmt,
                        CreditAmt = x.CreditAmt,
                        TotalAmt = x.TotalAmt,
                        PaidAmt = x.PaidAmt,
                        SaleDetailViewModels = x.SaleDetails.Where(a => a.SSIMId == x.SSId)
                        .OrderBy(a => a.TempSrNo)
                        .Select(n => new SaleDetailViewModel()
                        {
                            TempSrNo = n.TempSrNo,
                            ItemCode = n.ItemCode,
                            SSItemName = n.SSItemName,
                            BatchNo = n.BatchNo,
                            ExpDate = (n.ExpDate != null ? Convert.ToDateTime(n.ExpDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                            Qty = n.Qty,
                            DiscPer1 = n.DiscPer1,
                            TotalDiscAmt = n.TotalDiscAmt,
                            CustSaleRate = n.CustSaleRate,
                            GSTPer = n.GSTPer,
                            TotalAmt = n.TotalAmt,
                            NetTotalAmt = n.NetTotalAmt,
                            PurRate = n.PurRate,
                            MRP = n.MRP,
                            SaleRate = n.SaleRate,
                            NetPurRate = n.NetPurRate,
                            RecordType = "Old"
                        }).ToList()
                    }).FirstOrDefaultAsync(x => x.SSId == id);
            return result;
        }
        public async Task<bool> DeleteSaleFile(SaleViewModel models)
        {
            var result2 = await _applicationDbContext.SaleTable.FirstOrDefaultAsync(x => x.SSId == models.SSId);
            if (result2 != null)
            {
                _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            return false;
        }
        public async Task<bool> DeleteSaleFileOne(int id, int tno)
        {
            var result1 = await _applicationDbContext.SaleDetailTable.FirstOrDefaultAsync(x => x.TempSrNo == tno && x.SSIMId == id);
            if (result1 != null)
            {
                result1.SSIMId = id;
                result1.TempSrNo = tno;
                _applicationDbContext.Entry(result1).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            var No1 = 1;
            var result2 = await _applicationDbContext.SaleDetailTable.OrderBy(x => x.TempSrNo).Where(x => x.SSIMId == id).ToListAsync();
            foreach (var item in result2)
            {
                var result = await _applicationDbContext.SaleDetailTable.FirstOrDefaultAsync(x => x.SSMDId == item.SSMDId);
                if (result != null)
                {
                    item.TempSrNo = No1;
                    _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _applicationDbContext.SaveChanges();
                    No1++;
                }
            }
            return false;
        }
        public async Task<List<SaleViewModel>> SearchSaleFileDateWise(int CmpId, string UCode, string invno, string name, string address, decimal totalamt, decimal discamt, decimal grandamt, decimal paidamt, DateTime dt1, DateTime dt2)
        {
            var result = await _applicationDbContext.SaleTable
                 .OrderBy(x => x.CompId).ThenBy(x => x.UserCode).ThenBy(x => x.SDate).ThenBy(x => x.SSVNo)
                 .Where(x => (CmpId > 0 ? x.CompId == CmpId : true)
                  && (UCode != "0" ? x.UserCode == UCode : true)
                  && x.SDate >= dt1 && x.SDate <= dt2
                  && (invno != null ? x.SSVNo.Contains(invno) : true)
                  && (name != null ? x.CustName.Contains(name) : true)                  
                  && (address != null ? x.CustAddress1.Contains(address) : true)
                  && (totalamt > 0 ? x.TotalAmt == totalamt : true)
                  && (discamt > 0 ? x.DiscAmt == discamt : true)
                  && (grandamt > 0 ? x.TotalAmt == grandamt : true)
                  )
                 .Select(x => new SaleViewModel()
                 {
                     SSId = x.SSId,
                     CompId = x.CompId,
                     CompanyDetailViewModel = new CompanyDetailViewModel()
                     {
                         CompName = x.CompanyDetail.CompName,
                         Address1 = x.CompanyDetail.Address1,
                         TransCode = x.CompanyDetail.TransCode
                     },
                     UserCode = x.UserCode,
                     SSVNo = x.SSVNo,
                     SDate = (x.SDate != null ? Convert.ToDateTime(x.SDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                     PayMode = (PaymentMode)x.PayMode,
                     CustName = x.CustName,
                     CustAddress1 = x.CustAddress1,
                     Remark = x.Remark,
                     NetAmt = x.NetAmt,
                     DiscAmt = x.DiscAmt,
                     TaxAmt = x.TaxAmt,
                     CreditAmt = x.CreditAmt,
                     TotalAmt = x.TotalAmt,
                     PaidAmt = x.PaidAmt,
                 }).ToListAsync();
            return result;
        }

        // Sale Return File  (Credit Notes)
        public async Task<string> SaleReturnSrNoCreation(int cmpid)
        {
            var NewNo = ""; var NewValue = 0; CurrentIndex = 0;
            var result = await _applicationDbContext.SaleRTable
                          .OrderByDescending(x => x.SRId)
                          .Select(x => new { x.SRVNo, x.CompId })
                          .FirstOrDefaultAsync(x => x.CompId == cmpid);
            if (result != null)
            {
                string[] parts1 = result.SRVNo.Split('C');
                NewValue = Convert.ToInt32(parts1[1]) + 1;
                CurrentIndex = Convert.ToInt32(NewValue.ToString().Length) - 1;
                NewNo = CurrentIndex < 4 ? "C" + myzero[CurrentIndex] + (NewValue) : "C" + NewValue.ToString();
            }
            else
            {
                NewNo = "C00001";
            }
            return NewNo;
        }
        public async Task<int> AddNewSaleReturnFile(SaleRViewModel models)
        {
            DateTime? Date1 = null;
            userdt = models.SDate.Split('/');
            userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            SaleR opnitemMaster = new SaleR()
            {
                UserCode = models.UserCode,
                CompId = models.CompId,
                SRVNo = models.SRVNo,
                SDate = string.IsNullOrEmpty(models.SDate) ? Date1 : Convert.ToDateTime(userdt1),               
                CustName = models.CustName,
                CustAddress1 = models.CustAddress1,
                Remark = models.Remark,
                NetAmt = models.NetAmt,
                DiscAmt = models.DiscAmt,
                TaxAmt = models.TaxAmt,
                TotalAmt = models.TotalAmt
            };
            _applicationDbContext.Entry(opnitemMaster).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            foreach (var item in models.SaleRDetailViewModels)
            {
                Date1 = null; userdt = item.ExpDate.Split('/');
                userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
                SaleRDetail order = new SaleRDetail()
                {
                    SRMDId = item.SRMDId,
                    ItemCode = item.ItemCode,
                    SRItemName = item.SRItemName,
                    BatchNo = item.BatchNo,
                    ExpDate = string.IsNullOrEmpty(item.ExpDate) ? Date1 : Convert.ToDateTime(userdt1),
                    Qty = item.Qty,
                    DiscPer1 = item.DiscPer1,
                    TotalDiscAmt = item.TotalDiscAmt,
                    CustSaleRate = item.CustSaleRate,
                    GSTPer = item.GSTPer,
                    TotalAmt = item.TotalAmt,
                    NetTotalAmt = item.NetTotalAmt,
                    PurRate = item.PurRate,
                    MRP = item.MRP,
                    SaleRate = item.SaleRate,
                    NetPurRate = item.NetPurRate,
                    TempSrNo = (int)item.TempSrNo,
                    CompIdSRItemMD = (int)models.CompId,
                    UserCodeSRItemMD = models.UserCode,
                    SRVNoD = models.SRVNo,
                    SRIMId = opnitemMaster.SRId
                };
                _applicationDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            await _applicationDbContext.SaveChangesAsync();
            return opnitemMaster.SRId;
        }
        public async Task<bool> UpdateSaleReturnFile(SaleRViewModel models)
        {
            DateTime? Date1 = null;
            userdt = models.SDate.Split('/');
            userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            var result = await _applicationDbContext.SaleRTable.FirstOrDefaultAsync(n => n.SRId == models.SRId);
            if (result != null)
            {
                result.UserCode = result.UserCode;
                result.CompId = result.CompId;
                result.SRVNo = result.SRVNo;
                result.SDate = string.IsNullOrEmpty(models.SDate) ? Date1 : Convert.ToDateTime(userdt1);
                result.CustName = models.CustName;
                result.CustAddress1 = models.CustAddress1;
                result.Remark = models.Remark;
                result.NetAmt = models.NetAmt;
                result.DiscAmt = models.DiscAmt;
                result.TaxAmt = models.TaxAmt;
                result.TotalAmt = models.TotalAmt;
            };
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();

            foreach (var item in models.SaleRDetailViewModels)
            {
                Date1 = null; userdt = item.ExpDate.Split('/');
                userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
                var result1 = await _applicationDbContext.SaleRDetailTable.FirstOrDefaultAsync(x => x.TempSrNo == item.TempSrNo && x.SRIMId == models.SRId);
                if (result1 != null)
                {
                    //result1.SSMDId = item.SSMDId;
                    result1.ItemCode = item.ItemCode;
                    result1.SRItemName = item.SRItemName;
                    result1.BatchNo = item.BatchNo;
                    result1.ExpDate = string.IsNullOrEmpty(item.ExpDate) ? Date1 : Convert.ToDateTime(userdt1);
                    result1.Qty = item.Qty;
                    result1.DiscPer1 = item.DiscPer1;
                    result1.TotalDiscAmt = item.TotalDiscAmt;
                    result1.CustSaleRate = item.CustSaleRate;
                    result1.GSTPer = item.GSTPer;
                    result1.TotalAmt = item.TotalAmt;
                    result1.NetTotalAmt = item.NetTotalAmt;
                    result1.PurRate = item.PurRate;
                    result1.MRP = item.MRP;
                    result1.SaleRate = item.SaleRate;
                    result1.NetPurRate = item.NetPurRate;
                    //result1.TempSrNo = (int)item.TempSrNo;
                    //result1.CompIdSSItemMD = (int)result.CompId;
                    //result1.UserCodeSSItemMD = result.UserCode;
                    //result1.SSVNoD = models.SSVNo;
                    //result1.SSIMId = result.SSId;
                    _applicationDbContext.Entry(result1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                else
                {
                    SaleRDetail order = new SaleRDetail()
                    {
                        SRMDId = item.SRMDId,
                        ItemCode = item.ItemCode,
                        SRItemName = item.SRItemName,
                        BatchNo = item.BatchNo,
                        ExpDate = string.IsNullOrEmpty(item.ExpDate) ? Date1 : Convert.ToDateTime(userdt1),
                        Qty = item.Qty,
                        DiscPer1 = item.DiscPer1,
                        TotalDiscAmt = item.TotalDiscAmt,
                        CustSaleRate = item.CustSaleRate,
                        GSTPer = item.GSTPer,
                        TotalAmt = item.TotalAmt,
                        NetTotalAmt = item.NetTotalAmt,
                        PurRate = item.PurRate,
                        MRP = item.MRP,
                        SaleRate = item.SaleRate,
                        NetPurRate = item.NetPurRate,
                        TempSrNo = (int)item.TempSrNo,
                        CompIdSRItemMD = (int)result.CompId,
                        UserCodeSRItemMD = result.UserCode,
                        SRVNoD = models.SRVNo,
                        SRIMId = result.SRId
                    };
                    _applicationDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                }
            }
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<SaleRViewModel> GetSaleReturnFileById(int id)
        {
            var result = await _applicationDbContext.SaleRTable
                    .Select(x => new SaleRViewModel()
                    {
                        SRId = x.SRId,
                        CompId = x.CompId,
                        UserCode = x.UserCode,
                        SRVNo = x.SRVNo,
                        SDate = (x.SDate != null ? Convert.ToDateTime(x.SDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                        CustName = x.CustName,
                        CustAddress1 = x.CustAddress1,
                        Remark = x.Remark,
                        NetAmt = x.NetAmt,
                        DiscAmt = x.DiscAmt,
                        TaxAmt = x.TaxAmt,
                        TotalAmt = x.TotalAmt,
                        SaleRDetailViewModels = x.SaleRDetails.Where(a => a.SRIMId == x.SRId)
                        .OrderBy(a => a.TempSrNo)
                        .Select(n => new SaleRDetailViewModel()
                        {
                            TempSrNo = n.TempSrNo,
                            ItemCode = n.ItemCode,
                            SRItemName = n.SRItemName,
                            BatchNo = n.BatchNo,
                            ExpDate = (n.ExpDate != null ? Convert.ToDateTime(n.ExpDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                            Qty = n.Qty,
                            DiscPer1 = n.DiscPer1,
                            TotalDiscAmt = n.TotalDiscAmt,
                            CustSaleRate = n.CustSaleRate,
                            GSTPer = n.GSTPer,
                            TotalAmt = n.TotalAmt,
                            NetTotalAmt = n.NetTotalAmt,
                            PurRate = n.PurRate,
                            MRP = n.MRP,
                            SaleRate = n.SaleRate,
                            NetPurRate = n.NetPurRate,
                            RecordType ="Old"
                        }).ToList()
                    }).FirstOrDefaultAsync(x => x.SRId == id);
            return result;
        }
        public async Task<bool> DeleteSaleReturnFile(SaleRViewModel models)
        {
            var result2 = await _applicationDbContext.SaleRTable.FirstOrDefaultAsync(x => x.SRId == models.SRId);
            if (result2 != null)
            {
                _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            return false;
        }
        public async Task<bool> DeleteSaleReturnFileOne(int id, int tno)
        {
            var result1 = await _applicationDbContext.SaleRDetailTable.FirstOrDefaultAsync(x => x.TempSrNo == tno && x.SRIMId == id);
            if (result1 != null)
            {
                result1.SRIMId = id;
                result1.TempSrNo = tno;
                _applicationDbContext.Entry(result1).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            var No1 = 1;
            var result2 = await _applicationDbContext.SaleRDetailTable.OrderBy(x => x.TempSrNo).Where(x => x.SRIMId == id).ToListAsync();
            foreach (var item in result2)
            {
                var result = await _applicationDbContext.SaleRDetailTable.FirstOrDefaultAsync(x => x.SRMDId == item.SRMDId);
                if (result != null)
                {
                    item.TempSrNo = No1;
                    _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _applicationDbContext.SaveChanges();
                    No1++;
                }
            }
            return false;
        }
        public async Task<List<SaleRViewModel>> SearchSaleReturnFileDateWise(int CmpId, string UCode, string invno, string name, string address, decimal totalamt, decimal discamt, decimal grandamt, DateTime dt1, DateTime dt2)
        {
            var result = await _applicationDbContext.SaleRTable
                 .OrderBy(x => x.CompId).ThenBy(x => x.UserCode).ThenBy(x => x.SDate).ThenBy(x => x.SRVNo)
                 .Where(x => (CmpId > 0 ? x.CompId == CmpId : true)
                  && (UCode != "0" ? x.UserCode == UCode : true)
                  && x.SDate >= dt1 && x.SDate <= dt2
                  && (invno != null ? x.SRVNo.Contains(invno) : true)
                  && (name != null ? x.CustName.Contains(name) : true)
                  && (address != null ? x.CustAddress1.Contains(address) : true)
                  && (totalamt > 0 ? x.TotalAmt == totalamt : true)
                  && (discamt > 0 ? x.DiscAmt == discamt : true)
                  && (grandamt > 0 ? x.TotalAmt == grandamt : true)
                  )
                 .Select(x => new SaleRViewModel()
                 {
                     SRId = x.SRId,
                     CompId = x.CompId,
                     CompanyDetailViewModel = new CompanyDetailViewModel()
                     {
                         CompName = x.CompanyDetail.CompName,
                         Address1 = x.CompanyDetail.Address1,
                         TransCode = x.CompanyDetail.TransCode
                     },
                     UserCode = x.UserCode,
                     SRVNo = x.SRVNo,
                     SDate = (x.SDate != null ? Convert.ToDateTime(x.SDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),                     
                     CustName = x.CustName,
                     CustAddress1 = x.CustAddress1,
                     Remark = x.Remark,
                     NetAmt = x.NetAmt,
                     DiscAmt = x.DiscAmt,
                     TaxAmt = x.TaxAmt,
                     TotalAmt = x.TotalAmt
                 }).ToListAsync();
            return result;
        }

        // Purchase / Sale Order File 
        public async Task<string> PurchaseOrderSrNoCreation(int cmpid)
        {
            var NewNo = ""; var NewValue = 0; CurrentIndex = 0;
            var result = await _applicationDbContext.PurchaseOrderTable
                          .OrderByDescending(x => x.SOId)
                          .Select(x => new { x.SOVNo, x.CompId })
                          .FirstOrDefaultAsync(x => x.CompId == cmpid);
            if (result != null)
            {
                string[] parts1 = result.SOVNo.Split('X');
                NewValue = Convert.ToInt32(parts1[1]) + 1;
                CurrentIndex = Convert.ToInt32(NewValue.ToString().Length) - 1;
                NewNo = CurrentIndex < 4 ? "X" + myzero[CurrentIndex] + (NewValue) : "X" + NewValue.ToString();
            }
            else
            {
                NewNo = "X00001";
            }
            return NewNo;
        }
        public async Task<int> AddNewPurchaseOrderFile(PurchaseOrderViewModel models)
        {
            DateTime? Date1 = null;
            userdt = models.ODate.Split('/');
            userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            PurchaseOrder opnitemMaster = new PurchaseOrder()
            {
                UserCode = models.UserCode,
                CompId = models.CompId,
                SOVNo = models.SOVNo,
                ODate = string.IsNullOrEmpty(models.ODate) ? Date1 : Convert.ToDateTime(userdt1),
                AcCode = models.AcCode,
                CustName = models.CustName,
                CustAddress1 = models.CustAddress1,
                Remark = models.Remark
            };
            _applicationDbContext.Entry(opnitemMaster).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            foreach (var item in models.PurchaseOrderDetailViewModels)
            {               
                PurchaseOrderDetail order = new PurchaseOrderDetail()
                {
                    SOMDId = item.SOMDId,
                    ItemCode = item.ItemCode,
                    SSItemName = item.SSItemName,      
                    CasePcs = item.CasePcs,
                    Rate = item.Rate,
                    UnitName = item.UnitName,
                    GSTPer = item.GSTPer,
                    TempSrNo = (int)item.TempSrNo,
                    CompIdSOItemMD = (int)models.CompId,
                    UserCodeSOItemMD = models.UserCode,
                    SOVNoD = models.SOVNo,
                    SOIMId = opnitemMaster.SOId
                };
                _applicationDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            await _applicationDbContext.SaveChangesAsync();
            return opnitemMaster.SOId;
        }
        public async Task<bool> UpdatePurchaseOrderFile(PurchaseOrderViewModel models)
        {
            DateTime? Date1 = null;
            userdt = models.ODate.Split('/');
            userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            var result = await _applicationDbContext.PurchaseOrderTable.FirstOrDefaultAsync(n => n.SOId == models.SOId);
            if (result != null)
            {
                result.UserCode = result.UserCode;
                result.CompId = result.CompId;
                result.SOVNo = result.SOVNo;
                result.ODate = string.IsNullOrEmpty(models.ODate) ? Date1 : Convert.ToDateTime(userdt1);
                result.AcCode = models.AcCode;
                result.CustName = models.CustName;
                result.CustAddress1 = models.CustAddress1;
                result.Remark = models.Remark;
            };
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();

            foreach (var item in models.PurchaseOrderDetailViewModels)
            {              
                var result1 = await _applicationDbContext.PurchaseOrderDetailTable.FirstOrDefaultAsync(x => x.TempSrNo == item.TempSrNo && x.SOIMId == models.SOId);
                if (result1 != null)
                {
                    //result1.SSMDId = item.SSMDId;
                    result1.ItemCode = item.ItemCode;
                    result1.SSItemName = item.SSItemName;
                    result1.CasePcs = item.CasePcs;
                    result1.Rate = item.Rate;
                    result1.UnitName = item.UnitName;
                    result1.GSTPer = item.GSTPer;
                    //result1.TempSrNo = (int)item.TempSrNo;
                    //result1.CompIdSSItemMD = (int)result.CompId;
                    //result1.UserCodeSSItemMD = result.UserCode;
                    //result1.SSVNoD = models.SSVNo;
                    //result1.SSIMId = result.SSId;
                    _applicationDbContext.Entry(result1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                else
                {
                    PurchaseOrderDetail order = new PurchaseOrderDetail()
                    {
                        SOMDId = item.SOMDId,
                        ItemCode = item.ItemCode,
                        SSItemName = item.SSItemName,
                        CasePcs = item.CasePcs,
                        Rate = item.Rate,
                        UnitName = item.UnitName,
                        GSTPer = item.GSTPer,
                        TempSrNo = (int)item.TempSrNo,
                        CompIdSOItemMD = (int)result.CompId,
                        UserCodeSOItemMD = result.UserCode,
                        SOVNoD = models.SOVNo,
                        SOIMId = result.SOId
                    };
                    _applicationDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                }
            }
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<PurchaseOrderViewModel> GetPurchaseOrderFileById(int id)
        {
            var result = await _applicationDbContext.PurchaseOrderTable
                    .Select(x => new PurchaseOrderViewModel()
                    {
                        SOId = x.SOId,
                        CompId = x.CompId,
                        UserCode = x.UserCode,
                        SOVNo = x.SOVNo,
                        ODate = (x.ODate != null ? Convert.ToDateTime(x.ODate).ToString("dd/MM/yyyy").Replace('-', '/') : null),                        
                        AcCode =  x.AcCode,
                        LedgerMasterViewModel = new LedgerMasterViewModel()
                        {
                            LedgerMasterId = x.LedgerMasterSaleOrder.LedgerMasterId,
                            PartyName = x.LedgerMasterSaleOrder.PartyName,
                            Address1 = x.LedgerMasterSaleOrder.Address1,
                            MobileNo1 = x.LedgerMasterSaleOrder.MobileNo1,
                            GSTNo = x.LedgerMasterSaleOrder.GSTNo,
                            StateLedgerMasterView = new StateViewModel()
                            {
                                StateId = x.LedgerMasterSaleOrder.StateLedger.StateId,
                                StateName = x.LedgerMasterSaleOrder.StateLedger.StateName,
                            }
                        },
                        CustName = x.CustName,
                        CustAddress1 = x.CustAddress1,
                        Remark = x.Remark,
                        PurchaseOrderDetailViewModels = x.PurchaseOrderDetails.Where(a => a.SOIMId == x.SOId)
                        .OrderBy(a => a.TempSrNo)
                        .Select(n => new PurchaseOrderDetailViewModel()
                        {
                            TempSrNo = n.TempSrNo,
                            ItemCode = n.ItemCode,
                            SSItemName = n.SSItemName,
                            CasePcs = n.CasePcs,
                            Rate = n.Rate,
                            UnitName = n.UnitName,
                            GSTPer = n.GSTPer,
                            RecordType = "Old"
                        }).ToList()
                    }).FirstOrDefaultAsync(x => x.SOId == id);
            return result;
        }
        public async Task<bool> DeletePurchaseOrderFile(PurchaseOrderViewModel models)
        {
            var result2 = await _applicationDbContext.PurchaseOrderTable.FirstOrDefaultAsync(x => x.SOId == models.SOId);
            if (result2 != null)
            {
                _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            return false;
        }
        public async Task<bool> DeletePurchaseOrderFileOne(int id, int tno)
        {
            var result1 = await _applicationDbContext.PurchaseOrderDetailTable.FirstOrDefaultAsync(x => x.TempSrNo == tno && x.SOIMId == id);
            if (result1 != null)
            {
                result1.SOIMId = id;
                result1.TempSrNo = tno;
                _applicationDbContext.Entry(result1).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            var No1 = 1;
            var result2 = await _applicationDbContext.PurchaseOrderDetailTable.OrderBy(x => x.TempSrNo).Where(x => x.SOIMId == id).ToListAsync();
            foreach (var item in result2)
            {
                var result = await _applicationDbContext.PurchaseOrderDetailTable.FirstOrDefaultAsync(x => x.SOMDId == item.SOMDId);
                if (result != null)
                {
                    item.TempSrNo = No1;
                    _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _applicationDbContext.SaveChanges();
                    No1++;
                }
            }
            return false;
        }
        public async Task<List<PurchaseOrderViewModel>> SearchPurchaseOrderFileDateWise(int CmpId, string UCode, string invno, string name, string mobileno, string address, DateTime dt1, DateTime dt2)
        {
            var result = await _applicationDbContext.PurchaseOrderTable
                 .OrderBy(x => x.CompId).ThenBy(x => x.UserCode).ThenBy(x => x.ODate).ThenBy(x => x.SOVNo)
                 .Where(x => (CmpId > 0 ? x.CompId == CmpId : true)
                  && (UCode != "0" ? x.UserCode == UCode : true)
                  && x.ODate >= dt1 && x.ODate <= dt2
                  && (invno != null ? x.SOVNo.Contains(invno) : true)
                  && (name != null ? x.CustName.Contains(name) : true)
                  && (mobileno != null ? x.LedgerMasterSaleOrder.MobileNo1.Contains(mobileno) : true)
                  && (address != null ? x.CustAddress1.Contains(address) : true)
                  )
                 .Select(x => new PurchaseOrderViewModel()
                 {
                     SOId = x.SOId,
                     CompId = x.CompId,
                     CompanyDetailViewModel = new CompanyDetailViewModel()
                     {
                         CompName = x.CompanyDetail.CompName,
                         Address1 = x.CompanyDetail.Address1,
                         TransCode = x.CompanyDetail.TransCode
                     },
                     UserCode = x.UserCode,
                     SOVNo = x.SOVNo,
                     ODate = (x.ODate != null ? Convert.ToDateTime(x.ODate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                     AcCode = x.AcCode,
                     LedgerMasterViewModel = new LedgerMasterViewModel()
                     {
                         LedgerMasterId = x.LedgerMasterSaleOrder.LedgerMasterId,
                         PartyName = x.LedgerMasterSaleOrder.PartyName,
                         Address1 = x.LedgerMasterSaleOrder.Address1,
                         MobileNo1 = x.LedgerMasterSaleOrder.MobileNo1,
                         GSTNo = x.LedgerMasterSaleOrder.GSTNo
                     },
                     CustName = x.CustName,
                     CustAddress1 = x.CustAddress1,
                     Remark = x.Remark
                 }).ToListAsync();
            return result;
        }

        // Voucher  File
        public async Task<string> GetCodeLedgerMasterById(int id)
        {
            var result = await _applicationDbContext.HeadTable
                    .Where(x => x.LedgerMasterId == id)
                    .Select(x => x.LedCode).FirstOrDefaultAsync();
            return result;
        }
        public async Task<string> VoucherSrNoCreation(int cmpid, string vouchtype)
        {
            var NewNo = ""; var NewValue = 0; CurrentIndex = 0; var splitChar = "";
            if (vouchtype == "Bank Receipt") { splitChar = "E"; }
            else if (vouchtype == "Bank Payment") { splitChar = "F"; }
            else if (vouchtype == "Receipt") { splitChar = "G"; }
            else if (vouchtype == "Payment") { splitChar = "H"; }
            var result = await _applicationDbContext.VoucherTable
                          .OrderByDescending(x => x.VId)
                          .Select(x => new { x.VVNo, x.CompId, x.VType })
                          .FirstOrDefaultAsync(x => x.CompId == cmpid && x.VType == vouchtype);
            if (result != null)
            {
                string[] parts1 = result.VVNo.Split(splitChar);
                NewValue = Convert.ToInt32(parts1[1]) + 1;
                CurrentIndex = Convert.ToInt32(NewValue.ToString().Length) - 1;
                NewNo = CurrentIndex < 4 ? splitChar + myzero[CurrentIndex] + (NewValue) : splitChar + NewValue.ToString();
            }
            else
            {
                NewNo = splitChar + "00001";
            }
            return NewNo;
        }
        public async Task<int> AddNewVoucherRecord(VoucherViewModel model)
        {
            string booktype; int accountId = 0; int accountIdII = 0;
            booktype = model.VType == "Receipt" || model.VType == "Payment" ? "Cash Book" : "Bank Book";
            DateTime? Date1 = null;
            if (!string.IsNullOrEmpty(model.VDate))
            {
                userdt = model.VDate.Split('/');
                userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            }
            Voucher opnitemMaster = new Voucher()
            {
                CompId = model.CompId,
                UserCode = model.UserCode,
                VType = model.VType,
                VVNo = model.VVNo,
                VDate = string.IsNullOrEmpty(model.VDate) ? Date1 : Convert.ToDateTime(userdt1),
                DrAmt = model.DrAmt,
                CrAmt = model.CrAmt,
                Remark = model.Remark
            };
            _applicationDbContext.Entry(opnitemMaster).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            daamt = Convert.ToDouble(model.VoucherDetailViewModels.Where(x => x.AccountMode == AccountDrCr.Dr).Count());
            ccamt = Convert.ToDouble(model.VoucherDetailViewModels.Where(x => x.AccountMode == AccountDrCr.Cr).Count());
            if (daamt > ccamt)
            {
                accountId = model.VoucherDetailViewModels.Where(x => x.AccountMode == AccountDrCr.Cr).Select(x => Convert.ToInt32(x.AcCode1)).FirstOrDefault();
            }
            else if (daamt < ccamt)
            {
                accountId = model.VoucherDetailViewModels.Where(x => x.AccountMode == AccountDrCr.Dr).Select(x => Convert.ToInt32(x.AcCode1)).FirstOrDefault();
            }
            else if (daamt == ccamt && (daamt + ccamt) == 2)
            {
                accountId = model.VoucherDetailViewModels.Where(x => x.TempSrNo == 1).Select(x => Convert.ToInt32(x.AcCode1)).FirstOrDefault();
                accountIdII = model.VoucherDetailViewModels.Where(x => x.TempSrNo == 2 ).Select(x => Convert.ToInt32(x.AcCode1)).FirstOrDefault();
            }
            else if (daamt == ccamt && (daamt + ccamt) != 2)
            {
                accountId = model.VoucherDetailViewModels.Where(x => x.AccountMode == AccountDrCr.Dr).Select(x => Convert.ToInt32(x.AcCode1)).FirstOrDefault();                
            }
            foreach (var item in model.VoucherDetailViewModels)
            {
                VoucherDetail order = new VoucherDetail()
                {
                    VMDId = item.VMDId,
                    BookType = booktype,
                    AcCode1 = item.AcCode1,
                    VoucherPartyName = item.VoucherPartyName,
                    AcCode2 = (daamt + ccamt) == 2 ? ( item.TempSrNo == 1 ? accountIdII : accountId ) : accountId,
                    ChequeNo = item.ChequeNo,
                    Dr_Amt = item.AccountMode == AccountDrCr.Dr ? (item.Dr_Amt != null ? item.Dr_Amt : 0) : 0,
                    Cr_Amt = item.AccountMode == AccountDrCr.Cr ? (item.Cr_Amt != null ? item.Cr_Amt : 0) : 0,
                    RefNo = item.RefNo,
                    TempSrNo = item.TempSrNo,
                    CompIdVItemMD = model.CompId,
                    UserCodeVItemMD = model.UserCode,
                    VVNoD = model.VVNo,
                    VVType = model.VType,
                    VIMId = opnitemMaster.VId,
                    CustAcCode1 = await GetCodeLedgerMasterById(Convert.ToInt32(item.AcCode1)),
                    CustAcCode2 = await GetCodeLedgerMasterById(accountId)
                };
                _applicationDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            await _applicationDbContext.SaveChangesAsync();
            return opnitemMaster.VId;
        }
        public async Task<bool> UpdateVoucherRecord(VoucherViewModel model)
        {
            string booktype; int accountId = 0; int accountIdII = 0;
            booktype = model.VType == "Receipt" || model.VType == "Payment" ? "Cash Book" : "Bank Book";
            DateTime? Date1 = null;
            if (!string.IsNullOrEmpty(model.VDate))
            {
                userdt = model.VDate.Split('/');
                userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            }
            var result = await _applicationDbContext.VoucherTable.FirstOrDefaultAsync(n => n.VId == model.VId);
            if (result != null)
            {
                //result.VId = opnMasterId;
                //result.CompId = model.CompId;
                //result.UserCode = model.UserCode;
                result.VType = model.VType;
                result.VVNo = model.VVNo;
                result.VDate = string.IsNullOrEmpty(model.VDate) ? Date1 : Convert.ToDateTime(userdt1);
                result.DrAmt = model.DrAmt;
                result.CrAmt = model.CrAmt;                
                result.Remark = model.Remark;
            };
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            daamt = Convert.ToDouble(model.VoucherDetailViewModels.Where(x => x.AccountMode == AccountDrCr.Dr).Count());
            ccamt = Convert.ToDouble(model.VoucherDetailViewModels.Where(x => x.AccountMode == AccountDrCr.Cr).Count());
            if (daamt > ccamt)
            {
                accountId = model.VoucherDetailViewModels.Where(x => x.AccountMode == AccountDrCr.Cr).Select(x => Convert.ToInt32(x.AcCode1)).FirstOrDefault();
            }
            else if (daamt < ccamt)
            {
                accountId = model.VoucherDetailViewModels.Where(x => x.AccountMode == AccountDrCr.Dr).Select(x => Convert.ToInt32(x.AcCode1)).FirstOrDefault();
            }
            else if (daamt == ccamt && (daamt + ccamt) == 2)
            {
                accountId = model.VoucherDetailViewModels.Where(x => x.TempSrNo == 1).Select(x => Convert.ToInt32(x.AcCode1)).FirstOrDefault();
                accountIdII = model.VoucherDetailViewModels.Where(x => x.TempSrNo == 2).Select(x => Convert.ToInt32(x.AcCode1)).FirstOrDefault();
            }
            else if (daamt == ccamt && (daamt + ccamt) != 2)
            {
                accountId = model.VoucherDetailViewModels.Where(x => x.AccountMode == AccountDrCr.Dr).Select(x => Convert.ToInt32(x.AcCode1)).FirstOrDefault();
            }
            foreach (var item in model.VoucherDetailViewModels)
            { 
                var result1 = await _applicationDbContext.VoucherDetailTable.FirstOrDefaultAsync(x => x.TempSrNo == item.TempSrNo && x.VIMId == result.VId);
                if (result1 != null)
                {
                    result1.AcCode1 = item.AcCode1;
                    result1.VoucherPartyName = item.VoucherPartyName;
                    result1.AcCode2 = (daamt + ccamt) == 2 ? (item.TempSrNo == 1 ? accountIdII : accountId) : accountId;
                    result1.ChequeNo = item.ChequeNo;
                    result1.Dr_Amt = item.AccountMode == AccountDrCr.Dr ? (item.Dr_Amt != null ? item.Dr_Amt : 0) : 0;
                    result1.Cr_Amt = item.AccountMode == AccountDrCr.Cr ? (item.Cr_Amt != null ? item.Cr_Amt : 0) : 0;
                    result1.RefNo = item.RefNo;
                    //result1.TempSrNo = item.TempSrNo; result1.CompIdVItemMD = item.CompIdVItemMD;
                    //result1.UserCodeVItemMD = item.UserCodeVItemMD; result1.VVNoD = item.VVNoD;
                    //result1.VVType = item.VVType; 
                    //result1.VIMId = item.VIMId;
                    result1.CustAcCode1 = await GetCodeLedgerMasterById(Convert.ToInt32(item.AcCode1));
                    result1.CustAcCode2 = await GetCodeLedgerMasterById(accountId);
                    _applicationDbContext.Entry(result1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                else
                {
                    VoucherDetail order = new VoucherDetail()
                    {
                        VMDId = item.VMDId,
                        BookType = booktype,
                        AcCode1 = item.AcCode1,
                        VoucherPartyName = item.VoucherPartyName,
                        AcCode2 = (daamt + ccamt) == 2 ? (item.TempSrNo == 1 ? accountIdII : accountId) : accountId,
                        ChequeNo = item.ChequeNo,
                        Dr_Amt = item.AccountMode == AccountDrCr.Dr ? (item.Dr_Amt != null ? item.Dr_Amt : 0) : 0,
                        Cr_Amt = item.AccountMode == AccountDrCr.Dr ? (item.Dr_Amt != null ? item.Dr_Amt : 0) : 0,
                        RefNo = item.RefNo,
                        TempSrNo = item.TempSrNo,
                        CompIdVItemMD = result.CompId,
                        UserCodeVItemMD = result.UserCode,
                        VVNoD = result.VVNo,
                        VVType = result.VType,
                        VIMId = result.VId,
                        CustAcCode1 = await GetCodeLedgerMasterById(Convert.ToInt32(item.AcCode1)),
                        CustAcCode2 = await GetCodeLedgerMasterById(accountId)
                    };
                    _applicationDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                }
            }
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<VoucherViewModel> GetVoucherById(int id) 
        {
            var result = await _applicationDbContext.VoucherTable
                    .Select(x => new VoucherViewModel()
                    {
                        VId = x.VId,
                        CompId = x.CompId,
                        VCompanyDetails = new CompanyDetailViewModel()
                        {
                            CompName = x.CompVoucher.CompName,
                            Address1 = x.CompVoucher.Address1,
                            TransCode = x.CompVoucher.TransCode
                        },
                        VVNo = x.VVNo,
                        UserCode = x.UserCode,
                        VDate = (x.VDate != null ? Convert.ToDateTime(x.VDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                        CrAmt = x.CrAmt,
                        DrAmt = x.DrAmt,
                        VType = x.VType,
                        Remark = x.Remark,
                        VoucherDetailViewModels = x.VoucherDetails.Where(n => n.VIMId == x.VId).OrderBy(n => n.TempSrNo)
                                                      .Select(n => new VoucherDetailViewModel()
                                                      {
                                                          TempSrNo = n.TempSrNo,
                                                          AcCode1 = n.AcCode1,
                                                          VoucherPartyName = n.VoucherPartyName,
                                                          AcCode2 = n.AcCode2,
                                                          ChequeNo = n.ChequeNo,
                                                          AccountMode = n.Dr_Amt > 0 ? AccountDrCr.Dr : AccountDrCr.Cr,
                                                          Dr_Amt = n.Dr_Amt,
                                                          Cr_Amt = n.Cr_Amt,
                                                          RefNo = n.RefNo,
                                                          RecordType = "Old"
                                                      }).ToList()
                    }).FirstOrDefaultAsync(x => x.VId == id);
            return result;
        }
        public async Task<bool> DeleteVoucherRecord(int id)
        {
            var result2 = await _applicationDbContext.VoucherTable.FirstOrDefaultAsync(x => x.VId == id);
            if (result2 != null)
            {
                _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            return false;
        }
        public async Task<bool> DeleteVoucherOneRecord(int id, int tno)
        {
            var result1 = await _applicationDbContext.VoucherDetailTable.FirstOrDefaultAsync(x => x.TempSrNo == tno && x.VIMId == id);
            if (result1 != null)
            {
                result1.VIMId = id;
                result1.TempSrNo = tno;
                _applicationDbContext.Entry(result1).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            var No1 = 1;
            var result2 = await _applicationDbContext.VoucherDetailTable.OrderBy(x => x.TempSrNo).Where(x => x.VIMId == id).ToListAsync();
            foreach (var item in result2)
            {
                var result3 = await _applicationDbContext.VoucherDetailTable.FirstOrDefaultAsync(x => x.VMDId == item.VMDId);
                if (result3 != null)
                {
                    item.TempSrNo = No1;
                    _applicationDbContext.Entry(result3).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _applicationDbContext.SaveChanges();
                    No1++;
                }
            }
            return false;
        }
        public async Task<List<VoucherViewModel>> SearchVoucherDateWise(int CmpId, string userId,string vouchertype, decimal totalAmt, decimal creditAmt, DateTime dt1, DateTime dt2)
        {
            var result = await _applicationDbContext.VoucherTable
                 .Where(x => (CmpId > 0 ? x.CompId == CmpId : true)
                 && ( userId != "0" ? x.UserCode == userId : true)
                 && (vouchertype != null && vouchertype != "0" ? x.VType == vouchertype : true)
                 && (totalAmt > 0 ? x.CrAmt == totalAmt : true)
                 && (creditAmt > 0 ? x.DrAmt == creditAmt : true)
                 && x.VDate >= dt1 && x.VDate <= dt2)
                 .OrderBy(x => x.CompId).ThenBy(x => x.UserCode).ThenBy(x => x.VDate).ThenBy(x => x.VVNo)
                 .Select(x => new VoucherViewModel()
                 {
                     VId = x.VId,
                     CompId = x.CompId,
                     VCompanyDetails = new CompanyDetailViewModel()
                     {
                         CompName = x.CompVoucher.CompName,
                         Address1 = x.CompVoucher.Address1,
                         TransCode = x.CompVoucher.TransCode
                     },
                     VVNo = x.VVNo,
                     VType = x.VType,
                     UserCode = x.UserCode,
                     VDate = (x.VDate != null ? Convert.ToDateTime(x.VDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                     CrAmt = x.CrAmt,
                     DrAmt = x.DrAmt
                 }).ToListAsync();
            return result;
        }
        public async Task<List<VoucherViewModel>> AccountGroupVoucherDateWise(int CmpId, DateTime dt2, int AcGroupId)
        {
            var result = await _applicationDbContext.VoucherTable
                 .Where(x => x.CompId == CmpId && x.VDate <= dt2)
                 .OrderBy(x => x.CompId).ThenBy(x => x.VDate).ThenBy(x => x.VId)
                 .Select(x => new VoucherViewModel()
                 {
                     VId = x.VId,
                     CompId = x.CompId,
                     VCompanyDetails = new CompanyDetailViewModel()
                     {
                         CompName = x.CompVoucher.CompName,
                         Address1 = x.CompVoucher.Address1,
                         TransCode = x.CompVoucher.TransCode
                     },
                     VVNo = x.VVNo,
                     UserCode = x.UserCode,
                     VDate = (x.VDate != null ? Convert.ToDateTime(x.VDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                     CrAmt = x.CrAmt,
                     DrAmt = x.DrAmt,
                     VoucherDetailViewModels = x.VoucherDetails.Where(n => n.VIMId == x.VId && n.VoucherAcCode1.AcGPLedger.Id == AcGroupId)
                                               .Select(n => new VoucherDetailViewModel()
                                               {
                                                   TempSrNo = n.TempSrNo,
                                                   AcCode1 = n.AcCode1,
                                                   VoucherPartyName = n.VoucherPartyName,
                                                   AcCode2 = n.AcCode2,
                                                   ChequeNo = n.ChequeNo,
                                                   Dr_Amt = n.Dr_Amt,
                                                   Cr_Amt = n.Cr_Amt,
                                                   RefNo = n.RefNo
                                               }).ToList()
                 }).ToListAsync();
            return result;
        }
        public async Task<int> LedgerBeforeDateBal(DateTime dt1, int AcId)
        {            
            var result = await _applicationDbContext.VoucherTable
                 .Where(x => x.VDate < dt1)
                 .OrderBy(x => x.CompId).ThenBy(x => x.VDate).ThenBy(x => x.VId)
                 .Select(x => new VoucherViewModel()
                 {
                     VoucherDetailViewModels = x.VoucherDetails.Where(n => n.VIMId == x.VId && n.AcCode1 == AcId)
                                               .Select(n => new VoucherDetailViewModel()
                                               {
                                                   TempSrNo = n.TempSrNo,
                                                   AcCode1 = n.AcCode1,
                                                   VoucherPartyName = n.VoucherPartyName,
                                                   AcCode2 = n.AcCode2,
                                                   ChequeNo = n.ChequeNo,
                                                   Dr_Amt = n.Dr_Amt,
                                                   Cr_Amt = n.Cr_Amt
                                               }).ToList()
                 }).ToListAsync();
            int balamt = result != null ? (int)result.Sum(x => x.VoucherDetailViewModels.Sum(n => n.Dr_Amt - n.Cr_Amt)) : 0;
            return balamt;
        }
        public async Task<List<VoucherViewModel>> LedgerVoucherDateWise(DateTime dt1, DateTime dt2, int AcId)
        {
            var result = await _applicationDbContext.VoucherTable
                 .Where(x => x.VDate >= dt1 && x.VDate <= dt2)
                 .OrderBy(x => x.CompId).ThenBy(x => x.VDate).ThenBy(x => x.VId)
                 .Select(x => new VoucherViewModel()
                 {
                     VId = x.VId,
                     CompId = x.CompId,
                     VCompanyDetails = new CompanyDetailViewModel()
                     {
                         CompName = x.CompVoucher.CompName,
                         Address1 = x.CompVoucher.Address1,
                         TransCode = x.CompVoucher.TransCode
                     },
                     VVNo = x.VVNo,
                     UserCode = x.UserCode,
                     VType = x.VType,
                     VDate = (x.VDate != null ? Convert.ToDateTime(x.VDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                     CrAmt = x.CrAmt,
                     DrAmt = x.DrAmt,
                     Remark = x.Remark,
                     VoucherDetailViewModels = x.VoucherDetails.Where(n => n.VIMId == x.VId && n.AcCode1 == AcId)
                                               .Select(n => new VoucherDetailViewModel()
                                               {
                                                   TempSrNo = n.TempSrNo,
                                                   AcCode1 = n.AcCode1,
                                                   VoucherPartyName = n.VoucherPartyName,
                                                   VDLedger1 = new LedgerMasterViewModel()
                                                   {
                                                       PartyName = n.VoucherAcCode1.PartyName
                                                   },
                                                   AcCode2 = n.AcCode2,
                                                   VDLedger2 = new LedgerMasterViewModel()
                                                   {
                                                       PartyName = n.VoucherAcCode2.PartyName
                                                   },
                                                   ChequeNo = n.ChequeNo,
                                                   Dr_Amt = n.Dr_Amt,
                                                   Cr_Amt = n.Cr_Amt,
                                                   TotalAmt = n.TotalAmt,
                                                   DiscAmt = n.DiscAmt,
                                                   RefNo = n.RefNo,
                                                   PatientName = n.PatientName,
                                                   Comments = n.Comments,
                                                   CompIdVItemMD = n.CompIdVItemMD,
                                                   UserCodeVItemMD = n.UserCodeVItemMD,
                                                   VVNoD = n.VVNoD,
                                                   VVType = n.VVType,
                                                   VIMId = n.VIMId
                                               }).ToList()
                 }).ToListAsync();
            List<VoucherViewModel> voucherList = new List<VoucherViewModel>();
            int x = 0;var drcrnature = "";
            foreach (var item in result)
            {                
                if (item.VoucherDetailViewModels.Where(x => x.AcCode1 == AcId).Count() > 0)
                {
                    List<VoucherDetailViewModel> voucherDetailViewModels = new List<VoucherDetailViewModel>();
                    var templist = await LedgerIdRecord(item.VId);
                    var drcrnaturex = templist.Where(x => x.AcCode1 == AcId && x.AcCode2 == AcId).FirstOrDefault();
                    x = 1;
                    if (templist.Where(x => x.AcCode1 == AcId && x.AcCode2 == AcId).Count() > 0)
                    {
                        drcrnature = drcrnaturex.Dr_Amt > 0 ? "Dr" : "Cr";
                        foreach (var itemx in templist.Where(x => x.AcCode1 != AcId))
                        {
                            voucherDetailViewModels.Add(new VoucherDetailViewModel()
                            {
                                TempSrNo = x,
                                AcCode1 = itemx.AcCode1,
                                VoucherPartyName = itemx.VoucherPartyName,
                                VDLedger1 = new LedgerMasterViewModel()
                                {
                                    PartyName = itemx.VDLedger1.PartyName
                                },
                                ChequeNo = itemx.ChequeNo,
                                Dr_Amt = drcrnature == "Dr" ? itemx.Cr_Amt : 0,
                                Cr_Amt = drcrnature == "Cr" ? itemx.Dr_Amt : 0,
                                TotalAmt = itemx.TotalAmt,
                                DiscAmt = itemx.DiscAmt,
                                RefNo = itemx.RefNo,
                                PatientName = itemx.PatientName,
                                Comments = itemx.Comments,
                                CompIdVItemMD = itemx.CompIdVItemMD,
                                UserCodeVItemMD = itemx.UserCodeVItemMD,
                                VVNoD = itemx.VVNoD,
                                VVType = itemx.VVType,
                                VIMId = itemx.VIMId
                            });
                            x++;
                        }
                    }
                    else
                    {
                        x = 1;
                        foreach (var itemx in templist.Where(x => x.AcCode1 == AcId))
                        {
                            voucherDetailViewModels.Add(new VoucherDetailViewModel()
                            {
                                TempSrNo = x,
                                AcCode1 = itemx.AcCode1,
                                VoucherPartyName = itemx.VoucherPartyName,
                                VDLedger1 = new LedgerMasterViewModel()
                                {
                                    PartyName = itemx.VDLedger2.PartyName
                                },
                                ChequeNo = itemx.ChequeNo,
                                Dr_Amt = itemx.Dr_Amt,
                                Cr_Amt = itemx.Cr_Amt,
                                TotalAmt = itemx.TotalAmt,
                                DiscAmt = itemx.DiscAmt,
                                RefNo = itemx.RefNo,
                                PatientName = itemx.PatientName,
                                Comments = itemx.Comments,
                                CompIdVItemMD = itemx.CompIdVItemMD,
                                UserCodeVItemMD = itemx.UserCodeVItemMD,
                                VVNoD = itemx.VVNoD,
                                VVType = itemx.VVType,
                                VIMId = itemx.VIMId
                            });
                            x++;
                        }
                    }
                    voucherList.Add(new VoucherViewModel()
                    {
                        VId = item.VId,
                        CompId = item.CompId,
                        VCompanyDetails = new CompanyDetailViewModel()
                        {
                            CompName = item.VCompanyDetails.CompName,
                            Address1 = item.VCompanyDetails.Address1,
                            TransCode = item.VCompanyDetails.TransCode
                        },
                        VVNo = item.VVNo,
                        UserCode = item.UserCode,
                        VType = item.VType,
                        VDate = item.VDate,
                        CrAmt = item.CrAmt,
                        DrAmt = item.DrAmt,
                        Remark = item.Remark,
                        VoucherDetailViewModels = voucherDetailViewModels
                    });                    
                }
            }
            return voucherList;
        }
        public async Task<List<VoucherDetailViewModel>> LedgerIdRecord(int id)
        {
            var result = await _applicationDbContext.VoucherDetailTable
                 .Where(n => n.VIMId == id)
                 .Select(n => new VoucherDetailViewModel()
                 {
                     TempSrNo = n.TempSrNo,
                     AcCode1 = n.AcCode1,
                     VoucherPartyName = n.VoucherPartyName,
                     VDLedger1 = new LedgerMasterViewModel()
                     {
                         PartyName = n.VoucherAcCode1.PartyName
                     },
                     AcCode2 = n.AcCode2,
                     VDLedger2 = new LedgerMasterViewModel()
                     {
                         PartyName = n.VoucherAcCode2.PartyName
                     },                     
                     ChequeNo = n.ChequeNo,
                     Dr_Amt = n.Dr_Amt,
                     Cr_Amt = n.Cr_Amt,
                     TotalAmt = n.TotalAmt,
                     DiscAmt = n.DiscAmt,
                     RefNo = n.RefNo,
                     PatientName = n.PatientName,
                     Comments = n.Comments,
                     CompIdVItemMD = n.CompIdVItemMD,
                     UserCodeVItemMD = n.UserCodeVItemMD,
                     VVNoD = n.VVNoD,
                     VVType = n.VVType,
                     VIMId = n.VIMId
                 }).ToListAsync();
            return result;
        }
        public async Task<List<LedgerMasterViewModel>> DailyWorkSummaryAccountGroup(DateTime dt1)
        {
            var result = await _applicationDbContext.VoucherTable
                 .Where(x => x.VDate == dt1)
                 .Select(x => new VoucherViewModel()
                 {
                     VoucherDetailViewModels = x.VoucherDetails.Where(n => n.VIMId == x.VId)
                                               .Select(n => new VoucherDetailViewModel()
                                               {
                                                   AcCode1 = n.AcCode1,
                                                   VoucherPartyName = n.VoucherAcCode1.PartyName
                                               }).ToList()
                 }).ToListAsync();
            List<LedgerMasterViewModel> ledgerMasterViewModels = new List<LedgerMasterViewModel>();
            foreach (var item in result)
            {
                foreach (var itemx in item.VoucherDetailViewModels)
                {
                    ledgerMasterViewModels.Add(new LedgerMasterViewModel()
                    {
                        LedgerMasterId = (int)itemx.AcCode1,
                        PartyName = itemx.VoucherPartyName
                    });
                }
            }
            List<LedgerMasterViewModel> ledgerMasterViewModelsx = new List<LedgerMasterViewModel>();
            foreach (var item in ledgerMasterViewModels.GroupBy(x => new { x.LedgerMasterId, x.PartyName }))
            {
                ledgerMasterViewModelsx.Add(new LedgerMasterViewModel() { LedgerMasterId = item.Key.LedgerMasterId, PartyName = item.Key.PartyName });
            }

            return ledgerMasterViewModelsx;
        }
        public async Task<List<VoucherViewModel>> DailyWorkSummaryDateWise(DateTime dt1)
        {
            var result = await _applicationDbContext.VoucherTable
                 .Where(x => x.VDate == dt1)
                 .OrderBy(x => x.CompId).ThenBy(x => x.VDate).ThenBy(x => x.VId)
                 .Select(x => new VoucherViewModel()
                 {
                     CompId = x.CompId,
                     VoucherDetailViewModels = x.VoucherDetails.Where(n => n.VIMId == x.VId)
                                               .Select(n => new VoucherDetailViewModel()
                                               {
                                                   TempSrNo = n.TempSrNo,
                                                   AcCode1 = n.AcCode1,
                                                   VoucherPartyName = n.VoucherPartyName,
                                                   AcCode2 = n.AcCode2,
                                                   ChequeNo = n.ChequeNo,
                                                   Dr_Amt = n.Dr_Amt,
                                                   Cr_Amt = n.Cr_Amt
                                               }).ToList()
                 }).ToListAsync();
            return result;
        }
        public async Task<List<VoucherViewModel>> CashBankDateWise(DateTime dt1, DateTime dt2, int AcId)
        {
            var result = await _applicationDbContext.VoucherTable
                 .Where(x => x.VDate >= dt1 && x.VDate <= dt2)
                 .OrderBy(x => x.CompId).ThenBy(x => x.VDate).ThenBy(x => x.VId)
                 .Select(x => new VoucherViewModel()
                 {
                     CompId = x.CompId,
                     VCompanyDetails = new CompanyDetailViewModel()
                     {
                         CompName = x.CompVoucher.CompName,
                         Address1 = x.CompVoucher.Address1,
                         TransCode = x.CompVoucher.TransCode
                     },
                     VVNo = x.VVNo,
                     UserCode = x.UserCode,
                     VDate = (x.VDate != null ? Convert.ToDateTime(x.VDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                     CrAmt = x.CrAmt,
                     DrAmt = x.DrAmt,
                     VType = x.VType,
                     VoucherDetailViewModels = x.VoucherDetails.Where(n => n.VIMId == x.VId && n.AcCode2 == AcId)
                                               .Select(n => new VoucherDetailViewModel()
                                               {
                                                   TempSrNo = n.TempSrNo,
                                                   AcCode1 = n.AcCode1,
                                                   VoucherPartyName = n.VoucherPartyName,
                                                   AcCode2 = n.AcCode2,
                                                   ChequeNo = n.ChequeNo,
                                                   Dr_Amt = n.Dr_Amt,
                                                   Cr_Amt = n.Cr_Amt
                                               }).ToList()
                 }).ToListAsync();
            return result;
        }
   
    }
}