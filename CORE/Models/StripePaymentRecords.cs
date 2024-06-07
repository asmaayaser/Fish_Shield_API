using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Models
{
	public class PaymentRecord
	{
		public int Id { get; set; }
		public string StripeSessionId { get; set; }
		public DateTime Created { get; set; }
		public string Status { get; set; }

		[ForeignKey("Owner")]
        public string OwnerId { get; set; }
        public FarmOwner Owner { get; set; }
    }
}
