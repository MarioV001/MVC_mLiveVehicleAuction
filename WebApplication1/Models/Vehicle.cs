using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace mVehAuction.Models
{
    public class Vehicle
    {
        [ForeignKey("Id")]
        public int Id { get; set; }
        public int CreatorId { get; set; }//so we know who created the listing
        public string Make { get; set; } = "NA";
        public string Model { get; set; } = "NA";
        public int Year { get; set; } = 0;
        public int Odometer { get; set; }
        public string ImageURL { get; set; } = "NA";
        public string Category { get; set; } = "NA";
        public string DamageType { get; set; } = "NA";
        public DateTime TimeCreated { get; set; }
        public DateTime AuctionStartDate { get; set; }
        public int LotLocation { get; set; } = 0;
        public decimal CurrentBid { get; set; }
        public decimal BuyNow { get; set; }//Buy Now Price
        public string Location { get; set; } = "NA";//Location of veh
        public string VIN { get; set; } = "NA";
        public string BodyStyle {get;set;} = "NA";
        public int EngineCC { get; set;}
        public int TransGears { get; set;}
        public string Transmision { get; set; } = "NA";
        public string AdditionalDescription { get; set; } = "NA";
        public int LastBidderID { get; set; } = -1;//save the last bidder ID
        public string Drive { get; set; } = "NA";
        public string Keys { get; set; } = "NA";//Amount # of keys
        public string VehDocuments { get; set; } = "NA";//if veh comes with V5
        public string FuelType { get; set; } = "NA";
        public decimal RetailValue { get; set; } = 0;// so we know how much its worth
        public int Views { get; set; } = 0;//the page views for this listing

        public string GetImageLocationPath(string UniqueKey,bool HD=false)
        {
            if(HD) return "/VehIMGUpload/" + UniqueKey + "/HD/0." + FileUpload.GetImageExtension(UniqueKey, true);
            else return "/VehIMGUpload/" + UniqueKey + "/0." + FileUpload.GetImageExtension(UniqueKey,true);
        }

        public List<int> GetAllYears()
        {
            List<int> yYear = new List<int>();
            for (int i = 1985; i <= DateTime.Now.Year; i++)
            {
                yYear.Add(i);
            }
            return yYear;
        }

        
        public IEnumerable<string> GetVehBrands()//Vehicle Brands
        {
            foreach (VehBrand value in System.Enum.GetValues(typeof(VehBrand)))
            {
                yield return value.GetDescription();
            }
        }
        public IEnumerable<string> GetVehCategory()//Vehicle Damage Reporte  catefori
        {
            foreach (VehicleCategory value in System.Enum.GetValues(typeof(VehicleCategory)))
            {
                yield return value.GetDescription();
            }
        }
        public IEnumerable<string> GetDamageType()//vehicle damage location
        {
            foreach (DamageType value in System.Enum.GetValues(typeof(DamageType)))
            {
                yield return value.GetDescription();
            }
        }
        public IEnumerable<string> GetBodyType()//body style of vehicle
        {
            foreach (BodyType value in System.Enum.GetValues(typeof(BodyType)))
            {
                yield return value.GetDescription();
            }
        }
        public IEnumerable<string> GetTransType()//transmision type in vehicle
        {
            foreach (TransmisionType value in System.Enum.GetValues(typeof(TransmisionType)))
            {
                yield return value.GetDescription();
            }
        }
        public IEnumerable<string> GetDriveType()// Axle drive on vehicle
        {
            foreach (DriveType value in Enum.GetValues(typeof(DriveType)))
            {
                yield return value.GetDescription();
            }
        }
        public IEnumerable<string> GetFuelType()//get fuel type on veh
        {
            foreach (FuelType value in Enum.GetValues(typeof(FuelType)))
            {
                yield return value.GetDescription();
            }
        }
        public IEnumerable<string> GetYesNo()//get fuel type on veh
        {
            foreach (YesNoType value in Enum.GetValues(typeof(YesNoType)))
            {
                yield return value.GetDescription();
            }
        }


    }
    public enum YesNoType
    {
        [Description("Yes")]
        Yes,
        [Description("No")]
        No,
    }
    public enum DriveType
    {
        [Description("Front Drive")]
        FrontDrive,
        [Description("Rear Drive")]
        RearDrive,
        [Description("All Wheel Drive")]
        AllWheelDrive
    }
    public enum BodyType
    {
        [Description("Coupe")]
        Coupe,
        [Description("Estate")]
        Estate,
        [Description("Convertible")]
        Convertible
    }
    public enum FuelType
    {
        [Description("Petrol")]
        Petrol,
        [Description("Petrol + LGP")]
        Petrol_LPG,
        [Description("Diesel")]
        Diesel
    }
    public enum TransmisionType
    {
        [Description("Automatic")]
        Auto,
        [Description("Manual")]
        Manual
    }

    public enum DamageType
    {
        [Description("MINOR DENTS/SCRATCHES")]
        MINOR_DENTS,
        [Description("NORMAL WEAR")]
        NORMAL_WEAR,
        [Description("ALL OVER")]
        ALL_OVER,
        [Description("BURN")]
        BURN,
        [Description("BURN - ENGINE")]
        BURN_ENGINE,
        [Description("BURN - INTERIOR")]
        BURN_INTERIOR,
        [Description("FRAME DAMAGE REPORTED")]
        FRAME_DAMAGE,
        [Description("FRONT END")]
        FRONT_END,
        [Description("MECHANICAL")]
        MECHANICAL,
        [Description("MISSING/ALTERED VIN")]
        ALTERED_VIN,
        [Description("PARTIAL/INCOMPLETE REPAIR")]
        INCOMPLETE_REPAIR,
        [Description("PARTS")]
        PARTS,
        [Description("REAR END")]
        REAR_END,
        [Description("ROLLOVER")]
        ROLLOVER,
        [Description("SIDE")]
        SIDE,
        [Description("TOP/ROOF")]
        ROOF,
        [Description("UNDERCARRIAGE")]
        UNDERCARRIAGE,
        [Description("UNKNOWN")]
        UNKNOWN,
        [Description("VANDALISM")]
        VANDALISM,
        [Description("WATER/FLOOD")]
        WATER
    }
    public enum VehBrand
    {
        [Description("Alfa Romeo")]
        Alpha,
        [Description("Aston Martin")]
        Aston,
        [Description("Audi")]
        Audi,
        [Description("Bentley")]
        Bentley,
        [Description("Chevrolet")]
        Chevrolet,
        [Description("Cadillac")]
        Cadillac,
        [Description("Chrysler")]
        Chrysler,
        [Description("Citroën")]
        Citroen,
        [Description("Dacia")]
        Dacia,
        [Description("Daihatsu")]
        Daihatsu,
        [Description("Dodge")]
        Dodge,
        [Description("Daewoo")]
        Daewoo,
        [Description("Fiat")]
        Fiat,
        [Description("Ferrari")]
        Ferrari,
        [Description("Ford")]
        Ford,
        [Description("Great Wall")]
        GreatWall,
        [Description("Honda")]
        Honda,
        [Description("Hyundai")]
        Hyundai,
        [Description("Isuzu")]
        Isuzu,
        [Description("Infiniti")]
        Infiniti,
        [Description("Jeep")]
        Jeep,
        [Description("Jaguar")]
        Jaguar,
        [Description("Lamborghini")]
        Lamborghini,
        [Description("Land Rover")]
        LandRover,
        [Description("Lexus")]
        Lexus,
        [Description("Lotus")]
        Lotus,
        [Description("Maserati")]
        Maserati,
        [Description("Mazda")]
        Mazda,
        [Description("McLaren")]
        McLaren,
        [Description("Mini")]
        Mini,
        [Description("Mitsubishi")]
        Mitsubishi,
        [Description("Nissan")]
        Nissan,
        [Description("Opel")]
        Opel,
        [Description("Peugeot")]
        Peugeot,
        [Description("Porsche")]
        Porsche,
        [Description("Renault")]
        Renault,
        [Description("Seat")]
        Seat,
        [Description("Skoda")]
        Skoda,
        [Description("Subaru")]
        Subaru,
        [Description("Suzuki")]
        Suzuki,
        [Description("Tesla")]
        Tesla,
        [Description("Toyota")]
        Toyota,
        [Description("Volkswagen")]
        Volkswagen,
        [Description("Volvo")]
        Volvo,
        [Description("BMW")]
        BMW,
        [Description("Mercedes")]
        Mercedes,
    }
    public enum VehicleCategory
    {
        [Description("CAT C - Salvage")]
        CAT_C,
        [Description("CAT B - Breaker")]
        CAT_B,
        [Description("CAT D - Salvage")]
        CAT_D,
        [Description("CAT X - Stolen Recoverd")]
        CAT_X,
        [Description("CAT U - Unrecorder")]
        CAT_U,
        [Description("CAT N - Repairable Non Structural")]
        CAT_N,
        [Description("CAT S - Repairable Structural")]
        CAT_S
    }

}
