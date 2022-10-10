namespace Blorc.Components
{
    public abstract class UniqueComponentBase : BlorcComponentBase
    {

        public UniqueComponentBase()
        {
            InstanceId = GenerateUniqueId(ComponentName?.ToLower() ?? string.Empty);
        }

        public string InstanceId { get; private set; }

        public abstract string ComponentName { get; }
    }
}
