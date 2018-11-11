using NLog;
using System.Timers;

namespace Cardiology.Utils
{
    internal class SilentSaver
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private static IAutoSaveForm form;
        private static bool start;
        private static Timer timer = null;

        internal static void setForm(IAutoSaveForm f)
        {
            form = f;
            start = true;
            if (timer == null)
            {
                timer = new System.Timers.Timer();
                timer.Elapsed += new ElapsedEventHandler(OnAutoSave);
                timer.Interval = 1000 * 60;
                timer.Enabled = true;
            }

            timer.Start();
        }

        internal static void clearForm()
        {
            form = null;
            stop();
        }

        internal static void startWork()
        {
            start = true;
        }

        internal static void stop()
        {
            start = false;
            if(timer!=null)
            {
                timer.Stop();
            }
        }

        private static void OnAutoSave(object source, ElapsedEventArgs e)
        {
            if (start && form != null)
            {
                logger.Debug("auto save is started");
                form.save();
                logger.Debug("auto save is ended");
            }
        }
    }
}
