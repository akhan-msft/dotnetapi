## prompts for refactoring, unit tests and UI development

### copilot edits , handling multiple changes to a file
```
can you please recommend the changes that are required to expose this new stored procedure GetCustomersByPostalCode as a new data access method in my application.
```

### Unit tests for new customer service
```
can you please help write unit tests for this service class, please ensure that you are using the correct customer model properties inside the unit tests, use mocks for database access
```

### prompt for refactoring of Order controller

```
can you review my Order Controller service code for best practices?
```

```
Can you suggest changes for this controller so it uses design patterns like the Repository Pattern for data access and a Business Service or Delegate for a cleaner design. Use best practices for this implementation
```

###http client tests for the Order service
```
can you generate 2 new http client tests for me using the pattern shown in this file, use unique random data and generate 2 tests each for GET and POST requests
```

### Unit Test Generation

```txt
@workspace `/tests`: Can you generate unit tests for this service? Use mocks for data access.
 ```

### Generate unit tests for the Customer web controller
```
@workspace /tests generate web tests for my customer controller, use mocks for data access, store tests in the tests project and PLEASE ensure that the customer properties correctly map to those defined in the Customer entity class
```


### Simple UI updates to the Customer entry page
```
can you make this page more modern and progressive looking by using bootstrap framework so the forms and tables look more presentable

```

### Create Customers web page using a page mockup created in webflow
```
Can you generate an html page for me using the mockup page in the png file I attached
```

```
can you update the page so it uses the customer API to save customer and also integrate the search by name for the top search form? please use jquery for invoking the API and use the correct properties for the customer class, if a customer is found, the page and the form fields should be updated accordingly
```

```
Can you generate an html page for me using the mockup page I attached? the page has a search form that allows searching a customer by name and then populates the form below with the customer values if the customer is found

Please integrate with the Customer Controller API to search for and or create new customers. Please use jquery for invoking the API and use the correct properties and fields for the Customer, use bootstrap to enhance and present a modern look to the page.
```

### Use Prompt to generate an OpenAI controller
```
// Develop a simple .NET Core Web API Controller that integrates with OpenAI API, using the sample curl request below to develop the integration
// 1. Expose a GET endpoint in the controller with the following pattern "/api/chat", the request should accept a single query parameter for "content"
// 2. Create a C# model class to encapsulate the request to the external API, the request should map to the JSON request in the example below
// 3. Use a string object to handle the JSON response payload and return the response back to the caller as-is
// 4. Use the following curl request sample below as an example to develop the integration
// curl https://api.openai.com/v1/chat/completions \
// -H "Content-Type: application/json" \
// -H "Authorization: Bearer $OPENAI_API_KEY" \
// -d '{
//         "model": "gpt-4o",
//         "store": true,
//         "messages": [
//             {"role": "user", "content": "Tell me about GH Copilot"}
//         ]
//     }'
// 5. Use the HttpClient class to make the request to the OpenAI API 
// 6. Use the Newtonsoft.Json library to serialize and deserialize the JSON payloads
```

### Create web page using sketched mockup 
```
```
can you generate an HTML page using the mockup image i've included, the page should allow searching by Customer ID and return the Order Details for the customer in a table as shown in the mock up. Order and mock up page
```

```
Using the following GET request sample, can you generate an html web page for me using the Orders search mockup image I've attached to search for Orders by Customer ID and display Orders in an html table, you can use jquery for the API calls and Bootstrap theme for a modern look

GET Request  /api/order/customer/101
{
  "orderId": 1,
  "customerId": 101,
  "orderDetails": "2x Laptop, 1x Mouse",
  "orderDate": "2025-03-26T10:00:00",
  "amount": 1500.00,
}
```
```Agent mode
can you create a .net 8 web API project for me that implements a REST API for products, use an in memory data store for the data and enable swagger support to test the APIs, create the project and build it and resolve any errors that occur during the setup
```

```Agent mode tests
I would like to add unit tests for my Customer web controller in the /tests/tests.webapi project, can you help write these unit tests and compile and run these tests to ensure they are working, use mock objects wherever possible and again please create the files in the test project folder only
```

```
I would like to create a new SPA app using React JS that consumes the Customer API, the UI should follow the look in the index.html page for the Customer view and add functionality, please use a new project directory within this workspace to create the SPA front end project, ensure the app compiles and starts up correctly
```