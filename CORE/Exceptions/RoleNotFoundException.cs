using CORE.Exceptions;
using System.Runtime.Serialization;

namespace Services
{
   
    public class RoleNotFoundException : NotFoundException
    {
       

        public RoleNotFoundException(string Role) : base($"Role {Role} not  Available in this Current time")
        {
        }

       
    }
}