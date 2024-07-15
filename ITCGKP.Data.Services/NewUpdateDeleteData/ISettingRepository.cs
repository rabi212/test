using ITCGKP.Data.ViewModels.Setting;
using ITCGKP.Data.ViewModels.Master;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITCGKP.Data.Services.NewUpdateDeleteData
{
    public interface ISettingRepository
    {
        Task<bool> IsExpDateValied(string Expdate);
        Task<string> DateTimeServer();
        Task<string> DateTimeServerYear();
        Task<string> DateTimeServerTime();
        //Titles Table
        Task<int> AddNewTitles(TitlesViewModel models);
        Task<bool> UpdateTitles(TitlesViewModel models);
        Task<List<TitlesViewModel>> GetAllTitles(int id);
        Task<TitlesViewModel> GetTitlesById(int id);
        Task<bool> DeleteTitles(int id);

        // Company Table
        Task<string> BranchSrNoCreation(int stateid, int districtid);
        Task<int> AddNewCompany(CompanyDetailViewModel models);
        Task<bool> UpdateCompany(CompanyDetailViewModel models);
        Task<List<CompanyDetailViewModel>> GetAllCompany(int id);
        Task<CompanyDetailViewModel> GetCompanyById(int id);
        Task<bool> DeleteCompany(int id);

        //State Table
        Task<int> AddNewState(StateViewModel models);
        Task<bool> UpdateState(StateViewModel models);
        Task<List<StateViewModel>> GetAllState(int id);
        Task<StateViewModel> GetStateById(int id);
        Task<bool> DeleteState(int id);

        //Didstrict Table
        Task<int> AddNewDistrict(DistrictViewModel models);
        Task<bool> UpdateDistrict(DistrictViewModel models);
        Task<List<DistrictViewModel>> GetAllDistrict(int id);
        Task<List<DistrictViewModel>> GetAllDistrictByState(int id);
        Task<DistrictViewModel> GetDistrictById(int id);
        Task<bool> DeleteDistrict(int id);
      

        // Money Master File
        Task<int> AddNewMoneyMaster(MoneyMasterViewModel models);
        Task<bool> UpdateMoneyMaster(MoneyMasterViewModel models);
        Task<MoneyMasterViewModel> GetMoneyMasterById(int id);
        Task<List<MoneyMasterViewModel>> GetALLMoneyMaster(int cmpid);

        // SMS Key Master File
        Task<int> AddNewSMSKey(SMSKeyViewModel models);
        Task<bool> UpdateSMSKey(SMSKeyViewModel models);
        Task<SMSKeyViewModel> GetSMSKeyById(int id);
        Task<List<SMSKeyViewModel>> GetALLSMSKey(int cmpid);

        // SMS File
        Task<int> AddNewSMSFile(SMSFileViewModel models);
        Task<bool> UpdateSMSFile(SMSFileViewModel models);
        Task<SMSFileViewModel> GetSMSFileById(int id);
        Task<List<SMSFileViewModel>> GetALLSMSFile(int cmpid);

        Task<string> SendSingleMessage(string phoneno, string messagedetails);

        // Upload Photo
        Task<int> AddNewUploadPhotoFile(UploadPhotoFrontViewModel models);
        Task<bool> UpdateUploadPhotoFile(UploadPhotoFrontViewModel models);
        Task<List<UploadPhotoFrontViewModel>> GetAllUploadPhotoFile();
        Task<UploadPhotoFrontViewModel> GetUploadPhotoFileById(int id);
        Task<bool> DeleteUploadPhoto(int id);
        Task<List<UploadPhotoFrontViewModel>> GetAllUploadPhotoFileFront();

        // Customer File      
        Task<int> AddNewAutoMessageRecord(string phoneNos, string msgtype);       
        Task<string> CheckMessageType(string type);

        // Custom Fonts File
        Task<int> AddNewFontCustom(FontCustomViewModel models);
        Task<bool> UpdateFontCustom(FontCustomViewModel models);
        Task<List<FontCustomViewModel>> GetAllFontCustom(int id);
        Task<FontCustomViewModel> GetFontCustomById(int id);
        Task<bool> DeleteFontCustom(int id);
    }
}