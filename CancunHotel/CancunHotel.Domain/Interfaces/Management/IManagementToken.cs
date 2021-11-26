using CancunHotel.Domain.Enums;
using System;

namespace CancunHotel.Domain.Interfaces.Business
{
    public interface IManagementToken
    {
        string Create(Guid userId, UserAccessLevel userAccess);
        string ReadClaim(TokenClaims claimsName);
    }
}
