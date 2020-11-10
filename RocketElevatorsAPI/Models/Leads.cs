using System;

namespace Main.Models {
    public class LeadItems {
        public int id { get; set; }
        public DateTime created_at { get; set; }
        public int? customer_id { get; set; }
        public string contact_full_name { get; set; }
        public string company_name { get; set; }
        public string departement { get; set; }
        public string email { get; set; }
        public string project_name { get; set; }
    }
}