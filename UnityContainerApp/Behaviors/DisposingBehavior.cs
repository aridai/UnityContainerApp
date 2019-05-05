using System;
using System.Windows;
using Microsoft.Xaml.Behaviors;

namespace UnityContainerApp.Behaviors
{
    public sealed class DisposingBehavior : Behavior<Window>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Closed += this.OnClosed;
        }

        private void OnClosed(object sender, EventArgs e)
        {
            (this.AssociatedObject.DataContext as IDisposable)?.Dispose();
            (this.AssociatedObject as IDisposable)?.Dispose();
            this.AssociatedObject.Closed -= this.OnClosed;
        }
    }
}