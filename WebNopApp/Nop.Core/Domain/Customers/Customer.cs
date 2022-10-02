using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Nop.Core.Domain.Customers
{
    public class Customer : BaseEntity
    {
        /// <summary>
        /// 用户账号
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 用户电话
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// 用户部门
        /// </summary>
        public int DepartMentId { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }
    }
}
