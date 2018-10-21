﻿using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;

namespace Tracer.Serialization
{
    public class JsonSerializer : ISerializer
    {
        private readonly DataContractJsonSerializer jsonSerializer;

        public void Serialize(TraceResult traceResult, Stream stream)
        {
            using(XmlDictionaryWriter jsonWriter = JsonReaderWriterFactory.CreateJsonWriter(stream, Encoding.UTF8, true, true))
            {
                jsonSerializer.WriteObject(jsonWriter, traceResult);
            }
        }

        internal JsonSerializer()
        {
            jsonSerializer = new DataContractJsonSerializer(typeof(TraceResult));
        }
    }
}
