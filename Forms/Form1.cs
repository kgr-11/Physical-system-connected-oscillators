using System.Windows.Forms;

namespace ChainConnectedOscillators
{
    public partial class Form1 : Form
    {
        int N;//кол-во шаров в системе без учета крайних
        Service service;
        private ScottPlot.Plottables.DataLogger logger;//для точек графика
        private ScottPlot.Plottables.DataLogger logger2;//для точек положения равновесия
        public Form1()
        {
            InitializeComponent();
            N = 1;
            service = new Service(N);
            numericUpDown_N.Value = N;
            numericUpDown_n_i_forStart.Maximum = numericUpDown_N.Value;
            numericUpDown_n_i_for_graphic.Maximum = numericUpDown_N.Value;
            //задаем один раз возможный диапазон отклонения от положения равновесия
            numericUpDown_startPosition_n_i.DecimalPlaces = 2;//значение с точность до 2 знаков
            numericUpDown_startPosition_n_i.Maximum = (decimal)Service.lenCoil / 2;
            numericUpDown_startPosition_n_i.Minimum = -(decimal)Service.lenCoil / 2;
            numericUpDown_startPosition_n_i.Increment = (numericUpDown_startPosition_n_i.Maximum - numericUpDown_startPosition_n_i.Minimum) / 10;

            //установка значений по умолчанию
            textBox_m.Text = Convert.ToString(0.1);
            textBox_k0.Text = Convert.ToString(100);
            textBox_alpha.Text = Convert.ToString(0);
            textBox_gamma.Text = Convert.ToString(0);
            textBox_mu.Text = Convert.ToString(0);
            comboBox_k.SelectedIndex = 0;

            //кнопки
            button_stop.Enabled = false;
            button_reset.Enabled = false;

            // Создаем DataLogger и добавляем его на график
            logger = formsPlot1_x_i.Plot.Add.DataLogger();
            logger2= formsPlot1_x_i.Plot.Add.DataLogger();
        }


        private void pictureBox_system_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            //двойная буферизация 
            //здесь вызов сервиса и его функции, которая рисует
            Bitmap map = service.DrawImg(pictureBox_system.Width, pictureBox_system.Height);
            e.Graphics.DrawImage(map, 0, 0);
            map.Dispose();
        }

        //изменение кол-ва шаров в системе
        private void numericUpDown_N_ValueChanged(object sender, EventArgs e)
        {
            N = Convert.ToInt32(numericUpDown_N.Value);
            numericUpDown_n_i_forStart.Maximum = N;
            numericUpDown_n_i_for_graphic.Maximum = numericUpDown_N.Value;
            numericUpDown_n_i_forStart_ValueChanged(null,null);
            //обновление системы
            service.ResetBallStates(N);
            pictureBox_system.Invalidate();
        }


        void BlockComponentForStart()
        {
            //разблокировка двух кнопок
            button_reset.Enabled = true;
            button_stop.Enabled = true;
            //блокировка всех компонентов
            button_start.Enabled = false;
            numericUpDown_N.Enabled = false;
            numericUpDown_n_i_forStart.Enabled = false;
            numericUpDown_startPosition_n_i.Enabled = false;
            textBox_alpha.Enabled = false;
            textBox_gamma.Enabled = false;
            textBox_m.Enabled = false;
            textBox_k0.Enabled = false;
            textBox_mu.Enabled = false;
            comboBox_k.Enabled = false;
        }
        void UnBlockComponentForReset()
        {
            //блокировка двух кнопок
            button_reset.Enabled = false;
            button_stop.Enabled = false;
            //разблокировка всех компонентов
            button_start.Enabled = true;
            numericUpDown_N.Enabled = true;
            numericUpDown_n_i_forStart.Enabled = true;
            numericUpDown_startPosition_n_i.Enabled = true;
            textBox_alpha.Enabled = true;
            textBox_gamma.Enabled = true;
            textBox_m.Enabled = true;
            textBox_k0.Enabled = true;
            textBox_mu.Enabled = true;
            comboBox_k.Enabled = true;
        }

