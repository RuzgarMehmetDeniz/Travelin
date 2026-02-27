using Project3Travelin.Dtos.CommentDtos;
using Project3Travelin.Entities;

namespace Project3Travelin.Services.CommentServices
{
    public interface ICommentServices
    {
        Task<List<ResultCommentDto>> GetAllCommentAsync();
        Task CreateCommentAsync(CreateCommentDto createCommentDto);
        Task UpdateCommentAsync(UpdateCommentDto updateCommentDto);
        Task DeleteCommentAsync(string id);
        Task<GetCommentByIdDto> GetCommentByIdAsync(string id);
        Task<List<Comment>> GetCommentsByTourIdAsync(string tourId);
        Task ApproveCommentAsync(string id);

    }
}
