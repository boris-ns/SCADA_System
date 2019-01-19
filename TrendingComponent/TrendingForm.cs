using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TrendingComponent
{
    public partial class TrendingForm : Form, ServiceReference.ITrendingCallback
    {
        private static ServiceReference.TrendingClient trendingService;

        // Key is tag name, value is measured value for that tag
        private Dictionary<string, float> tagValues;
        private Dictionary<string, Series> tagSeries;

        private Random random;

        public TrendingForm()
        {
            InitializeComponent();

            InstanceContext instanceContext = new InstanceContext(this);
            trendingService = new ServiceReference.TrendingClient(instanceContext);
            trendingService.TrendingClientInit();

            tagValues = new Dictionary<string, float>();
            tagSeries = new Dictionary<string, Series>();
            random = new Random();
        }

        public void SendNewValue(string tagName, string tagType, float value)
        {
            if (!tagValues.ContainsKey(tagName))
            {
                tagValues[tagName] = value;

                Series series = null;
                if (tagType == "digital")
                {
                    series = chartDigitalTags.Series.Add(tagName);
                    chartDigitalTags.Legends.Add(tagName);
                }
                else
                {
                    series = chartAnalogTags.Series.Add(tagName);
                    chartAnalogTags.Legends.Add(tagName);
                }

                series.ChartType = SeriesChartType.Line;

                Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                series.Color = randomColor;

                tagSeries[tagName] = series;
            }

            tagValues[tagName] = value;

            DrawTagValues();
        }

        private void DrawTagValues()
        {
            foreach (string tagName in tagValues.Keys)
            {
                tagSeries[tagName].Points.AddY(tagValues[tagName]);
            }
        }
    }
}
