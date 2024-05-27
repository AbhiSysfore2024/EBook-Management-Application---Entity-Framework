﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IAuthenticateAndAuthorize
    {
        string Signup(DTOLoginRequest loginRequest);
        string RoleAssigned(DTOLoginRequest loginRequest);
        string GenerateJwtToken(DTOLoginRequest loginDTO, string role);

    }
}