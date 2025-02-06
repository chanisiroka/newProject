using AutoMapper;
using Common.Dto;
using Repository.Entities;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CategoryService : IService<CategoryDto>
    {
        private readonly IRepository<Category> _repository;
        //imapper-ממשק המטפל בהמרה
        private IMapper mapper;
        public CategoryService(IRepository<Category> repository,IMapper mapper)
        {
            this._repository = repository;
            this.mapper = mapper;
        }
        public async Task< CategoryDto> AddItem(CategoryDto item)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Images/", item.ImageFile.FileName);
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                item.ImageFile.CopyTo(fs);
                //  fs.Close();
            }
            return  mapper.Map<CategoryDto>(await _repository.AddItem(mapper.Map<Category>(item)));
        }

        public async Task DeleteItem(int id)
        {
          await _repository.DeleteItem(id);
        }

        public async Task< List<CategoryDto>> GetAll()
        {
           return mapper.Map<List<CategoryDto>>(await _repository.GetAll());
        }

        public async Task< CategoryDto> GetById(int id)
        {
           
            return mapper.Map<CategoryDto>(await _repository.GetById(id));

        }

        public async Task<CategoryDto> UpdateItem(int id, CategoryDto item)
        {
            return mapper.Map<CategoryDto>(await _repository.UpdateItem(id,mapper.Map<Category>(item)));  
        }
    }
}
