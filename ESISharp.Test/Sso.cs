using ESISharp.Sso.Scopes;
using ESISharp.Test.Model.Abstract;
using NUnit.Framework;
using System;

namespace ESISharp.Test
{
    public class Sso : PathTest
    {
        [CIIgnore]
        [Test]
        public void Authentication()
        {
            Authenticated.Sso.Client.AddScope(Scope.All);
            var a = Authenticated.Sso.ForceAuthentication();
            var t = Authenticated.Sso.Client.Token;
            Assert.Multiple(() => 
            {
                Assert.True(a);
                Assert.False(string.IsNullOrWhiteSpace(t.AccessToken));
                Assert.False(string.IsNullOrWhiteSpace(t.RefreshToken));
                Assert.False(string.IsNullOrWhiteSpace(t.TokenType));
                Assert.True(t.TokenType == "Bearer");
                Assert.True(t.Expires > DateTime.UtcNow);
            });
        }

        [CIIgnore]
        [Test]
        public void VerifyToken()
        {
            var a = Authenticated.Sso.ForceAuthentication();
            var v = Authenticated.Sso.Authentication.VerifyToken();
            Assert.Multiple(() =>
            {
                Assert.True(a);
                Assert.IsNotNull(v.CharacterID);
                Assert.IsNotEmpty(v.CharacterName);
                Assert.IsNotEmpty(v.CharacterOwnerHash);
                Assert.AreNotEqual(v.Expires, DateTime.MinValue);
                Assert.AreEqual(v.IntellectualProperty, "EVE");
                Assert.IsNotEmpty(v.Scopes);
                Assert.AreEqual(v.TokenType, "Character");
            });
        }
    }
}
