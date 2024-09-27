//  12.სესხის უფლებამოსილება
//  დაწერეთ პროგრამა, რომელიც განსაზღვრავს, არის თუ არა პირი სესხის მისაღებად უფლებამოსილი. პირობებია:
//  პირი უნდა იყოს 18 წლის ან უფროსი.
//      პირს უნდა ჰქონდეს მინიმუმ $25,000 წლიური შემოსავალი.
//      თუ პირს შემოსავალი ნაკლები აქვს $25,000-ზე, ის შეიძლება იყოს უფლებამოსილი თანამონაწილის (თავდების)
//      ყოლის შემთხვევაში.

/// თუ შემოსავალი არის 25000  - 50000 მაშინ მოქმედებს პირველი ლიმიტი
/// თუ შემოსავალი არის 50000  - 70000 მაშინ მოქმედებს მეორე ლიმიტი
/// თუ შემოსავალი არის 70000  - უსასრულობა მაშინ მოქმედებს მესამე ლიმიტი

decimal limit1 = 10_000m;
decimal limit2 = 20_000m;
decimal limit3 = 30_000m;

Console.Write("Enter Age: ");
var age = int.Parse(Console.ReadLine());

Console.Write("Salary: ");
var salary = decimal.Parse(Console.ReadLine());

Console.Write("Has Responsible person: ");
var hasResponsiblePerson = bool.Parse(Console.ReadLine());

Console.Write("Requested Loan amount: ");
var requestedLoanAmount = decimal.Parse(Console.ReadLine());

if (age >= 18)
{
    decimal limit;
    do
    {
        // ToDo: Add getting requested amount from console
        limit = CheckLimits();
    } while (limit > 0);
}
else
{
    Console.WriteLine("No loans for underage customers");
}

decimal CheckLimits()
{
    if (salary >= 25_000 && salary < 50_000)
    {
        limit1 = DisburseLoan(requestedLoanAmount, limit1);
        return limit1;
    }
    else if (salary >= 50_000 && salary < 70_000)
    {
        limit2 = DisburseLoan(requestedLoanAmount, limit2);
        return limit2;
    }
    else if (salary >= 70_000)
    {
        limit3 = DisburseLoan(requestedLoanAmount, limit3);
        return limit3;
    }
    else if (hasResponsiblePerson)
    {
        limit1 = DisburseLoan(requestedLoanAmount, limit1);
        return limit1;
    }

    return 0;
}
decimal DisburseLoan(decimal amount, decimal limit)
{
    const decimal loanCommissionRate = 0.01m;

    if (amount + amount * loanCommissionRate <= limit)
    {
        limit -= amount + amount * loanCommissionRate;
        Console.WriteLine($"Loan approved. You have left {limit} limit");
    }
    else
    {
        Console.WriteLine($"Limit Exceeded. Limit is {limit}, you have requested: {amount}");
    }

    return limit;
}