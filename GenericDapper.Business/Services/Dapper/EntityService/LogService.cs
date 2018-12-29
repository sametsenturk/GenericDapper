using GenericDapper.Business.Services.Dapper.Base;
using GenericDapper.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericDapper.Business.Services.Dapper.EntityService
{
    public class LogService:BaseService<Log>
    {
        public LogService()
        {
            this._tableName = "logs";
        }
    }
}
