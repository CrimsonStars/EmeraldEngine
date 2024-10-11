using Terminal.Gui;

namespace LamaGameworld.Editor
{
    public partial class MyView : Terminal.Gui.Window
    {
        #region Terminal GUI elements
        private Terminal.Gui.TextField _inputName;
        private Terminal.Gui.Label _sampleLabel;
        #endregion

        public void ConstructWindow()
        {
            _sampleLabel = new Terminal.Gui.Label();
            _sampleLabel.Data = "label_0";
            _sampleLabel.Text = "Name";
            _sampleLabel.TextAlignment = Terminal.Gui.TextAlignment.Left;
            //_sampleLabel.X = Terminal.Gui.Pos.Center();
            //_sampleLabel.Y = Terminal.Gui.Pos.Center();

            _inputName = new Terminal.Gui.TextField();

            Add(_sampleLabel, _inputName);
        }

        public void Elson()
        {
            var x = new Button();
            x.Text = "Imma button!";
            x.X = Pos.Center();
            x.Y = Pos.Center();
            x.Clicked += () =>
            {
                MessageBox.Query("Hello", "Hello There!", "Ok");
                _currentView = "ooo";
            };

            // no i nie wiem co teraz zrobic
            // co za dno...

            Add(x);
        }

    }
}
