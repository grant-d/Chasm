﻿using SourceCode.Clay.Buffers;
using System;
using System.Text;

namespace SourceCode.Chasm.IO.Json
{
    partial class JsonChasmSerializer // .Sha1
    {
        #region Serialize

        public override BufferSession Serialize(Sha1 model)
        {
            var wire = model.ToString("N");
            var utf8 = Encoding.UTF8.GetBytes(wire);

            var session = new BufferSession(new ArraySegment<byte>(utf8));
            return session;
        }

        #endregion

        #region Deserialize

        public override Sha1 DeserializeSha1(ReadOnlySpan<byte> span)
        {
            if (span.IsEmpty) throw new ArgumentNullException(nameof(span));

            string json;
            unsafe
            {
                fixed (byte* ptr = &span.DangerousGetPinnableReference())
                {
                    json = Encoding.UTF8.GetString(ptr, span.Length);
                }
            }

            var model = Sha1.Parse(json);
            return model;
        }

        #endregion
    }
}
