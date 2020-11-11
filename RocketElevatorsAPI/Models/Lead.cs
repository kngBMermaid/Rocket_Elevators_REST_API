using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RocketElevatorsAPI.Models
{
    [Table("leads")]
    public class Lead
    {

        // Fields

        [Key]
        private ulong id;
        private string email;
        private DateTime createdAt;

        // Properties
        public ulong ID 
        { 
            get { return id; }
            set { id = value; }
        }
        public string Email { get; set; }
        public DateTime CreatedAt { get; }
    }
}


