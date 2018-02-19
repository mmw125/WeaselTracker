﻿using System;
using System.Windows.Controls;
using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Plugins;

namespace Weasel
{
	public class WeaselPlugin : IPlugin
	{
		private WeaselDisplay _display;

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
			WeaselTracker tracker = new WeaselTracker(_display);

            GameEvents.OnGameStart.Add(tracker.GameStart);
            GameEvents.OnGameEnd.Add(tracker.GameEnd);
            DeckManagerEvents.OnDeckSelected.Add(tracker.OnSelectDeck);

            GameEvents.OnPlayerCreateInPlay.Add(tracker.OnPlayerPlay);
            GameEvents.OnPlayerPlay.Add(tracker.OnPlayerPlay);

            GameEvents.OnOpponentCreateInPlay.Add(tracker.OnOpponentCreateInPlay);
            GameEvents.OnOpponentPlay.Add(tracker.OnOpponentPlay);
        }

		public void OnUnload()
		{
			Core.OverlayCanvas.Children.Remove(_display);
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