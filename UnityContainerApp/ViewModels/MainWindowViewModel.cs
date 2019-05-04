using System;
using Prism.Mvvm;
using UnityContainerApp.Models;

namespace UnityContainerApp.ViewModels
{
    public sealed class MainWindowViewModel : BindableBase
    {
        public Couple Couple { get; }

        public string Text => this.Couple.ToString();

        public MainWindowViewModel(Couple couple)
        {
            this.Couple = couple;
            System.Diagnostics.Debug.WriteLine($"{nameof(MainWindowViewModel)}::Constructor(Couple)");
        }
    }
}