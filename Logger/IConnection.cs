﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Logger
{
    interface IConnection
    {
        void GetConnection();
    }
}
