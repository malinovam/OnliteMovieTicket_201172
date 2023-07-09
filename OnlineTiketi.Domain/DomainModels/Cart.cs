namespace OnlineTiketi.Domain.DomainModels
{
    public class Cart
    {
        public int Id { get; set; }
        public string seatno { get; set; }
        public string UserId { get; set; }
        public DateAndTime date { get; set; }
        public int Amount { get; set; }
        public int MovieId { get; set; }

    }
}
