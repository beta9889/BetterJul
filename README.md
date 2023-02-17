# BetterJul
## Installation

Clone the repository. 
In the project JulAPI create a file called "*appsettings.json*" with the following lines 
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

In the same project (JulAPI) create a file called "*appsettings.Development.json*" with the following lines
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```

In the project ClientSide create a file called "*appsettings.json*" with the following lines

```
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

```

In the same project (ClientSide) create a file called "*appsettings.Development.json*" with the following lines
```
{
  "DetailedErrors": true,
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```
