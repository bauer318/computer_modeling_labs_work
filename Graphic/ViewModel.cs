using ComputerModelling.QuadraticCongruentMethod;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using SkiaSharp;
using System;
using System.Globalization;
using System.Linq;

namespace Graphic
{
    public class ViewModel
    {
        private static readonly RandomNumberGenerator _random = new RandomNumberGenerator(6, 7, 3, 4001);
        /// <summary>
        /// массив случайных значений равномерного распределения на [0;1)
        /// </summary>
        private static double[] _values;

        /// <summary>
        /// массив случайных значений по нормальному распределению N(3.5,0.9)
        /// </summary>
        private static double[] _xValues;

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

        private readonly double _lambda;
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
            
            TextDx = Math.Round(_dX,4,MidpointRounding.AwayFromZero).ToString();
            TextMx = Math.Round(_mX, 4, MidpointRounding.AwayFromZero).ToString();
           
            TextLambda = Math.Round(_lambda, 4, MidpointRounding.AwayFromZero).ToString();
        }

        public static double[] GetDataPlot()
        {
            if (_values == null)
            {
                _random.GeneratorData(out _values);
             
            }
            if (_dataPlot == null)
                _random.MakeData(_xValues, out _dataPlot, out _dataFunc, _xValues.Min(), _xValues.Max());
            return _dataPlot;
        }
        public static double[] GetDataFunc()
        {
            if (_values == null)
            {
                _random.GeneratorData(out _values);
            }
            if (_dataFunc == null)
                _random.MakeData(_xValues, out _dataPlot, out _dataFunc, _xValues.Min(), _xValues.Max());
            return _dataFunc;
        }

        
    }
}
