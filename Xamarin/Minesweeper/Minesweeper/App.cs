using System;
using Android.App;
using Android.Runtime;
using Autofac;
using Minesweeper.Logic;

namespace Minesweeper
{
    [Application(Icon = "@drawable/icon", Label = "@string/app_name")]
    public class App : Application
    {
        public App(IntPtr h,
                   JniHandleOwnership jho)
            : base(h,
                   jho)
        {
        }

        public static IContainer Container { get; set; }

        public override void OnCreate()
        {
            var builder = new ContainerBuilder();
            var installer = new Installer(builder);

            Container = builder.Build();

            base.OnCreate();
        }
    }
}