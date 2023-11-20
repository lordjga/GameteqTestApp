import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Currency } from "../../shared/models/currency.model";
import { environment } from "../../../../environments/environment";

@Injectable({
  providedIn: 'root'
})

export class HomeApiService {
  constructor(private httpClient: HttpClient) { }

  public getAllCurrencies(): Observable<Currency[]> {
    return this.httpClient.get<Currency[]>(environment.baseUrl + "api/Currency/getAllCurrencies");
      //.pipe(map(result => this.userMapService.convertRequestToUsers(result)));
  }
}
