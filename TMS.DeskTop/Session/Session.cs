namespace TMS.DeskTop.Session
{
    public class Session
    {
        private static Session instance;
        public static Session Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Session();
                }
                return instance;
            }
        }

        private Session()
        {

        }

        public bool IsInitInfoComplete { get; set; } = false;

        public long Id { get; set; } = 0;
    }
}
