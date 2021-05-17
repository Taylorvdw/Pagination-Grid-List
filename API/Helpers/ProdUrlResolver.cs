using API.Dto;
using API.Models;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class ProdUrlResolver : IValueResolver<Product, ProdDto, string>
    {
        private readonly IConfiguration _config;
        public ProdUrlResolver(IConfiguration config)
        {
            _config = config;
        }
        public string Resolve(Product source, ProdDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["APIUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}
