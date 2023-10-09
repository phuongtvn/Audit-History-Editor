using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Audit_History_Editor
{
    public class Common
    {
        public static List<string> ParseGUIDs(string guids)
        {
            List<string> invalidGUIDs = new List<string>();
            List<string> listGUID = new List<string>();
            if (string.IsNullOrEmpty(guids))
            {
                throw new Exception("GUID(s) is empty. Please check data again.");
            }

            var arr = guids.Split(',');
            foreach (string guid in arr)
            {
                Guid g;
                if (Guid.TryParse(guid, out g))
                {
                    listGUID.Add(guid);
                }
                else
                {
                    invalidGUIDs.Add(guid);
                }
            }

            return listGUID;
        }

        public static bool IsSameGUID(string guid1, string guid2)
        {
            Guid g1;
            if (!Guid.TryParse(guid1, out g1))
            {
                return false;
            }
            Guid g2;
            if (!Guid.TryParse(guid2, out g2))
            {
                return false;
            }

            return g1.Equals(g2);
        }
    }
}
