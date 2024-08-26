using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmeraldEngine.Models
{
    /// <summary>
    /// Gameworld singleton.
    /// </summary>
    public class Gameworld
    {
        private Player _player;
        private Room _currentRoom;
        private List<Item> _gameItem;
        private static Gameworld _instance = null;

        private Gameworld() { }

        public static Gameworld Instance()
        {
            if(_instance==null)
            {
                _instance = new Gameworld();
            }

            return _instance;
        }
    }
}
