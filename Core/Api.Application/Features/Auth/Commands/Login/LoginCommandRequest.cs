using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Application.Features.Auth.Commands.Login
{

    public class LoginCommandRequest:IRequest<LoginCommandResponse>
    {
      //  [DefaultValue("Default email degeri girip swagger'da otomatik giris yapabilrsin")]
        public string Email { get; set; }
        //  [DefaultValue("Default Password degeri girip swagger'da otomatik giris yapabilrsin")]
        public string Password { get; set; }
    }
}
