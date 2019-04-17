namespace HomeTask3.Entity
{
    public class Barcelona2:Barcelona1
    {
        public string ListingUrl { get; set; }

        public Barcelona2(string[] fields) : base(fields)
        {
            ListingUrl = fields[0];
            int _id;
            if(int.TryParse(ListingUrl.Replace("https://www.airbnb.com/rooms/", ""), out _id))
            {
                Id = _id;
            }
        }
    }
}
