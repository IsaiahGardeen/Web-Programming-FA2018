using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survivor.Services
{
    public class UserNameProvider : IUserNameProvider
    {
        public string UserName => throw new InvalidOperationException("You must set your own username here");
    }
}
