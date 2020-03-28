// Class: CS/INFO 1182
// Created by: Brad Curtis
// Date: 4/22/2017
// Description - Form used to allow user to pick a Hero
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
    /// Interaction logic for Character.xaml
    /// </summary>
    public partial class Character : Window {
        public Character() {
            InitializeComponent();

            Game.AddHeroes();
        }

        //gives the user a dialogue of the character they moused over
        private void btnHelp_Click(object sender, RoutedEventArgs e) {
            if (rbMal.IsChecked == true) {
                MessageBox.Show("Captain Malcom Reynolds is the leader of this group. He is classified as a combatant."
    + " Mal has above average speed, below average damage and average health.");
            }

            if (rbZoe.IsChecked == true) {
                MessageBox.Show("Zoe Washburne is second in command. She is classified as a combatant."
    + " Zoe has average speed, below average damage and above average health.");
            }

            if (rbWash.IsChecked == true) {
                MessageBox.Show("Hoban \"Wash\" Washburne is the pilot. He is classified as a noncombatant."
    + " Wash has above average speed, average manuevering and below average coordination.");
            }

            if (rbInara.IsChecked == true) {
                MessageBox.Show("Inara Serra is a Companion aboard the ship. She is classified as a noncombatant."
    + " Inara has average speed, above average persuasion and below average will.");
            }

            if (rbJayne.IsChecked == true) {
                MessageBox.Show("Jayne Cobb is a member of the ship crew. He is classified as a combatant."
    + " Jayne has below average speed, above average damage and average health.");
            }

            if (rbKaylee.IsChecked == true) {
                MessageBox.Show("Kaylee Frye is the ship mechanic. She is classified as a noncombatant."
    + " Kaylee has below average speed, above average reasoning and average determination.");
            }

            if (rbSimon.IsChecked == true) {
                MessageBox.Show("Dr. Simon Tam is the ship medic. He is classified as a noncombatant."
    + " Simon has above average speed, average skill and below average patience.");
            }

            if (rbRiver.IsChecked == true) {
                MessageBox.Show("River Tam is a stowaway aboard the ship. She is classified as a combatant."
    + " River has above average speed, average damage and below average health.");
            }

            if (rbBook.IsChecked == true) {
                MessageBox.Show("Shepard Derrial Book is a travelling minister on the ship. He is classified as a noncombatant."
    + " Shepard Book has average speed, below average conversion and above average faith.");
            }
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e) {

            if (rbMal.IsChecked == true) {

                Game.Heroes[0].Picked = true;
            }

            else if (rbZoe.IsChecked == true) {

                Game.Heroes[1].Picked = true;
            }

            else if (rbWash.IsChecked == true) {

                Game.Heroes[2].Picked = true;
            }

            else if (rbInara.IsChecked == true) {

                Game.Heroes[3].Picked = true;
            }

            else if (rbJayne.IsChecked == true) {

                Game.Heroes[4].Picked = true;
            }

            else if (rbKaylee.IsChecked == true) {

                Game.Heroes[5].Picked = true;
            }

            else if (rbSimon.IsChecked == true) {

                Game.Heroes[6].Picked = true;
            }

            else if (rbRiver.IsChecked == true) {

                Game.Heroes[7].Picked = true;
            }

            else if (rbBook.IsChecked == true) {

                Game.Heroes[8].Picked = true;
            }

            this.Close();
        }
    }
}
