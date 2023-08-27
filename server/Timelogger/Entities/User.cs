using System.ComponentModel.DataAnnotations;
using Timelogger.Entities.DTO;

namespace Timelogger.Entities
{
    internal class User : BaseDocument<UserDTO>
    {
        [Key]
        public int UserId { get; set; }

        public string Name { get; set; }

        internal override UserDTO AsDTO()
        {
            return new UserDTO()
            {
                UserId = UserId,
                Name = Name
            };
        }
    }
}