using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ChainConnectedOscillators.Repositories.Mathematic
{
    public class MathRepository
    {
        //паметры системы
        double m;
        double mu;
        double gamma;
        double g = 9.8;
        double R;
        double len_coil;
        Forces forces;
        public MathRepository(double m, double mu, double gamma, double R,double len_coil, Func<double,double, double> k)
        { 
            this.m= m;
            this.mu= mu;
            this.gamma= gamma;
            this.R= R;
            this.len_coil = len_coil;
            forces = new Forces(k);
        }

        //ускорение - второй закон ньютона - именно проекция ускорения 
        double a_x(double x_curr, double Vx_curr, double x_last, double x_next, double step_t)
        {
            double x0_right = x_next - 2*R - len_coil;
            double x0_left = x_last + 2*R + len_coil;
            //правая сила трения - действует в ту сторону, куда направлена скорость
            double F_hook_right = forces.F_hook(x_curr, x0_right);
            //левая сила трения -  действует в ту сторону, куда направлена скорость
            double F_hook_left = forces.F_hook(x_curr, x0_left);
            //сила сухого трения - всегда против скорости
            double F_friction=forces.F_friction(mu, m,g);
            //сила вязкого трения - против скорости
            double F_Air_friction = forces.F_Air_friction(Math.Abs(Vx_curr), gamma);

            double ax = F_hook_right + F_hook_left;
            double dv_max = mu * g * step_t;
            if (Math.Abs(Vx_curr) < dv_max)//вязкого трения нет 
            {
                //шар почти покоится -> сила трения покоя
                if (Math.Abs(F_hook_left + F_hook_right) <= F_friction)
                {
                    ax = 0;
                }
                else
                {
                    ax = F_hook_left + F_hook_right - Math.Sign(F_hook_left + F_hook_right) * F_friction;
                }
            }
            else if (Vx_curr > 0)
            {
                ax = F_hook_right + F_hook_left - F_friction - F_Air_friction;
            }
            else
            {
                ax = F_hook_right + F_hook_left + F_friction + F_Air_friction;
            }
            ax /= m;
            return ax;
        }

        //метод РК4 для системы для N взаимодействующих тел
        //уравнения тел второго порядка
        public void RK4(double[,] Y, double step_t)
        {
            //вектора шагов по скорости
            double[] k1 = new double[Y.GetUpperBound(0)+1];
            double[] k2 = new double[Y.GetUpperBound(0) + 1];
            double[] k3 = new double[Y.GetUpperBound(0) + 1];
            double[] k4 = new double[Y.GetUpperBound(0) + 1];
            //  k1 - по краем неподвижные шары 
            for (int i = 1; i < k1.Length - 1; i++)
            {
                k1[i] = a_x(Y[i, 0],  //  текущая координата
                    Y[i, 1],  //  текущая скорость
                    Y[i - 1, 0],  //  коорината прошлого шара
                    Y[i + 1, 0],step_t)  //  координата следующего шара
                    *step_t;
            }
            //  k2 - по краем неподвижные шары 
            for (int i = 1; i < k2.Length - 1; i++)
            {
                k2[i] = a_x(Y[i, 0] + Y[i, 1] * step_t / 2,  //  текущая координата с поправкой
                    Y[i, 1] + k1[i] / 2,  //  текущая скорость с поправкой
                    Y[i-1, 0] + Y[i-1, 1] * step_t / 2,  //координата прошлого шара с поправкой
                    Y[i+1, 0] + Y[i+1, 1] * step_t / 2,step_t)  //координата следующего шара с поправкой
                    *step_t;
            }
            //  k3 - по краем неподвижные шары 
            for (int i = 1; i < k3.Length - 1; i++)
            {
                k3[i] = a_x(Y[i, 0] + Y[i, 1] * step_t / 2 + k2[i] / 4*step_t,//  текущая координата с поправкой
                    Y[i, 1] + k2[i]/2,  //  текущая скорость с поправкой
                    Y[i-1, 0] + Y[i-1, 1] * step_t / 2 + k2[i-1] / 4 * step_t,  //координата прошлого шара с поправкой
                    Y[i+1, 0] + Y[i+1, 1] * step_t / 2 + k2[i+1] / 4 * step_t,step_t)  //координата следующего шара с поправкой
                    * step_t;
            }
            //  k4- по краем неподвижные шары 
            for (int i = 1; i < k4.Length - 1; i++)
            {
                k4[i] = a_x(Y[i, 0] + Y[i, 1] * step_t + k3[i] * step_t,  //  текущая координата с поправкой
                    Y[i, 1] + k3[i],  //  текущая скорость с поправкой
                    Y[i-1, 0] + Y[i-1, 1] * step_t + k3[i-1]  * step_t,  //координата прошлого шара с поправкой
                    Y[i+1, 0] + Y[i+1, 1] * step_t + k3[i+1]  * step_t,step_t)  //координата следующего шара с поправкой
                    * step_t;
            }
            //  обновляем состояние системы - по краем неподвижные шары 
            for (int i = 1; i < Y.GetUpperBound(0); i++)
            {
                //  обновление координаты i-шара
                Y[i, 0] = Y[i, 0]+Y[i,1]*step_t+ step_t / 6 * (k1[i] +k2[i] +k3[i])*step_t;
                //  обновление скорости i -шара
                Y[i, 1] = Y[i, 1]+ step_t / 6 * (k1[i] + 2 * k2[i] + 2 * k3[i] + k4[i]);
            }
        }

    }
}
