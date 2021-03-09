using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Zoomtel.Quartz.Abstractions
{
    public enum QuartzSerializerType
    {
        [Description("JSON")]
        Json,
        [Description("XML")]
        Xml
    }
    public enum QuartzProvider
    {
        [Description("SqlServer")]
        SqlServer,
        [Description("MySql")]
        MySql,
        [Description("SQLite-Microsoft")]
        SQLite,
        [Description("OracleODP")]
        Oracle,
        [Description("Npgsql")]
        PostgreSQL
    }
    /// <summary>
    /// Quartz配置
    /// </summary>
    public class QuartzConfig 
    {
        /// <summary>
        /// 开启
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 启用日志
        /// </summary>
        public bool Logger { get; set; } = false;

        /// <summary>
        /// 实例名称
        /// </summary>
        [Required(ErrorMessage = "实例名称不能为空")]
        public string InstanceName { get; set; } = "QuartzServer";

        /// <summary>
        /// 表前缀
        /// </summary>
        public string TablePrefix { get; set; } = "QRTZ_";

        /// <summary>
        /// 序列化方式
        /// </summary>
        public QuartzSerializerType SerializerType { get; set; } = QuartzSerializerType.Json;

        /// <summary>
        /// 数据库类型
        /// </summary>
        public QuartzProvider Provider { get; set; } = QuartzProvider.SqlServer;

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        [Required(ErrorMessage = "数据库连接字符串不能为空")]
        public string ConnectionString { get; set; }

        /// <summary>
        /// 数据源
        /// </summary>
        public string DataSource { get; set; } = "default";

        public NameValueCollection ToProps()
        {
            return new NameValueCollection
            {
                ["quartz.scheduler.instanceName"] = InstanceName,
                ["quartz.jobStore.type"] = "Quartz.Impl.AdoJobStore.JobStoreTX,Quartz",
                ["quartz.jobStore.driverDelegateType"] = "Quartz.Impl.AdoJobStore.StdAdoDelegate,Quartz",
                ["quartz.jobStore.tablePrefix"] = TablePrefix,
                ["quartz.jobStore.dataSource"] = DataSource,
                ["quartz.dataSource.default.connectionString"] = ConnectionString,
                ["quartz.dataSource.default.provider"] = Provider.ToDescription(),
                ["quartz.serializer.type"] = SerializerType.ToDescription()
            };
        }
    }
}
