using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bank = new BankVault();
        private Item item = new Item("Dani", "26487");
        private IReadOnlyDictionary<string, Item> valutCells = new Dictionary<string, Item>().ToImmutableDictionary();

        [SetUp]
        public void Setup()
        {
            this.bank = new BankVault();
            this.item = new Item("Dani", "26487");
            this.valutCells = new Dictionary<string, Item>
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };
        }

        [Test]
        public void TestAddItemIFCellCountainsKeyAndWorkProperly()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                string cell = "S6";
                bank.AddItem(cell, item);

            });
        }

        [Test]
        public void TestColectionWorkProperly()
        {
            IReadOnlyDictionary<string, Item> exp = new Dictionary<string, Item>()
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };

            IReadOnlyDictionary<string, Item> act = valutCells;

            CollectionAssert.AreEqual(exp, act);

        }

        [Test]
        public void TestAddCellInTheSameCellThrowsExeption()
        {
             string cell = "A1";
             bank.AddItem(cell, item);

            Assert.Throws<ArgumentException>(() =>
            {
                bank.AddItem(cell, item);
            });
        }

        [Test]
        public void TestIfItemExistinTheSameCellThrowExeption()
        {
            Item item1 = new Item("Laki", "26587");
            var added = bank.AddItem("B4", item1);

            bool addItemIsTrue = added.Contains(item1.ItemId);

            Assert.IsTrue(addItemIsTrue);
            //Assert.That(() => addItemIsTrue, Throws.InvalidOperationException);
        }

        [Test]
        public void TestRemoveItemIfNotExistsThrowExeption()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                string cell = "S6";
                bank.RemoveItem(cell, item);

            });
        }

        [Test]
        public void TestRemoveItemIfCellDosentExsistThrowExeption()
        {
            string cell = "A1";

            Assert.Throws<ArgumentException>(() =>
            {
                bank.RemoveItem(cell, item);
            });
        }

        [Test]
        public void TestRemoveItemIsWorkingProperly()
        {
            bank.AddItem("B3", item);

            bank.RemoveItem("B3", item);

            IReadOnlyDictionary<string, Item> exp = new Dictionary<string, Item>()
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };
            
            CollectionAssert.AreEqual(exp, bank.VaultCells);
        }
    }
}