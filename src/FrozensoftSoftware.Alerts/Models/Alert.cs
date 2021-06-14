namespace FrozensoftSoftware.Alerts.Models
{
    public class Alert
    {
        public const string TempDataKey = "Alerts";

        public string AlertStyle { get; set; }

        public string Message { get; set; }

        public bool Dismissable { get; set; }
    }

    public enum AlertStyles
    {
        Primary,
        Secondary,
        Success,
        Danger,
        Warning,
        Info,
        Light,
        Dark
    }
}