using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult //IResult implemantastonu ile succes ve message'ı alıyoruz.
        //Hme success hem message hem de veri dönüdren işlemler için bu result kullanılır. IResult void işlemler içindir.(ör.Add)
    {
        T Data { get; }
    }
}
