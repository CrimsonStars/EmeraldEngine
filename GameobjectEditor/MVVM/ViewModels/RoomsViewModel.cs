using EmeraldEngine.Models;
using System;
using System.Collections.Generic;

namespace GameobjectEditor.MVVM.ViewModels
{
   public class RoomsViewModel
   {
      public List<Room> _rooms;

      public void CreateSampleRooms()
      {
         _rooms = new List<Room>() {
            new Room() {
               ObjectId=GenerateRoomId(),
               Name="Wheat stone",
               Description="A sharpening stone",
            },
            new Room() {
               ObjectId=GenerateRoomId(),
               Name="Rusty knife",
               Description="Useless knife covered in rust. It's dull... yet.",
            },
            new Room() {
               ObjectId=GenerateRoomId(),
               Name="Wooden spoon",
               Description="An ordinary wooden spoon perfect for eating all sorts of dishes.",
            }
         };
      }

      private string GenerateRoomId() => $"ROOM.{Guid.NewGuid()}";
   }
}