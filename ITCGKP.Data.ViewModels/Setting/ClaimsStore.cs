using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ITCGKP.Data.ViewModels.Setting
{
    public static class ClaimsStore
    {
        public static List<Claim> AllClaims = new List<Claim>()
        {
            new Claim("Create Role","Create Role"),
            new Claim("Edit Role","Edit Role"),
            new Claim("Delete Role","Delete Role"),

            new Claim("Create User","Create User"),
            new Claim("Edit User","Edit User"),
            new Claim("Delete User","Delete User"),

            new Claim("Create Title","Create Title"),
            new Claim("Edit Title","Edit Title"),
            new Claim("Delete Title","Delete Title"),


            new Claim("Create State","Create State"),
            new Claim("Edit State","Edit State"),
            new Claim("Delete State","Delete State"),


            new Claim("Create District","Create District"),
            new Claim("Edit District","Edit District"),
            new Claim("Delete District","Delete District"),


            new Claim("Create Company","Create Company"),
            new Claim("Edit Company","Edit Company"),
            new Claim("Delete Company","Delete Company"),

            new Claim("Create SMSKey","Create SMSKey"),
            new Claim("Edit SMSKey","Edit SMSKey"),
            new Claim("Delete SMSKey","Delete SMSKey"),

            new Claim("Create SMSFile","Create SMSFile"),
            new Claim("Edit SMSFile","Edit SMSFile"),
            new Claim("Delete SMSFile","Delete SMSFile"),

            new Claim("Create MoneyMaster","Create MoneyMaster"),
            new Claim("Edit MoneyMaster","Edit MoneyMaster"),
            new Claim("Delete MoneyMaster","Delete MoneyMaster"),

            new Claim("Create UploadPhotoFile","Create UploadPhotoFile"),
            new Claim("Edit UploadPhotoFile","Edit UploadPhotoFile"),
            new Claim("Delete UploadPhotoFile","Delete UploadPhotoFile"),

            new Claim("Chart Show","Chart Show"),
            new Claim("Customer Status","Customer Status"),

            new Claim("Send Message","Send Message"),

            // Master File
            new Claim("Create PageSetup","Create PageSetup"),
            new Claim("Edit PageSetup","Edit PageSetup"),
            new Claim("Delete PageSetup","Delete PageSetup"),

            new Claim("Create Test Doc","Create Test Doc"),
            new Claim("Edit Test Doc","Edit Test Doc"),
            new Claim("Delete Test Doc","Delete Test Doc"),

            new Claim("Create Area","Create Area"),
            new Claim("Edit Area","Edit Area"),
            new Claim("Delete Area","Delete Area"),

            new Claim("Create Client","Create Client"),
            new Claim("Edit Client","Edit Client"),
            new Claim("Delete Client","Delete Client"),

            new Claim("Create Executive","Create Executive"),
            new Claim("Edit Executive","Edit Executive"),
            new Claim("Delete Executive","Delete Executive"),

            new Claim("Create Test Group","Create Test Group"),
            new Claim("Edit Test Group","Edit Test Group"),
            new Claim("Delete Test Group","Delete Test Group"),

            new Claim("Create Medical Master","Create Medical Master"),
            new Claim("Edit  Medical Master","Edit Medical Master"),
            new Claim("Delete Medical Master","Delete Medical Master"),

            new Claim("Create Doctor","Create Doctor"),
            new Claim("Edit  Doctor","Edit Doctor"),
            new Claim("Delete Doctor","Delete Doctor"),

            new Claim("Create Doctor Lab","Create Doctor Lab"),
            new Claim("Edit  Doctor Lab","Edit Doctor Lab"),
            new Claim("Delete Doctor Lab","Delete Doctor Lab"),

            new Claim("Create Report Master","Create Report Master"),
            new Claim("Edit Report Master","Edit Report Master"),
            new Claim("Delete Report Master","Delete Report Master"),

            new Claim("Create Test Master","Create Test Master"),
            new Claim("Edit Test Master","Edit Test Master"),
            new Claim("Delete Test Master","Delete Test Master"),

            new Claim("Create Test Rate","Create Test Rate"),
            new Claim("Edit Test Rate","Edit Test Rate"),
            new Claim("Delete Test Rate","Delete Test Rate"),

            new Claim("Create Pre-Result","Create Pre-Result"),
            new Claim("Edit Pre-Result","Edit Pre-Result"),
            new Claim("Delete Pre-Result","Delete Pre-Result"),

            new Claim("Create Registration","Create Registration"),
            new Claim("Edit Registration","Edit Registration"),
            new Claim("Delete Registration","Delete Registration"),

            new Claim("Create Patient Due Receipt","Create Patient Due Receipt"),
            new Claim("Edit Patient Due Receipt","Edit Patient Due Receipt"),
            new Claim("Delete Patient Due Receipt","Delete Patient Due Receipt"),

            // Finanacial File
            new Claim("Create Account Group","Create Account Group"),
            new Claim("Edit Account Group","Edit Account Group"),
            new Claim("Delete Account Group","Delete Account Group"),

            new Claim("Create Account Master","Create Account Master"),
            new Claim("Edit Account Master","Edit Account Master"),
            new Claim("Delete Account Master","Delete Account Master"),

            new Claim("Create Account Configuration","Create Account Configuration"),
            new Claim("Edit Account Configuration","Edit Account Configuration"),
            new Claim("Delete Account Configuration","Delete Account Configuration"),

            new Claim("Create Product Company","Create Product Company"),
            new Claim("Edit Product Company","Edit Product Company"),
            new Claim("Delete Product Company","Delete Product Company"),

            new Claim("Create Unit Measurement","Create Unit Measurement"),
            new Claim("Edit Unit Measurement","Edit Unit Measurement"),
            new Claim("Delete Unit Measurement","Delete Unit Measurement"),

             new Claim("Create Unit Quantity","Create Unit Quantity"),
            new Claim("Edit Unit Quantity","Edit Unit Quantity"),
            new Claim("Delete Unit Quantity","Delete Unit Quantity"),

            new Claim("Create Product Master","Create Product Master"),
            new Claim("Edit Product Master","Edit Product Master"),
            new Claim("Delete Product Master","Delete Product Master"),

            new Claim("Create Item Group","Create Item Group"),
            new Claim("Edit Item Group","Edit Item Group"),
            new Claim("Delete Item Group","Delete Item Group"),

            new Claim("Create Item Master","Create Item Master"),
            new Claim("Edit Item Master","Edit Item Master"),
            new Claim("Delete Item Master","Delete Item Master"),

            new Claim("Create Openning Stock File","Create Openning Stock File"),
            new Claim("Edit Openning Stock File","Edit Openning Stock File"),
            new Claim("Delete Openning Stock File","Delete Openning Stock File"),

            // Transaction File
            new Claim("Create Bank Payment","Create Bank Payment"),
            new Claim("Edit Bank Payment","Edit Bank Payment"),
            new Claim("Delete Bank Payment","Delete Bank Payment"),

            new Claim("Create Bank Recipt","Create Bank Recipt"),
            new Claim("Edit Bank Recipt","Edit Bank Recipt"),
            new Claim("Delete Bank Recipt","Delete Bank Recipt"),

            new Claim("Create Cash Payment","Create Cash Payment"),
            new Claim("Edit Cash Payment","Edit Cash Payment"),
            new Claim("Delete Cash Payment","Delete Cash Payment"),

            new Claim("Create Cash Recipt","Create Cash Recipt"),
            new Claim("Edit Cash Recipt","Edit Cash Recipt"),
            new Claim("Delete Cash Recipt","Delete Cash Recipt"),

            new Claim("Create Purchase File","Create Purchase File"),
            new Claim("Edit Purchase File","Edit Purchase File"),
            new Claim("Delete Purchase File","Delete Purchase File"),

            new Claim("Create Debit Note File","Create Debit Note File"),
            new Claim("Edit Debit Note File","Edit Debit Note File"),
            new Claim("Delete Debit Note File","Delete Debit Note File"),

            new Claim("Create Sale File","Create Sale File"),
            new Claim("Edit Sale File","Edit Sale File"),
            new Claim("Delete Sale File","Delete Sale File"),

            new Claim("Create Credit Note File","Create Credit Note File"),
            new Claim("Edit Credit Note File","Edit Credit Note File"),
            new Claim("Delete Credit Note File","Delete Credit Note File"),

            new Claim("Create Order File","Create Order File"),
            new Claim("Edit Order File","Edit Order File"),
            new Claim("Delete Order File","Delete Order File"),

            // Pay Bill File
            new Claim("Create Pay Bill File","Create Pay Bill File"),
            new Claim("Edit Pay Bill File","Edit Pay Bill File"),
            new Claim("Delete Pay Bill File","Delete Pay Bill File"),

            // Report File
             new Claim("Debit Note Bill Print","Debit Note Bill Print"),
            new Claim("Credit Note Bill Print","Credit Note Bill Print"),
            new Claim("Sale Bill Print","Sale Bill Print"),
            new Claim("Order Bill Print","Order Bill Print"),

            new Claim("Daily Summary Print","Daily Summary Print"),
            new Claim("Account Description Print","Account Description Print"),
            new Claim("Account Group Print","Account Group Print"),
            new Claim("Account Balance Print","Account Balance Print"),

             new Claim("Bank Payment Bill Print","Bank Payment Bill Print"),
            new Claim("Bank Recipt Bill Print","Bank Recipt Bill Print"),
            new Claim("Cash Payment Bill Print","Cash Payment Bill Print"),
            new Claim("Cash Recipt Bill Print","Cash Recipt Bill Print"),

            new Claim("Cash Book Print","Cash Book Print"),
            new Claim("Bank Book Print","Bank Book Print"),

            new Claim("Salary Bill Print","Salary Bill Print"),
            new Claim("Monthly Executive List","Monthly Executive List"),
            new Claim("Monthly Salary Sheet","Monthly Salary Sheet"),
            new Claim("Monthly Salary Bank Statement","Monthly Salary Bank Statement"),
            new Claim("Monthly Deductation List","Monthly Deductation List"),

            // Test Reporting
            new Claim("Due Analysis","Due Analysis"),
            new Claim("Audit File","Audit File"),
            new Claim("Rate List","Rate List"),
            new Claim("Due Collection Print","Due Collection Print"),
            new Claim("Stock Summary","Stock Summary"),

            new Claim("Daily Collection Print","Daily Collection Print"),
            new Claim("Executive Wise Print","Executive Wise Print"),
            new Claim("Doctor Wise Print","Doctor Wise Print"),
            new Claim("Test Group Wise Print","Test Group Wise Print"),
            new Claim("Test Wise Print","Test Wise Print"),
            new Claim("IP Collection Print","IP Collection Print"),

            new Claim("Patient Result","Patient Result"),
            new Claim("Medical Result","Medical Result"),

            new Claim("Download Print","Download Print"),
            new Claim("Download Header","Download Header"),

            new Claim("Result Approved","Result Approved"),
            new Claim("Registration Cancel","Registration Cancel")
        };      
    }
}
