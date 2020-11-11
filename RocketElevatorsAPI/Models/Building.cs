using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RocketElevatorsAPI.Models
{
    [Table("buildings")]
    public class Building
    {

        // Fields

        [Key]
        private ulong id;

        // Properties
        public ulong ID 
        { 
            get { return id; }
            set { id = value; }
        }

    }
}