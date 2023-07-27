using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RobotBloger.Application.Services.BlogServices.Dto;
using RobotBloger.Domain.Entitys;
using RobotBloger.Infrastrucute.Data;

namespace RobotBloger.Application.Services.BlogServices
{
    public class BlogService : IBlogService
    {
        readonly IMapper _mapper;
        readonly RobotBlogerDbContext _work;
        public BlogService(IMapper mapper, RobotBlogerDbContext context)
        {
            _mapper = mapper;
            _work = context;


        }


        #region Blog



        public async Task<List<BlogDto>> GetAllBlogsForMasterAsync()
        {
            var list = await _work.Blogs.Include(x => x.BlogType).Where(x => x.Status && x.BlogType.Status).OrderByDescending(x => x.RelaseTime).ToListAsync();

            var ml = _mapper.Map<List<BlogDto>>(list);
            return ml;
        }

        public async Task<List<BlogDto>> GetAllBlogsWithTypeIdAsync(BlogDto blogDto)
        {
            var list = await _work.Blogs.Include(x => x.BlogType).Where(x => x.Status && x.BlogType.Status && x.BlogTypeId==blogDto.BlogTypeId &&
            x.RelaseTime<=DateTime.Now).OrderByDescending(x => x.RelaseTime).ToListAsync();

            var ml = _mapper.Map<List<BlogDto>>(list);
            return ml;
        }


        public async Task AddBlogAsync(BlogDto blogDto)
        {
            var entity = _mapper.Map<Blog>(blogDto);
            entity.Id = Guid.NewGuid();
            entity.Status = true;
            entity.CreateTime = DateTime.Now;
          
            entity.BlogTypeId = new Guid("53212c81-ba97-4191-b875-231476a3107b");
            entity.RelaseTime = blogDto.RelaseTime;



            File.WriteAllBytes((@"D:\Özel Dosyalar\dotnethocasi\public\assets\img\blog\small\" + entity.Id.ToString() + ".jpg"),
                Convert.FromBase64String(entity.SmallPhoto.Replace("data:image/jpeg;base64,", "")));
            File.WriteAllBytes((@"D:\Özel Dosyalar\dotnethocasi\public\assets\img\blog\big\" + entity.Id.ToString() + ".jpg"),
                Convert.FromBase64String(entity.BigPhoto.Replace("data:image/jpeg;base64,", "")));
            entity.BigPhoto = (@"../assets/img/blog/big/" + entity.Id.ToString() + ".jpg");
            entity.SmallPhoto = (@"../assets/img/blog/small/" + entity.Id.ToString() + ".jpg");




            await _work.Blogs.AddAsync(entity);
            await _work.SaveChangesAsync();


        }



        public async Task DeleteBlogAsync(BlogDto blogDto)
        {
            var entity = await _work.Blogs.FirstOrDefaultAsync(x => x.Status && x.Id == blogDto.Id);
            entity.Status = false;
            _work.Blogs.Update(entity);
            await _work.SaveChangesAsync();
        }

        public async Task<List<BlogDto>> GetLastBlogsAsync()
        {
            var list = await _work.Blogs.Include(x => x.BlogType).
                Where(x => x.Status && x.BlogType.Status && x.RelaseTime < DateTime.Now).OrderByDescending(x => x.RelaseTime).Take(30).ToListAsync();

            var mlist = _mapper.Map<List<BlogDto>>(list);

            foreach (var item in mlist)
            {

                item.Description = item.Content.Replace("<p>","").Replace("</p>","").Substring(0,50) + "...";
            }

            return (mlist);
        }
        public async Task<List<BlogDto>> GetAllBlogsAsync()
        {


            var list = await _work.Blogs.Include(x => x.BlogType).
                Where(x => x.Status && x.BlogType.Status && x.RelaseTime < DateTime.Now).OrderByDescending(x => x.RelaseTime).ToListAsync();




            return (_mapper.Map<List<BlogDto>>(list));
        }



        public async Task<BlogDto> GetBlogWithIdAsync(BlogDto blogDto)
        {
            var entity = await _work.Blogs.Include(x => x.BlogType).FirstOrDefaultAsync(x => x.Status && x.Id == blogDto.Id);


            return (_mapper.Map<BlogDto>(entity));
        }

        public async Task UpdateBlogAsync(BlogDto blogDto)
        {
            var entity = await _work.Blogs.FirstOrDefaultAsync(x => x.Status && x.Id == blogDto.Id);

          
            entity.Header = blogDto.Header;
            entity.RelaseTime = blogDto.RelaseTime;
       
            entity.Status = true;
            entity.BlogTypeId = blogDto.BlogTypeId;
            _work.Blogs.Update(entity);

            await _work.SaveChangesAsync();



        }



        #endregion

        #region BlogType


        public async Task AddBlogTypeAsync(BlogTypeDto blogDto)
        {
            var entity = _mapper.Map<BlogType>(blogDto);
            entity.Status = true;

            await _work.BlogTypes.AddAsync(entity);
            await _work.SaveChangesAsync();


        }


        public async Task<List<BlogTypeDto>> GetAllBlogTypesAsync()
        {
            var list = await _work.BlogTypes.Where(x => x.Status).ToListAsync();

            return (_mapper.Map<List<BlogTypeDto>>(list));
        }

        public async Task<BlogTypeDto> GetBlogTypeWithIdAsync(BlogTypeDto blogTypeDto)
        {
            var entity = await _work.BlogTypes.FirstOrDefaultAsync(x => x.Status && x.Id == blogTypeDto.Id);

            return (_mapper.Map<BlogTypeDto>(entity));
        }

        public async Task UpdateBlogTypeAsync(BlogTypeDto blogTypeDto)
        {
            var entity = await _work.BlogTypes.FirstOrDefaultAsync(x => x.Status && x.Id == blogTypeDto.Id);

            entity.Status = true;
            entity.Name = blogTypeDto.Name;

            _work.BlogTypes.Update(entity);

            await _work.SaveChangesAsync();

        }



        public async Task DeleteBlogTypeAsync(BlogTypeDto blogTypeDto)
        {
            var entity = await _work.BlogTypes.FirstOrDefaultAsync(x => x.Status && x.Id == blogTypeDto.Id);
            entity.Status = false;
            _work.BlogTypes.Update(entity);
            await _work.SaveChangesAsync();

        }

        public async Task<BlogDto> GetBlogWithUrlAsync(BlogDto blogDto)
        {
            var entity = await _work.Blogs.Include(x => x.BlogType).Where(x => x.Status && x.BlogType.Status && x.Url == blogDto.Url).FirstOrDefaultAsync();

            var em = _mapper.Map<BlogDto>(entity);

            return em;
        }

        public async Task<BlogDto> GetBlogWithURLAsync(string url)
        {
            var blog = await _work.Blogs.Include(x=>x.BlogType).FirstOrDefaultAsync(x=>x.Status && x.Url== url);
            var mblog = _mapper.Map<BlogDto>(blog);

            return mblog; 

        }

       


        #endregion




    }
}
