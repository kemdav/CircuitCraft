using MaterialSkin.Controls;
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
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
        }

        private void toolButton_Click(object sender, EventArgs e)
        {
            MaterialButton materialButton = (MaterialButton)sender;
            if (circuitGrid.currentTool == GridControl.ToolType.None)
            {
                foreach (var control in Controls)
                {
                    if (control is MaterialButton)
                    {
                        ((MaterialButton)control).UseAccentColor = false;
                    }
                }
                if (materialButton.Text == "WIRE")
                {
                    circuitGrid.currentTool = GridControl.ToolType.Wire;
                }
                else if (materialButton.Text == "RESISTOR")
                {
                    circuitGrid.currentTool = GridControl.ToolType.Resistor;
                }
                else if (materialButton.Text == "DELETE")
                {
                    circuitGrid.currentTool = GridControl.ToolType.Delete;
                }
                else if (materialButton.Text == "LED")
                {
                    circuitGrid.currentTool = GridControl.ToolType.LED;
                }
                else if (materialButton.Text == "BATTERY")
                {
                    circuitGrid.currentTool = GridControl.ToolType.Battery;
                }
                materialButton.UseAccentColor = true;
            }
            else
            {
                materialButton.UseAccentColor = false;
                circuitGrid.currentTool = GridControl.ToolType.None;
            }
        }
    }
}
