# TSMDotNepApi
[![NuGet Release](https://img.shields.io/nuget/vpre/TSMDotNetApi.svg?maxAge=3600)](https://www.nuget.org/packages/TSMDotNetApi/)

.Net Standard library for [TradeSkillMaster API](http://api.tradeskillmaster.com/docs/)

## Usage

```C#
static async void testApiAsync()
{
    var explorer = new TsmExplorer("your API key");
    try
    {
        // Blade of Wizardry
        var data = await _tsmExplorer.GetItemGlobalDataAsync(31336);
    }
    catch (TsmFailedException te)
    {
        // Request to TSM was invalid
    }
    catch (Exception e)
    {
        // Generic exception
    }
}
```

## Installation

Install as [NuGet package](https://www.nuget.org/packages/TSMDotNetApi/):

```powershell
Install-Package TSMDotNetApi
```
