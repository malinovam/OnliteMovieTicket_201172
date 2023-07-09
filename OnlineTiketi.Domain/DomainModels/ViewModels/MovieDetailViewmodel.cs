using System;
namespace OnlineTiketi.Domain.DomainModels.ViewModels
{
    public class MovieDetailViewmodel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateofMovie { get; set; }
        public string MoviePicture { get; set; }
    }
}
