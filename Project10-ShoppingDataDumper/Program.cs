using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Project10_ShoppingDataDumper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mobile Phone Data Dumper");

            string url = "https://fonoapi.freshpixl.com/v1/getlatest";

            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);

            var data = new
            {
                token = "78742879dc6027bd25857a7849475b3880e90eccfd42a764"
            };

            request.AddJsonBody(data);
            var response = client.Execute<List<MobilePhoneDataModel>>(request);

            using var context = new ShoppingDbContext();
            Random _random = new Random();
            foreach (MobilePhoneDataModel d in response.Data)
            {
                Console.WriteLine("Adding -> " + d.DeviceName);
                d.Price = _random.Next(400,1400).ToString();
                context.MobilePhoneData.Add(d);
            }
            // updating database
            context.SaveChanges();
            //Console.WriteLine(response.Data);
        }
    }
}
