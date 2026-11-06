using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainConnectedOscillators.Repositories.Mathematic
{
    public class Forces
    {
        //функция кф-та жесткости
        Func<double, double,double> k;
        public Forces(Func<double, double, double> k)
        { 
            this.k = k;
        }
        //сила упругости
        public double F_hook(double x, double x0)
        {
            //x, который передаем, это x центра шара
            // в силе упругости нужна координата x пружины, она вычисляется с помощью x0
            return k(x,x0) * (x0-x);
        }
        //сила трения скольжения
        public double F_friction(double mu, double m, double g)
        {
            return mu * m * g;
        }

        //сила вязкого трения 
        public double F_Air_friction(double V, double gamma)
        {
            return gamma *V;
        }
    }
}