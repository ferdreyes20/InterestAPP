import { Component, OnInit } from '@angular/core';
import { Computation } from '../models/computation.model';
import { Request } from '../models/request.model'

@Component({
  selector: 'app-request',
  templateUrl: './request.component.html',
  styleUrls: ['./request.component.css']
})
export class RequestComponent implements OnInit {

  requests: Request[] = [
    {
      id: 1,
      name: "1",
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
          futureValue: 3217.5
        }
      ]
    }
  ];

  constructor() { }

  ngOnInit(): void {
  }

}
