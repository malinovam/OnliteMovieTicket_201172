using Microsoft.VisualBasic;

namespace OnlineTiketi.Domain.DomainModels.ViewModels
{
    public class BookNowViewModel
    {
        public string Movie_Name { get; set; }
        public DateAndTime Movie_Date { get; set; }
        public string SeatNo { get; set; }
        public int Amount { get; set; }
        public int MovieId { get; set; }

    }
}
