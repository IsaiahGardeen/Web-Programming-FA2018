﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hobbits.Services
{
    public class RequestIdGenerator : IRequestIdGenerator
    {
        public string RequestId { get; }

        public RequestIdGenerator()
        {
            RequestId = Guid.NewGuid().ToString();
        }
    }
}
