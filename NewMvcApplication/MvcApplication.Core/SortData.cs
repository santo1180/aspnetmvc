using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;


namespace MvcApplication.Core
{
    [Serializable()]
    public class SortData : ExtData<SortData>
    {
        public string property { get; set; }
        public string direction { get; set; }

        public override bool Equals(object obj)
        {
            //comparing an instance to a null should return false
            if (obj == null) return false;

            //if object can't be cast to this type - return false;
            SortData fd = obj as SortData;
            if (fd == null) return false;

            return AreEqual(this.property, fd.property) &&
                   AreEqual(this.direction, fd.direction);
        }

        public override int GetHashCode()
        {
            return property.GetHashCode() ^ direction.GetHashCode() ;
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
    }
}
