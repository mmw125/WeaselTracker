using System.Collections.Generic;
using System.Linq;
using HearthDb.Enums;
using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Enums;
using Hearthstone_Deck_Tracker.Hearthstone;
using Hearthstone_Deck_Tracker.Hearthstone.Entities;
using CoreAPI = Hearthstone_Deck_Tracker.API.Core;

namespace Weasel
{

    internal class WeaselTracker
	{
        public const string tunnelerId = "CFM_095";
        private WeaselDisplay _display;
        private int weasels = 0;

		public WeaselTracker(WeaselDisplay display)
		{
            _display = display;
			// Hide in menu, if necessary
			if (Config.Instance.HideInMenu && CoreAPI.Game.IsInMenu)
				_display.Hide();
		}

		// Reset on when a new game starts
		internal void GameStart()
		{
            _display.UpdateNumber(0);
            _display.Hide();
        }

        // Reset on when a new game starts
        internal void GameEnd()
        {
            _display.UpdateNumber(0);
            _display.Hide();
        }

        // Need to handle hiding the element when in the game menu
        internal void InMenu()
		{
			if (Config.Instance.HideInMenu)
			{
				_display.Hide();
			}
		}

        internal void OnCreateInPlay(Card card)
        {
            if (card.Id == tunnelerId)
            {
                weasels += 1;
                _display.UpdateNumber(weasels);
                _display.Show();
            }
        }
	}
}