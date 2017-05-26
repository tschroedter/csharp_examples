using System;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Minesweeper.Logic.Interfaces;
using Object = Java.Lang.Object;

namespace Minesweeper
{
    public class PlayingFieldAdapter
        : BaseAdapter
    {
        public PlayingFieldAdapter(PlayActivity activity)
        {
            m_Activity = activity;
            m_Game = activity.Game;

            FillInformation();
        }

        public override int Count
        {
            get
            {
                return Information.Count;
            }
        }

        private readonly PlayActivity m_Activity;
        private readonly IGame m_Game;
        public List <PlayingFieldInformation> Information = new List <PlayingFieldInformation>();

        public override Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return Information [ position ].Id;
        }

        public override View GetView(int position,
                                     View convertView,
                                     ViewGroup parent)
        {
            View view = convertView ??
                        m_Activity.LayoutInflater.Inflate(Resource.Layout.PlayingFieldItem,
                                                          parent,
                                                          false);

            var button = view.FindViewById <Button>(Resource.Id.DisplayFieldButton);

            if ( button != null )
            {
                PlayingFieldInformation information = Information [ position ];

                button.SetBackgroundResource(information.BackgroundResource);
                button.Click += OnHintButtonClick;
                button.Id = position;
                button.Text = information.DisplayText;
            }

            return view;
        }

        private void FillInformation()
        {
            Information.Clear();

            var id = 0;

            for ( var row = 0 ; row < m_Game.RowsCount ; row++ )
                for ( var column = 0 ; column < m_Game.ColumnsCount ; column++ )
                {
                    int hint = m_Game.GetHintFor(row,
                                                 column);

                    var info = new PlayingFieldInformation
                               {
                                   Id = id++,
                                   Hint = hint,
                                   Row = row,
                                   Column = column,
                                   IsSelected = false,
                                   DisplayText = ".",
                                   BackgroundResource = Resource.Drawable.AtSea
                               };

                    Information.Add(info);
                }
        }

        private void OnHintButtonClick(object sender,
                                       EventArgs e)
        {
            var button = sender as Button;

            if ( ( button == null ) ||
                 ValidateButtonClick(button) )
            {
                return;
            }

            PlayingFieldInformation information = Information [ button.Id ];

            if ( information.Hint == -1 )
            {
                button.SetBackgroundResource(Resource.Drawable.MineExplosion);
                button.SetText(Resource.String.Boom);
            }
            else
            {
                button.Text = information.Hint.ToString();
            }

            PlayOneRound(information.Row,
                         information.Column);
        }

        private void PlayOneRound(int row,
                                  int column)
        {
            m_Game.PlayOneRound(row,
                                column);

            if ( !m_Game.IsGameFinished(m_Game.Status) )
            {
                return;
            }

            Toast.MakeText(m_Activity,
                           m_Game.GameStatusToString(m_Game.Status),
                           ToastLength.Short).Show();
        }

        private bool ValidateButtonClick(Button button)
        {
            if ( button == null )
            {
                return true;
            }

            if ( button.Text != "." )
            {
                Toast.MakeText(m_Activity,
                               "You already selected this field!",
                               ToastLength.Short).Show();
            }
            return false;
        }
    }
}