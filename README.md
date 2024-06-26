## Application Preview
![image](https://github.com/uabarahona/bidcalculator/assets/15148088/8d63446d-9b9e-40e1-a41c-1caea7b6aabc)

## Demo

[![IMAGE ALT TEXT](http://img.youtube.com/vi/w2GCVh9pfJ8/0.jpg)](http://www.youtube.com/watch?v=w2GCVh9pfJ8)

## Description
This application was developed as part of an interview process. The tech stack used includes:
- .NET for the API
- Vue.js for the front-end
- .NET Aspire for the orchestrator

### Build & Run
The following are required to run the application:
- Node.js LTS
- .NET 8
- Docker

Once the prerequisites are installed, you can open the project in Visual Studio 2022 and run it. No further configurations are required. When running the application, it will automatically:
- Deploy and seed the database
- Run the front-end
- Run the API

### Considerations
The goal of this project was to create a quick MVP of a use case. Due to this, certain trade-offs have been made:

On the front-end:
- Few libraries like `headlessUI` and `vueUse` have been added to increase speed for the MVP. In a real-world scenario, after the MVP gets accepted, this would be one of the technical discussions to address.

On the back-end:
- Even though EF Core is being used, migrations are not utilized. In a real-world scenario, after the MVP gets accepted, this would be one of the first things to implement.
