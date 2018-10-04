import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Broker } from '../_models/broker';
import { App } from '../_models/App';
import { PaginatedResult } from '../_models/pagination';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BrokerService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getApps(): Observable<App[]> {
    return this.http.get<App[]>(this.baseUrl + 'apps');
  }

  getAppsForBroker(brokerid): Observable<App[]> {
    return this.http.get<App[]>(this.baseUrl + 'apps/' + brokerid);
  }

  getBrokers(page?, itemsPerPage?): Observable<PaginatedResult<Broker[]>> {
    const paginatedResult: PaginatedResult<Broker[]> = new PaginatedResult<Broker[]>();

    let params = new HttpParams();
    if (page != null && itemsPerPage != null) {
      params = params.append('pageNumber', page);
      params = params.append('pageSize', itemsPerPage);
    }

    return this.http.get<Broker[]>(this.baseUrl + 'brokers', { observe: 'response', params})
    .pipe(
      map(response => {
        paginatedResult.result = response.body;
        if (response.headers.get('Pagination') != null) {
          paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
        }
        return paginatedResult;
      })
    );
  }

  getBroker(id): Observable<Broker> {
    return this.http.get<Broker>(this.baseUrl + 'brokers/' + id);
  }

}
