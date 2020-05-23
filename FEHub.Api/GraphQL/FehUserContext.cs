//-----------------------------------------------------------------------------
// <copyright file="FehUserContext.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System.Collections.Generic;
using System.Security.Claims;

namespace FEHub.Api.GraphQL
{
    internal sealed class FehUserContext : Dictionary<string, object>
    {
        #region Properties
        public ClaimsPrincipal User { get; set; }
        #endregion
    }
}
