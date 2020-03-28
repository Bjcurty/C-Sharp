// Class: CS/INFO 1182
// Created by: Jon Holmes
// Adapted by: Brad Curtis
// Date: 4/6/2017
// Description - Hero class used to define properties and methods of the game hero
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryObjects {
    [Serializable]
    public class Hero : Actor {

        #region Private Fields

        private bool _IsRunningAway;
        private DoorKey _DoorKey;
        private Weapon _Weapon;
        private bool _picked;
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
            : base(newName, newTitle, atkSpeed, hitPoints, startingPositionX, startingPositionY) {

            Weapon = null;
        }

        public Hero(String newName, String nickName, double atkSpeed, int hitPoints, int startingPositionX, int startingPositionY, bool picked)
            : base(newName, nickName, atkSpeed, hitPoints, startingPositionX, startingPositionY) {

            NickName = nickName;
        }
        #endregion

        #region Public Properties
        public bool Picked {

            get { return _picked; }
            set { _picked = value; }
        }
        /// <summary>
        /// Get Hero's attack speed
        /// </summary>
        public override double AttackSpeed {

            get {

                if (HasWeapon) {

                    return base.AttackSpeed + Weapon.SpeedModifier;

                }
                else {

                    return base.AttackSpeed;
                }
            }
        }

        /// <summary>
        /// Set if the hero is running away
        /// </summary>
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

        /// <summary>
        /// Sets Hero attack damage without and with a weapon
        /// </summary>
        public int AttackDamage {

            get {
                if (_Weapon == null) {
                    if (_NickName == "Mal") {

                        return 5;
                    }

                    else if (_NickName == "Zoe") {

                        return 5;
                    }

                    else if (_NickName == "Wash") {

                        return 10;
                    }

                    else if (_NickName == "Inara") {

                        return 15;
                    }

                    else if (_NickName == "Jayne") {

                        return 15;
                    }

                    else if (_NickName == "Kaylee") {

                        return 15;
                    }

                    else if (_NickName == "Simon") {

                        return 10;
                    }

                    else if (_NickName == "River") {

                        return 10;
                    }

                    else if (_NickName == "Shepard Book") {

                        return 5;
                    }

                    else {

                        return 5;
                    }
                }
                else {

                    if (_NickName == "Mal") {

                        return Weapon.AffectValue + 5;
                    }

                    else if (_NickName == "Zoe") {

                        return Weapon.AffectValue + 5;
                    }

                    else if (_NickName == "Wash") {

                        return Weapon.AffectValue + 10;
                    }

                    else if (_NickName == "Inara") {

                        return Weapon.AffectValue + 15;
                    }

                    else if (_NickName == "Jayne") {

                        return Weapon.AffectValue + 15;
                    }

                    else if (_NickName == "Kaylee") {

                        return Weapon.AffectValue + 15;
                    }

                    else if (_NickName == "Simon") {

                        return Weapon.AffectValue + 10;
                    }

                    else if (_NickName == "River") {

                        return Weapon.AffectValue + 10;
                    }

                    else if (_NickName == "Shepard Book") {

                        return Weapon.AffectValue + 5;
                    }

                    else {

                        return Weapon.AffectValue;
                    }
                }
            }
        }

        /// <summary>
        /// Determines if the Hero is alive
        /// </summary>
        /// <returns></returns>
        public bool IsAlive() {

            if (_CurrentHitPoints > 0) {

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

        /// <summary>
        /// Gets the item for the Hero depending on item type
        /// </summary>
        public Item EquipItem(Item item) {

            if (item.GetType() == typeof(Potion)) {

                healMe(item.AffectValue);

                return null;
            }

            if (item.GetType() == typeof(Weapon)) {               

                if (_Weapon == null) {

                    _Weapon = (Weapon)item;

                    return null;
                }

                else if (_Weapon != null) {

                    Weapon tempWeapon = _Weapon;

                    _Weapon = (Weapon)item;

                    return tempWeapon;
                }

                else return null;
            }

            if (item.GetType() == typeof(DoorKey)) {

                if (DoorKey == null) {

                    _DoorKey = (DoorKey)item;

                    return null;
                }

                else if (DoorKey != null) {

                    _DoorKey = (DoorKey)item;

                    return item;
                }

                else return null;
            }

            else return item;
        }

        /// <summary>
        /// Allows a + operation between a Hero and a Monster
        /// </summary>
        public static bool operator +(Hero h, Monster m) {

            if (h.IsRunningAway == true) {

                if (h.AttackSpeed > m.AttackSpeed) {

                    return true;  
                }

                else {

                    h.damageMe(m.AttackValue);

                    MessageBox.Show("You were not fast enough to get away unscathed.");

                    if(h.isAlive()) {

                        return true;
                    }
                }
            }

            else if (h.IsRunningAway == false) {

                if (h.AttackSpeed > m.AttackSpeed) {

                    m.damageMe(h.AttackDamage);

                    if (m.isAlive()) {

                        h.damageMe(m.AttackValue);

                        if (h.isAlive()) {

                            return true;
                        }
                    }
                }

                else if (h.AttackSpeed == m.AttackSpeed) {

                    m.damageMe(h.AttackDamage);
                    h.damageMe(m.AttackValue);

                    if (h.isAlive()) {

                        return true;
                    }
                }

                else if (h.AttackSpeed < m.AttackSpeed) {

                    h.damageMe(m.AttackValue);

                    if (h.isAlive()) {

                        m.damageMe(h.AttackDamage);

                        if (h.isAlive()) {

                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public void RemoveKey() {

            _DoorKey = null;
        }

        public void RemoveWeapon() {

            _Weapon = null;
        }
        #endregion
    }
}
