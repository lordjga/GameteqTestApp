import { CurrencyRate } from "./currency-rate.model";

export interface Currency {
  id: number,
  name: string,
  multiplier: number,
  currencyRates: CurrencyRate[] 
}
