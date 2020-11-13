using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RocketElevatorsAPI.Models
{
    [Table("columns")]
    public class Column
    {

        // Fields
        private ulong id;
        private string status;
        private ulong batteryId;


        // Properties

        [Key]
        public ulong Id { get; set; }
        
        public string Status 
        {
            get { return status; }
            set 
            {
                if (value.ToLower() != "active" && value.ToLower() != "inactive" && value.ToLower() != "intervention")
                {
                    throw new System.Exception("Status given for column with ID " + this.id + " is invalid. Please change it.");
                }
                status = value;
            }
        }

        [ForeignKey("battery_id")]
        public ulong Battery_Id
        { 
            get { return batteryId; } 
            set { batteryId = value; } 
        }
    }
}