using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SimpleOAuth;

namespace SimpleOAuthOneLegged
{
    class Program
    {
        static Tokens RequestTokens { get; set; }

        static void Main(string[] args)
        {
            RequestTokens = new Tokens() { ConsumerKey = "", ConsumerSecret = "" };

            var url = "http://www.uitid.be/uitid/rest/searchv2/search?q=category_name:\"Kamp of vakantie\"&fq=agefrom:[6 TO 8]&fq=keywords:\"Zonder overnachting\"&fq=type:event&group=event&start=0&rows=12&datetype=next30days&fq=zipcode=1000!40km";
            var request = WebRequest.Create(url);

            request.Method = "GET";

            request.SignRequest().WithTokens(RequestTokens).InHeader();
            WebResponse webResponse = request.GetResponse();
        }
    }
}
