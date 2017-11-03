using Microsoft.VisualStudio.TestTools.UnitTesting;
using Drugi_zadatak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugi_zadatak.Tests
{
    [TestClass()]
    public class ToDoItemTests
    {
        [TestMethod()]
        public void ToDoItemTest()
        {
            ToDoItem item = new ToDoItem("oprati sude");
            Assert.IsFalse(item.IsCompleted);
            Assert.IsTrue(item.Text.Equals("oprati sude"));
        }

        [TestMethod()]
        public void MarkAsCompletedTest()
        {
            ToDoItem item = new ToDoItem("oprati sude");
            Assert.IsFalse(item.IsCompleted);
            item.MarkAsCompleted();
            Assert.IsTrue(item.IsCompleted);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            ToDoItem item = new ToDoItem("oprati sude");
            ToDoItem item2 = new ToDoItem("oprati sude");
            Assert.IsTrue(item.Equals(item));
            Assert.IsFalse(item.Equals(item2));


        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            ToDoItem item = new ToDoItem("oprati sude");
            ToDoItem item2 = new ToDoItem("oprati sude");
            Assert.IsTrue(item.GetHashCode().Equals(item.GetHashCode()));
            Assert.IsFalse(item.GetHashCode().Equals(item2.GetHashCode()));
        }
    }
}