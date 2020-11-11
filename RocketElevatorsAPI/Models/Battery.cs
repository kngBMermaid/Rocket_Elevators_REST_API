using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RocketElevatorsAPI.Models 
{

    [Table("batteries")]
    public class Battery
    {

        // Fields

        [Key]
        private ulong id;
        private string status;

        [ForeignKey("building_id")]
        private ulong buildingId;


        // Properties
        public ulong ID 
        { 
            get { return id; }
            set { id = value; }    
        }

        public string Status 
        {
            get { return status; }
            set 
            {
                if (value.ToLower() != "active" && value.ToLower() != "inactive" && value.ToLower() != "intervention")
                {
                    throw new System.Exception("Status given for battery with ID " + this.id + " is invalid. Please change it.");
                }
                status = value;
            }
        }

        public ulong BuildingID
        { 
            get { return buildingId; } 
            set { buildingId = value; } 
        }
    }
}