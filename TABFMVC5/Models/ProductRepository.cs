using System;
using System.Linq;
using System.Collections.Generic;
	
namespace TABFMVC5.Models
{
    public class ProductRepository : EFRepository<Product>, IProductRepository
    {
        public override IQueryable<Product> All()
        {
            return base.All().Where(p => p.Active.HasValue && p.Active.Value);
        }

        public IQueryable<Product> Get所有資料_可判斷是否顯示刪除的資料(bool isShowDeleted)
        {
            if (!isShowDeleted)
            {
                return this.All().Where(p => !p.IsShowDeleted);
            }

            return this.All();
        }

        public IQueryable<Product> GetTop10()
        {
            return this.All().Take(10);
        }

        public Product Find(int? id)
        {
            if (!id.HasValue)
            {
                return null;
            }

            return this.All().FirstOrDefault(p => p.ProductId == id.Value);
        }
    }

    public  interface IProductRepository : IRepository<Product>
	{

	}
}