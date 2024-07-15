using ITCGKP.Data.Services.NewUpdateDeleteData;
using ITCGKP.Data.ViewModels.Setting;
using ITCGKPLAB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ITCGKPLAB.Controllers
{
    public class PaymentController : Controller
    {
        private const string _key = "rzp_test_7wOHxbdsmjwZrM";
        private const string _secret = "WvcQQnJ3Sw8ofSSzOCoR8FuV";
        private readonly ISettingRepository _repository = null;
        private CompanyDetailViewModel compModel { get; set; }
        public PaymentController(ISettingRepository SettingRepository)
        {
            _repository = SettingRepository;
        }
        [AllowAnonymous]
        [AcceptVerbs("Get", "Post")]
        public IActionResult IsCustomerIdTrueFalse(string CustomerCode)
        {
            bool user = false; // await _repository.GetCustomerIdValided(CustomerCode);
            if (user)
            {
                return Json(true);
            }
            else
            {
                return Json($"Customer Id {CustomerCode} is not correct");
            }
        }

        [AllowAnonymous]
        public ViewResult Registration()
        {
            var model = new RegistrationModel();
            return View(model);
        }
        [AllowAnonymous]
        public async Task<ViewResult> Payment(RegistrationModel registration)
        {
            compModel = await _repository.GetCompanyById(1);
            OrderModel order = new OrderModel()
            {
                OrderAmount = registration.Amount,
                Currency = "INR",
                Payment_Capture = 1,    // 0 - Manual capture, 1 - Auto capture
                Notes = new Dictionary<string, string>()
                    {
                        { "note 1", "first note while creating order" }, { "note 2", "you can add max 15 notes" }
                    }
            };
            var orderId = CreateOrder(order);

            RazorPayOptionsModel razorPayOptions = new RazorPayOptionsModel()
            {
                Key = _key,
                AmountInSubUnits = order.OrderAmountInSubUnits,
                Currency = order.Currency,
                Name = compModel.CompName,
                Description = compModel.TransCode,
                ImageLogUrl = "",
                OrderId = orderId,
                ProfileName = registration.Name,
                ProfileContact = registration.Mobile,
                ProfileEmail = registration.Email,
                CustomerId = registration.CustomerId,
                InstallId = registration.InstallId,
                PayAmount = Convert.ToInt32(registration.Amount),
                Notes = new Dictionary<string, string>()
                {
                    { "note 1", "this is a payment note" }, { "note 2", "here also, you can add max 15 notes" }
                }
            };
            return View(razorPayOptions);
        }

        private string CreateOrder(OrderModel order)
        {
            try
            {
                RazorpayClient client = new RazorpayClient(_key, _secret);
                Dictionary<string, object> options = new Dictionary<string, object>();
                options.Add("amount", order.OrderAmountInSubUnits);
                options.Add("currency", order.Currency);
                options.Add("payment_capture", order.Payment_Capture);
                options.Add("notes", order.Notes);

                Order orderResponse = client.Order.Create(options);
                var orderId = orderResponse.Attributes["id"].ToString();
                return orderId;
            }
            catch (Exception)
            {
                return null;
            }
        }
        [AllowAnonymous]
        public ViewResult AfterPayment()
        {
            var paymentStatus = Request.Form["paymentstatus"].ToString();
            if (paymentStatus == "Fail")
                return View("Fail");

            var orderId = Request.Form["orderid"].ToString();
            var paymentId = Request.Form["paymentid"].ToString();
            var signature = Request.Form["signature"].ToString();

            var validSignature = CompareSignatures(orderId, paymentId, signature);
            if (validSignature)
            {
                int? ix = Convert.ToInt32(Request.Form["CustomerId"]);
                // int nn = await _repository.OnlineTransferNewVoucher(Convert.ToInt32(Request.Form["CustomerId"]), Convert.ToInt32(Request.Form["InstallId"]), "Payment Id : " + paymentId + " Online payment success");
                ViewBag.Message = "Date " + DateTime.Now + "Congratulations!! Your payment was successful" + " Payment Id : " + paymentId + " Rs. " + Convert.ToInt32(Request.Form["PayAmount"]);
                return View("Success");
            }
            else
            {
                return View("Fail");
            }
        }

        private bool CompareSignatures(string orderId, string paymentId, string razorPaySignature)
        {
            var text = orderId + "|" + paymentId;
            var secret = _secret;
            var generatedSignature = CalculateSHA256(text, secret);
            if (generatedSignature == razorPaySignature)
                return true;
            else
                return false;
        }

        private string CalculateSHA256(string text, string secret)
        {
            string result = "";
            var enc = Encoding.Default;
            byte[]
            baText2BeHashed = enc.GetBytes(text),
            baSalt = enc.GetBytes(secret);
            System.Security.Cryptography.HMACSHA256 hasher = new HMACSHA256(baSalt);
            byte[] baHashedText = hasher.ComputeHash(baText2BeHashed);
            result = string.Join("", baHashedText.ToList().Select(b => b.ToString("x2")).ToArray());
            return result;
        }
        [AllowAnonymous]
        public ViewResult Capture()
        {
            return View();
        }
        [AllowAnonymous]
        public ViewResult CapturePayment(string paymentId)
        {
            RazorpayClient client = new RazorpayClient(_key, _secret);
            Razorpay.Api.Payment payment = client.Payment.Fetch(paymentId);
            var amount = payment.Attributes["amount"];
            var currency = payment.Attributes["currency"];

            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", amount);
            options.Add("currency", currency);
            Razorpay.Api.Payment paymentCaptured = payment.Capture(options);
            ViewBag.Message = "Payment capatured!";
            return View("Success");
        }
    }
}
