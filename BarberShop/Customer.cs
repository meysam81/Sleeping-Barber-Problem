using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System;
using static BarberShop.GlobalVariable;
using static BarberShop.Objects;

namespace BarberShop
{
    class Customer
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        static Semaphore enterShop = new Semaphore(1, 1);
        static Semaphore sofaSemaphore = new Semaphore(1, 1);
        static Semaphore barberChairSemaphore = new Semaphore(1, 1);
        static Semaphore paySemaphore = new Semaphore(1, 1);
        static int cashierX = 745, enterShopY = 370, enterShopX = 770;
        int tempEnterShopX, tempEnterShopY, tempCashierX, cashierY = 120, barberChairNumber, sofaNumber;
        readonly int width = 20, height = 20;
        static int count = 0;
        int leftBeforeSitOnSofa, upBeforeExitShop;
        PointF tempPF, pfName, sofaCoordinate, barberChairCoordinate;
        Graphics g;
        Form f1;
        barberForm bf;
        Brush formColor, objectColor, objectName, respond;
        ////////////////////////////////////Functions///////////////////////////////////////////////
        public Customer(Form f)
        {
            bf = new barberForm();
            f1 = f;
            g = f1.CreateGraphics();
            objectName = new SolidBrush(Color.Black);
            formColor = new SolidBrush(f1.BackColor);
            objectColor = new SolidBrush(Color.BlueViolet);
            respond = new SolidBrush(Color.Coral);
        }
        /////////////////////////////////////Customer//////////////////////////////////////////
        public void CustomerFunction()
        {
            int custnr;
            maxCapacity.WaitOne();
            EnterShop();
            mutex1.WaitOne();
            custnr = count;
            count++;
            mutex1.Release();
            sofa.WaitOne();
            SitOnSofa();
            barberChair.WaitOne();
            GetUpFromSofa();
            sofa.Release();
            SitInBarberChair();
            mutex2.WaitOne();
            queue1.Enqueue(custnr);
            custReady.Release();
            mutex2.Release();
            finished[custnr].WaitOne();
            LeaveBarberChair();
            leaveBChair[custnr].Release();
            Pay();
            mutex3.WaitOne();
            queue2.Enqueue(custnr);
            mutex3.Release();
            payment.Release();
            receipt[custnr].WaitOne();
            ExitShop();
            maxCapacity.Release();
        }
        ////////////////////////////////EnterShop////////////////////////////////////////////////
        public void EnterShop()
        {
            enterShop.WaitOne();
            if (Convert.ToInt32(Thread.CurrentThread.Name) > 1)
                enterShopX -= 60;
            if (enterShopX <= 280)
            {
                enterShopX = 770;
                enterShopY += 30;
            }
            if (enterShopY > 430)
                enterShopY = 370;
            tempEnterShopX = enterShopX;
            tempEnterShopY = enterShopY;
            tempPF = myCoordinate[Convert.ToInt32(Thread.CurrentThread.Name)];
            enterShop.Release();
            g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
            tempPF.X = 200;
            g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
            pfName = tempPF;
            pfName.X += 2;
            pfName.Y += 2;
            g.DrawString(Thread.CurrentThread.Name, f1.Font, objectName, pfName);
            while (tempPF.Y < 370)
            {
                Thread.Sleep(3);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.Y += 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(Thread.CurrentThread.Name, f1.Font, objectName, pfName);
            }
            while (tempPF.X < tempEnterShopX)
            {
                Thread.Sleep(3);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.X += 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(Thread.CurrentThread.Name, f1.Font, objectName, pfName);
                if (tempPF.X > 260)
                    while (tempPF.Y < tempEnterShopY)
                    {
                        Thread.Sleep(3);
                        g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                        tempPF.Y += 1;
                        g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                        pfName = tempPF;
                        pfName.X += 2;
                        pfName.Y += 2;
                        g.DrawString(Thread.CurrentThread.Name, f1.Font, objectName, pfName);
                    }
            }
        }
        //////////////////////////////////SitOnSofa////////////////////////////////////////////////
        public void SitOnSofa()
        {
            sofaSemaphore.WaitOne();
            sofaNumber = sofaQueue.Dequeue();
            sofaSemaphore.Release();
            sofaCoordinate = (PointF)bf.GetSofaLocation(sofaNumber);
            leftBeforeSitOnSofa = (int)tempPF.X - 25;
            while (tempPF.X > leftBeforeSitOnSofa)
            {
                Thread.Sleep(3);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.X -= 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(Thread.CurrentThread.Name, f1.Font, objectName, pfName);
            }
            while (tempPF.Y > 336)
            {
                Thread.Sleep(3);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.Y -= 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(Thread.CurrentThread.Name, f1.Font, objectName, pfName);
            }
            while (tempPF.X > 520)
            {
                Thread.Sleep(3);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.X -= 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(Thread.CurrentThread.Name, f1.Font, objectName, pfName);
            }
            while (tempPF.X < 520)
            {
                Thread.Sleep(3);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.X += 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(Thread.CurrentThread.Name, f1.Font, objectName, pfName);
            }
            while (tempPF.Y > 280)
            {
                Thread.Sleep(3);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.Y -= 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(Thread.CurrentThread.Name, f1.Font, objectName, pfName);
            }
            while (tempPF.X > sofaCoordinate.X + 15)
            {
                Thread.Sleep(3);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.X -= 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(Thread.CurrentThread.Name, f1.Font, objectName, pfName);
            }
            while (tempPF.X < sofaCoordinate.X + 15)
            {
                Thread.Sleep(3);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.X += 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(Thread.CurrentThread.Name, f1.Font, objectName, pfName);
            }
            while (tempPF.Y > sofaCoordinate.Y - 20)
            {
                Thread.Sleep(3);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.Y -= 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(Thread.CurrentThread.Name, f1.Font, objectName, pfName);
            }
        }
        ////////////////////////////////GetUpFromSofa/////////////////////////////////////////////
        public void GetUpFromSofa()
        {
            sofaSemaphore.WaitOne();
            sofaQueue.Enqueue(sofaNumber);
            sofaSemaphore.Release();
            g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
            tempPF.Y -= 1;
            g.FillEllipse(respond, tempPF.X, tempPF.Y, width, height);
            pfName = tempPF;
            pfName.X += 2;
            pfName.Y += 2;
            g.DrawString(Thread.CurrentThread.Name, f1.Font, objectName, pfName);
            Thread.Sleep(800);
        }
        //////////////////////////////////SitInBarberChair//////////////////////////////////////////
        public void SitInBarberChair()
        {
            barberChairSemaphore.WaitOne();
            barberChairNumber = barberChairQueue.Dequeue();
            barberChairSemaphore.Release();
            barberChairCoordinate = bf.GetBarberChairLocation(barberChairNumber);
            while (tempPF.Y > 156)
            {
                Thread.Sleep(3);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.Y -= 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(Thread.CurrentThread.Name, f1.Font, objectName, pfName);
            }
            while (tempPF.X > barberChairCoordinate.X + 15)
            {
                Thread.Sleep(3);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.X -= 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(Thread.CurrentThread.Name, f1.Font, objectName, pfName);
            }
            while (tempPF.X < barberChairCoordinate.X + 15)
            {
                Thread.Sleep(3);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.X += 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(Thread.CurrentThread.Name, f1.Font, objectName, pfName);
            }
            while (tempPF.Y > barberChairCoordinate.Y - 20)
            {
                Thread.Sleep(3);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.Y -= 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(Thread.CurrentThread.Name, f1.Font, objectName, pfName);
            }
        }
        ///////////////////////////////////LeaveBarberChair/////////////////////////////////////////////
        public void LeaveBarberChair()
        {
            barberChairSemaphore.WaitOne();
            barberChairQueue.Enqueue(barberChairNumber);
            barberChairSemaphore.Release();
            g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
            tempPF.Y -= 1;
            g.FillEllipse(respond, tempPF.X, tempPF.Y, width, height);
            pfName = tempPF;
            pfName.X += 2;
            pfName.Y += 2;
            g.DrawString(Thread.CurrentThread.Name, f1.Font, objectName, pfName);
            Thread.Sleep(800);
        }
        //////////////////////////////////////Pay/////////////////////////////////////////////////
        public void Pay()
        {
            paySemaphore.WaitOne();
            if (Convert.ToInt32(Thread.CurrentThread.Name) > 1)
                cashierX -= 20;
            if (cashierX <= 660)
                cashierX = 745;
            tempCashierX = cashierX;
            paySemaphore.Release();
            while (tempPF.X < barberChairCoordinate.X + 50)
            {
                Thread.Sleep(8);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.X += 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(Thread.CurrentThread.Name, f1.Font, objectName, pfName);
            }
            while (tempPF.Y < barberChairCoordinate.Y + 60)
            {
                Thread.Sleep(8);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.Y += 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(Thread.CurrentThread.Name, f1.Font, objectName, pfName);
            }
            while (tempPF.X < tempCashierX)
            {
                Thread.Sleep(8);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.X += 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(Thread.CurrentThread.Name, f1.Font, objectName, pfName);
            }
            while (tempPF.Y < cashierY)
            {
                Thread.Sleep(8);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.Y += 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(Thread.CurrentThread.Name, f1.Font, objectName, pfName);
            }
        }
        ////////////////////////////////////ExitShop//////////////////////////////////////////////
        public void ExitShop()
        {
            g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
            tempPF.Y -= 1;
            g.FillEllipse(respond, tempPF.X, tempPF.Y, width, height);
            pfName = tempPF;
            pfName.X += 2;
            pfName.Y += 2;
            g.DrawString(Thread.CurrentThread.Name, f1.Font, objectName, pfName);
            Thread.Sleep(800);
            upBeforeExitShop = (int)tempPF.Y - 30;
            while (tempPF.Y > upBeforeExitShop)
            {
                Thread.Sleep(3);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.Y -= 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(Thread.CurrentThread.Name, f1.Font, objectName, pfName);
            }
            while (tempPF.X <= 820)
            {
                Thread.Sleep(3);
                g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
                tempPF.X += 1;
                g.FillEllipse(objectColor, tempPF.X, tempPF.Y, width, height);
                pfName = tempPF;
                pfName.X += 2;
                pfName.Y += 2;
                g.DrawString(Thread.CurrentThread.Name, f1.Font, objectName, pfName);
            }
            g.FillEllipse(formColor, tempPF.X, tempPF.Y, width, height);
        }
        ///////////////////////////////////////////////////////////////////////////////////////////
    }
}