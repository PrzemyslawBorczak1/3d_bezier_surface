using System.Globalization;

using System.Numerics;


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

        }

        private void betaBar_ValueChanged(object sender, EventArgs e)
        {
            surfaceCanvas1.UpdateAngles(alfaBar.Value, betaBar.Value);
        }


        private void precisionU_ValueChanged(object sender, EventArgs e)
        {
            surfaceCanvas1.UpdatePrecision(uBar.Value,  vBar.Value);
        }


        private void precisionV_ValueChanged(object sender, EventArgs e)
        {
            surfaceCanvas1.UpdatePrecision(uBar.Value, vBar.Value);
        }
    }
}
