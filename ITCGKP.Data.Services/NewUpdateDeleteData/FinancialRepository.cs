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
using System.Threading.Tasks;

namespace ITCGKP.Data.Services.NewUpdateDeleteData
{
    public class FinancialRepository : VariableService, IFinancialRepository
    {
        string[] myzero = { "0000", "000", "00", "0" };
        string[] myTwozero = { "00", "0" };
        string[] myThreezero = { "000", "00", "0" };
        private readonly ApplicationDBContext _applicationDbContext = null;
        public FinancialRepository(ApplicationDBContext applicationDBContext)
        {
            _applicationDbContext = applicationDBContext;
        }
        // A/c Group Record
        public async Task<string> HeadGroupSrNoCreation()
        {
            var NewNo = ""; var NewValue = 0; CurrentIndex = 0;
            var result = await _applicationDbContext.HeadGroupTable
                      .OrderByDescending(x => x.Id)
                      .Select(x => x.HDGCode).FirstOrDefaultAsync();
            if (result != null)
            {
                NewValue = Convert.ToInt32(result) + 1;
                CurrentIndex = Convert.ToInt32(NewValue.ToString().Length) - 1;
                NewNo = CurrentIndex < 2 ? myTwozero[CurrentIndex] + (NewValue) : NewValue.ToString();
            }
            else
            {
                NewNo = "001";
            }
            return NewNo;
        }
        public async Task<int> AddNewAccountGroupMaster(AccountGroupViewModel model)
        {
            int LastNo = 0;
            if (model.Under_Name.Trim() == "Primary")
            {
                LastNo = await _applicationDbContext.HeadGroupTable.CountAsync() + 1;
            }
            else if (model.Under_Name.Trim() != "Primary")
            {
                LastNo = await _applicationDbContext.HeadGroupTable
                       .Where(x => x.Ledger_Name == model.Under_Name)
                       .Select(x => x.Id).FirstOrDefaultAsync();
            }
            AccountGroup newCate = new AccountGroup()
            {
                HDGCode = model.HDGCode,
                Ledger_Name = model.Ledger_Name,
                Under_Name = model.Under_Name,
                Nature = (int)model.Nature,
                TNo1 = LastNo,
                EffectGrossProfit = model.EffectGrossProfit
            };
            _applicationDbContext.Entry(newCate).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            return newCate.Id;
        }
        public async Task<bool> UpdateAccountGroupMaster(AccountGroupViewModel model)
        {
            int LastNo = 0;
            if (model.Under_Name.Trim() == "Primary")
            {
                LastNo = await _applicationDbContext.HeadGroupTable.Where(x => x.Id == model.Id).Select(x => x.Id).FirstOrDefaultAsync();
            }
            else if (model.Under_Name.Trim() != "Primary")
            {
                LastNo = await _applicationDbContext.HeadGroupTable
                       .Where(x => x.Ledger_Name == model.Under_Name)
                       .Select(x => x.Id).FirstOrDefaultAsync();
            }
            var result = await _applicationDbContext.HeadGroupTable.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (result != null)
            {
                result.Id = model.Id;
                result.HDGCode = model.HDGCode;
                result.Ledger_Name = model.Ledger_Name;
                result.Under_Name = model.Under_Name;
                result.Nature = (int)model.Nature;
                result.TNo1 = LastNo; result.EffectGrossProfit = model.EffectGrossProfit;
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return false;
        }
        public async Task<List<AccountGroupViewModel>> GetAllAccountGroupMaster(int id)
        {
            var result = await _applicationDbContext.HeadGroupTable
                .Where(x => ((id > 0) ? x.Id == id : true))
                .Select(x => new AccountGroupViewModel()
                {
                    Id = x.Id,
                    HDGCode = x.HDGCode,
                    Ledger_Name = x.Ledger_Name,
                    Under_Name = x.Under_Name,
                    Nature = (AccountNature)x.Nature,
                    EffectGrossProfit = x.EffectGrossProfit
                }).ToListAsync();
            return result;
        }
        public async Task<AccountGroupViewModel> GetAccountGroupMasterById(int id)
        {
            var result = await _applicationDbContext.HeadGroupTable.Select(x => new AccountGroupViewModel()
            {
                Id = x.Id,
                HDGCode = x.HDGCode,
                Ledger_Name = x.Ledger_Name,
                Under_Name = x.Under_Name,
                Nature = (AccountNature)x.Nature,
                EffectGrossProfit = x.EffectGrossProfit
            }).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<List<AccountGroupViewModel>> SearchAccountGroupUnderName(string searchName)
        {
            var result = await _applicationDbContext.HeadGroupTable
                .Where(x => x.Ledger_Name.Contains(searchName))
                .Select(x => new AccountGroupViewModel()
                {
                    Id = x.Id,
                    Under_Name = x.Ledger_Name
                }).ToListAsync();
            return result;
        }
        public async Task<bool> DeleteAccountGroupMaster(int id)
        {
            var result = await _applicationDbContext.HeadGroupTable.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                await _applicationDbContext.SaveChangesAsync();
            }
            return false;
        }       

        // Address Book Duplication Ledger Master 
        public async Task<string> AddressSrNoCreation(int? cmpdid)
        {
            var NewNo = ""; var NewValue = 0; var splitChar = "";
            var result1 = await _applicationDbContext.CompanyDetailTable.Where(x => x.Id == cmpdid).Select(x => new { x.TransCode }).FirstOrDefaultAsync();
            splitChar = result1.TransCode.Substring(3, 9) + "A";           
            var result = await _applicationDbContext.HeadTable
                          .OrderByDescending(x => x.LedgerMasterId).OrderByDescending(x => x.CompId)
                          .Where(x => x.CompId == cmpdid && x.AcGroupId != 29)
                          .Select(x => new {x.LedCode }).FirstOrDefaultAsync();

            if (result != null)
            {
                string parts1 = result.LedCode.Substring(10, 5);
                NewValue = Convert.ToInt32(parts1) + 1;
                CurrentIndex = Convert.ToInt32(NewValue.ToString().Length) - 1;
                NewNo = CurrentIndex < 5 ? splitChar + myzero[CurrentIndex] + (NewValue) : splitChar + NewValue.ToString();
            }
            else
            {
                NewNo = splitChar + "00001";
            }
            return NewNo;
        }
        public async Task<int> AddNewAddressMasterRecord(LedgerMasterViewModel models)
        {
            DateTime? Date1 = null;
            LedgerMaster ledgerMaster = new LedgerMaster()
            {               
                CompId = models.CompId,
                PartyName = models.PartyName,
                Address1 = models.Address1,
                Address2 = models.Address2,
                Address3 = models.Address3,
                City = models.City,
                PinNo = models.PinNo,
                LedStateId = Convert.ToInt32(models.LedStateId),
                EmailAddress = models.EmailAddress,
                PhoneNo = models.PhoneNo,
                MobileNo1 = models.MobileNo1,
                MobileNo2 = models.MobileNo2,
                PanNo = models.PanNo,
                AdharNo = models.AdharNo,
                AcGroupId = models.AcGroupId,
                DateOfBirth = string.IsNullOrEmpty(models.DateOfBirth) ? Date1 : Convert.ToDateTime(models.DateOfBirth), //Convert.ToDateTime(models.DateOfBirth),
                DateOfAnversary = string.IsNullOrEmpty(models.DateOfAnversary) ? Date1 : Convert.ToDateTime(models.DateOfAnversary), //Convert.ToDateTime(models.DateOfAnversary)
                OpnAmt = models.OpnAmt,
                OpnAc = (int)models.OpnAc,
                LedCode = models.LedCode
            };
            _applicationDbContext.Entry(ledgerMaster).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            return ledgerMaster.LedgerMasterId;
        }
        public async Task<bool> UpdateAddressMaster(LedgerMasterViewModel models)
        {
            DateTime? Date1 = null;
            var result = await _applicationDbContext.HeadTable.FirstOrDefaultAsync(x => x.LedgerMasterId == models.LedgerMasterId);
            if (result != null)
            {
                result.LedgerMasterId = models.LedgerMasterId;
                result.CompId = models.CompId;
                result.PartyName = models.PartyName;
                result.Address1 = models.Address1; result.Address2 = models.Address2;
                result.Address3 = models.Address3; result.City = models.City;
                result.PinNo = models.PinNo; result.LedStateId = Convert.ToInt32(models.LedStateId);
                result.EmailAddress = models.EmailAddress; result.PhoneNo = models.PhoneNo;
                result.MobileNo1 = models.MobileNo1; result.MobileNo2 = models.MobileNo2;
                result.PanNo = models.PanNo; result.AdharNo = models.AdharNo; result.AcGroupId = models.AcGroupId;
                result.DateOfBirth = string.IsNullOrEmpty(models.DateOfBirth) ? Date1 : Convert.ToDateTime(models.DateOfBirth); // Convert.ToDateTime(models.DateOfBirth) ;
                result.DateOfAnversary = string.IsNullOrEmpty(models.DateOfAnversary) ? Date1 : Convert.ToDateTime(models.DateOfAnversary);
                result.OpnAmt = models.OpnAmt; result.OpnAc = (int)models.OpnAc;
                result.LedCode = models.LedCode; 
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<LedgerMasterViewModel> GetAddressMasterById(int id)
        {
            var result = await _applicationDbContext.HeadTable
                .Select(x => new LedgerMasterViewModel()
                {
                    LedgerMasterId = x.LedgerMasterId,
                    CompId = x.CompId,
                    PartyName = x.PartyName,
                    Address1 = x.Address1,
                    Address2 = x.Address2,
                    Address3 = x.Address3,
                    City = x.City,
                    PinNo = x.PinNo,
                    LedStateId = x.LedStateId,
                    EmailAddress = x.EmailAddress,
                    PhoneNo = x.PhoneNo,
                    MobileNo1 = x.MobileNo1,
                    MobileNo2 = x.MobileNo2,
                    PanNo = x.PanNo,
                    AdharNo = x.AdharNo,
                    DateOfBirth = (x.DateOfBirth != null ? Convert.ToDateTime(x.DateOfBirth).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                    DateOfAnversary = (x.DateOfAnversary != null ? Convert.ToDateTime(x.DateOfAnversary).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                    OpnAmt = x !=null ? x.OpnAmt : 0,
                    OpnAc = x.OpnAc !=null ? (AccountDrCr)x.OpnAc : (AccountDrCr)2,
                    LedCode = x.LedCode,
                    AcGroupId = x.AcGroupId
                }).FirstOrDefaultAsync(x => x.LedgerMasterId == id);
            return result;
        }
        public async Task<bool> DeleteAddressMaster(int id)
        {
            var result2 = await _applicationDbContext.HeadTable.FirstOrDefaultAsync(x => x.LedgerMasterId == id);
            if (result2 != null)
            {
                _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            return false;
        }
        public async Task<List<LedgerMasterViewModel>> SearchAddressMasterUnderName(string searchName)
        {
            var result = await _applicationDbContext.HeadGroupTable
                .Where(x => x.Ledger_Name.Contains(searchName))
                .Select(x => new LedgerMasterViewModel()
                {
                    AcGroupId = x.Id
                        // AcGroupName = x.Ledger_Name
                    }).ToListAsync();
            return result;
        }
        public async Task<List<LedgerMasterViewModel>> GetAllAddressMaster(int cmdid)
        {
            var result = await _applicationDbContext.HeadTable
                    .OrderBy(x => x.CompId).ThenBy(x => x.PartyName)
                    .Where(x => x.CompId == cmdid)
                    .Select(x => new LedgerMasterViewModel()
                    {
                        LedgerMasterId = x.LedgerMasterId,
                        PartyName = x.PartyName,
                        Address1 = x.Address1,
                        City = x.City,
                        MobileNo1 = x.MobileNo1,
                        LedCode = x.LedCode,
                        AcGroupId = x.AcGroupId
                    }).ToListAsync();
            return result;
        }
        public async Task<List<LedgerMasterViewModel>> GetAllAddressMasterName(int cmdid, string partyname = "", string mobileno = "", string cityname = "")
        {
            var result = await _applicationDbContext.HeadTable
                     .OrderBy(x => x.PartyName).ThenBy(x => x.CompId)
                     .Where(x => x.CompId == cmdid && ((partyname != null) ? x.PartyName.Contains(partyname) : true)
                     && ((mobileno != null) ? x.MobileNo1.Contains(mobileno) : true)
                     && ((cityname != null) ? x.City.Contains(cityname) : true))
                     .Select(x => new LedgerMasterViewModel()
                     {
                         LedgerMasterId = x.LedgerMasterId,
                         PartyName = x.PartyName,
                         Address1 = x.Address1,
                         City = x.City,
                         MobileNo1 = x.MobileNo1,
                         LedCode = x.LedCode
                     }).ToListAsync();
            return result;
        }
        public async Task<int> GetIdLedgerMasterByCode(string id)
        {
            var result = await _applicationDbContext.HeadTable
                .Where(x => x.LedCode == id)
                .Select(x => x.LedgerMasterId).FirstOrDefaultAsync();
            return result;
        }      
        public async Task<List<LedgerMasterViewModel>> GetLedgerHelpFile(int compId)
        {
            var result = await _applicationDbContext.HeadTable
                     .OrderBy(x => x.PartyName)
                     .Where(x => x.CompId == compId)
                     .Select(x => new LedgerMasterViewModel()
                     {
                         LedgerMasterId = x.LedgerMasterId,
                         PartyName = x.PartyName,
                         Address1 = x.Address1,
                         City = x.City,
                         MobileNo1 = x.MobileNo1,
                         CloseAc = (AccountDrCr)x.CloseAc,
                         CloseAmt = x.CloseAmt,
                         LedCode = x.LedCode,
                         LedStateId = x.LedStateId
                     }).ToListAsync();
            return result;
        }
        public async Task<List<LedgerMasterViewModel>> SearchLedgerMasterByALLGroup(int compId)
        {
            var result = await _applicationDbContext.HeadTable
                .OrderBy(x => x.PartyName)
                .Where(x => x.CompId == compId)
                .Select(x => new LedgerMasterViewModel()
                {
                    LedgerMasterId = x.LedgerMasterId,
                    PartyName = x.PartyName
                }).ToListAsync();
            return result;
        }
        // Account Configuration Master File        
        public async Task<int> AddNewAccountConfigMasterRecord(AccountConfigViewModel model)
        {
            AccountConfig accountGroup = new AccountConfig()
            {
                CompId = model.CompId,
                SaleCode = model.SaleCode,
                CreditCode = model.CreditCode,
                PurCode = model.PurCode,
                DebitCode = model.DebitCode,
                FreightCode = model.FreightCode,
                FreightOut = model.FreightOut,
                CGSTCode = model.CGSTCode,
                SGSTCode = model.SGSTCode,
                IGSTCode = model.IGSTCode,
                CessCode = model.CessCode,
                DiscCode = model.DiscCode,
                DiscAllowed = model.DiscAllowed,
                CashCode = model.CashCode,
                DigitalCode = model.DigitalCode,
                AdvCode = model.AdvCode,
                CommissionCode = model.CommissionCode,
                ServiceCode = model.ServiceCode,
                ServiceOut = model.ServiceOut,
                StockCode = model.StockCode,
                ProfitCode = model.ProfitCode
            };
            _applicationDbContext.Entry(accountGroup).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            return accountGroup.Id;
        }
        public async Task<bool> UpdateAccountConfig(AccountConfigViewModel model)
        {
            var result = await _applicationDbContext.AccountConfigTable.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (result != null)
            {
                result.Id = model.Id;
                result.CompId = model.CompId;
                result.SaleCode = model.SaleCode;
                result.CreditCode = model.CreditCode;
                result.PurCode = model.PurCode;
                result.DebitCode = model.DebitCode;
                result.FreightCode = model.FreightCode;
                result.FreightOut = model.FreightOut;
                result.CGSTCode = model.CGSTCode;
                result.SGSTCode = model.SGSTCode;
                result.IGSTCode = model.IGSTCode;
                result.CessCode = model.CessCode;
                result.DiscCode = model.DiscCode;
                result.DiscAllowed = model.DiscAllowed;
                result.CashCode = model.CashCode;
                result.DigitalCode = model.DigitalCode;
                result.AdvCode = model.AdvCode;
                result.CommissionCode = model.CommissionCode;
                result.ServiceCode = model.ServiceCode;
                result.ServiceOut = model.ServiceOut;
                result.StockCode = model.StockCode;
                result.ProfitCode = model.ProfitCode;
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<AccountConfigViewModel> GetAccountConfigById(int id)
        {
            var result = await _applicationDbContext.AccountConfigTable
                .Select(x => new AccountConfigViewModel()
                {
                    Id = x.Id,
                    CompId = x.CompId,
                    SaleCode = x.SaleCode,
                    CreditCode = x.CreditCode,
                    PurCode = x.PurCode,
                    DebitCode = x.DebitCode,
                    FreightCode = x.FreightCode,
                    FreightOut = x.FreightOut,
                    CGSTCode = x.CGSTCode,
                    SGSTCode = x.SGSTCode,
                    IGSTCode = x.IGSTCode,
                    CessCode = x.CessCode,
                    DiscCode = x.DiscCode,
                    DiscAllowed = x.DiscAllowed,
                    CashCode = x.CashCode,
                    DigitalCode = x.DigitalCode,
                    AdvCode = x.AdvCode,
                    CommissionCode = x.CommissionCode,
                    ServiceCode = x.ServiceCode,
                    ServiceOut = x.ServiceOut,
                    StockCode = x.StockCode,
                    ProfitCode = x.ProfitCode
                }).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<List<AccountConfigViewModel>> GetALLAccountConfig(int compId)
        {
            var result = await _applicationDbContext.AccountConfigTable
                .Where(x => x.CompId == compId)
                .Select(x => new AccountConfigViewModel()
                {
                    Id = x.Id,
                    CompId = x.CompId,
                    CompanyDetailsView = new CompanyDetailViewModel()
                    {
                        TransCode = x.CompanyDetail.TransCode,
                        NameAddress = x.CompanyDetail.CompName + " " + x.CompanyDetail.Address1
                    },
                    SaleCode = x.SaleCode,
                    CreditCode = x.CreditCode,
                    PurCode = x.PurCode,
                    DebitCode = x.DebitCode,
                    FreightCode = x.FreightCode,
                    FreightOut = x.FreightOut,
                    CGSTCode = x.CGSTCode,
                    SGSTCode = x.SGSTCode,
                    IGSTCode = x.IGSTCode,
                    CessCode = x.CessCode,
                    DiscCode = x.DiscCode,
                    DiscAllowed = x.DiscAllowed,
                    CashCode = x.CashCode,
                    DigitalCode = x.DigitalCode,
                    AdvCode = x.AdvCode,
                    CommissionCode = x.CommissionCode,
                    ServiceCode = x.ServiceCode,
                    ServiceOut = x.ServiceOut
                }).ToListAsync();
            return result;
        }
        // Product Measurement Details
        public async Task<string> ProductMeasurementSrNoCreation()
        {
            var NewNo = ""; var NewValue = 0; CurrentIndex = 0;
            var result = await _applicationDbContext.UnitMeasurementTable
                  .OrderByDescending(x => x.Id)
                  .Select(x => x.UnitCode).FirstOrDefaultAsync();
            if (result != null)
            {
                NewValue = Convert.ToInt32(result) + 1;
                CurrentIndex = Convert.ToInt32(NewValue.ToString().Length) - 1;
                NewNo = CurrentIndex < 2 ? myTwozero[CurrentIndex] + (NewValue) : NewValue.ToString();
            }
            else
            {
                NewNo = "001";
            }
            return NewNo;
        }
        public async Task<int> AddNewProductMeasurementRecord(UnitMeasurementViewModel model)
        {
            UnitMeasurement itemGroup = new UnitMeasurement()
            {
                UnitCode = model.UnitCode,
                UnitName = model.UnitName,
                UQCId = model.UQCId
            };
            _applicationDbContext.Entry(itemGroup).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            return itemGroup.Id;
        }
        public async Task<bool> UpdateProductMeasurement(UnitMeasurementViewModel model)
        {
            var result = await _applicationDbContext.UnitMeasurementTable.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (result != null)
            {
                result.Id = model.Id;
                result.UnitName = model.UnitName;
                result.UnitCode = model.UnitCode;
                result.UQCId = model.UQCId;
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<UnitMeasurementViewModel> GetProductMeasurementById(int id)
        {
            var result = await _applicationDbContext.UnitMeasurementTable
                .Select(x => new UnitMeasurementViewModel()
                {
                    Id = x.Id,
                    UnitName = x.UnitName,
                    UnitCode = x.UnitCode,
                    UQCId = x.UQCId
                }).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<bool> DeleteProductMeasurement(int id)
        {
            var result2 = await _applicationDbContext.UnitMeasurementTable.FirstOrDefaultAsync(x => x.Id == id);
            if (result2 != null)
            {
                _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            return false;
        }
        public async Task<List<UnitMeasurementViewModel>> GetAllProductMeasurement()
        {
            var result = await _applicationDbContext.UnitMeasurementTable
                     .Select(x => new UnitMeasurementViewModel()
                     {
                         Id = x.Id,
                         UnitName = x.UnitName,
                         UnitCode = x.UnitCode,
                         UQCId = x.UQCId
                     }).ToListAsync();
            return result;
        }
        public async Task<List<UnitMeasurementViewModel>> GetAllProductMeasurementName()
        {
            var result = await _applicationDbContext.UnitMeasurementTable
                     .OrderBy(x => x.UnitName)
                     .Select(x => new UnitMeasurementViewModel()
                     {
                         Id = x.Id,
                         UnitName = x.UnitName,
                         UnitCode = x.UnitCode,
                         UQCId = x.UQCId
                     }).ToListAsync();
            return result;
        }
        public async Task<List<UnitMeasurementViewModel>> GetAllProductMeasurementName(string name)
        {
            var result = await _applicationDbContext.UnitMeasurementTable
                .Where(x => x.UnitName.Contains(name))
                .Select(x => new UnitMeasurementViewModel()
                {
                    Id = x.Id,
                    UnitName = x.UnitName,
                    UnitCode = x.UnitCode,
                    UQCId = x.UQCId
                }).ToListAsync();
            return result;
        }

        // UQC Master Table Details        
        public async Task<int> AddNewUQCRecord(UQCMasterViewModel model)
        {
            UQCMaster itemGroup = new UQCMaster()
            {
                Code = model.Code,
                Name = model.Name
            };
            _applicationDbContext.Entry(itemGroup).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            return itemGroup.Id;
        }
        public async Task<bool> UpdateUQC(UQCMasterViewModel model)
        {
            var result = await _applicationDbContext.UQCMasterTable.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (result != null)
            {
                result.Id = model.Id;
                result.Name = model.Name;
                result.Code = model.Code;
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<UQCMasterViewModel> GetUQCById(int id)
        {
            var result = await _applicationDbContext.UQCMasterTable
                .Select(x => new UQCMasterViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code
                }).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<bool> DeleteUQC(int id)
        {
            var result2 = await _applicationDbContext.UQCMasterTable.FirstOrDefaultAsync(x => x.Id == id);
            if (result2 != null)
            {
                _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            return false;
        }
        public async Task<List<UQCMasterViewModel>> GetAllUQC()
        {
            var result = await _applicationDbContext.UQCMasterTable
                     .Select(x => new UQCMasterViewModel()
                     {
                         Id = x.Id,
                         Name = x.Name,
                         Code = x.Code
                     }).ToListAsync();
            return result;
        }

        // Product Company Details
        public async Task<string> ProductCompanySrNoCreation()
        {
            var NewNo = ""; var NewValue = 0; CurrentIndex = 0;
            var result = await _applicationDbContext.ProductCompanyTable
                  .OrderByDescending(x => x.ProdId)
                  .Select(x => x.ProdCode).FirstOrDefaultAsync();
            if (result != null)
            {
                NewValue = Convert.ToInt32(result) + 1;
                CurrentIndex = Convert.ToInt32(NewValue.ToString().Length) - 1;
                NewNo = CurrentIndex < 2 ? myTwozero[CurrentIndex] + (NewValue) : NewValue.ToString();
            }
            else
            {
                NewNo = "001";
            }
            return NewNo;
        }
        public async Task<int> AddNewProductCompanyRecord(ProductCompanyViewModel model)
        {
            ProductCompany itemGroup = new ProductCompany()
            {
                ProdCode = model.ProdCode,
                ProdName = model.ProdName
            };
            _applicationDbContext.Entry(itemGroup).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            return itemGroup.ProdId;
        }
        public async Task<bool> UpdateProductCompany(ProductCompanyViewModel model)
        {
            var result = await _applicationDbContext.ProductCompanyTable.FirstOrDefaultAsync(x => x.ProdId == model.ProdId);
            if (result != null)
            {
                result.ProdId = model.ProdId;
                result.ProdName = model.ProdName;
                result.ProdCode = model.ProdCode;
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<ProductCompanyViewModel> GetProductCompanyById(int id)
        {
            var result = await _applicationDbContext.ProductCompanyTable
                .Select(x => new ProductCompanyViewModel()
                {
                    ProdId = x.ProdId,
                    ProdName = x.ProdName,
                    ProdCode = x.ProdCode
                }).FirstOrDefaultAsync(x => x.ProdId == id);
            return result;
        }
        public async Task<bool> DeleteProductCompany(int id)
        {
            var result2 = await _applicationDbContext.ProductCompanyTable.FirstOrDefaultAsync(x => x.ProdId == id);
            if (result2 != null)
            {
                _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            return false;
        }
        public async Task<List<ProductCompanyViewModel>> GetAllProductCompany()
        {
            var result = await _applicationDbContext.ProductCompanyTable
                     .Select(x => new ProductCompanyViewModel()
                     {
                         ProdId = x.ProdId,
                         ProdName = x.ProdName,
                         ProdCode = x.ProdCode
                     }).ToListAsync();
            return result;
        }
        public async Task<List<ProductCompanyViewModel>> GetAllProductCompanyName()
        {
            var result = await _applicationDbContext.ProductCompanyTable
                     .OrderBy(x => x.ProdName)
                     .Select(x => new ProductCompanyViewModel()
                     {
                         ProdId = x.ProdId,
                         ProdName = x.ProdName,
                         ProdCode = x.ProdCode
                     }).ToListAsync();
            return result;
        }
        public async Task<List<ProductCompanyViewModel>> GetAllProductCompanyName(string name)
        {
            var result = await _applicationDbContext.ProductCompanyTable
                .Where(x => x.ProdName.Contains(name))
                .Select(x => new ProductCompanyViewModel()
                {
                    ProdId = x.ProdId,
                    ProdName = x.ProdName,
                    ProdCode = x.ProdCode
                }).ToListAsync();
            return result;
        }

        // Item Group
        public async Task<string> ItemGroupSrNoCreation()
        {
            var NewNo = ""; var NewValue = 0; CurrentIndex = 0;
            var result = await _applicationDbContext.ItemGroupTable
                  .OrderByDescending(x => x.Id)
                  .Select(x => x.ItGPCode).FirstOrDefaultAsync();
            if (result != null)
            {
                NewValue = Convert.ToInt32(result) + 1;
                CurrentIndex = Convert.ToInt32(NewValue.ToString().Length) - 1;
                NewNo = CurrentIndex < 2 ? myTwozero[CurrentIndex] + (NewValue) : NewValue.ToString();
            }
            else
            {
                NewNo = "001";
            }
            return NewNo;
        }
        public async Task<int> AddNewItemGroupRecord(ItemGroupViewModel model)
        {
            ItemGroup itemGroup = new ItemGroup()
            {
                ItemGroupName = model.ItemGroupName,
                ItGPCode = model.ItGPCode,
                IHSNCode = model.IHSNCode,
                IGSTPer = model.IGSTPer,
                CGSTPer = model.CGSTPer,
                SGSTPer = model.SGSTPer,
                CessPer = model.CessPer
            };
            _applicationDbContext.Entry(itemGroup).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            return itemGroup.Id;
        }
        public async Task<bool> UpdateItemGroup(ItemGroupViewModel model)
        {
            var result = await _applicationDbContext.ItemGroupTable.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (result != null)
            {
                result.Id = model.Id;
                result.ItemGroupName = model.ItemGroupName;
                result.ItGPCode = model.ItGPCode;
                result.IHSNCode = model.IHSNCode;
                result.IGSTPer = model.IGSTPer;
                result.CGSTPer = model.CGSTPer;
                result.SGSTPer = model.SGSTPer;
                result.CessPer = model.CessPer;
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<ItemGroupViewModel> GetItemGroupById(int id)
        {
            var result = await _applicationDbContext.ItemGroupTable
                .Select(x => new ItemGroupViewModel()
                {
                    Id = x.Id,
                    ItemGroupName = x.ItemGroupName,
                    ItGPCode = x.ItGPCode,
                    IHSNCode = x.IHSNCode,
                    IGSTPer = x.IGSTPer,
                    CGSTPer = x.CGSTPer,
                    SGSTPer = x.SGSTPer,
                    CessPer = x.CessPer
                }).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<bool> DeleteItemGroup(int id)
        {
            var result2 = await _applicationDbContext.ItemGroupTable.FirstOrDefaultAsync(x => x.Id == id);
            if (result2 != null)
            {
                _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            return false;
        }
        public async Task<List<ItemGroupViewModel>> GetAllItemGroup()
        {
            var result = await _applicationDbContext.ItemGroupTable
                     .Select(x => new ItemGroupViewModel()
                     {
                         Id = x.Id,
                         ItemGroupName = x.ItemGroupName,
                         ItGPCode = x.ItGPCode,
                         IHSNCode = x.IHSNCode,
                         IGSTPer = x.IGSTPer,
                         CGSTPer = x.CGSTPer,
                         SGSTPer = x.SGSTPer,
                         CessPer = x.CessPer
                     }).ToListAsync();
            return result;
        }
        public async Task<List<ItemGroupViewModel>> GetAllItemGroupOrderName()
        {
            var result = await _applicationDbContext.ItemGroupTable
                     .OrderBy(x => x.ItemGroupName)
                     .Select(x => new ItemGroupViewModel()
                     {
                         Id = x.Id,
                         ItemGroupName = x.ItemGroupName,
                         ItGPCode = x.ItGPCode,
                         IHSNCode = x.IHSNCode,
                         IGSTPer = x.IGSTPer,
                         CGSTPer = x.CGSTPer,
                         SGSTPer = x.SGSTPer,
                         CessPer = x.CessPer
                     }).ToListAsync();
            return result;
        }
        public async Task<List<ItemGroupViewModel>> GetAllItemGroupByName(string name)
        {
            var result = await _applicationDbContext.ItemGroupTable
                .Where(x => x.ItemGroupName.Contains(name))
                .Select(x => new ItemGroupViewModel()
                {
                    Id = x.Id,
                    ItemGroupName = x.ItemGroupName,
                    ItGPCode = x.ItGPCode,
                    IHSNCode = x.IHSNCode,
                    IGSTPer = x.IGSTPer,
                    CGSTPer = x.CGSTPer,
                    SGSTPer = x.SGSTPer,
                    CessPer = x.CessPer
                }).ToListAsync();
            return result;
        }
        public async Task<int> GetAllIdItemGroupByName(string name)
        {
            var result = await _applicationDbContext.ItemGroupTable
                .Where(x => x.ItemGroupName == name)
                .Select(x => x.Id).FirstOrDefaultAsync();
            return result;
        }
        // Packing Master Record
        public async Task<string> PackingSrNoCreation()
        {
            var NewNo = ""; var NewValue = 0; CurrentIndex = 0;
            var result = await _applicationDbContext.PackingTable
                  .OrderByDescending(x => x.PackId)
                  .Select(x => x.PackCode).FirstOrDefaultAsync();
            if (result != null)
            {
                //string parts1 = result.Substring(0, 5);
                NewValue = Convert.ToInt32(result) + 1;
                CurrentIndex = Convert.ToInt32(NewValue.ToString().Length) - 1;
                NewNo = CurrentIndex < 2 ? myTwozero[CurrentIndex] + (NewValue) : NewValue.ToString();
            }
            else
            {
                NewNo = "001";
            }
            return NewNo;
        }
        public async Task<int> AddNewPackingRecord(PackingMasterViewModel model)
        {
            PackingMaster accountGroup = new PackingMaster()
            {
                PackName = model.PackName,
                PackCode = model.PackCode
            };
            _applicationDbContext.Entry(accountGroup).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            return accountGroup.PackId;
        }
        public async Task<bool> UpdatePackingMaster(PackingMasterViewModel model)
        {
            var result = await _applicationDbContext.PackingTable.FirstOrDefaultAsync(x => x.PackId == model.PackId);
            if (result != null)
            {
                result.PackId = model.PackId;
                result.PackName = model.PackName;
                result.PackCode = model.PackCode;
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<PackingMasterViewModel> GetPackingMasterById(int id)
        {
            var result = await _applicationDbContext.PackingTable
                .Select(x => new PackingMasterViewModel()
                {
                    PackId = x.PackId,
                    PackName = x.PackName,
                    PackCode = x.PackCode
                }).FirstOrDefaultAsync(x => x.PackId == id);
            return result;
        }
        public async Task<bool> DeletePackingMaster(int id)
        {
            var result2 = await _applicationDbContext.PackingTable.FirstOrDefaultAsync(x => x.PackId == id);
            if (result2 != null)
            {
                _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            return false;
        }
        public async Task<List<PackingMasterViewModel>> SearchPackingMasterName(string searchName)
        {
            var result = await _applicationDbContext.PackingTable
                    .Where(x => searchName != null ? x.PackName.Contains(searchName) : true)
                    .Select(x => new PackingMasterViewModel()
                    {
                        PackId = x.PackId,
                        PackName = x.PackName,
                        PackCode = x.PackCode
                    }).ToListAsync();
            return result;
        }
        public async Task<List<PackingMasterViewModel>> GetALLPackingMaster()
        {
            var result = await _applicationDbContext.PackingTable
                .Select(x => new PackingMasterViewModel()
                {
                    PackId = x.PackId,
                    PackName = x.PackName,
                    PackCode = x.PackCode
                }).ToListAsync();
            return result;
        }        
        public async Task<List<PackingMasterViewModel>> GetALLPackingMasterName(string name)
        {
            var result = await _applicationDbContext.PackingTable
                    .OrderBy(x => x.PackName)
                    .Where(x => x.PackName.Contains(name))
                    .Select(x => new PackingMasterViewModel()
                    {
                        PackId = x.PackId,
                        PackName = x.PackName,
                        PackCode = x.PackCode
                    }).ToListAsync();
            return result;
        }
        // Item Master File
        public async Task<string> ItemSrNoCreation()
        {
            var NewNo = ""; var NewValue = 0; CurrentIndex = 0;
            var result = await _applicationDbContext.ItemTable
                      .OrderByDescending(x => x.ItemId)
                      .Select(x => x.ItemCode).FirstOrDefaultAsync();
            if (result != null)
            {
                //string parts1 = result.Substring(0, 5);
                NewValue = Convert.ToInt32(result) + 1;
                CurrentIndex = Convert.ToInt32(NewValue.ToString().Length) - 1;
                NewNo = CurrentIndex < 3 ? myThreezero[CurrentIndex] + (NewValue) : NewValue.ToString();
            }
            else
            {
                NewNo = "0001";
            }
            return NewNo;
        }
        public async Task<int> AddNewItemMasterRecord(ItemMasterViewModel model)
        {
            ItemMaster accountGroup = new ItemMaster()
            {
                ItemCode = model.ItemCode,
                PackId = model.PackId,
                ItGPCode = model.ItGPCode,
                ProdId = model.ProdId,
                UnitId = model.UnitId,
                ItemName = model.ItemName,
                IHSNCode = model.IHSNCode,
                DiscPer = model.DiscPer,
                GSTPer = model.GSTPer,
                CessPer = model.CessPer,
                ProfitPer = model.ProfitPer,
                UnitCase = (int)model.UnitCase,
                ShowStock = (int)model.ShowStock,
                ReversCharge = (int)model.ReversCharge
            };
            _applicationDbContext.Entry(accountGroup).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            return accountGroup.ItemId;
        }
        public async Task<bool> UpdateItemMaster(ItemMasterViewModel model)
        {
            var result = await _applicationDbContext.ItemTable.FirstOrDefaultAsync(x => x.ItemId == model.ItemId);
            if (result != null)
            {
                result.ItemId = model.ItemId;
                result.ItemCode = model.ItemCode;
                result.PackId = model.PackId;
                result.ItGPCode = model.ItGPCode;
                result.ProdId = model.ProdId;
                result.UnitId = model.UnitId;
                result.ItemName = model.ItemName;
                result.IHSNCode = model.IHSNCode;
                result.DiscPer = model.DiscPer;
                result.GSTPer = model.GSTPer;
                result.CessPer = model.CessPer;
                result.ProfitPer = model.ProfitPer;
                result.UnitCase = (int)model.UnitCase;
                result.ShowStock = (int)model.ShowStock;
                result.ReversCharge = (int)model.ReversCharge;
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<ItemMasterViewModel> GetItemMasterById(int id)
        {
            var result = await _applicationDbContext.ItemTable
                    .Select(x => new ItemMasterViewModel()
                    {
                        ItemId = x.ItemId,
                        ItemCode = x.ItemCode,
                        PackId = x.PackId,
                        ItGPCode = x.ItGPCode,
                        ProdId = x.ProdId,
                        UnitId = x.UnitId,
                        ItemName = x.ItemName,
                        IHSNCode = x.IHSNCode,
                        DiscPer = x.DiscPer,
                        GSTPer = x.GSTPer,
                        CessPer = x.CessPer,
                        ProfitPer = x.ProfitPer,
                        UnitCase = x.UnitCase,
                        ShowStock = (StockTransfer)x.ShowStock,
                        ReversCharge = (ReverseCharged)x.ReversCharge
                    }).FirstOrDefaultAsync(x => x.ItemId == id);
            return result;
        }
        public async Task<bool> DeleteItemMaster(int id)
        {
            var result2 = await _applicationDbContext.ItemTable.FirstOrDefaultAsync(x => x.ItemId == id);
            if (result2 != null)
            {
                _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            return false;
        }
        public async Task<List<ItemMasterViewModel>> SearchItemMasterName(string searchName)
        {
            var result = await _applicationDbContext.ItemTable
                   .Where(x => (searchName != null ? x.ItemName.Contains(searchName) : true))
                   .OrderBy(x => x.ItemName)
                   .Select(x => new ItemMasterViewModel()
                   {
                       ItemId = x.ItemId,
                       ItemCode = x.ItemCode,
                       PackId = x.PackId,
                       PackingMasterViewModel = new PackingMasterViewModel()
                       {
                           PackId = x.PackingMaster.PackId,
                           PackCode = x.PackingMaster.PackCode,
                           PackName = x.PackingMaster.PackName
                       },
                       ItGPCode = x.ItGPCode,
                       ItemGroupViewModel = new ItemGroupViewModel()
                       {
                           Id = x.Itemdetails.Id,
                           ItGPCode = x.Itemdetails.ItGPCode,
                           ItemGroupName = x.Itemdetails.ItemGroupName
                       },
                       ProdId = x.ProdId,
                       ProductCompanyViewModel = new ProductCompanyViewModel()
                       {
                           ProdId = x.ProductCompany.ProdId,
                           ProdCode = x.ProductCompany.ProdCode,
                           ProdName = x.ProductCompany.ProdName
                       },
                       UnitId = x.UnitId,
                       UnitMeasurementViewModel = new UnitMeasurementViewModel()
                       {
                           Id = x.UnitMeasurement.Id,
                           UnitCode = x.UnitMeasurement.UnitCode,
                           UnitName = x.UnitMeasurement.UnitName
                       },
                       ItemName = x.ItemName,
                       IHSNCode = x.IHSNCode,
                       DiscPer = x.DiscPer,
                       GSTPer = x.GSTPer,
                       CessPer = x.CessPer,
                       ProfitPer = x.ProfitPer,
                       UnitCase = x.UnitCase,
                       ShowStock = (StockTransfer)x.ShowStock,
                       ReversCharge = (ReverseCharged)x.ReversCharge
                   }).ToListAsync();
            return result;
        }
        public async Task<List<ItemMasterViewModel>> GetALLItemMaster()
        {
            var result = await _applicationDbContext.ItemTable
                    .Select(x => new ItemMasterViewModel()
                    {
                        ItemId = x.ItemId,
                        ItemCode = x.ItemCode,
                        PackId = x.PackId,
                        PackingMasterViewModel = new PackingMasterViewModel()
                        {
                            PackName = x.PackingMaster.PackName
                        },
                        ItGPCode = x.ItGPCode,
                        ItemGroupViewModel = new ItemGroupViewModel()
                        {
                            ItemGroupName = x.Itemdetails.ItemGroupName
                        },
                        ProdId = x.ProdId,
                        ProductCompanyViewModel = new ProductCompanyViewModel()
                        {
                            ProdName = x.ProductCompany.ProdName
                        },
                        UnitId = x.UnitId,
                        UnitMeasurementViewModel = new UnitMeasurementViewModel()
                        {
                            UnitName = x.UnitMeasurement.UnitName
                        },
                        ItemName = x.ItemName,
                        IHSNCode = x.IHSNCode,
                        DiscPer = x.DiscPer,
                        GSTPer = x.GSTPer,
                        CessPer = x.CessPer,
                        ProfitPer = x.ProfitPer,
                        UnitCase = x.UnitCase,
                        ShowStock = (StockTransfer)x.ShowStock,
                        ReversCharge = (ReverseCharged)x.ReversCharge
                    }).ToListAsync();
            return result;
        }
        public async Task<List<ItemMasterViewModel>> GetALLItemMasterName(int itemGroupId, int prodid, string itemname = "", string prodcompanme = "", string hsncode = "")
        {
            var result = await _applicationDbContext.ItemTable
                .Where(x => (itemGroupId > 0 ? x.Itemdetails.Id == itemGroupId : true)
                && (prodid > 0 ? x.PackingMaster.PackId == prodid : true)
                && ((itemname != null) ? x.ItemName.Contains(itemname) : true)
                && ((prodcompanme != null) ? x.ProductCompany.ProdName.Contains(prodcompanme) : true)
                && ((hsncode != null) ? x.IHSNCode.Contains(hsncode) : true))
                   .OrderBy(x => x.ItemName)
                   .Select(x => new ItemMasterViewModel()
                   {
                       ItemId = x.ItemId,
                       ItemCode = x.ItemCode,
                       PackId = x.PackId,
                       PackingMasterViewModel = new PackingMasterViewModel()
                       {
                           PackName = x.PackingMaster.PackName
                       },
                       ItGPCode = x.ItGPCode,
                       ItemGroupViewModel = new ItemGroupViewModel()
                       {
                           ItemGroupName = x.Itemdetails.ItemGroupName
                       },
                       ProdId = x.ProdId,
                       ProductCompanyViewModel = new ProductCompanyViewModel()
                       {
                           ProdName = x.ProductCompany.ProdName
                       },
                       UnitId = x.UnitId,
                       UnitMeasurementViewModel = new UnitMeasurementViewModel()
                       {
                           UnitName = x.UnitMeasurement.UnitName
                       },
                       ItemName = x.ItemName,
                       IHSNCode = x.IHSNCode,
                       DiscPer = x.DiscPer,
                       GSTPer = x.GSTPer,
                       CessPer = x.CessPer,
                       ProfitPer = x.ProfitPer,
                       UnitCase = x.UnitCase,
                       ShowStock = (StockTransfer)x.ShowStock,
                       ReversCharge = (ReverseCharged)x.ReversCharge
                   }).ToListAsync();
            return result;
        }

        // Opening Item Stock
        public async Task<string> OpnSrNoCreation(int cmpid)
        {
            var NewNo = ""; var NewValue = 0; CurrentIndex = 0;
            var result = await _applicationDbContext.OpenItemMasterTable
                          .OrderByDescending(x => x.OpnId)
                          .Select(x => new { x.OpnVNo, x.CompId })
                          .FirstOrDefaultAsync(x => x.CompId == cmpid);
            if (result != null)
            {
                string[] parts1 = result.OpnVNo.Split('O');
                NewValue = Convert.ToInt32(parts1[1]) + 1;
                CurrentIndex = Convert.ToInt32(NewValue.ToString().Length) - 1;
                NewNo = CurrentIndex < 4 ? "O" + myzero[CurrentIndex] + (NewValue) : "O" + NewValue.ToString();
            }
            else
            {
                NewNo = "O00001";
            }
            return NewNo;
        }
        public async Task<int> AddNewOpenItemMaster(OpenItemMasterViewModel models)
        {
            // int stockId = await AddNewOpenStock(models);
            DateTime? Date1 = null;
            userdt = models.OpnDate.Split('/');
            userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            OpenItemMaster opnitemMaster = new OpenItemMaster()
            {
                UserCode = models.UserCode,
                CompId = models.CompId,
                OpnVNo = models.OpnVNo,
                OpnDate = string.IsNullOrEmpty(models.OpnDate) ? Date1 : Convert.ToDateTime(userdt1),
            };
            _applicationDbContext.Entry(opnitemMaster).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            foreach (var item in models.OpenItemMasterDetailViewModels)
            {
                Date1 = null; userdt = item.ExpDate.Split('/');
                userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
                OpenItemMasterDetail order = new OpenItemMasterDetail()
                {
                    OpnIMDId = item.OpnIMDId,
                    ItemCode = item.ItemCode,
                    ItemName = item.ItemName,
                    BatchNo = item.BatchNo,
                    ExpDate = string.IsNullOrEmpty(item.ExpDate) ? Date1 : Convert.ToDateTime(userdt1),
                    CasePcs = item.CasePcs,
                    FreePcs = item.FreePcs,
                    TotalPcs = item.TotalPcs,
                    PurRate = item.PurRate,
                    GSTPer = item.GSTPer,
                    MRP = item.MRP,
                    SaleRate = item.SaleRate,
                    NetPurRate = item.NetPurRate,
                    PurAmt = item.PurAmt,
                    NetPurAmt = item.NetPurAmt,
                    MRPAmt = item.MRPAmt,
                    CessPer = item.CessPer,
                    CessAmt = item.CessAmt,
                    UnitCase = item.UnitCase,
                    TempSrNo = (int)item.TempSrNo,
                    CompIdOpnItemMD = models.CompId,
                    UserCodeOpnItemMD = models.UserCode,
                    OpnVNoD = models.OpnVNo,
                    OpnIMId = opnitemMaster.OpnId
                };
                _applicationDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            await _applicationDbContext.SaveChangesAsync();
            return opnitemMaster.OpnId;
        }
        public async Task<bool> UpdateOpenItemMaster(OpenItemMasterViewModel models)
        {
            DateTime? Date1 = null;
            userdt = models.OpnDate.Split('/');
            userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            //int stockId = await AddNewOpenStock(models);            
            var result = await _applicationDbContext.OpenItemMasterTable.FirstOrDefaultAsync(n => n.OpnId == models.OpnId);
            if (result != null)
            {
                result.UserCode = models.UserCode;
                result.CompId = models.CompId;
                result.OpnVNo = models.OpnVNo;
                result.OpnDate = string.IsNullOrEmpty(models.OpnDate) ? Date1 : Convert.ToDateTime(userdt1); //Convert.ToDateTime(ledgerMasterViewModel.DateOfBirth),,              
            };
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();

            foreach (var item in models.OpenItemMasterDetailViewModels)
            {
                Date1 = null; userdt = item.ExpDate.Split('/');
                userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
                var result1 = await _applicationDbContext.OpenItemMasterDetailTable.FirstOrDefaultAsync(x => x.TempSrNo == item.TempSrNo && x.OpnIMId == models.OpnId);
                if (result1 != null)
                {
                    result1.ItemCode = item.ItemCode;
                    result1.ItemName = item.ItemName;
                    result1.BatchNo = item.BatchNo;
                    result1.ExpDate = string.IsNullOrEmpty(item.ExpDate) ? Date1 : Convert.ToDateTime(userdt1);
                    result1.CasePcs = item.CasePcs;
                    result1.FreePcs = item.FreePcs;
                    result1.TotalPcs = item.TotalPcs;
                    result1.PurRate = item.PurRate;
                    result1.GSTPer = item.GSTPer;
                    result1.MRP = item.MRP;
                    result1.SaleRate = item.SaleRate;
                    result1.NetPurRate = item.NetPurRate;
                    result1.PurAmt = item.PurAmt;
                    result1.NetPurAmt = item.NetPurAmt;
                    result1.MRPAmt = item.MRPAmt;
                    result1.CessPer = item.CessPer;
                    result1.CessAmt = item.CessAmt;
                    result1.UnitCase = item.UnitCase;
                    result1.TempSrNo = (int)item.TempSrNo;
                    //result1.CompIdOpnItemMD = item.CompIdOpnItemMD;
                    // result1.UserCodeOpnItemMD = item.UserCodeOpnItemMD;
                    // result1.OpnVNoD = item.OpnVNoD; result1.OpnIMId = item.OpnIMId;
                    _applicationDbContext.Entry(result1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                else
                {
                    OpenItemMasterDetail order = new OpenItemMasterDetail()
                    {
                        OpnIMDId = item.OpnIMDId,
                        ItemCode = item.ItemCode,
                        ItemName = item.ItemName,
                        BatchNo = item.BatchNo,
                        ExpDate = string.IsNullOrEmpty(item.ExpDate) ? Date1 : Convert.ToDateTime(userdt1),
                        CasePcs = item.CasePcs,
                        FreePcs = item.FreePcs,
                        TotalPcs = item.TotalPcs,
                        PurRate = item.PurRate,
                        GSTPer = item.GSTPer,
                        MRP = item.MRP,
                        SaleRate = item.SaleRate,
                        NetPurRate = item.NetPurRate,
                        PurAmt = item.PurAmt,
                        NetPurAmt = item.NetPurAmt,
                        MRPAmt = item.MRPAmt,
                        CessPer = item.CessPer,
                        CessAmt = item.CessAmt,
                        UnitCase = item.UnitCase,
                        TempSrNo = (int)item.TempSrNo,
                        CompIdOpnItemMD = result.CompId,
                        UserCodeOpnItemMD = result.UserCode,
                        OpnVNoD = result.OpnVNo,
                        OpnIMId = result.OpnId
                    };
                    _applicationDbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                }
            }
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<OpenItemMasterViewModel> GetOpenItemMasterById(int id)
        {
            var result = await _applicationDbContext.OpenItemMasterTable
                    .Select(x => new OpenItemMasterViewModel()
                    {
                        OpnId = x.OpnId,
                        CompId = x.CompId,
                        OpnVNo = x.OpnVNo,
                        UserCode = x.UserCode,
                        OpnDate = (x.OpnDate != null ? Convert.ToDateTime(x.OpnDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                        OpenItemMasterDetailViewModels = x.OpenItemMasterDetails.Where(a => a.OpnIMId == x.OpnId)
                        .OrderBy(a => a.TempSrNo)
                        .Select(n => new OpenItemMasterDetailViewModel()
                        {
                            TempSrNo = n.TempSrNo,
                            ItemCode = n.ItemCode,
                            ItemName = n.ItemName,
                            BatchNo = n.BatchNo,
                            ExpDate = (n.ExpDate != null ? Convert.ToDateTime(n.ExpDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                            CasePcs = n.CasePcs,
                            FreePcs = n.FreePcs,
                            TotalPcs = n.TotalPcs,
                            PurRate = n.PurRate,
                            MRP = n.MRP,
                            SaleRate = n.SaleRate,
                            NetPurRate = n.NetPurRate,
                            PurAmt = n.PurAmt,
                            NetPurAmt = n.NetPurAmt,
                            MRPAmt = n.MRPAmt,
                            GSTPer = n.GSTPer,
                            CessPer = n.CessPer,
                            CessAmt = n.CessAmt,
                            UnitCase = n.UnitCase
                        }).ToList()
                    }).FirstOrDefaultAsync(x => x.OpnId == id);
            return result;
        }
        public async Task<bool> DeleteOpenItemMaster(OpenItemMasterViewModel models)
        {
            //await DeleteItemStock(models.OpnVNo, models.UserCode, models.CompId);
            var result2 = await _applicationDbContext.OpenItemMasterTable.FirstOrDefaultAsync(x => x.OpnId == models.OpnId);
            if (result2 != null)
            {
                _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            return false;
        }
        public async Task<bool> DeleteOpenItemMasterOne(int id, int tno)
        {
            var result1 = await _applicationDbContext.OpenItemMasterDetailTable.FirstOrDefaultAsync(x => x.TempSrNo == tno && x.OpnIMId == id);
            if (result1 != null)
            {
                result1.OpnIMId = id;
                result1.TempSrNo = tno;
                //await  DeleteItemStockOneItem(result1.OpnVNoD, result1.ItemCode, result1.UserCodeOpnItemMD, result1.CompIdOpnItemMD);
                _applicationDbContext.Entry(result1).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            var No1 = 1;
            var result2 = await _applicationDbContext.OpenItemMasterDetailTable.OrderBy(x => x.TempSrNo).Where(x => x.OpnIMId == id).ToListAsync();
            foreach (var item in result2)
            {
                var result = await _applicationDbContext.OpenItemMasterDetailTable.FirstOrDefaultAsync(x => x.OpnIMDId == item.OpnIMDId);
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
        public async Task<List<OpenItemMasterViewModel>> GetALLOpenItemMasterDateWise(string uid, string StartDate, string EndDate)
        {
            bool isDataFormatCorrect1 = DateTime.TryParse(StartDate, out sdate);
            bool isDataFormatCorrect2 = DateTime.TryParse(EndDate, out edate);
            sdate = isDataFormatCorrect1 == true ? Convert.ToDateTime(StartDate).Date : DateTime.Today;
            edate = isDataFormatCorrect2 == true ? Convert.ToDateTime(EndDate).Date : DateTime.Today;
            //.Where(x=> ((uid.Length > 0) ? x.UserCode == uid : true) && x.OpnDate >= sdate && x.OpnDate <= edate)
            var result = await _applicationDbContext.OpenItemMasterTable
                .Where(x => x.UserCode == uid && x.OpnDate >= sdate && x.OpnDate <= edate)
                .OrderBy(x => x.CompId).ThenBy(x => x.UserCode).OrderByDescending(x => x.OpnDate).OrderByDescending(x => x.OpnVNo)
                .Select(x => new OpenItemMasterViewModel()
                {
                    OpnId = x.OpnId,
                    CompId = x.CompId,
                    CompanyDetailViewModel = new CompanyDetailViewModel()
                    {
                        CompName = x.CompanyDetail.CompName,
                        Address1 = x.CompanyDetail.Address1
                    },
                    UserCode = x.UserCode,
                    OpnVNo = x.OpnVNo,
                    OpnDate = (x.OpnDate != null ? Convert.ToDateTime(x.OpnDate).ToString("dd/MM/yyyy").Replace('-', '/') : null)
                }).ToListAsync();
            return result;
        }
        public async Task<List<OpenItemMasterViewModel>> SearchOpenItemMasterDateWise(int CmpId, string UCode, DateTime dt1, DateTime dt2)
        {
            var result = await _applicationDbContext.OpenItemMasterTable
                 .OrderBy(x => x.CompId).ThenBy(x => x.UserCode).ThenBy(x => x.OpnDate).ThenBy(x => x.OpnVNo)
                 .Where(x => (CmpId > 0 ? x.CompId == CmpId : true)
                  && (UCode != "0" ? x.UserCode == UCode : true)
                  && x.OpnDate >= dt1 && x.OpnDate <= dt2)
                 .Select(x => new OpenItemMasterViewModel()
                 {
                     OpnId = x.OpnId,
                     CompId = x.CompId,
                     CompanyDetailViewModel = new CompanyDetailViewModel()
                     {
                         CompName = x.CompanyDetail.CompName,
                         Address1 = x.CompanyDetail.Address1,
                         TransCode = x.CompanyDetail.TransCode
                     },
                     UserCode = x.UserCode,
                     OpnVNo = x.OpnVNo,
                     OpnDate = (x.OpnDate != null ? Convert.ToDateTime(x.OpnDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                     OpenItemMasterDetailViewModels = x.OpenItemMasterDetails.Where(a => a.OpnIMId == x.OpnId)
                        .OrderBy(a => a.TempSrNo)
                        .Select(n => new OpenItemMasterDetailViewModel()
                        {
                            TempSrNo = n.TempSrNo,
                            ItemCode = n.ItemCode,
                            ItemName = n.ItemName,
                            BatchNo = n.BatchNo,
                            ExpDate = (n.ExpDate != null ? Convert.ToDateTime(n.ExpDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                            CasePcs = n.CasePcs,
                            FreePcs = n.FreePcs,
                            TotalPcs = n.TotalPcs,
                            PurRate = n.PurRate,
                            MRP = n.MRP,
                            SaleRate = n.SaleRate,
                            NetPurRate = n.NetPurRate,
                            PurAmt = n.PurAmt,
                            NetPurAmt = n.NetPurAmt,
                            MRPAmt = n.MRPAmt,
                            GSTPer = n.GSTPer,
                            CessPer = n.CessPer,
                            CessAmt = n.CessAmt,
                            UnitCase = n.UnitCase,
                            OpnIMId = n.OpnIMId
                        }).ToList()
                 }).ToListAsync();
            return result;
        }
        public async Task<List<ItemStockViewModel>> SearchItemStockDateWise(int CmpId, int ProdCompId, int itemGroupId, int itemPackId, string itemname, string hsncode,DateTime dt1)
        {
            var result = await _applicationDbContext.ItemStockTable
                 .OrderBy(x => x.CompId).ThenBy(x => x.ItemCode)
                 .Where(x => (CmpId > 0 ? x.CompId == CmpId : true)
                  && (ProdCompId > 0 ? x.ItemMaster.ProdId == ProdCompId : true)
                  && (itemGroupId > 0 ? x.ItemMaster.ItGPCode == itemGroupId : true)
                  && (itemPackId > 0 ? x.ItemMaster.PackId == itemPackId : true)
                  && (itemname != null ? x.ItemMaster.ItemName.Contains(itemname) : true)
                  && (hsncode != null ? x.ItemMaster.IHSNCode.Contains(hsncode) : true)
                  && x.VouchDate <= dt1)
                 .Select(x => new ItemStockViewModel()
                 {
                     CompId = x.CompId,
                     CompanyDetailViewModel = new CompanyDetailViewModel()
                     {
                         CompName = x.CompanyDetail.CompName,
                         Address1 = x.CompanyDetail.Address1,
                         TransCode = x.CompanyDetail.TransCode
                     },
                     UserCode = x.UserCode,
                     ItemCode = x.ItemCode,
                     ItemMasterViewModel = new ItemMasterViewModel()
                     {
                         ItemId = x.ItemMaster.ItemId,
                         ItemName = x.ItemMaster.ItemName,
                         UnitCase = x.ItemMaster.UnitCase,
                         PackingMasterViewModel = new PackingMasterViewModel()
                         {
                             PackId = x.ItemMaster.PackingMaster.PackId,
                             PackName = x.ItemMaster.PackingMaster.PackName
                         },
                         ProductCompanyViewModel = new ProductCompanyViewModel()
                         {
                             ProdId = x.ItemMaster.ProductCompany.ProdId,
                             ProdName = x.ItemMaster.ProductCompany.ProdName
                         },
                         ItemGroupViewModel = new ItemGroupViewModel()
                         {
                             Id = x.ItemMaster.Itemdetails.Id,
                             ItemGroupName = x.ItemMaster.Itemdetails.ItemGroupName
                         }
                     },
                     OpnPCS = x.OpnPCS,
                     PurPCS = x.PurPCS,
                     PurRtPCS = x.PurRtPCS,
                     SalePCS = x.SalePCS,
                     SaleRtPCS = x.SaleRtPCS,
                     DiscAmt = x.OpnPCS + x.PurPCS + x.SaleRtPCS - x.SalePCS - x.PurRtPCS,
                     PurRate = x.PurRate,
                     MRP = x.MRP,
                     GSTPer = x.GSTPer
                 }).ToListAsync();
            var itemgroupfile = result.GroupBy(x => new { x.CompId, x.ItemCode, x.PurRate, x.GSTPer, x.MRP });
            List<ItemStockViewModel> ItemList = new List<ItemStockViewModel>();
            foreach (var item in itemgroupfile)
            {
                ItemList.Add(new ItemStockViewModel()
                {
                    CompId = item.Key.CompId,
                    ItemCode = item.Key.ItemCode,
                    ItemNamex = result.Where(x => x.CompId == item.Key.CompId && x.ItemCode == item.Key.ItemCode && x.PurRate == item.Key.PurRate && x.MRP == item.Key.MRP && x.GSTPer == item.Key.GSTPer).Select(x => x.ItemMasterViewModel.ItemName).FirstOrDefault(),
                    UnitCaseX = result.Where(x => x.CompId == item.Key.CompId && x.ItemCode == item.Key.ItemCode && x.PurRate == item.Key.PurRate && x.MRP == item.Key.MRP && x.GSTPer == item.Key.GSTPer).Select(x => x.ItemMasterViewModel.UnitCase).FirstOrDefault(),
                    Trancode = result.Where(x => x.CompId == item.Key.CompId && x.ItemCode == item.Key.ItemCode && x.PurRate == item.Key.PurRate && x.MRP == item.Key.MRP && x.GSTPer == item.Key.GSTPer).Select(x => x.CompanyDetailViewModel.TransCode).FirstOrDefault(),
                    OpnPCS = result.Where(x => x.CompId == item.Key.CompId && x.ItemCode == item.Key.ItemCode && x.PurRate == item.Key.PurRate && x.MRP == item.Key.MRP && x.GSTPer == item.Key.GSTPer).Sum(x => x.OpnPCS),
                    PurPCS = result.Where(x => x.CompId == item.Key.CompId && x.ItemCode == item.Key.ItemCode && x.PurRate == item.Key.PurRate && x.MRP == item.Key.MRP && x.GSTPer == item.Key.GSTPer).Sum(x => x.PurPCS),
                    PurRtPCS = result.Where(x => x.CompId == item.Key.CompId && x.ItemCode == item.Key.ItemCode && x.PurRate == item.Key.PurRate && x.MRP == item.Key.MRP && x.GSTPer == item.Key.GSTPer).Sum(x => x.PurRtPCS),
                    SalePCS = result.Where(x => x.CompId == item.Key.CompId && x.ItemCode == item.Key.ItemCode && x.PurRate == item.Key.PurRate && x.MRP == item.Key.MRP && x.GSTPer == item.Key.GSTPer).Sum(x => x.SalePCS),
                    SaleRtPCS = result.Where(x => x.CompId == item.Key.CompId && x.ItemCode == item.Key.ItemCode && x.PurRate == item.Key.PurRate && x.MRP == item.Key.MRP && x.GSTPer == item.Key.GSTPer).Sum(x => x.SaleRtPCS),
                    DiscAmt = result.Where(x => x.CompId == item.Key.CompId && x.ItemCode == item.Key.ItemCode && x.PurRate == item.Key.PurRate && x.MRP == item.Key.MRP && x.GSTPer == item.Key.GSTPer).Sum(x => x.DiscAmt), // For Bal Qty,
                    PurRate = item.Key.PurRate,
                    MRP = item.Key.MRP,
                    GSTPer = item.Key.GSTPer
                });
            }
            return ItemList;
        }
        public async Task<List<ItemBalanceViewModel>> SearchItemBalanceByItemId(int itemid,int cmpid)
        {
            var result = await _applicationDbContext.ItemBalanceTable
                   .Where(x => x.ItemCode == itemid && x.CompId == cmpid)
                   .OrderBy(x => x.ExpDate).ThenBy(x => x.BalQty)
                   .Select(x => new ItemBalanceViewModel()
                   {
                       CompId = x.CompId,
                       ItemCode = x.ItemCode,
                       BatchNo = x.BatchNo,
                       ExpDate = (x.ExpDate != null ? Convert.ToDateTime(x.ExpDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                       MRP = x.MRP,
                       PurRate = x.PurRate,
                       NetPurRate = x.NetPurRate,
                       SaleRate = x.SaleRate,
                       NetSaleRate = x.NetSaleRate,
                       GSTPer = x.GSTPer,
                       CessPer = x.CessPer,
                       OnFreeCase = x.OnFreeCase,
                       BalQty = x.BalQty
                   }).ToListAsync();
            return result;
        }
        public async Task<ItemBalanceViewModel> ItemBalanceAutomationAdd(int itemid, int cmpid)
        {
            var result = await _applicationDbContext.ItemBalanceTable
                   .Where(x => x.ItemCode == itemid && x.CompId == cmpid && x.BalQty > 0)
                   .OrderBy(x => x.BalQty)
                   .Select(x => new ItemBalanceViewModel()
                   {
                       CompId = x.CompId,
                       ItemCode = x.ItemCode,
                       BatchNo = x.BatchNo,
                       ExpDate = (x.ExpDate != null ? Convert.ToDateTime(x.ExpDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                       MRP = x.MRP,
                       PurRate = x.PurRate,
                       NetPurRate = x.NetPurRate,
                       SaleRate = x.SaleRate,
                       NetSaleRate = x.NetSaleRate,
                       GSTPer = x.GSTPer,
                       CessPer = x.CessPer,
                       OnFreeCase = x.OnFreeCase,
                       BalQty = x.BalQty
                   }).FirstOrDefaultAsync();
            return result;
        }
       
        public async Task<int> TransferPatientToVoucher(PatientViewModel models)
        {
            string resultTest = "";
            foreach (var item in models.PatientDetailsMasterViewModels)
            {
                resultTest = resultTest + item.TestMasterViewModels.TestCode + ",";
            }
            DateTime? Date1 = null;
            if (!string.IsNullOrEmpty(models.SDate))
            {
                userdt = models.SDate.Split('/');
                userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            }
            var result = await _applicationDbContext.AccountConfigTable.FirstOrDefaultAsync(x => x.CompId == models.CompId);
            if (result != null)
            {
                var resultService = await _applicationDbContext.HeadTable.FirstOrDefaultAsync(x => x.LedgerMasterId == result.ServiceCode);
                var resultCash = await _applicationDbContext.HeadTable.FirstOrDefaultAsync(x => x.LedgerMasterId == result.CashCode);
                var resultDisc = await _applicationDbContext.HeadTable.FirstOrDefaultAsync(x => x.LedgerMasterId == result.DiscAllowed);

                var resultServiceOut = await _applicationDbContext.HeadTable.FirstOrDefaultAsync(x => x.LedgerMasterId == result.ServiceOut);
                var resultCommission = await _applicationDbContext.HeadTable.FirstOrDefaultAsync(x => x.LedgerMasterId == result.CommissionCode);
                var resultAccount = await _applicationDbContext.HeadTable.FirstOrDefaultAsync(x => x.LedCode == models.DoctorAcCodeX);

                Voucher opnitemMaster = new Voucher()
                {
                    CompId = models.CompId,
                    UserCode = models.UserCode,
                    VType = "Payment",
                    VVNo = models.VNo,
                    VDate = string.IsNullOrEmpty(models.SDate) ? Date1 : Convert.ToDateTime(userdt1),
                    DrAmt = models.TotalAmt - models.DiscAmt,
                    CrAmt = 0
                };
                _applicationDbContext.Entry(opnitemMaster).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await _applicationDbContext.SaveChangesAsync();

                VoucherDetail order1 = new VoucherDetail()
                {
                    BookType = "Cash Book",
                    AcCode1 = resultAccount.LedgerMasterId,
                    AcCode2 = resultCash.LedgerMasterId,
                    Dr_Amt = 0,
                    Cr_Amt = models.DiscountType == "Doctor" ? models.TotalIPAmt - models.DiscAmt : models.TotalIPAmt,
                    TotalAmt = models.TotalAmt,
                    DiscAmt = models.DiscountType == "Doctor" ? models.DiscAmt : 0,
                    RefNo = models.RefNo,
                    PatientName = models.TitleName + " " + models.Name + " " + (int)models.Age + " " + models.AgeType + " / " + models.Sex,
                    Comments = resultTest,
                    TempSrNo = 1,
                    CompIdVItemMD = models.CompId,
                    UserCodeVItemMD = models.UserCode,
                    VVNoD = models.VNo,
                    VVType = "Cash Payment",
                    VIMId = opnitemMaster.VId,
                    CustAcCode1 = resultAccount.LedCode,
                    CustAcCode2 = resultCash.LedCode
                };
                _applicationDbContext.Entry(order1).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await _applicationDbContext.SaveChangesAsync();

                VoucherDetail order2 = new VoucherDetail()
                {
                    BookType = "Cash Book",
                    AcCode2 = resultAccount.LedgerMasterId,
                    AcCode1 = resultCash.LedgerMasterId,
                    Dr_Amt = models.TotalAmt - models.DiscAmt,
                    Cr_Amt = 0,
                    TotalAmt = models.TotalAmt,
                    DiscAmt = models.DiscAmt,
                    RefNo = models.RefNo,
                    PatientName = models.TitleName + " " + models.Name + " " + (int)models.Age + " " + models.AgeType + " / " + models.Sex,
                    Comments = resultTest,
                    TempSrNo = 2,
                    CompIdVItemMD = models.CompId,
                    UserCodeVItemMD = models.UserCode,
                    VVNoD = models.VNo,
                    VVType = "Cash Payment",
                    VIMId = opnitemMaster.VId,
                    CustAcCode2 = resultAccount.LedCode,
                    CustAcCode1 = resultCash.LedCode
                };
                _applicationDbContext.Entry(order2).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await _applicationDbContext.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<bool> TransferPatientToUpdateVoucher(PatientViewModel models)
        {
            string resultTest = "";
            foreach (var item in models.PatientDetailsMasterViewModels)
            {
                resultTest = resultTest + item.TestMasterViewModels.TestCode + ",";
            }
            var resultCash = await _applicationDbContext.HeadTable.FirstOrDefaultAsync(x => x.AcGroupId == 27);
            var resultAccount = await _applicationDbContext.HeadTable.FirstOrDefaultAsync(x => x.LedCode == models.DoctorAcCodeX);
            DateTime? Date1 = null;

            if (!string.IsNullOrEmpty(models.SDate))
            {
                userdt = models.SDate.Split('/');
                userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            }          

            var result = await _applicationDbContext.VoucherTable.FirstOrDefaultAsync(n => n.UserCode == models.UserCode && n.VVNo == models.VNo && n.CompId == models.CompId);
            if (result != null)
            {
                result.CompId = models.CompId;
                result.UserCode = models.UserCode;
                result.VType = "Payment";
                result.VVNo = models.VNo;
                result.VDate = string.IsNullOrEmpty(models.SDate) ? Date1 : Convert.ToDateTime(userdt1);
                result.DrAmt = models.TotalAmt - models.DiscAmt;
                result.CrAmt = 0;
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            };
            await _applicationDbContext.SaveChangesAsync();
            var result1 = await _applicationDbContext.VoucherDetailTable.FirstOrDefaultAsync(n => n.UserCodeVItemMD == models.UserCode && n.VVNoD == models.VNo && n.CompIdVItemMD == models.CompId && n.TempSrNo == 1);
            if (result1 != null)
            {
                result1.BookType = "Cash Book";
                result1.AcCode1 = resultAccount.LedgerMasterId;
                result1.AcCode2 = resultCash.LedgerMasterId;
                result1.Dr_Amt = 0;
                result1.Cr_Amt = models.DiscountType == "Doctor" ? models.TotalIPAmt - models.DiscAmt : models.TotalIPAmt;
                result1.TotalAmt = models.TotalAmt;
                result1.DiscAmt = models.DiscountType == "Doctor" ? models.DiscAmt : 0;
                result1.RefNo = models.RefNo;
                result1.PatientName = models.TitleName + " " + models.Name + " " + (int)models.Age + " " + models.AgeType + " / " + models.Sex;
                result1.Comments = resultTest;
                result1.TempSrNo = 1;
                result1.CompIdVItemMD = models.CompId;
                result1.UserCodeVItemMD = models.UserCode;
                result1.VVNoD = models.VNo;
                result1.VVType = "Cash Payment";
                result1.VIMId = result.VId;
                result1.CustAcCode1 = resultAccount.LedCode;
                result1.CustAcCode2 = resultCash.LedCode;
            _applicationDbContext.Entry(result1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            };
            await _applicationDbContext.SaveChangesAsync();
            var result2 = await _applicationDbContext.VoucherDetailTable.FirstOrDefaultAsync(n => n.UserCodeVItemMD == models.UserCode && n.VVNoD == models.VNo && n.CompIdVItemMD == models.CompId && n.TempSrNo == 2);
            if (result2 != null)
            {
                result2.BookType = "Cash Book";
                result2.AcCode2 = resultAccount.LedgerMasterId;
                result2.AcCode1 = resultCash.LedgerMasterId;
                result2.Dr_Amt = models.TotalAmt - models.DiscAmt;
                result2.Cr_Amt = 0;
                result2.TotalAmt = models.TotalAmt;
                result2.DiscAmt = models.DiscAmt;
                result2.RefNo = models.RefNo;
                result2.PatientName = models.TitleName + " " + models.Name + " " + (int)models.Age + " " + models.AgeType + " / " + models.Sex;
                result2.Comments = resultTest;
                result2.TempSrNo = 2;
                //result2.CompIdVItemMD = models.CompId;
                result2.UserCodeVItemMD = models.UserCode;
                result2.VVNoD = models.VNo;
                result2.VVType = "Cash Payment";
                result2.VIMId = result.VId;
                result2.CustAcCode2 = resultAccount.LedCode;
                result2.CustAcCode1 = resultCash.LedCode;
            _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            };
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeletePatientVoucher(string VchNo, string Userid, int? cmpid)
        {
            var result1 = await _applicationDbContext.VoucherTable.Where(x => x.VVNo == VchNo && x.UserCode == Userid && x.CompId == cmpid).FirstOrDefaultAsync();         
                if (result1 != null)
                {
                    var result2 = await _applicationDbContext.VoucherTable.FirstOrDefaultAsync(a => a.VId == result1.VId);
                        if (result2 != null)
                        {
                            _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                            _applicationDbContext.SaveChanges();
                        }
                }
            return false;
        }
        public async Task<List<VoucherViewModel>> GetVoucherIPDateWise(int cmpid,int DoctorId, DateTime FromDt, DateTime UptoDt)
        {           
            var result = await _applicationDbContext.VoucherTable.OrderBy(x => x.VDate)
                         .Where(x => (cmpid > 0 ? x.CompId == cmpid :true )
                          && x.VDate >= FromDt && x.VDate <= UptoDt)
                        .Select(x => new VoucherViewModel()
                        {
                           VId = x.VId,
                           CompId = x.CompId,
                           UserCode = x.UserCode,
                           VType = x.VType,
                           VVNo = x.VVNo,
                           VDate = (x.VDate != null ? Convert.ToDateTime(x.VDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                           VoucherDetailViewModels = x.VoucherDetails.Where(n => n.VIMId == x.VId
                                                && ((DoctorId > 0) ? n.AcCode1 == DoctorId  : true) &&  n.Cr_Amt > 0)
                                                .Select(n => new VoucherDetailViewModel() { 
                                                    VMDId = n.VMDId,
                                                    BookType = n.BookType,
                                                    AcCode1 = n.AcCode1,
                                                    AcCode2 = n.AcCode2,
                                                    ChequeNo = n.ChequeNo,
                                                    Dr_Amt = n.Dr_Amt,
                                                    Cr_Amt = n.Cr_Amt,
                                                    TempSrNo = n.TempSrNo,
                                                    TotalAmt = n.TotalAmt,
                                                    DiscAmt = n.DiscAmt,
                                                    RefNo = n.RefNo,
                                                    PatientName = n.PatientName,
                                                    Comments = n.Comments,
                                                    CompIdVItemMD = n.CompIdVItemMD,
                                                    UserCodeVItemMD = n.UserCodeVItemMD,
                                                    VVNoD = n.VVNoD,
                                                    VVType = n.VVType,
                                                    VIMId = n.VIMId,
                                                    CustAcCode1 = n.CustAcCode1,
                                                    CustAcCode2 = n.CustAcCode2
                                                }).ToList()
                        }).ToListAsync();
            return result;
        }
    }
}
