namespace RequestTrackerBLLibrary
{
    public class DepartmentNameDoesNotExistException : Exception
    {
        string msg;
        public DepartmentNameDoesNotExistException() 
        {
            msg = "Provided Department Name does not exist!";
        }

        public override string Message => msg;
    }
}