        //кнопка старта
        private void button_start_Click(object sender, EventArgs e)
        {
            numericUpDown_N.Enabled = false;//блокировка изменения кол-во шаров
            //считывание входных данных
            double m = Convert.ToDouble(textBox_m.Text);
            double k0 = Convert.ToDouble(textBox_k0.Text);
            double mu = Convert.ToDouble(textBox_mu.Text);
            double gamma = Convert.ToDouble(textBox_gamma.Text);
            double alpha = Convert.ToDouble(textBox_alpha.Text);
            int numberK_x = comboBox_k.SelectedIndex;
            //запуск сервиса с нужными данными
            service.Start(m, k0, mu, gamma, alpha, numberK_x);
            //блокировка элементов управления
            BlockComponentForStart();
            //настройка таймера
            timer1.Interval = 16;//16мс
            //запуск таймера
            timer1.Start();
        }

        //тик-так
        private void timer1_Tick(object sender, EventArgs e)
        {
            //выбор шага по времени
            double w = 2 * (Math.Sqrt(Convert.ToDouble(textBox_k0.Text) / Convert.ToDouble(textBox_m.Text)));
            double step_t = 0.1 / w;
            step_t *= 10;
            //обновление данных
            service.UpDateStatesBalls(step_t);
            //перерисовка
            service.DrawingPlot_i_Ball(formsPlot1_x_i, logger,logger2, (int)numericUpDown_n_i_for_graphic.Value);
            pictureBox_system.Invalidate();
        }

        //обработчик отклонения от положения равновесия
        private void numericUpDown_startPosition_n_i_ValueChanged(object sender, EventArgs e)
        {
            //какой шарик отклоняем
            int i = (int)numericUpDown_n_i_forStart.Value;
            //на сколько от положения равновесия отклоняем i шарик
            double step = Convert.ToDouble(numericUpDown_startPosition_n_i.Value);
            //устанавливаем значение отклонения для i шарика
            service.DeflectionBall(i, step);
            //помечаем, что надо перерисовать 
            pictureBox_system.Invalidate();

        }

        //изменение номера отклоняемого шарика-> сброс отклонения шарика до этого
        private void numericUpDown_n_i_forStart_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown_startPosition_n_i.Value = (decimal)0.00;
            //возвращаем, все в исходное состояние
            if (numericUpDown_n_i_forStart.Value > 1)
                service.DeflectionBall((int)numericUpDown_n_i_forStart.Value - 1, 0);
            if (numericUpDown_n_i_forStart.Value < numericUpDown_n_i_forStart.Maximum)
                service.DeflectionBall((int)numericUpDown_n_i_forStart.Value + 1, 0);
            //помечаем, что надо перерисовать 
            pictureBox_system.Invalidate();
        }

        bool IsPause = false;
        private void button_stop_Click(object sender, EventArgs e)
        {
            if (!IsPause)
            {
                timer1.Stop();
                IsPause = true;
            }
            else
            {
                timer1.Start();
                IsPause = false;
            }
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            IsPause = false;
            timer1.Stop();
            numericUpDown_startPosition_n_i.Value = (decimal)0.00;
            numericUpDown_n_i_forStart.Value = 1;
            service.ResetBallStates(N);
            UnBlockComponentForReset();
            logger.Data.Coordinates.Clear();
            logger2.Data.Coordinates.Clear();
            numericUpDown_n_i_for_graphic.Value = 1;
            formsPlot1_x_i.Refresh();
            pictureBox_system.Invalidate();
        }

        private void numericUpDown_n_i_for_graphic_ValueChanged(object sender, EventArgs e)
        {
            logger.Data.Coordinates.Clear();
            logger2.Data.Coordinates.Clear();
        }
    }

}
