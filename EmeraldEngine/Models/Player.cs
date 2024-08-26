using EmeraldEngine.Universal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmeraldEngine.Models
{
    /// <summary>
    /// <b>NOTES:</b>
    /// Need to change in the future some element types/collections.
    /// For now it's just a placeholder for things to come.
    /// </summary>
    public class Player: BaseInformation
    {

        public List<Item> Inventory { get; set; }

    }
}
