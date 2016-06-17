using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPractice.Navigate
{
    public class NavigationList<T> : List<T>
    {
        private int _currentIndex = 0;
        public int CurrnetIndex
        {
            get
            {
                if (_currentIndex > Count - 1) { _currentIndex = Count - 1; }
                if (_currentIndex < 0) { _currentIndex = 0; }
                return _currentIndex;
            }
            set { _currentIndex = value; }
        }

        public T MoveNext
        {
            get { _currentIndex++; return this[CurrnetIndex]; }
        }

        public T MovePrevious
        {
            get { _currentIndex--; return this[CurrnetIndex]; }
        }

        public T Current
        {
            get { return this[CurrnetIndex]; }
        }

        public T First
        {
            get {_currentIndex=0; return this[CurrnetIndex]; }
        }

        public T Last
        {
            get { _currentIndex = Count - 1; return this[CurrnetIndex]; }
        }
    }

    [TestClass]
    public class TestNavigation
    {
        [TestMethod]
        public void Test()
        {
            NavigationList<string> n = new NavigationList<string>();
            n.Add("A");
            n.Add("B");
            n.Add("C");
            n.Add("D");
            Assert.AreEqual(n.Current, "A");
            Assert.AreEqual(n.MoveNext, "B");
            Assert.AreEqual(n.MovePrevious, "A");

            Assert.AreEqual(n.MoveNext, "B");
            Assert.AreEqual(n.MoveNext, "C");
            Assert.AreEqual(n.MoveNext, "D");
            Assert.AreEqual(n.MoveNext, "D");
            Assert.AreEqual(n.MoveNext, "D");
            Assert.AreEqual(n.Current, "D");

            Assert.AreEqual(n.MovePrevious, "C");
            Assert.AreEqual(n.MovePrevious, "B");
            Assert.AreEqual(n.Current, "B");
            Assert.AreEqual(n.MovePrevious, "A");
            Assert.AreEqual(n.MovePrevious, "A");
            Assert.AreEqual(n.MovePrevious, "A");

            Assert.AreEqual(n.Last, "D");
            Assert.AreEqual(n.First, "A");

            Assert.AreEqual(n.Count, 4);
        }

    }

}
