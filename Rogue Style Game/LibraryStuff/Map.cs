// Class: CS/INFO 1182
// Created by: Jon Holmes
// Adapted by: Brad Curtis
// Date: 3/16/2017
// Description - Map to hold a collction of MapCells
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using LibraryStuff;

namespace LibraryStuff {
    public class Map {
        #region Private Variables

        private MapCell[,] _Cells = null;
        private List<Monster> _Monsters = new List<Monster>();
        private List<Item> _Items = new List<Item>();
        private Hero _Adventurer;
        #endregion

        #region Constructors

        /// <summary>
        /// Create and fill the Map
        /// </summary>
        /// <param name="rows">Number of Rows the map should have</param>
        /// <param name="cols">Number of Columns the map should have</param>
        public Map(int rows, int cols) {

            _Cells = new MapCell[rows, cols];

            FillMonsters();

            FillItems();

            FillMap();
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Get all of the cells of the map
        /// </summary>
        public MapCell[,] Cells {
            get {

                if (_Cells == null) FillMap();

                return _Cells;
            }

            set {

                _Cells = value;
            }
        }

        /// <summary>
        /// Get and Set the Adventurer on the Map
        /// </summary>
        public Hero Adventurer {
            get {

                return _Adventurer;
            }

            set {

                _Adventurer = value;
            }
        }

        public MapCell ReturnPosition() {

            //the hero exists
            if (Game.Adventurer != null) {
                
                //Map cell where the hero is currently
                return Game.GameMap.Cells[Game.Adventurer.PositionX, Game.Adventurer.PositionY];
            }

            //the hero doesn't exist
            else {

                return new MapCell();
            }
        }

        public int MonsterCount() {

            return CountMonster();
        }

        public int ItemCount() {

            return CountItem();
        }

        public decimal DiscoveredCount() {

            return CalculateDiscovered();
        }
        #endregion

        #region Private Properties

        /// <summary>
        /// Get the List of Monsters available on our map
        /// </summary>
        private List<Monster> Monsters {
            get {

                return _Monsters;
            }
        }
        /// <summary>
        /// Get the List of Potions available on our map
        /// </summary>
        private List<Item> Items {
            get {

                return _Items;
            }
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Fill the List of Potions
        /// </summary>
        private void FillItems() {

            _Items.Add(new Potion("Small Healing Potion", 25, Potion.Color.DarkCyan));
            _Items.Add(new Potion("Medium Healing Potion", 50, Potion.Color.Blue));
            _Items.Add(new Potion("Large Healing Potion", 100, Potion.Color.BlueViolet));
            _Items.Add(new Potion("Extreme Healing Potion", 200, Potion.Color.DarkRed));
            _Items.Add(new Weapon("Dagger", 10, -1));
            _Items.Add(new Weapon("Club", 20, -3));
            _Items.Add(new Weapon("Sword", 30, -2));
            _Items.Add(new Weapon("Claymore", 40, -4));
        }

        /// <summary>
        /// Fill the List of Monsters
        /// </summary>
        private void FillMonsters() {

            Monsters.Add(new Monster("Orc", "", 3, 100, 0, 0, 10));
            Monsters.Add(new Monster("Goblin", "", 1, 30, 0, 0, 5));
            Monsters.Add(new Monster("Slug", "", 5, 3, 0, 0, 2));
            Monsters.Add(new Monster("Rat", "", 0, 5, 0, 0, 1));
            Monsters.Add(new Monster("Skeleton", "", 4, 70, 0, 0, 7));
        }

        /// <summary>
        /// Fill the map with empty MapCells
        /// </summary>
        public void FillMap() {

            int rows = Game.GameMap.Cells.GetLength(0);
            int cols = Game.GameMap.Cells.GetLength(1);

            Random rand = new Random();

            int x = rand.Next(rows);
            int y = rand.Next(cols);

            Door door = new Door("Door", 5, "123");
            DoorKey doorKey = new DoorKey("Key", 5, "123");

            for (int row = 0; row < rows; row++) {
                for (int col = 0; col < cols; col++) {

                    int jackpot = rand.Next(0, 6);

                    Game.GameMap.Cells[row, col] = new MapCell();

                    if (jackpot == 3) {

                        int pickItem = rand.Next(0, 4);

                        if(pickItem == 0) {

                            Game.GameMap.Cells[row, col].Item = ((Potion)_Items[rand.Next(0, 4)]).CreateCopy();
                        }

                        else if (pickItem == 1) {

                            Game.GameMap.Cells[row, col].Item = ((Weapon)_Items[rand.Next(4, 8)]).CreateCopy();
                        }

                        else if (pickItem == 2) {

                            Game.GameMap.Cells[row, col].Monster = _Monsters[rand.Next(_Monsters.Count)].CreateCopy();
                        }
                    }
                }
            }

            for (int j = 0; j < 2; j++) {

                while (Game.GameMap.Cells[x, y].Item != null || Game.GameMap.Cells[x, y].Monster != null) {

                    x = rand.Next(rows);
                    y = rand.Next(cols);
                }

                if (Game.GameMap.Cells[x, y].Item == null && Game.GameMap.Cells[x, y].Monster == null) {

                    if (j == 0) {

                        Game.GameMap.Cells[x, y].Item = door;
                    }

                    else if (j == 1) {

                        Game.GameMap.Cells[x, y].Item = doorKey;
                    }
                }
            }

        }

        public bool MoveHero(Actor.Direction dir) {

            Game.GameMap.Cells[Game.Adventurer.PositionX, Game.Adventurer.PositionY].HasBeenSeen = true;

            if (dir == Actor.Direction.Up) {

                if(Game.Adventurer.PositionY > 0) {

                    Game.Adventurer.Move(Actor.Direction.Up);
                }
            }

            if (dir == Actor.Direction.Down) {

                if (Game.Adventurer.PositionY < 10) {

                    Game.Adventurer.Move(Actor.Direction.Down);
                }
            }

            if (dir == Actor.Direction.Left) {

                if (Game.Adventurer.PositionX > 0 ) {

                    Game.Adventurer.Move(Actor.Direction.Left);
                }
            }

            if (dir == Actor.Direction.Right) {

                if (Game.Adventurer.PositionY < 8) {

                    Game.Adventurer.Move(Actor.Direction.Right);
                }
            }

            if ((Game.GameMap.Cells[Game.Adventurer.PositionX, Game.Adventurer.PositionY].HasBeenSeen && Game.GameMap.Cells[Game.Adventurer.PositionX, Game.Adventurer.PositionY].Monster != null) ||
                (Game.GameMap.Cells[Game.Adventurer.PositionX, Game.Adventurer.PositionY].HasBeenSeen && Game.GameMap.Cells[Game.Adventurer.PositionX, Game.Adventurer.PositionY].Item != null)){

                return true;
            }

            else {

                return false;
            }
        }

        public int CountMonster() {

            int rows = Game.GameMap.Cells.GetLength(0);
            int cols = Game.GameMap.Cells.GetLength(1);

            int monsterCount = 0;

            for (int row = 0; row < rows; row++) {
                for (int col = 0; col < cols; col++) {

                    if (Game.GameMap.Cells[row, col].HasMonster != false) {

                        monsterCount++;
                    }
                }
            }

            return monsterCount;
        }

        public int CountItem() {

            int rows = Game.GameMap.Cells.GetLength(0);
            int cols = Game.GameMap.Cells.GetLength(1);

            int itemCount = 0;

            for (int row = 0; row < rows; row++) {
                for (int col = 0; col < cols; col++) {

                    if (Game.GameMap.Cells[row, col].HasItem != false) {

                        itemCount++;
                    }
                }
            }

            return itemCount;
        }

        public decimal CalculateDiscovered() {

            int rows = Game.GameMap.Cells.GetLength(0);
            int cols = Game.GameMap.Cells.GetLength(1);

            int discoveredCount = 0;

            for (int row = 0; row < rows; row++) {
                for (int col = 0; col < cols; col++) {

                    if (Game.GameMap.Cells[row, col].HasMonster != false) {

                        discoveredCount++;
                    }
                }
            }

            return discoveredCount/ (rows * cols);
        }
        #endregion


    }
}
