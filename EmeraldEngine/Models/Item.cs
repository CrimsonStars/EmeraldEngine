using EmeraldEngine.Universal;

namespace EmeraldEngine.Models
{
    public class Item : BaseInformation
    {
        public float Weight { get; set; }
        public float Value { get; set; }
        public bool Pickable { get; set; }
    }
}