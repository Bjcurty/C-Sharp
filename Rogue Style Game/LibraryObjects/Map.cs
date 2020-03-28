// Class: CS/INFO 1182
// Created by: Jon Holmes
// Adapted by: Brad Curtis
// Date: 4/6/2017
// Description - Map to hold a collction of MapCells
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryObjects {
    [Serializable]
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

        /// <summary>
        /// Returns the mapcell that the Hero is in
        /// </summary>
        public MapCell ReturnPosition() {

            //the hero exists
            if (Adventurer != null) {

                //Map cell where the hero is currently
                return Cells[Adventurer.PositionX, Adventurer.PositionY];
            }

            //the hero doesn't exist
            else {

                return new MapCell();
            }
        }

        /// <summary>
        /// Counts the monsters in the MapCell[]
        /// </summary>
        public int MonsterCount() {

            return CountMonster();
        }

        /// <summary>
        /// Counts the items in the MapCell[]
        /// </summary>
        public int ItemCount() {

            return CountItem();
        }

        /// <summary>
        /// Calculates the percentage of discovered cells in the MapCell[]
        /// </summary>
        public decimal DiscoveredCount() {

            return CalculateDiscovered();
        }
        #endregion

        #region Private Properties

        /// <summary>
        /// Get the List of Monsters available on our map
        /// </summary>
        public List<Monster> Monsters {
            get {

                return _Monsters;
            }

            set { _Monsters = value; }
        }
        /// <summary>
        /// Get the List of Potions available on our map
        /// </summary>
        public List<Item> Items {
            get {

                return _Items;
            }

            set { _Items = value; }
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Fill the List of Items
        /// </summary>
        private void FillItems() {

            _Items.Add(new Potion("Bandage", 25, Potion.Color.DarkCyan));
            _Items.Add(new Potion("Pain Meds", 50, Potion.Color.Blue));
            _Items.Add(new Potion("Health Tonic", 100, Potion.Color.BlueViolet));
            _Items.Add(new Potion("Doctor in a bag", 150, Potion.Color.DarkRed));
            _Items.Add(new Weapon("Sword", 10, 0));
            _Items.Add(new Weapon("Pistol", 20, 0));
            _Items.Add(new Weapon("Shotgun", 30, 0));
            _Items.Add(new Weapon("Machine Gun", 40, 0));
        }

        /// <summary>
        /// Fill the List of Monsters
        /// </summary>
        private void FillMonsters() {

                Monsters.Add(new Monster("Men in Blue", "", 5, 200, 0, 0, 35));
                Monsters.Add(new Monster("Alliance Soldier", "", 3, 150, 0, 0, 15));
                Monsters.Add(new Monster("Reaver", "", 6, 300, 0, 0, 50));
                Monsters.Add(new Monster("Alliance Spy", "", 4, 100, 0, 0, 20));
                Monsters.Add(new Monster("Random Hoodlum", "", 3, 50, 0, 0, 5));  
        }

        /// <summary>
        /// Fill the map with empty MapCells
        /// </summary>
        public void FillMap() {

            int rows = Cells.GetLength(0);
            int cols = Cells.GetLength(1);

            Random rand = new Random();

            int x = rand.Next(rows);
            int y = rand.Next(cols);

            Door door = new Door("Door", 5, "123");
            DoorKey doorKey = new DoorKey("Key", 5, "123");

            for (int row = 0; row < rows; row++) {
                for (int col = 0; col < cols; col++) {

                    int jackpot = rand.Next(0, 5);

                    Cells[row, col] = new MapCell();

                    if (jackpot == 3) {

                        int pickItem = rand.Next(0, 5);

                        if (pickItem == 0 || pickItem == 3) {

                            Cells[row, col].Item = ((Potion)_Items[rand.Next(0, 4)]).CreateCopy();
                        }

                        else if (pickItem == 1) {

                            Cells[row, col].Item = ((Weapon)_Items[rand.Next(4, 8)]).CreateCopy();
                        }

                        else if (pickItem == 2 || pickItem == 4) {

                            Cells[row, col].Monster = _Monsters[rand.Next(_Monsters.Count)].CreateCopy();                          
                        }
                    }
                }
            }

            for (int j = 0; j < 2; j++) {

                while (Cells[x, y].Item != null || Cells[x, y].Monster != null) {

                    x = rand.Next(rows);
                    y = rand.Next(cols);
                }

                if (Cells[x, y].Item == null && Cells[x, y].Monster == null) {

                    if (j == 0) {

                        Cells[x, y].Item = door;
                    }

                    else if (j == 1) {

                        Cells[x, y].Item = doorKey;
                    }
                }
            }

        }

        /// <summary>
        /// Moves Actor as long as it wont go off the GameMap. Returns true if the Hero enters a cell occupied by a Monster or Item
        /// </summary>
        public bool MoveHero(Actor.Direction dir) {

            if (dir == Actor.Direction.Up) {

                if (Adventurer.PositionY > 0) {

                    Adventurer.Move(Actor.Direction.Up);

                    Cells[Adventurer.PositionY, Adventurer.PositionX].HasBeenSeen = true;
                }
            }

            if (dir == Actor.Direction.Down) {

                if (Adventurer.PositionY < 9) {

                    Adventurer.Move(Actor.Direction.Down);

                    Cells[Adventurer.PositionY, Adventurer.PositionX].HasBeenSeen = true;
                }
            }

            if (dir == Actor.Direction.Left) {

                if (Adventurer.PositionX > 0) {

                    Adventurer.Move(Actor.Direction.Left);

                    Cells[Adventurer.PositionY, Adventurer.PositionX].HasBeenSeen = true;
                }
            }

            if (dir == Actor.Direction.Right) {

                if (Adventurer.PositionX < 9) {

                    Adventurer.Move(Actor.Direction.Right);

                    Cells[Adventurer.PositionY, Adventurer.PositionX].HasBeenSeen = true;
                }
            }

            if (Cells[Adventurer.PositionY, Adventurer.PositionX].HasItem) {

                return true;
            }

            if (Cells[Adventurer.PositionY, Adventurer.PositionX].HasMonster) {

                return true;
            }

            else {

                return false;
            }
        }

        /// <summary>
        /// Counts the number of monsters in the map
        /// </summary>
        public int CountMonster() {

            int rows = Cells.GetLength(0);
            int cols = Cells.GetLength(1);

            int monsterCount = 0;

            for (int row = 0; row < rows; row++) {
                for (int col = 0; col < cols; col++) {

                    if (Cells[row, col].HasMonster != false) {

                        monsterCount++;
                    }
                }
            }

            return monsterCount;
        }

        /// <summary>
        /// Counts the number of Items in the map
        /// </summary>
        public int CountItem() {

            int rows = Cells.GetLength(0);
            int cols = Cells.GetLength(1);

            int itemCount = 0;

            for (int row = 0; row < rows; row++) {
                for (int col = 0; col < cols; col++) {

                    if (Cells[row, col].HasItem != false) {

                        itemCount++;
                    }
                }
            }

            return itemCount;
        }

        /// <summary>
        /// Calculates the percantage of discovered cells in the map
        /// </summary>
        public decimal CalculateDiscovered() {

            decimal rows = Cells.GetLength(0);
            decimal cols = Cells.GetLength(1);

            int discoveredCount = 0;

            for (int row = 0; row < rows; row++) {
                for (int col = 0; col < cols; col++) {

                    if (Cells[row, col].HasBeenSeen) {

                        discoveredCount++;
                    }
                }
            }

            return (int)((discoveredCount / (rows * cols)) * 100);
        }
        #endregion
    }
}
