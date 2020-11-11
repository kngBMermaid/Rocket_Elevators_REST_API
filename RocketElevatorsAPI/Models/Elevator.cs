using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RocketElevatorsAPI.Models
{
    [Table("elevators")]
    public class Elevator
    {

        // Fields
        private ulong id;
        private string status;
        private ulong columnId;


        // Properties
        [Key]
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
                    throw new System.Exception("Status given for elevator with ID " + this.id + " is invalid. Please change it.");
                }
                status = value;
            }
        }

        [ForeignKey("column_id")]
        public ulong ColumnID 
        {
            get { return columnId; }
            set { columnId = value; } 
        }
    }
}