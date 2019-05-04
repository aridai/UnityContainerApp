using System;
using Prism.Mvvm;
using UnityContainerApp.Models;

namespace UnityContainerApp.ViewModels
{
    public sealed class MainWindowViewModel : BindableBase
    {
        public Couple Couple { get; }

        public MainWindowViewModel(Couple couple)
        {
            this.Couple = couple;
        }
    }
}