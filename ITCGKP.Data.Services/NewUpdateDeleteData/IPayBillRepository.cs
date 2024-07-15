using ITCGKP.Data.ViewModels.Master;
using ITCGKP.Data.ViewModels.PayBill;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITCGKP.Data.Services.NewUpdateDeleteData
{
    public interface IPayBillRepository
    {
        Task<int> AddNewPayBillRecord(UpdatePayBillViewModel model);
        Task<bool> UpdatePayBillRecord(UpdatePayBillViewModel model);
        Task<UpdatePayBillViewModel> GetPayBillById(int id);
        Task<bool> DeletePayBillRecord(int id);
        Task<bool> DeletePayBillOneMonthRecord(string PayUpotDate);
        Task<List<UpdatePayBillViewModel>> SearchPayBillDateWise(int CmpId, string userId, int empId, string custName, string mobno, decimal basicAmt, decimal totalpayAmt, decimal advAAmt, DateTime dt1, DateTime dt2);
        Task<UpdatePayBillViewModel> GetPayBillByEmpId(int id, string uptoDate);
        Task<bool> PayBillByEmpIdValid(int id, string uptoDate);
        Task<bool> PayBillByMonthValid(string uptoDate);
        Task<int> AutomationPayBill(OpenSearchViewModel model);
        Task<List<UpdatePayBillViewModel>> PayBillMonthly(string UptoMonth);
    }
}