import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { RequestComponent } from './request/request.component';
import { RequestDetailComponent } from './request-detail/request-detail.component';
import { RequestAddComponent } from './request-add/request-add.component';
import { FormsModule } from '@angular/forms';
import { RequestEditComponent } from './request-edit/request-edit.component';
import { MessageComponent } from './common/message/message.component';

@NgModule({
  declarations: [
    AppComponent,
    RequestComponent,
    RequestDetailComponent,
    RequestAddComponent,
    RequestEditComponent,
    MessageComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'requests', component: RequestComponent},
      { path: 'requests/add', component: RequestAddComponent },
      { path: 'requests/:id', component: RequestDetailComponent },
      { path: 'requests/edit/:id', component: RequestEditComponent },
      { path: '', redirectTo: 'requests', pathMatch: 'full' },
      { path: '*', redirectTo: 'requests', pathMatch: 'full' }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
