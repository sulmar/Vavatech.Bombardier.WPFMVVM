using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Bombardier.WPF.Common
{
    public static class DispatchService
    {
        public static void Invoke(Action action)
        {
            if (System.Windows.Application.Current != null)
            {
                Dispatcher dispatcher = System.Windows.Application.Current.Dispatcher;

                if (dispatcher == null || dispatcher.CheckAccess())
                {
                    action();
                }
                else
                {
                    dispatcher.BeginInvoke(action);
                }
            }
        }
    }
}
