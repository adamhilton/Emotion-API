# .Net EmotionAPI

[![Join the chat at https://gitter.im/Felsig/Emotion-API](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/Felsig/Emotion-API?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
[![Build status](https://img.shields.io/appveyor/ci/felsig/emotion-api/master.svg?style=flat-square)](https://ci.appveyor.com/project/Felsig/emotion-api/branch/master)
[![NuGet Version](http://img.shields.io/nuget/v/EmotionAPI.svg?style=flat-square)](https://www.nuget.org/packages/EmotionAPI/)
[![License][license-image]][license-url]
[license-image]: https://img.shields.io/badge/license-MIT-blue.svg?style=flat-square
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
