using AutoMapper;
using Common.Dto;
using Repository.Entities;
using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class MyMapper:Profile
    {
        string DirectoryUrl = Environment.CurrentDirectory + "\\Images\\";
        public MyMapper()
        {
            //"1.jpg"  byte[]
            CreateMap<Category, CategoryDto>().ForMember("Image",s=>s.MapFrom(y=> convertToByte(DirectoryUrl+y.ImageUrl)));
            
            CreateMap<CategoryDto, Category>().ForMember("ImageUrl", s => s.MapFrom(y => y.ImageFile.FileName.ToString()));
        }

        byte[] convertToByte(string s)
        { 
            byte[] bytes =File.ReadAllBytes(s);
            //=Convert.FromBase64String(s);Convert.ToBase64String(

            return bytes;
        }

    }
}
