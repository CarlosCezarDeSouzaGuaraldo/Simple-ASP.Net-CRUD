using System.ComponentModel;

namespace Simple_ASP.Net_CRUD.Enums
{
    public enum TaskStatus
    {
        [Description("To do")]
        ToDo = 1,
        [Description("Doing")]
        Doing = 2,
        [Description("Done")]
        Done = 3
    }
}
