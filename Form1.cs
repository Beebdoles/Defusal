using System.ComponentModel.Design;
using System.Windows.Forms.VisualStyles;
using System.Xml;

namespace Defusal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //module wires
        {
            String[] wireColours;
            wireColours = wireInputs.Text.ToString().Split(',');
            List<string> wireColoursNew = new List<string>();

            for (int i = 0; i <= wireColours.Length - 1; ++i)
            {
                wireColoursNew.Add(wireColours[i]);
            }

            int blue = 0, red = 0, white = 0, green = 0;

            foreach(string a in wireColoursNew)
            {
                if(a.Equals("blue"))
                {
                    ++blue;
                }

                if(a.Equals("red"))
                {
                    ++red;
                }

                if(a.Equals("white"))
                {
                    ++white;
                }

                if (a.Equals("green"))
                {
                    ++green;
                }
            }

            string cutWire = "error";

            if(wireColoursNew.Count == 3)
            {
                if(red == 0)
                {
                    cutWire = "Cut first wire";
                }
                else if(white >= 1)
                {
                    cutWire = "Cut second wire";
                }
                else if(blue >= 1)
                {
                    cutWire = "Cut third wire";
                }
                else
                {
                    cutWire = "Error";
                }
            }

            if (wireColoursNew.Count == 4)
            {
                if(green == 0)
                {
                    cutWire = "Cut first wire";
                }
                else if(blue == 0)
                {
                    cutWire = "Cut second wire";
                }
                else if(white == 0)
                {
                    cutWire = "Cut third wire";
                }
                else
                {
                    cutWire = "Cut fourth wire";
                }
            }

            if (wireColoursNew.Count == 5)
            {
                if(lightColour.Text.Equals("red"))
                {
                    cutWire = "Cut first wire";
                }
                else if(lightColour.Text.Equals("green"))
                {
                    cutWire = "Cut second wire";
                }
                else if(lightColour.Text.Equals("blue"))
                {
                    cutWire = "Cut third wire";
                }
                else if(lightColour.Text.Equals("yellow"))
                {
                    cutWire = "Cut fourth wire";
                }
                else
                {
                    cutWire = "Cut fifth wire";
                }
            }

            textBox3.Text = cutWire;
        }

        private void buttonSubmit_Click(object sender, EventArgs e) //module button
        {
            string colour = buttonColour.Text.ToString();
            string text = buttonText.Text.ToString();
            int count = 0;
            string arrow;

            if(colour.Equals("blue") && text.Equals("detonate"))
            {
                count = 1;
            }
            else if(colour.Equals("red"))
            {
                count = 2;
            }
            else if(text.Equals("abort"))
            {
                count = 3;
            }
            else if(colour.Equals("grey") || colour.Equals("white"))
            {
                count = 4;
            }
            else
            {
                count = 0;
            }

            if(count <= 2)
            {
                arrow = "down";
            }
            else
            {
                arrow = "up";
            }

            if(count == 0)
            {
                buttonOutput.Text = "input error";
            }
            else
            {
                buttonOutput.Text = "click " + count + " time(s), press " + arrow + " arrow";
            }
        }

        private void hexaSubmit_Click(object sender, EventArgs e) //module hexadecimal
        {
            string[] hex = hexaInput.Text.Split(' ');
            string text = "";

            foreach(string a in hex)
            {
                try
                {
                    text += ((Char)Convert.ToInt32(a, 16)).ToString();
                }
                catch
                {
                    text += " [unidentified hex value entered] ";
                }
            }

            hexaOutput.Text = text;
        }

        private void keypadSubmit_Click(object sender, EventArgs e) //module keypad
        {
            double x;
            double y;
            try
            {
                int num1 = Convert.ToInt32(keypadInput1.Text);
                int num2 = Convert.ToInt32(keypadInput2.Text);
                int num3 = Convert.ToInt32(keypadInput3.Text);
                int num4 = Convert.ToInt32(keypadInput4.Text);
                y = (double)(num1 + num2 + num3 + num4) / 2.0;

                if (num1 < 10)
                {
                    x = 15;
                }
                else if (num1 > 10 && num1 < 20)
                {
                    x = 20;
                }
                else if (num1 > 20 && num1 < 80)
                {
                    x = 30;
                }
                else
                {
                    x = 10;
                }

                if (num2 < 10)
                {
                    x += 10;
                }
                else if (num2 > 10 && num2 < 20)
                {
                    x *= 2;
                }
                else if (num2 > 20 && num2 < 80)
                {
                    x *= 3;
                }
                else
                {
                    x -= 10;
                }

                if (num3 < 10)
                {
                    x *= 2;
                }
                else if (num3 > 10 && num3 < 20)
                {
                    x *= 3;
                }
                else if (num3 > 20 && num3 < 80)
                {
                    x -= 5;
                }
                else
                {
                    x += 0;
                }

                if (num4 < 10)
                {
                    x *= 2;
                }
                else if (num4 > 10 && num4 < 20)
                {
                    x += 20;
                }
                else if (num4 > 20 && num4 < 80)
                {
                    x += 50;
                }
                else
                {
                    x *= 3;
                }

                double z = (double)x - y;

                if (z <= 0)
                {
                    keypadOutput1.Text = "1";
                    keypadOutput2.Text = "2";
                    keypadOutput3.Text = "3";
                    keypadOutput4.Text = "4";
                }
                if (z >= 0.5 && z <= 19.5)
                {
                    keypadOutput1.Text = "1";
                    keypadOutput2.Text = "2";
                    keypadOutput3.Text = "4";
                    keypadOutput4.Text = "3";
                }
                if (z >= 20 && z <= 49.5)
                {
                    keypadOutput1.Text = "4";
                    keypadOutput2.Text = "3";
                    keypadOutput3.Text = "2";
                    keypadOutput4.Text = "1";
                }
                if (z >= 50 && z <= 89.5)
                {
                    keypadOutput1.Text = "2";
                    keypadOutput2.Text = "4";
                    keypadOutput3.Text = "1";
                    keypadOutput4.Text = "3";
                }
                if (z >= 90)
                {
                    keypadOutput1.Text = "3";
                    keypadOutput2.Text = "1";
                    keypadOutput3.Text = "2";
                    keypadOutput4.Text = "4";
                }
            }
            catch
            {
                keypadOutput1.Text = "error";
                keypadOutput2.Text = "error";
                keypadOutput3.Text = "error";
                keypadOutput4.Text = "error";
            }
            
        }

        private void binary1_Click(object sender, EventArgs e)
        {
            binaryColourAdjust(sender);
        }

        private void binary2_Click(object sender, EventArgs e)
        {
            binaryColourAdjust(sender);
        }

        private void binary3_Click(object sender, EventArgs e)
        {
            binaryColourAdjust(sender);
        }

        private void binary4_Click(object sender, EventArgs e)
        {
            binaryColourAdjust(sender);
        }

        private void binary5_Click(object sender, EventArgs e)
        {
            binaryColourAdjust(sender);
        }

        private void binary6_Click(object sender, EventArgs e)
        {
            binaryColourAdjust(sender);
        }

        private void binary7_Click(object sender, EventArgs e)
        {
            binaryColourAdjust(sender);
        }

        int black = 7, white = 0;

        private void mathematicsSubmit_Click(object sender, EventArgs e) //module mathematics
        {
            string[] letters = mathematicsInput.Text.Split(' ');
            try
            {
                int x = Convert.ToInt32(mathematicsLetterToNumber(letters[0].Substring(0, 1)) + mathematicsLetterToNumber(letters[0].Substring(1, 1)));
                int y = Convert.ToInt32(mathematicsLetterToNumber(letters[1].Substring(0, 1)) + mathematicsLetterToNumber(letters[1].Substring(1, 1)));

                mathematicsOutput.Text = (x * y).ToString();
            }
            catch
            {
                mathematicsOutput.Text = "input error, check your input";
            }
        }

        private void binarySubmit_Click(object sender, EventArgs e) //module binary
        {
            int count;

            if(black == 7)
            {
                count = 1;
            }
            else if(binary2.BackColor.Equals(Color.White) && binary7.BackColor.Equals(Color.Black))
            {
                count = 2;
            }
            else if(binary1.BackColor.Equals(Color.White) && binary2.BackColor.Equals(Color.White))
            {
                count = 3;
            }
            else if(binary1.BackColor.Equals(Color.Black) && binary7.BackColor.Equals(Color.Black))
            {
                count = 4;
            }
            else if(binary1.BackColor.Equals(Color.White) && binary2.BackColor.Equals(Color.White) && binary3.BackColor.Equals(Color.White))
            {
                count = 5;
            }
            else if(binary1.BackColor.Equals(Color.White) && binary2.BackColor.Equals(Color.White) && binary3.BackColor.Equals(Color.White) && binary4.BackColor.Equals(Color.White))
            {
                count = 6;
            }
            else if(black > 3)
            {
                count = 7;
            }
            else if(white > 5)
            {
                count = 8;
            }
            else if(black == 7)
            {
                count = 9;
            }
            else
            {
                count = 10;
            }

            binaryOutput.Text = "click red " + count + " time(s)";
        }

        private void colourSubmit_Click(object sender, EventArgs e) //module colour code
        {
            string[] lightColours = colourInputLight.Text.Split(',');
            string displayLetters = colourInputDisplay.Text;

            int x = 0, y = 0, z = 0;

            foreach(string a in lightColours)
            {
                if(colourCodeLightToNumber(a) != -1)
                {
                    y += colourCodeLightToNumber(a);
                }
                else
                {
                    ++z;
                }
            }

            for(int i = 0; i < displayLetters.Length; ++i)
            {
                if(colourCodeDisplayToNumber(displayLetters.Substring(i, 1)) != -1)
                {
                    x += colourCodeDisplayToNumber(displayLetters.Substring(i, 1));
                }
                else
                {
                    ++z;
                }
            }

            if(x - y > 0 && z == 0)
            {
                colourOutput.Text = "click red button " + (x - y) + " time(s)";
            }
            else if(x - y <= 0 && z == 0)
            {
                colourOutput.Text = "submit without clicking";
            }
            else
            {
                colourOutput.Text = "input error, double check input";
            }
        }

        private void multibuttonsSubmit_Click(object sender, EventArgs e) //module multibuttons
        {
            try
            {
                int[] numbers = new int[6];
                for (int i = 0; i < 6; ++i)
                {
                    numbers[i] = Convert.ToInt32(multibuttonsInput.Text.Substring(i, 1));
                }

                Boolean multi1 = false, multi2 = false, multi3 = false;

                if (numbers[0] < 6) 
                { 
                    multiOutput1.Text = "1";
                    multi1 = true;
                } 
                else 
                { 
                    multiOutput4.Text = "1"; 
                }

                if (numbers[1] < 6) 
                { 
                    multiOutput2.Text = "2";
                    multi2 = true;
                } 
                else
                {
                    multiOutput5.Text = "2"; 
                }

                if (numbers[2] < 6) 
                {
                    multiOutput3.Text = "3";
                    multi3 = true;
                } 
                else 
                { 
                    multiOutput6.Text = "3"; 
                }

                if (numbers[3] < 7)
                {
                    if (multi2) { multiOutput5.Text = "4"; } else { multiOutput2.Text = "4"; }
                    if (multi3) { multiOutput6.Text = "5"; } else { multiOutput3.Text = "5"; }
                    if (multi1) { multiOutput4.Text = "6"; } else { multiOutput1.Text = "6"; }
                } 
                else if (numbers[4] < 7)
                {
                    if (multi3) { multiOutput6.Text = "4"; } else { multiOutput3.Text = "4"; }
                    if (multi2) { multiOutput5.Text = "5"; } else { multiOutput2.Text = "5"; }
                    if (multi1) { multiOutput4.Text = "6"; } else { multiOutput1.Text = "6"; }
                }
                else if (numbers[5] > 5)
                {
                    if (multi1) { multiOutput4.Text = "4"; } else { multiOutput1.Text = "4"; }
                    if (multi2) { multiOutput5.Text = "5"; } else { multiOutput2.Text = "5"; }
                    if (multi3) { multiOutput6.Text = "6"; } else { multiOutput3.Text = "6"; }
                }
                else
                {
                    if (multi1) { multiOutput4.Text = "4"; } else { multiOutput1.Text = "4"; }
                    if (multi3) { multiOutput6.Text = "5"; } else { multiOutput3.Text = "5"; }
                    if (multi2) { multiOutput5.Text = "6"; } else { multiOutput2.Text = "6"; }
                }
            }
            catch
            {
                multiOutput1.Text = "error";
                multiOutput2.Text = "error";
                multiOutput3.Text = "error";
                multiOutput4.Text = "error";
                multiOutput5.Text = "error";
                multiOutput6.Text = "error";
            }
        }

        private void timingSubmit_Click(object sender, EventArgs e) //module timing
        {
            try
            {
                string[] display = timingInput.Text.Split(' ');
                int x = 0, y = 0;

                x = Convert.ToInt32(display[0].Substring(0, 1)) + Convert.ToInt32(display[0].Substring(1, 1));
                y = timingLetterToNumber(display[1].Substring(0, 1)) + timingLetterToNumber(display[1].Substring(1, 1));

                if(x * y >= 0 && x * y <= 59)
                {
                    timingOutput.Text = "click when White";
                }
                if(x * y >= 60 && x * y <= 99)
                {
                    timingOutput.Text = "click when Red";
                }
                if(x * y >= 100 && x * y <= 199)
                {
                    timingOutput.Text = "click when Yellow";
                }
                if(x * y >= 200 && x * y <= 299)
                {
                    timingOutput.Text = "click when Green";
                }
                if(x * y >= 300 && x * y <= 399)
                {
                    timingOutput.Text = "click when Blue";
                }
                if(x * y >= 400 && x * y <= 499)
                {
                    timingOutput.Text = "click when Yellow";
                }
                if(x * y >= 500 && x * y <= 599)
                {
                    timingOutput.Text = "click when Red";
                }
                if(x * y >= 600)
                {
                    timingOutput.Text = "click when White";
                }
            }
            catch
            {
                timingOutput.Text = "error, check input";
            }
        }

        private void tilesSubmit_Click(object sender, EventArgs e) //module tiles
        {
            try
            {
                string colour1 = tilesInput1.Text, colour2 = tilesInput2.Text;

                if(tilesLetterToNumber(colour1) != -1 && tilesLetterToNumber(colour2) != -1)
                {
                    tilesOutput.Text = (tilesLetterToNumber(colour1) + tilesLetterToNumber(colour2)).ToString();
                }
                else
                {
                    tilesOutput.Text = "error, check input";
                }
            }
            catch
            {
                tilesOutput.Text = "error, check input";
            }
        }

        private int tilesLetterToNumber(string a)
        {
            if(a.Equals("red"))
            {
                return 1;
            }
            else if(a.Equals("green"))
            {
                return 9;
            }
            else if (a.Equals("blue"))
            {
                return 7;
            }
            else if (a.Equals("yellow"))
            {
                return 2;
            }
            else if (a.Equals("pink"))
            {
                return 6;
            }
            else if (a.Equals("white"))
            {
                return 5;
            }
            else
            {
                return -1;
            }
        }

        private int timingLetterToNumber(string a)
        {
            if (a.Equals("A"))
            {
                return 4;
            }
            else if (a.Equals("B"))
            {
                return 3;
            }
            else if (a.Equals("C"))
            {
                return 7;
            }
            else if (a.Equals("D"))
            {
                return 9;
            }
            else
            {
                return -1;
            }
        }

        private int colourCodeLightToNumber(string a)
        {
            if(a.Equals("red"))
            {
                return 0;
            }
            else if(a.Equals("green"))
            {
                return 0;
            }
            else if (a.Equals("blue"))
            {
                return 1;
            }
            else if (a.Equals("yellow"))
            {
                return 2;
            }
            else if (a.Equals("white"))
            {
                return 3;
            }
            else
            {
                return -1;
            }
        }

        private int colourCodeDisplayToNumber(string a)
        {
            if(a.Equals("r"))
            {
                return 1;
            }
            else if (a.Equals("g"))
            {
                return 3;
            }
            else if (a.Equals("b"))
            {
                return 2;
            }
            else if (a.Equals("y"))
            {
                return 3;
            }
            else if (a.Equals("w"))
            {
                return 4;
            }
            else
            {
                return -1;
            }
        }

        private void binaryColourAdjust(object sender)
        {
            Control ctrl = (Control)sender;
            switch (ctrl.BackColor.Name)
            {
                case "Black":
                    ctrl.BackColor = Color.White;
                    --black;
                    ++white;
                    break;
                case "White":
                    ctrl.BackColor = Color.Black;
                    ++black;
                    --white;
                    break;
            }
        }

        private string mathematicsLetterToNumber(string a)
        {
            if (a.Equals("A"))
            {
                return "1";
            }
            else if (a.Equals("B"))
            {
                return "3";
            }
            else if (a.Equals("C"))
            {
                return "7";
            }
            else if (a.Equals("D"))
            {
                return "2";
            }
            else if (a.Equals("E"))
            {
                return "4";
            }
            else if (a.Equals("F"))
            {
                return "5";
            }
            else if (a.Equals("G"))
            {
                return "6";
            }
            else if (a.Equals("H"))
            {
                return "0";
            }
            else if (a.Equals("I"))
            {
                return "8";
            }
            else if (a.Equals("J"))
            {
                return "9";
            }
            else
            {
                return "null";
            }
        }
    }
}