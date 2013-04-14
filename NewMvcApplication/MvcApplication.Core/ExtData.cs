using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace MvcApplication.Core
{
    public class ExtData<T>
    {
        public static List<T> GetData(string str)
        {
            T[] strData;
            if (string.IsNullOrEmpty(str))
                return new List<T>();

            strData = new JavaScriptSerializer().Deserialize<T[]>(str);
            return strData.ToList();
        }
    }
}
