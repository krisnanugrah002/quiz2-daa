using System.Text;

namespace quiz2_daa_bfs
{
    public partial class Form1 : Form
    {
        private Dictionary<string, List<Flight>> _flightGraph;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            txtHasil.Text = "Sedang memuat data routes.csv di background...\nMohon tunggu...";
            await LoadFlightDataAsync();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            if (_flightGraph == null || _flightGraph.Count == 0)
            {
                txtHasil.Text = "Data penerbangan belum selesai dimuat atau gagal dimuat.";
                return;
            }

            if (comboAsal.SelectedItem == null || comboTujuan.SelectedItem == null)
            {
                txtHasil.Text = "Silakan pilih bandara Asal dan Tujuan.";
                return;
            }

            string startNode = comboAsal.SelectedItem.ToString();
            string endNode = comboTujuan.SelectedItem.ToString();

            if (startNode == endNode)
            {
                txtHasil.Text = "Bandara Asal dan Tujuan tidak boleh sama.";
                return;
            }

            var resultBuilder = new StringBuilder();
            resultBuilder.AppendLine($"Mencari rute dari {startNode} ke {endNode}...");
            resultBuilder.AppendLine("==========================================");
            resultBuilder.AppendLine();

            resultBuilder.AppendLine("--- Hasil BFS (Rute Paling Sedikit Transit) ---");

            var bfsRoute = BFSFinder.FindRouteBFS(_flightGraph, startNode, endNode);

            if (bfsRoute.Count > 0)
            {
                int transitCount = Math.Max(0, bfsRoute.Count - 1);
                resultBuilder.AppendLine($"Jumlah Transit: {transitCount}");
                resultBuilder.AppendLine("Detail Rute:");

                int flightNumber = 1;
                foreach (var flight in bfsRoute)
                {
                    resultBuilder.AppendLine($"  Flight {flightNumber}: {flight.From} to {flight.To} ({flight.FlightId})");
                    flightNumber++;
                }
            }
            else
            {
                resultBuilder.AppendLine("Tidak ada rute yang ditemukan.");
            }

            txtHasil.Text = resultBuilder.ToString();
        }

        private void comboAsal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
