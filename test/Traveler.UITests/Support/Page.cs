using System;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.iOS;
using Xamarin.UITest.Queries;

namespace Traveler.UITests.Support
{
    public abstract class Page
    {
        protected readonly IApp App;
        protected readonly bool OnAndroid;
        protected readonly bool OniOS;

        protected Page(IApp app)
        {
            App = app;
            OnAndroid = app.GetType() == typeof(AndroidApp);
            OniOS = app.GetType() == typeof(iOSApp);
        }

        protected void EnterText(string marked, string text)
            => EnterText(e => e.Marked(marked), text);

        protected void EnterText(Func<AppQuery, AppQuery> appQuery, string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                App.Tap(appQuery);
                App.ClearText(appQuery);
            }
            else
            {
                App.Tap(appQuery);
                App.EnterText(text);
            }
        }

        protected void SetPickerDate(string marked, DateTime desired)
        {
            App.Tap(marked);
            if (OnAndroid)
            {
                var yearNum = desired.Year;
                //Android starts from 0
                var monthNum = desired.Month - 1;
                var dateNum = desired.Day;
                App.WaitForElement(x => x.Class("DatePicker"), "Timed out waiting for date picker", TimeSpan.FromMinutes(1));
                App.Query(x => x.Class("DatePicker").Invoke("updateDate", yearNum, monthNum, dateNum));
                App.Tap("OK");
            }
            else
            {
                var current = App.Query(marked).First();

                var currentDate = DateTime.Parse(current.Text);

                var yearStr = "" + desired.Year;
                var monthStr = desired.ToString("MMMM");
                var dateStr = "" + desired.Day;

                if (desired.Month >= currentDate.Month)
                    App.ScrollDownTo(x => x.Text(monthStr), x => x.Class("UIPickerTableView").Index(0), ScrollStrategy.Auto, timeout: TimeSpan.FromMinutes(1));
                else
                    App.ScrollUpTo(x => x.Text(monthStr), x => x.Class("UIPickerTableView").Index(0), ScrollStrategy.Auto, timeout: TimeSpan.FromMinutes(1));
                App.Tap(x => x.Text(monthStr));

                if (desired.Day >= currentDate.Day)
                    App.ScrollDownTo(x => x.Text(dateStr), x => x.Class("UIPickerTableView").Index(3), ScrollStrategy.Auto, timeout: TimeSpan.FromMinutes(1));
                else
                    App.ScrollUpTo(x => x.Text(dateStr), x => x.Class("UIPickerTableView").Index(3), ScrollStrategy.Auto, timeout: TimeSpan.FromMinutes(1));
                App.Tap(x => x.Text(dateStr));

                if (desired.Year >= currentDate.Year)
                    App.ScrollDownTo(x => x.Text(yearStr), x => x.Class("UIPickerTableView").Index(6), ScrollStrategy.Auto, timeout: TimeSpan.FromMinutes(1));
                else
                    App.ScrollUpTo(x => x.Text(yearStr), x => x.Class("UIPickerTableView").Index(6), ScrollStrategy.Auto, timeout: TimeSpan.FromMinutes(1));
                App.Tap(x => x.Text(yearStr));

                App.Tap("Done");
            }
        }

        protected void SetPickerValue(Func<AppQuery, AppQuery> marked, string desired)
        {
            App.Tap(marked);

            if (OnAndroid)
            {
                App.Tap(x => x.Text(desired));
            }
            else
            {
                App.ScrollDownTo(x => x.Text(desired), x => x.Class("UIPickerTableView").Index(0), ScrollStrategy.Auto, timeout: TimeSpan.FromMinutes(1));
                App.Tap(x => x.Text(desired));

                App.Tap("Done");
            }
        }

        public bool IsVisible(string marked, int timeoutSeconds = 10)
            => IsVisible(e => e.Marked(marked), timeoutSeconds);

        public bool IsVisible(Func<AppQuery, AppQuery> query, int timeoutSeconds = 10)
        {
            try
            {
                return App.WaitForElement(query, timeout: TimeSpan.FromSeconds(timeoutSeconds)).Any();
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsNotVisible(string marked, int timeoutSeconds = 10)
            => IsNotVisible(e => e.Marked(marked), timeoutSeconds);

        public bool IsNotVisible(Func<AppQuery, AppQuery> query, int timeoutSeconds = 10)
        {
            try
            {
                App.WaitForNoElement(query, timeout: TimeSpan.FromSeconds(timeoutSeconds));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal bool HasAlertMessage(string message)
        {
            try
            {
                return App.WaitForElement(e => e.Text(message)).Any();
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal bool IsEnabled(string marked)
            => App.Query(e => e.Marked(marked)).FirstOrDefault().Enabled;

        internal bool IsEnabled(Func<AppQuery, AppQuery> query)
            => App.Query(query).FirstOrDefault().Enabled;
    }
}
