using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.DataVisualization.Charting;
using System.IO;
using System.Drawing;


namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            

            return View();
        }
        public ActionResult Chart()
        {
            ViewBag.Message = "Chart page.";
            Chart chart = new Chart();
            chart.BackColor = Color.Transparent;
            chart.Width = 250;
            chart.Height = 100;

            Series series1 = new Series("Series1");
            series1.ChartArea = "ca1";
            series1.ChartType = SeriesChartType.Pie;
            series1.Font = new Font("Verdana", 8.25f, FontStyle.Regular);
            series1.Points.Add(new DataPoint
            {
                AxisLabel = "Value1",
                YValues = new double[] { 100, 200 }
            });
            series1.Points.Add(new DataPoint
            {
                AxisLabel = "Value2",
                YValues = new double[] { 100, 200 }
            });
            chart.Series.Add(series1);

            ChartArea ca1 = new ChartArea("ca1");
            ca1.BackColor = Color.Transparent;
            chart.ChartAreas.Add(ca1);

            using (var ms = new MemoryStream())
            {
                chart.SaveImage(ms, ChartImageFormat.Png);
                ms.Seek(0, SeekOrigin.Begin);

                byte[] imageByteData = ms.ToArray(); // File(ms.ToArray(), "image/png", "mychart.png");
                string imageBase64Data = Convert.ToBase64String(imageByteData);
                string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                ViewBag.ImageData = imageDataURL;
            }

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}