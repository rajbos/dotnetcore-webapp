# dotnetcore-webapp
Example environment to test and show a project setup for a sample application

Example application has been created with dotnet:
```
dotnet new webapp
```

In the workflow folder you can find 2 different workflows for build and deploying the application onto environments:

|file|purpose|
|---|---|
|dotnetcore.yml|deploy into an Azure App Service|
|dotnetcore-iis.yml|deploy to an IIS website on a Windows machine locally|

Deployment is done with these steps:
* Build
* Publish
* Deploy
* Run a first request (warmup and to check if it is up)
* Run a set of end-to-end (aka webtests) on the deployed application

If you have an questions or want another example, please raise an issue :hammer:.
