using System.Runtime.Serialization;

namespace UFIDA.U9.Cust.Pub.WS.Base.Interfaces
{
    public interface IReturnMessage
    {
        [DataMember]
        bool IsSuccess { set; }

        [DataMember]
        string ErrMsg { set; }
    }
}