using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zoomtel.Entity
{
    [Table("orderinfo", Schema = "manager")]
    public class OrderInfo
    {

        [JsonProperty("id")]
        [Required]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// 订单Id
        /// </summary>
        [JsonProperty("order_id")]
        [Required]
        [Column("order_id")]
        public int OrderId { get; set; }

        [JsonProperty("passengerid")]
        [Column("passenger_id")]
        public int PassengerId { get; set; }



        [JsonProperty("addressid")]
        [Column("address_id")]
        public int AddressId { get; set; }

        /// <summary>
        /// 订单价格
        /// </summary>
        [StringLength(maximumLength: 100)]
        [Column("price")]
        public string Price { get; set; }

        /// <summary>
        /// 订单客人信息
        /// </summary>
        [ForeignKey("PassengerId")]
        public Passenger OrderForPassenger { get; set; }

    }
    }
