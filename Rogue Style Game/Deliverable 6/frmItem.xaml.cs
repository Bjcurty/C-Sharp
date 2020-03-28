// Class: CS/INFO 1182
// Created by: Brad Curtis
// Date: 4/22/2017
// Description - Form used to alert the user which Item they came across
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
using LibraryObjects;

namespace Deliverable_6 {
    /// <summary>
    /// Interaction logic for frmItem.xaml
    /// </summary>
    public partial class frmItem : Window {
        public frmItem() {
            InitializeComponent();
        }

        //uses item in the current mapcell
        private void btnOk_Click(object sender, RoutedEventArgs e) {

            Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Item
                = Game.Adventurer.EquipItem(Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Item);

            this.Close();
        }

        //does not use item in mapcell
        private void btnNo_Click(object sender, RoutedEventArgs e) {

            this.Close();
        }
    }
}
