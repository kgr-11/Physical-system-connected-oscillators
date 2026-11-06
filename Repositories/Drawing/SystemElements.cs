using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainConnectedOscillators.Repositories.Drawing
{
    public static class SystemElements
    {
        //класс рисует элементы физ системы

        // эл-ты физ системы:
        // 1. Шарик
        // 2. Пружинка+точка крепления
        // 3. повехность+штрихи у поверхности


        //  рисование шарика
        public static void DrawingBall(Graphics graphic,Pen pen,Brush brush, double center_x,double center_y, int radius)
        {
            //квадрат отрисовывается в с.к., где ось Oy вверх
            //  заливка шарик
            graphic.FillEllipse(brush, (float)center_x - radius, (float)center_y - radius, 2 * radius, 2 * radius);
            //  отрисовка границы шарика
            graphic.DrawEllipse(pen, (float)center_x - radius, (float)center_y - radius, 2 * radius, 2 * radius);
            //  отрисовка границы шарика 2 * radius, 2 * radius);
        }

        //  рисование пружины + точка крепления пружины
        //  countRount - число витков катушки 
        public static void DrawingCoil(Graphics graphic, Pen pen, double start_x,double start_y,double finish_x, double finish_y,int countRount)
        {
            //зная старт, финиш, кол-во витков - можно определить шаг, с которым рисовать витки
            // первый половинный виток и последний половинный виток рисуются с полушагом
            float step_x = (float)Math.Abs(finish_x - start_x) / countRount;
            float step_y = (float)start_y*2;
            //координты старта и финиша линии
            float x0, y0;
            float x1, y1;

            // рисуем первый половинный виток
            x0 = (float)start_x;
            y0 = (float)start_y;
            x1=x0 + step_x/2;
            y1 = y0 - step_y/2;//стартовый половинный виток всегда начинает отрисовываться сверху вниз

            graphic.DrawLine(pen, x0, y0, x1, y1);

            //рисуем серединные витки
            // -1, т.к один полный виток это начальный и конечный полвинный виток
            for (int i = 0; i < countRount - 1; i++)
            {
                // расчет координат витка
                x0 = x1;
                y0 = y1;
                x1 = x0 + step_x;
                if (y0 > (float)start_y)//виток сейчас должен рисоватьсься сверху вниз
                    y1 = y0 - step_y;
                else // иначе снизу вверх
                    y1 = y0 + step_y;

                // отрисовка самого витка
                graphic.DrawLine(pen, x0, y0, x1, y1);
            }

            //рисуем последний половинный виток

            //расчет координат последнего витка
            x0 = x1;
            y0 = y1;
            x1 = x0 + step_x/2;
            if (y0 > (float)start_y)//виток сейчас должен рисоватьсься сверху вниз
                y1 = y0 - step_y/2;
            else // иначе снизу вверх
                y1 = y0 + step_y/2;

            // отрисовка самого витка
            graphic.DrawLine(pen, x0, y0, x1, y1);

            //рисуем точки крепление пружинки

            //левая точка крепления
            graphic.FillEllipse(Brushes.Silver, (float)start_x - 2, (float)start_y - 2, 5, 5);

            //правая точка крепления
            graphic.FillEllipse(Brushes.Silver, (float)finish_x - 2, (float)finish_y - 2, 5, 5);
        }

        //рисование поверхности, где находится вся система
        public static void DrawingHouseSystem(Graphics graphic, Pen penForBorder, int width, int heigth)
        {
            // рисование трех стенок 

            //рисование левой стенки
            graphic.DrawLine(penForBorder, 0, -5, 0, heigth);//высота стенок 80% высоты контролла

            //рисование правой стенки
            graphic.DrawLine(penForBorder, width, -5, width, heigth);//высота стенок 80% высоты контролла

            // рисование пола

            graphic.DrawLine(penForBorder,0, -3, width, -3);

            //рисование штрихов

            //пока без этого - из-за этого может упасть производительность
        }
    }
}
