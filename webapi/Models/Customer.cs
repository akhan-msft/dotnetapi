using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

[Table("customers")]
public class Customer
{
    [Key]
    [Column("customer_id")]
    public int CustomerId { get; set; }
    
    [Required(ErrorMessage = "Customer name is required")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Customer name must be between 1 and 100 characters")]
    [RegularExpression(@"^[a-zA-Z0-9\s\.\-']+$", ErrorMessage = "Customer name contains invalid characters")]
    [Column("customer_name")]
    [JsonPropertyName("name")]
    public string CustomerName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Street address is required")]
    [StringLength(200, MinimumLength = 1, ErrorMessage = "Street address must be between 1 and 200 characters")]
    [RegularExpression(@"^[a-zA-Z0-9\s\.\-#,]+$", ErrorMessage = "Street address contains invalid characters")]
    [Column("customer_street_address")]
    [JsonPropertyName("address")]
    public string CustomerStreetAddress { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "City is required")]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "City must be between 1 and 50 characters")]
    [RegularExpression(@"^[a-zA-Z\s\.\-']+$", ErrorMessage = "City contains invalid characters")]
    [Column("city")]
    public string City { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "State is required")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "State must be between 2 and 50 characters")]
    [RegularExpression(@"^[a-zA-Z\s\.\-]+$", ErrorMessage = "State contains invalid characters")]
    [Column("state")]
    public string State { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Postal code is required")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Postal code must be between 3 and 20 characters")]
    [RegularExpression(@"^[a-zA-Z0-9\s\-]+$", ErrorMessage = "Postal code contains invalid characters")]
    [Column("postal_code")]
    public string PostalCode { get; set; } = string.Empty;
    
    [Column("create_date")]
    public DateTime CreateDate { get; set; } = DateTime.Now;
}
