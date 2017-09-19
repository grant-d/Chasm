﻿using Google.Protobuf;
using SourceCode.Clay.Buffers;
using SourceCode.Mamba.CasRepo.IO.Proto.Wire;
using System;

namespace SourceCode.Mamba.CasRepo.IO.Proto
{
    partial class ProtoCasSerializer // .Tree
    {
        #region Serialize

        public override BufferSession Serialize(TreeNodeList model)
        {
            var wire = model.Convert();

            var size = wire.CalculateSize();
            var buffer = BufferSession.RentBuffer(size);

            using (var cos = new CodedOutputStream(buffer))
            {
                wire.WriteTo(cos);

                var segment = new ArraySegment<byte>(buffer, 0, (int)cos.Position);

                var session = new BufferSession(buffer, segment);
                return session;
            }
        }

        #endregion

        #region Deserialize

        public override TreeNodeList DeserializeTree(ReadOnlyBuffer<byte> buffer)
        {
            var wire = new TreeWire();
            wire.MergeFrom(buffer.ToArray()); // TODO: Perf

            var model = wire.Convert();
            return model;
        }

        public override TreeNodeList DeserializeTree(ArraySegment<byte> segment)
        {
            var wire = new TreeWire();
            wire.MergeFrom(segment.ToArray()); // TODO: Perf

            var model = wire.Convert();
            return model;
        }

        #endregion
    }
}
