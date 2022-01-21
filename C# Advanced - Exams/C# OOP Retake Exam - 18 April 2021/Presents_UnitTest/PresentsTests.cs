namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class PresentsTests
    {
        private Bag bag;
        private Present present1;
        private Present present2;
        private List<Present> presents;

        [SetUp]
        public void SetUp()
        {
            this.bag = new Bag();
            this.present1 = new Present("Clock", 70);
            this.present2 = new Present("Doll", 100);
            this.presents = new List<Present>();

        }

        [Test]
        public void TestCtorWorksCorrectly()
        {
            var expName = "Doll";
            var expMagic = 100;

            Assert.AreEqual(expName, this.present2.Name);
            Assert.AreEqual(expMagic, this.present2.Magic);
        }

        [Test]
        public void TestCtorWorksCorrectlyWhitCollection()
        {
            Assert.IsNotNull(bag.GetPresents());
        }

        [Test]
        public void TestCreatePresentThrowExeptionIfPresentIsNull()
        {
            Present pres = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                bag.Create(pres);
            }
            );
        }

        [Test]
        public void TestCreatePresentThrowExeptionIfPresentExsist()
        {
            bag.Create(present1);
            presents.Add(present1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                bag.Create(present1);
            }
            );
        }

        [Test]
        public void TestRemovePresent()
        {
            bag.Create(present1);
            bag.Create(present2);

            bool res = bag.Remove(present2);

            Assert.IsTrue(res);
        }

        [Test]
        public void TestGetPresent()
        {
            bag.Create(present1);
            bag.Create(present2);

            IReadOnlyCollection<Present> exp = new List<Present>() { present1, present2 };
            IReadOnlyCollection<Present> act = bag.GetPresents();

            CollectionAssert.AreEqual(exp, act);
        }

        [Test]
        public void CreateShouldReturnCorrectMessage()
        {
            var result = bag.Create(present2);
            var exp = $"Successfully added present {present2.Name}.";

            Assert.AreEqual(exp, result);
        }

        [Test]
        public void TestGetPresentWithLeastMagic()
        {
            Present exp = new Present("Stick", 20);

            bag.Create(present1);
            bag.Create(present2);
            bag.Create(exp);

            Present act = bag.GetPresentWithLeastMagic();

            Assert.AreEqual(act, exp);
        }

        [Test]
        public void TestGetPresentWithLeastMagicThrowExeptionIfBagIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => bag.GetPresentWithLeastMagic());
        }

        [Test]
        public void TestGetPresentShouldReturnPresentWnenNoDublicate()
        {
            Present present3 = new Present("Stick", 20);

            bag.Create(present1);
            bag.Create(present2);
            bag.Create(present3);

            string expName = "Doll";

            Present act = bag.GetPresent(expName);

            Assert.AreEqual(present2, act);
        }
    }
}
