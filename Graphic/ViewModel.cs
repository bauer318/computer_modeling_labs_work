using ComputerModelling.OneDimensionalLattice;
using ComputerModelling.QuadraticCongruentMethod;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using SkiaSharp;
using System;
using System.Linq;

namespace Graphic
{
    public class ViewModel
    {
        private static readonly RandomNumberGenerator _random = new RandomNumberGenerator(6, 7, 3, 4001);
        private static readonly OneDimensionalLatticeWorker one = new OneDimensionalLatticeWorker(_random, 0, 10, 3, 0.6);
        
        /// <summary>
        /// массив 
        /// </summary>
        private static double[] _values;

        /// <summary>
        /// данные гистрограммы
        /// </summary>
        private static double[] _dataPlot;
        /// <summary>
        /// данные статической функции
        /// </summary>
        private static double[] _dataFunc;
        /// <summary>
        /// Дисперсия
        /// </summary>
        private static double _dX;
        /// <summary>
        /// математическое ожидание
        /// </summary>
        private static double _mX;

        public int N { get; private set; }

        public string TextDx { get; private set; }
        public string TextMx { get; private set; }
        public string TextLambda { get; private set; }
        public ISeries[] Series { get; set; } =
        {

            new ColumnSeries<double>
            {

                Values = GetDataPlot(),
                Stroke = null,
                Fill = new SolidColorPaint(SKColors.DarkRed),
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
              TextSize = 12,
              Padding = new LiveChartsCore.Drawing.Padding(15),
              Paint = new SolidColorPaint(SKColors.Black)
        };

        public LabelVisual TitleStatFunc { get; set; } =
        new LabelVisual
        {
            Text = "Статическая функция распределения",
            TextSize = 12,
            Padding = new LiveChartsCore.Drawing.Padding(15),
            Paint = new SolidColorPaint(SKColors.Black)
        };

        public Axis[] YAxes { get; set; } = new Axis[]
         {
            new Axis
            {
                Name = "Pi",
                MinLimit = 0,
                MaxLimit = 0.3
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
            TextDx = Math.Round(_dX,4,MidpointRounding.AwayFromZero).ToString();
            TextMx = Math.Round(_mX, 4, MidpointRounding.AwayFromZero).ToString();
       
        }

        public static double[] GetDataPlot()
        {
            if (_values == null)
            {
                _values = one.GetValues(_random.G_N);
            }
            if (_dataPlot == null)
                _random.MakeData(_values, out _dataPlot, out _dataFunc, _values.Min(), _values.Max());
            return _dataPlot;
        }
        public static double[] GetDataFunc()
        {
            if (_values == null)
            {
                _values = one.GetValues(_random.G_N);
            }
            if (_dataFunc == null)
                _random.MakeData(_values, out _dataPlot, out _dataFunc, _values.Min(), _values.Max());
            return _dataFunc;
        }

        
    }
}
