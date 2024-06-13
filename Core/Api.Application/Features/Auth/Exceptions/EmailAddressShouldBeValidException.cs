using Api.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Application.Features.Auth.Exceptions
{
    public class EmailAddressShouldBeValidException:BaseExceptions
    {
        public EmailAddressShouldBeValidException():base("There is no email address like this")
        {
            
        }
    }
}
