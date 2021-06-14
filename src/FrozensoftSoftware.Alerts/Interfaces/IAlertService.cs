using FrozensoftSoftware.Alerts.Models;

namespace FrozensoftSoftware.Alerts.Interfaces
{
    public interface IAlertService
    {
        void AddAlert(string message, AlertStyles alertStyle = AlertStyles.Success, bool dismissible = true);
    }
}
