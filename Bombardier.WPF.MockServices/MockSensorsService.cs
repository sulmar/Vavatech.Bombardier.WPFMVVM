using Bombardier.WPF.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bombardier.WPF.Models;
using System.Threading;

namespace Bombardier.WPF.MockServices
{
    public class MockSensorsService : ISensorsService
    {
        public event EventHandler<Measure> SensorChanged;

        private Timer timer;
        private readonly Random random;

        public MockSensorsService()
        {
            random = new Random();
            timer = new Timer(CallbackMethod, null, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1));
        }

        private void OnSensorChanged(Measure measure)
        {
            if (SensorChanged!=null)
            {
                SensorChanged.Invoke(this, measure);
            }
        }

        private void CallbackMethod(object objectState)
        {
            var measure = new Measure();
            measure.DeviceId = "dev-1";
            measure.Value = random.NextDouble();
            measure.OverLimit = 0.5;

            OnSensorChanged(measure);
            

        }
    }
}
