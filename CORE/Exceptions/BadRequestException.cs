namespace CORE.Exceptions
{
    public abstract class BadRequestException : Exception
    {
        public BadRequestException(string msg):base (msg) { }
        
    }
    public class InvalidDateRangeBadRequest : BadRequestException
    {
        public InvalidDateRangeBadRequest() : base("Please Enter a valid DateTime Range")
        {
        }
    }
    public class InvalidCodeException : BadRequestException
    {
        public InvalidCodeException(string code) : base($"this Code {code} is InValid code, Please Enter A valid code or Contact Admins For More Info")
        {
        }
    }
    public class SubscriptionEndedException : BadRequestException
    {
        public SubscriptionEndedException() : base("Subscription Ended Try To Recharge your Subscription Plan to Able to do more Detection")
        {
        }
    }

}
