using RobotBloger.Application.Services.BlogServices.Dto;

namespace RobotBloger.Application.Services.BlogServices
{
    public interface IBlogService
    {

        #region BlogType


        public Task<List<BlogTypeDto>> GetAllBlogTypesAsync();
        public Task<BlogTypeDto> GetBlogTypeWithIdAsync(BlogTypeDto blogTypeDto);
        public Task AddBlogTypeAsync(BlogTypeDto blogTypeDto);

        public Task DeleteBlogTypeAsync(BlogTypeDto blogTypeDto);

        public Task UpdateBlogTypeAsync(BlogTypeDto blogTypeDto);


        #endregion

        #region Blog

        public Task<List<BlogDto>> GetAllBlogsAsync();
        public Task<List<BlogDto>> GetAllBlogsWithTypeIdAsync(BlogDto blogDto);
        public Task<List<BlogDto>> GetLastBlogsAsync();
        public Task<BlogDto> GetBlogWithIdAsync(BlogDto blogDto);

        public Task<BlogDto> GetBlogWithURLAsync(string url);

        public Task<BlogDto> GetBlogWithUrlAsync(BlogDto blogDto);
        public Task AddBlogAsync(BlogDto blogDto);

        public Task DeleteBlogAsync(BlogDto blogDto);

        public Task UpdateBlogAsync(BlogDto blogDto);
        public Task<List<BlogDto>> GetAllBlogsForMasterAsync();




        #endregion


    }
}
