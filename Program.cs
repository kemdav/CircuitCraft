using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using ReaLTaiizor.Controls;
using SpiceSharp;
using SpiceSharp.Components;
using SpiceSharp.Simulations;
using static LockedAspectRatioForm;

namespace CircuitCraft
{
    internal static class Program
    {
        public static bool isFullScreen = false;
        public static System.Windows.Forms.FormBorderStyle originalBorderStyle;
        public static FormWindowState originalWindowState;
        public static Rectangle originalBounds;

        public static Media mainMenuMedia;
        private static string GetLibVLCPath()
        {
            var architectureFolder = IntPtr.Size == 8 ? "win-x64" : "win-x86";
            var currentDirectory = AppContext.BaseDirectory;
            return Path.Combine(currentDirectory, "libvlc", architectureFolder);
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var libvlcPath = GetLibVLCPath();
            Core.Initialize(libvlcPath);

            ApplicationConfiguration.Initialize();
            Application.Run(new LoginScreenForm());
        }

        public static Circuit BuildSpiceCircuit(List<Tuple<CircuitElement, PictureBox>> uiElements, List<Wire> uiWires)
        {
            var circuit = new Circuit();
            foreach (var tuple in uiElements)
            {
                CircuitElement element = tuple.Item1;
                switch (element.Type)
                {
                    case "Battery":
                        circuit.Add(new VoltageSource("V1", "n1", "0", element.Voltage));
                        break;
                    case "Resistor":
                        circuit.Add(new Resistor("R1", "n1", "0", element.Resistance));
                        break;
                    case "LED":
                        //circuit.Add(new Diode("D1", "n1", "0", 0.7));
                        break;
                }
            }

            return circuit;
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
        public static void ApplyTransparentUIVideo(ref VideoView media, ref MaterialSkin.Controls.MaterialButton bttn)
        {
            System.Drawing.Point labelPos = bttn.Location;
            media.Controls.Add(bttn);
            media.Location = labelPos;
        }
    }

    internal static class  ResourceHelper
    {
        public static Image LoadVideoFromResource(string imageName)
        {
            try
            {
                string exePath = Path.Combine(Application.StartupPath, "Images", "CircuitElements", imageName);
                if (File.Exists(exePath))
                {
                    return Image.FromFile(exePath);
                }
                string projectPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Resources\CircuitElements", imageName);
                if (File.Exists(projectPath))
                {
                    return Image.FromFile(projectPath);
                }
                throw new FileNotFoundException($"Image file not found: {imageName}.  Checked:\n{exePath}\n{projectPath}");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show($"Image file not found: {imageName}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}