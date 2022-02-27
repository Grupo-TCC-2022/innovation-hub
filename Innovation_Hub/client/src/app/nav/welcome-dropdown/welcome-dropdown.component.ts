import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-welcome-dropdown',
  templateUrl: './welcome-dropdown.component.html',
  styleUrls: ['./welcome-dropdown.component.css']
})
export class WelcomeDropdownComponent implements OnInit {

  constructor(public accountService: AccountService, private router: Router) { }

  ngOnInit(): void {
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }
}
