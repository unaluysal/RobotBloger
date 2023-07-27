using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RobotBloger.Application.Services.BlogServices;
using RobotBloger.Application.Services.BlogServices.Dto;

namespace RobotBloger.Api.Controllers
{
 
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        readonly IBlogService _blogService;
        public BlogController(IBlogService blogService) {


            _blogService = blogService;

        }


        #region Blog

        [HttpGet("GetAllBlogs")]

        public async Task<ActionResult> GetAllBlogs()
        {


            var list = await _blogService.GetAllBlogsAsync();


            return Ok(list);

        }

        [HttpPost("GetAllBlogsWithType")]

        public async Task<ActionResult> GetAllBlogsWithType(BlogDto blogDto)
        {


            var list = await _blogService.GetAllBlogsWithTypeIdAsync(blogDto);


            return Ok(list);

        }


        [HttpGet("GetlLastBlogs")]

        public async Task<ActionResult> GetlLastBlogs()
        {


            var list = await _blogService.GetLastBlogsAsync();


            return Ok(list);

        }

        [HttpPost("GetBlogWithId")]

        public async Task<ActionResult> GetBlogWithId(BlogDto blogDto)
        {


            var dto = await _blogService.GetBlogWithIdAsync(blogDto);



            return Ok(dto);

        }


        [HttpPost("GetBlogWithUrl")]

        public async Task<ActionResult> GetBlogWithUrl(BlogDto blogDto)
        {


            var dto = await _blogService.GetBlogWithUrlAsync(blogDto);



            return Ok(dto);

        }

        [HttpPost("AddBlog")]

        public async Task<ActionResult> AddBlog(BlogDto blogDt)
        {


            await _blogService.AddBlogAsync(blogDt);


            return Ok();

        }

        [HttpGet("GetAllBlogsForMaster")]

        public async Task<ActionResult> GetAllBlogsForMaster()
        {


            var list = await _blogService.GetAllBlogsForMasterAsync();


            return Ok(list);

        }


        [HttpPost("UpdateBlog")]

        public async Task<ActionResult> UpdateBlog(BlogDto blogDto)
        {


            await _blogService.UpdateBlogAsync(blogDto);


            return Ok();

        }


        [HttpPost("DeleteBlog")]

        public async Task<ActionResult> DeleteBlog(BlogDto blogDto)
        {


            await _blogService.DeleteBlogAsync(blogDto);


            return Ok();

        }


        #endregion
        #region BlogType



        [HttpGet("GetAllBlogTypes")]

        public async Task<ActionResult> GetAllBlogTypes()
        {


            var list = await _blogService.GetAllBlogTypesAsync();


            return Ok(list);

        }

        [HttpGet("GetBlogTypeWithId")]

        public async Task<ActionResult> GetBlogTypeWithId(BlogTypeDto blogTypeDto)
        {


            var list = await _blogService.GetBlogTypeWithIdAsync(blogTypeDto);


            return Ok(list);

        }

        [HttpPost("AddBlogType")]

        public async Task<ActionResult> AddBlogType(BlogTypeDto blogTypeDto)
        {


            await _blogService.AddBlogTypeAsync(blogTypeDto);


            return Ok();

        }


        [HttpPost("UpdateBlogType")]

        public async Task<ActionResult> UpdateBlogType(BlogTypeDto blogTypeDto)
        {


            await _blogService.UpdateBlogTypeAsync(blogTypeDto);


            return Ok();

        }


        [HttpPost("DeleteBlogType")]

        public async Task<ActionResult> DeleteBlogType(BlogTypeDto blogTypeDto)
        {


            await _blogService.DeleteBlogTypeAsync(blogTypeDto);


            return Ok();

        }



        #endregion

    }
}
