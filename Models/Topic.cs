using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Melissa_Scott_9189_SA2_IPG521_Final.Models
{
    public class Topic
    {
        [Key]
        [Display(Name = "Topic")]
        public int PaperTopicIdId { get; set; }
        [Required]
        [Display(Name = "Topic")]
        public string TopicName { get; set; }

      

    }
}