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

  public getRequest<T>(url: string): Observable<T> {
    return this.httpClient.get<T>(environment.baseUrl + url);
  }
}
