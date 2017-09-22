﻿using SourceCode.Clay.Buffers;
using System;

namespace SourceCode.Chasm.IO
{
    partial interface IChasmSerializer // .Commit
    {
        BufferSession Serialize(Commit model);

        Commit DeserializeCommit(ReadOnlyMemory<byte> buffer);

        Commit DeserializeCommit(ArraySegment<byte> segment);
    }
}
