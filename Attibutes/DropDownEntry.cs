namespace DlcFlags.OptionsFramework.Attibutes
{
    public struct DropDownEntry<TKey>
    {
        public TKey Code;
        public string Description;

        public DropDownEntry(TKey code, string description)
        {
            Code = code;
            Description = description;
        }
    }
}