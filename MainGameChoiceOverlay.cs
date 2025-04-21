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
    public partial class MainGameChoiceOverlay : Form
    {
        private Color overlayColor = Color.FromArgb(180, 0, 0, 0);

        private const int WS_EX_NOACTIVATE = 0x08000000; // Extended window style: No Activate
        private const int WM_MOUSEACTIVATE = 0x0021;     // Windows message: Mouse Activate
        private const int MA_NOACTIVATE = 3;             // Return value for WM_MOUSEACTIVATE: Do not activate
        private const int MA_NOACTIVATEANDEAT = 4;       // Return value for WM_MOUSEACTIVATE: Do not activate and discard msg


        public Panel ChoicePanel1
        {
            get { return choicePanel1; }
        }

        public Panel ChoicePanel2
        {
            get { return choicePanel2; }
        }

        public Panel ChoicePanel3
        {
            get { return choicePanel3; }
        }

        public Panel GameOverPanel
        {
            get { return gameoverFormPos; }
        }

        public MainGameChoiceOverlay()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_EX_NOACTIVATE; // Add the No Activate style
                return cp;
            }
        }

        protected override void WndProc(ref Message m)
        {
            // Check if the message is WM_MOUSEACTIVATE
            if (m.Msg == WM_MOUSEACTIVATE)
            {
                // Tell Windows DO NOT ACTIVATE this window and DISCARD the click message
                m.Result = (IntPtr)MA_NOACTIVATEANDEAT;
                return; // Stop processing the message here
            }

            // Handle all other messages normally (including painting, messages for child controls, etc.)
            base.WndProc(ref m);
        }


    }
}
