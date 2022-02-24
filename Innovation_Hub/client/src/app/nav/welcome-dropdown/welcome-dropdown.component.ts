import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-welcome-dropdown',
  templateUrl: './welcome-dropdown.component.html',
  styleUrls: ['./welcome-dropdown.component.css']
})
export class WelcomeDropdownComponent implements OnInit {

  constructor(public accountService: AccountService) { }

  ngOnInit(): void {
  }
  
  logout() {
    this.accountService.logout();
  }
}
