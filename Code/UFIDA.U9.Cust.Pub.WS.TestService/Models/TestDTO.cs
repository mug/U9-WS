using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace UFIDA.U9.Cust.Pub.WS.TestService.Models
{
    [DataContract]
    public class TestDTO
    {
        private readonly List<TestDTO> _lineDTOs = new List<TestDTO>();

        [DataMember]
        public List<TestDTO> LineDTOs
        {
            get { return _lineDTOs; }
        }

        /// <summary>
        ///     名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public decimal Money { get; set; }

        [DataMember]
        public DateTime Date { get; set; }
    }
}