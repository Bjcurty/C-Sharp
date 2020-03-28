// Class: CS/INFO 1182
// Created by: Jon Holmes
// Adapted by: Brad Curtis
// Date: 3/16/2017
// Description - Interface to force deep copy on classes that inherit this
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStuff {

    #region Interface

    /// <summary>
    /// Interface for a Object that needs to be copied
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IRepeatable<T> {

         /// <summary>
         /// Create a copy of this object
         /// </summary>
         /// <returns>copy of the object</returns>
         T CreateCopy();
    }
    #endregion
}
