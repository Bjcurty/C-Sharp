//Brad Curtis
//4-26-19
using Microsoft.VisualStudio.TestTools.UnitTesting;
using M0n0p0ly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace M0n0p0ly.Tests
{
    [TestClass()]
    public class GameboardTests
    {
        //Tests to make sure the list won't be added to when the size is already 6
        [TestMethod()]
        public void AddPlayer_ListIsFull_DoesntAdd()
        {
            //Arrange
            List<Player> players = new List<Player>();
            int sizeBefore;
            int sizeAfter;
            //Act
            for(int i = 0; i < 6; i++)
            {
                players.Add(new Player());
            }
            sizeBefore = players.Count;
            if(players.Count < 6)
            {
                players.Add(new Player());
            }
            sizeAfter = players.Count;
            //Assert
            Assert.AreEqual(sizeAfter, sizeBefore);
        }

        //Tests to make sure the list will be added to when the size is under 6
        [TestMethod()]
        public void AddPlayer_ListIsNotFull_Adds()
        {
            //Arrange
            List<Player> players = new List<Player>();
            int sizeBefore;
            int sizeAfter;
            //Act
            for (int i = 0; i < 3; i++)
            {
                players.Add(new Player());
            }
            sizeBefore = players.Count;
            if (players.Count < 6)
            {
                players.Add(new Player());
            }
            sizeAfter = players.Count;
            //Assert
            Assert.AreNotEqual(sizeAfter, sizeBefore);
        }

        //Tests to make sure all inherited subtypes of Tile can be accessed through a list of tiles
        [TestMethod()]
        private void InitializeTileOrder_AnyTile_CanAccess()
        {
            //Arrange
            Tile[] tiles = new Tile[7];
            Basic basic;
            Jail jail;
            PassGo passGo;
            CardSpace cardSpace;
            Utility utility;
            Railroad railroad;
            FreeParking freeParking;
            //Act
            tiles[0] = new Basic("ABCD", 15, 3);
            basic = (Basic)tiles[0];
            tiles[1] = new Jail();
            jail = (Jail)tiles[1];
            tiles[2] = new PassGo();
            passGo = (PassGo)tiles[2];
            tiles[3] = new CardSpace("CC");
            cardSpace = (CardSpace)tiles[3];
            tiles[4] = new Utility("EFGH", 10, 5);
            utility = (Utility)tiles[4];
            tiles[5] = new Railroad("IJKL", 5, 7);
            railroad = (Railroad)tiles[5];
            tiles[6] = new FreeParking("MNOP");
            freeParking = (FreeParking)tiles[6];
            //Assert
            Assert.AreEqual(basic.Name, "ABCD");
            Assert.AreEqual(basic.Cost, 15);
            Assert.AreEqual(basic.Rent, 3);
            Assert.AreEqual(jail.Name, "Jail");
            Assert.AreEqual(passGo.Name, "Go");
            Assert.AreEqual(cardSpace.Name, "CC");
            Assert.AreEqual(utility.Name, "EFGH");
            Assert.AreEqual(utility.Cost, 10);
            Assert.AreEqual(utility.Rent, 5);
            Assert.AreEqual(railroad.Name, "IJKL");
            Assert.AreEqual(railroad.Cost, 5);
            Assert.AreEqual(railroad.Rent, 7);
            Assert.AreEqual(freeParking.Name, "MNOP");
        }

        //Tests to make sure the RNG is not returning null
        [TestMethod()]
        public void RollDice_RNG_IsNotNull()
        {
            //Arrange
            Random _Rand = new Random(Guid.NewGuid().GetHashCode());
            int dice;
            //Act
            dice = _Rand.Next(1, 7);
            //Assert
            Assert.IsNotNull(dice);
        }

        //Tests to make sure a player moving updates its property as expected when not passing Go
        [TestMethod()]
        public void Move_DoesNotPassGo_IsEqual()
        {
            //Arrange
            Player player = new Player();
            Tile[] tiles = new Tile[5];
            int expectedLocation;
            int distance = 5;
            //Act
            player.Location = 0;
            expectedLocation = player.Location + distance;
            player.Location += distance;
            //Assert
            Assert.AreEqual(player.Location, expectedLocation);
        }

        //Tests to make sure a player moving updates its property as expected when passing Go
        [TestMethod()]
        public void Move_DoesPassGo_IsNotEqual()
        {
            //Arrange
            Player player = new Player();
            Tile[] tiles = new Tile[5];
            int expectedLocation;
            int distance = 6;
            //Act
            player.Location = 0;
            expectedLocation = player.Location + distance;
            if(distance > tiles.Length)
            {
                distance -= tiles.Length;
            }
            player.Location += distance;
            //Assert
            Assert.AreNotEqual(player.Location, expectedLocation);
        }

        //Tests to make sure cards can be added to an array and the phrase matches
        [TestMethod()]
        public void InitializeCards_General_CanAddCardToList()
        {
            //Arrange
            Card[] cards = new Card[1];
            Card card = new Card("The Biblobablo was a moldy mushroom");
            //Act
            cards[0] = card;
            //Assert
            Assert.IsNotNull(cards);
            Assert.AreEqual(cards[0].Phrase, "The Biblobablo was a moldy mushroom");
        }

        //Tests to make sure a string can be split properly on |
        [TestMethod()]
        public void ReadInFilesTest_General_CanSplitProperly()
        {
            //Arrange
            string[] splitArr = new string[7];
            string str1 = "a|b|c|d|e|f|g|";
            //Act
            splitArr = str1.Split('|');
            //Assert
            Assert.AreEqual(splitArr[0], "a");
            Assert.AreEqual(splitArr[1], "b");
            Assert.AreEqual(splitArr[2], "c");
            Assert.AreEqual(splitArr[3], "d");
            Assert.AreEqual(splitArr[4], "e");
            Assert.AreEqual(splitArr[5], "f");
            Assert.AreEqual(splitArr[6], "g");
        }

        //Tests to make sure a file exists and is not null
        [TestMethod()]
        public void ReadInFilesTest_General_FileNotNullAndExists()
        {
            //Arrange
            string[] readArr = new string[7];
            //Act
            readArr = File.ReadAllLines("ChanceCards.txt");
            //Assert
            Assert.IsNotNull(readArr);
        }
    }
}