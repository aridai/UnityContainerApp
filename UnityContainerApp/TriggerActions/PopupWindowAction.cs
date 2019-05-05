using System;
using System.Windows;
using Microsoft.Xaml.Behaviors;
using Prism.Interactivity.InteractionRequest;

namespace UnityContainerApp.TriggerActions
{
    //  PrismはXamlBehaviorsWpfのアセンブリをサポートしないため、同じ名前のクラスでもそのまま使うことができない。
    //  参考: https://github.com/PrismLibrary/Prism/pull/1644
    //  今回はPrismのPouupWindowActionの簡易版を実装する。
    //  参考: https://github.com/PrismLibrary/Prism/blob/master/Source/Wpf/Prism.Wpf/Interactivity/PopupWindowAction.cs

    public sealed class PopupWindowAction : TriggerAction<DependencyObject>
    {
        protected override void Invoke(object parameter)
        {
            var args = (InteractionRequestedEventArgs)parameter;
            var confirmation = (Confirmation)args.Context;

            var caption = confirmation.Title.ToString();
            var body = confirmation.Content.ToString();

            confirmation.Confirmed = MessageBox.Show(body, caption, MessageBoxButton.OKCancel) == MessageBoxResult.OK;
            args.Callback();
        }
    }
}