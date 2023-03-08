using ComputerModelling.Kolmogorov;
using ComputerModelling.Pearson;
using ComputerModelling.QuadraticCongruentMethod;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using SkiaSharp;
using System;
using System.Globalization;

namespace Graphic
{
    public class ViewModel
    {
        private static readonly RandomNumberGenerator _random = new RandomNumberGenerator(6, 7, 3, 4001);
        /// <summary>
        /// массив случайных значений
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
        /// <summary>
        /// второй момент
        /// </summary>
        private static double _m2;
        /// <summary>
        /// третий момент
        /// </summary>
        private static double _m3;

        public double[] Values { get; private set; }
        public int N { get; private set; }

        private readonly double[] _pearsonDataPlot;
        private readonly double _xi2;
        private readonly double[] _pk;
        private readonly double _lambda;
        public string TextDx { get; private set; }
        public string TextMx { get; private set; }
        public string TextM2 { get; private set; }
        public string TextM3 { get; private set; }
        public string TextXi2 { get; private set; }
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
            _m2 = _random.GetMoment(2, _values);
            _m3 = _random.GetMoment(3, _values);
            TextDx = Math.Round(_dX,4,MidpointRounding.AwayFromZero).ToString();
            TextMx = Math.Round(_mX, 4, MidpointRounding.AwayFromZero).ToString();
            TextM2 = Math.Round(_m2, 4, MidpointRounding.AwayFromZero).ToString();
            TextM3 = Math.Round(_m3, 4, MidpointRounding.AwayFromZero).ToString();
            _pk = PearsonCriteriaWorker.GetProbalities(_random.K);
            _pearsonDataPlot = PearsonCriteriaWorker.GetDataPlot(_dataPlot, _random.G_N, _random.K);
            _xi2 = PearsonCriteriaWorker.Xi2(_pearsonDataPlot, _pk, _random.K, _random.G_N);
            TextXi2 = Math.Round(_xi2, 4, MidpointRounding.AwayFromZero).ToString();
            _lambda = KolmogorovCriteriaWorker.Lambda(_values, _random.G_N);
            TextLambda = Math.Round(_lambda, 4, MidpointRounding.AwayFromZero).ToString();
            Values = _values;
            N = _random.G_N;
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
