# Project Waterloo

This repo provides a solution for getting page rankings of a particular url from Google.

## About

It comes in two parts:
- API: A dotnet 8 api making use of Swagger UI for API documentation and the [SerpAPI](https://serpapi.com/) for getting the page ranking information
- FrontEnd: An Angular single page application for search and showing the information

It also uses xUnit and FakeItEasy for some basic units tests

## How to run

### API

 - Be sure to put the seperately provided Serp API key in the appsettings before running the API
 - Build API application
 - Run API application
   - It is suggested you choose the "https" option to run the application

The API should now be running on localhost:7157

### FrontEnd

- Run following commands InfoTrack.ProjectWaterloo/FrontEnd with Terminal or similar to start the Angular SPA:
  - npm install
  - ng build
  - ng serve

The FrontEnd should now be running on localhost:4200

## Troubleshooting

Couple of reasons why the frontend might not run:

- It was built using NodeJs v20.15.0, so you may need to update to this version
- You may not have angular install in which case you can run the following command: npm install -g @angular/cli
- Sometimes it doesn't let you run ng commands as its unsigned. You can bypass this temporarily by running: Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass

## Notes

At first I attempted to scrape the Google search results page directly. After realising that Google actually has methods in place to block this I changed direction and looked into APIs that could provide the results that I wanted. I settled on SerpAPI as it provides 100 requests per month free of charge.

The SerpAPI integration is a little limited, but it provides a lot of data in its response that could be used for various things. It also has the ability to search a variety of google domains and other search engines, which I had intended to facilitate, but after being delayed figuring out why the google page scraping wasn't working I didn't have the time.

The FrontEnd is incredibly limited in both design and functionality, but provides tyhe required tools to perform the required role. It is built using Angular as that is what I've used the most most recently. If you search multiple times it will list out the different results in a basic table.

I have used xUnit & FakeItEasy for the unit tests to fake services as I've used that in my current role, and my previous one, so it is something I'm familiar with and can implement quickly.
