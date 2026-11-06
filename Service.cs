using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChainConnectedOscillators.Repositories.Drawing;
using ChainConnectedOscillators.Repositories.Mathematic;
namespace ChainConnectedOscillators
{
    public class Service
    {
        //создания массива состояний N*2,
        //где i[0]-координата i шара в мировых координатах
        // i[1] - скорость i шара в мировых координатах
        //для вывода по факту надо только координату шара, а скорость для расчета следующей координаты 
        // + нужна функция преобразования мировой координаты в экранную
        int N;
        double[,] Ball_States;
        double current_time;
        const double R = 0.05;//5 см
        public const double lenCoil = 4 * R;//20 см длина пружины в нерастянутом состоянии
        double LenSystem;//длина всей системы
        MathRepository mathRepository;
        public Service(int N) {
            
            InitBallStates(N);
        }
        void InitBallStates(int countBalls)
        {
            this.N = countBalls + 2;//+2 как будто есть фиксированные шары по бокам
            Ball_States = new double[N, 2];
            //расчитывание длины всей системы
            LenSystem = countBalls * 2 * R + (countBalls + 1) * lenCoil;
            for (int i = 0; i < N; i++)
            {
                Ball_States[i, 0] = LenSystem / (N - 1) * i;
                Ball_States[i, 1] = 0;
              
            }
        }
        //расчеты
        //как действуем, пересчитали все координаты -> обновили шары на рисунке

        //обновление состояний шаров
        //ее будет вызывать таймер
        public void UpDateStatesBalls(double step_t)
        {
            mathRepository.RK4(Ball_States, step_t);
            current_time += step_t;
            
        }
        //отрисовка графика на форме
        public void DrawingPlot_i_Ball(ScottPlot.WinForms.FormsPlot formsPlot, ScottPlot.Plottables.DataLogger logger, ScottPlot.Plottables.DataLogger logger2,int numberBall)
        {
            logger.Add(current_time,Ball_States[numberBall, 0]);
            logger2.Add(current_time, LenSystem / (N - 1) * numberBall);
            formsPlot.Refresh();
        }
        //для сброса системы
        public void ResetBallStates(int countBalls)
        {
            InitBallStates(countBalls);
            current_time = 0;
        }

        //функция инициализации физ системы
        //говорим окончательные параметры репозиторию, который отвечает за все расчеты
        public void Start(double m, double k0, double mu,double gamma, double alpha,int numberK_x)
        {
            Func<double, double, double> k;
            /*k = delegate (double x, double x0)
            {
                return k0;
            };*/
            if (numberK_x == 0)
            {
                k = delegate (double x, double x0)
                {
                    return k0 + alpha * Math.Abs(x - x0);
                };
            }
            else
            {
                k = delegate (double x, double x0)
                {
                    return k0 + alpha * (x - x0) * (x - x0);
                };
            }
            mathRepository = new MathRepository(m, mu, gamma, R, lenCoil, k);
            current_time = 0;
        }

        //отклонение шарика от положения равновесия
        public void DeflectionBall(int numberBall, double step)
        {
            Ball_States[numberBall, 0] = LenSystem / (N - 1) * numberBall + step;
        }

        // Рисовашка

        //преобразование мировых координат в экранные
        private double TransformWorld2Px(double x_world)
        {
            int countBalls = N - 2;
            int countCoils = countBalls + 1;
            return x_world * (countBalls * DrawRepository.radiusBall * 2 + countCoils * DrawRepository.lenCoil) /
                (countBalls * 2 * R + (countBalls + 1) * lenCoil);
        }

        private int CulculationLenSystem(int countBalls)
        {
            int countCoils = countBalls + 1;
            return countBalls*DrawRepository.radiusBall*2+countCoils*DrawRepository.lenCoil;  
        }
        public Bitmap DrawImg(int widthControll, int heigthControll)
        {
            //вычисляем длину физ системы
            int LenSystem = CulculationLenSystem(N-2);//два крайних шара не учитываем
            //координата x, куда переносим систему координат
            int x_for_coord;
            float scale = 1.0f;
            if (LenSystem > (int)(widthControll * 0.97))
            {
                x_for_coord = (int)(widthControll * 0.015);
                scale =(widthControll * 0.97f) / LenSystem;
            }
            else
            {
                //если меньше, то нужно правильно подвинуть систему координат
                // чтобы физ система была по середине экрана
                x_for_coord = (int)(widthControll - LenSystem) / 2;
            }

            Bitmap map = new Bitmap(widthControll, heigthControll,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics buffer_g = Graphics.FromImage(map);
            buffer_g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // 1. перенос системы координат координат - при масштабировании дожлен поехать
            DrawRepository.СustomizationСoordinateSystem(buffer_g, x_for_coord, (int)(heigthControll * 0.9));


            // 2. если картинка не помещается, то применится масштабирование 
            buffer_g.ScaleTransform(scale, scale);

            // 3. отрисовать стенки 
            //(int)(heigthControll * 0.8/scale) - чтобы при уменьшении стенки не укорачивались 
            // 4.0f/scale - чтобы при масштабировании толщина стенок не изменялась 
            using (Pen pen = new Pen(Color.Red, 4.0f ))
            {
                if (scale < 1.0f)
                    pen.Width = 4.0f / scale;//чтобы при уменьшении стенки не становились тоньше
                DrawRepository.DrawingWalls(buffer_g, pen, LenSystem, (int)(heigthControll * 0.8 / scale));
            }

            // 4. цикл отрисовки шариков
            using (Pen penForBall = new Pen(Color.Purple, 2.0f))
            using (Brush brushForBall = new SolidBrush(Color.Blue))
            {
                for (int i = 1; i < Ball_States.GetUpperBound(0); i++)
                {
                    DrawRepository.DrawingBall(buffer_g, penForBall, brushForBall, TransformWorld2Px(Ball_States[i,0]));
                }
            }

            // 4. цикл отрисовки пружин
            using (Pen penForCoil = new Pen(Color.Green, 3.0f))
            {
                for (int i = 0; i < Ball_States.GetUpperBound(0); i++)
                {
                    if (i == 0)
                        DrawRepository.DrawingCoil(buffer_g, penForCoil, TransformWorld2Px(Ball_States[i, 0]) - DrawRepository.radiusBall, TransformWorld2Px(Ball_States[i + 1, 0]));
                    else if (i + 1 == Ball_States.GetUpperBound(0))
                        DrawRepository.DrawingCoil(buffer_g, penForCoil, TransformWorld2Px(Ball_States[i, 0]), TransformWorld2Px(Ball_States[i + 1, 0]) + DrawRepository.radiusBall);
                    else
                        DrawRepository.DrawingCoil(buffer_g, penForCoil, TransformWorld2Px(Ball_States[i, 0]), TransformWorld2Px(Ball_States[i + 1, 0]));
                }
            }
            buffer_g.Dispose();
            return map;
        }

    }

}
