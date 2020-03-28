// Class: CS/INFO 1182
// Created by: Jon Holmes
// Adapted by: Brad Curtis
// Date: 3/16/2017
// Description - Abstract class used as a blueprint for inherited classes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStuff {
    public abstract class Item {

        #region Protected Fields

        protected String _Name;
        protected int _AffectValue;
        #endregion

        #region Public Properties

        /// <summary>
        /// Overloaded contstructor to create an Item.
        /// </summary>
        /// <param name="myName">Name of the item</param>
        /// <param name="value"></param>
        public Item(String myName, int value) {

            Name = myName;
            AffectValue = value;
        }

        /// <summary>
        /// Get and Set Item Name
        /// </summary>
        public string Name {

            get {

                return _Name;
            }

            set {

                _Name = value;
            }
        }

        /// <summary>
        /// Get and Set Item Affect Value; this is the value of how
        ///  much can cause as an effect.
        /// </summary>
        public int AffectValue {

            get {

                return _AffectValue;
            }

            set {
                _AffectValue = value;
            }
        }
        #endregion
    }
}
