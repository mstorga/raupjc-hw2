using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomStruktura;

namespace Drugi_zadatak
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly IGenericList<ToDoItem> _inMemoryTodoDatabase;        public ToDoRepository(IGenericList<ToDoItem> initialDbState = null)
        {
            if (initialDbState != null)
            {
                _inMemoryTodoDatabase = initialDbState;
            }
            else
            {
                _inMemoryTodoDatabase = new GenericList<ToDoItem>();
            }
        }
        public void Add(ToDoItem todoItem)
        {
            _inMemoryTodoDatabase.Add(todoItem);
        }

        public ToDoItem Get(Guid todoId)
        {
            return _inMemoryTodoDatabase.FirstOrDefault(i => i.Id.Equals(todoId));

        }

        public List<ToDoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(i=>i!=null).Where(i => !i.IsCompleted).ToList();
        }

        public List<ToDoItem> GetAll()
        {
            return _inMemoryTodoDatabase.Where(s => s!=null).ToList();
        }

        public List<ToDoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Where(i => i!=null).Where(i=> i.IsCompleted).ToList();
        }

        public List<ToDoItem> GetFiltered(Func<ToDoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(i => i != null).Where(filterFunction).ToList();

        }

        public bool MarkAsCompleted(Guid todoId)
        {
            return Get(todoId).MarkAsCompleted();

        }

        public bool Remove(Guid todoId)
        {
            return _inMemoryTodoDatabase.Remove(Get(todoId));

        }

        public void Update(ToDoItem todoItem)
        {
            var item = Get(todoItem.Id);
            
            if (item == null)
            {
                Add(todoItem);
                return;
            }

            item.Text = todoItem.Text;
            item.DateCompleted = todoItem.DateCompleted;
            item.DateCreated = todoItem.DateCreated;

            if (todoItem.IsCompleted)
                item.MarkAsCompleted();

            Add(item);
        }
    }
}
