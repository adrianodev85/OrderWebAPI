using Flunt.Validations;
using System.Diagnostics.Contracts;

namespace OrderWebAPI.Domain.Product;

public class Category : Entity
{
    public string Name { get; private set; }
    public bool Active { get; private set; }
    public Category(string name, string createdBy, string editedBy)
    {
        Name = name;
        Active = true;
        CreatedBy = createdBy;
        CreatedOn = DateTime.Now;
        EditedBy = editedBy;
        EditedOn = DateTime.Now;

        Validate();

    }

    private void Validate()
    {
        var contract = new Contract<Category>()
            .IsNotNullOrEmpty(Name, "Name", "Category name is required or not found")
            .IsGreaterOrEqualsThan(Name, 3, "Name")
            .IsNotNullOrEmpty(CreatedBy, "CreatedBy", "CreatedBy is required or not found")
            .IsNotNullOrEmpty(EditedBy, "EditedBy", "EditedBy is required or not found");
        AddNotifications(contract);
    }

    public void EditInfo(string name, bool active)
    {
        Name = name;
        Active = active;
        Validate();
    }
}
