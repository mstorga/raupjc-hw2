using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugi_zadatak
{
    public class ToDoItem
    {
        public Guid Id { get; set; }
        public string Text { get; set; }

        public bool IsCompleted => DateCompleted.HasValue;

        public DateTime? DateCompleted { get; set; }
        public DateTime DateCreated { get; set; }

        public ToDoItem(string text)
        {
            Id = Guid.NewGuid();
            Text = text;
            DateCreated = DateTime.UtcNow;
        }
        public bool MarkAsCompleted()
        {
            if (!IsCompleted)
            {
                DateCompleted = DateTime.Now;
                return true;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            var item = obj as ToDoItem;
            return item != null &&
                   Id.Equals(item.Id);
        }

        public override int GetHashCode()
        {
            return 2108858624 + EqualityComparer<Guid>.Default.GetHashCode(Id);
        }
    }
}
