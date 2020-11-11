public class Column
{

    // Fields
    private ulong id;
    private string status;

    private ulong BatteryId;


    // Properties
    public ulong ID { get; set; }
    public string Status 
    {
        get { return status; }
        set 
        {
            if (status != "Active" && status != "Inactive" && status != "Intervention")
            {
                throw new System.Exception("Status given for column with ID " + this.id + " is invalid. Please change it.");
            }
        }
    }
    public ulong BatteryID { get; set; }
}