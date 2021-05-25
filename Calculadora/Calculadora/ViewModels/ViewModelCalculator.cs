using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Calculadora.ViewModels
{
    public class ViewModelCalculator : ViewModelBase
    {
        #region Properties

        private double _prevNumber = 0.0;

        public double PrevNumber
        {
            get => _prevNumber;
            set
            {
                if (_prevNumber != value)
                {
                    _prevNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        private double _currentNumber = 0.0;

        public double CurrentNumber
        {
            get => _currentNumber;
            set
            {
                if (_currentNumber != value)
                {
                    _currentNumber = value;
                    OnPropertyChanged();
                }
            }
        }
        
        private string _operation = "";

        public string Operation
        {
            get => _operation;
            set => _operation = value;
        }

        #endregion

        #region Commands

        public ICommand SelectNumber { protected set; get; }
        public ICommand OperatorNumber { protected set; get; }
        public ICommand ShowResult { protected set; get; }
        public ICommand ClearResult { protected set; get; }
        
        #endregion

        #region Constructor

        public ViewModelCalculator()
        {
            SelectNumber = new Command<String>(
                execute: (string parameter) =>
                {
                    CurrentNumber = CurrentNumber == 0 || Operation == "" ? Double.Parse(parameter) : 
                        Double.Parse(CurrentNumber+parameter);
                });

            OperatorNumber = new Command<String>(
                execute: (string parameter) =>
                {
                    Operation = parameter;
                    if (CurrentNumber != 0)
                    {
                        PrevNumber = CurrentNumber;
                        CurrentNumber = 0;
                    }
                });
            
            ShowResult = new Command( () =>
                {
                    switch (Operation)
                    {
                        case "+":
                            CurrentNumber += PrevNumber;
                            break;
                        case "-":
                            CurrentNumber = PrevNumber - CurrentNumber;
                            break;
                        case "÷":
                            CurrentNumber = PrevNumber/CurrentNumber;
                            break;
                        case "×":
                            CurrentNumber = PrevNumber*CurrentNumber;
                            break;
                        default:
                            CurrentNumber = CurrentNumber;
                            break;
                    }

                    Operation = "";
                });
            
            ClearResult = new Command( () =>
            {
                PrevNumber = 0;
                CurrentNumber = 0;
                Operation = "";
            });
            
        }

        #endregion
    }
}