using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ITCGKP.Data.Services.GeneralFunction
{
    public class GeneralMethod : IGeneralMethod
    {
        private readonly ApplicationDBContext _applicationDBContext = null;

        public GeneralMethod(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }
        public async Task<List<SelectListItem>> StoreFontSize()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            for (int i = 8; i < 40; i++)
            {
                selectListItems.Add(new SelectListItem() {Text = i + "px",Value = i + "px" });
            }
            selectListItems.Add(new SelectListItem() { Text = "initial", Value = "initial" });
            selectListItems.Add(new SelectListItem() { Text = "inherit", Value = "inherit" });
            selectListItems.Add(new SelectListItem() { Text = "large", Value = "large" });
            selectListItems.Add(new SelectListItem() { Text = "larger", Value = "larger" });
            selectListItems.Add(new SelectListItem() { Text = "medium", Value = "medium" });
            selectListItems.Add(new SelectListItem() { Text = "small", Value = "small" });
            selectListItems.Add(new SelectListItem() { Text = "smaller", Value = "smaller" });            
            selectListItems.Add(new SelectListItem() { Text = "unset", Value = "unset" });
            selectListItems.Add(new SelectListItem() { Text = "x-small", Value = "x-small" });
            selectListItems.Add(new SelectListItem() { Text = "x-large", Value = "x-large" });
            selectListItems.Add(new SelectListItem() { Text = "xx-small", Value = "xx-small" });
            selectListItems.Add(new SelectListItem() { Text = "xx-large", Value = "xx-large" });
            return await Task.FromResult(selectListItems);
        }
        public async Task<List<SelectListItem>> StoreFontStyle()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();          
            selectListItems.Add(new SelectListItem() { Text = "initial", Value = "initial" });
            selectListItems.Add(new SelectListItem() { Text = "inherit", Value = "inherit" });
            selectListItems.Add(new SelectListItem() { Text = "italic", Value = "italic" });
            selectListItems.Add(new SelectListItem() { Text = "normal", Value = "normal" });
            selectListItems.Add(new SelectListItem() { Text = "unset", Value = "unset" });

            return await Task.FromResult(selectListItems);
        }
        public async Task<List<SelectListItem>> StoreFontWeight()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem() { Text = "100", Value = "100" });
            selectListItems.Add(new SelectListItem() { Text = "200", Value = "200" });
            selectListItems.Add(new SelectListItem() { Text = "300", Value = "300" });
            selectListItems.Add(new SelectListItem() { Text = "400", Value = "400" });
            selectListItems.Add(new SelectListItem() { Text = "500", Value = "500" });
            selectListItems.Add(new SelectListItem() { Text = "600", Value = "600" });
            selectListItems.Add(new SelectListItem() { Text = "700", Value = "700" });
            selectListItems.Add(new SelectListItem() { Text = "800", Value = "800" });
            selectListItems.Add(new SelectListItem() { Text = "900", Value = "900" });
            selectListItems.Add(new SelectListItem() { Text = "bold", Value = "bold" });
            selectListItems.Add(new SelectListItem() { Text = "bolder", Value = "bolder" });
            selectListItems.Add(new SelectListItem() { Text = "initial", Value = "initial" });
            selectListItems.Add(new SelectListItem() { Text = "inherit", Value = "inherit" });            
            selectListItems.Add(new SelectListItem() { Text = "normal", Value = "normal" });
            selectListItems.Add(new SelectListItem() { Text = "unset", Value = "unset" });

            return await Task.FromResult(selectListItems);
        }
        public async Task<List<SelectListItem>> StoreLineHeight()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();           
            selectListItems.Add(new SelectListItem() { Text = "1.1", Value = "1.1" });
            selectListItems.Add(new SelectListItem() { Text = "1.2", Value = "1.2" });
            selectListItems.Add(new SelectListItem() { Text = "1.3", Value = "1.3" });
            selectListItems.Add(new SelectListItem() { Text = "1.4", Value = "1.4" });
            selectListItems.Add(new SelectListItem() { Text = "1.5", Value = "1.5" });
            selectListItems.Add(new SelectListItem() { Text = "1.6", Value = "1.6" });
            selectListItems.Add(new SelectListItem() { Text = "1.7", Value = "1.7" });
            selectListItems.Add(new SelectListItem() { Text = "1.8", Value = "1.8" });
            selectListItems.Add(new SelectListItem() { Text = "1.9", Value = "1.9" });
            selectListItems.Add(new SelectListItem() { Text = "2.0", Value = "2.0" });
            selectListItems.Add(new SelectListItem() { Text = "2.1", Value = "2.1" });
            selectListItems.Add(new SelectListItem() { Text = "2.2", Value = "2.2" });
            selectListItems.Add(new SelectListItem() { Text = "2.3", Value = "2.3" });
            selectListItems.Add(new SelectListItem() { Text = "2.4", Value = "2.4" });
            selectListItems.Add(new SelectListItem() { Text = "2.5", Value = "2.5" });
            selectListItems.Add(new SelectListItem() { Text = "initial", Value = "initial" });
            selectListItems.Add(new SelectListItem() { Text = "inherit", Value = "inherit" });
            selectListItems.Add(new SelectListItem() { Text = "normal", Value = "normal" });
            selectListItems.Add(new SelectListItem() { Text = "unset", Value = "unset" });

            return await Task.FromResult(selectListItems);
        }
        public async Task<List<SelectListItem>> StoreFontColor()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem() { Text = "black", Value = "black" });
            selectListItems.Add(new SelectListItem() { Text = "red", Value = "red" });
            selectListItems.Add(new SelectListItem() { Text = "green", Value = "green" });
            selectListItems.Add(new SelectListItem() { Text = "yellow", Value = "yellow" });
            selectListItems.Add(new SelectListItem() { Text = "blue", Value = "blue" });
            selectListItems.Add(new SelectListItem() { Text = "blueviolet", Value = "blueviolet" });
            selectListItems.Add(new SelectListItem() { Text = "brown", Value = "brown" });
            selectListItems.Add(new SelectListItem() { Text = "chartreuse", Value = "chartreuse" });
            selectListItems.Add(new SelectListItem() { Text = "chocolate", Value = "chocolate" });
            selectListItems.Add(new SelectListItem() { Text = "coral", Value = "coral" });
            selectListItems.Add(new SelectListItem() { Text = "cornflowerblue", Value = "cornflowerblue" });
            selectListItems.Add(new SelectListItem() { Text = "crimson", Value = "crimson" });
            selectListItems.Add(new SelectListItem() { Text = "darkblue", Value = "darkblue" });
            selectListItems.Add(new SelectListItem() { Text = "darkgreen", Value = "darkgreen" });

            return await Task.FromResult(selectListItems);
        }
        public async Task<List<SelectListItem>> StoreFontDecorate()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem() { Text = "dashed", Value = "dashed" });
            selectListItems.Add(new SelectListItem() { Text = "dotted", Value = "dotted" });
            selectListItems.Add(new SelectListItem() { Text = "double", Value = "double" });
            selectListItems.Add(new SelectListItem() { Text = "initial", Value = "initial" });
            selectListItems.Add(new SelectListItem() { Text = "inherit", Value = "inherit" });
            selectListItems.Add(new SelectListItem() { Text = "underline", Value = "underline" });
            selectListItems.Add(new SelectListItem() { Text = "solid", Value = "solid" });
            selectListItems.Add(new SelectListItem() { Text = "unset", Value = "unset" });
            selectListItems.Add(new SelectListItem() { Text = "none", Value = "none" });

            return await Task.FromResult(selectListItems);
        }
        public async Task<string> SendSingleMessage(string phoneno, string messagedetails)
        {
            string result = "";
            var result1 = await _applicationDBContext.SMSKeyTable.Where(x => x.MessageActive == true)
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
            }
            catch (Exception e) { return e.Message; }
            finally { myWriter.Close(); }
            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                sr.Close();
            }
            return result;
        }
        public  async Task<string > SenderSMTEmail(string emailaddress, string subjects, string bodys)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(emailaddress);
            mailMessage.Subject = subjects;
            mailMessage.Body = bodys;
            mailMessage.From = new MailAddress("rs7396531@gmail.com");
            mailMessage.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com") { };
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("rs7396531@gmail.com", "rskk!~@#$1978");
            smtp.Send(mailMessage);
            return await Task.FromResult(mailMessage.ToString());
        }
        public async Task<string> Customizedwords(double numbers)
        {
            string str1 = await Task.FromResult(numbers.ToString());
            string[] str2 = str1.Split('.');
            //int   str3 = Int32.Parse(str2[1]);
            int str3 = 0;
            double str4 = numbers * 100;
            int str5 = Convert.ToInt32(str4);
            int str6 = Convert.ToInt32(str2[0]) * 100;
            str3 = str5 - str6;

            int number = Convert.ToInt32(numbers);
            if (number == 0) return "Zero";
            if (number == -2147483648) return "Minus Two Hundred and Fourteen Crore Seventy Four Lakh Eighty Three Thousand Six Hundred and Forty Eight";
            int[] num = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (number < 0)
            {
                sb.Append("Minus ");
                number = -number;
            }
            string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };
            string[] words1 = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };
            string[] words2 = { "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };
            string[] words3 = { "Thousand ", "Lac ", "Crore " };
            string[] words4 = { "Ten", "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };
            num[0] = number % 1000; // units
            num[1] = number / 1000;
            num[2] = number / 100000;
            num[1] = num[1] - 100 * num[2]; // thousands
            num[3] = number / 10000000; // crores
            num[2] = num[2] - 100 * num[3]; // lakhs
            for (int i = 3; i > 0; i--)
            {
                if (num[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (int i = first; i >= 0; i--)
            {
                if (num[i] == 0) continue;
                u = num[i] % 10; // ones
                t = num[i] / 10;
                h = num[i] / 100; // hundreds
                t = t - 10 * h; // tens
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    if (h > 0 || i == 0) sb.Append(" "); // and
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }

            // Paisa Only 
            int x;
            u = 0; t = 0; h = 0; x = 0;
            u = str3 % 10; // ones  5
            t = str3 / 10; // 2 
            x = str3 / 10; // 2 
            //h = str3 / 100;
            //t = t - 10 * h;
            sb.Append("and ");

            if (t == 0)
                sb.Append(words0[u]);
            else if (t == 1)
                sb.Append(words1[u]);
            else
                sb.Append(words2[t - 2] + words0[u]);
            if (str3 == 0) sb.Append(" Zero ");
            return sb.ToString().TrimEnd() + " Paisa Only ";
        }
        public async Task<string> UppercaseFirstEach(string s)
        {
            char[] a = await Task.FromResult(s.ToLower().ToCharArray());
            for (int i = 0; i < a.Count(); i++)
            {
                a[i] = i == 0 || a[i - 1] == ' ' ? char.ToUpper(a[i]) : a[i];
            }
            return new string(a);
        }
        public async  Task<string> UppercaseFirst(string s)
        {
            return await Task.FromResult(char.ToUpper(s[0]) + s.Substring(1));
        }       
    }
}
