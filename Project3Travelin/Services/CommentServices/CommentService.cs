using AutoMapper;
using MongoDB.Driver;
using Project3Travelin.Dtos.CategoryDtos;
using Project3Travelin.Dtos.CommentDtos;
using Project3Travelin.Entities;
using Project3Travelin.Settings;
using System.Xml.Linq;

namespace Project3Travelin.Services.CommentServices
{
    public class CommentService : ICommentServices
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Comment> _CommentCollention;

        public CommentService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _CommentCollention = database.GetCollection<Comment>(_databaseSettings.CommentCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCommentAsync(CreateCommentDto createCommentDto)
        {
            var values = _mapper.Map<Comment>(createCommentDto);
            await _CommentCollention.InsertOneAsync(values);
        }

        public async Task DeleteCommentAsync(string id)
        {
            await _CommentCollention.DeleteOneAsync(x => x.CommentId == id);
        }

        public async Task<List<ResultCommentDto>> GetAllCommentAsync()
        {
            var values = await _CommentCollention.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultCommentDto>>(values);
        }

        public async Task<GetCommentByIdDto> GetCommentByIdAsync(string id)
        {
            var value = await _CommentCollention.Find(x => x.CommentId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetCommentByIdDto>(value);
        }

        public async Task<List<Comment>> GetCommentsByTourIdAsync(string tourId)
        {
            return await _CommentCollention
                .Find(c => c.TourId == tourId)
                .ToListAsync();
        }

        public async Task UpdateCommentAsync(UpdateCommentDto updateCommentDto)
        {
            var value = _mapper.Map<Comment>(updateCommentDto);
            await _CommentCollention.FindOneAndReplaceAsync(x => x.CommentId == updateCommentDto.CommentId, value);

        }
    }
}
