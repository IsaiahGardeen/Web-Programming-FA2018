﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hobbits.Services
{
    public interface IRequestIdGenerator
    {
        string RequestId { get; }
    }
}
