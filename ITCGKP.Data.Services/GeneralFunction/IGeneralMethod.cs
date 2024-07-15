using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITCGKP.Data.Services.GeneralFunction
{
    public interface IGeneralMethod
    {
        Task<List<SelectListItem>> StoreFontSize();
        Task<List<SelectListItem>> StoreFontStyle();
        Task<List<SelectListItem>> StoreFontWeight();
        Task<List<SelectListItem>> StoreLineHeight();
        Task<List<SelectListItem>> StoreFontColor();
        Task<List<SelectListItem>> StoreFontDecorate();
        Task<string> SendSingleMessage(string phoneno, string messagedetails);
        Task<string> SenderSMTEmail(string emailaddress, string subjects, string bodys);
        Task<string> Customizedwords(double numbers);
        Task<string> UppercaseFirstEach(string s);
        Task<string> UppercaseFirst(string s);      
    }
}