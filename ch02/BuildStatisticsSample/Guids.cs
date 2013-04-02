// Guids.cs
// MUST match guids.h
using System;

namespace Company.BuildStatisticsSample
{
    static class GuidList
    {
        public const string guidBuildStatisticsSamplePkgString = "4f93100c-b6b6-4122-840e-7fe04cd380a4";
        public const string guidBuildStatisticsSampleCmdSetString = "2953c485-a8b5-47ad-a844-3cd600f9e776";

        public static readonly Guid guidBuildStatisticsSampleCmdSet = new Guid(guidBuildStatisticsSampleCmdSetString);
    };
}