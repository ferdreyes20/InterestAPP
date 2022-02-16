import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Message } from 'src/models/message.model';
import { Request } from '../../models/request.model';
import { RequestService } from '../../services/request.service';

@Component({
  selector: 'app-request',
  templateUrl: './request.component.html',
  styleUrls: ['./request.component.css']
})
export class RequestComponent implements OnInit {
  message!: Message;
  requests: Request[] = [];

  constructor(
    private route: ActivatedRoute,
    private service: RequestService
  ) { }

  ngOnInit(): void {
    let messageStatus = this.route.snapshot.paramMap.get("status");
    let messageText = this.route.snapshot.paramMap.get("message");
    if(messageStatus  && messageText) {
      this.message = {
        status: messageStatus,
        text: messageText
      };
    }

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
