Orleans.Journal
===============

Event Sourcing for Microsoft Orleans (https://orleans.codeplex.com)

# Usage
Grain implementations must have the [JournalProvider("SomeCloudConfigProperty")] attribute, where the provider is the name of a property defined in the Azure Cloud Service's Configuration.
Providers take the format: 
  Provider=<AssemblyQualifiedClassNameOfProvider>;OtherSetting=OtherValue;YetAnotherSetting=YetAnotherValue
Example:
  Provider=Orleans.Journal.AzureTable.AzureTableJournal,Orleans.Journal.AzureTable;Table=grainJournal;ConnectionStringSetting=JournalConnection

See https://github.com/daprlabs/Orleans.Journal/blob/master/TestGrains/StackGrain.cs for an example of usage.
