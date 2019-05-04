using System;
using System.Windows;
using Prism.Mvvm;
using Unity;
using UnityContainerApp.Models;
using UnityContainerApp.ViewModels;

namespace UnityContainerApp
{
    public partial class App : Application
    {
        private readonly IUnityContainer container = new UnityContainer();

        protected override void OnStartup(StartupEventArgs e)
        {
            //  ここでDIコンテナの設定をする。

            //  インターフェースと具象型を紐付ける。
            //  これは引数なしコンストラクタを持つため、型での紐付けで良い。
            this.container.RegisterType<Girlfriend, Marisa>();

            //  インターフェースとインスタンスを紐付ける。
            //  この場合はシングルトンになると思われる。
            //  this.container.RegisterInstance<Couple>(new Couple(this.container.Resolve<Girlfriend>()));

            //  コンストラクタの全ての引数が解決できる型である場合はこのようにも書ける。
            //  this.container.RegisterType<Couple, Couple>();

            //  もしくは、今回のように具象型ならば、別に書かなくてもいい。

            //  これも、具象型かつコンストラクタの全ての引数が解決できるため、別に書かなくてもいい。
            //  this.container.RegisterInstance<MainWindowViewModel>(new MainWindowViewModel(this.container.Resolve<Couple>()));

            //  AutoWireViewModelを有効にしたViewに流し込むViewModelを設定する。
            //  ViewModelLocatorはViewの名前の末尾に「ViewModel」が付いているクラスの、
            //  引数なしコンストラクタで生成しようとするのだと思う。
            ViewModelLocationProvider.SetDefaultViewModelFactory(type => this.container.Resolve(type));
        }
    }
}