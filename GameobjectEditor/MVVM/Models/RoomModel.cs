namespace GameobjectEditor.MVVM.Models
{
   using System.ComponentModel;

   public class RoomModel : INotifyPropertyChanged
   {
      #region Properties
      // Called ObjectId in class
      public string Id
      {
         get
         {
            return Id;
         }
         set
         {
            if (Id != value)
            {
               Id = value;
               OnPropertyChange(nameof(Id));
            }
         }
      }

      public string Name
      {
         get
         {
            return Name;
         }
         set
         {
            if (Name != value)
            {
               Name = value;
               OnPropertyChange(nameof(Name));
            }
         }
      }
      #endregion

      public event PropertyChangedEventHandler? PropertyChanged;

      private void OnPropertyChange(string name)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
      }
   }
}
