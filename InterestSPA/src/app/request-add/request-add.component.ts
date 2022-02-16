import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RequestService } from 'src/services/request.service';

@Component({
  selector: 'app-request-add',
  templateUrl: './request-add.component.html',
  styleUrls: ['./request-add.component.css']
})
export class RequestAddComponent implements OnInit {
  value!: number;

  constructor(
    private router: Router,
    private service: RequestService
  ) { }

  ngOnInit(): void {
  }

  public addFormOnSubmit(): void {
    this.service.addRequest(this.value)
      .subscribe(
        (requestId: number) => {
          this.router.navigate([`/requests/${requestId}`, { status: "1", message: "Request added successful" }]);
        },
        (error) => {
          alert(error)
        }
      );
  }
}
