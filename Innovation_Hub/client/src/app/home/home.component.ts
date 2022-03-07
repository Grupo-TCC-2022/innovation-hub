import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { InterestAreasService } from '../_services/interestAreas.service';
import { ProposalsService } from '../_services/proposals.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public proposalType: any = "projects";

  constructor(public accountService: AccountService, public interestedAreasService: InterestAreasService, public proposalsService: ProposalsService) { }

  onProjectsTab() {
    this.proposalType = "projects"
  }

  onIdeasTab() {
    this.proposalType = "ideas"
  }

  onProblemsTab() {
    this.proposalType = "problems"
  }

  ngOnInit(): void {
  }

}
