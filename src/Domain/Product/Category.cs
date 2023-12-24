using Flunt.Validations;
using System.Diagnostics.Contracts;

namespace OrderWebAPI.Domain.Product;

public class Category : Entity
{
    public Category(string name, string createdBy, string editedBy)
    {
        var contract = new Contract<Category>()
            .IsNotNullOrEmpty(name, "Name", "Category name is required or not found")
            .IsGreaterOrEqualsThan(name, 3, "Name")
            .IsNotNullOrEmpty(createdBy, "CreatedBy", "CreatedBy is required or not found")
            .IsNotNullOrEmpty(editedBy, "EditedBy", "EditedBy is required or not found");
        AddNotifications(contract);

        Name = name;
        Active = true;
        CreatedBy = createdBy;
        CreatedOn = DateTime.Now;
        EditedBy = editedBy;
        EditedOn = DateTime.Now;
    }
}
