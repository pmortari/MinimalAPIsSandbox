using System;

namespace RegularAPINET5.Models
{
    public record Person
    {
        public Guid Id {  get; set; }
        public string Name {  get; set; }
        public int Age { get; set; }
    }
}
