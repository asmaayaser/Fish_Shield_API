using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Exceptions
{
	public abstract class NotFoundException:Exception
    {
        public NotFoundException(string msg):base(msg) { }
        
    }
    public class NotValidTypeException : NotFoundException
    {
        public NotValidTypeException() : base("no type found with this filtration criteria")
        {
        }
    }
    public class DiseaseNotFoundException : NotFoundException
    {
        public DiseaseNotFoundException(int Id) : base($"No Disease with this ID {Id} Founded in Our Database")
        {
        }
		public DiseaseNotFoundException(string name) : base($"this Disease:{name} not Found In Our DB Try Again Later or Contact Specialists")
		{
		}
	}
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(Guid id) : base($"no user with this id {id} in our database")
        {
        }
        public UserNotFoundException(string username):base($"no user with this id {username} in our database") 
        {
            
        }
    }
    public class NoFeedsFoundedInDB : NotFoundException
    {
        public NoFeedsFoundedInDB() : base("No FeedBacks in Data base Founded")
        {
        }
    }
    public class EquipmentNotFoundException : NotFoundException
    {
        public EquipmentNotFoundException() : base("No Equipments in Data base Founded")
        {
        }
    }
}

  
   
