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
        private static RandomNumberGenerator _random = new RandomNumberGenerator(6, 7, 3, 4001);
        private static double[] _values;
        private static double[] _dataPlot;
        private static double[] _dataFunc;
        private static double _dX;
        private static double _mX;
        public string TextDx { get; set; }
        public string TextMx { get; set; }
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

        public Axis[] YAxes { get; set; } = new Axis[]
         {
            new Axis
            {
                Name = "Pi",
                MinLimit = 0,
                MaxLimit = 0.1
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

        public ViewModel()
        {
            _random.Estimate(_values, out _mX, out _dX);
            TextDx = _dX.ToString();
            TextMx = _mX.ToString();
        }

        public static double[] GetDataPlot()
        {
            if(_values==null)
            _random.GeneratorData(out _values);
            if (_dataPlot == null)
                _random.MakeData(_values, out _dataPlot, out _dataFunc, 0.0, 1.0);
            return _dataPlot;
        }
        public static double[] GetDataFunc()
        {
            if(_values==null)
            _random.GeneratorData(out _values);
            if (_dataFunc == null)
                _random.MakeData(_values, out _dataPlot, out _dataFunc, 0.0, 1.0);
            return _dataFunc;
        }

        
    }
}
