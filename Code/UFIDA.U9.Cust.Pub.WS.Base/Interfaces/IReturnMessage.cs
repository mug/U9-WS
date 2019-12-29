namespace UFIDA.U9.Cust.Pub.WS.Base.Interfaces
{
    public interface IReturnMessage
    {
        bool IsSuccess { set; }
        string ErrMsg { set; }
    }
}