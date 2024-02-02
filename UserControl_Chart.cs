using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using LiveCharts;
using LiveCharts.WinForms;
using static reme.Receipt;
using LiveCharts.Wpf;
using System.Globalization;

namespace reme
{
    public partial class UserControl_Chart : UserControl
    {
        public UserControl_Chart()
        {
            InitializeComponent();
            LoadDataFromJson();
        }

        private void LoadDataFromJson()
        {
            try
            {
                string jsonFilePath = "inventory.json";

                if (File.Exists(jsonFilePath))
                {
                    string jsonData = File.ReadAllText(jsonFilePath);

                    List<ReceiptEntry> receiptEntries = JsonConvert.DeserializeObject<List<ReceiptEntry>>(jsonData);

                    // Calculate total amount per day
                    Dictionary<DateTime, int> totalAmountPerDay = CalculateTotalAmountPerDay(receiptEntries);

                    // Calculate items sold per day
                    Dictionary<DateTime, Dictionary<string, int>> itemsSoldPerDay = CalculateItemsSoldPerDay(receiptEntries);

                    // Populate chart with data
                    PopulateChart(totalAmountPerDay);

                  
                    // Populate bar chart with data
                    PopulateBarChart(totalAmountPerDay);

                    // Calculate yearly sales data
                    Dictionary<DateTime, int> yearlySalesData = CalculateTotalAmountPerYear(totalAmountPerDay);

                    // Populate yearly sales chart
                    PopulateYearlySalesChart(yearlySalesData);

                    PopulateMostOrderedItemsChart(receiptEntries);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data from JSON: {ex.Message}");
            }
        }


        //Calculate Amount PerDay
        private Dictionary<DateTime, int> CalculateTotalAmountPerDay(List<ReceiptEntry> receiptEntries)
        {
            Dictionary<DateTime, int> totalAmountPerDay = new Dictionary<DateTime, int>();

            foreach (ReceiptEntry entry in receiptEntries)
            {
                DateTime date = DateTime.Parse(entry.DATE).Date;

                if (totalAmountPerDay.ContainsKey(date))
                {
                    totalAmountPerDay[date] += entry.TotalAmount;
                }
                else
                {
                    totalAmountPerDay[date] = entry.TotalAmount;
                }
            }

            return totalAmountPerDay;
        }

        private Dictionary<DateTime, Dictionary<string, int>> CalculateItemsSoldPerDay(List<ReceiptEntry> receiptEntries)
        {
            Dictionary<DateTime, Dictionary<string, int>> itemsSoldPerDay = new Dictionary<DateTime, Dictionary<string, int>>();

            foreach (ReceiptEntry entry in receiptEntries)
            {
                DateTime date = DateTime.Parse(entry.DATE).Date;

                if (!itemsSoldPerDay.ContainsKey(date))
                {
                    itemsSoldPerDay[date] = new Dictionary<string, int>();
                }

                foreach (Item item in entry.Items)
                {
                    if (itemsSoldPerDay[date].ContainsKey(item.Order))
                    {
                        itemsSoldPerDay[date][item.Order] += item.Quantity;
                    }
                    else
                    {
                        itemsSoldPerDay[date][item.Order] = item.Quantity;
                    }
                }
            }

            return itemsSoldPerDay;
        }

        private void PopulateChart(Dictionary<DateTime, int> data)
        {
            cartesianChart1.Series.Clear();

            // Create a series to hold the data points
            LineSeries series = new LineSeries
            {
                Title = "Sales Data",
                Values = new ChartValues<int>(),
                PointGeometrySize = 10 // Optional: Adjust the size of the data points
            };

            // Add data points to the series
            foreach (var entry in data)
            {
                // Add each data point to the series
                series.Values.Add(entry.Value);
            }

            // Add the series to the chart
            cartesianChart1.Series.Add(series);

            // Set up X-axis labels
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Date",
                Labels = data.Keys.Select(date => date.ToShortDateString()).ToList()
            });
        }



