﻿// <auto-generated />
using System;
using EFCoreRepository.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Zoomtel.PersistComm.Migrations
{
    [DbContext(typeof(DefaultDbContext))]
    [Migration("20201204081842_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Zoomtel.Entity.Account.AccountEntity", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreatedBy");

                    b.Property<DateTime?>("CreatedTime");

                    b.Property<string>("Creator");

                    b.Property<string>("Email")
                        .HasMaxLength(300);

                    b.Property<string>("LastIp");

                    b.Property<string>("LastUserAgent");

                    b.Property<int>("LoginCount");

                    b.Property<string>("LoginName")
                        .HasMaxLength(30);

                    b.Property<string>("LoginPwd")
                        .HasMaxLength(100);

                    b.Property<Guid>("ModifiedBy");

                    b.Property<DateTime>("ModifiedTime");

                    b.Property<string>("Modifier");

                    b.Property<string>("PassSalt");

                    b.Property<string>("Phone")
                        .HasMaxLength(20);

                    b.Property<string>("RealName");

                    b.Property<int>("Sex");

                    b.Property<bool>("Status");

                    b.HasKey("Uid");

                    b.ToTable("T_SYS_ACCOUNT");
                });

            modelBuilder.Entity("Zoomtel.Entity.Account.AccountRoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleId");

                    b.Property<Guid>("Uid");

                    b.HasKey("Id");

                    b.ToTable("T_SYS_ACCOUNTROLE");
                });

            modelBuilder.Entity("Zoomtel.Entity.AuditInfo.AuditInfoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action");

                    b.Property<string>("ActionDesc");

                    b.Property<string>("Area");

                    b.Property<string>("BrowserInfo")
                        .HasMaxLength(500);

                    b.Property<string>("Controller");

                    b.Property<string>("ControllerDesc");

                    b.Property<long>("ExecutionDuration");

                    b.Property<DateTime>("ExecutionTime");

                    b.Property<string>("IP");

                    b.Property<string>("LoginName");

                    b.Property<string>("Parameters");

                    b.Property<string>("Result");

                    b.Property<Guid>("Uid");

                    b.HasKey("Id");

                    b.ToTable("T_SYS_AUDITINFO");
                });

            modelBuilder.Entity("Zoomtel.Entity.BaseType.BaseTypeInfoEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DelStatus");

                    b.Property<string>("EXTAttr1");

                    b.Property<string>("EXTAttr2");

                    b.Property<string>("EXTAttr3");

                    b.Property<string>("EXTAttr4");

                    b.Property<string>("EXTAttr5");

                    b.Property<string>("Remarks");

                    b.Property<string>("Seq");

                    b.Property<string>("TypeCode");

                    b.Property<string>("TypeContent");

                    b.Property<string>("TypeFlag");

                    b.Property<string>("TypeName");

                    b.HasKey("Id");

                    b.ToTable("T_SYS_BASETYPEINFO");
                });

            modelBuilder.Entity("Zoomtel.Entity.Menu.MenuEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasMaxLength(150);

                    b.Property<Guid>("CreatedBy");

                    b.Property<DateTime?>("CreatedTime");

                    b.Property<string>("Creator");

                    b.Property<int>("Fid");

                    b.Property<string>("Icon");

                    b.Property<string>("MenuName");

                    b.Property<Guid>("ModifiedBy");

                    b.Property<DateTime>("ModifiedTime");

                    b.Property<string>("Modifier");

                    b.Property<string>("ModuleCode")
                        .HasMaxLength(150);

                    b.Property<int>("Seq");

                    b.Property<string>("Target")
                        .HasMaxLength(20);

                    b.Property<string>("Url");

                    b.Property<bool>("Visible");

                    b.HasKey("Id");

                    b.ToTable("T_SYS_MENUS");
                });

            modelBuilder.Entity("Zoomtel.Entity.Quartz.TaskEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BeginDate");

                    b.Property<string>("ClassName");

                    b.Property<Guid>("CreatedBy");

                    b.Property<DateTime?>("CreatedTime");

                    b.Property<string>("Creator");

                    b.Property<string>("Cron");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Group");

                    b.Property<int>("IntervalInSeconds");

                    b.Property<Guid>("ModifiedBy");

                    b.Property<DateTime>("ModifiedTime");

                    b.Property<string>("Modifier");

                    b.Property<int>("RepeatCount");

                    b.Property<int>("Status");

                    b.Property<string>("TaskCode");

                    b.Property<string>("TaskName");

                    b.Property<int>("TriggerType");

                    b.HasKey("Id");

                    b.ToTable("T_QUARTZ_TASK");
                });

            modelBuilder.Entity("Zoomtel.Entity.Quartz.TaskGroupEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GroupCode");

                    b.Property<string>("GroupName");

                    b.HasKey("Id");

                    b.ToTable("T_QUARTZ_TASKGROUP");
                });

            modelBuilder.Entity("Zoomtel.Entity.Quartz.TaskLogEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedTime");

                    b.Property<string>("Msg");

                    b.Property<Guid>("TaskId");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("T_QUARTZ_TASKLOG");
                });

            modelBuilder.Entity("Zoomtel.Entity.Role.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("CreatedBy");

                    b.Property<DateTime?>("CreatedTime");

                    b.Property<string>("Creator");

                    b.Property<Guid>("ModifiedBy");

                    b.Property<DateTime>("ModifiedTime");

                    b.Property<string>("Modifier");

                    b.Property<string>("Remark");

                    b.Property<string>("RoleName");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.ToTable("T_SYS_ROLES");
                });

            modelBuilder.Entity("Zoomtel.Entity.Role.RoleMenuEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MenuId");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.ToTable("T_SYS_ROLEMENUS");
                });

            modelBuilder.Entity("Zoomtel.Entity.Role.RolePermissionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PermissionCode");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.ToTable("T_SYS_ROLEPERMISSION");
                });
#pragma warning restore 612, 618
        }
    }
}
