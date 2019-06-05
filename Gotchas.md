# Learning Project "Gotcha!"s

### 1. Authentication for making the https request was a little tricky to figure out

This [stack overflow post](https://stackoverflow.com/questions/14627399/setting-authorization-header-of-httpclient) turned out to be what I was really looking for. The answers are pretty concise.

### 2. JSON parsing is tricky. You can't use the same function to handle "{}" vs. "[{}, ...]" vs. "{var: [{}, ...]}"

There were three different ways that we ended up trying to tackle the problem. 
1. The first was to just deserialize the JSON and dynamically create a C# object out of it. Using "dynamic" and expando objects was the cleanest but trickiest solution. 
2. We then tried using JObject.Parse, which worked a lot better. It returns a JObject, but it struggles to handle an array of objects, which many api responses return.
3. We tried using JArray.Parse, but that only works with arrays. We figured it was easier to make a single object into an array, rather than make our array into an object. 

### 3. A fair understanding of the difference between JTokens and JObjects is really important to get the Newtonsoft working.

I would just point people to a few different pages that are pretty important to know:
1. [JObjects](https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_Linq_JObject.htm)
  - Represents a Json object. 
2. [JArrays](https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_Linq_JArray.htm)
  - Represents a Json Array.
  - The underlying structure is a list.
3. [JProperties](https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_Linq_JProperty.htm)
  - Represents a Json Property.
4. [JTokens](https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_Linq_JToken.htm)
  - Represents and Abstract JSON token. 
  - A single Key Value Pair of a Json object.

This [last stack overflow post](https://stackoverflow.com/questions/15726197/parsing-a-json-array-using-json-net) one shows you a good way to read from arrays.

### 4. CsvHelper handles c# objects mostly, getting it to work with JSON requires more than the examples show.

It would be good to read the api reference for [CsvWriter](https://joshclose.github.io/CsvHelper/api/CsvHelper/CsvWriter). If reading is needed, the [CsvReader](https://joshclose.github.io/CsvHelper/api/CsvHelper/CsvReader/) and the [CsvParser](https://joshclose.github.io/CsvHelper/api/CsvHelper/CsvParser/) classes are nice to know. Here are [a few examples](https://joshclose.github.io/CsvHelper/getting-started#writing-a-csv-file) to get a simple idea how to write to a csv.

