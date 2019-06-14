using System;
using System.ComponentModel.DataAnnotations;

namespace FuelStationWebApi.Models
{
    public class TVShow
    {
        //ID операции
        [Display(Name = "Код операции")]
        public int TVShowID { get; set; }
        public int GenreID { get; set; }
        [Display(Name = "Название")]
        public string NameShow { get; set; }
        public string DescriptionShow { get; set; }
        public virtual Genre Genre { get; set; }

    }
}
