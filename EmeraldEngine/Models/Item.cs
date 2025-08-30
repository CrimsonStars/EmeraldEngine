using EmeraldEngine.Universal;

namespace EmeraldEngine.Models
{
    public class Item : BasicInformation
    {
        public float Weight { get; set; }
        public float Value { get; set; }
        public bool Pickable { get; set; }
    }
}