Orleans.Journal
===============

Event Sourcing for Microsoft Orleans (https://orleans.codeplex.com)

# Usage
Grain implementations must have the [JournalProvider("SomeCloudConfigProperty")] attribute, where the provider is the name of a property defined in the Azure Cloud Service's Configuration.

**Providers take the format:**
`Provider=AssemblyQualifiedClassNameOfProvider;OtherSetting=OtherValue;YetAnotherSetting=YetAnotherValue`
  
**Example:**
`Provider=Orleans.Journal.AzureTable.AzureTableJournal,Orleans.Journal.AzureTable;Table=grainJournal;ConnectionStringSetting=JournalConnection`

* Derive grain implementation from `JournaledGrainBase<TGrain, TGrainState>`.
* Persist a message with `await this.Journal.WriteJournal();`.
* Access state by modifying `this.State.Value`.

See [StackGrain.cs](https://github.com/daprlabs/Orleans.Journal/blob/master/TestGrains/StackGrain.cs) for an example of usage. Something akin to this:
```c#
[JournalProvider("DefaultJournal")]
public class StackGrain : JournaledGrainBase<StackGrain, Stack<int>>, IStackGrain
{
    public async Task<int> GetSize()
    {
        return this.State.Value.Count;
    }

    public async Task Push(int value)
    {
        await this.Journal.WriteJournal();
        this.State.Value.Push(value);
    }

    public async Task<int> Pop()
    {
        await this.Journal.WriteJournal();
        return this.State.Value.Pop();
    }
}
```
