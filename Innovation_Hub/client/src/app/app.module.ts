import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ModalModule } from 'ngx-bootstrap/modal';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { HomeComponent } from './home/home.component';
import { WelcomeDropdownComponent } from './nav/welcome-dropdown/welcome-dropdown.component';
import { AppRoutingModule } from './app-routing.module';
import { RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { FeedComponent } from './feed/feed/feed.component';
import { MessagesComponent } from './feed/messages/messages.component';
import { FeedCardComponent } from './feed/feed-card/feed-card.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    WelcomeDropdownComponent,
    NotFoundComponent,
    ServerErrorComponent,
    FeedComponent,
    MessagesComponent,
    FeedCardComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ModalModule.forRoot(),
    FormsModule,
    BsDropdownModule.forRoot(),
    AppRoutingModule,
    RouterModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
    TabsModule,
    FontAwesomeModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
