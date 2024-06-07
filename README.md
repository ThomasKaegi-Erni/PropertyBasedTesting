# PropertyBasedTesting

Examples of property based testing.

## Mindset

- Test abstract properties of types.
  - Not values
- Test observable behaviour of types and abstractions.
  - Not implementations
- Find invariants and test those.
  - reversing a collection twice should give you the same list you started with
  - round robin serialisation ought to give you the same value you started with

See the simplistic tests [AdditionTest](BusinessLogic.Test/AdditionTest.cs) and [SomethingDisposableTest](BusinessLogic.Test/SomethingDisposableTest.cs) show this.

## Libraries

For C# there only seems to be [FsCheck](https://github.com/fscheck/FsCheck)...

- Good integration with `Nunit` and `Xunit` via dedicated nuget packages.
- Not trivial to (auto-) generate test data.
- More readable test output
  - One test fails per tested property
- Is not guaranteed to find failing cases.
  - With randomised data this can give the appearance of flaky tests.

See the [FsCheckAdditionTest](BusinessLogic.Test/FsCheckAdditionTest.cs) test for some very simple examples.

## References

Scott Wlaschin: [The Enterprise Developer from Hell](https://fsharpforfunandprofit.com/posts/property-based-testing/), "outwitting malicious compliance with property-based testing".

- He has written a [whole series](https://fsharpforfunandprofit.com/series/property-based-testing/) on the topic :-)
- with unlisted additions featuring the "EDFH", the "Enterprise Developer From Hell"
  - Series start [here](https://fsharpforfunandprofit.com/posts/return-of-the-edfh/).
