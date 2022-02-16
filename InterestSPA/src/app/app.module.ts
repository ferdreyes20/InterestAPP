import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { RequestComponent } from './request/request.component';
import { RequestDetailComponent } from './request-detail/request-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    RequestComponent,
    RequestDetailComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: 'requests', component: RequestComponent },
      { path: 'requests/:id', component: RequestDetailComponent },
      { path: '', redirectTo: 'requests', pathMatch: 'full' },
      { path: '*', redirectTo: 'requests', pathMatch: 'full' }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
