using FrozensoftSoftware.Alerts.Interfaces;
using FrozensoftSoftware.Alerts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections.Generic;
using System.Text.Json;

namespace FrozensoftSoftware.Alerts.Services
{
    public class AlertService : IAlertService
    {
        private readonly ITempDataDictionary _tempData;

        public AlertService(IHttpContextAccessor contextAccessor, ITempDataDictionaryFactory tempDataDictionaryFactory)
        {
            _tempData = tempDataDictionaryFactory.GetTempData(contextAccessor.HttpContext);
        }

        public void AddAlert(string message, AlertStyles alertStyle = AlertStyles.Success, bool dismissible = true)
        {
            var alerts = _tempData.ContainsKey(Alert.TempDataKey)
                ? (List<Alert>)_tempData[Alert.TempDataKey]
                : new List<Alert>();

            alerts.Add(new Alert
            {
                AlertStyle = alertStyle.ToString().ToLower(),
                Message = message,
                Dismissable = dismissible
            });

            _tempData[Alert.TempDataKey] = JsonSerializer.Serialize(alerts);
        }
    }
}