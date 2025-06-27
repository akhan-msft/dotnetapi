using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tests.webapi
{
    [TestFixture]
    public class CustomerControllerValidationTests
    {
        private CustomerController _controller;
        private Mock<ICustomerService> _mockCustomerService;

        [SetUp]
        public void Setup()
        {
            _mockCustomerService = new Mock<ICustomerService>();
            _controller = new CustomerController(_mockCustomerService.Object);
        }

        [Test]
        public async Task CreateCustomer_WithValidCustomer_ReturnsCreatedResult()
        {
            // Arrange
            var customer = new Customer
            {
                CustomerName = "John Doe",
                CustomerStreetAddress = "123 Main St",
                City = "Anytown",
                State = "CA",
                PostalCode = "12345"
            };

            _mockCustomerService.Setup(x => x.CreateCustomerAsync(It.IsAny<Customer>()))
                .ReturnsAsync(customer);

            // Act
            var result = await _controller.CreateCustomer(customer);

            // Assert
            Assert.That(result, Is.InstanceOf<CreatedAtActionResult>());
        }

        [Test]
        public async Task CreateCustomer_WithNullCustomer_ReturnsBadRequest()
        {
            // Act
            var result = await _controller.CreateCustomer(null!);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
            var badRequestResult = result as BadRequestObjectResult;
            Assert.That(badRequestResult!.Value, Is.EqualTo("Customer data is required."));
        }

        [Test]
        public async Task CreateCustomer_WithInvalidCustomerName_ReturnsBadRequest()
        {
            // Arrange
            var customer = new Customer
            {
                CustomerName = "", // Invalid: empty name
                CustomerStreetAddress = "123 Main St",
                City = "Anytown",
                State = "CA",
                PostalCode = "12345"
            };

            // Manually trigger validation
            var validationContext = new ValidationContext(customer);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(customer, validationContext, validationResults, true);

            // Simulate ModelState being invalid
            foreach (var validationResult in validationResults)
            {
                _controller.ModelState.AddModelError(validationResult.MemberNames.FirstOrDefault() ?? "", validationResult.ErrorMessage ?? "");
            }

            // Act
            var result = await _controller.CreateCustomer(customer);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task CreateCustomer_WithExcessivelyLongName_ReturnsBadRequest()
        {
            // Arrange
            var customer = new Customer
            {
                CustomerName = new string('A', 101), // Invalid: too long
                CustomerStreetAddress = "123 Main St",
                City = "Anytown",
                State = "CA",
                PostalCode = "12345"
            };

            // Manually trigger validation
            var validationContext = new ValidationContext(customer);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(customer, validationContext, validationResults, true);

            // Simulate ModelState being invalid
            foreach (var validationResult in validationResults)
            {
                _controller.ModelState.AddModelError(validationResult.MemberNames.FirstOrDefault() ?? "", validationResult.ErrorMessage ?? "");
            }

            // Act
            var result = await _controller.CreateCustomer(customer);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task CreateCustomer_WithMaliciousCharacters_ReturnsBadRequest()
        {
            // Arrange
            var customer = new Customer
            {
                CustomerName = "<script>alert('xss')</script>", // Invalid: malicious characters
                CustomerStreetAddress = "123 Main St",
                City = "Anytown",
                State = "CA",
                PostalCode = "12345"
            };

            // Manually trigger validation
            var validationContext = new ValidationContext(customer);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(customer, validationContext, validationResults, true);

            // Simulate ModelState being invalid
            foreach (var validationResult in validationResults)
            {
                _controller.ModelState.AddModelError(validationResult.MemberNames.FirstOrDefault() ?? "", validationResult.ErrorMessage ?? "");
            }

            // Act
            var result = await _controller.CreateCustomer(customer);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task GetCustomer_WithValidId_ReturnsOkResult()
        {
            // Arrange
            var customer = new Customer { CustomerId = 1, CustomerName = "John Doe" };
            _mockCustomerService.Setup(x => x.GetCustomerByIdAsync(1))
                .ReturnsAsync(customer);

            // Act
            var result = await _controller.GetCustomer(1);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task GetCustomer_WithInvalidId_ReturnsBadRequest()
        {
            // Act
            var result = await _controller.GetCustomer(-1);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
            var badRequestResult = result as BadRequestObjectResult;
            Assert.That(badRequestResult!.Value, Is.EqualTo("Customer ID must be a positive integer."));
        }

        [Test]
        public async Task GetCustomer_WithZeroId_ReturnsBadRequest()
        {
            // Act
            var result = await _controller.GetCustomer(0);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
            var badRequestResult = result as BadRequestObjectResult;
            Assert.That(badRequestResult!.Value, Is.EqualTo("Customer ID must be a positive integer."));
        }

        [Test]
        public async Task SearchCustomersByName_WithValidName_ReturnsOkResult()
        {
            // Arrange
            var customers = new List<Customer?> { new Customer { CustomerName = "John" } };
            _mockCustomerService.Setup(x => x.SearchCustomersByNameAsync("John"))
                .ReturnsAsync(customers);

            // Act
            var result = await _controller.SearchCustomersByName("John");

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task SearchCustomersByName_WithEmptyName_ReturnsBadRequest()
        {
            // Act
            var result = await _controller.SearchCustomersByName("");

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
            var badRequestResult = result as BadRequestObjectResult;
            Assert.That(badRequestResult!.Value, Is.EqualTo("Name parameter is required."));
        }

        [Test]
        public async Task SearchCustomersByName_WithExcessivelyLongName_ReturnsBadRequest()
        {
            // Arrange
            var longName = new string('A', 101);

            // Act
            var result = await _controller.SearchCustomersByName(longName);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
            var badRequestResult = result as BadRequestObjectResult;
            Assert.That(badRequestResult!.Value, Is.EqualTo("Name parameter cannot exceed 100 characters."));
        }

        [Test]
        public async Task SearchCustomersByName_WithMaliciousCharacters_ReturnsBadRequest()
        {
            // Act
            var result = await _controller.SearchCustomersByName("<script>alert('xss')</script>");

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
            var badRequestResult = result as BadRequestObjectResult;
            Assert.That(badRequestResult!.Value, Is.EqualTo("Name parameter contains invalid characters."));
        }

        [Test]
        public async Task SearchCustomersByName_WithSpecialCharacters_ReturnsBadRequest()
        {
            // Act
            var result = await _controller.SearchCustomersByName("test&dangerous");

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
            var badRequestResult = result as BadRequestObjectResult;
            Assert.That(badRequestResult!.Value, Is.EqualTo("Name parameter contains invalid characters."));
        }
    }
}