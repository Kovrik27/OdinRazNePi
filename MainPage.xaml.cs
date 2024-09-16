namespace OdinRazNePi
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        bool IsOperation;
        double x = 0;
        char operation = ' ';
        int count = 0;

        public void History(char operation)
        {
            if (!IsOperation)
            {
                Istoria.Text += x.ToString() + operation;
            }
            else
            {
                Istoria.Text += Istoria.Text.Remove(Istoria.Text.Length - 1) + operation;
            }
        }

        private void ClickCifri(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {               
                Display.Text += button.Text;
            } 
            
            IsOperation = false;
        }

       

        private void ClearEnd(object sender, EventArgs e)
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

            if (sender != null)
            {
                Istoria.Text = null;
                count = 0;
            }
            IsOperation = false;

            x = result; 
            
        }

        private void GoToOperation(object sender, EventArgs e)
        {
            var button = sender as Button;
            char operation = button.Text.ToString()[0];


            if (IsOperation != true)
            {
                if (count < 1)
                    double.TryParse(Display.Text, out x);
                count++;
               History(operation);
                if (count > 1) 
                {
                    Operation(null,null);
                }

                Display.Text = null;
                IsOperation = true;

            }
            
            this.operation = operation;

        }

        private void PilusMinus(object sender, EventArgs e)
        {
            double result = 0;
            double.TryParse(Display.Text, out x);
            result = x * -1;
            Display.Text = result.ToString();
        }

        private void Dot(object sender, EventArgs e)
        {
            if (!Display.Text.Contains("."))
                Display.Text += ".";
        }

        private void Percent(object sender, EventArgs e)
        {
            double percent1 = x / 100;
            double.TryParse(Display.Text, out double y);
            Display.Text = (y * percent1).ToString();

        }

        private void SquareRoot(object sender, EventArgs e)
        {
            double.TryParse(Display.Text, out double y);
            Display.Text = (Math.Sqrt(y)).ToString();
        }

        private void OneToX(object sender, EventArgs e)
        {
            double.TryParse(Display.Text, out double y);
            Display.Text = (1/y).ToString();
        }

        private void Backspace(object sender, EventArgs e)
        {
          if (Display.Text.Length > 0)
            {
                Display.Text = Display.Text.Remove(Display.Text.Length - 1);
            }
        }

        private void ClearFull(object sender, EventArgs e)
        {
            operation = ' ';
            x = 0;
            Display.Text = null;
            Istoria.Text = null;
            count = 0;
           
        }
    }
}
