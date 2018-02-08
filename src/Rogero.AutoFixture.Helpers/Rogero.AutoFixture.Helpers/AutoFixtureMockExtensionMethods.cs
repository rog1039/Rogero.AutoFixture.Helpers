using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoFixture;
using Moq;
using Moq.Language.Flow;

namespace Rogero.AutoFixture.Helpers
{
    public static class AutoFixtureMockExtensionMethods
    {
        public static void Mock<T>(this IFixture fixture, Action<Mock<T>> moqAction) where T : class
        {
            var moq = fixture.GetMock<T>();
            MockAction(fixture, moq, moqAction);
        }

        static void MockAction<T>(this IFixture fixture, Mock<T> moq, Action<Mock<T>> moqAction) where T : class
        {
            moqAction(moq);
            T subject = moq.Object;
            fixture.Register(() => subject);
            fixture.Register(() => moq);
        }

        public static Mock<T> GetMock<T>(this IFixture fixture) where T : class
        {
            var moq = fixture.Create<Mock<T>>();
            fixture.Register(() => moq);
            return moq;
        }

        public static ISetup<T> Setup<T>(this IFixture fixture, Expression<Action<T>> expression) where T : class
        {
            var mock = fixture.GetMock<T>();
            return mock.Setup(expression);
        }

        public static ISetup<T, TResult> Setup2<T, TResult>(this IFixture fixture, Expression<Func<T, TResult>> expression) where T : class
        {
            var mock = fixture.GetMock<T>();
            return mock.Setup(expression);
        }

        public static void Verify<T>(this IFixture fixture, Expression<Action<T>> action, Times times) where T : class
        {
            fixture.GetMock<T>().Verify(action, times);
        }

        public static IList<T> CreateList<T>(this IFixture fixture, int count)
        {
            return fixture.CreateMany<T>(count).ToList();
        }
    }
}
