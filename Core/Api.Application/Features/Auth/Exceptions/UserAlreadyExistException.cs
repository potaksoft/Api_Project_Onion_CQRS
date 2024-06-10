using Api.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Application.Features.Auth.Exceptions
{
    public class UserAlreadyExistException:BaseExceptions
    {
        public UserAlreadyExistException() : base("There is already user like this") { }
    }
}
