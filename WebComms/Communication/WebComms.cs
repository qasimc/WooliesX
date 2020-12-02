using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using WebComms.Interfaces;

namespace WebComms.Communication
{
    public class WebComms : IWebComms
    {
        public HttpWebRequest CreateGetRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            return request;
        }
        public HttpWebResponse Send(HttpWebRequest request)
        {

            HttpWebResponse response;
            response = (HttpWebResponse)request.GetResponse();
            return response;
        }
    }
}
