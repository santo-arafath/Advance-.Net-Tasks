using AutoMapper;
using BLL.DTOs;
using DLL.EF.Models;
using DLL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class NewsService
    {

        public static string GetById(int id)
        {
            var data = NewsRepo.GetById(id);
            return data;
        }

        public static string Createnews(NewsDTO cdt)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<NewsDTO, News>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<News>(cdt);
            var msg = NewsRepo.Createnews(data);
            return msg;
        }
    }
}
