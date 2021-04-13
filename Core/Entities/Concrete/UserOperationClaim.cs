using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;


namespace Core.Entities.Concrete
{
    public class UserOperationClaim:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OPerationClaimId { get; set; }
    }
}
