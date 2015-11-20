[![Build status](https://ci.appveyor.com/api/projects/status/oscx09t7s06sgiqc?svg=true)](https://ci.appveyor.com/project/Felsig/emotion-api/branch/master)
[license-image]: http://img.shields.io/badge/license-MIT-green.svg?style=flat-square
[license-url]: LICENSE

# Emotion-API
.Net library that wraps the Microsoft Project Oxford [Emotion API](https://www.projectoxford.ai/doc/Emotion/overview) for easier, simpler use inside your .Net application.

###Usage examples
```c#
var client = new EmotionAPIClient("{your_api_key}");
var response = client.Post("{image_url}");

foreach(var item in response)
{
  // item.Scores.Anger;
  // item.FaceRectangle.Height;
  // ...
}
```

###License
Licensed under the MIT License
