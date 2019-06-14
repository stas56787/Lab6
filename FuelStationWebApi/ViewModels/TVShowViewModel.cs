using System;

namespace FuelStationWebApi.ViewModels
{
    public class TVShowViewModel
    {
        //ID операции
        public int GenreID { get; set; }
        public int TVShowID { get; set; }
        public string NameShow { get; set; }
        public string DescriptionShow { get; set; }
        public string NameGenre { get; set; }

    }
}
