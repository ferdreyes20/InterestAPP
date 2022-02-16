import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Message } from 'src/models/message.model';
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
    private route: ActivatedRoute,
    private router: Router
  ) { }

  message!: Message;
  request!: Request;

  ngOnInit(): void {
    let messageStatus = this.route.snapshot.paramMap.get("status");
    let messageText = this.route.snapshot.paramMap.get("message");
    if(messageStatus  && messageText) {
      this.message = {
        status: messageStatus,
        text: messageText
      };
    }

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

  editRequest(requestId: number) {
    this.router.navigate([`/request/edit/${requestId}`])
  }

  deleteRequest() {
    this.service.removeRequest(this.request.id)
      .subscribe(
        (data: number) => {
          this.router.navigate(['/requests', { status: "1", message: "Request deleted successful" }]);
        },
        (error) => {
          alert(error)
        },
      );
  }
}
