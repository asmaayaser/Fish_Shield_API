namespace CORE.Exceptions
{
    public abstract class BadRequestException : Exception
    {
        public BadRequestException(string msg):base (msg) { }
        
    }
}
