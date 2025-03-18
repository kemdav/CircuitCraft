using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class LockedAspectRatioForm : Form
{
    private float _aspectRatio;
    private bool _aspectRatioLocked = true;
    private bool _initialLayoutComplete = false;

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }

    public float AspectRatio
    {
        get => _aspectRatio;
        set
        {
            if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value), "Aspect ratio must be positive.");
            _aspectRatio = value;
            if (_initialLayoutComplete) // Only enforce after initial layout
            {
                EnforceAspectRatio();
            }
        }
    }

    public bool AspectRatioLocked
    {
        get => _aspectRatioLocked;
        set => _aspectRatioLocked = value;
    }

    public LockedAspectRatioForm()
    {
        // Don't calculate aspect ratio here.  Do it after the initial layout.
        // InitializeClientSize ONLY; do NOT set Size here.
        this.ClientSize = new Size(1280, 720);

        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        // Removed ResizeBegin/ResizeEnd - not needed with the _initialLayoutComplete flag.
    }
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        _aspectRatio = (float)ClientSize.Width / ClientSize.Height; // Calculate here
        _initialLayoutComplete = true; // Set the flag after initial layout.
        EnforceAspectRatio();
    }

    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams cp = base.CreateParams;
            cp.ExStyle |= 0x02000000;  // WS_EX_COMPOSITED
            return cp;
        }
    }

    protected override void WndProc(ref Message m)
    {
        const int WM_SIZING = 0x214;

        if (_aspectRatioLocked && m.Msg == WM_SIZING)
        {
            RECT rc = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));
            int edge = m.WParam.ToInt32();

            AdjustSize(ref rc, edge);
            Marshal.StructureToPtr(rc, m.LParam, true);
            m.Result = IntPtr.Zero; // Indicate that we handled the message
            return; // Prevent base.WndProc from interfering
        }

        base.WndProc(ref m);
    }

    private void AdjustSize(ref RECT rc, int edge)
    {
        int newWidth = rc.Right - rc.Left;
        int newHeight = rc.Bottom - rc.Top;

        switch (edge)
        {
            case 1: // Left
            case 2: // Right
                newHeight = (int)Math.Round(newWidth / _aspectRatio); // Use Math.Round
                rc.Bottom = rc.Top + newHeight;
                break;
            case 3: // Top
            case 6: // Bottom
                newWidth = (int)Math.Round(newHeight * _aspectRatio); // Use Math.Round
                rc.Right = rc.Left + newWidth;
                break;
            case 4: // Top-Left
                AdjustTopLeft(ref rc, newWidth, newHeight);
                break;
            case 5: // Top-Right
                AdjustTopRight(ref rc, newWidth, newHeight);
                break;
            case 7: // Bottom-Left
                AdjustBottomLeft(ref rc, newWidth, newHeight);
                break;
            case 8: // Bottom-Right
                AdjustBottomRight(ref rc, newWidth, newHeight);
                break;
        }
    }

    private void AdjustTopLeft(ref RECT rc, int newWidth, int newHeight)
    {
        if (newWidth / (float)newHeight > _aspectRatio)
        {
            newHeight = (int)Math.Round(newWidth / _aspectRatio);
            rc.Top = rc.Bottom - newHeight;
        }
        else
        {
            newWidth = (int)Math.Round(newHeight * _aspectRatio);
            rc.Left = rc.Right - newWidth;
        }
    }

    private void AdjustTopRight(ref RECT rc, int newWidth, int newHeight)
    {
        if (newWidth / (float)newHeight > _aspectRatio)
        {
            newHeight = (int)Math.Round(newWidth / _aspectRatio);
            rc.Top = rc.Bottom - newHeight;
        }
        else
        {
            newWidth = (int)Math.Round(newHeight * _aspectRatio);
            rc.Right = rc.Left + newWidth;
        }
    }

    private void AdjustBottomLeft(ref RECT rc, int newWidth, int newHeight)
    {
        if (newWidth / (float)newHeight > _aspectRatio)
        {
            newHeight = (int)Math.Round(newWidth / _aspectRatio);
            rc.Bottom = rc.Top + newHeight;
        }
        else
        {
            newWidth = (int)Math.Round(newHeight * _aspectRatio);
            rc.Left = rc.Right - newWidth;
        }
    }

    private void AdjustBottomRight(ref RECT rc, int newWidth, int newHeight)
    {
        if (newWidth / (float)newHeight > _aspectRatio)
        {
            newHeight = (int)Math.Round(newWidth / _aspectRatio);
            rc.Bottom = rc.Top + newHeight;
        }
        else
        {
            newWidth = (int)Math.Round(newHeight * _aspectRatio);
            rc.Right = rc.Left + newWidth;
        }
    }

    private void EnforceAspectRatio()
    {
        if (WindowState == FormWindowState.Maximized || !_aspectRatioLocked)
            return;

        Size newSize = ClientSize;
        float currentAspect = (float)newSize.Width / newSize.Height;

        if (Math.Abs(currentAspect - _aspectRatio) < 1e-6) // Use a tolerance for float comparison
            return;

        if (currentAspect > _aspectRatio)
        {
            newSize.Height = (int)Math.Round(newSize.Width / _aspectRatio); // Round
        }
        else
        {
            newSize.Width = (int)Math.Round(newSize.Height * _aspectRatio); // Round
        }
        //Critical to have this check.
        if (!_initialLayoutComplete)
            return;


        ClientSize = newSize;
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        if (_initialLayoutComplete) // Only enforce after initial layout
            EnforceAspectRatio();
    }
}