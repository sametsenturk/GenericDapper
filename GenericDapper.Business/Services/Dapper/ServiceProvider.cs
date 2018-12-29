using GenericDapper.Business.Services.Dapper.EntityService;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericDapper.Business.Services.Dapper
{
    public class ServiceProvider : IDisposable
    {
        private UserService _userService;
        private LogService _logService;

        public UserService User { get { return _userService ?? new UserService(); } }
        public LogService Log { get { return _logService ?? new LogService(); } }

        public void Dispose()
        {
            this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
