using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerModelling.PokerTest
{
    public class PokerTest
    {
        /// <summary>
        /// Массив случайных чисел, сгенерированных тестируемым генератором
        /// </summary>
        private readonly double[] _values;
        /// <summary>
        /// количество случайных чисел в массиве <see cref="_values"/>
        /// </summary>
        private readonly int _n;
        /// <summary>
        /// количество равноверотностных интервалов
        /// </summary>
        private readonly int _k;
        /// <summary>
        /// Новая последовательность случайных чисел
        /// </summary>
        private int[] _y;
        /// <summary>
        /// Количество пятерок
        /// </summary>
        private int _n5;
        /// <summary>
        /// Количество пятерок разного класса
        /// </summary>
        private int _Nabcde = 0;
        private int _Naabcd = 0;
        private int _Naabbc = 0;
        private int _Naaabc = 0;
        private int _Naaabb = 0;
        private int _Naaaab = 0;
        private int _Naaaaa = 0;
        /// <summary>
        /// Вероятности появления пятерок разных классов
        /// </summary>
        public double Pabcde { get; private set; }
        public double Paabcd { get; private set; }
        public double Paabbc { get; private set; }
        public double Paaabc { get; private set; }
        public double Paaabb { get; private set; }
        public double Paaaab { get; private set; }
        public double Paaaaa { get; private set; }
        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        private PokerTest() { }
        /// <summary>
        /// иницилизирует объект покер-теста
        /// </summary>
        /// <param name="parValues">Массив случайных чисел, сгенерированных 
        /// тестируемым генератором</param>
        /// <param name="parN">количество случайных чисел в массиве</param>
        /// <param name="parK">количество равноверотностных интервалов</param>
        public PokerTest(double[] parValues, int parN, int parK)
        {
            _values = parValues;
            _n = parN;
            _k = parK;
            _n5 = _n / 5;
        }
        /// <summary>
        /// создает новую последовательность случайных чисел 
        /// </summary>
        private void InitY()
        {
            _y = new int[_n];
            for(int i=0; i < _n; i++)
            {
                _y[i] = (int)(_values[i] * _k);
            }
        }
        /// <summary>
        /// Определяет количество пятерок
        /// </summary>
        public void DetemineFivesDifferentClassesNumber()
        {
            int[] numN = new int[5];
            int[] repN = new int[5];
            InitY();
            for(int i=0; i<_n5-1; i++)
            {
                /*Обнувляем массив, в котором будем хранить
                 * количество повторений j-го числа в пятерке
                 */
                for (int j = 0; j < 5; j++)
                {
                    numN[j] = 0;
                }
                for (int j = 0; j < 5; j++)
                {
                    for(int m=0; m < 5; m++)
                    {
                        if (_y[j + i * 5] == _y[m + i * 5])
                        {
                            numN[j]++;
                        }
                    }
                }
                /*Обнувляем массив, в котором будем хранить
                 * сколько раз встретилось j повторяющихся чисел
                 */
                for (int j = 0; j < 5; j++)
                {
                    repN[j] = 0;
                }
                for (int j = 0; j < 5; j++)
                {
                    repN[numN[j] - 1]++;
                }
                //определяем класс пятерки
                DefineFiveClass(repN);
            }
            //оцениваем вероятности появления пятерок разных классов
            EvaluatesProbability();
        }
        /// <summary>
        /// Определяет класс пятерки
        /// </summary>
        /// <param name="parRepN">Массив кол-во раза встретилось j повторяющихся чисел</param>
        private void DefineFiveClass(int[] parRepN)
        {
            if (parRepN[0] == 5)
            {
                _Nabcde++;
            }
            else if (parRepN[0] == 3)
            {
                _Naabcd++;
            }
            else if (parRepN[1] == 4)
            {
                _Naabbc++;
            }
            else if((parRepN[1]==2) && (parRepN[2] == 3))
            {
                _Naaabb++;
            }
            else if (parRepN[3] == 4)
            {
                _Naaaab++;
            }
            else if (parRepN[4] == 5)
            {
                _Naaaaa++;
            }
            else
            {
                _Naaabc++;
            }
        }
        /// <summary>
        /// Оценивает вероятности появления пятерок разных классов
        /// </summary>
        private void EvaluatesProbability()
        {
            Pabcde = (double)_Nabcde / _n5;
            Paabcd = (double)_Naabcd / _n5;
            Paabbc = (double)_Naabbc / _n5;
            Paaabc = (double)_Naaabc / _n5;
            Paaabb = (double)_Naaabb / _n5;
            Paaaab = (double)_Naaaab / _n5;
            Paaaaa = (double)_Naaaaa / _n5;
        }

    }
}
