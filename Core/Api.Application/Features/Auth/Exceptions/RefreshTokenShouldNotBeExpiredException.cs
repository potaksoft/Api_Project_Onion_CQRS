using Api.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Application.Features.Auth.Exceptions
{
    public class RefreshTokenShouldNotBeExpiredException:BaseExceptions
    {
        public RefreshTokenShouldNotBeExpiredException() : base("Time is Up.Please try again") { } 
    }
}
