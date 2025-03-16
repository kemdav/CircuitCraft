using Microsoft.VisualBasic.Devices;

namespace CircuitCraft
{
    public partial class TutorialForm : Form
    {
        public TutorialForm()
        {
            InitializeComponent();

            circuitCanvas1.AddElement(new Battery { Location = new Point(50, 50) });
        }

        private void addResistorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Point screenPosition = Cursor.Position;
            Point clientPosition = circuitCanvas1.PointToClient(screenPosition);
            circuitCanvas1.AddElement(new Resistor { Location = clientPosition });
        }

        private void addBatterySourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Point screenPosition = Cursor.Position;
            Point clientPosition = circuitCanvas1.PointToClient(screenPosition);
            circuitCanvas1.AddElement(new Battery { Location = clientPosition });
        }

        private void rotate90ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rotate90ToolStripMenuItem_Click(sender, e);
        }
    }
}
