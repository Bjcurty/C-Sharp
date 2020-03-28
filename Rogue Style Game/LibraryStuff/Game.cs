// Class: CS/INFO 1182
// Created by: Brad Curtis
// Date: 3/16/2017
// Description - Static class to use for the project. This form contains all class related variables to be instantiated
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryStuff;

namespace LibraryStuff {
    static public class Game {

        #region Private Static Fields

        /// <summary>
        /// static variables to use for the game
        /// </summary>
        private static GameState _CurrentGameState = GameState.Default;
        private static Map _map = new Map(10, 10);
        private static Hero _Adventurer = new Hero("Bob", "The Awesomest", 10, 200, 0, 0);
        #endregion

        #region Public Properties
        public static GameState CurrentGameState {

            get {

                if (_Adventurer.isAlive() == false) {

                    _CurrentGameState = GameState.Lost;
                }

                return _CurrentGameState;
            }

            set { _CurrentGameState = value; }
        }

        public static Hero Adventurer {

            get {

                return _Adventurer;
            }
        }

        public static Map GameMap {

            get { return _map; }
        }

        public enum GameState {

            Running, Lost, Won, Default
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// This method starts/resets the game. It creates a new map and new adventurer. The adventurer will not be placed at 
        ///     a location where a potion exists
        /// </summary>
        /// <param name="height">Map rows</param>
        /// <param name="width">Map columns</param>
        static public void ResetGame(int height, int width) {

            Random rand = new Random();

            _CurrentGameState = GameState.Running;
            _map = new Map(height, width);

            int x = rand.Next(width);
            int y = rand.Next(height);

            bool heroPlaced = false;

            while (_map.Cells[y, x].HasItem && heroPlaced == false) {

                x = rand.Next(width);
                y = rand.Next(height);
            }

            if (_map.Cells[y, x].HasItem == false) {

                _Adventurer = new Hero("Bob", "The Awesomest", 10, 200, x, y);

                heroPlaced = true;
            }
            #endregion
        }
    }
}
