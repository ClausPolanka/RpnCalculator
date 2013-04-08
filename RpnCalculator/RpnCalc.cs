using System;
using System.Collections.Generic;
using System.Linq;

namespace RpnCalculator
{
    public class RpnCalc
    {
        private const int ON_TOP = 0;
        private List<double> stack = new List<double>();
        private bool enterWasPressed;
        private double boundaryNumber;
        private Display display;

        public RpnCalc(Display display)
        {
            this.display = display;
        }

        public void Pressed(double number)
        {
            PushOnStack(number);
            display.Show(Math.Round(number, digits: 2));
        }

        private void PushOnStack(double number)
        {
            if (enterWasPressed)
                RemoveTopNumber();

            stack.Insert(ON_TOP, number);
            SaveBoundaryElementIfNecessary();
        }

        private void RemoveTopNumber()
        {
            stack.RemoveAt(0);
            enterWasPressed = false;
        }

        private void SaveBoundaryElementIfNecessary()
        {
            if (stack.Count == 4)
                boundaryNumber = stack[3];
        }

        public void Enter()
        {
            double topNr = stack.First();
            ReplicateOnStack(topNr);
            display.Show(Math.Round(topNr, digits: 2));
        }

        private void ReplicateOnStack(double nr)
        {
            PushOnStack(nr);
            enterWasPressed = true;
        }

        public void Add()
        {
            double sum = SumOfOperands();
            EnsureTopNumberRemainsOnStackInCaseEnterWasPressedPreviously();
            PushOnStack(sum);
            display.Show(Math.Round(sum, digits: 2));
        }

        private void EnsureTopNumberRemainsOnStackInCaseEnterWasPressedPreviously()
        {
            if (enterWasPressed)
                enterWasPressed = false;
        }

        private double SumOfOperands()
        {
            double operand1 = Operand();
            double operand2 = Operand();
            return operand1 + operand2;
        }

        private double Operand()
        {
            double operand = boundaryNumber;

            if (stack.Count > 0)
            {
                operand = stack[0];
                stack.RemoveAt(0);
            }

            return operand;
        }

        public void Subtract()
        {
            double diff = DifferenceOfOperands();
            EnsureTopNumberRemainsOnStackInCaseEnterWasPressedPreviously();
            PushOnStack(diff);
            display.Show(Math.Round(diff, digits: 2));
        }

        private double DifferenceOfOperands()
        {
            double operand1 = Operand();
            double operand2 = Operand();
            return operand2 - operand1;
        }

        public void Multiply()
        {
            double prod = ProductOfOperands();
            EnsureTopNumberRemainsOnStackInCaseEnterWasPressedPreviously();
            PushOnStack(prod);
            display.Show(Math.Round(prod, digits: 2));
        }

        private double ProductOfOperands()
        {
            double operand1 = Operand();
            double operand2 = Operand();
            return operand1 * operand2;
        }

        public void Divide()
        {
            double quot = QuotientOfOperands();
            ThrowIfDivisionErrorOccured(quot);
            EnsureTopNumberRemainsOnStackInCaseEnterWasPressedPreviously();
            PushOnStack(quot);
            display.Show(Math.Round(quot, digits: 2));
        }

        private double QuotientOfOperands()
        {
            double operand1 = Operand();
            double operand2 = Operand();
            return operand2 / operand1;
        }

        private static void ThrowIfDivisionErrorOccured(double quot)
        {
            if (double.IsInfinity(quot))
                throw new DivisionException("Divided by 0 Exception.");

            if (double.IsNaN(quot))
                throw new DivisionException("0 as Dividend not supported.");
        }

        public class DivisionException : Exception
        {
            public DivisionException(string msg) : base(msg)
            {
            }
        }
    }
}