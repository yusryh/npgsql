﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Logging;

namespace Npgsql.Messages
{
    internal class ParameterDescriptionMessage : ServerMessage
    {
        internal List<uint> TypeOIDs { get; private set; }

        internal ParameterDescriptionMessage()
        {
            TypeOIDs = new List<uint>();
        }

        internal ParameterDescriptionMessage Load(NpgsqlBuffer buf)
        {
            var numParams = buf.ReadInt16();
            TypeOIDs.Clear();
            for (var i = 0; i < numParams; i++) {
                TypeOIDs.Add(buf.ReadUInt32());
            }
            return this;
        }

        internal override BackEndMessageCode Code { get { return BackEndMessageCode.ParameterDescription; } }
    }
}
