# Console Calculator

A console-based calculator built in C# as part of the [C# Academy](https://thecsharpacademy.com/) curriculum.

---

## Overview

Console Calculator is an interactive console application that allows users to perform a variety of arithmetic and mathematical operations. It logs all operations to a JSON file, tracks session history, and supports reusing previous results for chained calculations.

---

## Features

- **Basic operations** - Addition, Subtraction, Multiplication, Division
- **Advanced operations** - Square Root, Power, 10x
- **Trigonometry functions** - Sine, Cosine, Tangent (input in degrees)
- **Calculation history** - All operations from the current session are displayed and can be cleared at any time
- **Reuse last result** - Users can use the result of the previous calculation as the first operand of the next one
- **Usage counter** - Tracks how many times the calculator has been used during the session
- **JSON logging** - All operations and results are logged to `calculator.json`
- **Input validation** - Invalid inputs are rejected and the user is prompted to re-enter

---

## How to run

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) 10.0 or later

### Steps

```bash
git clone https://github.com/Sephydev/STUDY.CSharp.Calculator.git
cd STUDY.CSharp.Calculator/CalculatorProgram
dotnet run
```

---

## Project Structure

```
STUDY.CSharp.Calculator/
├── CalculatorLibrary/
│   └── Calculator.cs       # Calculator logic, JSON logging, history management
└── CalculatorProgram/
    └── Program.cs          # Entry point, user interface, input handling
```

---

## Usage

1. The calculator displays the **history of previous calculations** at the start of each loop.
2. If history exists, you can **delete it** or **reuse the last result** as the first operand.
3. Enter your **first number**, then your **second number** (ignored for single-operand operations).
4. Choose an **operator** from the list:
    - `a` - Add
    - `s` - Subtract
    - `m` - Multiply
    - `d` - Divide
    - `sr` - Square Root *(first number only)*
    - `pow` - Power
    - `exp` - 10x *(first number only)*
    - `sin` - Sine *(first number only, in degrees)*
    - `cos` - Cosine *(first number only, in degrees)*
    - `tan` - Tangent *(first number only, in degrees)*
5. Your result is displayed and logged to `calculatorlog.json`.
6. Press `n` to exit, or any other key to continue.

---

## License

This project was built for educational purposes as part of the C# Academy curriculum. Feel free to use or adapt it.