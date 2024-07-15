using ITCGKP.Data.Models;
using ITCGKP.Data.Services;
using ITCGKP.Data.Services.GeneralFunction;
using ITCGKP.Data.Services.NewUpdateDeleteData;
using ITCGKP.Data.Services.ProvideService;
using ITCGKPLAB.Models;
using ITCGKP.Data.Services.Security.MasterFile;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITCGKP.Data.Services.Security.ReportFile;
using ITCGKP.Data.Services.Security.FinancialFile;
using ITCGKP.Data.Services.Security.TransactionFile;
using ITCGKP.Data.Services.Security.PayBillFile;
using ITCGKPLAB.Utilies.ConfigOptions;
using ITCGKPLAB.Tags;

namespace ITCGKPLAB
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        
        //public Startup(IConfiguration configuration, IWebHostEnvironment env)
        //{
        //    configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
        //    .AddJsonFile("Secrets.json")
        //    .Build();

        //    _configuration = configuration;
        //}
        
        // Or Other than program.cs File me change karna hai
        //  .ConfigureAppConfiguration((hostingContextx, config) =>
        //        {
        //    var env = hostingContextx.HostingEnvironment;

        //    config.SetBasePath(env.ContentRootPath)
        //        .AddJsonFile("Secrets.json", optional: true, reloadOnChange: true);

        //})

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;            
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {   
            //builder.Services.AddDbContextPool % ApplicationDbContext % (options =% options.UseMySql(_GetConnStringName, ServerVersion.AutoDetect(_GetConnStringName)));

            //services.AddDbContext<ApplicationDBContext>(options =>
            //      options.UseMySql(_configuration.GetConnectionString("ApplicationDbConnect")));
            services.AddDbContext<ApplicationDBContext>(options => options.UseNpgsql(_configuration.GetConnectionString("ApplicationDbConnect")));
            
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;

                options.SignIn.RequireConfirmedEmail = true;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(1);
                options.Lockout.MaxFailedAccessAttempts = 5;
            })
          .AddEntityFrameworkStores<ApplicationDBContext>()
          .AddDefaultTokenProviders();
            
            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromDays(1);
            });

            // services.AddSession();
            services.AddSession(options =>
            {
                options.Cookie.Name = "TestSession";
                //options.Cookie.Expiration = TimeSpan.FromMinutes(245); //invalid
                //options.IdleTimeout = TimeSpan.FromSeconds(10);
                //options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;                
            });

            services.AddControllersWithViews (options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()
                            .Build();

                // globle authorization Filter
                options.Filters.Add(new AuthorizeFilter(policy));
            }).AddXmlSerializerFormatters();
            
            //// Here Authentication
            //services.AddAuthentication("CookieAuthentication")
            //   .AddCookie("CookieAuthentication", config =>
            //   {
            //       config.Cookie.Name = "ITCGKPLABSCOOKIES";
            //       config.Cookie.HttpOnly = true;
            //       config.ExpireTimeSpan = TimeSpan.FromDays(1);
            //       config.SlidingExpiration = true;
            //   });
            
            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = new PathString("/Administration/AccessDenied");
                options.Cookie.Name = "Application.ITCGKPLABSCOOKIES";
                //options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(5);
                options.LoginPath = _configuration["Application:LoginPath"];
                options.LogoutPath = _configuration["Application:LogoutPath"];               
                options.SlidingExpiration = true;
            });

            
            services.AddAuthorization(options =>
            {
                //options.FallbackPolicy = new AuthorizationPolicyBuilder()
                //                        .RequireAuthenticatedUser()
                //                        .Build();              

                options.AddPolicy("CreateRolePolicy",
                   policy => policy.RequireClaim("Create Role", "true"));

                options.AddPolicy("EditRolePolicy",
                   policy => policy.RequireClaim("Edit Role", "true"));

                options.AddPolicy("DeleteRolePolicy",
                    policy => policy.RequireClaim("Delete Role", "true"));

                options.AddPolicy("CreateUserPolicy",
                   policy => policy.RequireClaim("Create User", "true"));

                options.AddPolicy("EditUserPolicy",
                   policy => policy.RequireClaim("Edit User", "true"));

                options.AddPolicy("DeleteUserPolicy",
                    policy => policy.RequireClaim("Delete User", "true"));

                options.AddPolicy("EditPageSetupPolicy",
                   policy => policy.RequireClaim("Edit PageSetup", "true"));

                // Policy First Handler Authorized
                options.AddPolicy("PatientApprovedPolicy",
            policy => policy.AddRequirements(new PatientResultAppManageClaimsRequirement()));

                options.AddPolicy("PatientRegistrationCancelPolicy",
            policy => policy.AddRequirements(new PatientRegistCancelManageClaimsRequirement()));

                options.AddPolicy("PatientResultPolicy",
             policy => policy.AddRequirements(new PatientResultManageClaimsRequirement()));

                options.AddPolicy("MedicalResultPolicy",
             policy => policy.AddRequirements(new MedResultManageClaimsRequirement()));

                options.AddPolicy("AddEditTestDocPolicy",
               policy => policy.AddRequirements(new TestDocManageClaimsRequirement()));
                options.AddPolicy("DeleteTestDocPolicy",
                  policy => policy.AddRequirements(new TestDocDeleteManageClaimsRequirement()));

                options.AddPolicy("AddEditAreaPolicy",
                policy => policy.AddRequirements(new AreaManageClaimsRequirement()));
                options.AddPolicy("DeleteAreaPolicy",
                  policy => policy.AddRequirements(new AreaDeleteManageClaimsRequirement()));

                options.AddPolicy("AddEditClientPolicy",
                policy => policy.AddRequirements(new ClientManageClaimsRequirement()));
                options.AddPolicy("DeleteClientPolicy",
                  policy => policy.AddRequirements(new ClientDeleteManageClaimsRequirement()));


                options.AddPolicy("AddEditExecutivePolicy",
                policy => policy.AddRequirements(new ExecutiveManageClaimsRequirement()));
                options.AddPolicy("DeleteExecutivePolicy",
                  policy => policy.AddRequirements(new ExecutiveDeleteManageClaimsRequirement()));

                options.AddPolicy("AddEditDoctorPolicy",
                policy => policy.AddRequirements(new DoctorManageClaimsRequirement()));
                options.AddPolicy("DeleteDoctorPolicy",
                  policy => policy.AddRequirements(new DoctorDeleteManageClaimsRequirement()));

                options.AddPolicy("AddEditMedMasterPolicy",
                policy => policy.AddRequirements(new MedMasterManageClaimsRequirement()));
                options.AddPolicy("DeleteMedMasterPolicy",
                  policy => policy.AddRequirements(new MedMasterDeleteManageClaimsRequirement()));

                options.AddPolicy("AddEditDoctorLabPolicy",
                policy => policy.AddRequirements(new DoctorLabManageClaimsRequirement()));
                options.AddPolicy("DeleteDoctorLabPolicy",
                policy => policy.AddRequirements(new DoctorLabDeleteManageClaimsRequirement()));

                options.AddPolicy("AddEditPreResultPolicy",
                policy => policy.AddRequirements(new PreResultManageClaimsRequirement()));
                options.AddPolicy("DeletePreResultPolicy",
                  policy => policy.AddRequirements(new PreResultDeleteManageClaimsRequirement()));

                options.AddPolicy("AddEditRegistrationPolicy",
                policy => policy.AddRequirements(new RegistrationManageClaimsRequirement()));
                options.AddPolicy("DeleteRegistrationPolicy",
                policy => policy.AddRequirements(new RegistrationDeleteManageClaimsRequirement()));

                options.AddPolicy("AddEditPatientDueReciptPolicy",
                policy => policy.AddRequirements(new PatientDueReciptManageClaimsRequirement()));
                options.AddPolicy("DeletePatientDueReciptPolicy",
                policy => policy.AddRequirements(new PatientDueReciptDeleteManageClaimsRequirement()));

                options.AddPolicy("AddEditReportMasterPolicy",
                policy => policy.AddRequirements(new ReportMasterManageClaimsRequirement()));
                options.AddPolicy("DeleteReportMasterPolicy",
                  policy => policy.AddRequirements(new ReportMasterDeleteManageClaimsRequirement()));

                options.AddPolicy("AddEditTestPolicy",
                policy => policy.AddRequirements(new TestManageClaimsRequirement()));
                options.AddPolicy("DeleteTestPolicy",
                  policy => policy.AddRequirements(new TestDeleteManageClaimsRequirement()));

                options.AddPolicy("AddEditTestGroupPolicy",
                policy => policy.AddRequirements(new TestGroupManageClaimsRequirement()));
                options.AddPolicy("DeleteTestGroupPolicy",
                  policy => policy.AddRequirements(new TestGroupDeleteManageClaimsRequirement()));
                
                options.AddPolicy("AddEditTestRatePolicy",
              policy => policy.AddRequirements(new TestRateManageClaimsRequirement()));
                options.AddPolicy("DeleteTestRatePolicy",
                  policy => policy.AddRequirements(new TestRateDeleteManageClaimsRequirement()));

                // Financial Report
                options.AddPolicy("AddEditAccountGroupPolicy",
                policy => policy.AddRequirements(new AccountGroupManageClaimsRequirement()));
                options.AddPolicy("DeleteAccountGroupPolicy",
                  policy => policy.AddRequirements(new AccountGroupDeleteManageClaimsRequirement()));

                options.AddPolicy("AddEditAccountMasterPolicy",
                policy => policy.AddRequirements(new AccountMasterManageClaimsRequirement()));
                options.AddPolicy("DeleteAccountMasterPolicy",
                  policy => policy.AddRequirements(new AccountMasterDeleteManageClaimsRequirement()));

                options.AddPolicy("AddEditAccountConfigurationFilePolicy",
               policy => policy.AddRequirements(new AccountConfigurationManageClaimsRequirement()));
                options.AddPolicy("DeleteAccountConfigurationFilePolicy",
                policy => policy.AddRequirements(new AccountConfigurationDeleteManageClaimsRequirement()));

                options.AddPolicy("AddEditProductCompanyPolicy",
                 policy => policy.AddRequirements(new ProductCompanyManageClaimsRequirement()));
                options.AddPolicy("DeleteProductCompanyPolicy",
                policy => policy.AddRequirements(new ProductCompanyDeleteManageClaimsRequirement()));

                options.AddPolicy("AddEditUnitMeasurementPolicy",
                policy => policy.AddRequirements(new UnitMeasurementManageClaimsRequirement()));
                options.AddPolicy("DeleteUnitMeasurementPolicy",
                policy => policy.AddRequirements(new UnitMeasurementDeleteManageClaimsRequirement()));

                options.AddPolicy("AddEditUnitQuantityPolicy",
                policy => policy.AddRequirements(new UQCManageClaimsRequirement()));
                options.AddPolicy("DeleteUnitQuantityPolicy",
                policy => policy.AddRequirements(new UQCDeleteManageClaimsRequirement()));

                options.AddPolicy("AddEditProductMasterPolicy",
               policy => policy.AddRequirements(new ProductMasterManageClaimsRequirement()));
                options.AddPolicy("DeleteProductMasterPolicy",
                  policy => policy.AddRequirements(new ProductMasterDeleteManageClaimsRequirement()));

                options.AddPolicy("AddEditItemGroupPolicy",
                policy => policy.AddRequirements(new ItemGroupManageClaimsRequirement()));
                options.AddPolicy("DeleteItemGroupPolicy",
                  policy => policy.AddRequirements(new ItemGroupDeleteManageClaimsRequirement()));

                options.AddPolicy("AddEditItemMasterPolicy",
                policy => policy.AddRequirements(new ItemMasterManageClaimsRequirement()));
                options.AddPolicy("DeleteItemMasterPolicy",
                  policy => policy.AddRequirements(new ItemMasterDeleteManageClaimsRequirement()));

                options.AddPolicy("AddEditOpenningStockPolicy",
                policy => policy.AddRequirements(new OpenningStockManageClaimsRequirement()));
                options.AddPolicy("DeleteOpenningStockPolicy",
                  policy => policy.AddRequirements(new OpenningStockDeleteManageClaimsRequirement()));
                // Transaction File
                options.AddPolicy("AddEditBankPaymentFilePolicy",
                policy => policy.AddRequirements(new BankPaymentManageClaimsRequirement()));
                options.AddPolicy("DeleteBankPaymentFilePolicy",
                policy => policy.AddRequirements(new BankPaymentDeleteManageClaimsRequirement()));

                options.AddPolicy("AddEditBankReciptFilePolicy",
                policy => policy.AddRequirements(new BankReciptManageClaimsRequirement()));
                options.AddPolicy("DeleteBankReciptFilePolicy",
                policy => policy.AddRequirements(new BankReciptDeleteManageClaimsRequirement()));

                options.AddPolicy("AddEditCashPaymentFilePolicy",
                policy => policy.AddRequirements(new CashPaymentManageClaimsRequirement()));
                options.AddPolicy("DeleteCashPaymentFilePolicy",
                policy => policy.AddRequirements(new CashPaymentDeleteManageClaimsRequirement()));

                options.AddPolicy("AddEditCashReciptFilePolicy",
                policy => policy.AddRequirements(new CashReciptManageClaimsRequirement()));
                options.AddPolicy("DeleteCashReciptFilePolicy",
                 policy => policy.AddRequirements(new CashReciptDeleteManageClaimsRequirement()));

                options.AddPolicy("AddEditPurchaseFilePolicy",
                policy => policy.AddRequirements(new PurchaseFileManageClaimsRequirement()));
                options.AddPolicy("DeletePurchaseFilePolicy",
                policy => policy.AddRequirements(new PurchaseFileDeleteManageClaimsRequirement()));

                options.AddPolicy("AddEditPurchaseOrderFilePolicy",
                policy => policy.AddRequirements(new PurchaseOrderFileManageClaimsRequirement()));
                options.AddPolicy("DeletePurchaseOrderFilePolicy",
                policy => policy.AddRequirements(new PurchaseOrderFileDeleteManageClaimsRequirement()));

                options.AddPolicy("AddEditDebitNotePolicy",
                policy => policy.AddRequirements(new PurchaseReturnFileManageClaimsRequirement()));
                options.AddPolicy("DeleteDebitNotePolicy",
                policy => policy.AddRequirements(new PurchaseReturnFileDeleteManageClaimsRequirement()));

                options.AddPolicy("AddEditSaleFilePolicy",
                policy => policy.AddRequirements(new SaleFileManageClaimsRequirement()));
                options.AddPolicy("DeleteSaleFilePolicy",
                policy => policy.AddRequirements(new SaleFileDeleteManageClaimsRequirement()));

                options.AddPolicy("AddEditCreditNotePolicy",
                policy => policy.AddRequirements(new SaleReturnFileManageClaimsRequirement()));
                options.AddPolicy("DeleteCreditNotePolicy",
                policy => policy.AddRequirements(new SaleReturnFileDeleteManageClaimsRequirement()));

                // Salary Payment
                options.AddPolicy("AddEditSalaryFilePolicy",
                policy => policy.AddRequirements(new PayBillManageClaimsRequirement()));
                options.AddPolicy("DeleteSalaryFilePolicy",
                policy => policy.AddRequirements(new PayBillDeleteManageClaimsRequirement()));
                // Report File
                options.AddPolicy("SalaryBillPrintFilePolicy",
                policy => policy.AddRequirements(new SalaryBillPrintManageClaimsRequirement()));
                options.AddPolicy("MonthlyBankStatementPrintFilePolicy",
                policy => policy.AddRequirements(new MonthlyBankStatementPrintManageClaimsRequirement()));
                options.AddPolicy("MonthlyDeductationPrintFilePolicy",
                policy => policy.AddRequirements(new MonthlyDeductationPrintManageClaimsRequirement()));
                options.AddPolicy("MonthlyExecutivePrintFilePolicy",
                policy => policy.AddRequirements(new MonthlyExecutivePrintManageClaimsRequirement()));
                options.AddPolicy("MonthlySalarySheetPrintFilePolicy",
                policy => policy.AddRequirements(new MonthlySalarySheetPrintManageClaimsRequirement()));
                // Transaction Report
                // Transaction File
                options.AddPolicy("BankPaymentBillPrintFilePolicy",
                policy => policy.AddRequirements(new BankPaymentBillPrintManageClaimsRequirement()));
                options.AddPolicy("BankReciptBillPrintFilePolicy",
                policy => policy.AddRequirements(new BankReciptBillPrintManageClaimsRequirement()));
                options.AddPolicy("CashPaymentBillPrintFilePolicy",
                policy => policy.AddRequirements(new CashPaymentBillPrintManageClaimsRequirement()));
                options.AddPolicy("CashReciptBillPrintFilePolicy",
                policy => policy.AddRequirements(new CashReciptBillPrintManageClaimsRequirement()));
                options.AddPolicy("DailySummaryPrintFilePolicy",
                policy => policy.AddRequirements(new DailySummaryPrintManageClaimsRequirement()));
                options.AddPolicy("AccountDescriptionPrintFilePolicy",
                policy => policy.AddRequirements(new AcDescriptionPrintManageClaimsRequirement()));
                options.AddPolicy("AccountGroupPrintFilePolicy",
                policy => policy.AddRequirements(new AcGroupPrintManageClaimsRequirement()));
                options.AddPolicy("AccountBalancePrintFilePolicy",
                policy => policy.AddRequirements(new AcBalancePrintManageClaimsRequirement()));

                options.AddPolicy("PurchaseOrderBillPrintFilePolicy",
                policy => policy.AddRequirements(new PurchaseOrderFileBillPrintManageClaimsRequirement()));
                options.AddPolicy("DebitNoteBillPrintFilePolicy",
                policy => policy.AddRequirements(new PurchaseReturnFileBillPrintManageClaimsRequirement()));
                options.AddPolicy("SaleBillPrintFilePolicy",
                policy => policy.AddRequirements(new SaleFileBillPrintManageClaimsRequirement()));
                options.AddPolicy("CreditNoteBillPrintFilePolicy",
                policy => policy.AddRequirements(new SaleReturnFileBillPrintManageClaimsRequirement()));

                options.AddPolicy("DownloadPrintPolicy",
                policy => policy.AddRequirements(new DownloadManageClaimsRequirement()));
                options.AddPolicy("DownloadPrintHeaderPolicy",
                policy => policy.AddRequirements(new DownloadHeaderManageClaimsRequirement()));

                // Test Report
                options.AddPolicy("DueAnalysisPrintPolicy",
                 policy => policy.AddRequirements(new DueAnalysisPrintManageClaimsRequirement()));

                options.AddPolicy("AuditFilePrintPolicy",
                 policy => policy.AddRequirements(new AuditFilePrintManageClaimsRequirement()));

                options.AddPolicy("RateListPrintPolicy",
                 policy => policy.AddRequirements(new RateListPrintManageClaimsRequirement()));

                options.AddPolicy("DueCollectionPrintPolicy",
                 policy => policy.AddRequirements(new DueCollectionPrintManageClaimsRequirement()));

                options.AddPolicy("StockSummaryPrintPolicy",
                 policy => policy.AddRequirements(new StockSummaryPrintManageClaimsRequirement()));

                options.AddPolicy("DailyCollectionPrintPolicy",
                 policy => policy.AddRequirements(new DailyCollectionPrintManageClaimsRequirement()));

                options.AddPolicy("DoctorCollectionPrintPolicy",
                 policy => policy.AddRequirements(new DoctorCollectionPrintManageClaimsRequirement()));

                options.AddPolicy("ExecutiveCollectionPrintPolicy",
                 policy => policy.AddRequirements(new ExecutiveCollectionPrintManageClaimsRequirement()));

                options.AddPolicy("IPCollectionPrintPolicy",
                 policy => policy.AddRequirements(new IPCollectionPrintManageClaimsRequirement()));

                options.AddPolicy("TestCollectionPrintPolicy",
                 policy => policy.AddRequirements(new TestCollectionPrintManageClaimsRequirement()));

                options.AddPolicy("TestGroupCollectionPrintPolicy",
                 policy => policy.AddRequirements(new TestGroupCollectionPrintManageClaimsRequirement()));


                //options.AddPolicy("EditRolePolicy",
                //policy => policy.AddRequirements(new ManageAdminRolesAndClaimsRequirement()));

                // options.AddPolicy("EditUserPolicy",
                //         policy => policy.RequireAssertion(context => context.User.IsInRole("Admin") &&
                //        context.User.HasClaim(claim => claim.Type == "Edit User" && claim.Value == "true") ||
                //         context.User.IsInRole("SuperAdmin")));

                // Roles must be Admin & SuperAdmin
                options.AddPolicy("AdminRolePolicy",
                policy => policy.RequireRole("SuperAdmin")
                                .RequireRole("Manager")
                                .RequireRole("Admin")
                                .RequireRole("User"));
               
            });

