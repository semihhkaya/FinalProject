using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value, int duration);
        bool IsAdd(string key); //Veriyi Cache'den mi getirelim yoksa veritabanından mı cache'de var mı kontrolü yapılır.
        void Remove(string key); //Güncelleme veya ekleme olursa cache'i kaldır.
        void RemoveByPattern(string pattern); 
    }
}
