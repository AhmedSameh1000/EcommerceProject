using Core.Interfaces;
using Core.Models;
using InfraStructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext appDbContext;

        public ReviewRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public void AddReview(Review review)
        {
            appDbContext.Reviews.Add(review);
            appDbContext.SaveChanges();
        }

        public List<Review> GetReviews(int productId)
        {
            var Reviews=appDbContext.Reviews.Where(c=>c.productId==productId).ToList();
            return Reviews;
        }
    }
}
