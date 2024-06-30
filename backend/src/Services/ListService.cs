using ToDoListAPI.DTOs;
using ToDoListAPI.Interfaces;
using AutoMapper;

namespace ToDoListAPI.Services
{
    public class ListService : IListService
    {

        readonly IListRepository _ListRepository;
        private readonly IMapper _mapper;
        public ListService(IListRepository listRepository, IMapper mapper)
        {
            _ListRepository = listRepository;
            _mapper = mapper;
        }
        public ListDto CreateList(ListDto list)
        {
            throw new NotImplementedException();
        }

        public void DeleteList(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ListDto> GetAllLists()
        {
            throw new NotImplementedException();
        }

        public ListDto GetList(int id)
        {
            throw new NotImplementedException();
        }

        public ListDto UpdateList(int id, ListDto list)
        {
            throw new NotImplementedException();
        }
    }
}
