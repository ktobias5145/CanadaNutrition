namespace CanadaNutrition
{

    internal partial class Program
    {
        public class NutrientAmount
        {
            public int FoodID { get; set; }
            public int NutrientID { get; set; } 
            public double NutrientValue { get; set; }
            public int StandardError { get; set; }
            public int NumberofObservations { get; set; }
            public int NutrientSourceID { get; set; }
            public string? NutrientDateOfEntry { get; set; }
            public NutrientAmount() { }
            public NutrientAmount(int foodID, int nutrientID, double nutrientValue, int standardError, int numberofObservations, int nutrientSourceID, string? nutrientDateOfEntry)
            {
                FoodID = foodID;
                NutrientID = nutrientID;
                NutrientValue = nutrientValue;
                StandardError = standardError;
                NumberofObservations = numberofObservations;
                NutrientSourceID = nutrientSourceID;
                NutrientDateOfEntry = nutrientDateOfEntry;
            }
        }
    }
}
