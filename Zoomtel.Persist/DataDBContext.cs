using Microsoft.EntityFrameworkCore;
using System;
using Zoomtel.Entity;

namespace Zoomtel.Persist
{
    public class DataDBContext : DbContext
    {
        public DataDBContext(DbContextOptions<DataDBContext> options)
            : base(options)
        {

        }

        public DbSet<AccountEntity> Accounts { get; set; }

        /// <summary>
        /// 订单
        /// </summary>
        //public DbSet<OrderInfo> OrderInfos { get; set; }
        /// <summary>
        /// 乘客
        /// </summary>
        //public DbSet<Passenger> Passengers { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        //public DbSet<Address> Addresses { get; set; }
    }
}
