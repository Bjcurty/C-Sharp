// Class: CS/INFO 1182
// Created by: Jon Holmes
// Adapted by: Brad Curtis
// Date: 3/16/2017
// Description - Class to create each individual piece that will be used in a grid
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStuff {
    public class MapCell {

        #region "Private Fields"

        private bool _HasBeenSeen;
        private Monster _Monster;
        private Item _Item;
        #endregion

        #region "Public Properties"

        /// <summary>
        /// Get or set whether the MapCell has been discovered.
        /// </summary>
        public bool HasBeenSeen {
            get {

                return _HasBeenSeen;
            }

            set {

                _HasBeenSeen = value;
            }
        }

        /// <summary>
        /// Get and set the cell's Monster
        /// </summary>
        public Monster Monster {
            get {

                return _Monster;
            }

            set {

                _Monster = value;
            }
        }
        /// <summary>
        /// Get and set the cell's Item
        /// </summary>
        public Item Item {
            get {

                return _Item;
            }

            set {

                _Item = value;
            }
        }

        /// <summary>
        /// Get or set whether the MapCell has a monster.
        /// </summary>
        public bool HasMonster {
            get {

                return _Monster != null;
            }
        }

        /// <summary>
        /// Get or set whether the MapCell has an item.
        /// </summary>
        public bool HasItem {
            get {
                
                return _Item != null;
            }
        }
        #endregion
    }
}
