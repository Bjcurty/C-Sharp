// Class: CS/INFO 1182
// Created by: Brad Curtis
// Date: 4/22/2017
// Description - Form used to alert the user which Monster they came across
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Deliverable_6 {
    /// <summary>
    /// Interaction logic for frmMonster.xaml
    /// </summary>
    public partial class frmMonster : Window {
        public frmMonster() {
            InitializeComponent();
            updateLabels();
        }

        //makes game state lost if the hero dies or removes the monster if it dies
        private void btnOk_Click(object sender, RoutedEventArgs e) {

            bool keepGoing;

            keepGoing = Game.Adventurer + Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Monster;

            updateLabels();

            if (keepGoing == false) {

                if (Game.Adventurer.isAlive() == false) {

                    Game.CurrentGameState = Game.GameState.Lost;
                }

                if (Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Monster.isAlive() == false) {

                    Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Monster = null;
                }

                this.Close();
            }
        }

        //sets isRunningAway property to true on hero
        private void btnNo_Click(object sender, RoutedEventArgs e) {

            Game.Adventurer.IsRunningAway = true;

            bool keepGoing = Game.Adventurer + Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Monster;

            this.Close();
        }

        //updates hero related labels for the user
        private void updateLabels() {

            if(Game.Adventurer.NickName == "Mal" || Game.Adventurer.NickName == "Zoe" || Game.Adventurer.NickName == "Jayne" || Game.Adventurer.NickName == "River") {

                lblHHp.Content = "HP:";
                lblMHp.Content = "HP:";
            }

            else if (Game.Adventurer.NickName == "Wash") {

                lblHHp.Content = "Coordination:";
                lblMHp.Content = "Coordination:";
            }

            else if (Game.Adventurer.NickName == "Inora") {

                lblHHp.Content = "Will:";
                lblMHp.Content = "Will:";
            }

            else if (Game.Adventurer.NickName == "Kaylee") {

                lblHHp.Content = "Determination:";
                lblMHp.Content = "Determination:";
            }

            else if (Game.Adventurer.NickName == "Simon") {

                lblHHp.Content = "Patience:";
                lblMHp.Content = "Patience:";
            }

            else if (Game.Adventurer.NickName == "Shepard Book") {

                lblHHp.Content = "Faith:";
                lblMHp.Content = "Faith:";
            }

            lblHeroHp.Content = Game.Adventurer.CurrentHitPoints + "\\" + Game.Adventurer.MaximumHitPoints;
            lblMonsterHp.Content = Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Monster.CurrentHitPoints + "\\" + Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Monster.MaximumHitPoints;
        }
    }
}
