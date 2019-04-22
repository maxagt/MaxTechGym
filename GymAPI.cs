using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;
using System.Text;
using Newtonsoft.Json;
using MaxTechGym.Models;
using System.Threading.Tasks;
using System.Data;

namespace MaxTechGym
{
    static class GymAPI
    {
        private static HttpClient client;
        private static string credentials;

        static GymAPI()
        {
            client = new HttpClient();
            credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", "ibarrapromotions", "2030joel")));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
            client.BaseAddress = new Uri("http://10.37.129.2:3000/");
        }

        public static async Task<DateTime> GetDateTime()
        {
            try
            {
                string result = await client.GetStringAsync(client.BaseAddress + "now/");
                Date currentTime = JsonConvert.DeserializeObject<Date>(result);
                return currentTime.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static async Task<DataTable> getMembers(string parameters)
        {
            try
            {
                string result = await client.GetStringAsync(client.BaseAddress + "members?" + parameters);
                DataTable memberList = (DataTable)JsonConvert.DeserializeObject(result, (typeof(DataTable)));

                return memberList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<DataTable> getMemberById(string id)
        {
            try
            {
                string result = await client.GetStringAsync(client.BaseAddress + "members/" + id);
                DataTable memberList = (DataTable)JsonConvert.DeserializeObject(result, (typeof(DataTable)));

                return memberList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<HttpResponseMessage> updateMemberById(string id)
        {
            try
            {
                string json = JsonConvert.SerializeObject(null);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage result = await client.PutAsync(client.BaseAddress + "members/" + id, content);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static async Task<HttpResponseMessage> insertVisitById(string id)
        {
            try
            {
                string json = JsonConvert.SerializeObject(null);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage result = await client.PostAsync(client.BaseAddress + "members/" + id, content);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public static async Task<HttpResponseMessage> insertMember(Member member)
        {
            try
            {
                string json = JsonConvert.SerializeObject(member);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage result = await client.PostAsync(client.BaseAddress + "members/", content);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        //Get all the fingerprints paired with the correspondant Id
        public static async Task<DataTable> getAllFingerPrints()
        {
            try
            {
                string result = await client.GetStringAsync(client.BaseAddress + "fingerprints/");
                DataTable memberList = (DataTable)JsonConvert.DeserializeObject(result, (typeof(DataTable)));

                return memberList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
