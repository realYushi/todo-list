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
        public ListDto CreateList(ListDto list, string userId)
        {
            List listEntity = _mapper.Map<List>(list);
            listEntity.UserId = userId; // Set UserId before passing to repository
            List createdListEntity = _unitOfWork.ListRepository.CreateList(listEntity, userId);
            _unitOfWork.Save();
            return _mapper.Map<ListDto>(createdListEntity);
        }

        public void DeleteList(string id, string userId)
        {
            _unitOfWork.ListRepository.DeleteList(id, userId);
            _unitOfWork.Save();
        }

        public IEnumerable<ListDto> GetAllLists(string userId)
        {
            IEnumerable<Models.List> lists = _unitOfWork.ListRepository.GetAllLists(userId);
            return _mapper.Map<IEnumerable<ListDto>>(lists);
        }

        public ListDto GetList(string id, string userId)
        {
            List list = _unitOfWork.ListRepository.GetList(id, userId);
            return _mapper.Map<ListDto>(list);
        }

        public ListDto UpdateList(string id, ListDto list, string userId)
        {
            List listEntity = _mapper.Map<List>(list);
            List updatedListEntity = _unitOfWork.ListRepository.UpdateList(id, listEntity, userId);
            _unitOfWork.Save();
            return _mapper.Map<ListDto>(updatedListEntity);
        }
    }
}
