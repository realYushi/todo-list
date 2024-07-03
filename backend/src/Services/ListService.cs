using ToDoListAPI.DTOs;
using ToDoListAPI.Interfaces;
using ToDoListAPI.Data;
using AutoMapper;
using ToDoListAPI.Models;

namespace ToDoListAPI.Services
{
    public class ListService : IListService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ListService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public ListDto CreateList(ListDto list)
        {
            List listEntity = _mapper.Map<List>(list);
            _unitOfWork.ListRepository.CreateList(listEntity);
            ListDto createdList = _mapper.Map<ListDto>(listEntity);
            _unitOfWork.Save();
            return createdList;
        }

        public void DeleteList(String id)
        {
            String listId = id;
            _unitOfWork.ListRepository.DeleteList(listId);
            _unitOfWork.Save();
        }

        public IEnumerable<ListDto> GetAllLists()
        {
            IEnumerable<Models.List> lists = _unitOfWork.ListRepository.GetAllLists();
            return _mapper.Map<IEnumerable<ListDto>>(lists);
        }

        public ListDto GetList(String id)
        {
            String listId = id;
            List list = _unitOfWork.ListRepository.GetList(listId);
            return _mapper.Map<ListDto>(list);

        }

        public ListDto UpdateList(String id, ListDto list)
        {
            String listId = id;
            ListDto updatedList = list;
            List listEntity = _mapper.Map<List>(updatedList);
            List updatedListEntity = _unitOfWork.ListRepository.UpdateList(listId, listEntity);
            _unitOfWork.Save();
            return _mapper.Map<ListDto>(updatedListEntity);
        }
    }
}
