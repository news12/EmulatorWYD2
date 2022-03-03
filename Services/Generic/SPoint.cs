using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Generic
{
    public class SPoint<T>
      where T : System.IComparable<T>

    {
        public T X { get; set; }
        public T Y { get; set; }

        public SPoint(T x, T y)
        {
            X = x; Y = y;
        }
    }

  
}
