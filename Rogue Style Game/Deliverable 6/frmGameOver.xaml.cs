// Class: CS/INFO 1182
// Created by: Brad Curtis
// Date: 4/22/2017
// Description - Form used to interact with user when the game is lost
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
    /// Interaction logic for frmGameOver.xaml
    /// </summary>
    public partial class frmGameOver : Window {
        public frmGameOver() {
            InitializeComponent();
        }

        //resets game
        private void btnRestart_Click(object sender, RoutedEventArgs e) {

            Game.ResetGame();

            this.Close();
        }

        //closes program
        private void btnClose_Click(object sender, RoutedEventArgs e) {

            Application.Current.Shutdown();
        }

        //continues playing
        private void btnOk_Click(object sender, RoutedEventArgs e) {

            this.Close();
        }
    }
}
