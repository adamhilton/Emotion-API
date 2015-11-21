# .Net EmotionAPI
[![Build status](https://ci.appveyor.com/api/projects/status/oscx09t7s06sgiqc?svg=true)](https://ci.appveyor.com/project/Felsig/emotion-api/branch/master)
[![NuGet Version](http://img.shields.io/nuget/v/EmotionAPI.svg?style=flat)](https://www.nuget.org/packages/EmotionAPI/)
[![License][license-image]][license-url]
[license-image]: http://img.shields.io/badge/license-MIT-green.svg
[license-url]: LICENSE

## Summary
.Net class library that wraps the Microsoft Project Oxford [Emotion API](https://www.projectoxford.ai/doc/Emotion/overview) for easier, simpler use inside your .Net application.

## Get it on NuGet!
    Install-Package EmotionAPI

## Usage examples
```c#
var client = new EmotionAPIClient("{your_api_key}");
var response = client.PostAsync("{image_url || image_bytes}");

foreach(var item in response)
{
  // item.Scores.Anger;
  // item.FaceRectangle.Height;
  // ...
}
```
## License

Licensed under the [MIT License](https://github.com/Felsig/Emotion-API/blob/master/LICENSE)
