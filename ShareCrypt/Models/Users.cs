namespace ShareCrypt.Models
{
    public class Users
    {
         public int ID { get; set; }
         public string Username { get; set; }
         public string Password { get; set; }
         public string Email { get; set; }
         public string Fullname { get; set; }

/*        public ICollection<FF>? FFs { get; set; }
        public ICollection<Shared>? Shareds { get; set; }
        public ICollection<OwnedFF>? OwnedFFs { get; set; }*/

    }
}
