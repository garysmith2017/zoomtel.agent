using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
namespace EFCoreRepository.Extensions
{
    /// <summary>
    /// 序列扩展方法
    /// </summary>
    public static class SeqExtensions
    {


        /// <summary>
        /// 获取序列
        /// </summary>
        /// <param name="db"></param>
        /// <param name="seqname"></param>
        /// <returns></returns>
        public static int GetSeq(this DbContext db, string seqname)
        {
          return Convert.ToInt32( db.ExecuteScalar("SELECT NEXT VALUE FOR "+seqname,null));
        }

    }
}
