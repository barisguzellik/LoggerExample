using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    class Test : Logger
    {
        public OperationResult DoSomething()
        {
            Log log = new Log
            {
                DATE = DateTime.Now,
                HOSTADDRESS = "127.0.0.1",
                MESSAGE = "Message",
                URL = "localhost",
                USER = "Test"
            };

            return CreateLog(log);
        }
    }
}
