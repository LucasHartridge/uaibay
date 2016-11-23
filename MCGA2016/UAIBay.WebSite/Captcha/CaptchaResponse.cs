using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Diagnostics;
using Newtonsoft.Json;

namespace UAIBay.WebSite.Captcha
{

    public class CaptchaResponse
    {
        [JsonProperty("success")]
        public string Success { get; set; }

        [JsonProperty("error-codes")]
        public List<string> ErrorCodes;
    }

}