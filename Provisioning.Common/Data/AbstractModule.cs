namespace Provisioning.Common.Data
{
    public abstract class AbstractModule
    {
        protected AbstractModule()
        {

        }
        public string ConnectionString
        {
            get;
            set;
        }

        public string Container
        {
            get;
            set;
        }
    }
}
