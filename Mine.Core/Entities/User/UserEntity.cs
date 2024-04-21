using System.ComponentModel.DataAnnotations;

namespace Mine.Domain.Entities.User
{
    public class UserEntity
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public string Username { get; set; }

        public string Address { get; set; }

        [DisplayFormat(DataFormatString = "{0:F8}", ApplyFormatInEditMode = true)]
        public decimal Balance { get; set; }

        [DisplayFormat(DataFormatString = "{0:F8}", ApplyFormatInEditMode = true)]
        public decimal Earning { get; set; }


        public bool Active { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}
