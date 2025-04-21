using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircuitCraft
{
    public class VerticalProgressBar : ProgressBar
    {
        // Override the CreateParams property
        protected override CreateParams CreateParams
        {
            get
            {
                // Get the base CreateParams
                CreateParams cp = base.CreateParams;
                // Add the PBS_VERTICAL style (0x04) using a bitwise OR
                cp.Style |= 0x04;
                // Return the modified CreateParams
                return cp;
            }
        }
    }
}
