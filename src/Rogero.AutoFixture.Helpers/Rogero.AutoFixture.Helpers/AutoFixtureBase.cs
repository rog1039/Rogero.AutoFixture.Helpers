using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;

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
