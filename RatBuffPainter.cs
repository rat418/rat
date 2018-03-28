using SharpDX;
using System;
using System.Globalization;

namespace Turbo.Plugins.Default
{
    public class RatBuffPainter : BuffPainter
    {
        public RatBuffPainter(IController hud, bool setDefaultStyle)
            : base(hud, setDefaultStyle)
        {
            Enabled = true;
        }

        private void DrawTimeLeftNumbers(RectangleF rect, BuffPaintInfo info)
        {
            if (info.TimeLeft == 0) return;

            if (!ShowTimeLeftNumbers) return;
            if (info.TimeLeftNumbersOverride != null && info.TimeLeftNumbersOverride.Value == false) return;

            var text = "";
            if (info.TimeLeft > 1.0f)
            {
                var mins = Convert.ToInt32(Math.Floor(info.TimeLeft / 60.0d));
                var secs = Math.Floor(info.TimeLeft - mins * 60.0d);
                // if (info.TimeLeft >= 60)
                if (info.TimeLeft >= 120)
                {
                    text = mins.ToString("F0", CultureInfo.InvariantCulture) + ":" + (secs < 10 ? "0" : "") + secs.ToString("F0", CultureInfo.InvariantCulture);
                }
                else text = info.TimeLeft.ToString("F0", CultureInfo.InvariantCulture);
            }
            else text = info.TimeLeft.ToString("F1", CultureInfo.InvariantCulture);

            var layout = TimeLeftFont.GetTextLayout(text);
            TimeLeftFont.DrawText(layout, rect.X + (rect.Width - (float)Math.Ceiling(layout.Metrics.Width)) / 2.0f, rect.Y + (rect.Height - layout.Metrics.Height) / 2);
        }
    }
}
