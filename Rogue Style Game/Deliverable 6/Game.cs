// Class: CS/INFO 1182
// Created by: Brad Curtis
// Date: 4/6/2017
// Description - Static class to use for the project. This form contains all class related variables to be instantiated
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryObjects;

namespace Deliverable_6 {
    static public class Game {

        #region Private Static Fields

        /// <summary>
        /// static variables to use for the game
        /// </summary>
        private static GameState _CurrentGameState = GameState.Default;
        private static Map _map = new Map(10, 10);
        private static List<Hero> _heroes = new List<Hero>();
        #endregion

        #region Public Properties
        public static List<Hero> Heroes {

            get { return _heroes; }

        }
        public static GameState CurrentGameState {

            get {

                if (_map.Adventurer == null) {

                    _CurrentGameState = GameState.Default;
                }

                else if (_map.Adventurer.isAlive() == false) {

                    _CurrentGameState = GameState.Lost;
                }

                return _CurrentGameState;
            }

            set { _CurrentGameState = value; }
        }

        public static Hero Adventurer {

            get {

                return _map.Adventurer;
            }

            set { _map.Adventurer = value; }
        }

        public static Map GameMap {

            get { return _map; }
            set { _map = value; }
        }

        public enum GameState {

            Running, Lost, Won, Default
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// This method starts/resets the game. It creates a new map and new adventurer. The adventurer will not be placed at 
        ///     a location where an item or monster exists
        /// </summary>
        /// <param name="height">Map rows</param>
        /// <param name="width">Map columns</param>
        static public void ResetGame(int height, int width) {

            _CurrentGameState = GameState.Running;

            _map = new Map(height, width);

            Character _character = new Character();

            _character.ShowDialog();

            foreach (Hero h in Heroes) {

                if (h.Picked == true) {

                    Adventurer = h;

                    break;
                }
            }

            Random rand = new Random();

            int x = rand.Next(width);
            int y = rand.Next(height);

            bool heroPlaced = false;

            while (_map.Cells[y, x].HasItem || _map.Cells[y, x].HasMonster && heroPlaced == false) {

                x = rand.Next(width);
                y = rand.Next(height);
            }

            if (Adventurer == null) {

                System.Windows.MessageBox.Show("Please select a Hero.");

                return;
            }

            if (_map.Cells[y, x].HasItem == false && _map.Cells[y, x].HasMonster == false) {

                Adventurer.PositionX = x;
                Adventurer.PositionY = y;

                _map.Cells[y, x].HasBeenSeen = true;

                heroPlaced = true;
            }

            foreach (Hero h in Heroes) {

                h.Picked = false;
                h.RemoveKey();
                h.RemoveWeapon();
                h.IsRunningAway = false;
                h.healMe(h.MaximumHitPoints);
            }
        }

        static public void AddHeroes() {

            _heroes.Add(new Hero("Malcom Reynolds", "Mal", 6, 200, 0, 0, false));
            _heroes.Add(new Hero("Zoe Washburne", "Zoe", 5, 225, 0, 0, false));
            _heroes.Add(new Hero("Hoban Wasburne", "Wash", 6, 175, 0, 0, false));
            _heroes.Add(new Hero("Inara Serra", "Inara", 5, 175, 0, 0, false));
            _heroes.Add(new Hero("Jayne Cobb", "Jayne", 4, 200, 0, 0, false));
            _heroes.Add(new Hero("Kaylee Frye", "Kaylee", 4, 200, 0, 0, false));
            _heroes.Add(new Hero("Simon Tam", "Simon", 6, 200, 0, 0, false));
            _heroes.Add(new Hero("River Tam", "River", 6, 175, 0, 0, false));
            _heroes.Add(new Hero("Derrial Book", "Shepard Book", 5, 225, 0, 0, false));
        }
        static public void ResetGame() {

            _CurrentGameState = GameState.Running;

            _map = new Map(GameMap.Cells.GetLength(0), GameMap.Cells.GetLength(1));

            Character _character = new Character();

                _character.ShowDialog();

            foreach (Hero h in Heroes) {

                if (h.Picked == true) {

                    Adventurer = h;

                    break;
                }
            }

            Random rand = new Random();

            int x = rand.Next(GameMap.Cells.GetLength(0));
            int y = rand.Next(GameMap.Cells.GetLength(1));

            bool heroPlaced = false;

            while (_map.Cells[y, x].HasItem || _map.Cells[y, x].HasMonster && heroPlaced == false) {

                x = rand.Next(GameMap.Cells.GetLength(0));
                y = rand.Next(GameMap.Cells.GetLength(1));
            }

            if (Adventurer == null) {

                System.Windows.MessageBox.Show("Please select a Hero.");

                return;
            }

            if (_map.Cells[y, x].HasItem == false && _map.Cells[y, x].HasMonster == false) {

                Adventurer.PositionX = x;
                Adventurer.PositionY = y;

                _map.Cells[y, x].HasBeenSeen = true;

                heroPlaced = true;
            }

            foreach (Hero h in Heroes) {

                h.Picked = false;
                h.RemoveKey();
                h.RemoveWeapon();
                h.IsRunningAway = false;
                h.healMe(h.MaximumHitPoints);
            }
        }
        #endregion
    }
}
