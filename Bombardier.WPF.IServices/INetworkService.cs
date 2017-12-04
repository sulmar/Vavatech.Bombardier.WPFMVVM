using Bombardier.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombardier.WPF.IServices
{
    public interface INetworkService
    {
        Network Get(int id);
    }
}
