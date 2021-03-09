#region License
/***
 * Copyright © 2018-2020, 张强 (943620963@qq.com).
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * without warranties or conditions of any kind, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
#endregion

using EFCoreRepository.Extensions;
using EFCoreRepository.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using Zoomtel.Entity;
namespace EFCoreRepository.DbContexts
{
    /// <summary>
    /// 默认DbContext
    /// </summary>
    public class DefaultDbContext : DbContext
    {
        /// <summary>
        /// DbContext配置
        /// </summary>
        private readonly Action<DbContextOptionsBuilder> _options;

        /// <summary>
        ///登陆信息
        /// </summary>
        public ILoginInfo LoginInfo { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="options"></param>
        public DefaultDbContext(Action<DbContextOptionsBuilder> options,ILoginInfo loginInfo=null)
        {
            _options = options;
            LoginInfo = loginInfo;
        }

        public DefaultDbContext(DbContextOptions<DefaultDbContext> options, ILoginInfo loginInfo=null)
        : base(options)
        {
            LoginInfo = loginInfo;
        }



        /// <summary>
        /// OnConfiguring
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _options?.Invoke(optionsBuilder);
        }

        /// <summary>
        /// OnModelCreating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Zoomtel.Entity.Test.T1Entity>(b =>
            //{
            //    b.Property(a => a.dt).HasDefaultValueSql("getdate()");
            //    b.Property<int>("id").HasDefaultValueSql("NEXT VALUE FOR shared.OrderNumbers").ValueGeneratedOnAdd();
            //    b.Property(a => a.test).HasDefaultValue("ttttt2222555").ValueGeneratedOnAddOrUpdate();
            //    b.ToTable("t1");
            //    b.HasKey("id");
            //});


            //    modelBuilder.HasSequence<int>("OrderNumbers", schema: "shared")
            //.StartsAt(1000)
            //.IncrementsBy(5);

            var entityTypes = AssemblyHelper
                                .GetTypesFromAssembly(null,x=>x.Contains("Entity"))
                                .Where(type =>
                                    !type.Namespace.IsNullOrWhiteSpace() &&
                                    type.GetTypeInfo().IsClass &&
                                    //type.GetTypeInfo().BaseType != null &&
                                    type != typeof(BaseEntity) &&
                                    typeof(BaseEntity).IsAssignableFrom(type));
            //if(entityTypes!=)
            if (entityTypes?.Count() > 0)
            {
                foreach (var entityType in entityTypes)
                {
                    if (modelBuilder.Model.FindEntityType(entityType) != null)
                        continue;
                    modelBuilder.Model.AddEntityType(entityType);
                }
            }
        }
    }
}