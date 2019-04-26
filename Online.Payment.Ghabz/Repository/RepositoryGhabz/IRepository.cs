using Online.Payment.Ghabz.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online.Payment.Ghabz.Repository.RepositoryGhabz
{
    public interface IRepository
    {
        Task AddGhabz(GhabzHistory AddGhazHistory);
        IQueryable<GhabzHistory> GetGhabzHistory();

        Task<int> Commit();
        Task AddPayment(PaymentHistory paymentHistory);
    }
}
