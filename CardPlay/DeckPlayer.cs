using System;
using System.Collections.Generic;
using System.Text;
using CardPlay.Implementation;
using CardPlay.Interface;

namespace CardPlay
{
    public class DeckPlayer : IDeckPlayer
    {
        /// <summary>
        /// Deck service.
        /// </summary>
        private readonly IDeck _service;

        /// <summary>
        /// Application logger.
        /// </summary>
        private readonly IApplicationLogger<DeckPlayer> _logger;

        /// <summary>
        /// Initializes DeckPlayer.
        /// </summary>
        /// <param name="service">Deck Service.</param>
        /// <param name="logger">Logger Service.</param>
        public DeckPlayer(IDeck service, IApplicationLogger<DeckPlayer> logger)
        {
            this._service = service;
            this._logger = logger;
        }

        private Deck _cardDeck;

        /// <summary>
        /// Start the game.
        /// </summary>
        public void Start()
        {
            try
            {
                this._logger.Info("Game Started");
                this.Restart();
                this.Game();
            }
            catch (Exception e)
            {
                this._logger.Error("Error while playing", e);
                throw;
            }
            
        }

        /// <summary>
        /// Play the game with user.
        /// </summary>
        private void Game()
        {
            while (true)
            {
                Console.WriteLine("Please select an option below \n 0: to play a card \n 1: to shuffle the deck \n 2: to restart the game. \n 3: to exit the game.");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "0":
                        this.Play();
                        continue;
                    case "1":
                        this.Shuffle();
                        Console.WriteLine("Card shuffled");
                        continue;
                    case "2":
                        this.Restart();
                        Console.WriteLine("Game restarted");
                        continue;
                    case "3":
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please retry.");
                        continue;
                }

                break;
            }
        }

        /// <summary>
        /// Play the game.
        /// </summary>
        private void Play()
        {
            var hand = _cardDeck.Draw();
            _cardDeck.Print(hand);
        }

        /// <summary>
        /// Shuffle game.
        /// </summary>
        private void Shuffle()
        {
            _cardDeck.Shuffle();
        }

        /// <summary>
        /// Restart or Start game.
        /// </summary>
        private void Restart()
        {
            _cardDeck = new Deck();
            this.Shuffle();
        }
    }
}
