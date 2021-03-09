using EFCoreRepository.DbContexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zoomtel.Entity;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Zoomtel.Persist.Query;
using EFCoreRepository.Extensions;
using Zoomtel.Utils.Helpers;
using Zoomtel.Entity.Account;
using Zoomtel.Persist.Account.Models;

namespace Zoomtel.Persist.Account
{
   public class AccountRepository : EFCoreRepository.Repositories.RepositoryAb<AccountEntity>
    {
       



        public AccountRepository(DefaultDbContext db):base(db)
        {


        }

        public Task<bool> ExistsEmail(string email, Guid? id = null)
        {

            var q = dbSet.Where(a => a.Email == email);
            if (id != null) { q = q.Where(a => a.Uid != id); }
            return q.AnyAsync();
        }

        public Task<bool> ExistsPhone(string phone, Guid? id = null)
        {

            var q = dbSet.Where(a => a.Phone == phone);
            if (id != null) { q = q.Where(a => a.Uid != id); }
            return q.AnyAsync();
        }

        public Task<bool> ExistsLoginName(string loginname, Guid? id = null)
        {
            var q = dbSet.Where(a => a.LoginName == loginname);
            if (id != null) { q = q.Where(a => a.Uid != id); }
            return q.AnyAsync();
        }

        public Task<AccountEntity> GetByEmail(string email)
        {
            return dbSet.Where(a => a.Email == email).FirstOrDefaultAsync();
        }

        public Task<AccountEntity> GetByPhone(string phone)
        {
            return dbSet.Where(a => a.Phone == phone).FirstOrDefaultAsync();
        }

        public Task<AccountEntity> GetByLoginName(string loginname)
        {
            return dbSet.Where(a => a.LoginName == loginname).FirstOrDefaultAsync();
        }

        public Task<AccountEntity> GetByLoginNameOrEmail(string keyword)
        {
            return dbSet.Where(a => a.LoginName .Contains(keyword)||a.Email.Contains(keyword)).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdatePassword(Guid id, string password)
        {
            var entity= await dbSet.Where(a => a.Uid == id).FirstOrDefaultAsync();
            if (entity!=null)
            {
                entity.PassSalt = new StringHelper().GenerateRandom(8);
                entity.LoginPwd = Zoomtel.Utils.Helpers.Encrypt.DESEncrypt(entity.LoginPwd, entity.PassSalt);
                return DbContext.SaveChanges()>0;


            }
            return false;
        }

        public async Task<QueryResultModel<AccountEntity>> Query(AccountQueryModel model)
        {
            var paging = model.Paging();
            var query = dbSet.AsQueryable();
            if (model.status != null)
            {
                query = query.Where(a => a.Status == model.status);
            }
            if (!model.keyword.IsNull())
            {
                query = query.Where(a => a.LoginName.Contains(model.keyword)||a.Phone.Contains(model.keyword)||a.RealName.Contains(model.keyword));
            }
           
            if (!paging.OrderBy.Any())
            {
                query = query.OrderByDescending(m => m.CreatedTime);
            }
            return await query.PaginationGetResult(paging);
        }
    }
}
