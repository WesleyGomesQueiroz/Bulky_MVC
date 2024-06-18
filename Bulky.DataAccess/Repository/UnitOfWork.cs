using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ICategoryRepository Category { get; set; }
        public ICompanyRepository Company { get; set; }
        public IProductRepository Product { get; set; }
        public IShoppingCartRepository ShoppingCart { get; set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Company = new CompanyRepository(_db);
            Product = new ProductRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
