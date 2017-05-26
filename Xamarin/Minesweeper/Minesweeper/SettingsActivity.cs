using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Text;
using Android.Widget;

namespace Minesweeper
{
    [Activity(Label = "@string/ActivityTextSettings")]
    public class SettingsActivity : Activity
    {
        private readonly ISettings m_Settings = new Settings(); // todo IOC
        private EditText m_NumberOfColumns;
        private EditText m_NumberOfMines;
        private EditText m_NumberOfRows;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            m_Settings.ReadSettingFromIntent(Intent);

            SetContentView(Resource.Layout.Settings);

            var applyButton = FindViewById <Button>(Resource.Id.SettingsApplyButton);
            applyButton.Click += OnApplyButtonClick;

            var cancelButton = FindViewById <Button>(Resource.Id.SettingsCancelButton);
            cancelButton.Click += OnBackButtonClick;

            m_NumberOfRows = FindViewById <EditText>(Resource.Id.NumberOfRows);
            m_NumberOfColumns = FindViewById <EditText>(Resource.Id.NumberOfColumns);
            m_NumberOfMines = FindViewById <EditText>(Resource.Id.NumberOfMines);

            UpdateViewFromSettings();
        }

        private void OnApplyButtonClick(object sender,
                                        EventArgs eventArgs)
        {
            UpdateSettingsFromView();

            var intent = new Intent(this,
                                    typeof( MainActivity ));

            m_Settings.WriteSettingToIntent(intent);

            StartActivity(intent);
        }

        private void OnBackButtonClick(object sender,
                                       EventArgs eventArgs)
        {
            OnBackPressed();
        }

        private void UpdateSettingsFromView()
        {
            int rows = int.Parse(m_NumberOfRows.Text);
            int columns = int.Parse(m_NumberOfColumns.Text);
            int mines = int.Parse(m_NumberOfMines.Text);

            m_Settings.NumberOfRows = rows;
            m_Settings.NumberOfColumns = columns;
            m_Settings.NumberOfMines = mines;
        }

        private void UpdateViewFromSettings()
        {
            m_NumberOfRows.SetFilters(new IInputFilter[]
                                      {
                                          new MinMaxInputFilter(3,
                                                                9)
                                      });
            m_NumberOfRows.Text = m_Settings.NumberOfRows.ToString();

            m_NumberOfColumns.SetFilters(new IInputFilter[]
                                         {
                                             new MinMaxInputFilter(3,
                                                                   9)
                                         });
            m_NumberOfColumns.Text = m_Settings.NumberOfColumns.ToString();

            m_NumberOfMines.SetFilters(new IInputFilter[]
                                       {
                                           new MinMaxInputFilter(1,
                                                                 9)
                                       });
            m_NumberOfMines.Text = m_Settings.NumberOfMines.ToString();
        }
    }
}