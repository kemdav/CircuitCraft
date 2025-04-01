using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircuitCraft
{
    public partial class CircuitBlock : UserControl
    {
        public List<CircuitElement> CircuitElements { get; set; } = new List<CircuitElement>();
        public int CurrentElementIndex { get; set; } = 0;
        public int MaxiumElements { get; set; } = 0;

        public CircuitBlock()
        {
            InitializeComponent();
        }
    }
}
