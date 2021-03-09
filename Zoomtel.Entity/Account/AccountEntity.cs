using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Zoomtel.Entity.Account
{
    [Table("T_SYS_ACCOUNT")]
    public class AccountEntity:EntityBaseWithMdInfo,BaseEntity
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //设置自增
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid Uid { get; set; }

        /// <summary>
        /// 启用状态
        /// </summary>
        public bool Status { get; set; } 

        [MaxLength(30)]
        /// <summary>
        /// 用户名
        /// </summary>
        public string LoginName { get; set; }


        [MaxLength(100)]
        //[Required]
        /// <summary>
        /// 用户密码
        /// </summary>
        public string LoginPwd { get; set; }


        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(300)]
        public string Email { get; set; } = string.Empty;
        /// <summary>
        /// 密码盐
        /// </summary>
        public string PassSalt { get; set; }


        /// <summary>
        /// 登陆次数
        /// </summary>
        public int LoginCount { get; set; }

        /// <summary>
        /// 最后登陆IP
        /// </summary>
        public string LastIp { get; set; }

        /// <summary>
        /// 最后登陆用户信息
        /// </summary>
        public string LastUserAgent { get; set; }

        /// <summary>
        /// 性别 1男 0女 2不详
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 关联角色
        /// </summary>
        [NotMapped]
        public List<OptionResultModel> Roles { get; set; }
    }
}
