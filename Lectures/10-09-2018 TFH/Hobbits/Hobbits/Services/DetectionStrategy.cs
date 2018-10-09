using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Hobbits.Services
{
    public class DetectionStrategy : ITransientErrorDetectionStrategy
    {
        public bool IsTransient(Exception ex)
        {
            var webException = ex as WebException;
            var response = webException?.Response as HttpWebResponse;
            return response?.StatusCode == HttpStatusCode.ServiceUnavailable;
        }
    }
}
