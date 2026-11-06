using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainConnectedOscillators.Repositories.Drawing
{
    //репозиторий отрисовывает все элементы
    public static class DrawRepository
    {
        // изначальные размеры
        public const int radiusBall = 15;//радиус шарика
        public const int lenCoil = 60;//длина пружины
        public const int countRount = 10;//кол-во витков у пружинки

        //перенос и поворот системы координат
        public static void СustomizationСoordinateSystem(Graphics graphic, int newStartX, int newStartY)
        { 
            //перенос системы координат в новые координаты
            graphic.TranslateTransform(newStartX, newStartY);
            //поворот оси y в противоположную сторону
            graphic.ScaleTransform(1.0f, -1.0f);
        }

        //рисование стенок
        public static void DrawingWalls(Graphics graphic, Pen penForBorder, int width, int heigth)
        {
            SystemElements.DrawingHouseSystem(graphic, penForBorder, width, heigth);
        }

        
        //рисование шарика
        public static void DrawingBall(Graphics graphic, Pen penForBorder, Brush brush, double x_coord)
        {
            SystemElements.DrawingBall(graphic, penForBorder, brush, x_coord,radiusBall, radiusBall);
        }

        //рисование пружинок
        public static void DrawingCoil(Graphics graphic, Pen pen, double x_ball_left, double x_ball_right)
        {
            //считаем координаты шарика 
            double start_x = x_ball_left + radiusBall;
            double start_y = radiusBall;
            double finish_x = x_ball_right - radiusBall;
            double finish_y = radiusBall;   
            SystemElements.DrawingCoil(graphic, pen, start_x,start_y,finish_x, finish_y, countRount);
        }

    }
}
