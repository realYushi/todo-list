using ToDoListAPI.DTOs;

namespace TodoApi.Services
{
    public interface IListService
    {
        IEnumerable<ListDto> GetAllLists();
        ListDto GetListById(int id);
        ListDto CreateList(ListDto list);
        ListDto UpdateList(int id, ListDto list);
        void DeleteList(int id);
    }

    public class ListService : IListService
    {
        private readonly List<ListDto> _lists = new List<ListDto>();

        public IEnumerable<ListDto> GetAllLists()
        {
            return _lists;
        }

        public ListDto GetListById(int id)
        {
            return _lists.FirstOrDefault(l => l.Id == id);
        }

        public ListDto CreateList(ListDto list)
        {
            list.Id = _lists.Any() ? _lists.Max(l => l.Id) + 1 : 1;  // Simulate auto-increment of ID
            _lists.Add(list);
            return list;
        }
        public ListDto UpdateList(int id, ListDto list)
        {
            var existingList = GetListById(id);
            if (existingList != null)
            {
                existingList.Name = list.Name;
                existingList.TaskCount = list.TaskCount;
                existingList.UserName = list.UserName;
            }
            return existingList;
        }
        public void DeleteList(int id)
        {
            var list = GetListById(id);
            if (list != null)
            {
                _lists.Remove(list);
            }
        }
    }
}