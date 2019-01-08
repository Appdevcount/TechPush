using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TechPush.Common.APIConsumption
{
    public class APIDataAccess
    {
        private string Base_URL = "http://localhost/WEBAPIProject/api/";

        public string GetGoogleRedirAPIURL()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                HttpResponseMessage response = client.GetAsync("customersapi/").Result;

                if (response.IsSuccessStatusCode)
                {

                    string JsonString = response.Content.ReadAsStringAsync().Result;

                    dynamic jObj = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(JsonString);

                    //    parsedToken.user_id = jObj["data"]["user_id"];
                    //    parsedToken.app_id = jObj["data"]["app_id"];


                    ////use JavaScriptSerializer from System.Web.Script.Serialization
                    //JavaScriptSerializer JSserializer = new JavaScriptSerializer();
                    ////deserialize to your class
                    //return JSserializer.Deserialize<Customer>(JsonString);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }


        //public IEnumerable<Customer> findAll()
        //{
        //    try
        //    {
        //        HttpClient client = new HttpClient();
        //        client.BaseAddress = new Uri(Base_URL);
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        HttpResponseMessage response = client.GetAsync("customersapi").Result;

        //        if (response.IsSuccessStatusCode)
        //        {
        //            string JsonString = response.Content.ReadAsStringAsync().Result;
        //            //use JavaScriptSerializer from System.Web.Script.Serialization
        //            JavaScriptSerializer JSserializer = new JavaScriptSerializer();
        //            //deserialize to your class
        //            return JSserializer.Deserialize<IEnumerable<Customer>>(JsonString);
        //        }
        //        return null;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}
        //public Customer find(int id)
        //{
        //    try
        //    {
        //        HttpClient client = new HttpClient();
        //        client.BaseAddress = new Uri(Base_URL);
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        HttpResponseMessage response = client.GetAsync("customersapi/" + id).Result;

        //        if (response.IsSuccessStatusCode)
        //        {

        //            string JsonString = response.Content.ReadAsStringAsync().Result;
        //            //use JavaScriptSerializer from System.Web.Script.Serialization
        //            JavaScriptSerializer JSserializer = new JavaScriptSerializer();
        //            //deserialize to your class
        //            return JSserializer.Deserialize<Customer>(JsonString);
        //        }
        //        return null;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
        //public bool Create(Customer customer)
        //{
        //    try
        //    {
        //        HttpClient client = new HttpClient();
        //        client.BaseAddress = new Uri(Base_URL);
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        HttpResponseMessage response = client.PostAsync("customersapi", new StringContent(
        //            new JavaScriptSerializer().Serialize(customer), Encoding.UTF8, "application/json")).Result;
        //        return response.IsSuccessStatusCode;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public bool Edit(Customer customer)
        //{
        //    try
        //    {
        //        HttpClient client = new HttpClient();
        //        client.BaseAddress = new Uri(Base_URL);
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        HttpResponseMessage response = client.PutAsync("customersapi/" + customer.CustId, new StringContent(
        //            new JavaScriptSerializer().Serialize(customer), Encoding.UTF8, "application/json")).Result;
        //        return response.IsSuccessStatusCode;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public bool Delete(int id)
        //{
        //    try
        //    {
        //        HttpClient client = new HttpClient();
        //        client.BaseAddress = new Uri(Base_URL);
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        HttpResponseMessage response = client.DeleteAsync("customersapi/" + id).Result;
        //        return response.IsSuccessStatusCode;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
    }

}

