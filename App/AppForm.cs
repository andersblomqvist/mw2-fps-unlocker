using mw2_fps_unlocker.Memory;
using mw2_fps_unlocker.App;
using System.ComponentModel;
using System.Diagnostics;

namespace mw2_fps_unlocker
{
    public partial class AppForm : Form
    {
        private const long OFFSET_COM_MAXFPS = 0x1D260A8;   // int
        private const long OFFSET_CG_FOV = 0x809C78;        // float
        private const int DVAR_VALUE_OFFSET = 0x10;

        private MemoryHandler? mem;
        private readonly ProcessHandler proc;

        private bool ingame = false;

        private readonly TrackBarWithoutFocus trackBarFPS;
        private readonly TrackBarWithoutFocus trackBarFOV;

        private BackgroundWorker updater;
        public AppForm()
        {
            InitializeComponent();

            trackBarFPS = new TrackBarWithoutFocus();
            trackBarFPS.Location = new Point(50, 37);
            trackBarFPS.Size = new Size(151, 45);
            trackBarFPS.Scroll += TrackBarFPS_Scroll;
            trackBarFPS.Minimum = 75;
            trackBarFPS.Maximum = 500;
            trackBarFPS.Value = 300;
            trackBarFPS.TickStyle = TickStyle.None;

            trackBarFOV = new TrackBarWithoutFocus();
            trackBarFOV.Location = new Point(50, 80);
            trackBarFOV.Size = new Size(151, 45);
            trackBarFOV.Scroll += TrackBarFOV_Scroll;
            trackBarFOV.Minimum = 60;
            trackBarFOV.Maximum = 100;
            trackBarFOV.Value = 80;
            trackBarFOV.TickStyle = TickStyle.None;

            this.Controls.Add(trackBarFPS);
            this.Controls.Add(trackBarFOV);

            proc = new ProcessHandler();

            updater = new BackgroundWorker();
            updater.DoWork += Updater_DoWork;

            FindProcess();
        }

        private void FindProcess()
        {
            proc.FindByName("iw4mp", (mw2) =>
            {
                Invoke(new Action(() =>
                {
                    mem = new MemoryHandler(mw2);
                    ingame = true;
                    updater.RunWorkerAsync();
                }));
            });
        }

        /// <summary>
        /// We need to constantly write the FPS and FOV change. Otherwise
        /// it resets back to normal by mw2.
        /// </summary>
        private void Updater_DoWork(object? sender, DoWorkEventArgs e)
        {
            Invoke(new Action(() =>
            {
                LabelStatusValue.Text = "MW2 Started";
                LabelStatusValue.ForeColor = Color.Green;
            }));

            while (proc.IsRunning())
            {
                SetFPS();
                SetFOV();
                Thread.Sleep(250);
            }

            ingame = false;
            mem = null;

            Invoke(new Action(() =>
            {
                LabelStatusValue.Text = "Not In-game";
                LabelStatusValue.ForeColor = Color.RoyalBlue;
            }));

            // Start the Find Process routine so we don't need to restart
            // the app.
            FindProcess();
        }

        /// <summary>
        /// Resolves a dvar_t* stored at moduleBase + offset. Returns Zero if
        /// the game hasn't registered the dvar yet.
        /// </summary>
        private IntPtr GetDvar(long globalOffset)
        {
            if (mem == null)
                return IntPtr.Zero;

            return mem.ReadPointer(mem.BaseAddress + (nint)globalOffset);
        }

        private void SetFPS()
        {
            if (mem == null)
                return;

            IntPtr dvar = GetDvar(OFFSET_COM_MAXFPS);
            if (dvar == IntPtr.Zero)
                return;

            mem.WriteInteger(dvar + DVAR_VALUE_OFFSET, trackBarFPS.Value);
        }

        private void SetFOV()
        {
            if (mem == null)
                return;

            IntPtr dvar = GetDvar(OFFSET_CG_FOV);
            if (dvar == IntPtr.Zero)
                return;

            mem.WriteFloat(dvar + DVAR_VALUE_OFFSET, trackBarFOV.Value);
        }

        private void TrackBarFPS_Scroll(object? sender, EventArgs e)
        {
            LabelFPSValue.Text = trackBarFPS.Value.ToString();
            if (ingame)
                SetFPS();
        }

        private void TrackBarFOV_Scroll(object? sender, EventArgs e)
        {
            LabelFOVValue.Text = trackBarFOV.Value.ToString();
            if (ingame)
                SetFOV();
        }
    }
}