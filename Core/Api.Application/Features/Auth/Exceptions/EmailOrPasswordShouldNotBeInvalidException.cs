using Api.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Application.Features.Auth.Exceptions
{
    public  class EmailOrPasswordShouldNotBeInvalidException:BaseExceptions
    {
        public EmailOrPasswordShouldNotBeInvalidException() : base("UserName or Password wrong") { }
        
    }
}
