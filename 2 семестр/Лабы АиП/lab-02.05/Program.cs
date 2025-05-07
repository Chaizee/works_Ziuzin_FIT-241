class Suppliers
{
    public int Number { get; set; }
    public string OrgName { get; set; }
    public string MobileNumber { get; set; }

    public Suppliers(int number, string orgName, string mobileNumber)
    {
        Number = number;
        OrgName = orgName;
        MobileNumber = mobileNumber;
    }
}

class Products
{
    public int Number { get; set; }
    public string Name { get; set; }
    public Products(int number, string name)
    {
        Number = number;
        Name = name;
    }
}
class ProductsMovement
{
    public int ProductNumber { get; set; }
    public enum OperationType
    {
        Receipt,
        Sale
    }

    public OperationType operationType { get; set; }

    private int? _suppliersNumber;
    public int? SuppliersNumber
    {
        get
        {
            return operationType == OperationType.Receipt ? _suppliersNumber : (int?)null;
        }

        set
        {
            if (operationType == OperationType.Receipt)
            {
                _suppliersNumber = value;
            }
        }
    }

    public string Date { get; set; }
    public int Count { get; set; }
    public float Price { get; set; }

    public ProductsMovement(int productNumber, int? suppliersNumber, OperationType operationType, string date, int count, float price)
    {
        ProductNumber = productNumber;
        SuppliersNumber = suppliersNumber;
        this.operationType = operationType;
        Date = date;
        Count = count;
        Price = price;
    }
}

class Program
{
    static void Main(String[] args)
    {
        List<ProductsMovement> productsMovementList = new List<ProductsMovement>();
        List<Suppliers> suppliersList = new List<Suppliers>();
        List<Products> productsList = new List<Products>();
/*
        productsList.Add(new Products(1, "hot"));
        productsList.Add(new Products(2, "got"));
        productsList.Add(new Products(3, "jot"));

        suppliersList.Add(new Suppliers(1, "proorg", "81945420575"));
        suppliersList.Add(new Suppliers(2, "jotorg", "81947533291"));
        suppliersList.Add(new Suppliers(3, "gsoorg", "81947531441"));


        productsMovementList.Add(new ProductsMovement(1, null, ProductsMovement.OperationType.Sale, "23.03", 10, 26));
        productsMovementList.Add(new ProductsMovement(1, 1, ProductsMovement.OperationType.Receipt, "21.03", 15, 26));
        productsMovementList.Add(new ProductsMovement(2, null, ProductsMovement.OperationType.Sale, "21.03", 9, 56));
        productsMovementList.Add(new ProductsMovement(2, 2, ProductsMovement.OperationType.Receipt, "19.03", 24, 56));
        productsMovementList.Add(new ProductsMovement(3, null, ProductsMovement.OperationType.Sale, "15.03", 5, 14));
        productsMovementList.Add(new ProductsMovement(3, 3, ProductsMovement.OperationType.Receipt, "12.03", 8, 14));
*/
        Console.WriteLine("Остатки товаров: ");
        var productBalanc = productsMovementList
            .GroupBy(prod => prod.ProductNumber)
            .Select(g => new
            {
                ProductNumber = g.Key,
                TotalStock = g.Sum(m => m.operationType == ProductsMovement.OperationType.Receipt ? m.Count : -m.Count),
            }
            );

        foreach (var product in productBalanc)
        {
            Console.WriteLine($"Товар: {product.ProductNumber}, Остаток: {product.TotalStock}");
        }


        Console.WriteLine("\nТовары сгруппированные по поставщикам: ");
        var suppliersProduct = productsMovementList
            .Where(prod => prod.operationType == ProductsMovement.OperationType.Receipt)
            .GroupBy(prod => prod.SuppliersNumber);

        foreach (var products in suppliersProduct)
        {
            Console.WriteLine($"Поставщик: {products.Key}, Товары: ");

            foreach (var product in products)
            {
                Console.WriteLine(product.ProductNumber);
            }
        }

        Console.WriteLine("\nТовары сгруппированные по дате продажи: ");
        var dateProduct = productsMovementList
            .Where(prod => prod.operationType == ProductsMovement.OperationType.Sale)
            .GroupBy(prod => prod.Date);

        foreach (var products in dateProduct)
        {
            Console.WriteLine($"Дата продажи: {products.Key}, Товары: ");

            foreach(var product in products)
            {
                Console.WriteLine(product.ProductNumber);
            }
        }

     }
}

