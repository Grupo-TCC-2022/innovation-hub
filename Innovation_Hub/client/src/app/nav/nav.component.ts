import { Component, Input, OnInit, TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { AccountService } from '../_services/account.service';
import { InterestAreasService } from '../_services/interestAreas.service';

@Component({
  // eslint-disable-next-line @angular-eslint/component-selector
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  public modalRef?: BsModalRef;
  constructor(private modalService: BsModalService, public accountService: AccountService, public interestedAreasService: InterestAreasService) { }
  model: any = {}
  interestareas: any = []
  interestareascount: any = 0;

  ngOnInit(): void {
  }

  onAreaSelect(e: any) {
    this.interestareas = this.interestareas.filter((element) => {
      if (e.target.value == element && !e.target.checked) {
        return false;
      } else {
        return true;
      }
    });
    if (e.target.checked) {
      this.interestareas.push(e.target.value);
    }
    this.model.interestAreas = this.interestareas;

    this.interestareascount = this.interestareas.length;
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  register() {
    console.log(this.model);
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
}
