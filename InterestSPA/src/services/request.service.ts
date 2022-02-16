import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Request } from 'src/models/request.model';
import { environment } from '../environments/environment'

@Injectable({
  providedIn: 'root'
})
export class RequestService {

  constructor(private httClient: HttpClient) { }

  getRequestList(): Observable<Request[]> {
    return this.httClient.get<Request[]>(environment.interestApi.request.getRequestList);
  };

  getRequestById(id: number): Observable<Request> {

    return this.httClient.get<Request>(`${environment.interestApi.request.getRequest}?id=${id}`);
  };
}
