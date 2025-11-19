using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            txtHasil.Text = "Loading routes.csv data, please wait.....";
            await LoadFlightDataAsync();
        }

        private async Task LoadFlightDataAsync()
        {
            string csvFilePath = "routes.csv";

            if (!File.Exists(csvFilePath))
            {
                MessageBox.Show($"File is not found: {csvFilePath}\nMake sure all CSV file is in folder output.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                List<string> airportList = null;
                int airportCount = 0;
                int flightCount = 0;

                await Task.Run(() =>
                {
                    var localGraph = new Dictionary<string, List<Flight>>();
                    var localAllAirports = new HashSet<string>();
                    int localFlightCount = 0;

                    var lines = File.ReadAllLines(csvFilePath).Skip(1);

                    foreach (var line in lines)
                    {
                        try
                        {
                            var parts = line.Split(',');
                            if (parts.Length < 9) continue;

                            string stops = parts[7].Trim('"');

                            if (stops.Equals("0"))
                            {
                                string airline = parts[0].Trim('"');
                                string airlineId = parts[1].Trim('"');
                                string combinedFlightId = $"{airline}-{airlineId}";

                                string fromAirport = parts[2].Trim('"');
                                string toAirport = parts[4].Trim('"');

                                if (string.IsNullOrWhiteSpace(fromAirport) || fromAirport == "\\N" ||
                                    string.IsNullOrWhiteSpace(toAirport) || toAirport == "\\N" ||
                                    string.IsNullOrWhiteSpace(airline) || airline == "\\N" ||
                                    string.IsNullOrWhiteSpace(airlineId) || airlineId == "\\N")
                                {
                                    continue;
                                }

                                int durationInMinutes = 1;

                                var flight = new Flight(fromAirport, toAirport, durationInMinutes, combinedFlightId);

                                if (!localGraph.ContainsKey(fromAirport))
                                {
                                    localGraph[fromAirport] = new List<Flight>();
                                }
                                localGraph[fromAirport].Add(flight);
                                localFlightCount++;

                                localAllAirports.Add(fromAirport);
                                localAllAirports.Add(toAirport);
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }

                    foreach (var airport in localAllAirports)
                    {
                        if (!localGraph.ContainsKey(airport))
                        {
                            localGraph[airport] = new List<Flight>();
                        }
                    }

                    _flightGraph = localGraph;

                    airportList = localAllAirports.OrderBy(name => name).ToList();
                    airportCount = localAllAirports.Count;
                    flightCount = localFlightCount;
                });

                if (airportList != null && airportList.Count > 0)
                {
                    comboAsal.Items.AddRange(airportList.ToArray());
                    comboTujuan.Items.AddRange(airportList.ToArray());

                    txtHasil.Text = $"Data routes.csv succesfully loaded.\nFounded {airportCount} airports.\n Please select route.";
                }
                else
                {
                    txtHasil.Text = "CSV succesfully loaded, but there is no direct flight, please check CSV";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while load the data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                txtHasil.Text = "Please select origin and destination airport";
                return;
            }

            string startNode = comboAsal.SelectedItem.ToString();
            string endNode = comboTujuan.SelectedItem.ToString();

            if (startNode == endNode)
            {
                txtHasil.Text = "Origin and destination airport cannot be the same.";
                return;
            }

            var resultBuilder = new StringBuilder();
            resultBuilder.AppendLine($"Searching routes from {startNode} to {endNode}...");
            resultBuilder.AppendLine("==========================================");
            resultBuilder.AppendLine();

            resultBuilder.AppendLine("--- Routes founded ---");

            var bfsRoute = BFSFinder.FindRouteBFS(_flightGraph, startNode, endNode);

            if (bfsRoute.Count > 0)
            {
                int transitCount = Math.Max(0, bfsRoute.Count - 1);
                resultBuilder.AppendLine($"Total transit: {transitCount}");
                resultBuilder.AppendLine("Route details:");

                int flightNumber = 1;
                foreach (var flight in bfsRoute)
                {
                    resultBuilder.AppendLine($"  Flight {flightNumber}: {flight.From} to {flight.To} ({flight.FlightId})");
                    flightNumber++;
                }
            }
            else
            {
                resultBuilder.AppendLine("No routes found!.");
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