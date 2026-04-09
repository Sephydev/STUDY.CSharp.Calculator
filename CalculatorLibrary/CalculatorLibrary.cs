using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace CalculatorLibrary
{
    public class Calculator
    {
        JsonWriter writer;
        private int count;
        private List<string> previousCalculation;

        public Calculator()
        {
            count = 0;
            previousCalculation = new List<string>();

            StreamWriter logFile = File.CreateText("calculatorlog.json");
            logFile.AutoFlush = true;
            writer = new JsonTextWriter(logFile);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("Operations");
            writer.WriteStartArray();
        }
        public double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // Default value is "not-a-number" if an operation, such as division, could result in an error.
            string mathOperator = "";
            double radianNum1 = 0;
            
            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(num1);
            if (!Regex.IsMatch(op, "^(sr|exp|sin|cos)$"))
            {
                writer.WritePropertyName("Operand2");
                writer.WriteValue(num2);
            }
            writer.WritePropertyName("Operation");

            if (Regex.IsMatch(op, "^(sin|cos)"))
                radianNum1 = num1 * (Math.PI / 180);

            // Use a switch statement to do the math.
            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    mathOperator = "+";
                    writer.WriteValue("Add");
                    break;
                case "s":
                    result = num1 - num2;
                    mathOperator = "-";
                    writer.WriteValue("Subtract");
                    break;
                case "m":
                    result = num1 * num2;
                    mathOperator = "*";
                    writer.WriteValue("Multiply");
                    break;
                case "d":
                    // Ask the user to enter a non-zero divisor.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    mathOperator = "/";
                    writer.WriteValue("Divide");
                    break;
                case "sr":
                    result = Math.Sqrt(num1);
                    writer.WriteValue("Square Root");
                    break;
                case "pow":
                    result = Math.Pow(num1, num2);
                    writer.WriteValue("Taking the Power");
                    break;
                case "exp":
                    result = Math.Pow(10, num1);
                    writer.WriteValue("10x");
                    break;
                case "sin":
                    result = Math.Sin(radianNum1);
                    writer.WriteValue("Sinus");
                    break;
                case "cos":
                    result = Math.Cos(radianNum1);
                    writer.WriteValue("Cosinus");
                    break;
                // Return text for an incorrect option entry.
                default:
                    break;
            }
            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();
            IncrementCount();

            switch (op)
            {
                case "a":
                case "s":
                case "m":
                case "d":
                    previousCalculation.Add($"{num1} {mathOperator} {num2} = {result}");
                    break;
                case "sr":
                    previousCalculation.Add($"sqrt({num1}) = {result}");
                    break;
                case "pow":
                    previousCalculation.Add($"{num1}^{num2} = {result}");
                    break;
                case "exp":
                    previousCalculation.Add($"10^{num1} = {result}");
                    break;
                case "sin":
                case "cos":
                    previousCalculation.Add($"{op}({num1}) = {result}");
                    break;
            }

            return result;
        }

        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }

        private void IncrementCount()
        {
            count++;
        }

        public void DeleteHistory()
        {
            previousCalculation.Clear();
        }

        public List<string> PreviousCalculation
        {
            get
            {
                return previousCalculation;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
        }
    }
}
