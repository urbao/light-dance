using NAudio.Gui;
using NAudio.Wave;
using System.Drawing;
using System.Windows.Forms;

public class CustomWaveViewer : WaveViewer
{
    // Custom property for setting the waveform color
    public Color WaveformColor { get; set; } = Color.Red;

    protected override void OnPaint(PaintEventArgs e)
    {
        // Call the base class OnPaint method to perform the default painting
        base.OnPaint(e);

        // Get the waveStream field using reflection
        var waveStreamField = typeof(WaveViewer).GetField("waveStream", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var waveStream = waveStreamField.GetValue(this) as WaveStream;

        if (waveStream != null)
        {
            // Create a new pen with the specified color
            using (Pen pen = new Pen(WaveformColor))
            {
                // Calculate the height scale for drawing the waveform
                float heightScale = (float)Height / 2;

                // Calculate the width scale for drawing the waveform
                float widthScale = (float)Width / waveStream.Length;

                // Get the buffer containing the waveform data
                byte[] buffer = new byte[waveStream.Length];
                waveStream.Position = 0;
                waveStream.Read(buffer, 0, buffer.Length);

                // Draw the waveform with the custom color
                for (int i = 0; i < waveStream.Length - 1; i++)
                {
                    float x1 = i * widthScale;
                    float y1 = heightScale - (buffer[i] / 256f * heightScale);
                    float x2 = (i + 1) * widthScale;
                    float y2 = heightScale - (buffer[i + 1] / 256f * heightScale);

                    e.Graphics.DrawLine(pen, x1, y1, x2, y2);
                }
            }
        }
    }
}
