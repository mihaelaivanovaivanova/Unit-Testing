using Academy.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.Models.Abstraction.Mocks
{
    class UserMock : User
    {
        internal UserMock(string username) : base(username)
        {
        }
    }
}
