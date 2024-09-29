using mw2_fps_unlocker.Memory;
using mw2_fps_unlocker.App;
using System.ComponentModel;

namespace mw2_fps_unlocker
{
    public partial class AppForm : Form
    {
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
            trackBarFPS.Maximum = 300;
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
                    mem = new MemoryHandler(mw2.Handle);
                    ingame = true;
                    updater.RunWorkerAsync();
                }));
            });
        }

        /// <summary>
        /// We need to constantly write the FPS and FOV change. Otherwise
        /// it resets back to normal by mw2.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Updater_DoWork(object? sender, DoWorkEventArgs e)
        {
            LabelStatusValue.Text = "MW2 Started";
            LabelStatusValue.ForeColor = Color.Green;

            while (proc.IsRunning())
            {
                SetFPS();
                SetFOV();
                Thread.Sleep(250);
            }

            LabelStatusValue.Text = "Not In-game";
            LabelStatusValue.ForeColor = Color.RoyalBlue;

            // Start the Find Process routine so we don't need to restart
            // the app.
            FindProcess();
        }

        private void SetFPS()
        {
            if (mem == null)
                return;

            mem.WriteInteger(
                mem.ReadInteger(0x01B90730, 4) + 0xC, 
                trackBarFPS.Value
            );
        }
        private void SetFOV()
        {
            if (mem == null)
                return;

            mem.WriteFloat(
                mem.ReadInteger(0x00AAC1F8, 4) + 0xC, 
                trackBarFOV.Value
            );
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