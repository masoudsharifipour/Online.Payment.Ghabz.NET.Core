using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Online.Payment.Ghabz.Repository.DbContexts;
using Online.Payment.Ghabz.Repository.Models;

namespace Online.Payment.Ghabz.Repository.RepositoryGhabz
{
    public class Repository : IRepository
    {
        private readonly OnlinePaymentGhabzDbContext _db;

        public Repository(OnlinePaymentGhabzDbContext db)
        {
            this._db = db;
        }
        public async Task AddGhabz(GhabzHistory AddGhazHistory)
        {
            await this._db.ghabzHistories.AddAsync(AddGhazHistory);

            await this.Commit();
        }

        public async Task AddPayment(PaymentHistory paymentHistory)
        {
            await this._db.paymentHistories.AddAsync(paymentHistory);
            await this.Commit();
           
        }

        public async Task<int> Commit()
        {
            return await this._db.SaveChangesAsync();
        }

        public IQueryable<GhabzHistory> GetGhabzHistory()
        {
            return this._db.ghabzHistories.AsQueryable();
        }

    }
}
