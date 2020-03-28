// Class: CS/INFO 1182
// Created by: Jon Holmes
// Adapted by: Brad Curtis
// Date: 4/6/2017
// Description - Class to represent weapons in the game
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryObjects {
    [Serializable]
    public class Weapon : Item, IRepeatable<Weapon> {

        #region Private Fields

        private int _SpeedModifier;
        #endregion

        #region Constructor
        /// <summary>
        /// Overloaded Constructor
        /// </summary>
        /// <param name="wName">Name of the Weapon</param>
        /// <param name="wValue">Amount of damage the weapon can do</param>
        /// <param name="wSpeedModifier">How much this weapon affects the hero's attack speed.</param>
        public Weapon(String wName, int wValue, int wSpeedModifier) : base(wName, wValue) {

            _SpeedModifier = wSpeedModifier;
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// How much the hero's speed is modified when this weapon is equipped
        /// </summary>
        public int SpeedModifier {
            get {

                return _SpeedModifier;
            }
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Create a deep copy of this weapon.
        /// </summary>
        /// <returns></returns>
        public Weapon CreateCopy() {

            return new Weapon(this.Name, this.AffectValue, this.SpeedModifier);
        }
        #endregion
    }
}
