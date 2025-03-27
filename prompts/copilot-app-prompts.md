## prompts for refactoring, unit tests and UI development

### prompt for refactoring of Order controller

```
Can you evaluate this Web Controller and suggest changes to improve the design of this code so it adheres to our standards and overall best practices for .NET API development? For example, consider using the following patterns Repository Pattern** for data access Business Service/Delegate Pattern
```

### Unit Test Generation

```txt
@workspace `/tests`: Can you generate unit tests for this service? Use mocks for data access.Place the tests in the `tests` project folder.
 ```

### Generate unit tests for the Customer web controller
```
@workspace /tests generate web tests for my customer controller, use mocks for data access, store tests in the tests project and PLEASE ensure that the customer properties correctly map to those defined in the Customer entity class
```



### Create Customers web page using a page mockup created in webflow
```
can you generate an HTML page using the mockup image i've included, the page should allow searching by Customer ID and return the Order Details for the customer in a table as shown in the mock up. Order and mock up page
```

```
Can you generate an html page for me using the mockup page in the png file I attached
```

### Use Prompt to generate an OpenAI controller
```
// Develop a simple .NET Core Web API Controller that integrates with OpenAI API, using the sample curl request below to develop the integration
// 1. Expose a GET endpoint in the controller with the following pattern "/api/chat", the request should accept a single query parameter for "content"
// 2. Create a C# model class to encapsulate the request to the external API, the request should map to the JSON request in the example below
// 3. Use a string object to handle the JSON response payload and return the response back to the caller as-is
// 4. Read the value of the API key from the appsettings.json file
// 5. Use the following curl request sample below as an example to develop the integration
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
// 6. Use the HttpClient class to make the request to the OpenAI API and return the response as a string
// 7. Use the Newtonsoft.Json library to serialize and deserialize the JSON payloads
```

### Create web page using hand drawn mockup 
```
Using the following GET and POST requests samples, can you generate an html web page for me using the Orders search mockup image I've attached to search for Orders by Customer ID and display Orders in an html table, you can use jquery for the API calls, you can use Bootstrap CSS for styling

GET Request
{
  "orderId": 1,
  "customerId": 101,
  "orderDetails": "2x Laptop, 1x Mouse",
  "orderDate": "2025-03-26T10:00:00",
  "amount": 1500.00,
}

POST Request
{
  "customerId": 101,
  "orderDetails": "2x Laptop, 1x Mouse",
  "orderDate": "2025-03-26T10:00:00",
  "amount": 1500.00
}
```
