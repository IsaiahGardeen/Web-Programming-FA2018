using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hobbits.Services
{
    public class RequestIdGeneratorInts : IRequestIdGenerator
    {
        private static int currentId = 1;

        private string requestId;

        public RequestIdGeneratorInts()
        {
            this.requestId = currentId++.ToString();
        }

        public string RequestId => requestId;
    }
}
