using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombardier.WPF.Models
{
    public class Measure : Base
    {
        public string DeviceId { get; set; }

        public double Value { get; set; }

        public double OverLimit { get; set; }

        public bool IsOverLimit => Value > OverLimit;
    }

}
