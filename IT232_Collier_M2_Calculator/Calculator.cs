using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT232_Collier_M2_Calculator
{
    public partial class Calc : Form
    {
        #region Declarations
        decimal operandA = 0M;
        decimal operandB = 0M;
        decimal result = 0M;
        char operation;
        bool dec = true;
        #endregion

        #region Constructor
        public Calc()
        {
            InitializeComponent();
        }
        #endregion

        /* updateDisplay is called when the display needs to refresh. */
        private void updateDisplay(decimal value) {
            // Updates display
            lblDisplay.Text = value.ToString();
            lblDisplay.Refresh();
        }

        /* insertNum is called when a numerical button is clicked. */
        private void insertNum(String n)
        {
            // Inserts a number to operandA and updates display.
            // Make operand negative.
            if (operandB == 0 && operation == '-')
            {
                operandA = Convert.ToDecimal((operandA.ToString() + n)) * -1;
            }
            // Insert number after non-existent decimal point.
            else if (dec == false)
            {
                operandA = Convert.ToDecimal((operandA.ToString() + "." + n));
                dec = true;
            }
            // Insert a whole number.
            else 
            {
                operandA = Convert.ToDecimal((operandA.ToString() + n));
            }
            updateDisplay(operandA);
        }

        /* opButton is called when an operation button (add, subtract, multiply, divide, decimal) is clicked. */
        private void opButton(char op)
        {
            // A non-zero operandB means we need to calculate the total.
            if (operandB != 0 && op != '.')
            {
                btnEqual.PerformClick();
            }
            if (op != '.')
            {
                // Stores operandA in operandB.
                operandB = operandA;
                // Reset operandA to 0.
                operandA = 0M;
                // Set the last clicked oepration button.
                operation = op;
                // Allow decimal entry.
                dec = true;
            } else
            {
               dec = operandA.ToString().Contains(".");
            }
        }

        /* Clear Button */
        private void btnClear_Click(object sender, EventArgs e)
        {
            // Reset all values and refresh display.
            operandA = 0;
            operandB = 0;
            result = 0;
            operation = '?';
            dec = true;
            updateDisplay(operandA);
        }

        /* Equal Button */
        private void btnEqual_Click(object sender, EventArgs e)
        {
            // Perform the appropriate calculation.
            switch(operation)
            {
                case '+':
                    result = Decimal.Add(operandA, operandB);
                    break;
                case '-':
                    result = Decimal.Subtract(operandB, operandA);
                    break;
                case '*':
                    result = Decimal.Multiply(operandA, operandB);
                    break;
                case '/':
                    result = Decimal.Divide(operandB, operandA);
                    break;
                default:
                    break;
            }
            // Store the result in operandA and reset operandB, in case next click is an operator button.
            operandA = result;
            operandB = 0;
            // Reset the operation to a non-existent conditional.
            operation = '?';
            // Refresh the display.
            updateDisplay(operandA);
        }

        /* Operation Buttons */
        #region Operation Buttons
        // ADD
        private void btnAdd_Click(object sender, EventArgs e)
        {
            opButton('+');
        }
        // SUBTRACT
        private void btnSubtract_Click(object sender, EventArgs e)
        {
            opButton('-');
        }
        // MULTIPLY
        private void btnMultiply_Click(object sender, EventArgs e)
        {

            opButton('*');
        }
        // DIVIDE
        private void btnDivide_Click(object sender, EventArgs e)
        {
            opButton('/');
        }
        // DECIMAL
        private void btnDecimal_Click(object sender, EventArgs e)
        {
            opButton('.');
        }
        #endregion

        /* Numerical Buttons */
        #region Numerical Buttons
        // 0
        private void btnZero_Click(object sender, EventArgs e)
        {
            if(operandA != 0)
            {
                insertNum("0");
            }
        }
        // 1
        private void btnOne_Click(object sender, EventArgs e)
        {
            insertNum("1");
        }
        // 2
        private void btnTwo_Click(object sender, EventArgs e)
        {
            insertNum("2");
        }
        // 3
        private void btnThree_Click(object sender, EventArgs e)
        {
            insertNum("3");
        }
        // 4
        private void btnFour_Click(object sender, EventArgs e)
        {
            insertNum("4");
        }
        // 5
        private void btnFive_Click(object sender, EventArgs e)
        {
            insertNum("5");
        }
        // 6
        private void btnSix_Click(object sender, EventArgs e)
        {
            insertNum("6");
        }
        // 7
        private void btnSeven_Click(object sender, EventArgs e)
        {
            insertNum("7");
        }
        // 8
        private void btnEight_Click(object sender, EventArgs e)
        {
            insertNum("8");
        }
        // 9
        private void btnNine_Click(object sender, EventArgs e)
        {
            insertNum("9");
        }
        #endregion

    }
}