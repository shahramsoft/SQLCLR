using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Net;
public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void MessageToRocketChat (SqlString UserName,SqlString Message)
    {
        try
        {
            var userName = UserName.ToString();
            var message = Message.ToString();
            var userfindlst = userName.Split('\\');
            if (userfindlst.Length > 0)
            {
                var usernameGeneral = userfindlst[1];
                // SendMessageToRocket(usernameGeneral, message);
               
                string apiUrl = "http://192.168.0.42/TeamAssistant/api/PatchErrorMessage";
                //var msg = new Message { text = message };
                //var input = new Content
                //{
                //    message = msg
                //};
               
                 string jsonString = "{ \"message\":{ \"text\":\"" + message + "\"} }";
                WebClient client = new WebClient();
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                client.Encoding = System.Text.Encoding.UTF8;
                //client.Headers[HttpRequestHeader.AcceptEncoding] = "Encoding.UTF8";
                Uri uri = new Uri(apiUrl + "?name=" + usernameGeneral + "*MasterMindAgile*Main");
                client.UploadStringAsync(uri, jsonString);
                    
               
               
            }
        }
        catch (Exception)
        {

            throw;
        }
        //NotifySender(UserName.ToString(), Message.ToString());
    } 
   
        //static async System.Threading.Tasks.Task SendMessageAsync(string userName, string message)
        //{
        //    //string apiUrl = "http://localhost:24452/api/PatchErrorMessage?name=m.rahimi*MasterMindAgile*Main";
        //    string apiUrl = "http://192.168.0.42/TeamAssistant/api/PatchErrorMessage";
        //    var msg = new Message { text = message };
        //    var input = new Content
        //    {
        //        message = msg
        //    };

        //    string jsonString = (new System.Web.Script.Serialization.JavaScriptSerializer()).Serialize(input);
        //    using (var client = new Http.HttpClient())
        //    {
        //        System.Net.Http.HttpResponseMessage response = await client.PostAsync(
        //            apiUrl + "?name=" + userName + "*MasterMindAgile*Main"
        //            , new System.Net.Http.StringContent(jsonString, System.Text.Encoding.UTF8, "application/json"));

        //        // Console.WriteLine(response.IsSuccessStatusCode.ToString());
        //    }
        //}
    public void SendMessageToRocket(string userName, string message)
    {
        //string apiUrl = "http://localhost:24452/api/PatchErrorMessage?name=m.rahimi*MasterMindAgile*Main";
        string apiUrl = "http://192.168.0.42/TeamAssistant/api/PatchErrorMessage";
        var msg = new Message { text = message };
        var input = new Content
        {
            message = msg
        };

        //string jsonString = (new System.Web.Script.Serialization.JavaScriptSerializer()).Serialize(input);
        string jsonString = "{ \"message\":{ \"text\":\""+message+"\"} }";
        WebClient client = new WebClient();
        client.Headers[HttpRequestHeader.ContentType] = "application/json";
        var response = client.UploadString(apiUrl + "?name=" + userName + "*MasterMindAgile*Main", jsonString);
        //using (var client = new Http.HttpClient())
        //{
        //    System.Net.Http.HttpResponseMessage response = await client.PostAsync(
        //        apiUrl + "?name=" + userName + "*MasterMindAgile*Main"
        //        , new System.Net.Http.StringContent(jsonString, System.Text.Encoding.UTF8, "application/json"));

        //    // Console.WriteLine(response.IsSuccessStatusCode.ToString());
        //}
    }

} 
public class Content
    {
        public Message message;
    }
    public class Message
    {
        public string text { get; set; }
    }
