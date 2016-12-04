using CF.Public;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication1 {
    public class PaymentManager : IPayWithVivaWallet
    {
        private const string merchantId = "6466348D-85B2-4CBC-978B-422C688D2D45";
        private const string apiKey = "Y^!xL#";

        public async Task <bool> SendPaymentAsync() {
            if ( HttpContext.Current.Request.HttpMethod == "POST" ) {
                var cl = new RestClient("https://demo.vivapayments.com/api/") {
                    Authenticator = new HttpBasicAuthenticator(merchantId, apiKey)
                };
                var request = new RestRequest("transactions", Method.POST) {
                    RequestFormat = DataFormat.Json
                };

                request.AddParameter("PaymentToken", HttpContext.Current.Request.Form["vivaWalletToken"]);

                var response = await cl.ExecuteTaskAsync<TransactionResult>(request);

                if (response.Data != null)
                {
                    HttpContext.Current.Response.Write(response.Data.ErrorCode + "--" + response.Data.ErrorText);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        HttpContext.Current.Response.Write("<br />Successful payment");
                    }
                    return true;
                }
                else
                {
                    HttpContext.Current.Response.Write(response.ResponseStatus);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }

    public class TransactionResult {
        public int ErrorCode { get; set; }
        public string ErrorText { get; set; }
        public decimal Amount { get; set; }
        public Guid TransactionId { get; set; }
    }
}
