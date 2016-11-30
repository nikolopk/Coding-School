using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.Public
{
    public interface IPayWithVivaWallet
    {
        Task<bool> SendPaymentAsync(object sender, EventArgs e);
    }
}
