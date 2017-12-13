namespace ESISharp.Enumeration
{
    public class Language : Model.Abstract.FakeEnumerator
    {
        internal Language(string value) : base(value) { }

        public static readonly Language English = new Language("en-us");
        public static readonly Language German = new Language("de");
        public static readonly Language French = new Language("fr");
        public static readonly Language Russian = new Language("ru");
        public static readonly Language Japanese = new Language("ja");
        public static readonly Language Chinese = new Language("zh");
    }
}
