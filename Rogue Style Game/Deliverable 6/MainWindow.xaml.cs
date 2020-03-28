// Class: CS/INFO 1182
// Created by: Brad Curtis
// Date: 4/22/2017
// Description - Form used to control the game being played by the user
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibraryObjects;
using Microsoft.Win32;
using System.Runtime.Serialization.Formatters.Binary;

namespace Deliverable_6 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        /// <summary>
        /// Starts/restarts the game and fills appropriate interface objects
        /// </summary>
        private void btnStart_Click(object sender, RoutedEventArgs e) {

            Game.GameMap.FillMap();

            Game.ResetGame(grdMap.RowDefinitions.Count, grdMap.ColumnDefinitions.Count);

            if (Game.Adventurer == null) {

                return;
            }

            FillGrid();

            UpdateDetails();
        }

        /// <summary>
        /// Moves hero up
        /// </summary>
        private void btnMove_Click(object sender, RoutedEventArgs e) {

            Button btn = (Button)sender;

            if (Game.CurrentGameState != Game.GameState.Running) {

                MessageBox.Show("Please start a new game.");
            }

            else {

                if (btn == btnUp) {

                    Game.GameMap.MoveHero(Actor.Direction.Up);
                }

                else if (btn == btnDown) {

                    Game.GameMap.MoveHero(Actor.Direction.Down);
                }

                else if (btn == btnLeft) {

                    Game.GameMap.MoveHero(Actor.Direction.Left);
                }

                else if (btn == btnRight) {

                    Game.GameMap.MoveHero(Actor.Direction.Right);
                }

                FillGrid();

                UpdateDetails();

                CheckMapCell();
            }
        }

        //moves the hero
        private void Window_KeyUp(object sender, KeyEventArgs e) {

            if (e.Key == Key.Up) {

                btnMove_Click(btnUp, null);
            }

            else if (e.Key == Key.Left) {

                btnMove_Click(btnLeft, null);
            }

            else if (e.Key == Key.Right) {

                btnMove_Click(btnRight, null);
            }

            else if (e.Key == Key.Down) {

                btnMove_Click(btnDown, null);
            }
        }

        /// <summary>
        /// Fills the Grid with generated map cells. Populates the game via an interface to the user
        /// </summary>
        private void FillGrid() {

            grdMap.Children.Clear();

            int rows = Game.GameMap.Cells.GetLength(0);
            int cols = Game.GameMap.Cells.GetLength(1);

            for (int row = 0; row < rows; row++) {
                for (int col = 0; col < cols; col++) {

                    TextBlock tb = new TextBlock();
                    tb.TextWrapping = TextWrapping.Wrap;
                    tb.TextAlignment = TextAlignment.Center;

                    tb.SetValue(Grid.RowProperty, row);
                    tb.SetValue(Grid.ColumnProperty, col);

                    MapCell mc = Game.GameMap.Cells[row, col];

                    if (Game.Adventurer.PositionX == col && Game.Adventurer.PositionY == row && mc.Item != null) {

                    }

                    if (mc.Monster != null) {

                        if (Game.Adventurer.NickName == "Wash") {

                            WashMonster(mc);
                        }

                        if (Game.Adventurer.NickName == "Inara") {

                            InaraMonster(mc);
                        }

                        if (Game.Adventurer.NickName == "Kaylee") {

                            KayleeMonster(mc);
                        }

                        if (Game.Adventurer.NickName == "Simon") {

                            SimonMonster(mc);
                        }

                        if (Game.Adventurer.NickName == "Shepard Book") {

                            BookMonster(mc);
                        }

                        tb.Text = mc.Monster.Name();
                        tb.Foreground = new SolidColorBrush(Colors.White);
                        tb.Background = new SolidColorBrush(Colors.Red);
                    }

                    if (mc.Item != null) {

                        if (Game.Adventurer.NickName == "Wash") {

                            WashItem(mc);
                        }

                        else if (Game.Adventurer.NickName == "Inara") {

                            InaraItem(mc);
                        }

                        else if (Game.Adventurer.NickName == "Kaylee") {

                            KayleeItem(mc);
                        }

                        else if (Game.Adventurer.NickName == "Simon") {

                            SimonItem(mc);
                        }

                        else if (Game.Adventurer.NickName == "Shepard Book") {

                            BookItem(mc);
                        }

                        tb.Text = mc.Item.Name;

                        if (mc.Item.GetType() == typeof(Potion)) {
                            tb.Foreground = new SolidColorBrush(Colors.White);
                            tb.Background = new SolidColorBrush(Colors.Purple);
                        }

                        else if (mc.Item.GetType() == typeof(Weapon)) {
                            tb.Foreground = new SolidColorBrush(Colors.White);
                            tb.Background = new SolidColorBrush(Colors.SlateGray);
                        }

                        else if (mc.Item.GetType() == typeof(DoorKey)) {
                            tb.Foreground = new SolidColorBrush(Colors.White);
                            tb.Background = new SolidColorBrush(Colors.Goldenrod);
                        }

                        else if (mc.Item.GetType() == typeof(Door)) {
                            tb.Foreground = new SolidColorBrush(Colors.White);
                            tb.Background = new SolidColorBrush(Colors.SaddleBrown);
                        }
                    }

                    if (Game.Adventurer.PositionX == col && Game.Adventurer.PositionY == row) {

                        tb.Text = Game.Adventurer.Name();
                        tb.Foreground = new SolidColorBrush(Colors.Black);
                        tb.Background = new SolidColorBrush(Colors.Yellow);
                    }

                    if (!Game.GameMap.Cells[row, col].HasBeenSeen) {

                        tb.Background = new SolidColorBrush(Colors.Black);
                        tb.Foreground = new SolidColorBrush(Colors.Black);
                    }

                    grdMap.Children.Add(tb);
                }
            }
        }

        /// <summary>
        /// updates the listed values
        /// </summary>
        public void UpdateDetails() {

            tbName.Content = Game.Adventurer.NickName;

            tbHP.Content = Game.Adventurer.CurrentHitPoints.ToString() + "\\" + Game.Adventurer.MaximumHitPoints.ToString();

            tbDamage.Content = Game.Adventurer.AttackDamage;

            if (Game.Adventurer.HasWeapon == true) {

                tbWeapon.Content = Game.Adventurer.Weapon.Name;
            }

            else {

                tbWeapon.Content = "None";
            }

            if (Game.Adventurer.DoorKey != null) {

                tbKey.Content = Game.Adventurer.DoorKey.Name;
            }

            else {

                tbKey.Content = "None";
            }

            if(Game.Adventurer.NickName == "Mal" || Game.Adventurer.NickName == "Zoe" || Game.Adventurer.NickName == "Jayne" || Game.Adventurer.NickName == "River") {

                lblHP.Content = "HP:";
                lblWeapon.Content = "Weapon:";
                lblDamage.Content = "Damage:";
            }

            else if (Game.Adventurer.NickName == "Wash") {

                lblHP.Content = "Coordination:";
                lblWeapon.Content = "Upgrade:";
                lblDamage.Content = "Manuevering:";
            }

            else if (Game.Adventurer.NickName == "Inara") {

                lblHP.Content = "Will:";
                lblWeapon.Content = "Accessory:";
                lblDamage.Content = "Persuasion:";
            }

            else if (Game.Adventurer.NickName == "Kaylee") {

                lblHP.Content = "Determination:";
                lblWeapon.Content = "Tool:";
                lblDamage.Content = "Reasoning:";
            }

            else if (Game.Adventurer.NickName == "Simon") {

                lblHP.Content = "Patience:";
                lblWeapon.Content = "Equipment:";
                lblDamage.Content = "Skill:";
            }

            else if (Game.Adventurer.NickName == "Shepard Book") {

                lblHP.Content = "Faith:";
                lblWeapon.Content = "Swag:";
                lblDamage.Content = "Conversion:";
            }
        }

        /// <summary>
        /// Determines if the Hero is in the same space as an Item or Monster and brings up the corresponding Form
        /// </summary>
        public void CheckMapCell() {

            if (Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].HasItem) {

                if (Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Item.GetType() == typeof(Door)) {

                    Door door = (Door)Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Item;

                    if (door.isMatch(Game.Adventurer.DoorKey)) {

                        Game.CurrentGameState = Game.GameState.Won;
                    }

                    CheckGameState();
                }

                else {

                    frmItem frm = new frmItem();

                    frm.tbItem.Text = "You found this " + Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Item.Name + ".";

                    if (Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Item.GetType() == typeof(Weapon)) {

                        if (Game.Adventurer.NickName == "Wash") {

                            frm.tbItem.Text += " It adds " + Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Item.AffectValue + " manuevering." + " Would you like to use it?";
                        }

                        else if (Game.Adventurer.NickName == "Inara") {

                            frm.tbItem.Text += " It adds " + Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Item.AffectValue + " persuasion." + " Would you like to use it?";
                        }

                        else if (Game.Adventurer.NickName == "Kaylee") {

                            frm.tbItem.Text += " It adds " + Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Item.AffectValue + " reasoning." + " Would you like to use it?";
                        }

                        else if (Game.Adventurer.NickName == "Simon") {

                            frm.tbItem.Text += " It adds " + Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Item.AffectValue + " skill." + " Would you like to use it?";
                        }

                        else if (Game.Adventurer.NickName == "Shepard Book") {

                            frm.tbItem.Text += " It adds " + Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Item.AffectValue + " conversion." + " Would you like to use it?";
                        }

                        else {

                            frm.tbItem.Text += " It adds " + Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Item.AffectValue + " damage." + " Would you like to equip it?";
                        }
                    }

                    else if (Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Item.GetType() == typeof(Potion)) {

                        if (Game.Adventurer.NickName == "Wash") {

                            frm.tbItem.Text += " It recovers " + Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Item.AffectValue + " coordination. Would you like to use it?";
                        }

                        else if (Game.Adventurer.NickName == "Inara") {

                            frm.tbItem.Text += " It recovers " + Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Item.AffectValue + " will. Would you like to use it?";
                        }

                        else if (Game.Adventurer.NickName == "Kaylee") {

                            frm.tbItem.Text += " It recovers " + Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Item.AffectValue + " determination. Would you like to use it?";
                        }

                        else if (Game.Adventurer.NickName == "Simon") {

                            frm.tbItem.Text += " It recovers " + Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Item.AffectValue + " patience. Would you like to use it?";
                        }

                        else if (Game.Adventurer.NickName == "Shepard Book") {

                            frm.tbItem.Text += " It recovers " + Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Item.AffectValue + " faith. Would you like to use it?";
                        }

                        else {

                            frm.tbItem.Text += " It recovers " + Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Item.AffectValue + " health. Would you like to use it?";
                        }
                    }

                    else if (Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Item.GetType() == typeof(DoorKey)) {

                        frm.tbItem.Text += " Would you like to pick it up?";
                    }

                    frm.ShowDialog();
                }
            }

            else if (Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].HasMonster) {

                frmMonster frm = new frmMonster();

                Game.Adventurer.IsRunningAway = false;

                if (Game.Adventurer.NickName == "Wash") {

                    frm.tbMonster.Text = "In your way is this " + Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Monster.Name() + "." +
                    " Would you like to try landing maneuvers?";

                    frm.btnOk.Content = "Yes";
                    frm.btnNo.Content = "No";
                }

                else if (Game.Adventurer.NickName == "Inara") {

                    frm.tbMonster.Text = "You come across a " + Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Monster.Name() + "." +
                    " Would you like to try persuade them?";

                    frm.btnOk.Content = "Yes";
                    frm.btnNo.Content = "No";
                }

                else if (Game.Adventurer.NickName == "Kaylee") {

                    frm.tbMonster.Text = "You have come across a problem with the " + Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Monster.Name() + "." +
                    " Would you like to try fixing it?";

                    frm.btnOk.Content = "Yes";
                    frm.btnNo.Content = "No";
                }

                else if (Game.Adventurer.NickName == "Simon") {

                    frm.tbMonster.Text = "One of the crew members have suffered a " + Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Monster.Name() + "." +
                    " Would you like to try to patch them up?";

                    frm.btnOk.Content = "Yes";
                    frm.btnNo.Content = "No";
                }

                else if (Game.Adventurer.NickName == "Shepard Book") {

                    frm.tbMonster.Text = "One of the crew members is experiencing " + Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Monster.Name() + "." +
                    " Would you like to try and help them?";

                    frm.btnOk.Content = "Yes";
                    frm.btnNo.Content = "No";
                }

                else {

                    frm.tbMonster.Text = "In your way is this " + Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Monster.Name() + "." +
                        " Would you like to attack or run?";
                }

                frm.lblHeroName.Content = Game.Adventurer.FirstName;
                frm.lblMonsterName.Content = Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Monster.Name();
                frm.lblHeroHp.Content = Game.Adventurer.CurrentHitPoints + "\\" + Game.Adventurer.MaximumHitPoints;
                frm.lblMonsterHp.Content = Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Monster.CurrentHitPoints + "\\" + Game.GameMap.Cells[Game.Adventurer.PositionY, Game.Adventurer.PositionX].Monster.MaximumHitPoints;

                frm.ShowDialog();

                if (Game.Adventurer.isAlive() == false) {
                    CheckGameState();
                }
            }

            FillGrid();

            UpdateDetails();
        }

        private void CheckGameState() {

            frmGameOver frm = new frmGameOver();

            if (Game.CurrentGameState == Game.GameState.Won) {

                frm.tbDisplay.Text = "You have found the door and you have the key. Victory is yours this day!";
                frm.btnOk.Visibility = Visibility.Hidden;
            }

            else if (Game.CurrentGameState == Game.GameState.Lost) {

                frm.btnOk.Visibility = Visibility.Hidden;
                frm.tbDisplay.Text = "Unfortunately, you died and have lost the game. Better luck next time!";
            }

            else if (Game.CurrentGameState == Game.GameState.Running) {

                frm.tbDisplay.Text = "You have found the door but you have no key. Continue looking for the key!";
            }

            frm.ShowDialog();
        }

        private void miFile_Click(object sender, RoutedEventArgs e) {

        }

        private void miLoadGame_Click(object sender, RoutedEventArgs e) {

            OpenFileDialog lDia = new OpenFileDialog();
            lDia.Filter = "Map File |*.map";

            bool? answer = lDia.ShowDialog();
            FileStream fs = null;

            if (answer == true && lDia.CheckFileExists) {
                try {

                    BinaryFormatter bf = new BinaryFormatter();
                    fs = new FileStream(lDia.FileName, FileMode.Open);
                    Game.GameMap = (Map)bf.Deserialize(fs);
                }

                catch (Exception ex) {

                    MessageBox.Show(ex.Message);
                }

                finally {
                    if (fs != null) {

                        fs.Close();

                        FillGrid();

                        Game.CurrentGameState = Game.GameState.Running;
                    }
                }
            }

            else {

                MessageBox.Show("Game not found.");
            }
        }

        private void miSaveGame_Click(object sender, RoutedEventArgs e) {

            SaveFileDialog sDia = new SaveFileDialog();
            sDia.Filter = "Map File |*.map";

            bool? answer = sDia.ShowDialog();

            if (answer == true) {

                string fileToSaveAs = sDia.FileName;
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(fileToSaveAs, FileMode.OpenOrCreate);
                bf.Serialize(fs, Game.GameMap);
                fs.Close();
            }
        }

        private void WashMonster(MapCell mc) {

            if (mc.Monster.FirstName == "Men in Blue") {

                mc.Monster.ChangeName("Central Alliance Planet");
            }

            else if (mc.Monster.FirstName == "Alliance Soldier") {

                mc.Monster.ChangeName("Border Planet");
            }

            else if (mc.Monster.FirstName == "Reaver") {

                mc.Monster.ChangeName("Reaver Planet");
            }

            else if (mc.Monster.FirstName == "Alliance Spy") {

                mc.Monster.ChangeName("Alliance Ship");
            }

            else if (mc.Monster.FirstName == "Random Hoodlum") {

                mc.Monster.ChangeName("Derelict Ship");
            }
        }

        private void WashItem(MapCell mc) {

            if (mc.Item.Name == "Bandage") {

                mc.Item.Name = "Mt. Dew";
            }

            else if (mc.Item.Name == "Pain Meds") {

                mc.Item.Name = "Monster Drink";
            }

            else if (mc.Item.Name == "Health Tonic") {

                mc.Item.Name = "5 Hour Energy";
            }

            else if (mc.Item.Name == "Doctor in a bag") {

                mc.Item.Name = "Adrenaline Shot";
            }

            else if (mc.Item.Name == "Sword") {

                mc.Item.Name = "Bronze Upgrade";
            }

            else if (mc.Item.Name == "Pistol") {

                mc.Item.Name = "Silver Upgrade";
            }

            else if (mc.Item.Name == "Shotgun") {

                mc.Item.Name = "Gold Upgrade";
            }

            else if (mc.Item.Name == "Machine Gun") {

                mc.Item.Name = "Platinum Upgrade";
            }
        }

        private void InaraMonster(MapCell mc) {

            if (mc.Monster.FirstName == "Men in Blue") {

                mc.Monster.ChangeName("Alliance Governor");
            }

            else if (mc.Monster.FirstName == "Alliance Soldier") {

                mc.Monster.ChangeName("Federal Marshal");
            }

            else if (mc.Monster.FirstName == "Reaver") {

                mc.Monster.ChangeName("Alliance Prefect");
            }

            else if (mc.Monster.FirstName == "Alliance Spy") {

                mc.Monster.ChangeName("Quartermaster");
            }

            else if (mc.Monster.FirstName == "Random Hoodlum") {

                mc.Monster.ChangeName("Joe Nobody");
            }
        }

        private void InaraItem(MapCell mc) {

            if (mc.Item.Name == "Bandage") {

                mc.Item.Name = "Mt. Dew";
            }

            else if (mc.Item.Name == "Pain Meds") {

                mc.Item.Name = "Monster Drink";
            }

            else if (mc.Item.Name == "Health Tonic") {

                mc.Item.Name = "5 Hour Energy";
            }

            else if (mc.Item.Name == "Doctor in a bag") {

                mc.Item.Name = "Adrenaline Shot";
            }

            else if (mc.Item.Name == "Sword") {

                mc.Item.Name = "Hair Clasp";
            }

            else if (mc.Item.Name == "Pistol") {

                mc.Item.Name = "Makeup";
            }

            else if (mc.Item.Name == "Shotgun") {

                mc.Item.Name = "Silk Dress";
            }

            else if (mc.Item.Name == "Machine Gun") {

                mc.Item.Name = "Lingerie";
            }
        }

        private void KayleeMonster(MapCell mc) {

            if (mc.Monster.FirstName == "Men in Blue") {

                mc.Monster.ChangeName("Main Engine");
            }

            else if (mc.Monster.FirstName == "Alliance Soldier") {

                mc.Monster.ChangeName("Emergency System");
            }

            else if (mc.Monster.FirstName == "Reaver") {

                mc.Monster.ChangeName("Hull");
            }

            else if (mc.Monster.FirstName == "Alliance Spy") {

                mc.Monster.ChangeName("Comms System");
            }

            else if (mc.Monster.FirstName == "Random Hoodlum") {

                mc.Monster.ChangeName("Toilets");
            }
        }

        private void KayleeItem(MapCell mc) {

            if (mc.Item.Name == "Bandage") {

                mc.Item.Name = "Mt. Dew";
            }

            else if (mc.Item.Name == "Pain Meds") {

                mc.Item.Name = "Monster Drink";
            }

            else if (mc.Item.Name == "Health Tonic") {

                mc.Item.Name = "5 Hour Energy";
            }

            else if (mc.Item.Name == "Doctor in a bag") {

                mc.Item.Name = "Adrenaline Shot";
            }

            else if (mc.Item.Name == "Sword") {

                mc.Item.Name = "Hammer";
            }

            else if (mc.Item.Name == "Pistol") {

                mc.Item.Name = "Screwdriver";
            }

            else if (mc.Item.Name == "Shotgun") {

                mc.Item.Name = "Multitool";
            }

            else if (mc.Item.Name == "Machine Gun") {

                mc.Item.Name = "Garage in a bag";
            }
        }

        private void SimonMonster(MapCell mc) {

            if (mc.Monster.FirstName == "Men in Blue") {

                mc.Monster.ChangeName("Bullet Wound");
            }

            else if (mc.Monster.FirstName == "Alliance Soldier") {

                mc.Monster.ChangeName("Flesh Wound");
            }

            else if (mc.Monster.FirstName == "Reaver") {

                mc.Monster.ChangeName("Head Injury");
            }

            else if (mc.Monster.FirstName == "Alliance Spy") {

                mc.Monster.ChangeName("Broken Bone");
            }

            else if (mc.Monster.FirstName == "Random Hoodlum") {

                mc.Monster.ChangeName("Paper Cut");
            }
        }

        private void SimonItem(MapCell mc) {

            if (mc.Item.Name == "Bandage") {

                mc.Item.Name = "Mt. Dew";
            }

            else if (mc.Item.Name == "Pain Meds") {

                mc.Item.Name = "Monster Drink";
            }

            else if (mc.Item.Name == "Health Tonic") {

                mc.Item.Name = "5 Hour Energy";
            }

            else if (mc.Item.Name == "Doctor in a bag") {

                mc.Item.Name = "Adrenaline Shot";
            }

            else if (mc.Item.Name == "Sword") {

                mc.Item.Name = "Duct Tape";
            }

            else if (mc.Item.Name == "Pistol") {

                mc.Item.Name = "First Aid Kit";
            }

            else if (mc.Item.Name == "Shotgun") {

                mc.Item.Name = "Meds";
            }

            else if (mc.Item.Name == "Machine Gun") {

                mc.Item.Name = "Hospital in a bag";
            }
        }

        private void BookMonster(MapCell mc) {

            if (mc.Monster.FirstName == "Men in Blue") {

                mc.Monster.ChangeName("Homicidal");
            }

            else if (mc.Monster.FirstName == "Alliance Soldier") {

                mc.Monster.ChangeName("Scared");
            }

            else if (mc.Monster.FirstName == "Reaver") {

                mc.Monster.ChangeName("Suicidal");
            }

            else if (mc.Monster.FirstName == "Alliance Spy") {

                mc.Monster.ChangeName("Traumatized");
            }

            else if (mc.Monster.FirstName == "Random Hoodlum") {

                mc.Monster.ChangeName("Meh");
            }
        }

        private void BookItem(MapCell mc) {

            if (mc.Item.Name == "Bandage") {

                mc.Item.Name = "Mt. Dew";
            }

            else if (mc.Item.Name == "Pain Meds") {

                mc.Item.Name = "Monster Drink";
            }

            else if (mc.Item.Name == "Health Tonic") {

                mc.Item.Name = "5 Hour Energy";
            }

            else if (mc.Item.Name == "Doctor in a bag") {

                mc.Item.Name = "Adrenaline Shot";
            }

            else if (mc.Item.Name == "Sword") {

                mc.Item.Name = "Ring";
            }

            else if (mc.Item.Name == "Pistol") {

                mc.Item.Name = "Amulet";
            }

            else if (mc.Item.Name == "Shotgun") {

                mc.Item.Name = "Statues";
            }

            else if (mc.Item.Name == "Machine Gun") {

                mc.Item.Name = "Church in a bag";
            }
        }
    }
}
