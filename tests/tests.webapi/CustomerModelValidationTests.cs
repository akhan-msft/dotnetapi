using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace tests.webapi
{
    [TestFixture]
    public class CustomerModelValidationTests
    {
        private ValidationContext GetValidationContext(Customer customer)
        {
            return new ValidationContext(customer);
        }

        private List<ValidationResult> ValidateModel(Customer customer)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = GetValidationContext(customer);
            Validator.TryValidateObject(customer, validationContext, validationResults, true);
            return validationResults;
        }

        [Test]
        public void Customer_WithValidData_PassesValidation()
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

            // Act
            var validationResults = ValidateModel(customer);

            // Assert
            Assert.That(validationResults, Is.Empty);
        }

        [Test]
        public void Customer_WithEmptyName_FailsValidation()
        {
            // Arrange
            var customer = new Customer
            {
                CustomerName = "",
                CustomerStreetAddress = "123 Main St",
                City = "Anytown",
                State = "CA",
                PostalCode = "12345"
            };

            // Act
            var validationResults = ValidateModel(customer);

            // Assert
            Assert.That(validationResults, Is.Not.Empty);
            Assert.That(validationResults.Any(v => v.ErrorMessage!.Contains("Customer name")), Is.True);
        }

        [Test]
        public void Customer_WithExcessivelyLongName_FailsValidation()
        {
            // Arrange
            var customer = new Customer
            {
                CustomerName = new string('A', 101), // Exceeds 100 character limit
                CustomerStreetAddress = "123 Main St",
                City = "Anytown",
                State = "CA",
                PostalCode = "12345"
            };

            // Act
            var validationResults = ValidateModel(customer);

            // Assert
            Assert.That(validationResults, Is.Not.Empty);
            Assert.That(validationResults.Any(v => v.ErrorMessage!.Contains("between 1 and 100 characters")), Is.True);
        }

        [Test]
        public void Customer_WithInvalidCharactersInName_FailsValidation()
        {
            // Arrange
            var customer = new Customer
            {
                CustomerName = "<script>alert('xss')</script>",
                CustomerStreetAddress = "123 Main St",
                City = "Anytown",
                State = "CA",
                PostalCode = "12345"
            };

            // Act
            var validationResults = ValidateModel(customer);

            // Assert
            Assert.That(validationResults, Is.Not.Empty);
            Assert.That(validationResults.Any(v => v.ErrorMessage!.Contains("invalid characters")), Is.True);
        }

        [Test]
        public void Customer_WithExcessivelyLongAddress_FailsValidation()
        {
            // Arrange
            var customer = new Customer
            {
                CustomerName = "John Doe",
                CustomerStreetAddress = new string('A', 201), // Exceeds 200 character limit
                City = "Anytown",
                State = "CA",
                PostalCode = "12345"
            };

            // Act
            var validationResults = ValidateModel(customer);

            // Assert
            Assert.That(validationResults, Is.Not.Empty);
            Assert.That(validationResults.Any(v => v.ErrorMessage!.Contains("between 1 and 200 characters")), Is.True);
        }

        [Test]
        public void Customer_WithInvalidCharactersInAddress_FailsValidation()
        {
            // Arrange
            var customer = new Customer
            {
                CustomerName = "John Doe",
                CustomerStreetAddress = "123 Main St <script>",
                City = "Anytown",
                State = "CA",
                PostalCode = "12345"
            };

            // Act
            var validationResults = ValidateModel(customer);

            // Assert
            Assert.That(validationResults, Is.Not.Empty);
            Assert.That(validationResults.Any(v => v.ErrorMessage!.Contains("invalid characters")), Is.True);
        }

        [Test]
        public void Customer_WithExcessivelyLongCity_FailsValidation()
        {
            // Arrange
            var customer = new Customer
            {
                CustomerName = "John Doe",
                CustomerStreetAddress = "123 Main St",
                City = new string('A', 51), // Exceeds 50 character limit
                State = "CA",
                PostalCode = "12345"
            };

            // Act
            var validationResults = ValidateModel(customer);

            // Assert
            Assert.That(validationResults, Is.Not.Empty);
            Assert.That(validationResults.Any(v => v.ErrorMessage!.Contains("between 1 and 50 characters")), Is.True);
        }

        [Test]
        public void Customer_WithInvalidCharactersInCity_FailsValidation()
        {
            // Arrange
            var customer = new Customer
            {
                CustomerName = "John Doe",
                CustomerStreetAddress = "123 Main St",
                City = "Any<town>",
                State = "CA",
                PostalCode = "12345"
            };

            // Act
            var validationResults = ValidateModel(customer);

            // Assert
            Assert.That(validationResults, Is.Not.Empty);
            Assert.That(validationResults.Any(v => v.ErrorMessage!.Contains("invalid characters")), Is.True);
        }

        [Test]
        public void Customer_WithShortState_FailsValidation()
        {
            // Arrange
            var customer = new Customer
            {
                CustomerName = "John Doe",
                CustomerStreetAddress = "123 Main St",
                City = "Anytown",
                State = "C", // Too short
                PostalCode = "12345"
            };

            // Act
            var validationResults = ValidateModel(customer);

            // Assert
            Assert.That(validationResults, Is.Not.Empty);
            Assert.That(validationResults.Any(v => v.ErrorMessage!.Contains("between 2 and 50 characters")), Is.True);
        }

        [Test]
        public void Customer_WithInvalidCharactersInPostalCode_FailsValidation()
        {
            // Arrange
            var customer = new Customer
            {
                CustomerName = "John Doe",
                CustomerStreetAddress = "123 Main St",
                City = "Anytown",
                State = "CA",
                PostalCode = "123<45>" // Invalid characters
            };

            // Act
            var validationResults = ValidateModel(customer);

            // Assert
            Assert.That(validationResults, Is.Not.Empty);
            Assert.That(validationResults.Any(v => v.ErrorMessage!.Contains("invalid characters")), Is.True);
        }

        [Test]
        public void Customer_WithShortPostalCode_FailsValidation()
        {
            // Arrange
            var customer = new Customer
            {
                CustomerName = "John Doe",
                CustomerStreetAddress = "123 Main St",
                City = "Anytown",
                State = "CA",
                PostalCode = "12" // Too short
            };

            // Act
            var validationResults = ValidateModel(customer);

            // Assert
            Assert.That(validationResults, Is.Not.Empty);
            Assert.That(validationResults.Any(v => v.ErrorMessage!.Contains("between 3 and 20 characters")), Is.True);
        }

        [Test]
        public void Customer_WithValidAlternativePostalCode_PassesValidation()
        {
            // Arrange
            var customer = new Customer
            {
                CustomerName = "John Doe",
                CustomerStreetAddress = "123 Main St",
                City = "Anytown",
                State = "Ontario",
                PostalCode = "K1A 0A6" // Canadian postal code format
            };

            // Act
            var validationResults = ValidateModel(customer);

            // Assert
            Assert.That(validationResults, Is.Empty);
        }
    }
}