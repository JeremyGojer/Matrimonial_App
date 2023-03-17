namespace Happy_Marriage.Exceptions
{
    [Serializable]
    public class SessionExpiredException : Exception
    {
        public SessionExpiredException() : base("Your session has expired, please login again")
        { 
            
        }

        public SessionExpiredException(string message):base("Your session has expired, please login again "+message)
        {

        }
        
    }
}
