using System;
using System.Windows.Controls;
using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Plugins;

namespace Weasel
{
	public class WeaselPlugin : IPlugin
	{
		private WeaselDisplay _display;
        private WeaselTracker _tracker;

		public string Author
		{
			get { return "mmw125"; }
		}

		public string ButtonText
		{
			get { return "Settings"; }
		}

		public string Description
		{
			get { return "Displays the number of weasels in opponnent's deck and hand."; }
		}

		public MenuItem MenuItem
		{
			get { return null; }
		}

		public string Name
		{
			get { return "Weasel Tracker"; }
		}

		public void OnButtonPress()
		{
		}

		public void OnLoad()
		{
			_display = new WeaselDisplay();
			Core.OverlayCanvas.Children.Add(_display);
            _tracker = new WeaselTracker(_display);
            Core.OverlayCanvas.Children.Add(_tracker.GetDisplay());

            GameEvents.OnGameStart.Add(_tracker.GameStart);
            GameEvents.OnGameEnd.Add(_tracker.GameEnd);
            DeckManagerEvents.OnDeckSelected.Add(_tracker.OnSelectDeck);

            GameEvents.OnPlayerCreateInPlay.Add(_tracker.OnPlayerPlay);
            GameEvents.OnPlayerPlay.Add(_tracker.OnPlayerPlay);
            GameEvents.OnPlayerDeckDiscard.Add(_tracker.OnPlayerDraw);
            GameEvents.OnPlayerCreateInDeck.Add(_tracker.OnPlayerCreateInDeck);

            GameEvents.OnOpponentCreateInPlay.Add(_tracker.OnOpponentCreateInPlay);
            GameEvents.OnOpponentPlay.Add(_tracker.OnOpponentPlay);
            GameEvents.OnOpponentHandDiscard.Add(_tracker.OnOppenentDiscard);
            GameEvents.OnOpponentDeckDiscard.Add(_tracker.OnOppenentDiscard);
            GameEvents.OnOpponentCreateInDeck.Add(_tracker.OnOpponentCreateInDeck);
        }

		public void OnUnload()
		{
			Core.OverlayCanvas.Children.Remove(_display);
            Core.OverlayCanvas.Children.Remove(_tracker.GetDisplay());
        }

		public void OnUpdate()
		{
		}

		public Version Version
		{
			get { return new Version(0, 1, 1); }
		}
	}
}