        private void PopulateBarChart(Dictionary<DateTime, int> totalAmountPerDay)
        {
            // Clear existing series
            cartesianChart2.Series.Clear();

            // Dictionary to store the total amount obtained for each month
            Dictionary<string, decimal> totalAmountPerMonth = new Dictionary<string, decimal>();

            // Iterate through each day's data
            foreach (var entry in totalAmountPerDay)
            {
                DateTime date = entry.Key;
                string monthYearKey = $"{date.Year}-{date.Month}";

                // If the month-year key doesn't exist, initialize it with zero
                if (!totalAmountPerMonth.ContainsKey(monthYearKey))
                {
                    totalAmountPerMonth[monthYearKey] = 0;
                }

                // Add the total amount obtained on this day to the respective month's total
                totalAmountPerMonth[monthYearKey] += entry.Value;
            }

            // Create series for the bar chart
            SeriesCollection seriesCollection = new SeriesCollection();

            // Create a column series for the bar chart
            ColumnSeries columnSeries = new ColumnSeries
            {
                Title = "Monthly Sales", // Title of the series
                Values = new ChartValues<decimal>(), // Values for the series
                DataLabels = true // Enable data labels
            };

            // Add data to the column series
            foreach (var monthData in totalAmountPerMonth)
            {
                columnSeries.Values.Add(monthData.Value);
            }

            // Add the column series to the series collection
            seriesCollection.Add(columnSeries);

            // Set X-axis labels to display month-year keys
            cartesianChart2.AxisX.Clear();
            cartesianChart2.AxisX.Add(new Axis
            {
                Labels = totalAmountPerMonth.Keys.ToArray()
            });

            // Set the series collection to the chart
            cartesianChart2.Series = seriesCollection;
        }

        private void PopulateYearlySalesChart(Dictionary<DateTime, int> yearlySalesData)
        {
            // Clear existing series
            cartesianChart3.Series.Clear();

            // Aggregate sales data by year
            var salesByYear = yearlySalesData
                .GroupBy(x => x.Key.Year)
                .ToDictionary(x => x.Key.ToString(), x => x.Sum(y => y.Value));

            // Create series for the column chart
            SeriesCollection seriesCollection = new SeriesCollection();

            // Create a column series for the chart
            ColumnSeries columnSeries = new ColumnSeries
            {
                Title = "Yearly Sales", // Title of the series
                Values = new ChartValues<int>(), // Values for the series
                DataLabels = true // Enable data labels
            };

            // Add data to the column series
            foreach (var year in salesByYear.OrderBy(x => x.Key))
            {
                columnSeries.Values.Add(year.Value);
            }

            // Add the column series to the series collection
            seriesCollection.Add(columnSeries);

            // Set X-axis labels to display year values
            cartesianChart3.AxisX.Clear();
            cartesianChart3.AxisX.Add(new Axis
            {
                Labels = salesByYear.Keys.ToArray()
            });

            // Set the series collection to the chart
            cartesianChart3.Series = seriesCollection;
        }


        private Dictionary<DateTime, int> CalculateTotalAmountPerYear(Dictionary<DateTime, int> totalAmountPerDay)
        {
            // Aggregate total amount per year
            var totalAmountPerYear = totalAmountPerDay
                .GroupBy(x => x.Key.Year)
                .ToDictionary(x => new DateTime(x.Key, 1, 1), x => x.Sum(y => y.Value));

            return totalAmountPerYear;
        }

        private void PopulateMostOrderedItemsChart(List<ReceiptEntry> receiptEntries)
        {
            // Dictionary to store the frequency of each item
            Dictionary<string, int> itemFrequency = new Dictionary<string, int>();

            // Calculate the frequency of each item
            foreach (var entry in receiptEntries)
            {
                foreach (var item in entry.Items)
                {
                    // Split the order string into individual items
                    var orders = item.Order.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                    // Increment the frequency count for each item
                    foreach (var order in orders)
                    {
                        if (itemFrequency.ContainsKey(order))
                        {
                            itemFrequency[order] += item.Quantity;
                        }
                        else
                        {
                            itemFrequency[order] = item.Quantity;
                        }
                    }
                }
            }

            // Sort items by frequency in descending order
            var sortedItems = itemFrequency.OrderByDescending(pair => pair.Value);

            // Select top N most ordered items (you can adjust N as needed)
            var topItems = sortedItems.Take(5);

            // Prepare data for the chart
            var labels = topItems.Select(pair => pair.Key).ToList();
            var values = topItems.Select(pair => pair.Value).ToList();

            // Modify the existing chart
            cartesianChart4.Series.Clear();

            // Add series for the chart
            cartesianChart4.Series = new SeriesCollection
    {
        new LineSeries
        {
            Title = "Most Ordered Items",
            Values = new ChartValues<int>(values)
        }
    };

            // Set up X-axis labels
            cartesianChart4.AxisX.Add(new Axis
            {
                Title = "Items",
                Labels = labels
            });

            // Set up Y-axis
            cartesianChart4.AxisY.Add(new Axis
            {
                Title = "Frequency"
            });

            // Set the name of the chart
            cartesianChart4.Name = "Most Order Menu";
        }

    }
}
    
