using ReaLTaiizor.Controls;
using SpiceSharp;
using SpiceSharp.Components;
using SpiceSharp.Simulations;

namespace CircuitCraft
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginScreenForm());
        }

        static void RunCircuit()
        {

        }

        public static void ApplyTransparentUI(ref PictureBox pbox, ref Label label)
        {
            System.Drawing.Point labelPos = label.Location;
            pbox.Controls.Add(label);
            label.Location = labelPos;
            label.BackColor = Color.Transparent;
        }
        public static void ApplyTransparentUI(ref PictureBox pbox, ref TextBox tbx)
        {
            System.Drawing.Point labelPos = tbx.Location;
            pbox.Controls.Add(tbx);
            tbx.Location = labelPos;
        }
        public static void ApplyTransparentUI(ref PictureBox pbox, ref ParrotSlider sldr)
        {
            System.Drawing.Point labelPos = sldr.Location;
            pbox.Controls.Add(sldr);
            sldr.Location = labelPos;
        }
    }
}