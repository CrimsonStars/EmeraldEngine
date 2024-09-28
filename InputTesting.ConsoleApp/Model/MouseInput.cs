namespace InputTesting.ConsoleApp.Model
{
    public sealed class MouseInput
    {
        #region Fields & properties
        private MouseInput? _instance;
        private static bool LMB { get; set; }
        private static bool RMB { get; set; }
        private static bool MMB { get; set; }
        private static object Coordinates { get; set; }
        #endregion Fields & properties

        public MouseInput GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MouseInput();
            }

            return _instance;
        }

        private MouseInput()
        {
            LMB = false;
            RMB = false;
            MMB = false; 
        }
    }
}