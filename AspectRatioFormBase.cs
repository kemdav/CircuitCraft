using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class LockedAspectRatioForm : Form
{
    private float _aspectRatio;
    private bool _aspectRatioLocked = true;
    private bool _isUserResizing = false;

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
            EnforceAspectRatio();
        }
    }

    public bool AspectRatioLocked
    {
        get => _aspectRatioLocked;
        set => _aspectRatioLocked = value;
    }

    public LockedAspectRatioForm()
    {
        _aspectRatio = (float)ClientSize.Width / ClientSize.Height;
        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        ResizeBegin += (s, e) => _isUserResizing = true;
        ResizeEnd += (s, e) => _isUserResizing = false;
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
                newHeight = (int)(newWidth / _aspectRatio);
                rc.Bottom = rc.Top + newHeight;
                break;
            case 3: // Top
            case 6: // Bottom
                newWidth = (int)(newHeight * _aspectRatio);
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
            newHeight = (int)(newWidth / _aspectRatio);
            rc.Top = rc.Bottom - newHeight;
        }
        else
        {
            newWidth = (int)(newHeight * _aspectRatio);
            rc.Left = rc.Right - newWidth;
        }
    }

    private void AdjustTopRight(ref RECT rc, int newWidth, int newHeight)
    {
        if (newWidth / (float)newHeight > _aspectRatio)
        {
            newHeight = (int)(newWidth / _aspectRatio);
            rc.Top = rc.Bottom - newHeight;
        }
        else
        {
            newWidth = (int)(newHeight * _aspectRatio);
            rc.Right = rc.Left + newWidth;
        }
    }

    private void AdjustBottomLeft(ref RECT rc, int newWidth, int newHeight)
    {
        if (newWidth / (float)newHeight > _aspectRatio)
        {
            newHeight = (int)(newWidth / _aspectRatio);
            rc.Bottom = rc.Top + newHeight;
        }
        else
        {
            newWidth = (int)(newHeight * _aspectRatio);
            rc.Left = rc.Right - newWidth;
        }
    }

    private void AdjustBottomRight(ref RECT rc, int newWidth, int newHeight)
    {
        if (newWidth / (float)newHeight > _aspectRatio)
        {
            newHeight = (int)(newWidth / _aspectRatio);
            rc.Bottom = rc.Top + newHeight;
        }
        else
        {
            newWidth = (int)(newHeight * _aspectRatio);
            rc.Right = rc.Left + newWidth;
        }
    }

    private void EnforceAspectRatio()
    {
        if (WindowState == FormWindowState.Maximized || !_aspectRatioLocked || _isUserResizing)
            return;

        Size newSize = ClientSize;
        float currentAspect = (float)newSize.Width / newSize.Height;

        if (currentAspect == _aspectRatio)
            return;

        if (currentAspect > _aspectRatio)
        {
            newSize.Height = (int)(newSize.Width / _aspectRatio);
        }
        else
        {
            newSize.Width = (int)(newSize.Height * _aspectRatio);
        }

        ClientSize = newSize;
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        if (!_isUserResizing)
            EnforceAspectRatio();
    }
}