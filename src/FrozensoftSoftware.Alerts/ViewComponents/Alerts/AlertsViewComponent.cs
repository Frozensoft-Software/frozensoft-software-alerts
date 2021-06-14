using FrozensoftSoftware.Alerts.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace FrozensoftSoftware.Alerts.ViewComponents.Alerts
{
    public class AlertsViewComponent : ViewComponent
    {
        /// <exception cref="T:System.Text.Json.JsonException">The JSON is invalid.
        /// -or-
        /// <typeparamref name="TValue" /> is not compatible with the JSON.
        /// -or-
        /// There is remaining data in the string beyond a single JSON value.</exception>
        /// <exception cref="T:System.NotSupportedException">There is no compatible <see cref="System.Text.Json.Serialization.JsonConverter" /> for <typeparamref name="TValue" /> or its serializable members.</exception>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var alerts = new List<Alert>();
            if (!TempData.ContainsKey(Alert.TempDataKey)) return View(alerts);

            var alertsJson = TempData[Alert.TempDataKey].ToString() ?? "";

            alerts = JsonSerializer.Deserialize<List<Alert>>(alertsJson);

            alerts ??= new List<Alert>();

            return View(alerts);
        }
    }
}