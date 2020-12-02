using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace WebComms.Interfaces
{
    public interface IWebComms
    {
        HttpWebRequest CreateGetRequest(string urls);
        HttpWebResponse Send(HttpWebRequest request);
    }
}
