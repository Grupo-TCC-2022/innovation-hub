import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { InterestAreasService } from '../_services/interestAreas.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(public accountService: AccountService, public interestedAreasService: InterestAreasService) { }

  ngOnInit(): void {
  }

}
