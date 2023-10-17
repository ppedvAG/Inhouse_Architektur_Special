using System;

namespace HalloSingelton
{
    internal class Logger
    {
        private static Logger _instance = null;
        private static Object _obj = new Object();

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                    lock (_obj)
                    {
                        if (_instance == null)
                            _instance = new Logger();
                    }

                return _instance;
            }
        }

        private Logger()
        {
            Info("NEUER LOGGER");
        }

        public void Info(string msg)
        {
            Console.WriteLine($"[INFO] {DateTime.Now:g} {msg} ");
        }
    }
}
