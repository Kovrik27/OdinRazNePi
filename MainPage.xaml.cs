namespace OdinRazNePi
{
   public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        double x = 0;
        char operation = ' ';

        private void ClickCifri(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {               
                Display.Text += button.Text;
            } 
            
        }

       

        private void ClearFull(object sender, EventArgs e)
        {      
            Display.Text = null;
        }



        private void Operation(object sender, EventArgs e)
        {
            double result = 0;
			double.TryParse(Display.Text, out double y);
			switch (operation)
			{
				case '+': result = x + y; break;
				case '-': result = x - y; break;
				case '*': result = x * y; break;
				case '/': result = x / y; break;
			}
			Display.Text = result.ToString();
        }

        private void GoToOperation(object sender, EventArgs e)
        {
            var button = sender as Button;
            operation = button.Text.ToString()[0];
            double.TryParse(Display.Text, out x);
            Display.Text = null;
        }

        private void PilusMinus(object sender, EventArgs e)
        {
            double result = 0;
            double.TryParse(Display.Text, out x);
            result = x * -1;
            Display.Text = result.ToString();
        }

        private void Comma(object sender, EventArgs e)
        {
            if (!Display.Text.Contains(","))
                Display.Text += ",";
        }

        private void Percent(object sender, EventArgs e)
        {
            double result = 0;
            double.TryParse(Display.Text, out x);
            
        }
    }
}
