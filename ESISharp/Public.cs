using ESISharp.Enumeration;
using ESISharp.Paths.Public;

namespace ESISharp
{
    public class Public : Model.Abstract.EsiConnection
    {
        internal new Access Access = Access.Public;

        private readonly Alliance _Alliance;
        private readonly Character _Character;

        public Alliance Alliance => _Alliance;
        public Character Character => _Character;

        public Public() : base()
        {
            _Alliance = new Alliance(this);
            _Character = new Character(this);
        }
    }
}
