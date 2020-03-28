// Class: CS/INFO 1182
// Created by: Jon Holmes
// Adapted by: Brad Curtis
// Date: 3/16/2017
// Description - Hero class used to define properties and methods of the game hero
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStuff {
    public class Hero : Actor {

        #region Private Fields

        private bool _IsRunningAway;
        private DoorKey _DoorKey;
        private Weapon _Weapon;
        #endregion

        #region Constructor
        /// <summary>
        /// Overloaded Constructor for a hero
        /// </summary>
        /// <param name="newName">Hero's Name</param>
        /// <param name="newTitle">Hero's Title</param>
        /// <param name="atkSpeed">Hero's AttackSpeed</param>
        /// <param name="hitPoints">Hero's Starting HP</param>
        /// <param name="startingPositionX">Hero's Starting X Position</param>
        /// <param name="startingPositionY">Hero's Starting Y Position</param>
        public Hero(String newName, String newTitle, double atkSpeed, int hitPoints, int startingPositionX, int startingPositionY)
            : base(newName, newTitle, atkSpeed,  hitPoints, startingPositionX, startingPositionY) {

            Weapon = null;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Get Hero's attack speed
        /// </summary>
        public override double AttackSpeed {

            get {

                if (HasWeapon) {

                    return base.AttackSpeed  + Weapon.SpeedModifier;

                } else {

                    return base.AttackSpeed;
                }
            }
        }

        public bool IsRunningAway {

            get { return _IsRunningAway; }
            set { _IsRunningAway = value; }
        }

        public DoorKey DoorKey {

            get { return _DoorKey; }
        }
        /// <summary>
        /// Get and set the Hero's weapon
        /// </summary>
        public Weapon Weapon {

            get {
                return _Weapon;
            }

            set {
                _Weapon = value;
            }
        }
        /// <summary>
        /// Check to see if the hero has a weapon equipped.
        /// </summary>
        public bool HasWeapon {

            get {

                return _Weapon != null;
            }
        }

        public int AttackDamage {

            get {
                if(_Weapon == null) {

                    return 1;
                }
                else {

                    return Weapon.AffectValue;
                }
            }
        }

        public bool IsAlive() {

            if(_CurrentHitPoints > 0) {

                return true;
            }

            else {

                return false;
            }
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Move the hero.
        /// </summary>
        /// <param name="dirToMove">Direction the hero will move.</param>
        public override void Move(Actor.Direction dirToMove) {
            
            base.Move(dirToMove);
        }
        #endregion

        #region Public Operators

        public Item EquipItem(Item item) {

            if(item.GetType() == typeof(Potion)){

                return null;
            }

            if (item.GetType() == typeof(Weapon)) {

                _Weapon = (Weapon)item;

                if (Weapon != null) {

                    return item;
                }

                else return null;
            }

            if (item.GetType() == typeof(DoorKey)) {

                _DoorKey = (DoorKey)item;

                if (DoorKey != null) {

                    return item;
                }

                else return null;
            }

            else return item;
        }

        public static bool operator +(Hero h, Monster m) {

            if(h.AttackSpeed > m.AttackSpeed) {

                m.damageMe(h.AttackDamage);

                if(m.CurrentHitPoints > 0) {

                    h.damageMe(m.AttackValue);

                    if (h.IsAlive()) {

                        return true;
                    }
                }
            }

            if (h.IsRunningAway == false) {

                if (h.AttackSpeed < m.AttackSpeed) {

                    h.damageMe(m.AttackValue);

                    if (h.CurrentHitPoints > 0) {

                        m.damageMe(h.AttackDamage);
                    }
                }

                if (h.AttackSpeed == m.AttackSpeed) {

                    h.damageMe(m.AttackValue);

                    m.damageMe(h.AttackDamage);
                }

                if (h.IsAlive()) {

                    return true;
                }
            }

            else {

                h.damageMe(m.AttackValue);

                if (h.IsAlive()) {

                    return true;
                }
            }

            return false;
        }
        #endregion
    }
}
