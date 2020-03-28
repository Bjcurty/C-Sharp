// Class: CS/INFO 1182
// Created by: Brad Curtis
// Date: 3/16/2017
// Description - Class used to keep track of door keys in the game
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStuff {
    public class DoorKey: Item {

        #region Private Fields

        private string _code;

        #endregion

        #region Public Properties

        public string Code {

            get {
                return _code;
            }
        }
        #endregion

        #region Constructor
        public DoorKey(string name, int value, string code)
            :base(name, value) {

            _code = code;
        }
        #endregion
    }
}