#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation();
#endif
            //services.AddHostedService<DerivedBackgroundPrinter>();
            //services.AddSingleton<IWorker, Worker>();

            // Scope method here then configure servier
            
            services.AddScoped<ISettingRepository, SettingRepository>();
            services.AddScoped<IMasterRepository, MasterRepository>();
            services.AddScoped<IFinancialRepository, FinancialRepository>();
            services.AddScoped<IGeneralMethod, GeneralMethod>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IPayBillRepository, PayBillRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmailService, EmailService>();

            // Policy First Handler Authorized Master File
            

            services.AddSingleton<IAuthorizationHandler, PatientResultAppAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, PatientResultAppOtherUserHandler>();

            services.AddSingleton<IAuthorizationHandler, PatientRegistCancelAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, PatientRegistCancelOtherUserHandler>();

            services.AddSingleton<IAuthorizationHandler, PatientResultAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, PatientResultOtherUserHandler>();

            services.AddSingleton<IAuthorizationHandler, MedResultAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, MedResultOtherUserHandler>();

            services.AddSingleton<IAuthorizationHandler, TestDocAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, TestDocOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, TestDocDeleteClaimsHandler>();

            services.AddSingleton<IAuthorizationHandler, AreaAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, AreaOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, AreaDeleteClaimsHandler>();

            services.AddSingleton<IAuthorizationHandler, ClientAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, ClientOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, ClientDeleteClaimsHandler>();

            services.AddSingleton<IAuthorizationHandler, ExecutiveAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, ExecutiveOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, ExecutiveDeleteClaimsHandler>();

            services.AddSingleton<IAuthorizationHandler, MedMasterAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, MedMasterOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, MedMasterDeleteClaimsHandler>();

            services.AddSingleton<IAuthorizationHandler, DoctorAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, DoctorOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, DoctorDeleteClaimsHandler>();

            services.AddSingleton<IAuthorizationHandler, DoctorLabAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, DoctorLabOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, DoctorLabDeleteClaimsHandler>();

            services.AddSingleton<IAuthorizationHandler, PreResultAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, PreResultOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, PreResultDeleteClaimsHandler>();

            services.AddSingleton<IAuthorizationHandler, RegistrationAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, RegistrationOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, RegistrationDeleteClaimsHandler>();

            services.AddSingleton<IAuthorizationHandler, PatientDueReciptAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, PatientDueReciptOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, PatientDueReciptDeleteClaimsHandler>();

            services.AddSingleton<IAuthorizationHandler, ReportMasterAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, ReportMasterOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, ReportMasterDeleteClaimsHandler>();

            services.AddSingleton<IAuthorizationHandler, TestAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, TestOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, TestDeleteClaimsHandler>();

            services.AddSingleton<IAuthorizationHandler, TestGroupAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, TestGroupOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, TestGroupDeleteClaimsHandler>();

            services.AddSingleton<IAuthorizationHandler, TestRateAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, TestRateOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, TestRateDeleteClaimsHandler>();

            // Financial File

            services.AddSingleton<IAuthorizationHandler, AccountGroupAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, AccountGroupOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, AccountGroupDeleteClaimsHandler>();

            services.AddSingleton<IAuthorizationHandler, AccountMasterAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, AccountMasterOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, AccountMasterDeleteClaimsHandler>();

            services.AddSingleton<IAuthorizationHandler, AccountConfigurationAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, AccountConfigurationOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, AccountConfigurationDeleteClaimsHandler>();

            services.AddSingleton<IAuthorizationHandler, ProductCompanyAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, ProductCompanyOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, ProductCompanyDeleteClaimsHandler>();

            services.AddSingleton<IAuthorizationHandler, UnitMeasurementAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, UnitMeasurementOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, UnitMeasurementDeleteClaimsHandler>();

            services.AddSingleton<IAuthorizationHandler, UQCAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, UQCOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, UQCDeleteClaimsHandler>();

            services.AddSingleton<IAuthorizationHandler, ProductMasterAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, ProductMasterOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, ProductMasterDeleteClaimsHandler>();

            services.AddSingleton<IAuthorizationHandler, ItemGroupAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, ItemGroupOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, ItemGroupDeleteClaimsHandler>();

            services.AddSingleton<IAuthorizationHandler, ItemMasterAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, ItemMasterOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, ItemMasterDeleteClaimsHandler>();

            services.AddSingleton<IAuthorizationHandler, OpenningStockAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, OpenningStockOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, OpenningStockDeleteClaimsHandler>();
            // Transaction File
            services.AddSingleton<IAuthorizationHandler, BankPaymentAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, BankPaymentOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, BankPaymentDeleteClaimsHandler>();

            services.AddSingleton<IAuthorizationHandler, BankReciptAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, BankReciptOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, BankReciptDeleteClaimsHandler>();

            services.AddSingleton<IAuthorizationHandler, CashPaymentAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, CashPaymentOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, CashPaymentDeleteClaimsHandler>();

            services.AddSingleton<IAuthorizationHandler, CashReciptAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, CashReciptOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, CashReciptDeleteClaimsHandler>();

            services.AddSingleton<IAuthorizationHandler, PurchaseFileAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, PurchaseFileOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, PurchaseFileDeleteClaimsHandler>();

            services.AddSingleton<IAuthorizationHandler, PurchaseOrderFileAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, PurchaseOrderFileOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, PurchaseOrderFileDeleteClaimsHandler>();

            services.AddSingleton<IAuthorizationHandler, PurchaseReturnFileAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, PurchaseReturnFileOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, PurchaseReturnFileDeleteClaimsHandler>();

            services.AddSingleton<IAuthorizationHandler, SaleFileAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, SaleFileOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, SaleFileDeleteClaimsHandler>();

            services.AddSingleton<IAuthorizationHandler, SaleReturnFileAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, SaleReturnFileOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, SaleReturnFileDeleteClaimsHandler>();

            // Salary Payment
            services.AddSingleton<IAuthorizationHandler, PayBillAddEditClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, PayBillOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, PayBillDeleteClaimsHandler>();

            // Report

            services.AddSingleton<IAuthorizationHandler, BankPaymentBillPrintClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, BankPaymentBillPrintOtherUserHandler>();

            services.AddSingleton<IAuthorizationHandler, BankReciptBillPrintClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, BankReciptBillPrintOtherUserHandler>();

            services.AddSingleton<IAuthorizationHandler, CashPaymentBillPrintClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, CashPaymentBillPrintOtherUserHandler>();

            services.AddSingleton<IAuthorizationHandler, CashReciptBillPrintClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, CashReciptBillPrintOtherUserHandler>();

            services.AddSingleton<IAuthorizationHandler, DailySummaryPrintClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, DailySummaryPrintOtherUserHandler>();

            services.AddSingleton<IAuthorizationHandler, AcDescriptionPrintClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, AcDescriptionPrintOtherUserHandler>();

            services.AddSingleton<IAuthorizationHandler, AcGroupPrintClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, AcGroupPrintOtherUserHandler>();

            services.AddSingleton<IAuthorizationHandler, AcBalancePrintClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, AcBalancePrintOtherUserHandler>();

            services.AddSingleton<IAuthorizationHandler, CashBookPrintClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, CashBookPrintOtherUserHandler>();

            services.AddSingleton<IAuthorizationHandler, BankBookPrintClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, BankBookPrintOtherUserHandler>();

            services.AddSingleton<IAuthorizationHandler, SalaryBillPrintClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, SalaryBillPrintOtherUserHandler>();

            services.AddSingleton<IAuthorizationHandler, MonthlyBankStatementPrintClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, MonthlyBankStatementPrintOtherUserHandler>();

            services.AddSingleton<IAuthorizationHandler, MonthlyDeductationPrintClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, MonthlyDeductationPrintOtherUserHandler>();

            services.AddSingleton<IAuthorizationHandler, MonthlyExecutivePrintClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, MonthlyExecutivePrintOtherUserHandler>();

            services.AddSingleton<IAuthorizationHandler, MonthlySalarySheetPrintClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, MonthlySalarySheetPrintOtherUserHandler>();
            // Test Report
            services.AddSingleton<IAuthorizationHandler, DueAnalysisPrintClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, DueAnalysisPrintOtherUserHandler>();

            services.AddSingleton<IAuthorizationHandler, AuditFilePrintClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, AuditFilePrintOtherUserHandler>();

            services.AddSingleton<IAuthorizationHandler, RateListPrintClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, RateListPrintOtherUserHandler>();

            services.AddSingleton<IAuthorizationHandler, DueCollectionPrintClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, DueCollectionPrintOtherUserHandler>();

            services.AddSingleton<IAuthorizationHandler, StockSummaryPrintClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, StockSummaryPrintOtherUserHandler>();

            services.AddSingleton<IAuthorizationHandler, DailyCollectionPrintClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, DoctorCollectionPrintClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, ExecutiveCollectionPrintClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, IPCollectionPrintClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, TestCollectionPrintClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, TestGroupCollectionPrintClaimsHandler>();

            services.AddSingleton<IAuthorizationHandler, DailyCollectionPrintOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, DoctorCollectionPrintOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, ExecutiveCollectionPrintOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, IPCollectionPrintOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, TestCollectionPrintOtherUserHandler>();
            services.AddSingleton<IAuthorizationHandler, TestGroupCollectionPrintOtherUserHandler>();

            services.AddSingleton<IAuthorizationHandler, DownloadClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, DownloadOtherUserHandler>();

            services.AddSingleton<IAuthorizationHandler, DownloadHeaderClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, DownloadHeaderOtherUserHandler>();

            services.Configure<SMTPConfigModel>(_configuration.GetSection("SMTPConfig"));
            services.Configure<NewMsgConfigModel>(_configuration.GetSection("NewMessageAuto"));
            services.Configure<SoftwareConfigMode>(_configuration.GetSection("SoftwareType"));
            
            //services.Configure<GCSConfigOptions>(_configuration.GetSection("GCGSConfig"));
            
            services.Configure<GCSConfigOptions>(_configuration);
            //services.Configure<GCSConfigOptions>(_configuration.GetSection("GoogleCloudStorageBucketName"));

            services.AddSingleton<ICloudStorageServices, CloudStorageServices>();

            services.AddResponseCaching();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            app.UseStaticFiles();
            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();
            app.UseResponseCaching();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            RotativaConfiguration.Setup(env.WebRootPath, "Rotativa");
        }
    }
}
