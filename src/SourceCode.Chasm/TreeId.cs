﻿using System;
using System.Collections.Generic;

namespace SourceCode.Chasm
{
    public struct TreeId : IEquatable<TreeId>
    {
        #region Constants

        public static TreeId Empty { get; }

        public static Comparer DefaultComparer { get; } = new Comparer();

        #endregion

        #region Properties

        public Sha1 Sha1 { get; }

        #endregion

        #region De/Constructors

        public TreeId(Sha1 sha1)
        {
            Sha1 = sha1;
        }

        public void Deconstruct(out Sha1 sha1)
        {
            sha1 = Sha1;
        }

        #endregion

        #region IEquatable

        public bool Equals(TreeId other) => DefaultComparer.Equals(this, other);

        public override bool Equals(object obj)
            => obj is TreeId blobId
            && DefaultComparer.Equals(this, blobId);

        public override int GetHashCode() => DefaultComparer.GetHashCode(this);

        #endregion

        #region Comparer

        public sealed class Comparer : IEqualityComparer<TreeId>, IComparer<TreeId>
        {
            internal Comparer()
            { }

            public int Compare(TreeId x, TreeId y) => Sha1.DefaultComparer.Compare(x.Sha1, y.Sha1);

            public bool Equals(TreeId x, TreeId y) => Sha1.DefaultComparer.Equals(x.Sha1, y.Sha1);

            public int GetHashCode(TreeId obj) => Sha1.DefaultComparer.GetHashCode(obj.Sha1);
        }

        #endregion

        #region Operators

        public static bool operator ==(TreeId x, TreeId y) => DefaultComparer.Equals(x, y);

        public static bool operator !=(TreeId x, TreeId y) => !DefaultComparer.Equals(x, y); // not

        public override string ToString() => $"{nameof(TreeId)}: {Sha1}";

        #endregion
    }
}
