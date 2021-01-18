using System;
using MongoDB.Driver.GeoJsonObjectModel;

namespace API_MONGO.Data.Collections
{

    public class Infected
    {
        public Infected(DateTime birthDate, String sex, double latitude, double longitude)
        {
            this.BirthDate = birthDate;
            this.Sex = sex;
            this.Localization = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }

        public DateTime BirthDate {get; set;}
        
        public string Sex{get; set;}

        public GeoJson2DGeographicCoordinates Localization {get; set;}
    }
}
