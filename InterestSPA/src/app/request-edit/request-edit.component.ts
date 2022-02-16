import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestService } from 'src/services/request.service';
import { Request } from 'src/models/request.model';

@Component({
  selector: 'app-request-edit',
  templateUrl: './request-edit.component.html',
  styleUrls: ['./request-edit.component.css']
})
export class RequestEditComponent implements OnInit {
  request!: Request;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: RequestService) { }

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

  public addFormOnSubmit(): void {
    this.service.updateRequest(this.request)
      .subscribe(
        (requestId: number) => {
          this.router.navigate([`/requests/${requestId}`]);
        },
        (error) => {
          alert(error)
        }
      );
  }
}
