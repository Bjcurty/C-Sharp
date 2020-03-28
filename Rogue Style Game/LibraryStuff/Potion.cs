// Class: CS/INFO 1182
// Created by: Jon Holmes
// Adapted by: Brad Curtis
// Date: 3/16/2017
// Description - Class to hold potion information for the game
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace LibraryStuff {
    public class Potion : Item, IRepeatable<Potion> {

        #region Private Fields

        private Color _Color;
        #endregion

        #region Constructors

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="newName">Potion's Name</param>
        /// <param name="value">Value or Potency of the Potion</param>
        /// <param name="clr">Color of the Potion</param>
        /// 
        public Potion(String newName, int value, Color clr)
            : base(newName, value) {

            _Color = clr;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Get and Set the Potion's Color
        /// </summary>
        public enum Color {

            DarkCyan, Blue, BlueViolet, DarkRed
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Create a deep copy of this potion.
        /// </summary>
        /// <returns></returns>        
        public Potion CreateCopy() {

            return new Potion(this._Name, this._AffectValue, this._Color);
        }
        #endregion
    }
}
