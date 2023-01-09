using System.ComponentModel.DataAnnotations;

namespace SpaMiniPsa_API.Entities;

public class Dog
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Breed { get; set; }
    [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
    public DateTime DateOfBirth { get; set; }
    public bool IsDewormedFirstTime { get; set; }
    public DateTime? DateOfFirstDeworming { get; set; }
    public byte[] ProfileImage { get; set; }
    public virtual List<Image>? Images { get; set; }

    public string DateOfSecondDeworming => DateOfBirth.AddDays(5 * 7).ToShortDateString(); // Second up to 5 weeks
    public string DateOfThirdDeworming => DateOfBirth.AddDays(7 * 7).ToShortDateString(); // third up to 7 weeks
    public string DateOfFirstVaccination => DateOfBirth.AddDays(8 * 7).ToShortDateString(); // First vaccination up to 8 weeks
}
