using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IReviewRepository
    {
        void AddReview(Review review);
        List<Review> GetReviews(int productId);
    }
}
