namespace ESISharp.Sso.Scopes
{
    public partial class Scope
    {
        public static class Skills
        {
            public static readonly Scope ReadSkillQueue = new Scope("esi-skills.read_skillqueue.v1");
            public static readonly Scope ReadSkills = new Scope("esi-skills.read_skills.v1");
        }
    }
}
