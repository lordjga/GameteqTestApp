import { Currency } from "./currency.model";

export interface CurrencyRate {
  id: number,
  currencyId: number,
  date: Date,
  rate: number,
  currency: Currency
}
