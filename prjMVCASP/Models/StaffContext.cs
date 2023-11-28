namespace prjMVCASP.Models
{
    public class StaffContext
    {

        public static List<Staff> staffObject = new List<Staff>();

        public StaffContext()
        {
            if (staffObject.Count == 0)
            {
                staffObject.Add(new Staff(1, "Josh", "Baby staff member", "1234", "2009"));
                staffObject.Add(new Staff(2, "Jessica", "staff member", "4321", "2000"));
                staffObject.Add(new Staff(3, "Bob", "Mini staff member", "09876543", "1999"));
            }
        }
    }
}
