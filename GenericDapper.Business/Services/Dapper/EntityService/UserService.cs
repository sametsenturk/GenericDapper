using GenericDapper.Business.Services.Dapper.Base;
using GenericDapper.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericDapper.Business.Services.Dapper.EntityService
{
    public class UserService:BaseService<User>
    {
        public UserService()
        {
            this._tableName = "users";
        }
    }
}
