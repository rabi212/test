using ITCGKP.Data.Models;
using ITCGKP.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.IO;
using System.Net;
using System.Web;
using System.Collections.Specialized;
using ITCGKP.Data.ViewModels.Setting;
using ITCGKP.Data.ViewModels.Master;
using ITCGKP.Data.Models.Setting;
using ITCGKP.Data.Models.Master;

namespace ITCGKP.Data.Services.NewUpdateDeleteData
{
    public class SettingRepository : VariableService,  ISettingRepository
    {      
        private readonly ApplicationDBContext _applicationDbContext = null;
        public SettingRepository(ApplicationDBContext applicationDBContext)
        {
            _applicationDbContext = applicationDBContext;
        }
        public async Task<bool> IsExpDateValied(string Expdate)
        {
            if (await Task.FromResult(Expdate == null))
            {
                return false;
            }
            else
            {
                string[] sdate = Expdate.Split('/');
                DateTime tempDate;
                bool isCorrectFormat = DateTime.TryParse((sdate[2] + '-' + sdate[1] + '-' + sdate[0]).ToString(), out tempDate);
                return isCorrectFormat == true ? true : false;
            }
        }
        public async Task<string> DateTimeServer()
        {
            return await Task.FromResult(DateTime.Now.ToString("dd/MM/yyyy").Replace("-", "/"));
        }
        public async Task<string> DateTimeServerYear()
        {
            return await Task.FromResult(DateTime.Now.ToString("yyyy"));
        }
        public async Task<string> DateTimeServerTime()
        {
            return await Task.FromResult(DateTime.Now.ToString("hh:mm tt"));
        }
        public async Task<int> AddNewTitles(TitlesViewModel models)
        {
            Titles newState = new Titles()
            {
                Name = models.Name
            };
            //await _applicationDbContext.CompanyDetailTable.AddAsync(newCompany);
            _applicationDbContext.Entry(newState).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            return newState.Id;
        }
        public async Task<bool> UpdateTitles(TitlesViewModel models)
        {
            var result = await _applicationDbContext.TitlesTable.FirstOrDefaultAsync(x => x.Id == models.Id);
            if (result != null)
            {
                result.Id = models.Id;
                result.Name = models.Name;
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return false;
        }
        public async Task<List<TitlesViewModel>> GetAllTitles(int id)
        {
            var result = await _applicationDbContext.TitlesTable
                .Where(x => ((id > 0) ? x.Id == id : true))
                .Select(x => new TitlesViewModel()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();
            return result;
        }
        public async Task<TitlesViewModel> GetTitlesById(int id)
        {
            var result = await _applicationDbContext.TitlesTable.Select(x => new TitlesViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<bool> DeleteTitles(int id)
        {
            var result = await _applicationDbContext.TitlesTable.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                await _applicationDbContext.SaveChangesAsync();
            }
            return false;
        }
        public async Task<string> BranchSrNoCreation(int stateid,int districtid)
        {
            string stid = "";string disid = "";
            stid = stateid < 10 ? "0" + stateid : stateid.ToString();
            disid = districtid < 10 ? "00" + districtid :(districtid >=10 && districtid < 100 ? "0"+ districtid : districtid.ToString());
            var NewNo = ""; var NewValue = 0; var splitChar = "ITC" + stid + disid;
            string[] myzero = { "000", "00", "0" };
            var result = await _applicationDbContext.CompanyDetailTable
                          .OrderByDescending(x => x.Id)
                          .Where(x => x.StateId == stateid && x.DistId == districtid)
                          .Select(x => new { x.TransCode }).FirstOrDefaultAsync();

            if (result != null)
            {
                string parts1 = result.TransCode.Substring(8, 4);
                NewValue = Convert.ToInt32(parts1) + 1;
                CurrentIndex = Convert.ToInt32(NewValue.ToString().Length) - 1;
                NewNo = CurrentIndex < 4 ? splitChar + myzero[CurrentIndex] + (NewValue) : splitChar + NewValue.ToString();
            }
            else
            {
                NewNo = splitChar + "0001";
            }

            return NewNo;
        }
        public async Task<int> AddNewCompany(CompanyDetailViewModel models)
        {
            DateTime? Date1 = null;
            if (!string.IsNullOrEmpty(models.FromDate))
            {
                userdt = models.FromDate.Split('/');
                userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            }
            if (!string.IsNullOrEmpty(models.UptoDate))
            {
                userdt = models.UptoDate.Split('/');
                userdt2 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            }
            CompanyDetail newCompany = new CompanyDetail()
            {
                CompName = models.CompName,
                Address1 = models.Address1,
                Address2 = models.Address2,
                Address3 = models.Address3,
                City = models.City,
                PinNo = models.PinNo,
                StateId = models.StateId,
                DistId = models.DistId,
                PhoneNo = models.PhoneNo,
                MobileNo = models.MobileNo,
                EmailAddress = models.EmailAddress,
                GSTNo = models.GSTNo,
                Jurisdiction = models.Jurisdiction,
                TransCode = models.TransCode,
                FromDate = string.IsNullOrEmpty(models.FromDate) ? Date1 : Convert.ToDateTime(userdt1),
                UptoDate = string.IsNullOrEmpty(models.UptoDate) ? Date1 : Convert.ToDateTime(userdt2),
                ActionForm = models.ActionForm,
                PhotoPath = models.ExitPhotoPath,
                SignaturePhotoPath= models.ExitSignaturePhotoPath,
                SignaturePhotoPathLeft = models.ExitSignaturePhotoPathLeft,
                PhotoPathPrint = models.PhotoPathPrint,
                SignaturePrint = models.SignaturePrint,
                SignaturePrintLeft = models.SignaturePrintLeft,
                ExitFooterReport = models.ExitFooterReport
            };
            //await _applicationDbContext.CompanyDetailTable.AddAsync(newCompany);
            _applicationDbContext.Entry(newCompany).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            return newCompany.Id;
        }
        public async Task<bool> UpdateCompany(CompanyDetailViewModel models)
        {
            var result = await _applicationDbContext.CompanyDetailTable.FirstOrDefaultAsync(x => x.Id == models.Id);
            DateTime? Date1 = null;
            if (!string.IsNullOrEmpty(models.FromDate))
            {
                userdt = models.FromDate.Split('/');
                userdt1 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            }
            if (!string.IsNullOrEmpty(models.UptoDate))
            {
                userdt = models.UptoDate.Split('/');
                userdt2 = userdt[2] + "-" + userdt[1] + "-" + userdt[0];
            }
            //var result = new CompanyDetail();
            if (result != null)
            {
                result.Id = models.Id; result.StateId = models.StateId; result.DistId = models.DistId;
                result.CompName = models.CompName; result.Address1 = models.Address1; result.Address2 = models.Address2;
                result.Address3 = models.Address3; result.City = models.City; result.PinNo = models.PinNo; result.PhoneNo = models.PhoneNo;
                result.MobileNo = models.MobileNo; result.EmailAddress = models.EmailAddress; result.GSTNo = models.GSTNo;
                result.Jurisdiction = models.Jurisdiction; result.TransCode = models.TransCode; result.FromDate = string.IsNullOrEmpty(models.FromDate) ? Date1 : Convert.ToDateTime(userdt1);
                result.UptoDate = string.IsNullOrEmpty(models.UptoDate) ? Date1 : Convert.ToDateTime(userdt2); result.ActionForm = models.ActionForm;
                result.PhotoPath = models.ExitPhotoPath; result.SignaturePhotoPath = models.ExitSignaturePhotoPath;
                result.SignaturePhotoPathLeft = models.ExitSignaturePhotoPathLeft;
                result.PhotoPathPrint = models.PhotoPathPrint; result.SignaturePrint = models.SignaturePrint;
                result.SignaturePrintLeft = models.SignaturePrintLeft;
                result.ExitFooterReport = models.ExitFooterReport;
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return false;
        }
        public async Task<List<CompanyDetailViewModel>> GetAllCompany(int id)
        {
            var result = await _applicationDbContext.CompanyDetailTable
                .Where(x => ((id > 0) ? x.Id == id : true))
                .Select(x => new CompanyDetailViewModel()
                {
                    Id = x.Id,
                    NameAddress = x.CompName + " " + x.Address1,
                    CompName = x.CompName,
                    Address1 = x.Address1,
                    Address2 = x.Address2,
                    Address3 = x.Address3,
                    City = x.City,
                    PinNo = x.PinNo,
                    StateId = x.StateId,
                    StateInCompany = new StateViewModel()
                    {
                        StateName = x.State.StateName 
                    },
                    DistId = x.DistId,
                    DistrictInCompany = new DistrictViewModel()
                    {
                        DistrictName = x.District.DistrictName
                    },
                    PhoneNo = x.PhoneNo,
                    MobileNo = x.MobileNo,
                    EmailAddress = x.EmailAddress,
                    GSTNo = x.GSTNo,
                    Jurisdiction = x.Jurisdiction,
                    TransCode = x.TransCode,
                    FromDate = (x.FromDate != null ? Convert.ToDateTime(x.FromDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                    UptoDate = (x.UptoDate != null ? Convert.ToDateTime(x.UptoDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                    ExitPhotoPath = x.PhotoPath,
                    ExitSignaturePhotoPath = x.SignaturePhotoPath,
                    ExitSignaturePhotoPathLeft = x.SignaturePhotoPathLeft,
                    PhotoPathPrint = x.PhotoPathPrint,
                    SignaturePrint = x.SignaturePrint,
                    SignaturePrintLeft = x.SignaturePrintLeft,
                    ValidedDate = x.UptoDate,
                    ExitFooterReport = x.ExitFooterReport
                }).ToListAsync();
            return result;
        }
        public async Task<CompanyDetailViewModel> GetCompanyById(int id)
        {
            var result = await _applicationDbContext.CompanyDetailTable.Select(x => new CompanyDetailViewModel()
            {
                Id = x.Id,
                CompName = x.CompName,
                Address1 = x.Address1,
                Address2 = x.Address2,
                Address3 = x.Address3,
                City = x.City,
                PinNo = x.PinNo,
                StateId = x.StateId,
                StateInCompany = new StateViewModel()
                {
                    StateName = x.State.StateName
                },
                DistId = x.DistId,
                DistrictInCompany = new DistrictViewModel()
                {
                    DistrictName = x.District.DistrictName
                },
                PhoneNo = x.PhoneNo,
                MobileNo = x.MobileNo,
                EmailAddress = x.EmailAddress,
                GSTNo = x.GSTNo,
                Jurisdiction = x.Jurisdiction,
                TransCode = x.TransCode,
                FromDate = (x.FromDate != null ? Convert.ToDateTime(x.FromDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                UptoDate = (x.UptoDate != null ? Convert.ToDateTime(x.UptoDate).ToString("dd/MM/yyyy").Replace('-', '/') : null),
                ExitPhotoPath = x.PhotoPath,
                ExitSignaturePhotoPath = x.SignaturePhotoPath,
                ExitSignaturePhotoPathLeft = x.SignaturePhotoPathLeft,
                PhotoPathPrint = x.PhotoPathPrint,
                SignaturePrint = x.SignaturePrint,
                SignaturePrintLeft = x.SignaturePrintLeft,
                ValidedDate = x.UptoDate,
                ExitFooterReport = x.ExitFooterReport
            }).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<bool> DeleteCompany(int id)
        {
            var result = await _applicationDbContext.CompanyDetailTable.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                await _applicationDbContext.SaveChangesAsync();
            }
            return false;
        }

        public async Task<int> AddNewState(StateViewModel models)
        {
            State newState = new State()
            {
                StateName = models.StateName
            };
            //await _applicationDbContext.CompanyDetailTable.AddAsync(newCompany);
            _applicationDbContext.Entry(newState).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            return newState.StateId;
        }
        public async Task<bool> UpdateState(StateViewModel models)
        {
            var result = await _applicationDbContext.StateTable.FirstOrDefaultAsync(x => x.StateId == models.StateId);
            if (result != null)
            {
                result.StateId = models.StateId;
                result.StateName = models.StateName;
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return false;
        }
        public async Task<List<StateViewModel>> GetAllState(int id)
        {
            var result = await _applicationDbContext.StateTable
                .Where(x => ((id > 0) ? x.StateId == id : true))
                .Select(x => new StateViewModel()
                {
                    StateId = x.StateId,
                    StateName = x.StateName
                }).ToListAsync();
            return result;
        }
        public async Task<StateViewModel> GetStateById(int id)
        {
            var result = await _applicationDbContext.StateTable.Select(x => new StateViewModel()
            {
                StateId = x.StateId,
                StateName = x.StateName
            }).FirstOrDefaultAsync(x => x.StateId == id);
            return result;
        }
        public async Task<bool> DeleteState(int id)
        {
            var result = await _applicationDbContext.StateTable.FirstOrDefaultAsync(x => x.StateId == id);
            if (result != null)
            {
                _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                await _applicationDbContext.SaveChangesAsync();
            }
            return false;
        }

        public async Task<int> AddNewDistrict(DistrictViewModel models)
        {
            District newState = new District()
            {
                DistrictName = models.DistrictName,
                DistStateId = Convert.ToInt32(models.DistStateId)
            };
            //await _applicationDbContext.CompanyDetailTable.AddAsync(newCompany);
            _applicationDbContext.Entry(newState).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            return newState.DistId;
        }
        public async Task<bool> UpdateDistrict(DistrictViewModel models)
        {
            var result = await _applicationDbContext.DistrictTable.FirstOrDefaultAsync(x => x.DistId == models.DistId);
            if (result != null)
            {
                result.DistId = models.DistId;
                result.DistrictName = models.DistrictName;
                result.DistStateId = Convert.ToInt32(models.DistStateId);
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return false;
        }
        public async Task<List<DistrictViewModel>> GetAllDistrict(int id)
        {
            var result = await _applicationDbContext.DistrictTable
                .Where(x => ((id > 0) ? x.DistId == id : true))
                .Select(x => new DistrictViewModel()
                {
                    DistId = x.DistId,
                    DistrictName = x.DistrictName,
                    DistStateId = x.DistStateId,
                    StateViewModel = new StateViewModel()
                    {
                        StateName = x.StateDetails.StateName
                    }
                }).ToListAsync();
            return result;
        }
        public async Task<List<DistrictViewModel>> GetAllDistrictByState(int id)
        {
            var result = await _applicationDbContext.DistrictTable
                .OrderBy(x => x.DistrictName)
                .Where(x => ((id > 0) ? x.DistStateId == id : true))
                .Select(x => new DistrictViewModel()
                {
                    DistId = x.DistId,
                    DistrictName = x.DistrictName,
                    DistStateId = x.DistStateId,
                    StateViewModel = new StateViewModel()
                    {
                        StateName = x.StateDetails.StateName
                    }
                }).ToListAsync();
            return result;
        }
        public async Task<DistrictViewModel> GetDistrictById(int id)
        {
            var result = await _applicationDbContext.DistrictTable.Select(x => new DistrictViewModel()
            {
                DistId = x.DistId,
                DistrictName = x.DistrictName,
                DistStateId = x.DistStateId
            }).FirstOrDefaultAsync(x => x.DistId == id);
            return result;
        }
        public async Task<bool> DeleteDistrict(int id)
        {
            var result = await _applicationDbContext.DistrictTable.FirstOrDefaultAsync(x => x.DistId == id);
            if (result != null)
            {
                _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                await _applicationDbContext.SaveChangesAsync();
            }
            return false;
        }
        
       
        public async Task<int> AddNewMoneyMaster(MoneyMasterViewModel models)
        {

            MoneyMaster newMoneyMaster = new MoneyMaster()
            {
                MerchantId = models.MerchantId,
                CompId = models.CompId,
                APIKey = models.APIKey,
                APISalt = models.APISalt,
                AuthKey = models.AuthKey,
                PostURL = models.PostURL,
                SurURL = models.SurURL,
                FurURL = models.FurURL
            };
            _applicationDbContext.Entry(newMoneyMaster).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            return newMoneyMaster.Id;
        }
        public async Task<bool> UpdateMoneyMaster(MoneyMasterViewModel models)
        {
            var result = await _applicationDbContext.MoneyMasterTable.FirstOrDefaultAsync(x => x.Id == models.Id);
            if (result != null)
            {
                result.Id = models.Id;result.CompId = models.CompId;
                result.MerchantId = models.MerchantId; result.APIKey = models.APIKey;
                result.APISalt = models.APISalt; result.AuthKey = models.AuthKey;
                result.PostURL = models.PostURL; result.SurURL = models.SurURL;
                result.FurURL = models.FurURL;
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return false;
        }
        public async Task<MoneyMasterViewModel> GetMoneyMasterById(int id)
        {
            var result = await _applicationDbContext.MoneyMasterTable.Select(x => new MoneyMasterViewModel()
            {
                Id = x.Id,
                CompId = x.CompId,
                MerchantId = x.MerchantId,
                APIKey = x.APIKey,
                APISalt = x.APISalt,
                AuthKey = x.AuthKey,
                PostURL = x.PostURL,
                SurURL = x.SurURL,
                FurURL = x.FurURL
            }).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<List<MoneyMasterViewModel>> GetALLMoneyMaster(int cmpid)
        {
            var result = await _applicationDbContext.MoneyMasterTable
                .Where(x => cmpid > 0 ? x.CompId == cmpid : true)
                .Select(x => new MoneyMasterViewModel()
            {
                Id = x.Id,
                CompId = x.CompId,
                MerchantId = x.MerchantId,
                APIKey = x.APIKey,
                APISalt = x.APISalt,
                AuthKey = x.AuthKey,
                PostURL = x.PostURL,
                SurURL = x.SurURL,
                FurURL = x.FurURL
            }).ToListAsync();
            return result;
        }
       
        public async Task<int> AddNewSMSKey(SMSKeyViewModel models)
        {

            SMSKey newSMSKey = new SMSKey()
            {
                CompId = models.CompId,
                APIKeyNo = models.APIKeyNo,
                SenderName = models.SenderName,
                MessageDetail = models.MessageDetail,
                MessageType = models.MessageType,
                MessageActive = models.MessageActive,
                URLName = models.URLName
            };
            _applicationDbContext.Entry(newSMSKey).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            return newSMSKey.SMSKeyId;
        }
        public async Task<bool> UpdateSMSKey(SMSKeyViewModel models)
        {
            var result = await _applicationDbContext.SMSKeyTable.FirstOrDefaultAsync(x => x.SMSKeyId == models.SMSKeyId);
            if (result != null)
            {
                result.SMSKeyId = models.SMSKeyId;result.CompId = models.CompId;
                result.APIKeyNo = models.APIKeyNo; result.SenderName = models.SenderName;
                result.MessageDetail = models.MessageDetail; result.MessageType = models.MessageType;
                result.MessageActive = models.MessageActive; result.URLName = models.URLName;
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return false;
        }
        public async Task<SMSKeyViewModel> GetSMSKeyById(int id)
        {
            var result = await _applicationDbContext.SMSKeyTable.Select(x => new SMSKeyViewModel()
            {
                CompId = x.CompId,
                SMSKeyId = x.SMSKeyId,
                APIKeyNo = x.APIKeyNo,
                SenderName = x.SenderName,
                MessageDetail = x.MessageDetail,
                MessageType = x.MessageType,
                MessageActive = x.MessageActive,
                URLName = x.URLName
            }).FirstOrDefaultAsync(x => x.SMSKeyId == id);
            return result;
        }
        public async Task<List<SMSKeyViewModel>> GetALLSMSKey(int cmpid)
        {
            var result = await _applicationDbContext.SMSKeyTable
                .Where(x => cmpid > 0 ? x.CompId == cmpid : true)
                .Select(x => new SMSKeyViewModel()
            {
                CompId = x.CompId,
                SMSKeyId = x.SMSKeyId,
                APIKeyNo = x.APIKeyNo,
                SenderName = x.SenderName,
                MessageDetail = x.MessageDetail,
                MessageType = x.MessageType,
                MessageActive = x.MessageActive,
                URLName = x.URLName
            }).ToListAsync();
            return result;
        }
      
        public async Task<int> AddNewSMSFile(SMSFileViewModel models)
        {

            SMSFile newSMSFile = new SMSFile()
            {
                CompId = models.CompId,
                Dateofbirth = models.Dateofbirth,
                DateofAnniversary = models.DateofAnniversary,
                DateOfInstallment = models.DateOfInstallment,
                DateOfMaturity = models.DateOfMaturity
            };
            _applicationDbContext.Entry(newSMSFile).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            return newSMSFile.Id;
        }
        public async Task<bool> UpdateSMSFile(SMSFileViewModel models)
        {
            var result = await _applicationDbContext.SMSFileTable.FirstOrDefaultAsync(x => x.Id == models.Id);
            if (result != null)
            {
                result.Id = models.Id;result.CompId = models.CompId;
                result.Dateofbirth = models.Dateofbirth; result.DateofAnniversary = models.DateofAnniversary;
                result.DateOfInstallment = models.DateOfInstallment; result.DateOfMaturity = models.DateOfMaturity;
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return false;
        }
        public async Task<SMSFileViewModel> GetSMSFileById(int id)
        {
            var result = await _applicationDbContext.SMSFileTable.Select(x => new SMSFileViewModel()
            {
                Id = x.Id,
                Dateofbirth = x.Dateofbirth,
                DateofAnniversary = x.DateofAnniversary,
                DateOfInstallment = x.DateOfInstallment,
                DateOfMaturity = x.DateOfMaturity
            }).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<List<SMSFileViewModel>> GetALLSMSFile(int cmpid)
        {
            var result = await _applicationDbContext.SMSFileTable
                .Where(x => cmpid > 0 ? x.CompId == cmpid : true)
                .Select(x => new SMSFileViewModel()
            {
                Id = x.Id,
                Dateofbirth = x.Dateofbirth,
                DateofAnniversary = x.DateofAnniversary,
                DateOfInstallment = x.DateOfInstallment,
                DateOfMaturity = x.DateOfMaturity
            }).ToListAsync();
            return result;
        }

        public async Task<string> SendSingleMessage1(string phoneno, string messagedetails)
        {           
            string result = "";
            var result1 = await _applicationDbContext.SMSKeyTable.Where(x => x.MessageActive == true)
                        .Select(x => new { x.APIKeyNo, x.SenderName, x.URLName }).FirstOrDefaultAsync();
            //string url = result1.URLName + "apikey=" + result1.APIKeyNo + "&sender=" + result1.SenderName + "&numbers=" + phoneno + "&message=" + messagedetails;
            //string url = "http://sms.fastsmsindia.com/api/sendhttp.php?authkey=" + System.Uri.EscapeUriString("29062ACGnSFgkDQ5c27254a") + "&mobiles=" + System.Uri.EscapeUriString(phoneno) + "&message=" + System.Uri.EscapeUriString(messagedetails) + "&sender=" + System.Uri.EscapeUriString(result1.SenderName) + "&route=" + System.Uri.EscapeUriString("6") + "&unicode=" + System.Uri.EscapeUriString("0");

            // string[] tempPhone = phoneno.Trim().Length > 10 ? phoneno.Trim().Split(',') : phoneno.Trim().Split();          
            
                string url = (result1.URLName).Trim() + "authkey=" + System.Uri.EscapeUriString((result1.APIKeyNo).Trim()) + "&mobiles=" + System.Uri.EscapeUriString(phoneno) + "&message=" + messagedetails + "&sender=" + System.Uri.EscapeUriString((result1.SenderName).Trim()) + "&route=" + System.Uri.EscapeUriString("6") + "&unicode=" + System.Uri.EscapeUriString("1");
                 StreamWriter myWriter = null;
                HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
                objRequest.Method = "POST";

                objRequest.ContentLength = Encoding.UTF8.GetByteCount(url);
                objRequest.ContentType = "application/x-www-form-urlencoded";
                try
                {
                    myWriter = new StreamWriter(objRequest.GetRequestStream());
                    myWriter.Write(url);
                    myWriter.Dispose();
                    myWriter.Close();
                }
                catch (Exception e) { return e.Message; }
                finally { myWriter.Close(); myWriter.Dispose(); }
                HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
                using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
                {
                    result = sr.ReadToEnd();
                    sr.Close();
                }
            return result;
        }
        public async Task<string> SendSingleMessage2(string phoneno, string messagedetails)
        {
            string result = "";
            var result1 = await _applicationDbContext.SMSKeyTable.Where(x => x.MessageActive == true)
                        .Select(x => new { x.APIKeyNo, x.SenderName, x.URLName }).FirstOrDefaultAsync();
        //string url = result1.URLName + "apikey=" + result1.APIKeyNo + "&sender=" + result1.SenderName + "&numbers=" + phoneno + "&message=" + messagedetails;
        //string url = "http://sms.fastsmsindia.com/api/sendhttp.php?authkey=" + System.Uri.EscapeUriString("29062ACGnSFgkDQ5c27254a") + "&mobiles=" + System.Uri.EscapeUriString(phoneno) + "&message=" + System.Uri.EscapeUriString(messagedetails) + "&sender=" + System.Uri.EscapeUriString(result1.SenderName) + "&route=" + System.Uri.EscapeUriString("6") + "&unicode=" + System.Uri.EscapeUriString("0");
        //http://webmsg.smsbharti.com/app/smsapi/index.php?key=360000342803BF&campaign=0&routeid=35&type=unicode&contacts=9936807374,8545867070&senderid=SOFTEC&msg=Hindi++-+%C3%A0%C2%A4%C2%B9%C3%A0%C2%A4%C2%BF%C3%A0%C2%A4%C2%82%C3%A0%C2%A4%C2%A6%C3%A0%C2%A5%C2%80+%2C+Chinese+-++%C3%A7%C2%97%C2%B4%C3%A5%C2%91%C2%A2%C3%A8%C2%89%C2%B2+%C3%AF%C2%BC%C2%8CRussian+-+%C3%91%C2%80%C3%91%C2%83%C3%91%C2%81%C3%91%C2%81%C3%90%C2%B8%C3%90%C2%B0%C3%90%C2%BD";

            // string[] tempPhone = phoneno.Trim().Length > 10 ? phoneno.Trim().Split(',') : phoneno.Trim().Split();          
            StreamWriter myWriter = null;
            string url = (result1.URLName).Trim() + "authkey=" + System.Uri.EscapeUriString((result1.APIKeyNo).Trim()) + "&mobiles=" + System.Uri.EscapeUriString(phoneno) + "&message=" + messagedetails + "&sender=" + System.Uri.EscapeUriString((result1.SenderName).Trim()) + "&route=" + System.Uri.EscapeUriString("6") + "&unicode=" + System.Uri.EscapeUriString("1");
            //string url = "http://webmsg.smsbharti.com/app/smsapi/index.php?key=360000342803BF&campaign=0&routeid=35&type=unicode&contacts=" + phoneno + "&senderid=SOFTEC&msg=" + messagedetails;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
            objRequest.Method = "POST";

            objRequest.ContentLength = Encoding.UTF8.GetByteCount(url);
            objRequest.ContentType = "application/x-www-form-urlencoded";
            try
            {
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(url);
                myWriter.Dispose();
                myWriter.Close();
                HttpWebResponse myResp = (HttpWebResponse)objRequest.GetResponse();
                StreamReader _responseStreamReader = new StreamReader(myResp.GetResponseStream());
                string responseString = _responseStreamReader.ReadToEnd();                
                result = responseString;
                result = "Message Send Successfully";
                _responseStreamReader.Close();
                myResp.Close();
            }
            catch (Exception e) { return result = "Message not send " + e.Message; }
            finally
            {
                myWriter.Dispose();
                myWriter.Close();
            }
            return result;
        }
        public async Task<string> SendSingleMessage(string phoneno, string messagedetails)
        {
            // Text Local Code
            string result = "";
            var result1 = await _applicationDbContext.SMSKeyTable.Where(x => x.MessageActive == true)
                        .Select(x => new { x.APIKeyNo, x.SenderName, x.URLName }).FirstOrDefaultAsync();
            string url = result1.URLName + "apikey=" + result1.APIKeyNo + "&sender=" + result1.SenderName + "&numbers=" + phoneno + "&message=" + messagedetails;
            StreamWriter myWriter = null;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);

            objRequest.Method = "POST";
            objRequest.ContentLength = Encoding.UTF8.GetByteCount(url);
            objRequest.ContentType = "application/x-www-form-urlencoded";
            try
            {
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(url);
                result = "Message Send Successfully";
            }
            catch (Exception e)
            {
                return result = "Message not send " + e.Message;
            }
            finally
            {
                myWriter.Close();
            }

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                // Close and clean up the StreamReader
                sr.Close();
            }
            return result;        
         }
      
        public async Task<int> AddNewUploadPhotoFile(UploadPhotoFrontViewModel models)
        {
            UploadPhotoFront newPhoto = new UploadPhotoFront()
            {
                Title = models.Title,
                Descriptions = models.Descriptions,
                GroupName = models.GroupName,
                Rate = models.Rate,
                PhotoPath = models.ExitPhotoPath
            };
            _applicationDbContext.Entry(newPhoto).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            return newPhoto.Id;
        }
        public async Task<bool> UpdateUploadPhotoFile(UploadPhotoFrontViewModel models)
        {
            var result = new UploadPhotoFront();
            if (result != null)
            {
                result.Id = models.Id;
                result.Title = models.Title; result.Descriptions = models.Descriptions;
                result.GroupName = models.GroupName; result.Rate = models.Rate;
                result.PhotoPath = models.ExitPhotoPath;
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return false;
        }
        public async Task<List<UploadPhotoFrontViewModel>> GetAllUploadPhotoFile()
        {
            var result = await _applicationDbContext.UploadPhotoFrontTable.Select(x => new UploadPhotoFrontViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                Descriptions = x.Descriptions,
                GroupName = x.GroupName,
                Rate = x.Rate,
                ExitPhotoPath = x.PhotoPath
            }).ToListAsync();
            return result;
        }
        public async Task<UploadPhotoFrontViewModel> GetUploadPhotoFileById(int id)
        {
            var result = await _applicationDbContext.UploadPhotoFrontTable.Select(x => new UploadPhotoFrontViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                Descriptions = x.Descriptions,
                Rate = x.Rate,
                GroupName = x.GroupName,
                ExitPhotoPath = x.PhotoPath
            }).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<bool> DeleteUploadPhoto(int id)
        {
            var result = await _applicationDbContext.UploadPhotoFrontTable.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                await _applicationDbContext.SaveChangesAsync();
            }
            return false;
        }
        public async Task<List<UploadPhotoFrontViewModel>> GetAllUploadPhotoFileFront()
        {
            var result = await _applicationDbContext.UploadPhotoFrontTable.Select(x => new UploadPhotoFrontViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                Descriptions = x.Descriptions,
                GroupName = x.GroupName,
                Rate = x.Rate,
                ExitPhotoPath = x.PhotoPath
            }).ToListAsync();
            return result;
        }
   
        public async Task<int> AddNewAutoMessageRecord(string CustomerNo,string msgtype)
        {
            string[] Tempphone = CustomerNo.Split(',');
            foreach (var item in Tempphone)
            {
                CheckMessageSend messageSend = new CheckMessageSend()
                {
                    CustCode = Convert.ToInt32(item),
                    CurrentDate = DateTime.Now,
                    TodayMessageSend =true,
                    MessageType = msgtype
                };
                _applicationDbContext.Entry(messageSend).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await _applicationDbContext.SaveChangesAsync();
            }
            return 1;
        }
        public async Task<bool> IsCheckInstallmentMessageSend(int customerid, DateTime date,string msgtype)
        {
            var result = await _applicationDbContext.CheckMessageSendTable.Select(x =>
                                new { x.CustCode, x.CurrentDate, x.TodayMessageSend,x.MessageType })
                                .FirstOrDefaultAsync(x => x.CustCode == customerid 
                                && x.CurrentDate.Value.Month == date.Month
                                && x.CurrentDate.Value.Day == date.Day
                                && x.CurrentDate.Value.Year == date.Year
                                && x.MessageType == msgtype );
            return (result != null ? true : false);
        }      
        public async Task<string> CheckMessageType(string type)
        {
            userdt4 = ""; MonthNo = 0; CurrentIndex = 0; MonthFirst = 0; // year input / Days
            MonthNo = DateTime.Now.Month; CurrentIndex = DateTime.Now.Year; MonthFirst = DateTime.Now.Day;
            var result = await _applicationDbContext.SMSFileTable.FirstOrDefaultAsync();
            if (result !=null)
            {
                if (type == "Date of Birth")
                {
                    userdt4 = result.Dateofbirth;
                }
                else if (type == "Date Of Anniversary")
                {
                    userdt4 = result.DateofAnniversary;
                }
                else if (type == "Installment")
                {
                    userdt4 = result.DateOfInstallment;
                }
            }
            return userdt4;
        }
        public async Task<int> AddNewFontCustom(FontCustomViewModel models)
        {
            FontCustom newState = new FontCustom()
            {
                Name = models.Name
            };
            //await _applicationDbContext.CompanyDetailTable.AddAsync(newCompany);
            _applicationDbContext.Entry(newState).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _applicationDbContext.SaveChangesAsync();
            return newState.Id;
        }
        public async Task<bool> UpdateFontCustom(FontCustomViewModel models)
        {
            var result = await _applicationDbContext.FontCustomTable.FirstOrDefaultAsync(x => x.Id == models.Id);
            if (result != null)
            {
                result.Id = models.Id;
                result.Name = models.Name;
            }
            _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return false;
        }
        public async Task<List<FontCustomViewModel>> GetAllFontCustom(int id)
        {
            var result = await _applicationDbContext.FontCustomTable
                .Where(x => ((id > 0) ? x.Id == id : true))
                .Select(x => new FontCustomViewModel()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();
            return result;
        }
        public async Task<FontCustomViewModel> GetFontCustomById(int id)
        {
            var result = await _applicationDbContext.FontCustomTable.Select(x => new FontCustomViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<bool> DeleteFontCustom(int id)
        {
            var result = await _applicationDbContext.FontCustomTable.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                _applicationDbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                await _applicationDbContext.SaveChangesAsync();
            }
            return false;
        }
    }
}
