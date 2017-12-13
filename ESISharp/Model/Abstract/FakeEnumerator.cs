namespace ESISharp.Model.Abstract
{
    public abstract class FakeEnumerator
    {
        public dynamic Value { get; internal set; }

        protected FakeEnumerator(string value) => Value = value;
        protected FakeEnumerator(int value) => Value = value;
    }
}
