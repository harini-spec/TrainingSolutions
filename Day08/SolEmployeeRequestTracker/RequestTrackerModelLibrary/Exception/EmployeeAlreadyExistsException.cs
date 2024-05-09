namespace RequestTrackerBLLibrary
{
    public class EmployeeAlreadyExistsException : Exception
    {
        string msg;
        public EmployeeAlreadyExistsException()
        {
            msg = "Provided Employee Data is already present";
        }
        public override string Message => msg;
    }
}