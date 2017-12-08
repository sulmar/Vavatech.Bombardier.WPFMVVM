using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Bombardier.WPF.WPFClient.Converters
{
    class IntToWordsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int? id = value as int?;

            if (id.HasValue)
            {
                // TODO: konwersja
                switch(id.Value)
                {
                    case 1: return "jeden";
                    case 2: return "dwa";
                    case 3: return "trzy";
                    case 4: return "cztery";
                    case 5: return "pięć";
                    case 6: return "sześć";
                    case 7: return "siedem";
                    case 8: return "osiem";
                    case 9: return "dziewięć";
                    default: throw new ArgumentOutOfRangeException();
                }
                
            }
            else
            {
                throw new InvalidCastException();
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string slownie = value as string;

            if (slownie!=null)
            {
                // TODO: konwersja
                switch (slownie)
                {
                    case "jeden": return 1;
                    case "dwa": return 2;
                    case "trzy": return 3;

                    default: throw new ArgumentOutOfRangeException();
                }

            }
            else
            {
                throw new InvalidCastException();
            }
        }
    }


    class IntToWordsMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
