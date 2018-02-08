using AutoFixture;
using AutoFixture.AutoMoq;

namespace Rogero.AutoFixture.Helpers
{
    public class AutoFixtureBase
    {
        protected readonly IFixture _fixture;

        public AutoFixtureBase()
        {
            _fixture = new Fixture();
            _fixture.Customize(new AutoConfiguredMoqCustomization());
        }
    }
}
