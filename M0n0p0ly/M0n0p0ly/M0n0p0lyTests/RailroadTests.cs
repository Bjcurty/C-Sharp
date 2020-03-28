using Microsoft.VisualStudio.TestTools.UnitTesting;
using M0n0p0ly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M0n0p0ly.Tests {
    [TestClass()]
    public class RailroadTests {
        [TestMethod()]
        public void CalculateRent_ZeroOwned_NotNearest() {
            int expected = 25;
            Railroad railroad1 = new Railroad("Railroad1", 200, 25);
            Railroad railroad2 = new Railroad("Railroad2", 200, 25);
            Railroad railroad3 = new Railroad("Railroad3", 200, 25);
            Railroad railroad4 = new Railroad("Railroad4", 200, 25);
            railroad1.IsOwned = false;
            railroad2.IsOwned = false;
            railroad3.IsOwned = false;
            railroad4.IsOwned = false;
            bool advanceToNearestRailroad = false;

            railroad1.CalculateRent(railroad1, railroad2, railroad3, railroad4, advanceToNearestRailroad);
            int actual = railroad1.Rent;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CalculateRent_OneOwned_NotNearest() {
            int expected = 25;
            Railroad railroad1 = new Railroad("Railroad1",200,25);
            Railroad railroad2 = new Railroad("Railroad2", 200, 25);
            Railroad railroad3 = new Railroad("Railroad3", 200, 25);
            Railroad railroad4 = new Railroad("Railroad4", 200, 25);
            railroad1.IsOwned = true;
            railroad2.IsOwned = false;
            railroad3.IsOwned = false;
            railroad4.IsOwned = false;
            bool advanceToNearestRailroad = false;

            railroad1.CalculateRent(railroad1, railroad2, railroad3, railroad4, advanceToNearestRailroad);
            int actual = railroad1.Rent;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CalculateRent_TwoOwned_NotNearest() {
            int expected = 50;
            Railroad railroad1 = new Railroad("Railroad1", 200, 25);
            Railroad railroad2 = new Railroad("Railroad2", 200, 25);
            Railroad railroad3 = new Railroad("Railroad3", 200, 25);
            Railroad railroad4 = new Railroad("Railroad4", 200, 25);
            railroad1.IsOwned = true;
            railroad2.IsOwned = true;
            railroad3.IsOwned = false;
            railroad4.IsOwned = false;
            bool advanceToNearestRailroad = false;

            railroad1.CalculateRent(railroad1, railroad2, railroad3, railroad4, advanceToNearestRailroad);
            int actual = railroad1.Rent;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CalculateRent_ThreeOwned_NotNearest() {
            int expected = 100;
            Railroad railroad1 = new Railroad("Railroad1", 200, 25);
            Railroad railroad2 = new Railroad("Railroad2", 200, 25);
            Railroad railroad3 = new Railroad("Railroad3", 200, 25);
            Railroad railroad4 = new Railroad("Railroad4", 200, 25);
            railroad1.IsOwned = true;
            railroad2.IsOwned = true;
            railroad3.IsOwned = true;
            railroad4.IsOwned = false;
            bool advanceToNearestRailroad = false;

            railroad1.CalculateRent(railroad1, railroad2, railroad3, railroad4, advanceToNearestRailroad);
            int actual = railroad1.Rent;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CalculateRent_FourOwned_NotNearest() {
            int expected = 200;
            Railroad railroad1 = new Railroad("Railroad1", 200, 25);
            Railroad railroad2 = new Railroad("Railroad2", 200, 25);
            Railroad railroad3 = new Railroad("Railroad3", 200, 25);
            Railroad railroad4 = new Railroad("Railroad4", 200, 25);
            railroad1.IsOwned = true;
            railroad2.IsOwned = true;
            railroad3.IsOwned = true;
            railroad4.IsOwned = true;
            bool advanceToNearestRailroad = false;

            railroad1.CalculateRent(railroad1, railroad2, railroad3, railroad4, advanceToNearestRailroad);
            int actual = railroad1.Rent;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CalculateRent_ZeroOwned_Nearest() {
            int expected = 50;
            Railroad railroad1 = new Railroad("Railroad1", 200, 25);
            Railroad railroad2 = new Railroad("Railroad2", 200, 25);
            Railroad railroad3 = new Railroad("Railroad3", 200, 25);
            Railroad railroad4 = new Railroad("Railroad4", 200, 25);
            railroad1.IsOwned = false;
            railroad2.IsOwned = false;
            railroad3.IsOwned = false;
            railroad4.IsOwned = false;
            bool advanceToNearestRailroad = true;

            railroad1.CalculateRent(railroad1, railroad2, railroad3, railroad4, advanceToNearestRailroad);
            int actual = railroad1.Rent;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CalculateRent_OneOwned_Nearest() {
            int expected = 50;
            Railroad railroad1 = new Railroad("Railroad1", 200, 25);
            Railroad railroad2 = new Railroad("Railroad2", 200, 25);
            Railroad railroad3 = new Railroad("Railroad3", 200, 25);
            Railroad railroad4 = new Railroad("Railroad4", 200, 25);
            railroad1.IsOwned = true;
            railroad2.IsOwned = false;
            railroad3.IsOwned = false;
            railroad4.IsOwned = false;
            bool advanceToNearestRailroad = true;

            railroad1.CalculateRent(railroad1, railroad2, railroad3, railroad4, advanceToNearestRailroad);
            int actual = railroad1.Rent;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CalculateRent_TwoOwned_Nearest() {
            int expected = 100;
            Railroad railroad1 = new Railroad("Railroad1", 200, 25);
            Railroad railroad2 = new Railroad("Railroad2", 200, 25);
            Railroad railroad3 = new Railroad("Railroad3", 200, 25);
            Railroad railroad4 = new Railroad("Railroad4", 200, 25);
            railroad1.IsOwned = true;
            railroad2.IsOwned = true;
            railroad3.IsOwned = false;
            railroad4.IsOwned = false;
            bool advanceToNearestRailroad = true;

            railroad1.CalculateRent(railroad1, railroad2, railroad3, railroad4, advanceToNearestRailroad);
            int actual = railroad1.Rent;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CalculateRent_ThreeOwned_Nearest() {
            int expected = 200;
            Railroad railroad1 = new Railroad("Railroad1", 200, 25);
            Railroad railroad2 = new Railroad("Railroad2", 200, 25);
            Railroad railroad3 = new Railroad("Railroad3", 200, 25);
            Railroad railroad4 = new Railroad("Railroad4", 200, 25);
            railroad1.IsOwned = true;
            railroad2.IsOwned = true;
            railroad3.IsOwned = true;
            railroad4.IsOwned = false;
            bool advanceToNearestRailroad = true;

            railroad1.CalculateRent(railroad1, railroad2, railroad3, railroad4, advanceToNearestRailroad);
            int actual = railroad1.Rent;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CalculateRent_FourOwned_Nearest() {
            int expected = 400;
            Railroad railroad1 = new Railroad("Railroad1", 200, 25);
            Railroad railroad2 = new Railroad("Railroad2", 200, 25);
            Railroad railroad3 = new Railroad("Railroad3", 200, 25);
            Railroad railroad4 = new Railroad("Railroad4", 200, 25);
            railroad1.IsOwned = true;
            railroad2.IsOwned = true;
            railroad3.IsOwned = true;
            railroad4.IsOwned = true;
            bool advanceToNearestRailroad = true;

            railroad1.CalculateRent(railroad1, railroad2, railroad3, railroad4, advanceToNearestRailroad);
            int actual = railroad1.Rent;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AmountOfRentTest_ZeroOwned() {
            Railroad railroad1 = new Railroad("Railroad1", 200, 25);
            int expected = 25;
            int actual = railroad1.AmountOfRent(0, railroad1.Rent);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AmountOfRentTest_OneOwned() {
            Railroad railroad1 = new Railroad("Railroad1", 200, 25);
            int expected = 25;
            int actual = railroad1.AmountOfRent(1, railroad1.Rent);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AmountOfRentTest_TwoOwned() {
            Railroad railroad1 = new Railroad("Railroad1", 200, 25);
            int expected = 50;
            int actual = railroad1.AmountOfRent(2, railroad1.Rent);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AmountOfRentTest_ThreeOwned() {
            Railroad railroad1 = new Railroad("Railroad1", 200, 25);
            int expected = 100;
            int actual = railroad1.AmountOfRent(3, railroad1.Rent);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AmountOfRentTest_FourOwned() {
            Railroad railroad1 = new Railroad("Railroad1", 200, 25);
            int expected = 200;
            int actual = railroad1.AmountOfRent(4, railroad1.Rent);
            Assert.AreEqual(expected, actual);
        }
    }
}