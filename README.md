# GameteqTestApp

CurrencyReading:
  Console application which loads currencies from https://www.cnb.cz/en/financial_markets/foreign_exchange_market/exchange_rate_fixing/year.txt?year=2023, parses and stores data in the DB. Year is entered manually.

CurrencyRate:
  Angular SPA which displays currencies with ability to select currency and date.

CurrencyRate.API:
  ASP.NET Core Web API application which has two endpoints
    http://localhost:40443/api/currency/get - returns all currencies stored in the db
    http://localhost:40443/api/currency/getRate?currencyId={int}&date={yyyy-MM-dd} - returns a currency rate object on a specified day for the selected currency in relation to the Czech crown
