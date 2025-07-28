WPF Calculator Application
==========================

This is a simple calculator built using C# and WPF (Windows Presentation Foundation).
It supports basic arithmetic operations, percentage calculation, and memory functions.

Features:
---------
- Basic operations: +, -, ×, ÷
- Percentage: %
- Memory functions: M+, MRC, M-
- Clear (C) and All Clear (AC)
- Keyboard and button input
- Operation chaining and result display

Requirements:
-------------
- Windows Operating System
- .NET 8 SDK or higher
- Visual Studio 2022 (v17.8 or later) or newer

How to Run:
-----------
1. Clone the project:
   git clone https://github.com/Suraj-khatri/WPFCalculatorApp.git

2. Open the project in Visual Studio:
   Double-click on the CalculatorApp.sln file

3. Build and run the project:
   Press Ctrl + F5 to run the app without debugging

How to Use:
-----------
- Click numbers or use your keyboard to input values
- Use the operator buttons (+, -, ×, ÷) for calculations
- Press '=' to get the result
- Press '%' to calculate percentage:
  - value / 100
- M+ adds current result to memory (does not change display)
- MRC recalls memory value
- C clears the current entry
- AC clears everything including memory

Memory Example:
---------------
1. Press 100
2. Press ×
3. Press 2
4. Press M+  → Adds 200 to memory (display unchanged)
5. Press 50
6. Press ×
7. Press 5
8. Press M+  → Adds 250 (total memory = 450)
9. Press MRC → Displays 450

Project Structure:
-----------------
CalculatorApp/
├── CalculatorApp.WPF/
│   ├── MainWindow.xaml
│   └── MainWindow.xaml.cs   
└── CalculatorApp.sln
