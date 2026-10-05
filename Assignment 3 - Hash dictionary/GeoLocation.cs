using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    public class GeoLocation : IEquatable<GeoLocation>
    {
        public double Latitude { get; }
        public double Longitude { get; }

        public GeoLocation(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as GeoLocation);
        }

        public bool Equals(GeoLocation other)
        {
            if (other == null) return false;
            return Latitude == other.Latitude && Longitude == other.Longitude;
        }
    }
}
