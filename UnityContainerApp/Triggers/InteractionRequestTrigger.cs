using System;
using Microsoft.Xaml.Behaviors;

namespace UnityContainerApp.Triggers
{
    //  PrismはXamlBehaviorsWpfのアセンブリをサポートしないため、従来のTriggerをそのまま使うことができない。
    //  しかし、実装は簡単で、InteractionRequestのRaisedイベントをトリガーにするEventTriggerが実体であるため、自作することができる。
    //  参考: https://github.com/PrismLibrary/Prism/blob/388d7094980bfce89911c7c46694a678fbcfae28/Source/Wpf/Prism.Wpf/Interactivity/InteractionRequest/InteractionRequestTrigger.cs

    public sealed class InteractionRequestTrigger : EventTrigger
    {
        public InteractionRequestTrigger() => this.EventName = "Raised";
    }
}