using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    //Çıplak Class olmamalı (Yani bir class inheritance ya da interface,abstract implementasyonu almalı. Yoksa sorun olabilir.)
    public class Category:IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
