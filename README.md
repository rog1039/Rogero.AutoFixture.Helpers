# Rogero.AutoFixture.Helpers

## Nuget

```Install-Package Rogero.AutoFixture.Helpers```

Nuget here: https://www.nuget.org/packages/Rogero.AutoFixture.Helpers/

# Overview

This is a simple library of methods to help configure Moq mock objects using AutoFixture.

I typically use it like the following:

```csharp
var _fixture = new Fixture();

fixture.GetMock<IWatchDefinitionRepository>()
		.Setup(x => x.GetWatchDefinitions())
		.Returns(testCase.WatchDefinitions);
		
fixture.GetMock<IWatchDefinitionRepository>()
		.Setup(x => x.GetMostRecentWatchRunRecords())
		.Returns(testCase.TableWatchRecordRuns);
```

The helper method GetMock<T> performs two functions:
* Creates a Moq mock object
* Registeres the mock and the mocked object with the _fixture Fixture variable.

This way we can continue to call GetMock<T>() to retrieve the mock to mock out additional methods.

When we resolve from the container for the mocked object or an object that uses the mocked object, the _fixture will supply the mocked object.

## Helpful Hint

This project works best when creating fixture like this: 
```csharp
var fixture = new Fixture();
fixture.Customize(new AutoConfiguredMoqCustomization());
```

This way we can resolve from the Fixture and any dependencies required will be Moq'ed automatically.

The ```AutoMoqCustomization``` object is contained in another Nuget package, ```AutoFixture.AutoMoq``` available here: https://www.nuget.org/packages/AutoFixture.AutoMoq
