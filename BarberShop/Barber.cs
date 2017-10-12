using System.Threading;
using static BarberShop.GlobalVariable;

namespace BarberShop
{
    class Barber
    {
        ////////////////////////////////Barber//////////////////////////////////////////////////
        public void BarberFunction()
        {
            int bCust;
            while (true)
            {
                custReady.WaitOne();
                mutex2.WaitOne();
                bCust = queue1.Dequeue();
                mutex2.Release();
                coord.WaitOne();
                CutHair();
                coord.Release();
                finished[bCust].Release();
                leaveBChair[bCust].WaitOne();
                barberChair.Release();
            }
        }
        //////////////////////////////CutHair///////////////////////////////////////////////////
        private void CutHair()
        {
            Thread.Sleep(7000);
        }
    }
}
