namespace RocketElevatorsAPI.Models 
{
    public class Battery
    {

        // Fields
        private ulong id;
        private string status;
        private ulong buildingId;


        // Properties
        public ulong ID { get; set; }
        public string Status 
        {
            get { return status; }
            set 
            {
                if (status != "Active" && status != "Inactive" && status != "Intervention")
                {
                    throw new System.Exception("Status given for battery with ID " + this.id + " is invalid. Please change it.");
                }
            }
        }

        public ulong BuildingID { get; set; }
    }
}