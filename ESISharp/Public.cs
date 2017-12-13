using ESISharp.Enumeration;
using ESISharp.Paths.Public;

namespace ESISharp
{
    public class Public : Model.Abstract.EsiConnection
    {
        internal new Access Access = Access.Public;

        private readonly Alliance _Alliance;

        public Alliance Alliance => _Alliance;

        public Public() : base()
        {
            _Alliance = new Alliance(this);
        }
    }
}
