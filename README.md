# URLShortenerAPI

Welcome to the URLShortenerAPI repository! This repository contains a simple URL shortener API implemented in C# using ASP.NET Core.

## Overview

URLShortenerAPI provides a RESTful API for shortening URLs. It allows you to generate short and memorable URLs for your links, perfect for sharing on social media, in presentations, or wherever you need to save space.

## Features

- **Shorten URLs**: Generate short URLs for long links.
- **Retrieve Long URLs**: Retrieve the original long URL from a short URL.
- **Persistence**: Data is persisted across sessions using JSON serialization.
- **Easy Integration**: Simple API for integrating into your applications.

## Usage

To use the API, send a POST request to `/shorten` with a JSON payload containing the long URL you want to shorten. The API will return a JSON response with the shortened URL.

Example Request:
```json
POST /shorten
{
  "LongURL": "https://www.example.com/very/long/url"
}

##   Getting Started

Clone this repository.
Build and run the project in your development environment.
Send POST requests to /shorten to shorten URLs.
Dependencies
ASP.NET Core
Newtonsoft.Json
##License
This project is licensed under the MIT License. See the LICENSE file for details.

##Contributing
Contributions are welcome! Feel free to open an issue or submit a pull request.

##Contact
For questions or support, please contact Parag Sarin.

Thank you for checking out URLShortenerAPI! We hope you find it useful for your projects.
