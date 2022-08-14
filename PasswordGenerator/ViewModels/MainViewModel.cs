using System.Windows;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PasswordGenerator.ViewModels
{
    using RandomPasswordGenerator;

    internal class MainViewModel : ObservableObject
    {
        private string _password = string.Empty;

        private readonly RandomPasswordGenerator _generator = new(length: 12,
                                                                  uppercase: true,
                                                                  lowercase: true,
                                                                  numbers: true,
                                                                  symbols: false);

        public string Password
        {
            get => _password;

            set
            {
                if (value != Password) {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Length
        {
            get => _generator.Length;
            
            set
            {
                if (value != Length) {
                    _generator.Length = value;
                    OnPropertyChanged();
                    GeneratePassword();
                }
            }
        }

        public bool Uppercase
        {
            get => _generator.Uppercase;

            set
            {
                if (value != Uppercase) {
                    _generator.Uppercase = value;
                    OnPropertyChanged();
                    GeneratePassword();
                }
            }
        }

        public bool Lowercase
        {
            get => _generator.Lowercase;

            set
            {
                if (value != Lowercase) {
                    _generator.Lowercase = value;
                    OnPropertyChanged();
                    GeneratePassword();
                }
            }
        }

        public bool Numbers
        {
            get => _generator.Numbers;
            
            set
            {
                if (value != Numbers) {
                    _generator.Numbers = value;
                    OnPropertyChanged();
                    GeneratePassword();
                }
            }
        }

        public bool Symbols
        {
            get => _generator.Symbols;

            set
            {
                if (value != Symbols) {
                    _generator.Symbols = value;
                    OnPropertyChanged();
                    GeneratePassword();
                }
            }
        }

        public RelayCommand GenerateCommand { get; }

        public RelayCommand CopyCommand { get; }

        public MainViewModel()
        {
            GenerateCommand = new(GeneratePassword);
            CopyCommand = new(() => Clipboard.SetText(Password));
            GeneratePassword();
        }

        private void GeneratePassword() => Password = _generator.Next();
    }
}
