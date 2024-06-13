using Api.Application.Bases;
using Api.Application.Interfaces.AutoMappers;
using Api.Application.Interfaces.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Api.Application.Features.Auth.Commands.RevokeAll
{
    public class RevokeAllCommandHandler : BaseHandler,IRequestHandler<RevokeAllCommandRequest,Unit>
    {
        private readonly UserManager<User> _userManagaer;
        public RevokeAllCommandHandler(UserManager<User> userManager,IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor) : base(mapper, unitOfWork, contextAccessor)
        {
            this._userManagaer = userManager;   
        }

        public async Task<Unit> Handle(RevokeAllCommandRequest request, CancellationToken cancellationToken)
        {
           List<User> users=await _userManagaer.Users.ToListAsync(cancellationToken);

            foreach (User user in users)
            {
                user.RefreshToken = null;
                await _userManagaer.UpdateAsync(user);
            }
            return Unit.Value;
        }
    }
}
