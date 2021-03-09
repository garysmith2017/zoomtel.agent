using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zoomtel.Entity.Test
{
    [Table("test")]
  public  class T1Entity:SoftDeleteInfo, BaseEntity
    {
        [Key]
        public int id { get; set; }

        public DateTime? dt { get; set; }

    }
}
