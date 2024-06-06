using System.Runtime.Serialization;

namespace CORE.Exceptions
{
	public class FlaskApiCallDetectionException : Exception
	{
		public FlaskApiCallDetectionException(string? message) : base(message)
		{
		}
	}

	public class FailedToDeserializeResponseException : Exception
	{
        public FailedToDeserializeResponseException():base("Failed To Deserialize Response Exception Try Again Later")
        {
            
        }
       
	}

	
}

  
   
