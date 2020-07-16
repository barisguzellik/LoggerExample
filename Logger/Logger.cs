using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class Logger : IConnection
    {
        SqlConnection _Connection;
        public void GetConnection()
        {
            _Connection = new SqlConnection("Server");
        }
        #region Get Data
        //Get All Logs
        public IList<Log> GetLogs()
        {
            return _Connection.Query<Log>("SELECT*FROM LOG ORDER BY DATE DESC", new { }).ToList();
        }

        //Get Log
        public Log GetLog(Log log)
        {
            return _Connection.QueryAsync<Log>("SELECT*FROM LOG WHERE LOGID=@LOGID", new { LOGID = log.LOGID }).Result.First();
        }
        #endregion

        #region Create
        //Create Log
        public OperationResult CreateLog(Log log)
        {
            var operation = _Connection.ExecuteAsync("INSERT INTO LOG(USER,DATE,HOSTADDRESS,URL,MESSAGE) VALUES(@USER,@DATE,@HOSTADDRESS,@URL,@MESSAGE)",
                new
                {
                    USER = log.USER,
                    DATE = log.DATE,
                    HOSTADDRESS = log.HOSTADDRESS,
                    URL = log.URL,
                    MESSAGE = log.MESSAGE
                });

            if (operation.IsCompleted)
            {
                return new OperationResult
                {
                    Code = "ok",
                    Status = true,
                    Message = "Completed"
                };
            }
            else
            {
                return new OperationResult
                {
                    Code = "fault",
                    Status = false,
                    Message = operation.Exception.Message
                };
            }
        }

        #endregion
    }
}
