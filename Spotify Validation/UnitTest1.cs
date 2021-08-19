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
              string myToken = "Bearer BQCINCdXC61yeXlJzLluSEtgzagpBqU4-YiB_RquGTeMyqlqKtS1c7rJpskQDTcz-ZQjxn6lSj4LMznIJmrnf5WbGHitnv18tbNDGy1VueyUr9sb1ROJqIbAJcO6Vzor5TJYy8esRHtKVj4p5uD2C7BD3id3U7dV_ZdX7US53KnBlZyoPvIBj19r-efnJMyU62ufcFKG7n5IUva-iT9wKuuIkurGXYVSykLw4hiVAg";

            string getUrl = "https://api.spotify.com/v1/me";
            client = new RestClient();
            request = new RestRequest(getUrl);
            request.AddHeader("Authorization", "Token" + myToken);
            response = client.Get(request);
            Assert.AreEqual(System.Net.HttpStatusCode.OK,response.StatusCode);

            if(response.IsSuccessful)
            {
                System.Console.WriteLine("test Validated successfully with status code "+response.StatusCode +"\n with response :"+response.Content);

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
            string myToken = "Bearer BQCINCdXC61yeXlJzLluSEtgzagpBqU4-YiB_RquGTeMyqlqKtS1c7rJpskQDTcz-ZQjxn6lSj4LMznIJmrnf5WbGHitnv18tbNDGy1VueyUr9sb1ROJqIbAJcO6Vzor5TJYy8esRHtKVj4p5uD2C7BD3id3U7dV_ZdX7US53KnBlZyoPvIBj19r-efnJMyU62ufcFKG7n5IUva-iT9wKuuIkurGXYVSykLw4hiVAg";

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

        [TestMethod]
        public void AddItemToPlaylist()
        {
            string token = "Bearer BQDE4EotaEKC1mqbdMjjOteJUgL9X_N5YgZq8ZQuoyTziT4MEm2O_VlEwJ8JKt-XNKIUdZGP1Mk1GXVcHjjLkQHOKjjAawj1riW-OVWJZE5-HwxDnBoLH-P5GACuQaK6QHhjjKuDeOPtcKZZ2R6T7AczhRv2v5Hysol-2v8p_D7LVtRonQ93yftvQSYyRNOgv51ZIU83xZ_E37a_Moumc9RsTH7tMUo8RoJx7hQN4g";
            string getUrl = "https://api.spotify.com/v1/playlists/2surb9o4zDYqsICbov4m8l/tracks?uris=spotify%3Atrack%3A5sbooPcNgIE22DwO0VNGUJ";
            client = new RestClient();
            request = new RestRequest(getUrl);
            request.AddHeader("Authorization", "Token" + token);
            response = client.Post(request);
            Assert.AreEqual(201, (int)response.StatusCode);
           // Assert.AreEqual(System.Net.HttpStatusCode.Created, response.StatusCode);

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
        [TestMethod]
        public void CreatePlaylist()
        {
            string myToken = "Bearer BQCLneQmnXVbY2RyvYOlED2YBF4P82dxz1aoUhXCcGALTlU0nPPYl5HeuCrr94fXAmI_MgBHEU2zlfXK9wPM_K2utYAftUfD5Vwm18RqXL44bimAz0dVAjSGwJghKaWSll_sQbLlYTCNBx2qWHTLEO1Wb2YTDViwObr8UcUCdL3UlcPYuytMlvDsAOfPb0W1VPVpfc4Z5GhsxKgDgLYV7qZSE-xf2vO-4UjTRCvfOQ";
            string getUrl = "https://api.spotify.com/v1/users/lb61yakft7sa7njpc85qwkh8l/playlists";
            string jsonBody = "{"+
                                 "\"name\":\"Classics\","+
                                 "\"description\": \"Recent songs\","+
                                  "\"public\": false"+
                               "}";
            client = new RestClient();
            request = new RestRequest(getUrl);
            request.AddHeader("Authorization", "Token" + myToken);
            request.AddJsonBody(jsonBody);
            response = client.Post(request);
            Assert.AreEqual(201, (int)response.StatusCode);
            

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
