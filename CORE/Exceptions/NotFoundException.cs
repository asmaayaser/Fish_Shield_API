using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Exceptions
{
    public abstract class NotFoundException:Exception
    {
        public NotFoundException(string msg):base(msg) { }
        
    }

    public class DiseaseNotFoundException : NotFoundException
    {
        public DiseaseNotFoundException(int Id) : base($"No Disease with this ID {Id} Founded in Our Database")
        {
        }
    }
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(Guid id) : base($"no user with this id {id} in our database")
        {
        }
    }
    public class NoFeedsFoundedInDB : NotFoundException
    {
        public NoFeedsFoundedInDB() : base("No FeedBacks in Data base Founded")
        {
        }
    }
}

  
   
