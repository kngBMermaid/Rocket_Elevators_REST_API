public class Elevator
{

    // Fields
    private ulong id;
    private string status;
    private ulong columnId;


    // Properties
    public ulong ID { get; set; }
    public string Status 
    {
        get { return status; }
        set 
        {
            if (status != "Active" && status != "Inactive" && status != "Intervention")
            {
                throw new System.Exception("Status given for elevator with ID " + this.id + " is invalid. Please change it.");
            }
        }
    }
    public ulong ColumnID {get; set; }
}