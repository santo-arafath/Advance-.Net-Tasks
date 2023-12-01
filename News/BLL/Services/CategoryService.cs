using BLL.DTOs;
using DLL.EF.Models;
using DLL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BLL.Services
{
    public class CategoryService
    {

        public static string GetById(int id)
        {
            var data = CategoryRepo.GetById(id);
            return data;
        }

        public static string CreateCat(CategoryDTO cdt)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CategoryDTO, Category>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Category>(cdt);
            var msg = CategoryRepo.CreateCat(data);
            return msg;
        }
    }
}
