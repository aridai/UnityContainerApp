using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using Unity;
using UnityContainerApp.Models;

namespace UnityContainerApp.ViewModels
{
    public sealed class MainWindowViewModel : BindableBase, IDisposable
    {
        private readonly CompositeDisposable disposable = new CompositeDisposable();

        public string Text { get; }

        public ReactiveCommand ButtonCommand { get; }

        public InteractionRequest<Confirmation> DialogRequest { get; } = new InteractionRequest<Confirmation>();

        [InjectionConstructor]
        public MainWindowViewModel([Dependency]Couple couple)
        {
            this.Text = couple.ToString();

            //  1秒おきに有効状態が切り替わるおかしなボタンにする。
            this.ButtonCommand = Observable.Interval(TimeSpan.FromSeconds(1))
                .Scan(default(bool), (prev, _) => !prev)
                .ObserveOnDispatcher()
                .ToReactiveCommand()
                .AddTo(this.disposable);

            //  ダイアログを開くためのInteractionRequestを投げる。
            this.ButtonCommand.Subscribe(() =>
            {
                this.DialogRequest.Raise(
                    new Confirmation { Title = "ダイアログ", Content = "これはダイアログです。" },
                    conf => System.Diagnostics.Debug.WriteLine($"Title: {conf.Title}, Content: {conf.Content}, Confirmed: {conf.Confirmed}"));
            }).AddTo(this.disposable);
        }

        public void Dispose()
        {
            this.disposable.Dispose();
        }
    }
}