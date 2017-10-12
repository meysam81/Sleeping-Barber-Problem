using static BarberShop.GlobalVariable;
using System.Threading;
using System;
namespace BarberShop
{
    class Cashier
    {
        ////////////////////////////////Cashier//////////////////////////////////////////////////
        public void CashierFunction()
        {
            int cCust;
            while (true)
            {
                payment.WaitOne();
                coord.WaitOne();
                AcceptPay();
                coord.Release();
                mutex3.WaitOne();
                cCust = queue2.Dequeue();
                mutex3.Release();
                receipt[cCust].Release();
            }
        }
        /////////////////////////////////AcceptPay///////////////////////////////////////////////
        private void AcceptPay()
        {
            Thread.Sleep(1200);
        }
    }
}
