using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCalendar
{
    public class KeyManager
    {
        private static KeyManager instance;
        public static KeyManager Instance
        {
            get { return instance ?? (instance = new KeyManager()); }
        }

        public bool Ctrl { get; private set; }
        public bool Alt { get; private set; }
        public bool Shift { get; private set; }

        public bool CtrlAlt { get { return Ctrl && Alt; } }
        public bool CtrlShift { get { return Ctrl && Shift; } }
        public bool AltShift { get { return Alt && Shift; } }
        public bool CtrlAltShift { get { return Ctrl && Alt && Shift; } }

        public void Reset()
        {
            Ctrl = Alt = Shift = false;
        }

        public void OnKeyDown(KeyEventArgs e)
        {
            Ctrl = e.Control;
            Alt = e.Alt;
            Shift = e.Shift;

#if DEBUG
            Debug.WriteLine(Ctrl + " " + Alt + " " + Shift);
#endif
        }

        public void OnKeyUp(KeyEventArgs e)
        {
            OnKeyDown(e);
        }
    }
}
