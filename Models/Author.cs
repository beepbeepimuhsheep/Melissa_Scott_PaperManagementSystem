using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Melissa_Scott_9189_SA2_IPG521_Final.Models
{
    public class Author
    {
        [Key]
        [Display(Name = "Id")]
        public int PaperId { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string PaperTitle { get; set; }
        [Required]
        [Display(Name = "Abstract")]
        [DataType(DataType.MultilineText)]
        public string PaperAbstract { get; set; }
        [Display(Name = "Author")]
        public string PaperAuthor { get; set; } = HttpContext.Current.User.Identity.Name;

        [Display(Name = "Date Submitted")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime PaperDateSubmitted { get; set; }
        //public int TopicId { get; set; }


        //Foreign key
        [Display(Name = "Topic")]
        public int PaperTopicIdId { get; set; }

        [ForeignKey("PaperTopicIdId")]
        public virtual Topic Topics { get; set; }

    }

}