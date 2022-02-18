import { Component, TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
 
@Component({
  // eslint-disable-next-line @angular-eslint/component-selector
  selector: 'app-nav',
  templateUrl: './nav.component.html'
})
export class NavComponent {
  modalRef?: BsModalRef;
  constructor(private modalService: BsModalService) {}

  model: any = {}
 
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  login() {
    console.log(this.model);
  }
}
