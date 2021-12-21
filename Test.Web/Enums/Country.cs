using System.ComponentModel;

namespace Test.Web.Enums
{
    public enum Country
    {
        [Description("en")]
        English,

        [Description("de")]
        Germany,

        [Description("Español")]
        Spain,

        [Description("Română")]
        Romania,

        [Description("Pусский")]
        Russia
    }
}