using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hobbits.Services
{
    public class LoggingService
    {
        private IRequestIdGenerator requestIdGenerator;

        private DateTimeProvider dateTimeProvider;

        public LoggingService(IRequestIdGenerator requestIdGenerator, DateTimeProvider dateTimeProvider)
        {
            this.requestIdGenerator = requestIdGenerator;
            this.dateTimeProvider = dateTimeProvider;
        }

        public void Log(string message)
        {
            // pretend this is going into a database or something similar

            Console.WriteLine(message + " " + requestIdGenerator.RequestId + " " + this.dateTimeProvider.CurrentTime);
        }
    }
}
