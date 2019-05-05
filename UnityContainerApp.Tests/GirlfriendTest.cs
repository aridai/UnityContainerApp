using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;
using UnityContainerApp.Models;

namespace UnityContainerApp.Tests
{
    [TestClass]
    public sealed class GirlfriendTest
    {
        [TestMethod]
        public void テスト用彼女が注入されていることを確認するテスト()
        {
            var container = new UnityContainer();
            container.RegisterType<Girlfriend, Alice>();
            //  container.RegisterInstance<Girlfriend>(new Alice());
            //  container.RegisterFactory<Girlfriend>(_ => new Alice());
            //  container.RegisterType<Boyfriend, Boyfriend>();

            var couple = container.Resolve<Couple>();
            Assert.AreEqual("aridaiとアリスはカップルです。", couple.ToString());
        }
    }
}