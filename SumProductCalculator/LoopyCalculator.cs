using System;
using System.Windows;
using System.Windows.Controls;

namespace SummationProductCalculator
{
    class LoopyCalculator
    {
        public MainWindow window;
        string sumOrProduct;
        double a, b, c, k, m;
        Button clearButton, randomButton, equalsButton;
        TextBlock outBlock, infoBlock;
        TextBox aBox, bBox, cBox, kBox, mBox;

        // Set textboxes, textblocks, and buttons to either sum or product
        // Note this can't be achieved as a constructor because 
            // classes MainWindow and Calculator are dependent on each other
        public void Init(string whichCalculator)
        {
            if (whichCalculator == "sum")
            {
                sumOrProduct = "sum";
                clearButton = window.sumClear;
                randomButton = window.sumRandom;
                equalsButton = window.sumEquals;
                outBlock = window.sumOut;
                infoBlock = window.sumInfo;
                aBox = window.sumBoxA;
                bBox = window.sumBoxB;
                cBox = window.sumBoxC;
                kBox = window.sumBoxK;
                mBox = window.sumBoxM;
            }
            else
            {
                sumOrProduct = "product";
                clearButton = window.productClear;
                randomButton = window.productRandom;
                equalsButton = window.productEquals;
                outBlock = window.productOut;
                infoBlock = window.productInfo;
                aBox = window.productBoxA;
                bBox = window.productBoxB;
                cBox = window.productBoxC;
                kBox = window.productBoxK;
                mBox = window.productBoxM;
            }
        }

        // Randomise all textboxes with a number from 0-9
        public void Random()
        {
            Random random = new Random();
            a = random.Next(0, 10);
            b = random.Next(0, 10);
            c = random.Next(0, 10);
            k = random.Next(0, 10);
            m = random.Next(0, 10);
            
            // To ensure k and m are valid
            while (k > m)
            {
                k = random.Next(0, 10);
                m = random.Next(0, 10);
            }
                
            UpdateTextboxes();
        }

        // Reset doubles to zero and clears output text, also calls UpdateTextboxes if bool is true
        public void ResetAndClear(bool updateTextboxes)               
        {
            a = b = c = k = m = 0;
            outBlock.Text = "";
            infoBlock.Text = "";
            
            if (updateTextboxes)
                UpdateTextboxes();
        }

        // Update textboxes to current values
        private void UpdateTextboxes()
        {
            aBox.Text = a.ToString();
            bBox.Text = b.ToString();
            cBox.Text = c.ToString();
            kBox.Text = k.ToString();
            mBox.Text = m.ToString();
        }

        // Perform calculation and display result
        public void Calculate()
        {
            string infoText = "(";
            double resultThisLoop = 0;
            double result;
            
            // Actual calculations
            if (sumOrProduct == "sum")
            {
                result = 0;
                while (k <= m)
                {
                    resultThisLoop = ((Math.Pow(k, b)) * a) + c;
                    infoText += resultThisLoop.ToString() + " + ";
                    result += resultThisLoop;
                    k++;
                }
            }
            else
            {
                result = 1;
                while (k <= m)
                {
                    resultThisLoop = ((Math.Pow(k, b)) * a) + c;
                    infoText += resultThisLoop.ToString() + " * ";
                    result *= resultThisLoop;
                    k++;
                }
            }

            // Remove final operator and add closing bracket
            infoText = infoText.Substring(0, (infoText.Length - 3)) + ")";
   
            // Populate textblocks with results
            outBlock.Text = result.ToString();               
            infoBlock.Text = infoText;
        }

        // Check input is valid, if yes call Calculate()
        public void CheckInput()
        {
            // TryParse each textbox and update doubles,
                // Use isValid to check for errors
            int isValid = 0;
            if (!Double.TryParse(aBox.Text, out a))
                isValid++;
            if (!Double.TryParse(bBox.Text, out b))
                isValid++;
            if (!Double.TryParse(cBox.Text, out c))
                isValid++;
            if (!Double.TryParse(kBox.Text, out k))
                isValid++;
            if (!Double.TryParse(mBox.Text, out m))
                isValid++;
            if (k > m)
                isValid++;

            if (isValid != 0)
            {
                ResetAndClear(false);
                MessageBox.Show("Input invalid, use numbers only and ensure k isn't smaller than m");
            }
            else
                Calculate();
        }
    }
}
