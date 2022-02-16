import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Request } from 'src/models/request.model';

@Injectable({
  providedIn: 'root'
})
export class RequestService {
  apiUrl = "http://localhost:5000/Request/";

  constructor(private httClient: HttpClient) { }

  getRequestList(): Observable<Request[]> {
    return this.httClient.get<Request[]>(this.apiUrl + "GetRequestList");
  };

  getRequestById(id: number): Observable<Request> {
    return this.httClient.get<Request>(this.apiUrl + "GetRequest/" + id);
  };
}
