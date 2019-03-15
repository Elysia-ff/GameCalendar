using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCalendar.Data
{
    public class UIData
    {
        public Panel panel;
        public GroupBox groupBox;
        public List<Label> labels = new List<Label>();
        public Button button;
        public EventHandler clickEvent;
    }
}
