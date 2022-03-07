import { Component, OnInit } from '@angular/core';
import { BehaviorSubject, forkJoin, Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { ItemFilter } from '../_interfaces/ItemFilter';
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
  obsArray: BehaviorSubject<any[]> = new BehaviorSubject<any[]>([]);
  items$: Observable<any> = this.obsArray.asObservable();
  filterDto: ItemFilter = {
    skip: 0,
    take: 20
  }

  constructor(public accountService: AccountService, public interestedAreasService: InterestAreasService, public proposalsService: ProposalsService) { }

  onProjectsTab() {
    this.filterDto.skip = 0;
    this.obsArray.next([]);
    this.proposalType = "projects";
    this.getProjectsScroll();
  }

  onIdeasTab() {
    this.filterDto.skip = 0;
    this.obsArray.next([]);
    this.proposalType = "ideas";
    this.getIdeasScroll();
  }

  onProblemsTab() {
    this.filterDto.skip = 0;
    this.obsArray.next([]);
    this.proposalType = "problems";
    this.getProblemsScroll();
  }

  onProjectsScroll(event: any) {
    // visible height + pixel scrolled >= total height 
    if (event.target.offsetHeight + event.target.scrollTop >= event.target.scrollHeight) {
      console.log("End");
      this.getProjectsScroll();
    }
  }

  onIdeasScroll(event: any) {
    // visible height + pixel scrolled >= total height 
    if (event.target.offsetHeight + event.target.scrollTop >= event.target.scrollHeight) {
      console.log("End");
      this.getIdeasScroll();
    }
  }

  onProblemsScroll(event: any) {
    // visible height + pixel scrolled >= total height 
    if (event.target.offsetHeight + event.target.scrollTop >= event.target.scrollHeight) {
      console.log("End");
      this.getProblemsScroll();
    }
  }

  getProjectsScroll() {
    const filter = this.turnFilterIntoUrl(this.filterDto);

    if (this.filterDto.skip == 0) {
      this.filterDto.skip += 20;
    }

    this.proposalsService.getProjectsScroll(filter).subscribe((response: any) => {
      const currentValue = this.obsArray.value;
      let updatedValue;
      if (currentValue.length > 0) {
        updatedValue = [...currentValue, response];
        updatedValue = [].concat.apply([], updatedValue)
      } else {
        updatedValue = response;
      }
      console.log(updatedValue);
      this.obsArray.next(updatedValue);
    }, error => {
      console.log(error);
    });
  }

  getIdeasScroll() {
    const filter = this.turnFilterIntoUrl(this.filterDto);

    if (this.filterDto.skip == 0) {
      this.filterDto.skip += 20;
    }

    this.proposalsService.getIdeasScroll(filter).subscribe((response: any) => {
      const currentValue = this.obsArray.value;
      let updatedValue;
      if (currentValue.length > 0) {
        updatedValue = [...currentValue, response];
        updatedValue = [].concat.apply([], updatedValue)
      } else {
        updatedValue = response;
      }
      console.log(updatedValue);
      this.obsArray.next(updatedValue);
    }, error => {
      console.log(error);
    });
  }

  getProblemsScroll() {
    const filter = this.turnFilterIntoUrl(this.filterDto);

    if (this.filterDto.skip == 0) {
      this.filterDto.skip += 20;
    }

    this.proposalsService.getProblemsScroll(filter).subscribe((response: any) => {
      const currentValue = this.obsArray.value;
      let updatedValue;
      if (currentValue.length > 0) {
        updatedValue = [...currentValue, response];
        updatedValue = [].concat.apply([], updatedValue)
      } else {
        updatedValue = response;
      }
      console.log(updatedValue);
      this.obsArray.next(updatedValue);
    }, error => {
      console.log(error);
    });
  }

  ngOnInit(): void {
    this.getProjectsScroll();
  }

  turnFilterIntoUrl(filterDto?: ItemFilter) {
    if (filterDto.skip != 0) {
      filterDto.skip += 20;
    }

    let urlFilter = '?';

    for (const [key, value] of Object.entries(filterDto)) {
      urlFilter += `${key}=${value}&`;
    }

    return urlFilter.substring(0, urlFilter.length - 1);
  }
}
