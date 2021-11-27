namespace Screenmate.MVVM
{
    /// <summary>
    /// Singleton class base.
    /// </summary>
    /// <typeparam name="TInterface">Interface type of instance</typeparam>
    /// <typeparam name="TClass">Class type of instance</typeparam>
    public class Singleton<TInterface, TClass> where TClass : TInterface, new()
    {
        /// <summary>
        /// The instance
        /// </summary>
        private static TInterface _instance;

        /// <summary>
        /// Gets or sets the instance.
        /// </summary>
        /// <value>
        /// The instance
        /// </value>
        public static TInterface Instance
        {
            get {
                if(_instance == null)
                {
                    _instance = new TClass();
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }
    }
}
