using ComputerModelling.QuadraticCongruentMethod;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using SkiaSharp;

namespace Graphic
{
    public class ViewModel
    {
        static RandomNumberGenerator random = new RandomNumberGenerator(6, 7, 3, 4001);
        static double[] values;
        static double[] dataPlot;
        static double[] dataFunc;
        private static double dX;
        private static double mX;
        public string TextDx { get; set; }
        public string TextMx { get; set; }

        public ViewModel()
        {
            random.Estimate(values, out mX, out dX);
            TextDx = dX.ToString();
            TextMx = mX.ToString();
        }

        public ISeries[] Series { get; set; } =
        {

            new ColumnSeries<double>
            {

                Values = GetDataPlot(),
                Stroke = null,
                Fill = new SolidColorPaint(SKColors.CornflowerBlue),
                IgnoresBarPosition = true,

            }
        };

        public ISeries[] SeriesStatFunc { get; set; } =
        {
            new LineSeries<double>
            {
                Values = GetDataFunc(),
                Fill = null
            }
        };

        public LabelVisual TitleHistogram { get; set; } =
       new LabelVisual
       {
           Text = "Гистогрмма частот",
           TextSize = 10,
           Padding = new LiveChartsCore.Drawing.Padding(15),
           Paint = new SolidColorPaint(SKColors.DarkSlateGray)
       };
        public LabelVisual TitleStatFunc { get; set; } =
        new LabelVisual
        {
            Text = "Статическая функция распределения",
            TextSize = 10,
            Padding = new LiveChartsCore.Drawing.Padding(15),
            Paint = new SolidColorPaint(SKColors.DarkSlateGray)
        };
        public static double[] GetDataPlot()
        {
            if(values==null)
            random.GeneratorData(out values);
            if (dataPlot == null)
                random.MakeData(values, out dataPlot, out dataFunc, 0.0, 1.0);
            return dataPlot;
        }
        public static double[] GetDataFunc()
        {
            if(values==null)
            random.GeneratorData(out values);
            if (dataFunc == null)
                random.MakeData(values, out dataPlot, out dataFunc, 0.0, 1.0);
            return dataFunc;
        }

        public Axis[] YAxes { get; set; } = new Axis[]
        {
            new Axis
            {
                Name = "Pi",
                MinLimit = 0,
                MaxLimit = 1,
                MinStep = 1
            }
        };
        public Axis[] XAxes { get; set; } = new Axis[]
        {
            new Axis
            {
                Name = "X",
                MinStep = 1,
                Labels = new string[]{}
            }
        };
        public Axis[] YAxesStatFunc { get; set; } = new Axis[]
       {
            new Axis
            {
                Name = "Fx(x)",
                
            }
       };
    }
}
