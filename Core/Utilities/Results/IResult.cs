using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Temel voidler için başlangıç
    public interface IResult
    {
        bool Success { get; } //True-False
        string Message { get; } //True-False olma durumuna göre kullanıcıyı bilgilendiren mesaj içerikleri
    }
}
