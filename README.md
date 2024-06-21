# Project Waterloo

This repo provides a solution for getting page rankings of a particular url from Google.

## About

It comes in two parts:
- API: A dotnet 8 api making use of Swagger UI for API documentation and the Serp API for getting the page ranking information
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
