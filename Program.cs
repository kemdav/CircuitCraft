using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using ReaLTaiizor.Controls;
using SpiceSharp;
using SpiceSharp.Components;
using SpiceSharp.Simulations;

namespace CircuitCraft
{
    internal static class Program
    {
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
            Application.Run(new TutorialForm());
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
                // 1. Try loading from the executable's directory (for deployment).
                string exePath = Path.Combine(Application.StartupPath, "Images", "CircuitElements", imageName);
                if (File.Exists(exePath))
                {
                    return Image.FromFile(exePath);
                }

                // 2. If not found, try loading relative to the project directory (for development).
                string projectPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Resources\CircuitElements", imageName);
                if (File.Exists(projectPath))
                {
                    return Image.FromFile(projectPath);
                }

                // 3. If not found in either location, throw an exception.
                throw new FileNotFoundException($"Image file not found: {imageName}.  Checked:\n{exePath}\n{projectPath}");
            }
            catch (FileNotFoundException)
            {
                // Handle the case where the file doesn't exist.
                MessageBox.Show($"Image file not found: {imageName}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null; // Or throw the exception, depending on your error handling strategy.
            }
            catch (Exception ex)
            {
                // Handle other potential exceptions (e.g., invalid image format).
                MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null; // Or throw the exception.
            }
        }
    }
}