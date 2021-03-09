using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zoomtel.Entity.BaseType
{
    [Table("T_SYS_BASETYPEINFO")]
    public class BaseTypeInfoEntity : BaseEntity
    {
        public string Id { set; get; }

        public string TypeCode { set; get; }

        public string TypeName { set; get; }

        public string TypeContent { set; get; }

        /// <summary>
        /// 是否对外维护  10:对外开放  20:不对外开放
        /// </summary>
        public string TypeFlag { set; get; }

        public string Remarks { set; get; }

        /// <summary>
        /// 10:表示可用  0:表示删除
        /// </summary>
        public string DelStatus { set; get; }

        public string Seq { set; get; }
        
        public string EXTAttr1 { set; get; }

        public string EXTAttr2 { set; get; }

        public string EXTAttr3 { set; get; }

        public string EXTAttr4 { set; get; }

        public string EXTAttr5 { set; get; }
    }
}
