namespace ClaimsHandling.Data.DataModels
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public bool Active { get; set; }
    }
}
