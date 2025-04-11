//Структуры: БД библиотека, элементы, которые характеризуют книгу: ФИО автора, навзание книги, год издания, издательство, сведения о выдаче и возврате книги в виде 
// дата выдачи, дата возврата. 
// Необходимо выдать книги, которые ни разу не выдавались, и выдать книги, которые не возвращены

class LibraryTransaction
{
    public string issueDate { get; set; }
    public string returnDate { get; set; }

    public LibraryTransaction(string issueDate, string returnDate)
    {
        this.issueDate = issueDate;
        this.returnDate = returnDate;
    }
}
struct Book
{
    public string AuthorName { get; }
    public string BookName { get; }
    public int EditionYear { get; }
    public string EditionName { get; }
    public List<LibraryTransaction> Transactions { get; }

    public Book(string authorName, string bookName, int editionYear, string editionName, List<LibraryTransaction> transactions)
    {
        this.AuthorName = authorName;
        this.BookName = bookName;
        this.EditionYear = editionYear;
        this.EditionName = editionName;
        this.Transactions = transactions ?? new List<LibraryTransaction>();
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Book> books = new List<Book>();
        books.Add(new Book("Грибоедов С.Г.", "Горе от ума", 1986, "Звезда", new List<LibraryTransaction> { new LibraryTransaction("12.03.2007", "14.03.2008") }));
        books.Add(new Book("Пушкин А.С.", "Евгений Онегин", 1987, "Звезда", new List<LibraryTransaction> { new LibraryTransaction("02.08.2003", "null") }));
        books.Add(new Book("Данте Алигьери", "Божественная комедия", 2010, "Звезда", new List<LibraryTransaction> { new LibraryTransaction("null", "null") }));

        Console.WriteLine("Ни разу не выданные книги:");
        foreach (Book book in books)
        {
            if (book.Transactions.LastOrDefault().issueDate == "null")
            {
                Console.WriteLine(book.BookName + "," + book.AuthorName);
            }
        }
        Console.WriteLine("\nНе возвращенные книги:");
        foreach (Book book in books)
        {
            if (book.Transactions.LastOrDefault().returnDate == "null" && book.Transactions.LastOrDefault().issueDate != "null")
            {
                Console.WriteLine(book.BookName + "," + book.AuthorName);
            }
        }

    }
}


