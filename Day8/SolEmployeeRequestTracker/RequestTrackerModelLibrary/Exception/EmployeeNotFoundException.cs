namespace RequestTrackerBLLibrary
{
    public class EmployeeNotFoundException : Exception
    {
        string msg;
        public EmployeeNotFoundException()
        {
            msg = "No Employee found";
        }
        public override string Message => msg;
    }
}