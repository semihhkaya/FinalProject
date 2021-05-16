using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {//Base= resulta göndermek demek
        //hem olumlu-olumsuz hem de bir mesaj gönderir.
        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }

        public DataResult(T data, bool success):base(success) //sadece Olumlu veya olumsuz döndürür
        {
            Data = data;
        }
        public T Data { get; }
    }
}
