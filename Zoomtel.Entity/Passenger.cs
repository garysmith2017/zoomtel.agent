using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zoomtel.Entity
{
    [Table("passenger", Schema = "manager")]
    public class Passenger
    {

        [JsonProperty("id")]
        [Column("id")]
        public int Id { get; set; }

        [JsonProperty("passenger_id")]
        [Column("passengerid")]
        public int PassengerId { get; set; }

        [JsonProperty("passengername")]
        public string PassengerName { get; set; }

        [InverseProperty("OrderForPassenger")]
        public List<OrderInfo> OrderInfos { get; set; }

        //[InverseProperty("Passengers")]
        //public Address PssengerForAddress { get; set; }
    }
}