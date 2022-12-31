using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L00150620_Geil_Festival.Model
{
    public class Day1
    {
        public int id { get; set; }
        public string bandName { get; set; }
        public string stage { get; set; }
        public string time { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public bool saved { get; set; }
        public string bandPic { get; set; }

        //public Day1(int ID, string BandName, string Stage, string Time, 
        //    double Latitude, double Longitude, bool Saved, string BandPic)
        //{
        //    ID = id;
        //    BandName = bandName;
        //    Stage = stage;
        //    Time = time;
        //    Latitude = latitude;
        //    Longitude = longitude;
        //    Saved = saved;
        //    BandPic = bandPic;
        //}
    }
}
