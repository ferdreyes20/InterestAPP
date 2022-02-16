import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Request } from '../../models/request.model';

@Component({
  selector: 'app-request',
  templateUrl: './request.component.html',
  styleUrls: ['./request.component.css']
})
export class RequestComponent implements OnInit {

  requests: Request[] = [
    {
      id: 1,
      value: 1000,
      computations: [
        {
          id: 1,
          year: 1,
          value: 1000,
          interestRate: 0.10,
          futureValue: 1100
        },
        {
          id: 2,
          year: 2,
          value: 1100,
          interestRate: 0.30,
          futureValue: 1430
        },
        {
          id: 3,
          year: 3,
          value: 1430,
          interestRate: 0.50,
          futureValue: 2145
        },
        {
          id: 4,
          year: 4,
          value: 2145,
          interestRate: 0.50,
          futureValue: 1234.5
        }
      ]
    }
  ];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    debugger;
    this.http.get<Request[]>("http://localhost:5000/Request/GetRequestList")
      .subscribe(
        (data) => { debugger; this.requests = data; },
        (error) => { debugger; alert(error); }
      );
  }

}
