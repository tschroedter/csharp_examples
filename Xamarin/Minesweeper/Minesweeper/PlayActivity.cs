using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Autofac;
using Minesweeper.Logic.Interfaces;

namespace Minesweeper
{
    [Activity(Label = "@string/ActivityTextPlay")]
    public class PlayActivity : Activity
    {
        public IGame Game { get; private set; }
        private readonly ISettings m_Settings = new Settings(); // todo IOC
        private GridView m_GridView;
        private PlayingFieldAdapter m_MineFieldAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            m_Settings.ReadSettingFromIntent(Intent);

            SetContentView(Resource.Layout.Play);

            Initialize();

            var newGameButton = FindViewById <Button>(Resource.Id.NewGameButton);
            newGameButton.Click += OnNewGameButtonClick;

            var backButton = FindViewById <Button>(Resource.Id.BackButton);
            backButton.Click += OnBackButtonClick;
        }

        private void CreateGridView()
        {
            var layout = FindViewById <LinearLayout>(Resource.Id.MainLinearLayout);

            if ( m_GridView != null )
            {
                layout.RemoveView(m_GridView);
            }

            m_MineFieldAdapter = new PlayingFieldAdapter(this);

            m_GridView = new GridView(this)
                         {
                             NumColumns = m_Settings.NumberOfColumns,
                             Adapter = m_MineFieldAdapter
                         };

            layout.AddView(m_GridView);
        }

        private void CreateNewGame()
        {
            if ( Game == null )
            {
                Game = App.Container.Resolve <IGame>();
            }

            Game.Initialize(m_Settings.NumberOfRows,
                            m_Settings.NumberOfColumns,
                            m_Settings.NumberOfMines);
        }

        private void Initialize()
        {
            CreateNewGame();

            CreateGridView();
        }

        private void OnBackButtonClick(object sender,
                                       EventArgs eventArgs)
        {
            OnBackPressed();
        }

        private void OnNewGameButtonClick(object sender,
                                          EventArgs e)
        {
            Initialize();
        }
    }
}