using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebComms.Interfaces;
using WooliesX.Domain;
using WooliesX.Domain.Interfaces;
using WooliesX.Domain.Models;

namespace ExternalComms
{
    public class ExternalComms : IExternalComms
    {
        IWebComms WebCommunication;
        public ExternalComms(IWebComms webCommunication)
        {
            WebCommunication = webCommunication;
        }


        public ResultValue<Exercise1Response> GetExercise1Response(string resource)
        {

            Exercise1Response resp = new Exercise1Response()
            {
                name = "Qasim",
                token = "b674c919-a9aa-4669-af1e-ff6acfb88061"
            };
            return Result.Ok(resp);

            //try
            //{
            //    var request = WebCommunication.CreateGetRequest(resource);
            //    var response = WebCommunication.Send(request);
            //    string responseFromServer = string.Empty;
            //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //    {
            //        using (Stream dataStream = response.GetResponseStream())
            //        {

            //            StreamReader reader = new StreamReader(dataStream);

            //            responseFromServer = reader.ReadToEnd();

            //            return Result.Ok(JsonConvert.DeserializeObject<Exercise1Response>(responseFromServer));

            //        }
            //    }

            //    return Result.Failed<Exercise1Response>(Error.CreateFrom("External Server Communication Error", ErrorType.InternalServerError, response.StatusDescription));

            //}
            //catch(Exception ex)
            //{
            //    return Result.Failed<Exercise1Response>(Error.CreateFrom("External Server Communication Error", ex));
            //}
            //}
        }


        public ResultValue<List<Product>> GetExercise2Response(string resource, string token)
        {
            try
            {
                var request = WebCommunication.CreateGetRequest(resource + "?token=" + token);
                var response = WebCommunication.Send(request);
                string responseFromServer = string.Empty;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    using (Stream dataStream = response.GetResponseStream())
                    {

                        StreamReader reader = new StreamReader(dataStream);

                        responseFromServer = reader.ReadToEnd();

                        return Result.Ok(JsonConvert.DeserializeObject<List<Product>>(responseFromServer));

                    }
                }

                return Result.Failed<List<Product>>(Error.CreateFrom("Error while fetching products", ErrorType.ErrorFetchingShopperHistory, response.StatusDescription));

            }
            catch (Exception ex)
            {
                return Result.Failed<List<Product>>(Error.CreateFrom("Error while fetching products", ErrorType.ErrorFetchingProducts, ex.Message));
            }
        }

        public ResultValue<List<ShopperHistory>> GetShopperHistory(string token)
        {
            try
            {
                var request = WebCommunication.CreateGetRequest("http://dev-wooliesx-recruitment.azurewebsites.net/api/resource/shopperHistory?token=" + token);
                var response = WebCommunication.Send(request);
                string responseFromServer = string.Empty;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    using (Stream dataStream = response.GetResponseStream())
                    {

                        StreamReader reader = new StreamReader(dataStream);

                        responseFromServer = reader.ReadToEnd();

                        return Result.Ok(JsonConvert.DeserializeObject<List<ShopperHistory>>(responseFromServer));

                    }
                }

                return Result.Failed<List<ShopperHistory>>(Error.CreateFrom("Error while fetching shopper history", ErrorType.ErrorFetchingShopperHistory, response.StatusDescription));

            }
            catch (Exception ex)
            {
                return Result.Failed<List<ShopperHistory>>(Error.CreateFrom("Error while fetching shopper history", ErrorType.ErrorFetchingShopperHistory, ex.Message));
            }
        }
    }

}
