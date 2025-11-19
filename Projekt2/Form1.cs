using System.Globalization;

using System.Numerics;
using System.Windows.Forms;
using System.IO;
using System.Drawing;


namespace Projekt2
{
    public partial class Form1 : Form
    {
        const int width = 4;
        const int height = 4;
        const int amount = width * height;


        public Form1()
        {
            InitializeComponent();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog();
            dlg.Title = "Select a file";
            dlg.Filter = "Text files (*.txt)|*.txt";
            dlg.FilterIndex = 1;
            dlg.InitialDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.FullName;
            dlg.Multiselect = false;

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                string path = dlg.FileName;
                try
                {
                    List<Vector3> pts = new(amount);

                    var lines = File.ReadAllLines(path);
                    if (lines.Length != amount) throw new InvalidDataException("Plik musi zawieraæ 16 linii.");

                    for (int i = 0; i < amount; i++)
                    {
                        var line = lines[i].Trim();
                        if (string.IsNullOrEmpty(line))
                            throw new InvalidDataException($"Pusta linia: {i}");

                        var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length != 3)
                            throw new InvalidDataException($"Linia {i + 1} nie ma 3 wartoœci.");

                        var x = float.Parse(parts[0], CultureInfo.InvariantCulture);
                        var y = float.Parse(parts[1], CultureInfo.InvariantCulture);
                        var z = float.Parse(parts[2], CultureInfo.InvariantCulture);


                        pts.Add(new Vector3(x, y, z));
                    }


                    surfaceCanvas1.UpdateAngles(alfaBar.Value, betaBar.Value);
                    surfaceCanvas1.UpdatePrecision(uBar.Value, vBar.Value);
                    surfaceCanvas1.SetControlPoints(pts, width, height);

                    surfaceCanvas1.SetKd((float)kdBar.Value / kdBar.Maximum);
                    surfaceCanvas1.SetKs((float)ksBar.Value / ksBar.Maximum);
                    surfaceCanvas1.SetM(mBar.Value);

                    surfaceCanvas1.Refresh();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, $"Selected file: {path}\n\nUnable to load: {ex.Message}", "File selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void alfaBar_ValueChanged(object sender, EventArgs e)
        {
            surfaceCanvas1.UpdateAngles(alfaBar.Value, betaBar.Value);
            alfaLabel.Text = $"alfa: {alfaBar.Value}°";

        }

        private void betaBar_ValueChanged(object sender, EventArgs e)
        {
            surfaceCanvas1.UpdateAngles(alfaBar.Value, betaBar.Value);
            betaLabel.Text = $"beta: {betaBar.Value}°";
        }

        private void precisionU_ValueChanged(object sender, EventArgs e)
        {
            surfaceCanvas1.UpdatePrecision(uBar.Value, vBar.Value);
            uLabel.Text = $"u: {uBar.Value}";
        }

        private void precisionV_ValueChanged(object sender, EventArgs e)
        {
            surfaceCanvas1.UpdatePrecision(uBar.Value, vBar.Value);
            vLabel.Text = $"v: {vBar.Value}";
        }




        private void controlNetBox_CheckedChanged(object sender, EventArgs e)
        {
            if (controlNetBox.Checked)
            {
                DisplayStrategy.AddStrategy(ControlNet.GetInstance());
            }
            else
            {
                DisplayStrategy.RemoveStrategy(ControlNet.GetInstance());
            }

            surfaceCanvas1.Refresh();
        }

        private void meshBox_CheckedChanged(object sender, EventArgs e)
        {
            if (meshBox.Checked)
            {
                DisplayStrategy.AddStrategy(Mesh.GetInstance());
            }
            else
            {
                DisplayStrategy.RemoveStrategy(Mesh.GetInstance());
            }

            surfaceCanvas1.Refresh();

        }

        private void fillBox_CheckedChanged(object sender, EventArgs e)
        {
            if (fillBox.Checked)
            {
                DisplayStrategy.AddStrategy(Fill.GetInstance());
            }
            else
            {
                DisplayStrategy.RemoveStrategy(Fill.GetInstance());

            }

            surfaceCanvas1.Refresh();

        }


        private void kdBar_ValueChanged(object sender, EventArgs e)
        {
            surfaceCanvas1.SetKd((float)kdBar.Value / kdBar.Maximum);

            kdLabel.Text = $"kd: {kdBar.Value}%";
        }

        private void ksBar_ValueChanged(object sender, EventArgs e)
        {
            surfaceCanvas1.SetKs((float)ksBar.Value / ksBar.Maximum);
            ksLabel.Text = $"ks: {ksBar.Value}%";
        }

        private void mBar_ValueChanged(object sender, EventArgs e)
        {
            surfaceCanvas1.SetM(mBar.Value);
            mLabel.Text = $"m: {mBar.Value}";
        }




        private void surfaceColorButton_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.AllowFullOpen = true;
                colorDialog.AnyColor = true;

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    surfaceCanvas1.SetSurfaceColor(colorDialog.Color);
                }
            }

        }

        private void lightColorButton_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.AllowFullOpen = true;
                colorDialog.AnyColor = true;

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    surfaceCanvas1.SetLightColor(colorDialog.Color);
                }
            }

        }


        // TODO merge those next 2 meyhods
        private void loadTextureButton_Click(object sender, EventArgs e)
        {
            if (surfaceCanvas1.surface == null)
            {
                MessageBox.Show(this, "Load control points first.", "Load map", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            using var dlg = new OpenFileDialog();
            dlg.Title = "Select a file";
            dlg.Filter = "PNG images (*.png)|*.png";
            dlg.FilterIndex = 1;

            dlg.InitialDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.FullName;
            dlg.Multiselect = false;

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                string path = dlg.FileName;
                try
                {
                    using var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                    using var srcImage = Image.FromStream(fs);

                    var bmp = new Bitmap(srcImage);
                    
                    var oldDisplayImage = textureDisplay.BackgroundImage;
                    textureDisplay.BackgroundImage = new Bitmap(bmp);
                    textureDisplay.BackgroundImageLayout = ImageLayout.Zoom;
                    oldDisplayImage?.Dispose();

                    surfaceCanvas1.SetTexture(bmp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, $"Unable to load image: {ex.Message}", "Load map", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




        private void mapButton_Click(object sender, EventArgs e)
        {
            if (surfaceCanvas1.surface == null)
            {
                MessageBox.Show(this, "Load control points first.", "Load map", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            using var dlg = new OpenFileDialog();
            dlg.Title = "Select a file";
            dlg.Filter = "PNG images (*.png)|*.png";
            dlg.FilterIndex = 1;

            dlg.InitialDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.FullName;
            dlg.Multiselect = false;

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                string path = dlg.FileName;
                try
                {
                    using var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                    using var srcImage = Image.FromStream(fs);

                    var bmp = new Bitmap(srcImage);

                    var oldDisplayImage = mapDisplay.BackgroundImage;
                    mapDisplay.BackgroundImage = new Bitmap(bmp);
                    mapDisplay.BackgroundImageLayout = ImageLayout.Zoom;
                    oldDisplayImage?.Dispose();

                    surfaceCanvas1.SetMap(bmp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, $"Unable to load image: {ex.Message}", "Load map", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void useMapButton_CheckedChanged(object sender, EventArgs e)
        {
            surfaceCanvas1.UseMap(useMapButton.Checked);
        }

        private void useTextureButton_CheckedChanged(object sender, EventArgs e)
        {

            surfaceCanvas1.UseTexture(useTextureButton.Checked);
        }
    }
}
