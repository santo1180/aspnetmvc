using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace MvcApplication.Core
{
    [Serializable()]
    public class FilterData : ExtData<FilterData>
    {
        public string type { get; set; }
        public string field { get; set; }
        public object value { get; set; }
        public string comparison { get; set; }

        public override bool Equals(object obj)
        {
            //comparing an instance to a null should return false
            if (obj == null) return false;

            //if object can't be cast to this type - return false;
            FilterData fd = obj as FilterData;
            if (fd == null) return false;

            return AreEqual(this.type, fd.type) &&
                   AreEqual(this.field, fd.field) &&
                   AreEqual(this.comparison, fd.comparison) &&
                   AreEqual(this.value, fd.value);
        }

        public override int GetHashCode()
        {
            return type.GetHashCode() ^ field.GetHashCode() ^ comparison.GetHashCode() ^ value.GetHashCode();
        }

        private bool AreEqual(object val1, object val2)
        {
            if (val1 == null && val2 == null)
            {
                return true;
            }
            else if (val1 == null || val2 == null)
            {
                return false;
            }
            else
            {
                string oldStringValue = val1.ToString();
                string newStringValue = val2.ToString();
                return oldStringValue.Equals(newStringValue);
            }
        }


        public static string GetWhereCriteria(List<FilterData> filters)
        {
            StringBuilder strfilter = new StringBuilder("1 = 1");

            filters.ForEach(f =>
            {
                if (f.type == "string" || f.type == "datetime")
                {
                    strfilter.Append(" and " + f.field + " = " + "\"" + f.value + "\"");
                }
                else
                {
                    strfilter.Append(" and " + f.field + " = " + f.value);
                }
            });

            return strfilter.ToString();
        }
    }
}
