using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OmnitroTool.Server.Models;
namespace OmnitroTool.Server.Service
{
    public class ProductsService
    {
        omniservicesintContext _db;
        public ProductsService(omniservicesintContext db)
        {
            this._db = db;
        }

        public async Task <List<string>> GetAllProducts()
        {
            var productsNames = await _db.Products
                .Select(x => x.Name).ToListAsync();
            return productsNames;
        }
            
            }
    }

