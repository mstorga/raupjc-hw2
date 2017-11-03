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
    public class ToDoRepositoryTests
    {
        [TestMethod()]
        public void ToDoRepositoryTest()
        {
            ToDoRepository list = new ToDoRepository();
            Assert.AreEqual(list.GetAll().Count(), 0);
        }

        [TestMethod()]
        public void AddTest()
        {
            ToDoRepository list = new ToDoRepository();
            ToDoItem item = new ToDoItem("kupi wc papir");
            list.Add(item);

            Assert.AreEqual(item, list.Get(item.Id));
            Assert.AreEqual(list.GetAll().Count(), 1);

        }

        [TestMethod()]
        public void GetTest()
        {
            ToDoRepository list = new ToDoRepository();
            ToDoItem item = new ToDoItem("kupi wc papir");

            list.Add(item);
            Assert.AreEqual(item, list.Get(item.Id));
        }

        [TestMethod()]
        public void GetActiveTest()
        {
            ToDoRepository list = new ToDoRepository();
            ToDoItem item = new ToDoItem("kupi wc papir");
            ToDoItem item2 = new ToDoItem("ocisti sobu");
            
            list.Add(item);
            list.Add(item2);
            Assert.IsTrue(list.GetActive().Contains(item2));
            list.MarkAsCompleted(item2.Id);
            Assert.IsFalse(list.GetActive().Contains(item2));
        }

        [TestMethod()]
        public void GetAllTest()
        {
            ToDoRepository list = new ToDoRepository();
            ToDoItem item = new ToDoItem("kupi wc papir");
            ToDoItem item2 = new ToDoItem("ocisti sobu");

            list.Add(item);
            list.Add(item2);
            Assert.IsTrue(list.GetAll().Count.Equals(2));
        }

        [TestMethod()]
        public void GetCompletedTest()
        {
            ToDoRepository list = new ToDoRepository();
            ToDoItem item = new ToDoItem("kupi wc papir");
            ToDoItem item2 = new ToDoItem("ocisti sobu");
            list.Add(item2);
            list.Add(item);

            Assert.AreEqual(0, list.GetCompleted().Count());
            list.MarkAsCompleted(item.Id);
            Assert.AreEqual(1, list.GetCompleted().Count());
        }

        [TestMethod()]
        public void GetFilteredTest()
        {
            Func<ToDoItem, bool> filterFunction = new Func<ToDoItem, bool>(i => i.Text.EndsWith("ir"));

            ToDoRepository list = new ToDoRepository();
            ToDoItem item = new ToDoItem("kupi wc papir");
            ToDoItem item2 = new ToDoItem("ocisti sobu");
            list.Add(item2);
            list.Add(item);

            Assert.AreEqual(1, list.GetFiltered(filterFunction).Count());
        }

        [TestMethod()]
        public void MarkAsCompletedTest()
        {
            ToDoRepository list = new ToDoRepository();
            ToDoItem item = new ToDoItem("kupi wc papir");
            ToDoItem item2 = new ToDoItem("ocisti sobu");
            list.Add(item2);
            list.Add(item);

            Assert.AreEqual(2, list.GetActive().Count());
            list.MarkAsCompleted(item.Id);
            Assert.AreEqual(1, list.GetActive().Count());
        }

        [TestMethod()]
        public void RemoveTest()
        {
            ToDoRepository list = new ToDoRepository();
            ToDoItem item = new ToDoItem("kupi wc papir");
            ToDoItem item2 = new ToDoItem("ocisti sobu");
            list.Add(item2);
            list.Add(item);

            Assert.AreEqual(2, list.GetAll().Count());
            list.Remove(item.Id);
            Assert.AreEqual(1, list.GetAll().Count());

        }

        [TestMethod()]
        public void UpdateTest()
        {
            ToDoRepository list = new ToDoRepository();
            ToDoItem item = new ToDoItem("kupi wc papir");
            ToDoItem item2 = new ToDoItem("ocisti sobu");


            list.Add(item);
            item.Id = item2.Id;
            list.Update(item2);
            Assert.IsTrue(list.Get(item.Id).Text.Equals("ocisti sobu"));
        }
    }
}