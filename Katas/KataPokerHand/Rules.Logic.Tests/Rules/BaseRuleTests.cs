using System.Diagnostics.CodeAnalysis;
using NSubstitute;
using NUnit.Framework;
using Rules.Logic.Interfaces.Conditions;
using Rules.Logic.Rules;

namespace Rules.Logic.Tests.Rules.Rules
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal class BaseRuleTests
    {
        private ICellInformation CreateCellInformation()
        {
            return new CellInformation
                   {
                       RowIndex = 0,
                       ColumnIndex = 0,
                       Status = 0
                   };
        }

        private TestRule CreateSut()
        {
            var testRule = new TestRule();

            return testRule;
        }

        private sealed class TestRule : BaseRule <ICellInformation, int>
        {
            public bool WasCalledInitialize { get; private set; }

            public bool WasCalledApply { get; private set; }

            public override ICellInformation Apply(ICellInformation info)
            {
                WasCalledApply = true;

                return info;
            }

            public override int GetPriority()
            {
                return 1;
            }

            public override void Initialize(ICellInformation info)
            {
                Conditions.Add(Substitute.For <ICondition <int>>());
                Conditions.Add(Substitute.For <ICondition <int>>());

                WasCalledInitialize = true;
            }
        }

        [Test]
        public void Apply_CallsApply_WhenCalled()
        {
            // Arrange
            ICellInformation info = CreateCellInformation();
            TestRule sut = CreateSut();

            // Act
            sut.Apply(info);

            // Assert
            //sut.WasCalledApply.ShouldBeTrue();
        }

        [Test]
        public void ClearConditions_ClearsCondintions_WhenCalled()
        {
            // Arrange
            ICellInformation info = CreateCellInformation();
            TestRule sut = CreateSut();
            sut.Initialize(info);

            // Act
            sut.ClearConditions();

            // Assert
            //sut.GetConditions().Count().ShouldEqual(0);
        }

        [Test]
        public void Conditions_ReturnsEmpty_ByDefault()
        {
            // Arrange
            // Act
            TestRule sut = CreateSut();

            // Assert
            //sut.GetConditions().Count().ShouldEqual(0);
        }

        [Test]
        public void Initialize_AddsConditions_WhenCalled()
        {
            // Arrange
            ICellInformation info = CreateCellInformation();
            TestRule sut = CreateSut();

            // Act
            sut.Initialize(info);

            // Assert
            //sut.GetConditions().Count().ShouldEqual(2);
        }

        [Test]
        public void Initialize_CallsInitialize_WhenCalled()
        {
            // Arrange
            ICellInformation info = CreateCellInformation();
            TestRule sut = CreateSut();

            // Act
            sut.Initialize(info);

            // Assert
            //sut.WasCalledInitialize.ShouldBeTrue();
        }

        [Test]
        public void Priority_ReturnsInteger_WhenCalled()
        {
            // Arrange
            ICellInformation info = CreateCellInformation();
            TestRule sut = CreateSut();

            // Act
            sut.Apply(info);

            // Assert
            Assert.AreEqual(1,
                            sut.Priority);
        }
    }
}