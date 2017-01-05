using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinForm
{
    class MarqueeLabel : Label
    {
        private int CurrentPosition { get; set; }
        private Timer Timer { get; set; }
        public bool RTL { get; set; }
       


        public MarqueeLabel()
        {
            UseCompatibleTextRendering = true;
            Timer = new Timer();
            Timer.Interval = 25;
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Start();
            CurrentPosition = Width;
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            if (CurrentPosition > Width)
                CurrentPosition = -Width;
            else
                CurrentPosition += 2;

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.TranslateTransform((float)CurrentPosition, 0);
            base.OnPaint(e);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Timer != null)
                    Timer.Dispose();
            }
            Timer = null;
        }
    }
}
