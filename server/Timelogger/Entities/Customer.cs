using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Timelogger.Entities.DTO;

namespace Timelogger.Entities
{
    /// <summary>
    /// Main table storing all possible customers
    /// </summary>
    internal class Customer : BaseDocument<CustomerDTO>
    {
        [Key]
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerInfo { get; set; }

        #region references by FK
        internal List<Project> Projects { get; set; }

        internal override CustomerDTO AsDTO()
        {
            return new CustomerDTO()
            {
                CustomerId = Id,
                CustomerName = CustomerName,
                CustomerInfo = CustomerInfo,
            };
        }

        #endregion
    }
}
