using ITCGKP.Data.Models.PayBill;
using ITCGKP.Data.ViewModels.Master;
using ITCGKP.Data.ViewModels.PayBill;
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
    public class PayBillRepository : VariableService, IPayBillRepository
    {
        string[] myzero = { "0000", "000", "00", "0" };
        string[] myTwozero = { "00", "0" };
        private readonly ApplicationDBContext _applicationDbContext = null;
        public PayBillRepository(ApplicationDBContext applicationDBContext)
        {
            _applicationDbContext = applicationDBContext;
        }
        // Pay Bill  File       
        public async Task<int> AddNewPayBillRecord(UpdatePayBillViewModel model)
        {
            DateTime? Date1 = null;
            if (!string.IsNullOrEmpty(model.VDate))
            {
                userdt = model.VDate.Split('/');
                userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            }
            UpdatePayBill opnitemMaster = new UpdatePayBill()
            {
                Id = model.Id,
                UserCode = model.UserCode,
                CompId = (int)model.CompId,
                EmpId = (int)model.EmpId,
                VDate = string.IsNullOrEmpty(model.VDate) ? Date1 : Convert.ToDateTime(userdt1),
                BasicPay = model.BasicPay,
                AttendDays = (int)model.AttendDays,
                NewBasicPay = model.NewBasicPay,
                DA = model.DA,
                TA = model.TA,
                HRA = model.HRA,
                CCA = model.CCA,
                IPAmt = model.IPAmt,
                BonusAmt = model.BonusAmt,
                Remarks = model.Remarks,
                TotalPay = model.TotalPay,
                EFP = model.EFP,
                AdvAmt = model.AdvAmt,
                AdvRemarks = model.AdvRemarks,
                LIC = model.LIC,
                TotalDedPay = model.TotalDedPay,
                NetPay = model.NetPay
            };
            _applicationDbContext.Entry(opnitemMaster).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            return opnitemMaster.Id;
        }
        public async Task<bool> UpdatePayBillRecord(UpdatePayBillViewModel model)
        {
            DateTime? Date1 = null;
            if (!string.IsNullOrEmpty(model.VDate))
            {
                userdt = model.VDate.Split('/');
                userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            }
            var result = await _applicationDbContext.PayBillTable.FirstOrDefaultAsync(n => n.Id == model.Id);
            if (result != null)
            {
                //result.Id = model.Id;
                //result.UserCode = model.UserCode;
                //result.CompId = (int)model.CompId;
                //result.EmpId = model.EmpId;
                result.VDate = string.IsNullOrEmpty(model.VDate) ? Date1 : Convert.ToDateTime(userdt1);
                result.BasicPay = model.BasicPay;
                result.AttendDays = (int)model.AttendDays;
                result.NewBasicPay = model.NewBasicPay;
                result.DA = model.DA;
                result.TA = model.TA;
                result.HRA = model.HRA;
                result.CCA = model.CCA;
                result.IPAmt = model.IPAmt;
                result.BonusAmt = model.BonusAmt;
                result.Remarks = model.Remarks;
                result.TotalPay = model.TotalPay;
                result.EFP = model.EFP;
                result.AdvAmt = model.AdvAmt;
                result.AdvRemarks = model.AdvRemarks;
                result.LIC = model.LIC;
                result.TotalDedPay = model.TotalDedPay;
                result.NetPay = model.NetPay;
            };
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<UpdatePayBillViewModel> GetPayBillById(int id)
        {
            var result = await _applicationDbContext.PayBillTable
                    .Select(x => new UpdatePayBillViewModel()
                    {
                        Id = x.Id,
                        UserCode = x.UserCode,
                        CompId = (int)x.CompId,
                        CompanyDetailViewModel = new  CompanyDetailViewModel()
                        {
                            CompName = x.CompanyDetail.CompName,
                            Address1 = x.CompanyDetail.Address1,
                            TransCode = x.CompanyDetail.TransCode
                        },
                        EmpId = x.EmpId,
                        AgentFileViewModel = new AgentFileViewModel()
                        {
                            Code = x.AgentFile.Code,
                            Name = x.AgentFile.Name,
                            Address1 = x.AgentFile.Address1,
                            MobileNo = x.AgentFile.MobileNo
                        },
                        VDate = (x.VDate != null ? Convert.ToDateTime(x.VDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                        BasicPay = x.BasicPay,
                        AttendDays = x.AttendDays,
                        NewBasicPay = x.NewBasicPay,
                        DA = x.DA,
                        TA = x.TA,
                        HRA = x.HRA,
                        CCA = x.CCA,
                        IPAmt = x.IPAmt,
                        BonusAmt = x.BonusAmt,
                        Remarks = x.Remarks,
                        TotalPay = x.TotalPay,
                        EFP = x.EFP,
                        AdvAmt = x.AdvAmt,
                        AdvRemarks = x.AdvRemarks,
                        LIC = x.LIC,
                        TotalDedPay = x.TotalDedPay,
                        NetPay = x.NetPay
                    }).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<bool> DeletePayBillRecord(int id)
        {
            var result2 = await _applicationDbContext.PayBillTable.FirstOrDefaultAsync(x => x.Id == id);
            if (result2 != null)
            {
                _applicationDbContext.Entry(result2).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _applicationDbContext.SaveChanges();
            }
            return false;
        }
        public async Task<List<UpdatePayBillViewModel>> SearchPayBillDateWise(int CmpId, string userId, int empId, string custName, string mobno, decimal basicAmt, decimal totalpayAmt, decimal advAAmt, DateTime dt1, DateTime dt2)
        {
            var result = await _applicationDbContext.PayBillTable
                 .Where(x => (CmpId > 0 ? x.CompId == CmpId : true)
                 && (userId != "0" ? x.UserCode == userId : true)
                 && (empId != 0 ? x.EmpId == empId : true)
                 && (custName != null ? x.AgentFile.Name.Contains(custName) : true)
                 && (mobno != null ? x.AgentFile.MobileNo.Contains(mobno) : true)
                 && (basicAmt > 0 ? x.BasicPay == basicAmt : true)
                 && (totalpayAmt > 0 ? x.TotalPay == totalpayAmt : true)
                 && (advAAmt > 0 ? x.AdvAmt == advAAmt : true)
                 && x.VDate >= dt1 && x.VDate <= dt2)
                 .OrderBy(x => x.CompId).ThenBy(x => x.UserCode).ThenBy(x => x.VDate)
                 .Select(x => new UpdatePayBillViewModel()
                 {
                     Id = x.Id,
                     UserCode = x.UserCode,
                     CompId = (int)x.CompId,
                     CompanyDetailViewModel = new CompanyDetailViewModel()
                     {
                         CompName = x.CompanyDetail.CompName,
                         Address1 = x.CompanyDetail.Address1,
                         TransCode = x.CompanyDetail.TransCode
                     },
                     EmpId = x.EmpId,
                     AgentFileViewModel = new AgentFileViewModel()
                     {
                         Code = x.AgentFile.Code,
                         Name = x.AgentFile.Name,
                         Address1 = x.AgentFile.Address1,
                         MobileNo = x.AgentFile.MobileNo
                     },
                     VDate = (x.VDate != null ? Convert.ToDateTime(x.VDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                     BasicPay = x.BasicPay,
                     AttendDays = x.AttendDays,
                     NewBasicPay = x.NewBasicPay,
                     DA = x.DA,
                     TA = x.TA,
                     HRA = x.HRA,
                     CCA = x.CCA,
                     IPAmt = x.IPAmt,
                     BonusAmt = x.BonusAmt,
                     Remarks = x.Remarks,
                     TotalPay = x.TotalPay,
                     EFP = x.EFP,
                     AdvAmt = x.AdvAmt,
                     AdvRemarks = x.AdvRemarks,
                     LIC = x.LIC,
                     TotalDedPay = x.TotalDedPay,
                     NetPay = x.NetPay
                 }).ToListAsync();
            return result;
        }

        public async Task<bool> DeletePayBillOneMonthRecord(string PayUpotDate)
        {
            if (!string.IsNullOrEmpty(PayUpotDate))
            {
                userdt = PayUpotDate.Split('/');
                userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            }
            var result2 = await _applicationDbContext.PayBillTable.Where(x => 
                                     x.VDate.Value.Month == Convert.ToInt32(userdt[1])
                                    && x.VDate.Value.Year == Convert.ToInt32(userdt[2])
                                    ).ToListAsync();
            if (result2 != null)
            {
                foreach (var item in result2)
                {
                    var result1 = await _applicationDbContext.PayBillTable.Where(x => x.EmpId == item.EmpId
                                    && x.VDate.Value.Month == Convert.ToInt32(userdt[1])
                                    && x.VDate.Value.Year == Convert.ToInt32(userdt[2])).FirstOrDefaultAsync();
                    _applicationDbContext.Entry(result1).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    _applicationDbContext.SaveChanges();
                }                
            }
            return false;
        }
        public async Task<UpdatePayBillViewModel> GetPayBillByEmpId(int id,string uptoDate)
        {
            if (!string.IsNullOrEmpty(uptoDate))
            {
                userdt = uptoDate.Split('/');
                userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            }
            var resultAgent = await _applicationDbContext.AgentFileTable.FirstOrDefaultAsync(x => x.Id == id);
            
            int IPAmt = Convert.ToInt32(resultAgent.IPAmt1); int AdvAmt = 0;            

            AdvAmt =  0;

            var result = await _applicationDbContext.PayBillTable
                    .OrderBy(x => x.Id).ThenBy(x => x.EmpId)
                    .Select(x => new UpdatePayBillViewModel()
                    {                     
                        EmpId = x.EmpId,
                        BasicPay = x.BasicPay,
                        NewBasicPay = x.NewBasicPay,
                        DA = x.DA,
                        TA = 0,
                        HRA = x.HRA,
                        CCA = x.CCA,
                        IPAmt = IPAmt,
                        BonusAmt = 0,
                        Remarks = x.Remarks,
                        TotalPay = x.NewBasicPay + x.DA + x.HRA + x.CCA  + IPAmt,
                        EFP = x.EFP,
                        AdvAmt = AdvAmt,
                        AdvRemarks = x.AdvRemarks,
                        LIC = x.LIC,
                        TotalDedPay = x.EFP + x.LIC  + AdvAmt,
                        NetPay = x.NewBasicPay + x.DA + x.HRA + x.CCA + IPAmt - x.EFP - x.LIC - AdvAmt
                    }).LastOrDefaultAsync(x => x.EmpId == id);

            var result1 = await _applicationDbContext.AgentFileTable
                    .Where(x => x.Id == id)
                    .Select(x => new UpdatePayBillViewModel()
                    {                        
                        BasicPay = x.BasicPay,
                        NewBasicPay = x.BasicPay,
                        DA = x.DA,
                        TA = x.TA ,
                        HRA = x.HRA,
                        CCA = x.CCA,
                        IPAmt = IPAmt ,
                        BonusAmt = 0,
                        TotalPay = x.BasicPay + x.DA + x.HRA + x.CCA + x.TA + IPAmt,
                        EFP = 0,
                        AdvAmt = AdvAmt,                        
                        LIC = 0,
                        TotalDedPay = AdvAmt,
                        NetPay = x.BasicPay + x.DA + x.HRA + x.CCA + x.TA + IPAmt - AdvAmt
                    }).FirstOrDefaultAsync();
            return result !=null ? result : result1;
        }
        public async Task<bool> PayBillByEmpIdValid(int id, string uptoDate)
        {
            if (!string.IsNullOrEmpty(uptoDate))
            {
                userdt = uptoDate.Split('/');
                userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            }
            var result = await _applicationDbContext.PayBillTable
                        .Where(x => x.EmpId == id  && x.VDate.Value.Month == Convert.ToInt32(userdt[1]) 
                        && x.VDate.Value.Year == Convert.ToInt32(userdt[2])).FirstOrDefaultAsync();
            return result != null ? true : false;
        }
        public async Task<bool> PayBillByMonthValid(string uptoDate)
        {
            if (!string.IsNullOrEmpty(uptoDate))
            {
                userdt = uptoDate.Split('/');
                userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            }
            var result = await _applicationDbContext.PayBillTable
                        .Where(x => x.VDate.Value.Month == Convert.ToInt32(userdt[1])
                        && x.VDate.Value.Year == Convert.ToInt32(userdt[2])).FirstOrDefaultAsync();
            return result != null ? true : false;
        }
        public async Task<int> AutomationPayBill(OpenSearchViewModel model)
        {
            if (!string.IsNullOrEmpty(model.PayUptoDate))
            {
                userdt = model.PayUptoDate.Split('/');
                userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            }
            var resultAgent = await _applicationDbContext.AgentFileTable.Where(x => x.ActiveType == true).ToListAsync();

            foreach (var item in resultAgent)
            {   

                int IPAmt = Convert.ToInt32(item.IPAmt1) ; int AdvAmt = 0;                                
                var result = await _applicationDbContext.PayBillTable
                            .OrderBy(x => x.Id).ThenBy(x => x.EmpId).LastOrDefaultAsync(x => x.EmpId == item.Id);
                if (result != null)
                {
                    UpdatePayBill opnitemMaster = new UpdatePayBill()
                    {
                        Id = 0,
                        UserCode = model.UserId,
                        CompId = (int)model.CompId,
                        EmpId = item.Id,
                        VDate =  Convert.ToDateTime(userdt1),
                        BasicPay = result.BasicPay,
                        AttendDays = (int)model.PayBillDays,
                        NewBasicPay = result.BasicPay,
                        DA = result.DA,
                        TA = 0,
                        HRA = result.HRA,
                        CCA = result.CCA,
                        IPAmt = IPAmt,
                        BonusAmt = 0,
                        Remarks = " ",
                        TotalPay = result.BasicPay + result.DA + result.HRA + result.CCA + IPAmt,
                        EFP = result.EFP,
                        AdvAmt = AdvAmt,
                        AdvRemarks = " ",
                        LIC = result.LIC,
                        TotalDedPay = result.EFP + AdvAmt + result.LIC,
                        NetPay = result.BasicPay + result.DA + result.HRA + result.CCA + IPAmt - (result.EFP + AdvAmt + result.LIC)                        
                    };
                    _applicationDbContext.Entry(opnitemMaster).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    await _applicationDbContext.SaveChangesAsync();
                }
                else
                {
                    UpdatePayBill opnitemMaster = new UpdatePayBill()
                    {
                        Id = 0,
                        UserCode = model.UserId,
                        CompId = (int)model.CompId,
                        EmpId = item.Id,
                        VDate = Convert.ToDateTime(userdt1),
                        BasicPay = item.BasicPay,
                        AttendDays = (int)model.PayBillDays,
                        NewBasicPay = item.BasicPay,
                        DA = item.DA,
                        TA = 0,
                        HRA = item.HRA,
                        CCA = item.CCA,
                        IPAmt = IPAmt,
                        BonusAmt = 0,
                        Remarks = " ",
                        TotalPay = item.BasicPay + item.DA + item.HRA + item.CCA + IPAmt,
                        EFP = 0,
                        AdvAmt = AdvAmt,
                        AdvRemarks = " ",
                        LIC = 0,
                        TotalDedPay =  AdvAmt,
                        NetPay = item.BasicPay + item.DA + item.HRA + item.CCA + IPAmt - AdvAmt
                    };
                    _applicationDbContext.Entry(opnitemMaster).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    await _applicationDbContext.SaveChangesAsync();
                }
            }            
            return 1;
        }
        public async Task<List<UpdatePayBillViewModel>> PayBillMonthly(string UptoMonth)
        {
            if (!string.IsNullOrEmpty(UptoMonth))
            {
                userdt = UptoMonth.Split('/');
                userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            }
            var result = await _applicationDbContext.PayBillTable
                    .Where(x => x.VDate.Value.Month == Convert.ToInt32(userdt[1]) 
                    && x.VDate.Value.Year == Convert.ToInt32(userdt[2]))
                    .Select(x => new UpdatePayBillViewModel()
                    {
                        Id = x.Id,
                        UserCode = x.UserCode,
                        CompId = (int)x.CompId,
                        CompanyDetailViewModel = new CompanyDetailViewModel()
                        {
                            CompName = x.CompanyDetail.CompName,
                            Address1 = x.CompanyDetail.Address1,
                            TransCode = x.CompanyDetail.TransCode
                        },
                        EmpId = x.EmpId,
                        AgentFileViewModel = new AgentFileViewModel()
                        {
                            Code = x.AgentFile.Code,
                            Name = x.AgentFile.Name,
                            Address1 = x.AgentFile.Address1,
                            MobileNo = x.AgentFile.MobileNo,
                            EmailAddress = x.AgentFile.EmailAddress,
                            PinNo = x.AgentFile.PinNo,
                            BankName = x.AgentFile.BankName,
                            BankAcNo = x.AgentFile.BankAcNo,
                            IFSC = x.AgentFile.IFSC
                        },
                        VDate = (x.VDate != null ? Convert.ToDateTime(x.VDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                        BasicPay = x.BasicPay,
                        AttendDays = x.AttendDays,
                        NewBasicPay = x.NewBasicPay,
                        DA = x.DA,
                        TA = x.TA,
                        HRA = x.HRA,
                        CCA = x.CCA,
                        IPAmt = x.IPAmt,
                        BonusAmt = x.BonusAmt,
                        Remarks = x.Remarks,
                        TotalPay = x.TotalPay,
                        EFP = x.EFP,
                        AdvAmt = x.AdvAmt,
                        AdvRemarks = x.AdvRemarks,
                        LIC = x.LIC,
                        TotalDedPay = x.TotalDedPay,
                        NetPay = x.NetPay
                    }).ToListAsync();
            return result;
        }
    }
}