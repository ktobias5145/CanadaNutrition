namespace CanadaNutrition
{
    public class FoodName
    {
        public int FoodID { get; set; }
        public int FoodCode { get; set; }
        public int FoodGroupID { get; set; }
        public int FoodSourceID { get; set; }
        public string? FoodDescription { get; set; }
        public string? FoodDescriptionF { get; set; }
        public string? FoodDateOfEntry { get; set; }
        public string? FoodDateOfPublication { get; set; }
        public string? CountryCode { get; set; }
        public string? ScientificName { get; set; }
        public FoodName() { }
        public FoodName(int id, int code, int groupId, int sourceId, string desc, string descF, string date, string pub ,string Countrycode, string sciName)
        {
            FoodID = id;
            FoodCode = code;
            FoodGroupID = groupId;
            FoodSourceID = sourceId;
            FoodDescription = desc;
            FoodDescriptionF = descF;
            FoodDateOfEntry = date;
            FoodDateOfPublication = pub;
            CountryCode = Countrycode;
            ScientificName = sciName;
        }
    }
}
