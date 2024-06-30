using ToDoListAPI.DTOs;
namespace ToDoListAPI.Interface
{

  public interface IListService


  {
    IEnumerable<ListDto> GetAllLists();
    void DeleteList(int id);
    ListDto GetList(int id);
    ListDto UpdateList(int id, ListDto list);
    ListDto CreateList(ListDto list);
  }
}