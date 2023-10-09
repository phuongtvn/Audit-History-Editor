using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audit_History_Editor
{
    public class Constants
    {
        public static class ButtonColor
        {
            public static Color Disabled = Color.Silver;
            public static Color RetrieveAudit_Fill = Color.RoyalBlue;
            public static Color Rollback_Fill = Color.OrangeRed;
            public static Color RollbackAll_Fill = Color.LightSkyBlue;

        }
        public static class MESSAGES 
        {
            public const string CAPTION_INFO = "INFORMATION";
            public const string CAPTION_CONFIRM = "CONFIRMATION";
            public const string CAPTION_ERROR = "ERROR";
            public const string Confirm_RollbackAll = "Are you sure want to rollback {0} records to latest version? (Please note that only records has update operation will be affected)";
            public const string NoConnectionError = "Please select a connection first";
            public const string InvalidGUID = "Invalid GUID value. Please check your input again.";
            public const string NoAuditLog = "There is no audit log for the specific record. Please check your input again";
            public const string CannotRollback_Create = "Cannot rollback to this version due to Create operation";

        }
    }
    public class FieldTypes
    {
        public const string String = "String";
        public const string OptionSetValue = "OptionSetValue";
        public const string MultiOptionSetValue = "OptionSetValueCollection";
        public const string EntityReference = "EntityReference";
        public const string DateTime = "DateTime";
        public const string Int32 = "Int32";
        public const string Decimal = "Decimal";
        public const string FloatingPointNumber = "Double";
        public const string Money = "Money";
        public const string Boolean = "Boolean";

    }

}
