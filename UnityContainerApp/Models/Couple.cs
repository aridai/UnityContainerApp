using System;
using Unity;

namespace UnityContainerApp.Models
{
    //  Girlfriendはコンストラクタインジェクションで、
    //  Boyfriendはフィールドインジェクションで依存性の注入をしてみる。
    //  フィールド・プロパティインジェクションは外からアクセスできるセッタが必要みたい。

    public sealed class Couple
    {
        [Dependency]
        internal Boyfriend boyfriend;

        public Girlfriend Girlfriend { get; }

        public Boyfriend Boyfriend => this.boyfriend;

        [InjectionConstructor]
        public Couple([Dependency]Girlfriend girlfriend)
        {
            this.Girlfriend = girlfriend;
        }

        public override string ToString() => $"{this.Boyfriend.Name}と{this.Girlfriend.Name}はカップルです。";
    }
}