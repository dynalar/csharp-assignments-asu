namespace NumberGuesserForm
{
    public partial class Form1 : Form
    {
        // new instance of number guess service
        public NumberGuessServiceRef.NumberGuessClient numberGuessService = new NumberGuessServiceRef.NumberGuessClient();
        public int secretNumber = 0;
        public int attemptCount = 0;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //
        }

        /*
         * This code runs every time the Play Game button is clicked.
         * It increases the attempts counter, sets the attempts label, and 
         * calls the CheckNumber service.
         * 
         * CheckNumber service returns a message on whether the guess was good or not.
         */
        private void Play_Click(object sender, EventArgs e)
        {
            int guess = int.Parse(Guess.Text);

            // increase attempts every time play button is clicked
            attemptCount++;
            this.SetAttemptsLabel(attemptCount);

            string guessMessage = numberGuessService.CheckNumber(guess, this.secretNumber);

            this.SetNumberResultLabel(guessMessage);
        }

        /*
         * This method runs when we generate a secret number based on the upper and lower bounds 
         * that the user has chosen. 
         * 
         * The SecretNumber method in the NumberGuessService is called to generate the Secret Number.
         */
        private void GenerateSecretNumber_Click(object sender, EventArgs e)
        {
            int lowerLimit = int.Parse(LowerLimit.Text);
            int upperLimit = int.Parse(UpperLimit.Text);

            int secretNumber = numberGuessService.SecretNumber(lowerLimit, upperLimit);

            this.SetSecretNumber(secretNumber);
        }

        /*
         * This method sets the label to the amount of attempts the user has clicked.
         */
        public void SetAttemptsLabel(int attemptCount)
        {

            this.attempts.Text = attemptCount.ToString();
            this.attempts.Refresh();
        }

        /*
         * This method sets the label to the message that is received from the CheckNumber method from
         * the NumberGuess service.
         */
        public void SetNumberResultLabel(string message)
        {
            this.numberResult.Text = message;
            this.numberResult.Refresh();
        }

        /*
         * Setter for the secret number.
         */
        public void SetSecretNumber(int secretNumber)
        {
            this.secretNumber = secretNumber;
        }

        /*
         * validates that only ints can be entered into input fields.
         */
        private void ValidateIntegersOnly(object sender, KeyPressEventArgs e)
        {
            // allow user to enter integers only, NO TEXT!
            if ((!char.IsControl(e.KeyChar) && (e.KeyChar != '.') && !char.IsDigit(e.KeyChar))
                || ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)))
            {
                e.Handled = true;
            }
        }

        /* 
         * enables/disables the secret number, cannot run unless there is input present in both fields
         * 
         * lower and upper bounds must be valid as well.
         */
        private void EnableSecretNumberButton(object sender, KeyEventArgs e)
        {
            bool fieldIsPopulated = !String.IsNullOrEmpty(this.LowerLimit.Text) && !String.IsNullOrEmpty(this.UpperLimit.Text);

            if (fieldIsPopulated)
            {
                int lowerLimit = int.Parse(LowerLimit.Text);
                int upperLimit = int.Parse(UpperLimit.Text);

                bool validBounds = lowerLimit < upperLimit;

                if(validBounds) this.secretNumGeneratorButton.Enabled = true;

            } else
            {
                this.secretNumGeneratorButton.Enabled = false;
            }
        }
    }
}