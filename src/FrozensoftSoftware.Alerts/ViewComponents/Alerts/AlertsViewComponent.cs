using System.Collections.Generic;
using FrozensoftSoftware.Alerts.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrozensoftSoftware.Alerts.ViewComponents.Alerts
{
    public class AlertsViewComponent : ViewComponent
    {
        public IViewComponentResult InvokeAsync()
        {
            var alerts = TempData.ContainsKey(Alert.TempDataKey)
                ? (List<Alert>)TempData[Alert.TempDataKey]
                : new List<Alert>();

            return View(alerts);
        }
    }
}