
//------------------------------------------------------------------------------
// This code was generated by a tool.
//
//   Tool : Bond Compiler 0.10.0.0
//   File : Sha1Wire_types.cs
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// <auto-generated />
//------------------------------------------------------------------------------


// suppress "Missing XML comment for publicly visible type or member"
#pragma warning disable 1591


#region ReSharper warnings
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
// ReSharper disable UnusedParameter.Local
// ReSharper disable RedundantUsingDirective
#endregion

namespace SourceCode.Chasm.IO.Bond.Wire
{
    using System.Collections.Generic;

    [global::Bond.Schema]
    [System.CodeDom.Compiler.GeneratedCode("gbc", "0.10.0.0")]
    public partial class Sha1Wire
    {
        [global::Bond.Id(1)]
        public ulong Blit0 { get; set; }

        [global::Bond.Id(2)]
        public ulong Blit1 { get; set; }

        [global::Bond.Id(3)]
        public uint Blit2 { get; set; }

        public Sha1Wire()
            : this("SourceCode.Chasm.IO.Bond.Wire.Sha1Wire", "Sha1Wire")
        {}

        protected Sha1Wire(string fullName, string name)
        {
            
        }
    }
} // SourceCode.Chasm.IO.Bond.Wire
