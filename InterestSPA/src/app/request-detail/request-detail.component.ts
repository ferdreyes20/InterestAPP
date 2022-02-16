import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Request } from '../../models/request.model';
import { RequestService } from '../../services/request.service';

@Component({
  selector: 'app-request-detail',
  templateUrl: './request-detail.component.html',
  styleUrls: ['./request-detail.component.css']
})
export class RequestDetailComponent implements OnInit {

  constructor(
    private service: RequestService,
    private route: ActivatedRoute
  ) { }

  request!: Request;

  ngOnInit(): void {
    let requestId = Number(this.route.snapshot.paramMap.get("id"));
    this.service.getRequestById(requestId).
      subscribe(
        (data) => {
          this.request = data;
        },
        (error) => {
          alert(error)
        },
      );
  }

}
