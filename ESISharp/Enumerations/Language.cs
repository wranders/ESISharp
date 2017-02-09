namespace ESISharp.Enumerations
{
    /// <summary>Data Language</summary>
    public class Language
    {
        /// <summary>English Language</summary>
        public static readonly Language English = new Language("en-us");
        /// <summary>German Language</summary>
        public static readonly Language German = new Language("de");
        /// <summary>French Language</summary>
        public static readonly Language French = new Language("fr");
        /// <summary>Russian Language</summary>
        public static readonly Language Russian = new Language("ru");
        /// <summary>Japanese Language</summary>
        public static readonly Language Japanese = new Language("ja");
        /// <summary>Chinese Language</summary>
        public static readonly Language Chinese = new Language("zh");

        internal Language(string val)
        {
            Value = val;
        }

        /// <summary>Language</summary>
        public string Value { get; }
    }
}