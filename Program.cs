System.Console.Write("Enter the number of products: ");
int productsCount = int.Parse(Console.ReadLine());
int counter = 1;

List<Product> products = new();

while (counter <= productsCount)
{
  System.Console.WriteLine($"Product #{counter} data:");
  System.Console.Write("Common, used or imported (c/u/i)? ");
  var type = Console.ReadLine();

  System.Console.Write("Name: ");
  var name = Console.ReadLine();
  
  System.Console.Write("Price: ");
  var price = double.Parse(Console.ReadLine());

  if (type.ToLower() == "u")
  {
    System.Console.Write("Manufacture date (DD/MM/YYYY): ");
    var date = Console.ReadLine();
    var splitDate = date.Split("/");
    var year = int.Parse(splitDate[2]);
    var month = int.Parse(splitDate[1]);
    var day = int.Parse(splitDate[0]);

    var product = new UsedProduct(name, price, new DateTime(year, month, day));
    products.Add(product);
  }
  else if (type.ToLower() == "i")
  {
    System.Console.Write("Customs fee: ");
    var customsFee = double.Parse(Console.ReadLine());

    var product = new ImportedProduct(name, price, customsFee);
    products.Add(product);
  }
  else
  {
    var product = new Product(name, price);
    products.Add(product);
  }

  counter++;
}

System.Console.WriteLine("PRICE TAGS:");
foreach(var product in products)
{
  System.Console.WriteLine(product.PriceTag());
}