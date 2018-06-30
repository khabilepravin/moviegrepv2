using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace dataEntities
{
    public class Title : BaseModelEntity
    {   
        
        [DisplayName("Title Name")]
        [Required]
        public string TitleName { get; set; }

        public string Season { get; set; }

        public string Episode { get; set; }

        [Required]
        public string Year { get; set; }

        public string IndexStatus { get; set; }

        public string RowStatus { get; set; }

        public string SubtitleText { get; set; }

        public string Tags { get; set; }

        public string LanguageCode { get; set; }

        #region Custom (that means it is added just for client side purpose, doens't have any direct column mappgin)
        [DisplayName("Subtitles File")]
        [Required]
        public HttpPostedFileBase SubtitleFile { get; set; }
        [DisplayName("Admin Password")]
        [Required]
        public string AdminPass { get; set; }
        #endregion
    }
}
