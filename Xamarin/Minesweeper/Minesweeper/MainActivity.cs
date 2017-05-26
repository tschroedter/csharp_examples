using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Autofac;

namespace Minesweeper
{
    [Activity(Label = "Minesweeper", MainLauncher = true, Icon = "@drawable/MineExplosion")]
    public class MainActivity : Activity
    {
        private readonly ISettings m_Settings = new Settings(); // todo IOC

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            m_Settings.ReadSettingFromIntent(Intent);

            SetContentView(Resource.Layout.Main);

            using ( ILifetimeScope scope = App.Container.BeginLifetimeScope() )
            {
                // todo viewModel = App.Container.Resolve<MainViewModel>();
            }

            var playButton = FindViewById <Button>(Resource.Id.PlayButton);
            var settingsButton = FindViewById <Button>(Resource.Id.SettingsButton);
            var exitButton = FindViewById <Button>(Resource.Id.ExitButton);

            playButton.Click +=
                (sender,
                 args) =>
                {
                    PlayButtonClicked();
                };

            settingsButton.Click +=
                (sender,
                 args) =>
                {
                    SettingsButtonClicked();
                };

            exitButton.Click +=
                (sender,
                 args) =>
                {
                    ExitButtonClicked();
                };
        }

        private void ExitButtonClicked()
        {
            Process.KillProcess(Process.MyPid());
        }

        private void PlayButtonClicked()
        {
            var intent = new Intent(this,
                                    typeof( PlayActivity ));

            m_Settings.WriteSettingToIntent(intent);

            StartActivity(intent);
        }

        private void SettingsButtonClicked()
        {
            var intent = new Intent(this,
                                    typeof( SettingsActivity ));

            m_Settings.WriteSettingToIntent(intent);

            StartActivity(intent);
        }
    }
}