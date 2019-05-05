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
            //  Debug/ReleaseでDIの設定を切り替えている。

#if DEBUG
            this.RegisterDependenciesForDebug();
#else
            this.RegisterDependenciesForRelease();
#endif

            //  AutoWireViewModelを有効にしたViewに流し込むViewModelを設定する。
            //  ViewModelLocatorはViewの名前の末尾に「ViewModel」が付いているクラスの、
            //  引数なしコンストラクタで生成しようとするのだと思う。
            ViewModelLocationProvider.SetDefaultViewModelFactory(type => this.container.Resolve(type));
        }

        //  リリースビルド用に依存関係の登録を行う。
        private void RegisterDependenciesForRelease()
        {
            //  インターフェースと具象型を紐付ける。
            //  これは引数なしコンストラクタを持つため、型での紐付けで良い。
            this.container.RegisterType<Girlfriend, Marisa>();

            //  引数なしコンストラクタを持つ具象型の場合は別に書かなくてもいい。
            //  this.container.RegisterType<Boyfriend, Boyfriend>();

            //  インターフェースとインスタンスを紐付ける。
            //  この場合はシングルトンになると思われる。
            //  this.container.RegisterInstance<Couple>(new Couple(this.container.Resolve<Girlfriend>()));

            //  コンストラクタの全ての引数が解決できる型である場合はこのようにも書ける。
            //  this.container.RegisterType<Couple, Couple>();

            //  もしくは、今回のように具象型ならば、別に書かなくてもいい。

            //  これも、具象型かつコンストラクタの全ての引数が解決できるため、別に書かなくてもいい。
            //  this.container.RegisterInstance<MainWindowViewModel>(new MainWindowViewModel(this.container.Resolve<Couple>()));
        }

        //  デバッグビルド用に依存関係の登録を行う。
        private void RegisterDependenciesForDebug()
        {
            this.container.RegisterType<Girlfriend, Alice>();
        }
    }
}