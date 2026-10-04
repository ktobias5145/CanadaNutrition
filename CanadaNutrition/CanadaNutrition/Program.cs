using Microsoft.VisualBasic.FileIO;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace CanadaNutrition
{

    internal partial class Program
    {
        static private NutrientName NewNutrientName(string[] values)
        {
            int NutrientID = 0;
            int NutrientCode = 0;
            int NutrientDecimals = 0;
            int outId;
            if (Int32.TryParse(values[0], out outId))
                NutrientID = outId;
            if (Int32.TryParse(values[1], out outId))
                NutrientCode = outId;
            if (Int32.TryParse(values[7], out outId))
                NutrientDecimals = outId;
            return new(
                NutrientID,
                NutrientCode,
                values[2],
                values[3],
                values[4],
                values[5],
                values[6],
                NutrientDecimals
                );
        }
        static private NutrientAmount NewNutrientAmount(string[] values)
        {
            int foodId = 0;
            int nutrientId = 0;
            double nutrientValue = 0.0;
            int standardError = 0;
            int numObservations = 0;
            int nutrientSourceId = 0;
            int idOut;
            double idDoubleOut;
            NutrientAmount nutrientAmount;
            if (Int32.TryParse(values[0], out idOut))
            { foodId = idOut; }
            if (Int32.TryParse(values[1], out idOut))
            { nutrientId = idOut; }
            if (Double.TryParse(values[2], out idDoubleOut))
            { nutrientValue = idDoubleOut; }
            if (Int32.TryParse(values[3], out idOut))
            { standardError = idOut; }
            if (Int32.TryParse(values[4], out idOut))
            { numObservations = idOut; }
            if (Int32.TryParse(values[5], out idOut))
            { nutrientSourceId = idOut; }

            return new(
                foodId,
                nutrientId,
                nutrientValue,
                standardError,
                numObservations,
                nutrientSourceId,
                values[6]
                );
            
        }
        static private FoodName NewFood(string[] values)
        {
            int id = 0;
            int code = 0;
            int groupId = 0;
            int sourceId = 0;
            string Countrycode = values[8];
            int idOut, codeOut, groupIdOut, sourceIdOut;
            string descl = values[4];
            string descF = values[5];
            string date = values[6];
            string pub = values[7];
            string sciName = values[9];
            FoodName food;
            if (Int32.TryParse(values[0], out idOut))
            { id = idOut; }
            else
                Console.WriteLine("Error Creating Object: FoodID is not an Integer32.\n\tValue was: [" + values[0]+"]");
            if (Int32.TryParse(values[1], out codeOut))
            { code = codeOut; }
            else
                Console.WriteLine("Error Creating Object: FoodCode is not an Integer32.\n\tValue was: [" + values[1] + "]");
            if (Int32.TryParse(values[2], out groupIdOut))
            { groupId = groupIdOut; }
            else
                Console.WriteLine("Error Creating Object: FoodGroupID is not an Integer32.\n\tValue was: [" + values[2] + "]");
            if (Int32.TryParse(values[3], out sourceIdOut))
            { sourceId = sourceIdOut; }
            else
                Console.WriteLine("Error Creating Object: FoodSourceID is not an Integer32.\n\tValue was: [" + values[3] + "]");
                
            return new(
                    id,
                    code,
                    groupId,
                    sourceId,
                    descl,
                    descF,
                    date,
                    pub,
                    Countrycode,
                    sciName
                    );
        }

        static int ChooseFood(string fileName)
        {
            List<FoodName> foods = new();
            string searchValue;
            string[] splitValues;
            string[]? values;
            bool flag = false;
            int id =0;

            Console.Write("Enter A Food Choice: ");
            searchValue = Console.ReadLine()??"";
            Console.Clear();
            splitValues = searchValue.Split(" ");
            TextFieldParser parser = new TextFieldParser(fileName);
            parser.HasFieldsEnclosedInQuotes = true;
            parser.SetDelimiters(",");
            try
            {
                while (!parser.EndOfData)
                {
                    flag = false;
                    values = parser.ReadFields();
                    // if (values[4].Contains(searchValue))
                    foreach (string line in splitValues)
                    {
                        if (values![4].ToLower().Contains(line.ToLower()))
                        {
                            flag = true;
                        }
                        else flag = false;
                    }
                    if (flag)
                        foods.Add(NewFood(values!));
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); }
            parser.Close();

            Console.Clear();
            foreach (FoodName food in foods) { Console.WriteLine($"{food.FoodID}: {food.FoodDescription}"); }
            Console.WriteLine("=============================================================================================");
            flag = false;
            while(flag == false)
            {
                Console.Write("Select an id value to learn more about it: ");
                searchValue = Console.ReadLine() ?? "";
                if (Int32.TryParse(searchValue, out id)) 
                {
                    foreach(FoodName foodid in foods)
                    {
                        if (id == foodid.FoodID)
                        {
                            flag = true;
                            break;
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    foreach (FoodName food in foods)
                    {
                        Console.WriteLine($"{food.FoodID}: {food.FoodDescription}");
                    }
                    Console.WriteLine("=============================================================================================");
                }
            }
            return id;
        }
        static void ShowNutrients(int FoodID, string NutrientAmountFile, string NutrientNameFile)
        {
            List<NutrientAmount> nutrientAmounts = new List<NutrientAmount>();
            List<NutrientName> nutrientNames = new List<NutrientName>();
            string[]? values;
            TextFieldParser parser = new TextFieldParser(NutrientAmountFile);
            parser.HasFieldsEnclosedInQuotes = true;
            parser.SetDelimiters(",");
            try
            {
                parser.ReadLine();  //Skip first line/header line
                while (!parser.EndOfData)
                {     
                    values = parser.ReadFields();
                    if (Int32.Parse(values![0]) == FoodID)
                    {
                        nutrientAmounts.Add(NewNutrientAmount(values));
                    }
                    if (Int32.Parse(values![0]) > FoodID)
                        break;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); }
            parser.Close();

            parser = new TextFieldParser(NutrientNameFile);
            parser.HasFieldsEnclosedInQuotes = true;
            parser.SetDelimiters(",");
            try
            {
                parser.ReadLine();//Skip first line/header line
                while (!parser.EndOfData)
                {
                    values = parser.ReadFields();
                    foreach(var item in nutrientAmounts)
                    {
                        if (item.NutrientID == Int32.Parse(values![0]))
                            nutrientNames.Add(NewNutrientName(values));
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); }
            parser.Close();
            DisplayNutrition(nutrientAmounts, nutrientNames);
        }
        static void DisplayNutrition(List<NutrientAmount> nutrientAmounts, List<NutrientName> nutrientNames)
        {
            foreach(var item in nutrientAmounts) 
            {
                foreach(var item2 in nutrientNames)
                {
                    if(item.NutrientID == item2.NutrientID)
                    {
                        if (item2.NutrientNameE == "ENERGY (KILOCALORIES)")
                        {
                            Console.WriteLine($"{item2.NutrientNameE} : {item.NutrientValue}{item2.NutrientUnit}");
                        }
                        if (item2.NutrientNameE == "CARBOHYDRATE, TOTAL (BY DIFFERENCE)")
                        {
                            Console.WriteLine($"{item2.NutrientNameE} : {item.NutrientValue}{item2.NutrientUnit}");
                        }
                        if (item2.NutrientNameE == "FAT (TOTAL LIPIDS)")
                        {
                            Console.WriteLine($"{item2.NutrientNameE} : {item.NutrientValue}{item2.NutrientUnit}");
                        }
                        if (item2.NutrientNameE == "PROTEIN")
                        {
                            Console.WriteLine($"{item2.NutrientNameE} : {item.NutrientValue}{item2.NutrientUnit}");
                        }
                    }
                    //Console.WriteLine($"{item2.NutrientNameE} : {item.NutrientValue}{item2.NutrientUnit}");
                }
            }
        }
        static void Main(string[] args)
        {
            string FoodNameFile = "../../../Data/FOOD NAME.csv";
            string NutrientAmountFile = "../../../Data/NUTRIENT AMOUNT.csv";
            string NutrientNameFile = "../../../Data/NUTRIENT NAME.csv";
            int FoodId;

            Console.WriteLine("=============================================================================================");
            Console.WriteLine("Canadian Government Food Database");
            Console.WriteLine("=============================================================================================");
            //Get FoodId to show nutrients
            FoodId = ChooseFood(FoodNameFile);
            Console.Clear();
            ShowNutrients(FoodId, NutrientAmountFile, NutrientNameFile);
        }
    }
}
