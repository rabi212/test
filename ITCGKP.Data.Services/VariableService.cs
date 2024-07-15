using System;
using System.Collections.Generic;
using System.Text;

namespace ITCGKP.Data.Services
{
    public class VariableService
    {
        public DateTime sdate, edate;
        public int MonthNo = 0, MonthFirst = 0, eamt, CurrentIndex = 0, hrano = 0, ccano = 0, newdepartid = 0, newdesigid = 0,
        newscaleid = 0, gradepay = 0, newbasic = 0;
        public string[] userdt;
        public string userdt1, userdt2, userdt3, userdt4,vno, remark1 = "", remark2 = "", remark3 = "", remark4 = "";
        public decimal hamt = 0, wamt = 0, samt = 0,tamt = 0;
        public double DAPer = 0,GPFPer = 0,grossamt = 0,deductamt = 0, netamt = 0,
        daamt = 0, ccamt = 0, hraamt = 0, familyhelp = 0,glicamt = 0,npsamt = 0,
        gpfamt = 0, daarrear = 0,vechilearrea = 0,other1 = 0, other2 = 0, loanamt = 0,itamt = 0,hrentamt = 0,other3 = 0;
        public double ConvertRound(double no)
        {
            double secondno = 0, intno = 0;
            intno = Convert.ToInt32(no);
            secondno = no - intno;
            intno = secondno >= 0.5 ? intno += 1 : intno += 0;
            return intno;
        }
    }
}
