using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.Hearthstone;
using CoreAPI = Hearthstone_Deck_Tracker.API.Core;

namespace Weasel
{
    internal class WeaselTracker
	{
        public const string tunnelerId = "CFM_095";
        private WeaselDisplay _display;
        private int weaselsInPlayerDeck = 0;
        private int weaselsInOpponnentDeck = 0;
        private int weasels = 0;

		public WeaselTracker(WeaselDisplay display)
		{
            _display = display;
			// Hide in menu, if necessary
			if (Config.Instance.HideInMenu && CoreAPI.Game.IsInMenu)
				_display.Hide();
		}

        internal void Init()
        {
            _display.UpdateNumber(0);
            _display.Hide();
        }

		// Reset on when a new game starts
		internal void GameStart()
		{
            Init();
        }

        // Reset on when a new game starts
        internal void GameEnd()
        {
            Init();
        }

        // Need to handle hiding the element when in the game menu
        internal void InMenu()
		{
			if (Config.Instance.HideInMenu)
			{
				_display.Hide();
			}
		}

        internal void OnPlayerDraw(Card card)
        {
            if (card.Id == tunnelerId)
            {

            }
        }

        internal void OnPlayerCreateInPlay(Card card)
        {
            if (card.Id == tunnelerId)
            {
                IncrementWeasels();
                if (weaselsInOpponnentDeck != 0)
                {
                    weaselsInOpponnentDeck--;
                    _display.UpdateOpponnentWeasels(weaselsInOpponnentDeck);
                }
            }
        }

        internal void OnOpponnentCreateInPlay(Card card)
        {
            if (card.Id == tunnelerId)
            {
                IncrementWeasels();
            }
        }

        internal void OnOpponnentPlay(Card card)
        {
            if (card.Id == tunnelerId)
            {
                IncrementWeasels();
            }
        }

        internal void DrawWeasel()
        {
            if (weaselsInPlayerDeck != 0)
            {
                weaselsInPlayerDeck--;
                _display.UpdatePlayerWeasels(weaselsInPlayerDeck);
            }
        }

        internal void IncrementWeasels()
        {
            weasels += 1;
            _display.UpdateNumber(weasels);
            _display.Show();
        }

        internal void OnSelectDeck(Deck deck)
        {
            weaselsInPlayerDeck = 0;
            foreach (Card card in deck.Cards)
            {
                if (card.Id == tunnelerId)
                {
                    weaselsInPlayerDeck++;
                }
            }
        }
	}
}