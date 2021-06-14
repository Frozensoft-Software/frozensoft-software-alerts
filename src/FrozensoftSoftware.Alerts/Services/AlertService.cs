using System.Collections.Generic;
using FrozensoftSoftware.Alerts.Interfaces;
using FrozensoftSoftware.Alerts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace FrozensoftSoftware.Alerts.Services
{
    public class AlertService : IAlertService
    {
        private readonly ITempDataDictionary _tempData;

        public AlertService(IHttpContextAccessor contextAccessor, ITempDataDictionaryFactory tempDataDictionaryFactory)
        {
            _tempData = tempDataDictionaryFactory.GetTempData(contextAccessor.HttpContext);
        }

        /// <exception cref="T:System.ArgumentNullException"><paramref name="key" /> is <see langword="null" />.</exception>
        /// <exception cref="T:System.Collections.Generic.KeyNotFoundException">The property is retrieved and <paramref name="key" /> is not found.</exception>
        /// <exception cref="T:System.NotSupportedException">The property is set and the <see cref="T:System.Collections.Generic.IDictionary`2" /> is read-only.</exception>
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

            _tempData[Alert.TempDataKey] = alerts;
        }
    }
}