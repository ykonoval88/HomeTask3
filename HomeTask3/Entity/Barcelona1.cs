using System;
using System.Globalization;

namespace HomeTask3.Entity
{
    public class Barcelona1 : IComparable<Barcelona1>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public string SmartLocation { get; set; }
        public string Country { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public Barcelona1(string[] fields)
        {
            if (fields.Length < 7)
            {
                throw new ArgumentException($"Incorrect CSV item: {String.Join(",", fields, 0, fields.Length)}");
            }

            if (int.TryParse(fields[0], out var id))
            {
                Id = id;
            }

            Name = fields[1];
            ZipCode = fields[2];
            SmartLocation = fields[3];
            Country = fields[4];
            if (double.TryParse(fields[5], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture,
                out var latitude))
            {
                Latitude = latitude;
            }

            if (double.TryParse(fields[6], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture,
                out var longitude))
            {
                Longitude = longitude;
            }
        }

        public static bool operator >(Barcelona1 a, Barcelona1 b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator <(Barcelona1 a, Barcelona1 b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator ==(Barcelona1 a, Barcelona1 b)
        {
            return a.CompareTo(b) == 0;
        }

        public static bool operator !=(Barcelona1 a, Barcelona1 b)
        {
            return a.CompareTo(b) != 0;
        }

        public int CompareTo(Barcelona1 obj)
        {
            // Make compare operation for ID, Latitude, Longitude
            if (this.Id == obj.Id)
            {
                if (this.Latitude.Equals(obj.Latitude))
                {
                    return this.Longitude.CompareTo(obj.Longitude);
                }
                else
                {
                    return this.Latitude.CompareTo(obj.Latitude);
                }
            }

            return this.Id.CompareTo(obj.Id);
        }
    }
}
