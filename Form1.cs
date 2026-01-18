namespace Clocl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public int hours;
        public int secondsOfBreak;
        public bool breakTime = false;
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Enter the number of hours between 1 and 24 to set an alarm that will remind you to take a break from playing games. When the alarm goes off, you will have the option to start your break immediately or delay it by 15 minutes. During the break, you will be reminded that the break is ongoing. After 5 minutes, you will be notified that the break is over and you can resume playing.");

        }
        private void button2_Click(object sender, EventArgs e)
        {

            bool isValid = int.TryParse(textBox1.Text, out hours);
            if (isValid && hours >= 1 && hours <= 24)
            {
                MessageBox.Show($"Alarm set for every {hours} hour(s).");
                timer1.Interval = hours * 3600000; // Convert hours to milliseconds
                timer1.Start();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please enter a valid number between 1 and 24.");
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            var bouton = MessageBox.Show($"you have been playing for {hours} hour(s). take a break!", "Take a BREAK !", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            hours++;
            if (bouton == DialogResult.OK)
            {
                BreakTime();
            }
            if (bouton == DialogResult.Cancel)
            {
                MessageBox.Show("The break will start in 15 minutes");
                timer4.Start();  //appeler le timer de 15 minutes
            }
        }
        private void BreakTime()
        {
            breakTime = true;
            timer4.Stop();
            timer3.Start();
            while (breakTime == true)
            {
                MessageBox.Show($"The break as not ended !", "Break time !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            
            MessageBox.Show("The break is starting now!");
            BreakTime();
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
                breakTime = false;
                secondsOfBreak = 0;
                timer3.Stop();
                MessageBox.Show("Break time is over! You can continue playing.");
        }
        private void textBox1_Validated(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        

        

        

        
    }
}
