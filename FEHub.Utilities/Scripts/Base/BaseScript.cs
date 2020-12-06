//-----------------------------------------------------------------------------
// <copyright file="BaseScript.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System.Threading.Tasks;

namespace FEHub.Utilities.Scripts.Base
{
    internal abstract class BaseScript
    {
        public abstract Task RunAsync();
    }
}
