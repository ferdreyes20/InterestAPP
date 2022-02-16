import { Component, OnInit } from '@angular/core';
import { Request } from '../../models/request.model';
import { RequestService } from '../../services/request.service';

@Component({
  selector: 'app-request',
  templateUrl: './request.component.html',
  styleUrls: ['./request.component.css']
})
export class RequestComponent implements OnInit {

  requests: Request[] = [];

  constructor(
    private service: RequestService
  ) { }

  ngOnInit(): void {
    this.service.getRequestList()
      .subscribe(
        (data: Request[]) => { 
          this.requests = data;
          this.requests.sort((a, b) => {
            return a.id > b.id ? -1 : 1; 
         });
        },
        (error) => { alert(error); }
      );
  }
}
