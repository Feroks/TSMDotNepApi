# TSMDotNepApi
[![NuGet Release](https://img.shields.io/nuget/vpre/TSMDotNetApi.svg?maxAge=3600)](https://www.nuget.org/packages/TSMDotNetApi/)

.Net Standard library for [TradeSkillMaster API](http://api.tradeskillmaster.com/docs/)

## Usage

```C#
static async void testApiAsync()
{
    var explorer = new TsmExplorer("your API key");
    // Blade of Wizardry
    var data = await _tsmExplorer.GetItemGlobalDataAsync(31336);
}
```

## Installation

Install as [NuGet package](https://www.nuget.org/packages/Telegram.Bot/):

```powershell
Install-Package TSMDotNetApi
```
