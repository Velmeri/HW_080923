namespace HW_080923
{
	public partial class Form1 : Form
	{

		public Form1()
		{
			InitializeComponent();

			System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
			timer.Interval = 1000;
			timer.Tick += Timer_Tick;
			timer.Start();
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			pictureBox1.Invalidate();
		}

		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			int centerX = pictureBox1.Width / 2;
			int centerY = pictureBox1.Height / 2;
			int clockRadius = Math.Min(centerX, centerY) - 10;

			// Узнаем текущее время
			DateTime currentTime = DateTime.Now;
			int second = currentTime.Second;
			int minute = currentTime.Minute;
			int hour = currentTime.Hour % 12;

			// Циферблат
			g.FillEllipse(Brushes.White, centerX - clockRadius, centerY - clockRadius, 2 * clockRadius, 2 * clockRadius);
			g.DrawEllipse(Pens.Black, centerX - clockRadius, centerY - clockRadius, 2 * clockRadius, 2 * clockRadius);

			// Часовая стрелка
			int hourAngle = (hour * 360 / 12) - 90;
			int hourHandLength = clockRadius / 2;
			int hourHandX = centerX + (int)(hourHandLength * Math.Cos(hourAngle * Math.PI / 180));
			int hourHandY = centerY + (int)(hourHandLength * Math.Sin(hourAngle * Math.PI / 180));
			g.DrawLine(Pens.Black, centerX, centerY, hourHandX, hourHandY);

			// Минутная стрелка
			int minuteAngle = (minute * 360 / 60) - 90;
			int minuteHandLength = clockRadius * 3 / 4;
			int minuteHandX = centerX + (int)(minuteHandLength * Math.Cos(minuteAngle * Math.PI / 180));
			int minuteHandY = centerY + (int)(minuteHandLength * Math.Sin(minuteAngle * Math.PI / 180));
			g.DrawLine(Pens.Black, centerX, centerY, minuteHandX, minuteHandY);
			
			// Секундеая стрелка
			int secondAngle = (second * 360 / 60) - 90;
			int secondHandLength = clockRadius * 3 / 4;
			int secondHandX = centerX + (int)(secondHandLength * Math.Cos(secondAngle * Math.PI / 180));
			int secondHandY = centerY + (int)(secondHandLength * Math.Sin(secondAngle * Math.PI / 180));
			g.DrawLine(Pens.Red, centerX, centerY, secondHandX, secondHandY);
		}
	}
}