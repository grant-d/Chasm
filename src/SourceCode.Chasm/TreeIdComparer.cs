#region License

// Copyright (c) K2 Workflow (SourceCode Technology Holdings Inc.). All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

#endregion

using System.Collections.Generic;

namespace SourceCode.Chasm
{
    /// <summary>
    /// Represents a way to compare different <see cref="TreeId"/> values.
    /// </summary>
    public abstract class TreeIdComparer : IEqualityComparer<TreeId>, IComparer<TreeId>
    {
        #region Constants

        /// <summary>
        /// Gets a <see cref="TreeIdComparer"/> that compares all fields of a <see cref="TreeId"/> value.
        /// </summary>
        public static TreeIdComparer Default { get; } = new DefaultComparer();

        #endregion

        #region Constructors

        private TreeIdComparer()
        { }

        #endregion

        #region IComparer

        /// <inheritdoc/>
        public abstract int Compare(TreeId x, TreeId y);

        #endregion

        #region IEqualityComparer

        /// <inheritdoc/>
        public abstract bool Equals(TreeId x, TreeId y);

        /// <inheritdoc/>
        public abstract int GetHashCode(TreeId obj);

        #endregion

        #region Concrete

        private sealed class DefaultComparer : TreeIdComparer
        {
            #region Methods

            public override int Compare(TreeId x, TreeId y) => x.Sha1.CompareTo(y.Sha1);

            public override bool Equals(TreeId x, TreeId y) => x.Sha1.Equals(y.Sha1);

            public override int GetHashCode(TreeId obj) => obj.Sha1.GetHashCode();

            #endregion
        }

        #endregion
    }
}
