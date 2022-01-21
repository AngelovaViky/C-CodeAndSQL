using System.Collections.Generic;

namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void TestConstructorWorkProperly()
        {
            string bookName = "Robots";
            string author = "Isaac Asimov";
            Book book = new Book(bookName, author);

            var footNote = new Dictionary<int, string>();
            footNote.Add(1,"Asimov");

            Assert.AreEqual(1, footNote.Count);
        }

        [Test]
        public void BookNameShouldThrowExceptionIfIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                string bookName = null;
                string author = "Isaac Asimov";
                Book book = new Book(bookName, author);
            });
        }

        [Test]
        public void AuthorShouldThrowExceptionIfIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                string bookName = "I Robot";
                string author = null;
                Book book = new Book(bookName, author);
            });
        }

        [Test]
        public void AddFootnodeThrowExceptionIfExist()
        {
            Book book = new Book("Robot", "Deni");
            book.AddFootnote(1, "Deni");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(1, "Deni");
            });
        }

        [Test]
        public void FindFootnoteThrowsExceptionWhenDoesntExists()
        {
            Book book = new Book("Robot", "Deni"); 
            book.AddFootnote(2, "Deni");
            book.FindFootnote(2); 
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.FindFootnote(1);
            });
        }

        [Test]
        public void TestAlterFootnoteThrowExceptionWhenDoNotExsist()
        {
            Book book = new Book("Robot", "Deni");
            book.AddFootnote(1, "Deni");
            book.AddFootnote(3, "Azimov");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(2, "Lazar");
            });
        }

        [Test]
        public void TestCountFootnote()
        {
            Book book = new Book("Robot", "Azimov");
            book.AddFootnote(1, "Deni");
            book.AddFootnote(2, "Azimov");

            Assert.AreEqual(2, book.FootnoteCount);
        }
    }
}