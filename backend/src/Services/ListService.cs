using ToDoListAPI.DTOs;
using ToDoListAPI.Interfaces;
using AutoMapper;
using ToDoListAPI.Models;

namespace ToDoListAPI.Services
{
    public class ListService : IListService
    {
        private readonly IListRepository _listRepository;
        private readonly IMapper _mapper;

        public ListService(IListRepository listRepository, IMapper mapper)
        {
            _listRepository = listRepository;
            _mapper = mapper;
        }

        public async Task<ListDto> CreateListAsync(ListDto list, Guid userId)
        {
            list.UserId = userId;
            Models.List listEntity = _mapper.Map<Models.List>(list);
            Models.List createdListEntity = await _listRepository.CreateListAsync(listEntity, userId);
            return _mapper.Map<ListDto>(createdListEntity);
        }

        public async Task<bool> DeleteListAsync(Guid listId, Guid userId)
        {
            return await _listRepository.DeleteListAsync(listId, userId);
        }

        public async Task<IEnumerable<ListDto>> GetAllListsAsync(Guid userId)
        {
            IEnumerable<Models.List> lists = await _listRepository.GetAllListsAsync(userId);
            return _mapper.Map<IEnumerable<ListDto>>(lists);
        }

        public async Task<ListDto> GetListAsync(Guid listId, Guid userId)
        {
            Models.List list = await _listRepository.GetListAsync(listId, userId);
            return _mapper.Map<ListDto>(list);
        }

        public async Task<ListDto> UpdateListAsync(Guid listId, ListDto list, Guid userId)
        {
            var existingList = await _listRepository.GetListAsync(listId, userId);
            if (existingList == null)
            {
                return null;
            }

            existingList.Title = list.Title;
            existingList.Description = list.Description;
            Models.List updatedListEntity = await _listRepository.UpdateListAsync(listId, existingList, userId);
            return _mapper.Map<ListDto>(updatedListEntity);
        }
    }
}
