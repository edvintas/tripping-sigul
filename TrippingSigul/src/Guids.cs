// Guids.cs
// MUST match guids.h
using System;

namespace Noname.TrippingSigul
{
    static class GuidList
    {
        public const string guidTrippingSigulPkgString = "e8aef886-0d03-4e49-a6ad-a1f2340f73d9";
        public const string guidTrippingSigulCmdSetString = "a7f4396b-229e-4302-b03f-ca4423519b26";

        public static readonly Guid guidTrippingSigulCmdSet = new Guid(guidTrippingSigulCmdSetString);
    };
}