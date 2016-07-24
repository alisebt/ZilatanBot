using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZilatanBot
{
    public class TelegramHelper
    {
        //here is token defenition
        //here is token defenition
        //here is token defenition
        //here is token defenition
        private string token = "";
        //this is not usabel now
        //this is not usabel now
        //this is not usabel now
        //this is not usabel now

        public static string GetMe()
        {
            var client = new RestClient("https://api.telegram.org/bot233919755:AAEo7iH806AMN7wdQSfPdpb_5UUd-UAEHZ8/getMe");
            var request = new RestRequest(Method.POST);
            request.AddHeader("postman-token", "ac76adce-b6f5-09f0-3c3a-988be847ea80");
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);
            return response.Content.ToString();
        }
        public static IRestResponse<GetUpdatesResponce> GetUpdates()
        {
            var result = new GetUpdatesResponce();
            var client = new RestClient("https://api.telegram.org/bot233919755:AAEo7iH806AMN7wdQSfPdpb_5UUd-UAEHZ8/getUpdates");
            var request = new RestRequest(Method.POST);
            request.AddHeader("postman-token", "ca1066a9-0e04-3271-462e-095e7d6c07b6");
            request.AddHeader("cache-control", "no-cache");
            //IRestResponse response = client.Execute(request);
            //result = (GetUpdatesResponce)response.Content;
            IRestResponse<GetUpdatesResponce> response2 = client.Execute<GetUpdatesResponce>(request);
            return response2;
        }
        public static string SendMessage(string ChatID, string Message)
        {
            var client = new RestClient("https://api.telegram.org/bot233919755:AAEo7iH806AMN7wdQSfPdpb_5UUd-UAEHZ8/sendMessage");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("postman-token", "d5b83364-ce84-844a-9cda-f605932fec78");
            request.AddHeader("cache-control", "no-cache");
            request.AddParameter("application/x-www-form-urlencoded", string.Format("chat_id={0}&text={1}", ChatID, Message), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content.ToString();
        }


        public static bool SendMessageWithKeyboard(string ChatID, string Message, string KeyboardButtons)
        {
            //var client = new RestClient("https://api.telegram.org/bot233919755:AAEo7iH806AMN7wdQSfPdpb_5UUd-UAEHZ8/sendMessage");
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("postman-token", "642ae6b1-1536-4c50-766c-80734eba2cde");
            //request.AddHeader("cache-control", "no-cache");
            //request.AddHeader("content-type", "multipart/form-data; boundary=---011000010111000001101001");
            //request.AddParameter("multipart/form-data; boundary=---011000010111000001101001", "-----011000010111000001101001\r\nContent-Disposition: form-data; name=\"chat_id\"\r\n\r\n104964794\r\n-----011000010111000001101001\r\nContent-Disposition: form-data; name=\"text\"\r\n\r\nKeyboardTest\r\n-----011000010111000001101001\r\nContent-Disposition: form-data; name=\"reply_markup\"\r\n\r\n{\"keyboard\":[[{\"text\":\"نام کاربری\",\"request_contact\":false,\"request_location\":false},\"تصویر پروفایل\"]] ,\"resize_keyboard\":false,\"one_time_keyboard\":true}\r\n-----011000010111000001101001--", ParameterType.RequestBody);
            //IRestResponse response = client.Execute(request);


            //{"keyboard":[["نام کاربری","تصویر پروفایل"]] ,"resize_keyboard":false,"one_time_keyboard":true}

            var keyboard = "{\"keyboard\":[[\"نام کاربری\",\"تصویر پروفایل\"]] ,\"resize_keyboard\":false,\"one_time_keyboard\":true}";
            var client = new RestClient("https://api.telegram.org/bot233919755:AAEo7iH806AMN7wdQSfPdpb_5UUd-UAEHZ8/sendMessage");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("postman-token", "d5b83364-ce84-844a-9cda-f605932fec78");
            request.AddHeader("cache-control", "no-cache");
            request.AddParameter("application/x-www-form-urlencoded", string.Format("chat_id={0}&text={1}&reply_markup={2}", ChatID, Message, keyboard), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return true;
        }
    }


    public class From
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string username { get; set; }
    }

    public class Chat
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string username { get; set; }
        public string type { get; set; }
    }

    public class Entity
    {
        public string type { get; set; }
        public int offset { get; set; }
        public int length { get; set; }
    }

    public class Message
    {
        public int message_id { get; set; }
        public From from { get; set; }
        public Chat chat { get; set; }
        public int date { get; set; }
        public string text { get; set; }
        public List<Entity> entities { get; set; }
    }

    public class Result
    {
        public int update_id { get; set; }
        public Message message { get; set; }
    }

    public class GetUpdatesResponce
    {
        public bool ok { get; set; }
        public List<Result> result { get; set; }
    }



}