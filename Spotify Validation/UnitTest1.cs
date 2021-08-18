using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace Spotify_Validation
{
    [TestClass]
    public class ValidatingSpotify
    {
        IRestClient client;
        IRestRequest request;

        public static IRestResponse response { get; set; }
        [TestMethod]
        public void ValidateGetUserId()
        {
              string myToken = "Bearer BQDrDp5UpBBERvBVKpLC9-dhS-nELt4or9r6vC7j1nJD_Ejdc1gI1M55pF" +
            "YaYu5zQAOSLPQRsIsdBrrgp_nv95kwryq4QVdhs3Yw4sTDS8qUf701NkvbQuTQpEGAmk061vgtk-2B8UvEDlOpT" +
            "IFJlggVvK2UZxEQqy-tlwLCXxNCd-XoVKSDweO3abOARTTh_WYoD2MvePaoT9OoukRrhcm-R3x3mnjv-VQM1FCRIw";

            string getUrl = "https://api.spotify.com/v1/me";
            client = new RestClient();
            request = new RestRequest(getUrl);
            request.AddHeader("Authorization", "Token" + myToken);
            response = client.Get(request);
            Assert.AreEqual(System.Net.HttpStatusCode.OK,response.StatusCode);

            if(response.IsSuccessful)
            {
                System.Console.WriteLine("test Validated successfully with status code "+response.StatusCode +" with response :"+response.Content);

            }
            else
            {
                System.Console.WriteLine(response.ErrorException);
                System.Console.WriteLine(response.ErrorMessage);
            }
        }

        [TestMethod]
        public void RetrunPlayListBasedOnUserId()
        {
            string myToken = "Bearer BQBpy2U7dB6WJWPddDrJUxpnCouxwc_NhbUffzi4H_uK7l2-LzS3VuH_sPWF1ap" +
                "71YtSiE-CarkYty-P6snRVgrUvi7P9y7fbTmH7pD2Szb4TMHx7JuS62SzhdfkWAPcjkDr3CQ1KazqWEHsNE" +
                "bh8bnziUetj_CZhyb1shwHkhakEA6NrUJ6RfGz7RVRHbuMLtObHpBgezCX2ka1kpNL9qmNRL1bzpr1QEDdX-A6oA";

            string getUrl = "https://api.spotify.com/v1/me/playlists";
            client = new RestClient();
            request = new RestRequest(getUrl);
            request.AddHeader("Authorization", "Token" + myToken);
            response = client.Get(request);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

            if (response.IsSuccessful)
            {
                System.Console.WriteLine("test Validated successfully with status code " + response.StatusCode + " with response :" + response.Content);

            }
            else
            {
                System.Console.WriteLine(response.ErrorException);
                System.Console.WriteLine(response.ErrorMessage);
            }

        }
    }
}
