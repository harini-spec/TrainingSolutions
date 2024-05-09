namespace RequestTrackerBLLibrary
{
    public class DepartmentDoesNotExistException : Exception
    {
        string msg;
        public DepartmentDoesNotExistException()
        {
            msg = "Department ID not found";
        }
        public override string Message => msg;
    }
}