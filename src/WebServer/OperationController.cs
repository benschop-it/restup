using Restup.HttpMessage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalSend.Models;
using UniversalSend.Models.Helpers;

namespace Restup.WebServer
{
    public class OperationController
    {
        public static Dictionary<string, Func<MutableHttpServerRequest, object>> UriOperations { get; set; } = new Dictionary<string, Func<MutableHttpServerRequest, object>>();

        public static void TryRunOperationByRequestUri(MutableHttpServerRequest mutableHttpServerRequest)
        {
            //Debug.WriteLine($"uri:{mutableHttpServerRequest.Uri.ToString()}");
            string uri = StringHelper.GetURLFromURLWithQueryParmeters(mutableHttpServerRequest.Uri.ToString());
            Debug.WriteLine($"Looking for managed function for uri: {uri}");
            if(UriOperations.ContainsKey(uri))
            {
                Debug.WriteLine($"Preparing to execute managed function for uri: {uri}");
                Func<MutableHttpServerRequest,object> func = UriOperations[uri];
                func(mutableHttpServerRequest);
            }
        }
    }
}
