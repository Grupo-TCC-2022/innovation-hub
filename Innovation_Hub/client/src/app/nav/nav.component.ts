import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';
 
@Component({
  // eslint-disable-next-line @angular-eslint/component-selector
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  public modalRef?: BsModalRef;
  constructor(private modalService: BsModalService, public accountService: AccountService) {}

  ngOnInit(): void {
  }

  model: any = {}
 
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  register() {
    this.accountService.register(this.model, this).subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    });
  }

  login() {
    this.accountService.login(this.model, this).subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    });
  }

  logout() {
    this.accountService.logout();
  }
}
