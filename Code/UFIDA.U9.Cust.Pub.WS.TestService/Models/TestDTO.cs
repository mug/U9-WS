using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.Serialization;

namespace UFIDA.U9.Cust.Pub.WS.TestService.Models
{
    [DataContract]
    public class TestDTO
    {
        private readonly Dictionary<string, string> _dictionaryValue = new Dictionary<string, string>();
        private readonly List<TestDTO> _listValue = new List<TestDTO>();

        /// <summary>
        ///     List
        /// </summary>
        [DataMember]
        public List<TestDTO> ListValue
        {
            get { return _listValue; }
        }

        /// <summary>
        ///     Dictionary
        /// </summary>
        [DataMember]
        public Dictionary<string, string> DictionaryValue
        {
            get { return _dictionaryValue; }
        }

        /// <summary>
        ///     Object
        /// </summary>
        [DataMember]
        public object ObjectValue { get; set; }

        /// <summary>
        ///     Char
        /// </summary>
        [DataMember]
        public char CharValue { get; set; }

        /// <summary>
        ///     CharNullable
        /// </summary>
        [DataMember]
        public char? CharNullableValue { get; set; }

        /// <summary>
        ///     Char
        /// </summary>
        [DataMember]
        public bool BooleanValue { get; set; }

        /// <summary>
        ///     CharNullable
        /// </summary>
        [DataMember]
        public bool? BooleanNullableValue { get; set; }

        /// <summary>
        ///     SByte
        /// </summary>
        [DataMember]
        public sbyte SByteValue { get; set; }

        /// <summary>
        ///     SByteNullable
        /// </summary>
        [DataMember]
        public sbyte? SByteNullableValue { get; set; }

        /// <summary>
        ///     short
        /// </summary>
        [DataMember]
        public short Short16Value { get; set; }

        /// <summary>
        ///     ShortNullable
        /// </summary>
        [DataMember]
        public short? ShortNullableValue { get; set; }

        /// <summary>
        ///     ushort
        /// </summary>
        [DataMember]
        public ushort UShortValue { get; set; }

        /// <summary>
        ///     ushortNullable
        /// </summary>
        [DataMember]
        public ushort? UShortNullableValue { get; set; }

        /// <summary>
        ///     Int32
        /// </summary>
        [DataMember]
        public int Int16Value { get; set; }

        /// <summary>
        ///     Int32Nullable
        /// </summary>
        [DataMember]
        public int? Int16NullableValue { get; set; }

        /// <summary>
        ///     Byte
        /// </summary>
        [DataMember]
        public byte ByteValue { get; set; }

        /// <summary>
        ///     ByteNullable
        /// </summary>
        [DataMember]
        public byte? ByteNullableValue { get; set; }

        /// <summary>
        ///     UInt32
        /// </summary>
        [DataMember]
        public uint UIntValue { get; set; }

        /// <summary>
        ///     UInt32Nullable
        /// </summary>
        [DataMember]
        public uint? UIntNullableValue { get; set; }

        /// <summary>
        ///     Int64
        /// </summary>
        [DataMember]
        public long LongValue { get; set; }

        /// <summary>
        ///     Int64Nullable
        /// </summary>
        [DataMember]
        public long? LongNullableValue { get; set; }

        /// <summary>
        ///     UInt64
        /// </summary>
        [DataMember]
        public ulong ULongValue { get; set; }

        /// <summary>
        ///     UInt64Nullable
        /// </summary>
        [DataMember]
        public ulong? ULongNullableValue { get; set; }

        /// <summary>
        ///     Single
        /// </summary>
        [DataMember]
        public float FloatValue { get; set; }

        /// <summary>
        ///     SingleNullable
        /// </summary>
        [DataMember]
        public float? FloatNullableValue { get; set; }

        /// <summary>
        ///     Double
        /// </summary>
        [DataMember]
        public double DoubleValue { get; set; }

        /// <summary>
        ///     DoubleNullable
        /// </summary>
        [DataMember]
        public double? DoubleNullableValue { get; set; }

        /// <summary>
        ///     Double
        /// </summary>
        [DataMember]
        public DateTime DateTimeValue { get; set; }

        /// <summary>
        ///     DoubleNullable
        /// </summary>
        [DataMember]
        public DateTime? DateTimeNullableValue { get; set; }

        /// <summary>
        ///     DateTimeOffset
        /// </summary>
        [DataMember]
        public DateTimeOffset DateTimeOffsetValue { get; set; }

        /// <summary>
        ///     DateTimeOffsetNullable
        /// </summary>
        [DataMember]
        public DateTimeOffset? DateTimeOffsetNullableValue { get; set; }

        /// <summary>
        ///     Decimal
        /// </summary>
        [DataMember]
        public decimal DecimalValue { get; set; }

        /// <summary>
        ///     DecimalNullable
        /// </summary>
        [DataMember]
        public decimal? DecimalNullableValue { get; set; }

        /// <summary>
        ///     Guid
        /// </summary>
        [DataMember]
        public Guid GuidValue { get; set; }

        /// <summary>
        ///     GuidNullable
        /// </summary>
        [DataMember]
        public Guid? GuidNullableValue { get; set; }

        /// <summary>
        ///     TimeSpan
        /// </summary>
        [DataMember]
        public TimeSpan TimeSpanValue { get; set; }

        /// <summary>
        ///     GuidNullable
        /// </summary>
        [DataMember]
        public TimeSpan? TimeSpanNullableValue { get; set; }

        /// <summary>
        ///     BigInteger
        /// </summary>
        [DataMember]
        public BigInteger BigIntegerValue { get; set; }

        /// <summary>
        ///     BigIntegerNullable
        /// </summary>
        [DataMember]
        public BigInteger? BigIntegerNullableValue { get; set; }

        /// <summary>
        ///     Uri
        /// </summary>
        [DataMember]
        public Uri UriValue { get; set; }

        /// <summary>
        ///     String
        /// </summary>
        [DataMember]
        public string StringValue { get; set; }

        /// <summary>
        ///     Bytes
        /// </summary>
        [DataMember]
        public byte[] BytesValue { get; set; }

        /// <summary>
        ///     DBNull
        /// </summary>
        [DataMember]
        public DBNull DBNullValue { get; set; }
    }
}